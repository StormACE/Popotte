Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class dlgMultiModInfo

    'Get Popotte Dir
    Private PopotteDir As String = frmMain.PopotteDir
    Private NomLivre As String = ""
    Private SelectedRecettes As ListView.SelectedListViewItemCollection
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    'Constructor
    Public Sub New(ByVal Livre As String, ByVal recettes As ListView.SelectedListViewItemCollection)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        NomLivre = Livre
        SelectedRecettes = recettes
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim NewLivre As String = LivresComboBox.Text.Trim
        Dim Success As Integer = 0

        For Each recette As ListViewItem In SelectedRecettes
            If MoveFile(PopotteDir & NomLivre & "\" & recette.Text & ".rtf", PopotteDir & NewLivre & "\" & recette.Text & ".rtf", False) <> -1 Then
                Dim RecetteRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & recette.Text, True)
                If RecetteRegKey IsNot Nothing Then
                    Dim note As Integer = RecetteRegKey.GetValue("Note", 6)
                    Dim Desc As String = RecetteRegKey.GetValue("Description", "")
                    Dim NewLivreRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                    Try
                        NewLivreRegKey.CreateSubKey(NewLivre)
                        Dim NewRecetteRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre, True)
                        NewRecetteRegKey.CreateSubKey(recette.Text)
                        NewRecetteRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre & "\" & recette.Text, True)
                        NewRecetteRegKey.SetValue("Note", note)
                        NewRecetteRegKey.SetValue("Description", Desc)
                        RemoveRecetteKey(NomLivre, recette.Text)
                    Catch ex As Exception
                        MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If
                Success += 1
            End If
        Next

        If Success = SelectedRecettes.Count Then
            MessageBox.Show("Tout les fichiers ont été transféré dans le nouveau livre", "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Success > 0 And Success < SelectedRecettes.Count Then
            MessageBox.Show("Quelques fichiers n'ont pas été transférés correctement", "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Success = 0 Then
            MessageBox.Show("Aucun fichiers transférés", "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgMultiModInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Déplacer vers le Livre :"
        GetLivres()
        LivresComboBox.SelectedText = NomLivre
    End Sub

    Private Sub GetLivres()
        If (Directory.Exists(PopotteDir)) Then
            For Each Folder As String In My.Computer.FileSystem.GetDirectories(PopotteDir)
                'Retourne le nom du dossier
                Dim FolderName As String = Path.GetFileName(Folder)
                'Ajouter le dossier a la listview
                LivresComboBox.Items.Add(FolderName)
            Next
        End If
    End Sub

    Private Sub RemoveRecetteKey(ByVal NomLivre As String, ByVal NomRecette As String)
        Dim RecetteRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & NomRecette, True)
        If RecetteRegKey IsNot Nothing Then
            Dim SRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)
            SRegKey.DeleteSubKey(NomRecette)
        End If
    End Sub
End Class
