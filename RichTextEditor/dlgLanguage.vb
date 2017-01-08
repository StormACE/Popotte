Imports System.IO
Imports Microsoft.Win32

Public Class LanguageDialog

    Private regKey As RegistryKey
    Private Language As String

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Sub LanguageDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - LanguageDialogue", "1")
        OK_Button.Text = LangINI.GetKeyValue("Popotte - LanguageDialogue", "2")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - LanguageDialogue", "3")
        LabelLanguage.Text = LangINI.GetKeyValue("Popotte - LanguageDialogue", "4")

        'Get language availlable in folder
        For Each file As String In Directory.GetFiles(Application.StartupPath & "\Languages\")
            Dim FileName As String = Path.GetFileNameWithoutExtension(file)
            LanguageComboBox.Items.Add(FileName)
        Next file

        Language = frmMain.Language

        If regKey IsNot Nothing Then
            Language = regKey.GetValue("", "")
        Else
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Language")
            'Set language in registry
            regKey.SetValue("", Language)
        End If

        'Select the language in combobox
        Dim SelectedLanguage As Integer = LanguageComboBox.FindStringExact(Language)
        LanguageComboBox.SelectedIndex = SelectedLanguage

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim Language As String = LanguageComboBox.SelectedItem.ToString()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Language", True)
        'Set language in registry
        regKey.SetValue("", Language)
        'ask for restart
        Dim result As DialogResult = MessageBox.Show(LangINI.GetKeyValue("Popotte - LanguageDialogue - MessageBox", "1") & Environment.NewLine & LangINI.GetKeyValue("Popotte - LanguageDialogue - MessageBox", "2"), "Popotte", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
        Select Case result
            Case DialogResult.Yes
                Process.Start(Application.ExecutablePath)
                Application.Exit()
            Case DialogResult.No
                Me.Close()
            Case DialogResult.Cancel
                Exit Select
        End Select
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
