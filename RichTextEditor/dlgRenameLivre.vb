Imports Microsoft.Win32

''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>

Public Class RenommerLivreDialog

#Region "Declaration"
    'Get Popotte Dir
    Public PopotteDir As String = frmMain.PopotteDir

    Dim strText As String = ""
    Private SourceRegKey As RegistryKey

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
#End Region


#Region "Form methods"
    'Constructor
    Public Sub New(ByVal StringToPass As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        strText = StringToPass
    End Sub

    Private Sub RenommerLivreDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToParent()

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - ChangeBookName", "1")
        LabelNom.Text = LangINI.GetKeyValue("Popotte - ChangeBookName", "2")
        OK_Button.Text = LangINI.GetKeyValue("Popotte - ChangeBookName", "3")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - ChangeBookName", "4")

        NomTextBox.Text = strText
        NomTextBox.Focus()
    End Sub
#End Region


#Region "Button Methods"
    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim SourceDir As String = PopotteDir & strText
        Dim NewName As String = NomTextBox.Text.Trim
        If NewName <> "" Then
            If NewName <> strText Then
                If RenameFolder(SourceDir, NewName + "_bak") <> -1 Then
                    If RenameFolder(PopotteDir + NewName + "_bak", NewName) <> -1 Then
                        SourceRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & strText, True)
                        RenameLivreKey(SourceRegKey, NewName, strText)
                        dlgLivres.ListViewLivres.Clear()
                        dlgLivres.GetLivres()
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End If
            Else
                Me.Close()
            End If
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - ChangeBookName - MessageBox", "2"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ChangeBookName - MessageBox", "1"))
        End If
    End Sub

    Private Sub RenameLivreKey(ByVal Sourcekey As RegistryKey, ByVal Destkeyname As String, ByVal Livre As String)
        If Sourcekey IsNot Nothing Then
            Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
            Dim NewBaseRegKey As RegistryKey = RegKey.CreateSubKey(Destkeyname)
            Dim subKeys As String() = Sourcekey.GetSubKeyNames()
            If subKeys IsNot Nothing Then
                For Each subKeyName As String In subKeys
                    Dim NewSubRegKey As RegistryKey = NewBaseRegKey.CreateSubKey(subKeyName)
                    Dim SubRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & Livre & "\" & subKeyName, True)
                    Dim Note As Integer = SubRegKey.GetValue("Note")
                    Dim Desc As String = SubRegKey.GetValue("Description")
                    NewSubRegKey.SetValue("Note", Note)
                    NewSubRegKey.SetValue("Description", Desc)
                    Sourcekey.DeleteSubKey(subKeyName)
                Next
                Dim SRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
                SRegKey.DeleteSubKey(Livre)
            End If
        End If
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub NomTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NomTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            OK_Button_Click(Me, e)
            e.Handled = True
        End If
    End Sub

#End Region



End Class
