Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class dlgmodifymenu

    Dim recette As String = ""
    Dim sellist As ListBox = Nothing
    Dim ind As Integer
    Dim regKey As RegistryKey
    Dim Cday As Integer


    Public Sub New(ByVal NRecette As String, ByVal SelListbox As ListBox, ByVal index As Integer, ByVal day As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        recette = NRecette
        sellist = SelListbox
        ind = index
        Cday = day
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim day As String = ""
        sellist.Items(ind) = TextBox1.Text

        Select Case Cday
            Case 1
                day = "Sunday"
            Case 2
                day = "Monday"
            Case 3
                day = "Tuesday"
            Case 4
                day = "Wednesday"
            Case 5
                day = "Thursday"
            Case 6
                day = "Friday"
            Case 7
                day = "Saturday"
        End Select

        Dim mealgroup As String = ""
        Select Case ind
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day & "\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey.SetValue("Recette", TextBox1.Text)
            regKey.SetValue("Livre", "")
        Else
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day, True)
            If regKey IsNot Nothing Then
                regKey.CreateSubKey(mealgroup)
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day & "\" & mealgroup, True)
                regKey.SetValue("Recette", TextBox1.Text)
                regKey.SetValue("Livre", "")
            Else
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.CreateSubKey(day)
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day, True)
                regKey.CreateSubKey(mealgroup)
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\" & day & "\" & mealgroup, True)
                regKey.SetValue("Recette", TextBox1.Text)
                regKey.SetValue("Livre", "")
            End If
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dlgmodifymenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = recette
    End Sub
End Class
