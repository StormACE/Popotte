''' Copyright Martin Laflamme 2003/2019
''' Read licence.txt


Imports System.Text
Imports Microsoft.Win32

Public Class frmMenu

    Private regKey As RegistryKey
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        Dim nRecette As String = ""
        Dim nLivre As String = ""

        Text = LangINI.GetKeyValue("Popotte - Menu", "12")

        LabelSunday.Text = LangINI.GetKeyValue("Popotte - Menu", "2")
        LabelMonday.Text = LangINI.GetKeyValue("Popotte - Menu", "3")
        LabelTuesday.Text = LangINI.GetKeyValue("Popotte - Menu", "4")
        LabelWednesday.Text = LangINI.GetKeyValue("Popotte - Menu", "5")
        LabelThursday.Text = LangINI.GetKeyValue("Popotte - Menu", "6")
        LabelFriday.Text = LangINI.GetKeyValue("Popotte - Menu", "7")
        LabelSaturday.Text = LangINI.GetKeyValue("Popotte - Menu", "8")

        ListBoxSunday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxSunday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxSunday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ListBoxMonday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxMonday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxMonday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ListBoxTuesday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxTuesday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxTuesday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ListBoxWednesday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxWednesday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxWednesday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ListBoxThursday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxThursday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxThursday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ListBoxFriday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxFriday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxFriday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ListBoxSaturday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxSaturday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))
        ListBoxSaturday.Items.Add(LangINI.GetKeyValue("Popotte - Menu", "1"))

        ButtonClose.Text = LangINI.GetKeyValue("Popotte - Menu", "9")
        ButtonPreview.Text = LangINI.GetKeyValue("Popotte - Menu", "16")
        Button1Touteff.Text = LangINI.GetKeyValue("Popotte - Menu", "17")

        ModifierToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        EffacerToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")
        Modifier2ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        Effacer2ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")
        Modifier3ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        Effacer3ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")
        Modifier4ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        Effacer4ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")
        Modifier5ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        Effacer5ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")
        Modifier6ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        Effacer6ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")
        Modifier7ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "10")
        Effacer7ToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - Menu", "11")

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

    Private Sub ListBoxSunday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxSunday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxSunday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select

            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday\" & mealgroup, True)
            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxMonday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxMonday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxMonday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday\" & mealgroup, True)

            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxTuesday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxTuesday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxTuesday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday\" & mealgroup, True)

            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxWednesday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxWednesday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxWednesday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday\" & mealgroup, True)

            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxThursday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxThursday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxThursday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday\" & mealgroup, True)

            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxFriday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxFriday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxFriday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday\" & mealgroup, True)

            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ListBoxSaturday_MouseDoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles ListBoxSaturday.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim index As Integer = ListBoxSaturday.SelectedIndex
            Dim mealgroup As String = ""

            Select Case index
                Case 0
                    mealgroup = "meal1"
                Case 1
                    mealgroup = "meal2"
                Case 2
                    mealgroup = "meal3"
            End Select
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday\" & mealgroup, True)

            If regKey IsNot Nothing Then
                Dim Livre As String = CType(regKey.GetValue("Livre"), String)
                Dim recette As String = CType(regKey.GetValue("Recette"), String)
                If recette <> "" And Livre <> "" Then
                    Dim filename As String = frmMain.PopotteDir & Livre & "\" & recette & ".rtf"

                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", filename)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", recette)

                    frmMain.rtbDoc.LoadFile(filename, RichTextBoxStreamType.RichText)
                    frmMain.LivreOuvert = Livre
                    frmMain.Text = "Popotte - [" & recette & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListBoxSunday.SelectedItems.Count > 0 Then
            EffacerToolStripMenuItem.Enabled = True
            ModifierToolStripMenuItem.Enabled = True
        Else
            EffacerToolStripMenuItem.Enabled = False
            ModifierToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If ListBoxMonday.SelectedItems.Count > 0 Then
            Effacer2ToolStripMenuItem.Enabled = True
            Modifier2ToolStripMenuItem.Enabled = True
        Else
            Effacer2ToolStripMenuItem.Enabled = False
            Modifier2ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ContextMenuStrip3_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip3.Opening
        If ListBoxTuesday.SelectedItems.Count > 0 Then
            Effacer3ToolStripMenuItem.Enabled = True
            Modifier3ToolStripMenuItem.Enabled = True
        Else
            Effacer3ToolStripMenuItem.Enabled = False
            Modifier3ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ContextMenuStrip4_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip4.Opening
        If ListBoxWednesday.SelectedItems.Count > 0 Then
            Effacer4ToolStripMenuItem.Enabled = True
            Modifier4ToolStripMenuItem.Enabled = True
        Else
            Effacer4ToolStripMenuItem.Enabled = False
            Modifier4ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ContextMenuStrip5_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip5.Opening
        If ListBoxThursday.SelectedItems.Count > 0 Then
            Effacer5ToolStripMenuItem.Enabled = True
            Modifier5ToolStripMenuItem.Enabled = True
        Else
            Effacer5ToolStripMenuItem.Enabled = False
            Modifier5ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ContextMenuStrip6_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip6.Opening
        If ListBoxFriday.SelectedItems.Count > 0 Then
            Effacer6ToolStripMenuItem.Enabled = True
            Modifier6ToolStripMenuItem.Enabled = True
        Else
            Effacer6ToolStripMenuItem.Enabled = False
            Modifier6ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ContextMenuStrip7_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip7.Opening
        If ListBoxSaturday.SelectedItems.Count > 0 Then
            Effacer7ToolStripMenuItem.Enabled = True
            Modifier7ToolStripMenuItem.Enabled = True
        Else
            Effacer7ToolStripMenuItem.Enabled = False
            Modifier7ToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub EffacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EffacerToolStripMenuItem.Click
        Dim index As Integer = ListBoxSunday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxSunday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub Effacer2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Effacer2ToolStripMenuItem.Click
        Dim index As Integer = ListBoxMonday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxMonday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub Effacer3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Effacer3ToolStripMenuItem.Click
        Dim index As Integer = ListBoxTuesday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxTuesday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub Effacer4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Effacer4ToolStripMenuItem.Click
        Dim index As Integer = ListBoxWednesday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxWednesday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub Effacer5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Effacer5ToolStripMenuItem.Click
        Dim index As Integer = ListBoxThursday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxThursday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub Effacer6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Effacer6ToolStripMenuItem.Click
        Dim index As Integer = ListBoxFriday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxFriday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub Effacer7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Effacer7ToolStripMenuItem.Click
        Dim index As Integer = ListBoxSaturday.SelectedIndex
        Dim mealgroup As String = ""
        Select Case index
            Case 0
                mealgroup = "meal1"
            Case 1
                mealgroup = "meal2"
            Case 2
                mealgroup = "meal3"
        End Select

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday\" & mealgroup, True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday", True)
            regKey.DeleteSubKey(mealgroup)
            ListBoxSaturday.Items(index) = LangINI.GetKeyValue("Popotte - Menu", "1")
        End If
    End Sub

    Private Sub ModifierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModifierToolStripMenuItem.Click
        Dim index As Integer = ListBoxSunday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxSunday.Items(index).ToString, ListBoxSunday, index, 1)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub Modifier2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Modifier2ToolStripMenuItem.Click
        Dim index As Integer = ListBoxMonday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxMonday.Items(index).ToString, ListBoxMonday, index, 2)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub Modifier3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Modifier3ToolStripMenuItem.Click
        Dim index As Integer = ListBoxTuesday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxTuesday.Items(index).ToString, ListBoxTuesday, index, 3)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub Modifier4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Modifier4ToolStripMenuItem.Click
        Dim index As Integer = ListBoxWednesday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxWednesday.Items(index).ToString, ListBoxWednesday, index, 4)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub Modifier5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Modifier5ToolStripMenuItem.Click
        Dim index As Integer = ListBoxThursday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxThursday.Items(index).ToString, ListBoxThursday, index, 5)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub Modifier6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Modifier6ToolStripMenuItem.Click
        Dim index As Integer = ListBoxFriday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxFriday.Items(index).ToString, ListBoxFriday, index, 6)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub Modifier7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Modifier7ToolStripMenuItem.Click
        Dim index As Integer = ListBoxSaturday.SelectedIndex
        Dim mr As New dlgmodifymenu(ListBoxSaturday.Items(index).ToString, ListBoxSaturday, index, 7)
        mr.ShowDialog()
        mr.Dispose()
    End Sub

    Private Sub ButtonPreview_Click(sender As Object, e As EventArgs) Handles ButtonPreview.Click
        If frmMain.rtbDoc.Modified = False Then
            Printmenu()
            Close()
        Else
            Dim answer As Integer = MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "10"), LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            Select Case answer
                Case Windows.Forms.DialogResult.Cancel
                Case Windows.Forms.DialogResult.No
                    frmMain.rtbDoc.Clear()
                    frmMain.SetDefaultFont()
                    frmMain.rtbDoc.Focus()
                    Printmenu()
                    frmMain.currentFile = ""
                    frmMain.Text = "Popotte"
                    frmMain.LivreOuvert = ""
                    frmMain.rtbDoc.SelectionAlignment = TextAlign.Left
                    frmMain.ToolStripButtonGauche.Checked = True
                    frmMain.ToolStripButtonCentre.Checked = False
                    frmMain.ToolStripButtonDroite.Checked = False
                    frmMain.TexteÀGaucheToolStripMenuItem.Checked = True
                    frmMain.TexteCentréToolStripMenuItem.Checked = False
                    frmMain.TexteÀDroiteToolStripMenuItem.Checked = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Close()
                Case Windows.Forms.DialogResult.Yes
                    frmMain.SaveToolStripMenuItem_Click(Me, e)
                    frmMain.rtbDoc.Clear()
                    frmMain.SetDefaultFont()
                    frmMain.rtbDoc.Focus()
                    Printmenu()
                    frmMain.currentFile = ""
                    frmMain.Text = "Popotte"
                    frmMain.LivreOuvert = ""
                    frmMain.rtbDoc.SelectionAlignment = TextAlign.Left
                    frmMain.ToolStripButtonGauche.Checked = True
                    frmMain.ToolStripButtonCentre.Checked = False
                    frmMain.ToolStripButtonDroite.Checked = False
                    frmMain.TexteÀGaucheToolStripMenuItem.Checked = True
                    frmMain.TexteCentréToolStripMenuItem.Checked = False
                    frmMain.TexteÀDroiteToolStripMenuItem.Checked = False
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    Close()
            End Select
        End If
    End Sub

    Private Sub Printmenu()
        Dim sb As New StringBuilder()
        sb.AppendLine()
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "12") & " :")
        sb.AppendLine()
        sb.AppendLine(LabelSunday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxSunday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxSunday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxSunday.Items(2).ToString)
        sb.AppendLine()
        sb.AppendLine(LabelMonday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxMonday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxMonday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxMonday.Items(2).ToString)
        sb.AppendLine()
        sb.AppendLine(LabelTuesday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxTuesday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxTuesday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxTuesday.Items(2).ToString)
        sb.AppendLine()
        sb.AppendLine(LabelWednesday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxWednesday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxWednesday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxWednesday.Items(2).ToString)
        sb.AppendLine()
        sb.AppendLine(LabelThursday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxThursday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxThursday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxThursday.Items(2).ToString)
        sb.AppendLine()
        sb.AppendLine(LabelFriday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxFriday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxFriday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxFriday.Items(2).ToString)
        sb.AppendLine()
        sb.AppendLine(LabelSaturday.Text & " :")
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "13") & " :  " & ListBoxSaturday.Items(0).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "14") & " :  " & ListBoxSaturday.Items(1).ToString)
        sb.AppendLine(LangINI.GetKeyValue("Popotte - Menu", "15") & " :  " & ListBoxSaturday.Items(2).ToString)

        frmMain.rtbDoc.Text = sb.ToString
    End Sub

    Private Sub Button1Touteff_Click(sender As Object, e As EventArgs) Handles Button1Touteff.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
        If regKey IsNot Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Sunday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Sunday")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Monday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Monday")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Tuesday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Tuesday")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Wednesday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Wednesday")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Thursday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Thursday")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Friday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Friday")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu\Saturday", True)
            If regKey IsNot Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Menu", True)
                regKey.DeleteSubKeyTree("Saturday")
            End If


            For i As Integer = 0 To 2
                ListBoxSunday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
                ListBoxMonday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
                ListBoxTuesday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
                ListBoxWednesday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
                ListBoxThursday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
                ListBoxFriday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
                ListBoxSaturday.Items(i) = LangINI.GetKeyValue("Popotte - Menu", "1")
            Next
        End If
    End Sub
End Class