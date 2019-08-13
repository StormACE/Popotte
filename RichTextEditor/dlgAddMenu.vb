''' Copyright Martin Laflamme 2003/2019
''' Read licence.txt


Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class dlgAddMenu

    Private regKey As RegistryKey
    Private nlivre As String = ""
    Private recette As String = ""
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Public Sub New(ByVal NRecette As String, ByVal Livre As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        recette = NRecette
        nlivre = Livre
    End Sub

    Private Sub DlgAddMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Text = LangINI.GetKeyValue("Popotte - Addmenu", "1")
        Label1.Text = LangINI.GetKeyValue("Popotte - Addmenu", "2")
        Label2.Text = LangINI.GetKeyValue("Popotte - Addmenu", "3")

        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "4"))
        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "5"))
        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "6"))
        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "7"))
        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "8"))
        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "9"))
        ListBoxDays.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "10"))
        ListBoxDays.SelectedIndex = 0

        ListBoxMeal.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "11"))
        ListBoxMeal.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "12"))
        ListBoxMeal.Items.Add(LangINI.GetKeyValue("Popotte - Addmenu", "13"))
        ListBoxMeal.SelectedIndex = 0

        ButtonAdd.Text = LangINI.GetKeyValue("Popotte - Addmenu", "14")
        Cancel_Button.Text = LangINI.GetKeyValue("Popotte - Addmenu", "15")

    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey.CreateSubKey("Menu")
        End If

        Dim day As String = ListBoxDays.SelectedItem.ToString
        Dim meal As Integer = ListBoxMeal.SelectedIndex
        Dim mealgroup As String = ""

        Select Case meal
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
        regKey.CreateSubKey(day)
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day, True)
        regKey.CreateSubKey(mealgroup)
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day & "\" & mealgroup, True)
        regKey.SetValue("Recette", recette)
        regKey.SetValue("Livre", nlivre)

        MessageBox.Show(LangINI.GetKeyValue("Popotte - Addmenu", "16"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
