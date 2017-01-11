Imports System.IO
Imports System.Text

'Apache v2
'Read "Apache v2.txt"

Public Class CVérifierMiseAJour

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Dim demarrage As Boolean

    'Constructor
    Public Sub New(ByVal demar As Boolean)
        demarrage = demar
    End Sub

    Public Sub CheckForupdate()
        Dim appData As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)
        Dim Destpath As String = appData & "\Popotte\popotte.version"
        Dim Link As String = "https://raw.githubusercontent.com/StormAce/Popotte/Beta/Popotte.version"
        Dim vers As String = Nothing
        If System.IO.File.Exists(Destpath) Then
            Try
                My.Computer.FileSystem.DeleteFile(Destpath)
            Catch ex As IOException
                MessageBox.Show(LangINI.GetKeyValue("Popotte - VerifyUpdate", "3"), "Popotte - " & LangINI.GetKeyValue("Popotte - VerifyUpdate", "1"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
        If DownloadFile(Link, Destpath) <> -1 Then
            'read the version in file
            If System.IO.File.Exists(Destpath) Then
                Dim reader As New StreamReader(Destpath, Encoding.Default)
                vers = reader.ReadLine()
                reader.Close()
                My.Computer.FileSystem.DeleteFile(Destpath)

                'Compare Version
                Dim v1, v2 As System.Version
                v1 = My.Application.Info.Version
                v2 = ParseVersion(vers)

                If v1.CompareTo(v2) < 0 Then
                    Dim answer As Integer = MsgBox(LangINI.GetKeyValue("Popotte - VerifyUpdate", "4") + Environment.NewLine +
                                           LangINI.GetKeyValue("Popotte - VerifyUpdate", "5") + v1.ToString + Environment.NewLine +
                                           LangINI.GetKeyValue("Popotte - VerifyUpdate", "6") + vers + Environment.NewLine +
                                           LangINI.GetKeyValue("Popotte - VerifyUpdate", "7"),
                                           MsgBoxStyle.SystemModal Or MsgBoxStyle.Information Or MsgBoxStyle.OkCancel,
                                          "Popotte - " & LangINI.GetKeyValue("Popotte - VerifyUpdate", "2"))

                    If answer = Windows.Forms.DialogResult.OK Then
                            Process.Start("https://github.com/StormAce/Popotte/commits/Beta")
                    End If
                Else
                    If demarrage = False Then
                        MessageBox.Show(LangINI.GetKeyValue("Popotte - VerifyUpdate", "8"), "Popotte - " & LangINI.GetKeyValue("Popotte - VerifyUpdate", "2"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else

                MessageBox.Show(LangINI.GetKeyValue("Popotte - VerifyUpdate", "9"), "Popotte - " & LangINI.GetKeyValue("Popotte - VerifyUpdate", "1"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    'String to Version
    Private Function ParseVersion(input As String) As Version
        Dim ver As Version = Nothing
        If Version.TryParse(input, ver) Then
            Return ver
        Else
            Return Nothing
        End If
    End Function
End Class
