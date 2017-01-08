Imports System.Runtime.InteropServices
Imports System.ComponentModel

Public Class ListRichTextBox
    Inherits RichTextBox

    '//APIs
    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, _
                                        ByVal msg As Integer, _
                                        ByVal wParam As Integer, _
                                        <[In]()> <Out()> _
                                        <MarshalAs(UnmanagedType.LPStruct)> _
                                        ByVal lParam As ListFormatInfo) As IntPtr
    End Function

    '//properties
    Private _selectionList As Boolean
    ''' <summary>
    ''' Gets or sets a value indicating whether the currently selected text uses a ListFormat.
    ''' </summary>
    ''' <remarks>Returns whether the currently selected text's ListFormat equals the currently chosen ListFormat.</remarks>
    <Browsable(False)> _
    <Description("Gets or sets a value indicating whether the currently selected text uses a ListFormat.")> _
    Public Property SelectionList() As Boolean
        Get
            Dim none As RichTextBoxSelectionAttribute = RichTextBoxSelectionAttribute.None
            If Me.IsHandleCreated Then
                Dim format As New ListFormatInfo()
                format.Tabs = New Integer(31) {}
                ListRichTextBox.SendMessage(New HandleRef(Me, MyBase.Handle), _
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
                ListRichTextBox.SendMessage(New HandleRef(Me, MyBase.Handle), _
                                            1095, 0, format)
            End If
        End Set
    End Property

    Private _listFormat As ListFormats = ListFormats.Bullets
    ''' <summary>
    ''' Gets or sets a value indicating the format to use on lists.
    ''' </summary>
    <DefaultValue(GetType(ListFormats), "Bullets")> _
    <Description("Gets or sets a value indicating the format to use on lists.")> _
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

    <Browsable(False)> _
    <EditorBrowsable(EditorBrowsableState.Never)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
    <StructLayout(LayoutKind.Sequential)> _
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

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
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