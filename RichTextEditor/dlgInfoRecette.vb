Imports Microsoft.Win32
Imports System.IO

''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>

Public Class dlgInfoRecette

#Region "Declaration"
    'Get Popotte Dir
    Private PopotteDir As String = frmMain.PopotteDir

    Private strText As String = ""
    Private NomLivre As String = ""
    Private Saveit As Boolean = False
    Private regKey As RegistryKey

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
#End Region

#Region "Form Methods"
    'Constructor
    Public Sub New(ByVal NRecette As String, ByVal Livre As String, ByVal Save As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strText = NRecette
        NomLivre = Livre
        Saveit = Save
    End Sub

    Private Sub frmInfoRecette_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToParent()

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo", "1")
        LabelRecette.Text = LangINI.GetKeyValue("Popotte - ModifyInfo", "2")
        LabelLivre.Text = LangINI.GetKeyValue("Popotte - ModifyInfo", "3")
        LabelNote.Text = LangINI.GetKeyValue("Popotte - ModifyInfo", "4")
        LabelDesc.Text = LangINI.GetKeyValue("Popotte - ModifyInfo", "5")
        OK_Button.Text = LangINI.GetKeyValue("Popotte - ModifyInfo", "6")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - ModifyInfo", "7")

        If Saveit = True Then
            Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo", "8")
        End If

        NomTextBox.Text = strText
        NomTextBox.Focus()

        NoteComboBox.Items.Add(LangINI.GetKeyValue("Popotte - ModifyInfo", "9"))
        NoteComboBox.Items.Add(LangINI.GetKeyValue("Popotte - ModifyInfo", "10"))
        NoteComboBox.Items.Add(LangINI.GetKeyValue("Popotte - ModifyInfo", "11"))
        NoteComboBox.Items.Add(LangINI.GetKeyValue("Popotte - ModifyInfo", "12"))
        NoteComboBox.Items.Add(LangINI.GetKeyValue("Popotte - ModifyInfo", "13"))
        NoteComboBox.Items.Add(LangINI.GetKeyValue("Popotte - ModifyInfo", "14"))

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & strText, True)
        If regKey IsNot Nothing Then
            NoteComboBox.SelectedIndex = regKey.GetValue("Note", 5)
            DescTextBox.Text = regKey.GetValue("Description", "").ToString
        Else
            NoteComboBox.SelectedIndex = 5
        End If

        GetLivres()
        Me.ComboBoxLivre.SelectedText = NomLivre

    End Sub

    Private Sub GetLivres()
        If (Directory.Exists(PopotteDir)) Then
            For Each Folder As String In My.Computer.FileSystem.GetDirectories(PopotteDir)
                'Retourne le nom du dossier
                Dim FolderName As String = Path.GetFileName(Folder)
                'Ajouter le dossier a la listview
                Me.ComboBoxLivre.Items.Add(FolderName)
            Next
        End If
    End Sub
#End Region

