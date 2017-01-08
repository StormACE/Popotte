Imports Microsoft.Win32

Public NotInheritable Class dlgAboutBox

#Region "Declarations"
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
    'Folder we are in
    Private LastLivre As String = ""
    'Use for registry
    Dim regKey As RegistryKey
    'use by listviewrecette
    'Dim imageListSmallRecette As New ImageList
#End Region

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Définissez le titre du formulaire.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Controls Language
        Me.Text = String.Format(LangINI.GetKeyValue("Popotte - AboutBox", "1") & " {0}", ApplicationTitle)
        OKButton.Text = LangINI.GetKeyValue("Popotte - AboutBox", "3")

        ' Initialisez tout le texte affiché dans la boîte de dialogue À propos de.
        ' TODO: personnalisez les informations d'assembly de l'application dans le volet "Application" de la 
        '    boîte de dialogue Propriétés du projet (sous le menu "Projet").
        Me.LabelProductName.Text = My.Application.Info.ProductName & " 64 bits"
        Me.LabelVersion.Text = String.Format(LangINI.GetKeyValue("Popotte - AboutBox", "2") & " {0}", My.Application.Info.Version.ToString) & "  BETA  " & System.IO.File.GetLastWriteTime(System.AppDomain.CurrentDomain.BaseDirectory & "Popotte.exe").ToLongDateString()
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub


End Class
