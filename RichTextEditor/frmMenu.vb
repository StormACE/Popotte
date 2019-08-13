Imports Microsoft.Win32

Public Class frmMenu

    Private regKey As RegistryKey

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        Dim nRecette As String = ""
        Dim nLivre As String = ""

        ListBoxSunday.Items.Add("Aucune recette")
        ListBoxSunday.Items.Add("Aucune recette")
        ListBoxSunday.Items.Add("Aucune recette")

        ListBoxMonday.Items.Add("Aucune recette")
        ListBoxMonday.Items.Add("Aucune recette")
        ListBoxMonday.Items.Add("Aucune recette")

        ListBoxTuesday.Items.Add("Aucune recette")
        ListBoxTuesday.Items.Add("Aucune recette")
        ListBoxTuesday.Items.Add("Aucune recette")

        ListBoxWednesday.Items.Add("Aucune recette")
        ListBoxWednesday.Items.Add("Aucune recette")
        ListBoxWednesday.Items.Add("Aucune recette")

        ListBoxThursday.Items.Add("Aucune recette")
        ListBoxThursday.Items.Add("Aucune recette")
        ListBoxThursday.Items.Add("Aucune recette")

        ListBoxFriday.Items.Add("Aucune recette")
        ListBoxFriday.Items.Add("Aucune recette")
        ListBoxFriday.Items.Add("Aucune recette")

        ListBoxSaturday.Items.Add("Aucune recette")
        ListBoxSaturday.Items.Add("Aucune recette")
        ListBoxSaturday.Items.Add("Aucune recette")

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxSunday.Items.Insert(0, nRecette)
                ListBoxSunday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxSunday.Items.Insert(1, nRecette)
                ListBoxSunday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxSunday.Items.Insert(2, nRecette)
                ListBoxSunday.Items.RemoveAt(3)
            End If
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxMonday.Items.Insert(0, nRecette)
                ListBoxMonday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxMonday.Items.Insert(1, nRecette)
                ListBoxMonday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxMonday.Items.Insert(2, nRecette)
                ListBoxMonday.Items.RemoveAt(3)
            End If
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxTuesday.Items.Insert(0, nRecette)
                ListBoxTuesday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxTuesday.Items.Insert(1, nRecette)
                ListBoxTuesday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxTuesday.Items.Insert(2, nRecette)
                ListBoxTuesday.Items.RemoveAt(3)
            End If
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxWednesday.Items.Insert(0, nRecette)
                ListBoxWednesday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxWednesday.Items.Insert(1, nRecette)
                ListBoxWednesday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxWednesday.Items.Insert(2, nRecette)
                ListBoxWednesday.Items.RemoveAt(3)
            End If
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxThursday.Items.Insert(0, nRecette)
                ListBoxThursday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxThursday.Items.Insert(1, nRecette)
                ListBoxThursday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxThursday.Items.Insert(2, nRecette)
                ListBoxThursday.Items.RemoveAt(3)
            End If
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxFriday.Items.Insert(0, nRecette)
                ListBoxFriday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxFriday.Items.Insert(1, nRecette)
                ListBoxFriday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxFriday.Items.Insert(2, nRecette)
                ListBoxFriday.Items.RemoveAt(3)
            End If
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday\meal1", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxSaturday.Items.Insert(0, nRecette)
                ListBoxSaturday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday\meal2", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxSaturday.Items.Insert(1, nRecette)
                ListBoxSaturday.Items.RemoveAt(3)
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday\meal3", True)
            If regKey IsNot Nothing Then
                nRecette = CType(regKey.GetValue("Recette"), String)
                ListBoxSaturday.Items.Insert(2, nRecette)
                ListBoxSaturday.Items.RemoveAt(3)
            End If
        End If
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Close()
    End Sub

End Class