#Region "Buttons Methods"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim SourceFile As String = PopotteDir & NomLivre & "\" & strText & ".rtf"
        Dim NewName As String = NomTextBox.Text.Trim
        Dim NewNote As String = NoteComboBox.SelectedIndex.ToString
        Dim NewLivre As String = Me.ComboBoxLivre.Text.Trim
        Dim NewDesc As String = DescTextBox.Text.Trim
        If Saveit = False Then
            If NewLivre <> "" Then
                If NewLivre.ToLower <> NomLivre.ToLower Then 'need to move the file
                    If NewName <> "" Then
                        If NewName.ToLower <> strText.ToLower Then 'Rename and delete old regkey
                            Dim LivreRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre, True)
                            If LivreRegKey Is Nothing Then
                                LivreRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
                                Dim NewLivreRegKey As RegistryKey = LivreRegKey.CreateSubKey(NewLivre)
                            End If
                            If Directory.Exists(PopotteDir & NewLivre) <> True Then
                                CreateFolder(PopotteDir & NewLivre)
                            End If
                            Dim Newfile As String = PopotteDir & NewLivre & "\" & NewName & ".rtf"
                            My.Computer.FileSystem.MoveFile(SourceFile, Newfile)
                            Dim SourceBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                            If SourceBaseRegKey IsNot Nothing Then
                                Dim NewSourceBaseRegKey As RegistryKey = SourceBaseRegKey.CreateSubKey(NewLivre)
                                Dim NewSrcRecetteBaseRegKey As RegistryKey = NewSourceBaseRegKey.CreateSubKey(NewName)
                                NewSrcRecetteBaseRegKey.SetValue("Note", NewNote)
                                NewSrcRecetteBaseRegKey.SetValue("Description", NewDesc)
                                Dim OldRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & strText, True)
                                If OldRegKey IsNot Nothing Then
                                    Dim OldBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)
                                    OldBaseRegKey.DeleteSubKey(strText)
                                End If
                            End If
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        Else 'no rename needed
                            Dim Newfile As String = PopotteDir & NewLivre & "\" & NewName & ".rtf"
                            If Not File.Exists(Newfile) Then
                                If MoveFile(SourceFile, Newfile, False) <> -1 Then
                                    Dim SourceRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre & "\" & NewName, True)
                                    If SourceRegKey IsNot Nothing Then
                                        SourceRegKey.SetValue("Note", NewNote)
                                        SourceRegKey.SetValue("Description", NewDesc)
                                    Else 'Need to create subkeys
                                        Dim BaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                                        If BaseRegKey IsNot Nothing Then
                                            Dim NewBaseRegKey As RegistryKey = BaseRegKey.CreateSubKey(NewLivre)
                                            Dim NewRecetteBaseRegKey As RegistryKey = NewBaseRegKey.CreateSubKey(NewName)
                                            NewRecetteBaseRegKey.SetValue("Note", NewNote)
                                            NewRecetteBaseRegKey.SetValue("Description", NewDesc)
                                        End If
                                    End If
                                    Dim OldRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & strText, True)
                                    If OldRegKey IsNot Nothing Then
                                        Dim OldBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)
                                        OldBaseRegKey.DeleteSubKey(strText)
                                    End If
                                End If
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()
                            Else
                                Dim DiaAnswer As DialogResult = MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"))
                                If DiaAnswer = Windows.Forms.DialogResult.Yes Then
                                    If MoveFile(SourceFile, Newfile, True) <> -1 Then
                                        Dim SourceRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre & "\" & NewName, True)
                                        If SourceRegKey IsNot Nothing Then
                                            SourceRegKey.SetValue("Note", NewNote)
                                            SourceRegKey.SetValue("Description", NewDesc)
                                        Else 'Need to create subkeys
                                            Dim BaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                                            If BaseRegKey IsNot Nothing Then
                                                Dim NewBaseRegKey As RegistryKey = BaseRegKey.CreateSubKey(NewLivre)
                                                Dim NewRecetteBaseRegKey As RegistryKey = NewBaseRegKey.CreateSubKey(NewName)
                                                NewRecetteBaseRegKey.SetValue("Note", NewNote)
                                                NewRecetteBaseRegKey.SetValue("Description", NewDesc)
                                            End If
                                        End If
                                        Dim OldRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & strText, True)
                                        If OldRegKey IsNot Nothing Then
                                            Dim OldBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)
                                            OldBaseRegKey.DeleteSubKey(strText)
                                        End If
                                    End If
                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                    Me.Close()
                                End If
                            End If
                        End If
                    Else
                        MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "3"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"))
                    End If
                Else
                    If NewName <> "" Then
                        If NewName.ToLower <> strText.ToLower Then 'Rename and delete old regkey
                            Dim LivreRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre, True)
                            If LivreRegKey Is Nothing Then
                                LivreRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
                                Dim NewLivreRegKey As RegistryKey = LivreRegKey.CreateSubKey(NewLivre)
                            End If
                            If Directory.Exists(PopotteDir & NewLivre) <> True Then
                                CreateFolder(PopotteDir & NewLivre)
                            End If
                            If RenameFile(SourceFile, NewName, ".rtf") <> -1 Then
                                Dim SourceBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                                If SourceBaseRegKey IsNot Nothing Then
                                    Dim NewSourceBaseRegKey As RegistryKey = SourceBaseRegKey.CreateSubKey(NewLivre)
                                    Dim NewSrcRecetteBaseRegKey As RegistryKey = NewSourceBaseRegKey.CreateSubKey(NewName)
                                    NewSrcRecetteBaseRegKey.SetValue("Note", NewNote)
                                    NewSrcRecetteBaseRegKey.SetValue("Description", NewDesc)
                                    Dim OldRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & strText, True)
                                    If OldRegKey IsNot Nothing Then
                                        Dim OldBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)
                                        OldBaseRegKey.DeleteSubKey(strText)
                                    End If
                                End If
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()
                            End If
                        Else 'no rename needed
                            Dim SourceRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NewLivre & "\" & NewName, True)
                            If SourceRegKey IsNot Nothing Then
                                SourceRegKey.SetValue("Note", NewNote)
                                SourceRegKey.SetValue("Description", NewDesc)
                            Else 'Need to create subkeys
                                Dim BaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                                If BaseRegKey IsNot Nothing Then
                                    Dim NewBaseRegKey As RegistryKey = BaseRegKey.CreateSubKey(NewLivre)
                                    Dim NewRecetteBaseRegKey As RegistryKey = NewBaseRegKey.CreateSubKey(NewName)
                                    NewRecetteBaseRegKey.SetValue("Note", NewNote)
                                    NewRecetteBaseRegKey.SetValue("Description", NewDesc)
                                End If
                            End If
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    Else
                        MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "3"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"))
                    End If
                End If
            Else
                MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "4"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"))
            End If
        Else
            If NewLivre <> "" And NewName <> "" Then
                If Directory.Exists(PopotteDir) Then
                    CreateFolder(PopotteDir & NewLivre)
                Else
                    CreateFolder(PopotteDir)
                    CreateFolder(PopotteDir & NewLivre)
                End If
                If Not File.Exists(PopotteDir & NewLivre & "\" & NewName & ".rtf") Then
                    Savefile(NewLivre, NewName, NewDesc, NewNote)
                Else
                    Dim DiaAnswer As DialogResult = MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"))
                    If DiaAnswer = Windows.Forms.DialogResult.Yes Then
                        Savefile(NewLivre, NewName, NewDesc, NewNote)
                    End If
                End If
            Else
                MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "5"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"))
            End If
        End If
    End Sub

    Private Sub Savefile(NewLivre As String, NewName As String, NewDesc As String, NewNote As Integer)
        If RichEditBox_SaveFile(PopotteDir & NewLivre & "\" & NewName & ".rtf") <> -1 Then
            Dim SourceBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
            If SourceBaseRegKey IsNot Nothing Then
                Dim NewSourceBaseRegKey As RegistryKey = SourceBaseRegKey.CreateSubKey(NewLivre)
                Dim NewSrcRecetteBaseRegKey As RegistryKey = NewSourceBaseRegKey.CreateSubKey(NewName)
                NewSrcRecetteBaseRegKey.SetValue("Note", NewNote)
                NewSrcRecetteBaseRegKey.SetValue("Description", NewDesc)
            End If
            MsgBox(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "6"), MsgBoxStyle.Information, "Popotte")
            frmMain.Text = "Popotte - [" & NewName & ".rtf]"
            frmMain.LivreOuvert = NewLivre
            frmMain.currentFile = NewName
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            If regKey Is Nothing Then
                Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                regKey = newregKey.CreateSubKey("DerRecette")
            End If
            regKey.SetValue("DerRecette", PopotteDir & NewLivre & "\" & NewName & ".rtf")
            regKey.SetValue("Livre", NewLivre)
            regKey.SetValue("Recette", NewName)
            frmMain.rtbDoc.Modified = False
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Public Function RichEditBox_SaveFile(ByRef strPath As String) As Integer
        Dim RetVal As Integer = 0
        Try
            frmMain.rtbDoc.SaveFile(strPath)
        Catch ex As IOException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "7"), "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            RetVal = -1
        Catch ex As ArgumentException
            RetVal = -1
        Catch ex As Exception
            MessageBox.Show(LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "8") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - ModifyInfo - MessageBox", "2"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        End Try
        Return RetVal
    End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

End Class
