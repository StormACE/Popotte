Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Win32

''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>

Public Class frmSave

#Region "Declarations"
    'Get Popotte Dir
    Public PopotteDir As String = frmMain.PopotteDir
    Dim regKey As RegistryKey
#End Region


#Region "Form Methods"
    Private Sub frmSave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Populate Dialogue
        Me.ComboBoxLivres.DropDownHeight = 133
        GetLivres()

        Me.ComboBoxNouveauNote.Items.Add("5 - Excellent")
        Me.ComboBoxNouveauNote.Items.Add("4 - Très Bon")
        Me.ComboBoxNouveauNote.Items.Add("3 - Bon")
        Me.ComboBoxNouveauNote.Items.Add("2 - Moyen")
        Me.ComboBoxNouveauNote.Items.Add("1 - Pauvre")
        Me.ComboBoxNouveauNote.Items.Add("Aucune")

        Me.ComboBoxNote.Items.Add("5 - Excellent")
        Me.ComboBoxNote.Items.Add("4 - Très Bon")
        Me.ComboBoxNote.Items.Add("3 - Bon")
        Me.ComboBoxNote.Items.Add("2 - Moyen")
        Me.ComboBoxNote.Items.Add("1 - Pauvre")
        Me.ComboBoxNote.Items.Add("Aucune")

        If frmMain.LivreOuvert <> "" Then
            CheckBoxNouveauLivre.Checked = False
            CheckBoxLivreExistant.Checked = True
            ComboBoxLivres.Enabled = True
            ComboBoxLivres.SelectedItem = frmMain.LivreOuvert
            TextBoxNomRecette.Enabled = True
            TextBoxNomRecette.Text = frmMain.currentFile
            TextBoxNouveauNomRecette.Text = frmMain.currentFile
            ComboBoxNote.Enabled = True
            TextBoxDescription.Enabled = True
            Dim NoteRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & frmMain.LivreOuvert & "\" & frmMain.currentFile, True)
            If NoteRegKey IsNot Nothing Then
                ComboBoxNote.SelectedIndex = NoteRegKey.GetValue("Note", 0)
                TextBoxDescription.Text = NoteRegKey.GetValue("Description", "")
            Else
                ComboBoxNote.SelectedIndex = 5
                TextBoxDescription.Text = ""
            End If
            TextBoxNouveauNomLivre.Enabled = False
            TextBoxNouveauNomRecette.Enabled = False
            ComboBoxNouveauNote.Enabled = False
            ComboBoxNouveauNote.SelectedIndex = 5
            TextBoxNouveauDescription.Enabled = False
        Else
            CheckBoxNouveauLivre.Checked = True
            CheckBoxLivreExistant.Checked = False
            ComboBoxLivres.Enabled = False
            If ComboBoxLivres.Items.Count <> 0 Then
                ComboBoxLivres.SelectedIndex = 0
            End If
            TextBoxNomRecette.Enabled = False
            ComboBoxNote.Enabled = False
            ComboBoxNote.SelectedIndex = 5
            TextBoxDescription.Enabled = False
            TextBoxNouveauNomLivre.Enabled = True
            TextBoxNouveauNomRecette.Enabled = True
            ComboBoxNouveauNote.Enabled = True
            ComboBoxNouveauNote.SelectedIndex = 5
            TextBoxNouveauDescription.Enabled = True
        End If
    End Sub

    Private Sub GetLivres()
        If (Directory.Exists(PopotteDir)) Then
            For Each Folder As String In My.Computer.FileSystem.GetDirectories(PopotteDir)
                'Retourne le nom du dossier
                Dim FolderName As String = Path.GetFileName(Folder)
                'Ajouter le dossier a la listview
                Me.ComboBoxLivres.Items.Add(FolderName)
            Next
        End If
    End Sub
#End Region


