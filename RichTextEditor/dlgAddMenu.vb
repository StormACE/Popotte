''' Copyright Martin Laflamme 2003/2019
''' Read licence.txt


Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class dlgAddMenu

    Private regKey As RegistryKey
    Private nlivre As String = ""
    Private recette As String = ""

    Public Sub New(ByVal NRecette As String, ByVal Livre As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        recette = NRecette
        nlivre = Livre
    End Sub

    Private Sub DlgAddMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBoxDays.Items.Add("Sunday")
        ListBoxDays.Items.Add("Monday")
        ListBoxDays.Items.Add("Tuesday")
        ListBoxDays.Items.Add("Wednesday")
        ListBoxDays.Items.Add("Thursday")
        ListBoxDays.Items.Add("Friday")
        ListBoxDays.Items.Add("Saturday")
        ListBoxDays.SelectedIndex = 0

        ListBoxMeal.Items.Add("1st Meal")
        ListBoxMeal.Items.Add("2nd Meal")
        ListBoxMeal.Items.Add("3rd Meal")
        ListBoxMeal.SelectedIndex = 0

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

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
