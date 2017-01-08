Imports Microsoft.Win32

Public Class ResearchCenter

#Region "Declarations"

    Private regKey As RegistryKey
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni
#End Region

#Region "Form Methods"
    Private Sub RC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Controls Language
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - ResearchCenter", "1")
        LabelNom.Text = LangINI.GetKeyValue("Popotte - ResearchCenter", "2")
        LabelCom.Text = LangINI.GetKeyValue("Popotte - ResearchCenter", "3")
        ADD_Button.Text = LangINI.GetKeyValue("Popotte - ResearchCenter", "4")
        DEL_Button.Text = LangINI.GetKeyValue("Popotte - ResearchCenter", "5")

        'Add ToolTips To Controls
        Dim buttonToolTip1 As New ToolTip()
        Dim buttonToolTip2 As New ToolTip()
        Dim buttonToolTip3 As New ToolTip()
        Dim buttonToolTip4 As New ToolTip()

        buttonToolTip1.UseFading = True
        buttonToolTip1.UseAnimation = True
        buttonToolTip1.IsBalloon = True
        buttonToolTip1.ShowAlways = True
        buttonToolTip1.AutoPopDelay = 2500
        buttonToolTip1.InitialDelay = 500
        buttonToolTip1.ReshowDelay = 500
        buttonToolTip1.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip2.UseFading = True
        buttonToolTip2.UseAnimation = True
        buttonToolTip2.IsBalloon = True
        buttonToolTip2.ShowAlways = True
        buttonToolTip2.AutoPopDelay = 2500
        buttonToolTip2.InitialDelay = 500
        buttonToolTip2.ReshowDelay = 500
        buttonToolTip2.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip3.UseFading = True
        buttonToolTip3.UseAnimation = True
        buttonToolTip3.IsBalloon = True
        buttonToolTip3.ShowAlways = True
        buttonToolTip3.AutoPopDelay = 2500
        buttonToolTip3.InitialDelay = 500
        buttonToolTip3.ReshowDelay = 500
        buttonToolTip3.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip4.UseFading = True
        buttonToolTip4.UseAnimation = True
        buttonToolTip4.IsBalloon = True
        buttonToolTip4.ShowAlways = True
        buttonToolTip4.AutoPopDelay = 2500
        buttonToolTip4.InitialDelay = 500
        buttonToolTip4.ReshowDelay = 500
        buttonToolTip4.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip1.ToolTipTitle = LangINI.GetKeyValue("Popotte - ResearchCenter", "6")
        buttonToolTip1.SetToolTip(TextBoxSite, LangINI.GetKeyValue("Popotte - ResearchCenter", "7"))
        buttonToolTip2.ToolTipTitle = LangINI.GetKeyValue("Popotte - ResearchCenter", "8")
        buttonToolTip2.SetToolTip(TextBoxCom, LangINI.GetKeyValue("Popotte - ResearchCenter", "9"))
        buttonToolTip3.ToolTipTitle = LangINI.GetKeyValue("Popotte - ResearchCenter", "10")
        buttonToolTip3.SetToolTip(ADD_Button, LangINI.GetKeyValue("Popotte - ResearchCenter", "11"))
        buttonToolTip4.ToolTipTitle = LangINI.GetKeyValue("Popotte - ResearchCenter", "12")
        buttonToolTip4.SetToolTip(DEL_Button, LangINI.GetKeyValue("Popotte - ResearchCenter", "13"))

        ' Set ListViewLivres Properties
        ListViewRC.View = View.Details
        ListViewRC.GridLines = True
        ListViewRC.FullRowSelect = True
        ListViewRC.HideSelection = False
        ListViewRC.MultiSelect = False
        ListViewRC.Sorting = SortOrder.Ascending
        Select Case frmMain.DPI
            Case 96 '100% et 150%
                ' Create Columns Headers
                ListViewRC.Columns.Add(LangINI.GetKeyValue("Popotte - ResearchCenter", "2"), 153)
                ListViewRC.Columns.Add(LangINI.GetKeyValue("Popotte - ResearchCenter", "3"), 280)
            Case 120 '125%
                ' Create Columns Headers
                ListViewRC.Columns.Add(LangINI.GetKeyValue("Popotte - ResearchCenter", "2"), 237)
                ListViewRC.Columns.Add(LangINI.GetKeyValue("Popotte - ResearchCenter", "3"), 280)
        End Select

        LoadDefaultRC()
    End Sub

    Private Sub LoadDefaultRC()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche", True)
        If regKey IsNot Nothing Then
            For Each valueName As String In regKey.GetValueNames()
                ListViewRC.Items.Add(valueName, 0).SubItems.Add(regKey.GetValue(valueName).ToString())
            Next
        End If
    End Sub

    Private Sub ListViewRC_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListViewRC.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            TextBoxSite.Text = ListViewRC.SelectedItems(0).Text
            TextBoxCom.Text = ListViewRC.SelectedItems(0).SubItems(1).Text
        End If
    End Sub

#End Region


#Region "Buttons Methods"
    Private Sub ADD_Button_Click(sender As System.Object, e As System.EventArgs) Handles ADD_Button.Click
        If TextBoxSite.Text <> "" And TextBoxCom.Text <> "" Then
            If CheckifSiteExist(TextBoxSite.Text) <> 1 Then
                ListViewRC.Items.Add(TextBoxSite.Text, 0).SubItems.Add(TextBoxCom.Text)
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche", True)
                If regKey Is Nothing Then
                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
                    regKey = regKey.CreateSubKey("CentreRecherche")
                End If
                regKey.SetValue(TextBoxSite.Text, TextBoxCom.Text)
            Else
                Dim Answer As Integer = MessageBox.Show(LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "2"), "Popotte - " & LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "1"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If Answer = Windows.Forms.DialogResult.Yes Then
                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche", True)
                    If regKey Is Nothing Then
                        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
                        regKey = regKey.CreateSubKey("CentreRecherche")
                    End If
                    regKey.SetValue(TextBoxSite.Text, TextBoxCom.Text)
                    ListViewRC.Items.Clear()
                    LoadDefaultRC()
                End If
            End If
            Dim result As DialogResult = MessageBox.Show(LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "3"), "Popotte", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            Select Case result
                Case DialogResult.Yes
                    Process.Start(Application.ExecutablePath)
                    Application.Exit()
                Case DialogResult.No
                    Exit Select
            End Select
        Else
            MessageBox.Show(LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "4"), "Popotte - " & LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DEL_Button_Click(sender As System.Object, e As System.EventArgs) Handles DEL_Button.Click
        If ListViewRC.SelectedItems.Count = 0 Then
            MessageBox.Show(LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "5"), "Popotte - " & LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim Sitename As String = ListViewRC.SelectedItems(0).Text
            Dim Answer As Integer = MessageBox.Show(LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "6") & " " & Sitename, "Popotte - " & LangINI.GetKeyValue("Popotte - ResearchCenter - MessageBox", "1"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Answer = Windows.Forms.DialogResult.Yes Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche", True)
                regKey.DeleteValue(Sitename)
                ListViewRC.Items.Clear()
                LoadDefaultRC()
            End If
        End If
    End Sub

    Private Function CheckifSiteExist(ByVal sn As String) As Integer
        Dim ReturnVal As Integer = 0
        For Each lvitem As ListViewItem In Me.ListViewRC.Items
            Dim SiteName As String = lvitem.Text
            If SiteName = sn Then
                ReturnVal = 1
                Exit For
            End If
        Next
        Return ReturnVal
    End Function
#End Region

End Class