#Region "Buttons Methods"
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        If CheckBoxNouveauLivre.Checked Then
            If TextBoxNouveauNomRecette.Text <> "" And TextBoxNouveauNomLivre.Text <> "" Then
                Dim Nomlivre As String = TextBoxNouveauNomLivre.Text.Trim
                Dim NomRecette As String = TextBoxNouveauNomRecette.Text.Trim
                Dim Description As String = TextBoxNouveauDescription.Text.Trim
                Dim Note As Integer = ComboBoxNouveauNote.SelectedIndex
                If Directory.Exists(PopotteDir) Then
                    CreateFolder(PopotteDir & Nomlivre)
                Else
                    CreateFolder(PopotteDir)
                    CreateFolder(PopotteDir & Nomlivre)
                End If
                If Not File.Exists(PopotteDir & Nomlivre & "\" & NomRecette & ".rtf") Then
                    Savefile(Nomlivre, NomRecette, Description, Note)
                Else
                    Dim DiaAnswer As DialogResult = MsgBox("La recette existe déjà! Voulez vous écraser le fichier existant?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Popotte - Attention!")
                    If DiaAnswer = Windows.Forms.DialogResult.Yes Then
                        Savefile(Nomlivre, NomRecette, Description, Note)
                    End If
                End If
            Else
                MsgBox("Vous devez remplir les champs Nom du Livre et Nom de la Recette avant de Sauvegarder.", MsgBoxStyle.Exclamation, "Popotte - Attention!")
            End If

        ElseIf CheckBoxLivreExistant.Checked Then
            If TextBoxNomRecette.Text <> "" Then
                Dim Nomlivre As String = ComboBoxLivres.SelectedItem
                Dim NomRecette As String = TextBoxNomRecette.Text.Trim
                Dim Description As String = TextBoxDescription.Text.Trim
                Dim Note As Integer = ComboBoxNote.SelectedIndex
                If Not File.Exists(PopotteDir & Nomlivre & "\" & NomRecette & ".rtf") Then
                    Savefile(Nomlivre, NomRecette, Description, Note)
                Else
                    Dim DiaAnswer As DialogResult = MsgBox("La recette existe déjà! Voulez vous écraser le fichier existant?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Popotte - Attention!")
                    If DiaAnswer = Windows.Forms.DialogResult.Yes Then
                        Savefile(Nomlivre, NomRecette, Description, Note)
                    End If
                End If
            Else
                MsgBox("Vous devez remplir le champs Nom de la Recette avant de Sauvegarder.", MsgBoxStyle.Exclamation, "Popotte - Attention!")
            End If
        End If
    End Sub

    Private Sub Savefile(Nomlivre As String, NomRecette As String, Description As String, Note As Integer)
        If RichEditBox_SaveFile(PopotteDir & Nomlivre & "\" & NomRecette & ".rtf") <> -1 Then
            Dim SourceBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
            If SourceBaseRegKey IsNot Nothing Then
                Dim NewSourceBaseRegKey As RegistryKey = SourceBaseRegKey.CreateSubKey(Nomlivre)
                Dim NewSrcRecetteBaseRegKey As RegistryKey = NewSourceBaseRegKey.CreateSubKey(NomRecette)
                NewSrcRecetteBaseRegKey.SetValue("Note", Note)
                NewSrcRecetteBaseRegKey.SetValue("Description", Description)
            End If
            MsgBox("Votre Recette a été sauvegardée avec succès!", MsgBoxStyle.Exclamation, "Popotte")
            frmMain.Text = "Popotte - [" & NomRecette & ".rtf]"
            frmMain.LivreOuvert = Nomlivre
            frmMain.currentFile = NomRecette
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            If regKey Is Nothing Then
                Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                regKey = newregKey.CreateSubKey("DerRecette")
            End If
            regKey.SetValue("DerRecette", PopotteDir & Nomlivre & "\" & NomRecette & ".rtf")
            regKey.SetValue("Livre", Nomlivre)
            regKey.SetValue("Recette", NomRecette)
            frmMain.rtbDoc.Modified = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Function RichEditBox_SaveFile(ByRef sPath As String) As Integer
        Dim RetVal As Integer = 0
        Try
            frmMain.rtbDoc.SaveFile(sPath)
        Catch ex As IOException
            MessageBox.Show("Une erreur ces produite en sauvegardant le fichier.", "Popotte - Attention!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            RetVal = -1
        Catch ex As ArgumentException
            RetVal = -1
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.ToString, "Popotte - Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        End Try
        Return RetVal
    End Function
#End Region

#Region "CheckBox Methods"
    Private Sub CheckBoxNouveauLivre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxNouveauLivre.Click
        CheckBoxNouveauLivre.Checked = True
        CheckBoxLivreExistant.Checked = False
        ComboBoxLivres.Enabled = False
        TextBoxNomRecette.Enabled = False
        ComboBoxNote.Enabled = False
        TextBoxDescription.Enabled = False
        TextBoxNouveauNomLivre.Enabled = True
        TextBoxNouveauNomRecette.Enabled = True
        ComboBoxNouveauNote.Enabled = True
        TextBoxNouveauDescription.Enabled = True
    End Sub

    Private Sub CheckBoxLivreExistant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxLivreExistant.Click
        If ComboBoxLivres.Items.Count <> 0 Then
            CheckBoxLivreExistant.Checked = True
            CheckBoxNouveauLivre.Checked = False
            ComboBoxLivres.Enabled = True
            TextBoxNomRecette.Enabled = True
            ComboBoxNote.Enabled = True
            TextBoxDescription.Enabled = True
            TextBoxNouveauNomLivre.Enabled = False
            TextBoxNouveauNomRecette.Enabled = False
            ComboBoxNouveauNote.Enabled = False
            TextBoxNouveauDescription.Enabled = False
        Else
            CheckBoxLivreExistant.Checked = False
            MsgBox("Vous devez créer un nouveau livre avant de choisir cette option.", MsgBoxStyle.Exclamation, "Popotte - Attention!")
        End If
        
    End Sub
#End Region
End Class
