Imports System.Text.RegularExpressions

Module MiscFunctions
    ' ...
    ''' <summary>
    ''' Convert a string of the format "color [nameOfColor]" or
    ''' "color [A=a, R=r, G=g, B=b]" to a System.Drawing.Color.
    ''' </summary>
    ''' <param name="s">A String representing the colour.</param>
    ''' <returns>A System.Drawing.Color.</returns>
    ''' <remarks>Returns fallbackColour if the colour could not be parsed.</remarks>
    Public Function ColourFromData(s As String) As Color
        Dim fallbackColour = Color.Black

        If Not s.StartsWith("color", StringComparison.OrdinalIgnoreCase) Then
            Return fallbackColour
        End If

        ' Extract whatever is between the brackets.
        Dim re = New Regex("\[(.+?)]")
        Dim colorNameMatch = re.Match(s)
        If Not colorNameMatch.Success Then
            Return fallbackColour
        End If

        Dim colourName = colorNameMatch.Groups(1).Value

        ' Get the names of the known colours.
        'TODO: If this function is called frequently, consider creating allColours as a variable with a larger scope.
        Try
            Dim allColours = [Enum].GetNames(GetType(System.Drawing.KnownColor))
            ' Attempt a case-insensitive match to the known colours.
            Dim nameOfColour = allColours.FirstOrDefault(Function(c) String.Compare(c, colourName, StringComparison.OrdinalIgnoreCase) = 0)

            If Not String.IsNullOrEmpty(nameOfColour) Then
                Return Color.FromName(nameOfColour)
            End If
        Catch ex As Exception
        End Try

        ' Was not a named colour. Parse for ARGB values.
        re = New Regex("A=(\d+).*?R=(\d+).*?G=(\d+).*?B=(\d+)", RegexOptions.IgnoreCase)
        Dim componentMatches = re.Match(colourName)

        If componentMatches.Success Then

            Dim a = Integer.Parse(componentMatches.Groups(1).Value)
            Dim r = Integer.Parse(componentMatches.Groups(2).Value)
            Dim g = Integer.Parse(componentMatches.Groups(3).Value)
            Dim b = Integer.Parse(componentMatches.Groups(4).Value)

            Dim maxValue = 255

            If a > maxValue OrElse r > maxValue OrElse g > maxValue OrElse b > maxValue Then
                Return fallbackColour
            End If

            Return System.Drawing.Color.FromArgb(a, r, g, b)

        End If

        Return fallbackColour

    End Function
End Module
