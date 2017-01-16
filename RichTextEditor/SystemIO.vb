''' <summary>
''' Popotte v5
''' 1 mars 2016 au 13 Janvier 2017
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2017
''' Read licence.txt
''' </summary>

Imports System.IO
Imports System.Security

Module SystemIO

    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Public Function CreateFolder(ByRef sPath As String) As Integer
        Dim RetVal As Integer = 0
        Try
            Directory.CreateDirectory(sPath)
        Catch ex As DirectoryNotFoundException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "22"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As PathTooLongException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "23"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As IOException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "24"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As UnauthorizedAccessException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "25"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As ArgumentNullException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "26"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As ArgumentException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "27"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As NotSupportedException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "28"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As Exception
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        End Try
        Return RetVal
    End Function

    Public Function RenameFolder(ByRef SourceDir As String, ByRef NewName As String) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.RenameDirectory(SourceDir, NewName)
        Catch ex As DirectoryNotFoundException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "29"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As PathTooLongException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "23"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As IOException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "30"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As UnauthorizedAccessException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "31"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As ArgumentNullException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "26"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As ArgumentException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "27"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As NotSupportedException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "28"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As SecurityException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "31"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As Exception
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        End Try
        Return RetVal
    End Function

    Public Function RenameFile(ByRef SourceFile As String, ByRef NewName As String, ByRef ext As String) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.RenameFile(SourceFile, NewName & ext)
        Catch ex As FileNotFoundException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "29"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As PathTooLongException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "23"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As IOException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "32"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As UnauthorizedAccessException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "31"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As ArgumentNullException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "26"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As ArgumentException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "27"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As NotSupportedException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "28"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As SecurityException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "31"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            RetVal = -1
        Catch ex As Exception
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        End Try
        Return RetVal
    End Function

    'Send folder to recycle bin
    Public Function RecycleFolder(ByRef sPath As String) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.DeleteDirectory(sPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
        Catch ex As FileNotFoundException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "34"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Error) 'error : file not found
            RetVal = -1
        Catch ex As ArgumentNullException
            'MessageBox.Show("Error : Textbox empty") 
            RetVal = -1
        Catch ex As DirectoryNotFoundException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "29"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            RetVal = -1
        Catch ex As NotSupportedException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "28"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            RetVal = -1
        Catch ex As PathTooLongException
            'MessageBox.Show("The path exceeds the system-defined maximum length")
            RetVal = -1
        Catch ex As Exception
            'MessageBox.Show("Erreur : " & ex.ToString) 'else display any possible error
            RetVal = -1
        Finally
        End Try
        Return RetVal
    End Function

    'Send file to recycle bin
    Public Function RecycleFile(ByRef sPath As String) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.DeleteFile(sPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
        Catch ex As FileNotFoundException
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "34"), "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'error : file not found
            RetVal = -1
        Catch ex As ArgumentNullException
            'MessageBox.Show("Error : Textbox empty") 'error : empty textbox
            RetVal = -1
        Catch ex As PathTooLongException
            'MessageBox.Show("The path exceeds the system-defined maximum length")
            RetVal = -1
        Catch ex As Exception
            'MessageBox.Show("Erreur : " & ex.ToString) 'else display any possible error
            RetVal = -1
        Finally
        End Try
        Return RetVal
    End Function

    'Copy folder
    Public Function CopyFolder(ByRef sPath As String, ByRef sDest As String) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.CopyDirectory(sPath, sDest, True)
        Catch ex As Exception
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        Finally
        End Try
        Return RetVal
    End Function

    'Move File
    Public Function MoveFile(ByRef sPath As String, ByRef sDest As String, ByRef bOverwrite As Boolean) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.MoveFile(sPath, sDest, bOverwrite)
        Catch ex As Exception
            MessageBox.Show(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            RetVal = -1
        Finally
        End Try
        Return RetVal
    End Function

    'is directory empty
    Public Function IsDirectoryEmpty(path As String) As Boolean
        Dim dirs() As String = System.IO.Directory.GetDirectories(path)
        Dim files() As String = System.IO.Directory.GetFiles(path)

        If (dirs.Length = 0 And files.Length = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
