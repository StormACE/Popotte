Imports System.IO
Imports Microsoft.Win32

''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>

Public Class dlgStartup

    Private LangINI As IniFile = frmMain.LangIni
    Private regKey As RegistryKey = Nothing

    Private Sub dlgStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - Démarrage", "4")
        Label2.Text = LangINI.GetKeyValue("Popotte - Démarrage", "1")
        RadioButton4.Text = LangINI.GetKeyValue("Popotte - Démarrage", "2")
        Button1.Text = LangINI.GetKeyValue("Popotte - Démarrage", "3")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        RadioButton1.Checked = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        RadioButton2.Checked = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            frmMain.ToolStripMenuItemOnedrive_Click(Me, e)
            If (Directory.Exists(frmMain.PopotteDir)) Then
                createfirststartkey()
                Me.Close()
            End If
        ElseIf RadioButton2.Checked Then
            frmMain.ToolStripMenuItemDropbox_Click(Me, e)
            If (Directory.Exists(frmMain.PopotteDir)) Then
                createfirststartkey()
                Me.Close()
            End If
        ElseIf RadioButton4.Checked Then
            frmMain.DossierRecetteToolStripMenuItem_Click(Me, e)

            If Not (Directory.Exists(frmMain.PopotteDir)) Then
                If (CreateFolder(frmMain.PopotteDir) = -1) Then
                    MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "6"), LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    frmMain.askforexamples()
                    createfirststartkey()
                    Me.Close()
                End If
            Else
                frmMain.askforexamples()
                createfirststartkey()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub createfirststartkey()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
        regKey.CreateSubKey("FirstStart")
    End Sub
End Class
