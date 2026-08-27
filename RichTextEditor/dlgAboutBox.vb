''' <summary>
''' Popotte v5
''' 1 mars 2016 au 29 décembre 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2019
''' Read licence.txt
''' </summary>
Public NotInheritable Class dlgAboutBox

#Region "Declarations"
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
    Dim Button_Licence As Control
    Dim xCPU As String = "x64"
#End Region

    Private Sub AboutBox1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        ' Définissez le titre du formulaire.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Controls Language
        Me.Text = String.Format(LangINI.GetKeyValue("Popotte - AboutBox", "1") & " {0}", ApplicationTitle)

        Button_Licence = New Button
        Button_Licence.Name = "Button_Licence"
        Button_Licence.Text = LangINI.GetKeyValue("Popotte - AboutBox", "3")
        Button_Licence.Anchor = AnchorStyles.Bottom AndAlso AnchorStyles.Right
        TableLayoutPanel.Controls.Add(Button_Licence, 3, 4)
        AddHandler Button_Licence.Click, AddressOf Button_Licence_Click

        ' Initialisez tout le texte affiché dans la boîte de dialogue À propos de.
        ' TODO: personnalisez les informations d'assembly de l'application dans le volet "Application" de la 
        '    boîte de dialogue Propriétés du projet (sous le menu "Projet").
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format(LangINI.GetKeyValue("Popotte - AboutBox", "2") & " {0}", My.Application.Info.Version.ToString) & "  " & xCPU & "   " & System.IO.File.GetLastWriteTime(System.AppDomain.CurrentDomain.BaseDirectory & "Popotte.exe").ToLongDateString()
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub Button_Licence_Click(ByVal sender As Object, ByVal e As EventArgs)
        Process.Start(Application.StartupPath & "\licence.txt")
    End Sub

End Class
