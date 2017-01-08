Option Explicit On

Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.ComponentModel
Imports System.Text
Imports System.Drawing.Printing

'By Martin Laflamme For Popotte 5.0
'Copyright Martin Laflamme 2016
'This control class replaces the use of the regular RichTextBox control; the
'purpose of this extension was specifically to facilitate printing the contents
'of a rich text box control and adding advanced functions.


'Specifies how text in a is
'horizontally aligned.

Public Enum TextAlign
    ''' <summary>
    ''' The text is aligned to the left.
    ''' </summary>
    Left = 1
    ''' <summary>
    ''' The text is aligned to the right.
    ''' </summary>
    Right = 2
    ''' <summary>
    ''' The text is aligned in the center.
    ''' </summary>
    Center = 3
    ''' <summary>
    ''' The text is justified.
    ''' </summary>
    Justify = 4
End Enum

Public Class AdvRichTextBoxPrintCtrl
    Inherits RichTextBox

    ' Convert the unit that is used by the .NET framework (1/100 inch) 
    ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
    Private Const AnInch As Double = 14.4

    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure CHARRANGE
        Public cpMin As Integer          ' First character of range (0 for start of doc)
        Public cpMax As Integer          ' Last character of range (-1 for end of doc)
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure FORMATRANGE
        Public hdc As IntPtr             ' Actual DC to draw on
        Public hdcTarget As IntPtr       ' Target DC for determining text formatting
        Public rc As RECT                ' Region of the DC to draw to (in twips)
        Public rcPage As RECT            ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE         ' Range of text to draw (see above declaration)
    End Structure

    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57

    Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

    ' Render the contents of the RichTextBox for printing
    '	Return the last character printed + 1 (printing start from this point for next page)
    Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

        ' Mark starting and ending character 
        Dim cRange As CHARRANGE
        cRange.cpMin = charFrom
        cRange.cpMax = charTo

        ' Calculate the area to render and print
        Dim rectToPrint As RECT
        rectToPrint.Top = e.MarginBounds.Top * AnInch
        rectToPrint.Bottom = e.MarginBounds.Bottom * AnInch
        rectToPrint.Left = e.MarginBounds.Left * AnInch
        rectToPrint.Right = e.MarginBounds.Right * AnInch

        ' Calculate the size of the page
        Dim rectPage As RECT
        rectPage.Top = e.PageBounds.Top * AnInch
        rectPage.Bottom = e.PageBounds.Bottom * AnInch
        rectPage.Left = e.PageBounds.Left * AnInch
        rectPage.Right = e.PageBounds.Right * AnInch

        Dim hdc As IntPtr = e.Graphics.GetHdc()

        Dim fmtRange As FORMATRANGE
        fmtRange.chrg = cRange                 ' Indicate character from to character to 
        fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
        fmtRange.hdcTarget = hdc               ' Point at printer hDC
        fmtRange.rc = rectToPrint              ' Indicate the area on page to print
        fmtRange.rcPage = rectPage             ' Indicate whole size of page

        Dim res As IntPtr = IntPtr.Zero

        Dim wparam As IntPtr = IntPtr.Zero
        wparam = New IntPtr(1)

        ' Move the pointer to the FORMATRANGE structure in memory
        Dim lparam As IntPtr = IntPtr.Zero
        lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
        Marshal.StructureToPtr(fmtRange, lparam, False)

        ' Send the rendered data for printing 
        res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

        ' Free the block of memory allocated
        Marshal.FreeCoTaskMem(lparam)

        ' Release the device context handle obtained by a previous call
        e.Graphics.ReleaseHdc(hdc)

        ' Return last + 1 character printer
        Return res.ToInt32()
    End Function


    Public Sub BeginUpdate()
        ' Deal with nested calls.
        updating += 1

        If updating > 1 Then
            Return
        End If

        ' Prevent the control from raising any events.
        oldEventMask = SendMessage(New HandleRef(Me, Handle), EM_SETEVENTMASK, 0, 0)

        ' Prevent the control from redrawing itself.
        SendMessage(New HandleRef(Me, Handle), WM_SETREDRAW, 0, 0)
    End Sub

    ''' <summary>
    ''' Resumes drawing and event handling.
    ''' </summary>
    ''' <remarks>
    ''' This method should be called every time a call is made
    ''' made to BeginUpdate. It resets the event mask to it's
    ''' original value and enables redrawing of the control.
    ''' </remarks>
    Public Sub EndUpdate()
        ' Deal with nested calls.
        updating -= 1

        If updating > 0 Then
            Return
        End If

        ' Allow the control to redraw itself.
        SendMessage(New HandleRef(Me, Handle), WM_SETREDRAW, 1, 0)

        ' Allow the control to raise event messages.
        SendMessage(New HandleRef(Me, Handle), EM_SETEVENTMASK, 0, oldEventMask)
    End Sub


    'Highlight selected text in rtf
    Public WriteOnly Property SelectionHighLight() As Color
        Set(ByVal Value As Color)
            'First, test SelectedText property NOT SelectedRTF property because
            '...SelectedRTF will never be nothing, it will always have at least
            '...the current default Font table
            If Me.SelectedText Is Nothing Then Exit Property
            Dim sb As New StringBuilder()           'use StringBuilder for speed 
            'and cleanliness
            Dim SelText As String = Me.SelectedRtf  'move to local string for speed
            Dim strTemp As String                   'used twice for ease of calculating 
            'internal coordinates
            Dim FontTableEnds As Integer            'end character of the rtf font table
            Dim ColorTableBegins As Integer         'beginning of the rtf color table
            Dim ColorTableEnds As Integer           'end of the rtf color table
            Dim StartLooking As Integer             'used to walk a string appending chunks
            Dim HighlightBlockStart As Integer      'used to find "\highlight#" block for 
            'stripping
            Dim HighlightBlockEnd As Integer        'used to find "\highlight#" block for 
            'stripping
            Dim cycl As Integer                     'used in For/Next loops
            Dim NewColorIndex As Integer = 0        'new color table index for incoming color

            'find the end of the font table
            FontTableEnds = InStr(1, SelText, "}}")
            'add the header and font table to the string accumulator
            sb.Append(Mid(SelText, 1, FontTableEnds + 1))

            'find the color table start
            ColorTableBegins = InStr(FontTableEnds, SelText, "{\colortbl")
            If ColorTableBegins = 0 Then 'no color table exists 
                'add a color table header
                sb.Append("{\colortbl ;")
                'no color table so for later use make the ColorTableEnd the same 
                ' as FontTableEnds
                ColorTableEnds = FontTableEnds
                'default our new color table index to 1 since it will be the only one
                'remember Color table index 0 is reserved 
                NewColorIndex = 1
            Else 'a color table already exists
                'find the end of the color table
                ColorTableEnds = InStr(ColorTableBegins, SelText, "}")
                'backup one character so as to exclude the brace
                ColorTableEnds -= 1
                'need to count the quantity of semi;colons which will
                '... determine what color table index number our new color will be
                strTemp = Mid(SelText, FontTableEnds + 2,
                              (ColorTableEnds - FontTableEnds) - 1)
                For cycl = 1 To strTemp.Length
                    If Mid(strTemp, cycl, 1) = ";" Then NewColorIndex += 1
                Next
                'append the color table without end brace
                sb.Append(strTemp)
            End If

            'append the color table entry for the highlight color
            sb.Append("\red" & Trim(Value.R.ToString))
            sb.Append("\green" & Trim(Value.G.ToString))
            sb.Append("\blue" & Trim(Value.B.ToString))
            'append the table entry terminator semi;colon

            sb.Append(";")
            'append the color table terminating brace
            sb.Append("}")
            'append the new highlight tag
            sb.Append("\highlight" & Trim(NewColorIndex.ToString))
            'Drop into a single string for easier manipulation
            strTemp = Mid(SelText, ColorTableEnds + 2,
                          (SelText.Length - ColorTableEnds) - 1)

            'begin at first character
            StartLooking = 1
            'append everything remaining, but strip all remaining highlight tags
            Do
                'find a "\highlight" block
                HighlightBlockStart = InStr(StartLooking, strTemp, "\highlight")
                'if no more "\highlight" block found
                If HighlightBlockStart = 0 Then
                    'append everything remaining
                    sb.Append(Mid(strTemp, StartLooking,
                                  strTemp.Length - StartLooking))
                    'we're done appending
                    Exit Do
                End If
                'calculate the end of the word "highlight"
                HighlightBlockEnd = HighlightBlockStart + 9
                'accomodate color tables with over 9 colors and thus multi-digit 
                'color indexes Plus, watch for (and discard) ONE space if it 
                'immediately follows the last digit
                Do
                    'keep stepping past end
                    HighlightBlockEnd += 1
                    'watch for (and discard) ONE space if it immediately follows the
                    ' last digit
                    If Mid(strTemp, HighlightBlockEnd + 1, 1) = " " Then
                        HighlightBlockEnd += 1
                        Exit Do
                    End If
                    'looking for the first non-numeric character
                Loop While InStr(1, "0123456789", Mid(strTemp, HighlightBlockEnd + 1, 1))
                'append this block
                sb.Append(Mid(strTemp, StartLooking, (HighlightBlockStart - StartLooking)))
                'move the start forward past the last "\highlight#" block
                StartLooking = HighlightBlockEnd + 1
            Loop

            Me.SelectedRtf = sb.ToString
        End Set
    End Property

    'Find highlighted text in rtf
    Public Sub FindHighlight(ByVal SearchText As String, ByVal HighlightColor As Color,
                             ByVal MatchCase As Boolean, ByVal WholeWords As Boolean)
        Me.SuspendLayout()
        Dim StartLooking As Integer = 0
        Dim FoundAt As Integer
        Dim SearchLength As Integer
        Dim RTBfinds As RichTextBoxFinds
        If SearchText Is Nothing Then Exit Sub
        Select Case True
            Case MatchCase And WholeWords
                RTBfinds = RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord
            Case MatchCase
                RTBfinds = RichTextBoxFinds.MatchCase
            Case WholeWords
                RTBfinds = RichTextBoxFinds.WholeWord
            Case Else
                RTBfinds = RichTextBoxFinds.None
        End Select
        SearchLength = SearchText.Length
        Do
            FoundAt = Me.Find(SearchText, StartLooking, RTBfinds)
            If FoundAt > -1 Then Me.SelectionBackColor = HighlightColor
            StartLooking = StartLooking + SearchLength
        Loop While FoundAt > -1
        Me.ResumeLayout()
    End Sub

    Public Sub BackColorSetWhole(ByVal BackColorDefault As Color)
        Me.SelectAll()
        Me.SelectionBackColor = BackColorDefault
    End Sub



    ''' <summary>
    ''' Gets or sets the alignment to apply to the current
    ''' selection or insertion point.
    ''' </summary>
    ''' <remarks>
    ''' Replaces the SelectionAlignment from
    ''' <see cref="RichTextBox"/>.
    ''' </remarks>
    Public Shadows Property SelectionAlignment() As TextAlign
        Get
            Dim fmt As New PARAFORMAT()
            fmt.cbSize = Marshal.SizeOf(fmt)

            ' Get the alignment.
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, fmt)

            ' Default to Left align.
            If (fmt.dwMask And PFM_ALIGNMENT) = 0 Then
                Return TextAlign.Left
            End If

            Return CType(fmt.wAlignment, TextAlign)

        End Get

        Set(ByVal value As TextAlign)
            Dim fmt As New PARAFORMAT()
            fmt.cbSize = Marshal.SizeOf(fmt)
            fmt.dwMask = PFM_ALIGNMENT
            fmt.wAlignment = CShort(value)

            ' Set the alignment.
            SendMessage(New HandleRef(Me, Handle), EM_SETPARAFORMAT, SCF_SELECTION, fmt)
        End Set
    End Property

    ''' <summary>
    ''' This member overrides
    ''' <see cref="Control"/>.OnHandleCreated.
    ''' </summary>
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)

        ' Enable support for justification.
        SendMessage(New HandleRef(Me, Handle), EM_SETTYPOGRAPHYOPTIONS, TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY)
    End Sub

    Private updating As Integer = 0
    Private oldEventMask As Integer = 0

    ' Constants from the Platform SDK.
    Private Const EM_SETEVENTMASK As Integer = 1073
    Private Const EM_GETPARAFORMAT As Integer = 1085
    Private Const EM_SETPARAFORMAT As Integer = 1095
    Private Const EM_SETTYPOGRAPHYOPTIONS As Integer = 1226
    Private Const WM_SETREDRAW As Integer = 11
    Private Const TO_ADVANCEDTYPOGRAPHY As Integer = 1
    Private Const PFM_ALIGNMENT As Integer = 8
    Private Const SCF_SELECTION As Integer = 1

    ' It makes no difference if we use PARAFORMAT or
    ' PARAFORMAT2 here, so I have opted for PARAFORMAT2.
    <StructLayout(LayoutKind.Sequential)>
    Private Structure PARAFORMAT
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Public rgxTabs As Integer()

        ' PARAFORMAT2 from here onwards.
        Public dySpaceBefore As Integer
        Public dySpaceAfter As Integer
        Public dyLineSpacing As Integer
        Public sStyle As Short
        Public bLineSpacingRule As Byte
        Public bOutlineLevel As Byte
        Public wShadingWeight As Short
        Public wShadingStyle As Short
        Public wNumberingStart As Short
        Public wNumberingStyle As Short
        Public wNumberingTab As Short
        Public wBorderSpace As Short
        Public wBorderWidth As Short
        Public wBorders As Short
    End Structure

    <DllImport("user32", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lp As PARAFORMAT) As Integer
    End Function


    '//APIs
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As HandleRef,
                                        ByVal msg As Integer,
                                        ByVal wParam As Integer,
                                        <[In]()> <Out()>
                                        <MarshalAs(UnmanagedType.LPStruct)>
                                        ByVal lParam As ListFormatInfo) As IntPtr
    End Function

    '//properties
    Private _selectionList As Boolean
    ''' <summary>
    ''' Gets or sets a value indicating whether the currently selected text uses a ListFormat.
    ''' </summary>
    ''' <remarks>Returns whether the currently selected text's ListFormat equals the currently chosen ListFormat.</remarks>
    <Browsable(False)>
    <Description("Gets or sets a value indicating whether the currently selected text uses a ListFormat.")>
    Public Property SelectionList() As Boolean
        Get
            Dim none As RichTextBoxSelectionAttribute = RichTextBoxSelectionAttribute.None
            If Me.IsHandleCreated Then
                Dim format As New ListFormatInfo()
                format.Tabs = New Integer(31) {}
                AdvRichTextBoxPrintCtrl.SendMessage(New HandleRef(Me, MyBase.Handle),
                                            1085, 0, format)
                If ((32 And format.Mask) <> 0) Then
                    If (format.Numbering = Me._listFormat) Then
                        none = RichTextBoxSelectionAttribute.All
                    End If
                    Return (none = RichTextBoxSelectionAttribute.All)
                End If
            End If
            Return False
        End Get
        Set(ByVal value As Boolean)
            If MyBase.IsHandleCreated Then
                Dim format As New ListFormatInfo()
                format.Mask = 36
                If Not value Then
                    format.Numbering = Convert.ToInt16(ListFormats.None)
                    format.Offset = 0
                Else
                    format.Numbering = Convert.ToInt16(Me._listFormat)
                    format.Offset = MyBase.BulletIndent
                End If
                AdvRichTextBoxPrintCtrl.SendMessage(New HandleRef(Me, MyBase.Handle),
                                            1095, 0, format)
            End If
        End Set
    End Property

    Private _listFormat As ListFormats = ListFormats.Bullets
    ''' <summary>
    ''' Gets or sets a value indicating the format to use on lists.
    ''' </summary>
    <DefaultValue(GetType(ListFormats), "Bullets")>
    <Description("Gets or sets a value indicating the format to use on lists.")>
    Public Property ListFormat() As ListFormats
        Get
            Return Me._listFormat
        End Get
        Set(ByVal value As ListFormats)
            If [Enum].IsDefined(GetType(ListFormats), value) Then
                Me._listFormat = value
            End If
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property SelectionBullet() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            MyBase.SelectionBullet = False
        End Set
    End Property

    '//enumerations
    ''' <summary>
    ''' Represents an enumeration of valid formats for lists in the control.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ListFormats
        None = 0
        Bullets = 1
        Numbered = 2
        LowercaseLetters = 3
        UppercaseLetters = 4
        LowercaseRomanNumeral = 5
        UppercaseRomanNumeral = 6
        SmallBullets = 8
    End Enum

    '//nested classes
    <StructLayout(LayoutKind.Sequential)>
    Private Class ListFormatInfo

        '//properties
        Private _size As Integer
        Public Property Size() As Integer
            Get
                Return Me._size
            End Get
            Set(ByVal value As Integer)
                Me._size = value
            End Set
        End Property

        Private _mask As Integer
        Public Property Mask() As Integer
            Get
                Return Me._mask
            End Get
            Set(ByVal value As Integer)
                Me._mask = value
            End Set
        End Property

        Private _numbering As Short
        Public Property Numbering() As Short
            Get
                Return Me._numbering
            End Get
            Set(ByVal value As Short)
                Me._numbering = value
            End Set
        End Property

        Private _reserved As Short
        Public Property Reserved() As Short
            Get
                Return Me._reserved
            End Get
            Set(ByVal value As Short)
                Me._reserved = value
            End Set
        End Property

        Private _startIndent As Integer
        Public Property StartIndent() As Integer
            Get
                Return Me._startIndent
            End Get
            Set(ByVal value As Integer)
                Me._startIndent = value
            End Set
        End Property

        Private _rightIndent As Integer
        Public Property RightIndent() As Integer
            Get
                Return Me._rightIndent
            End Get
            Set(ByVal value As Integer)
                Me._rightIndent = value
            End Set
        End Property

        Private _offset As Integer
        Public Property Offset() As Integer
            Get
                Return Me._offset
            End Get
            Set(ByVal value As Integer)
                Me._offset = value
            End Set
        End Property

        Private _alignment As Short
        Public Property Alignment() As Short
            Get
                Return Me._alignment
            End Get
            Set(ByVal value As Short)
                Me._alignment = value
            End Set
        End Property

        Private _tabCount As Short
        Public Property TabCount() As Short
            Get
                Return Me._tabCount
            End Get
            Set(ByVal value As Short)
                Me._tabCount = value
            End Set
        End Property

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Private _tabs As Integer()
        Public Property Tabs() As Integer()
            Get
                Return Me._tabs
            End Get
            Set(ByVal value As Integer())
                Me._tabs = value
            End Set
        End Property





        '//constructors
        Public Sub New()
            Me._size = Marshal.SizeOf(GetType(ListFormatInfo))
        End Sub
    End Class

End Class


