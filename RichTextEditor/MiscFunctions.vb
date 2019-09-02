Imports System.Text.RegularExpressions

'GPL 3
'Read "Gnu GPL v3.txt"

Module MiscFunctions
    ' ...
    ''' <summary>
    ''' Convert a string of the format "color [nameOfColor]" or
    ''' "color [A=a, R=r, G=g, B=b]" to a System.Drawing.Color.
    ''' </summary>
    ''' <param name="s">A String representing the color (Color[Colorname or ARGB]).</param>
    ''' <returns>A System.Drawing.Color.</returns>
    ''' <remarks>Returns Black if the color could not be parsed.</remarks>
    Public Function ColorFromData(s As String) As Color
        Dim fallbackColor As Color = Color.Black

        If Not s.StartsWith("color", StringComparison.OrdinalIgnoreCase) Then
            Return fallbackColor
        End If

        ' Extract whatever is between the brackets.
        Dim str1 As String = s.Remove(0, 6)
        Dim re = New Regex("([^\[\]]+)")
        Dim colorNameMatch = re.Match(str1)

        'convert to Color object
        Dim colorName As String = colorNameMatch.Value.ToString
        'if color is a name
        If Not String.IsNullOrEmpty(colorName) And Not colorName.StartsWith("A=") Then
            Return Color.FromName(colorName)
        Else
            ' Was not a named color. Parse for ARGB values.
            re = New Regex("A=(\d+).*?R=(\d+).*?G=(\d+).*?B=(\d+)", RegexOptions.IgnoreCase)
            Dim componentMatches = re.Match(colorName)

            If componentMatches.Success Then

                Dim a = Integer.Parse(componentMatches.Groups(1).Value)
                Dim r = Integer.Parse(componentMatches.Groups(2).Value)
                Dim g = Integer.Parse(componentMatches.Groups(3).Value)
                Dim b = Integer.Parse(componentMatches.Groups(4).Value)

                Dim maxValue = 255

                If a > maxValue OrElse r > maxValue OrElse g > maxValue OrElse b > maxValue Then
                    Return fallbackColor
                End If

                Return System.Drawing.Color.FromArgb(a, r, g, b)

            End If

            Return fallbackColor
        End If
    End Function
End Module
