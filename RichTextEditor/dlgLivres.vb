Imports System.IO
Imports Microsoft.Win32
Imports System.Text

''' <summary>
''' Popotte v5
''' 1 mars 2016 au 30 juin 2019
''' Work on Vista sp2, Windows 7 sp1, windows 8, Windows 8.1 and Windows 10. Need .Net Framework 4.0
''' Copyright Martin Laflamme 2003/2019
''' Read licence.txt
''' </summary>

Public Class dlgLivres

#Region "Declarations"
    'Get Popotte Dir
    Public PopotteDir As String = frmMain.PopotteDir
    'Folder we are in
    Private LastLivre As String = ""
    'Use for registry
    Private regKey As RegistryKey
    'use by listviewrecette
    Private imageListSmallRecette As New ImageList
    'Get Language
    Private LangINI As IniFile = frmMain.LangIni

    Private Fav As Boolean = False
#End Region


#Region "Form Methods"
    Private Sub Livres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Controls Language
        RevenirButton.Text = LangINI.GetKeyValue("Popotte - BooksDialog", "2")
        ButtonRecherche.Text = LangINI.GetKeyValue("Popotte - BooksDialog", "3")
        FermerButton.Text = LangINI.GetKeyValue("Popotte - BooksDialog", "4")

        'Contextmenu Language
        NewBookToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "1")
        ChangerLeNomDuLivreToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "2")
        EffacerLeLivreToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "3")
        ModifierLesInfosDeLaRecetteToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "4")
        OuvrirAvecEditeurExterneToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "5")
        EffacerLaRecetteToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "6")
        EnleverFavToolStripMenuItem.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "7")
        ToolStripMenuItemFAV.Text = LangINI.GetKeyValue("Popotte - BooksDialog - Contextmenu", "8")


        ' Set ListViewLivres Properties
        ListViewLivres.View = View.Details
        ListViewLivres.GridLines = True
        ListViewLivres.FullRowSelect = True
        ListViewLivres.HideSelection = False
        ListViewLivres.MultiSelect = False
        ListViewLivres.ShowItemToolTips = True
        ListViewLivres.Sorting = SortOrder.Ascending
        ListViewLivres.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)
        Select Case frmMain.DPI
            Case 96 '100% et 150%
                ' Create Columns Headers
                ListViewLivres.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "5"), 565)
                ListViewLivres.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "6"), 88)
            Case 120 '125%
                ' Create Columns Headers
                ListViewLivres.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "5"), 697)
                ListViewLivres.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "6"), 88)
        End Select
        ListViewLivres.Columns(0).Tag = "String"
        ListViewLivres.Columns(1).Tag = "Numeric"

        ' Set ListViewRecettes Properties
        ListViewRecettes.Visible = False
        ListViewRecettes.View = View.Details
        ListViewRecettes.GridLines = True
        ListViewRecettes.FullRowSelect = True
        ListViewRecettes.HideSelection = False
        ListViewRecettes.MultiSelect = True
        ListViewRecettes.ShowItemToolTips = True
        ListViewRecettes.Sorting = SortOrder.Ascending
        ListViewRecettes.Font = New Font(New FontFamily("Arial"), 10, FontStyle.Regular)
        Select Case frmMain.DPI
            Case 96 '100% et 150%
                ' Create Columns Headers
                ListViewRecettes.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "6"), 360)
                ListViewRecettes.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "7"), 110)
                ListViewRecettes.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "8"), 182)
            Case 120 '125%
                ' Create Columns Headers
                ListViewRecettes.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "6"), 455)
                ListViewRecettes.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "7"), 105)
                ListViewRecettes.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "8"), 230)
        End Select
        ListViewRecettes.Columns(0).Tag = "String"
        ListViewRecettes.Columns(1).Tag = "String"

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\EditeurExt", True)
        If regKey IsNot Nothing Then
            OuvrirAvecEditeurExterneToolStripMenuItem.Enabled = True
        End If

        ' Set ListViewRecherche Properties
        ListViewRecherche.Visible = False
        ListViewRecherche.View = View.Details
        ListViewRecherche.GridLines = True
        ListViewRecherche.FullRowSelect = True
        ListViewRecherche.HideSelection = False
        ListViewRecherche.MultiSelect = False
        ListViewRecherche.ShowItemToolTips = True
        ListViewRecherche.Sorting = SortOrder.Ascending
        Select Case frmMain.DPI
            Case 96 '100% et 150%
                ' Create Columns Headers
                ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "6"), 360)
                ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "7"), 110)
                ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "8"), 182)
            Case 120 '125%
                ' Create Columns Headers
                ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "6"), 455)
                ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "7"), 105)
                ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "8"), 230)
        End Select
        ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "9"), 0)
        ListViewRecherche.Columns.Add("Position", 0)
        ListViewRecherche.Columns.Add(LangINI.GetKeyValue("Popotte - BooksDialog", "10"), 0)
        ListViewRecherche.Columns(0).Tag = "String"
        ListViewRecherche.Columns(1).Tag = "String"

        'Faire une imagelist avec les icons specifier
        Dim imageListSmall As New ImageList
        imageListSmall.ImageSize = New Size(65, 65)
        imageListSmall.Images.Add(Image.FromFile(Application.StartupPath & "\Images\livre.bmp"))

        'les image sont ajouter dynamiquement dans unn sub
        imageListSmallRecette.ImageSize = New Size(75, 75)

        ListViewLivres.SmallImageList = imageListSmall
        ListViewRecettes.SmallImageList = imageListSmallRecette
        ListViewRecherche.SmallImageList = imageListSmallRecette

        'Add ToolTips To Controls
        Dim buttonToolTip1 As New ToolTip()
        Dim buttonToolTip2 As New ToolTip()
        Dim buttonToolTip3 As New ToolTip()
        Dim buttonToolTip4 As New ToolTip()
        Dim buttonToolTip5 As New ToolTip()
        Dim buttonToolTip6 As New ToolTip()

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

        buttonToolTip5.UseFading = True
        buttonToolTip5.UseAnimation = True
        buttonToolTip5.IsBalloon = True
        buttonToolTip5.ShowAlways = True
        buttonToolTip5.AutoPopDelay = 2500
        buttonToolTip5.InitialDelay = 500
        buttonToolTip5.ReshowDelay = 500
        buttonToolTip5.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip6.UseFading = True
        buttonToolTip6.UseAnimation = True
        buttonToolTip6.IsBalloon = True
        buttonToolTip6.ShowAlways = True
        buttonToolTip6.AutoPopDelay = 2500
        buttonToolTip6.InitialDelay = 500
        buttonToolTip6.ReshowDelay = 500
        buttonToolTip6.ToolTipIcon = ToolTipIcon.Info

        buttonToolTip1.ToolTipTitle = LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "5")
        buttonToolTip1.SetToolTip(RevenirButton, LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "1"))
        buttonToolTip2.ToolTipTitle = LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "6")
        buttonToolTip2.SetToolTip(FermerButton, LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "2"))
        buttonToolTip3.ToolTipTitle = LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "7")
        buttonToolTip3.SetToolTip(ButtonRecherche, LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "3"))
        buttonToolTip4.ToolTipTitle = LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "8")
        buttonToolTip4.SetToolTip(TextBoxRecherche, LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "4"))
        buttonToolTip5.ToolTipTitle = LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "9")
        buttonToolTip5.SetToolTip(ButtonFav, LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "10"))
        buttonToolTip6.ToolTipTitle = LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "11")
        buttonToolTip6.SetToolTip(ButtonRandom, LangINI.GetKeyValue("Popotte - BooksDialog - Tooltips", "12"))

        'the textbox suggest favorites
        Dim Favcollection As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        TextBoxRecherche.AutoCompleteSource = AutoCompleteSource.CustomSource
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites", True)
        If regKey IsNot Nothing Then
            For Each subkeyname As String In regKey.GetSubKeyNames
                Favcollection.Add(subkeyname)
            Next
            TextBoxRecherche.AutoCompleteCustomSource = Favcollection
        End If

        'Populer la listview avec les livres
        If frmMain.LivreOuvert = "" Then
            If GetLivres() > 0 Then
                With ListViewLivres
                    .Items.Item(0).Selected = True
                    .Items.Item(0).EnsureVisible()
                End With
                RevenirButton.Enabled = False
            End If
        Else
            If (Directory.Exists(PopotteDir & frmMain.LivreOuvert & "\")) Then
                GetRecettes(PopotteDir & frmMain.LivreOuvert & "\")

                'trouve la derniere recette ouverte et la trouve dans la listview pour ensuite la selectionner et la montrer
                Dim itm As ListViewItem
                With ListViewRecettes
                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    Dim filename As String = Path.GetFileNameWithoutExtension(regKey.GetValue("Recette", ""))
                    If File.Exists(regKey.GetValue("DerRecette", "").ToString) Then
                        itm = .FindItemWithText(filename, False, 0, True)
                        If Not itm Is Nothing Then
                            .Items.Item(itm.Index).Selected = True
                            .Items.Item(itm.Index).EnsureVisible()
                        End If
                    End If
                End With
                RevenirButton.Enabled = True
                LastLivre = frmMain.LivreOuvert
                ListViewRecettes.Focus()
            Else
                GetLivres()
                RevenirButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub Livres_Closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closing
        Dispose()
        GC.Collect()
    End Sub


    Public Function GetLivres() As Integer
        Dim LivresCount As Integer = 0
        Dim RecetteTotalCount As Integer = 0
        Me.ListViewLivres.Items.Clear()
        If (Directory.Exists(PopotteDir)) Then
            For Each Folder As String In
            My.Computer.FileSystem.GetDirectories(PopotteDir)
                'Retourne le nom du dossier
                Dim FolderName As String = Path.GetFileName(Folder)
                'le nombre de recette du dossier
                Dim RecetteCount As Integer = GetLivresRecetteCount(Folder)
                RecetteTotalCount += RecetteCount
                'Ajouter le dossier a la listview
                Me.ListViewLivres.Items.Add(FolderName, 0).SubItems.Add(RecetteCount)
                LivresCount += 1
            Next
        End If
        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "1") & LivresCount & LangINI.GetKeyValue("Popotte - BooksDialog", "11") & RecetteTotalCount & ")"
        Return LivresCount
    End Function

    Private Function GetLivresRecetteCount(ByVal Path As String) As Integer

        'set search parameters
        Dim di As New DirectoryInfo(Path)
        Dim aryFi As FileInfo() = di.GetFiles("*.rtf")
        Dim fi As FileInfo
        'count files
        Dim Rcount As Integer = 0
        For Each fi In aryFi
            Rcount += 1
        Next
        Return Rcount
    End Function

    Private Sub ListViewLivres_MouseDoubleClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles ListViewLivres.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim NomLivre As String = ListViewLivres.SelectedItems(0).Text
            LastLivre = NomLivre
            GetRecettes(PopotteDir & NomLivre & "\")
            RevenirButton.Enabled = True
            ListViewRecettes.Focus()
        End If
    End Sub

    Private Sub ListViewLivres_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles ListViewLivres.ColumnClick
        SortMyListView(ListViewLivres, e.Column, False, True)
    End Sub

    Private Sub ListViewLivres_AfterLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles ListViewLivres.AfterLabelEdit
        ' Determine if label is changed by checking to see if it is equal to Nothing.
        If e.Label Is Nothing Then
            Return
        End If
        Dim SourceLivreLabel As String = ListViewLivres.SelectedItems(0).Text

        Dim SourceDir As String = PopotteDir & SourceLivreLabel
        Dim NewName As String = e.Label.ToString.Trim

        If NewName <> "" Then
            If NewName <> SourceDir Then
                If RenameFolder(SourceDir, NewName + "_bak") <> -1 Then
                    If RenameFolder(PopotteDir + NewName + "_bak", NewName) <> -1 Then
                        Dim SourceRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & SourceLivreLabel, True)
                        SourceRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & SourceDir, True)
                        RenameLivreKey(SourceRegKey, NewName, SourceDir)
                    End If
                End If
            End If
        Else
            MsgBox(LangINI.GetKeyValue("Popotte - ChangeBookName - MessageBox", "2"), MsgBoxStyle.Exclamation, "Popotte - " & LangINI.GetKeyValue("Popotte - ChangeBookName - MessageBox", "1"))
        End If
    End Sub

    Private Sub RenameLivreKey(ByVal Sourcekey As RegistryKey, ByVal Destkeyname As String, ByVal Livre As String)
        If Sourcekey IsNot Nothing Then
            Dim RegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
            Dim NewBaseRegKey As RegistryKey = RegKey.CreateSubKey(Destkeyname)
            Dim subKeys As String() = Sourcekey.GetSubKeyNames()
            If subKeys IsNot Nothing Then
                For Each subKeyName As String In subKeys
                    Dim NewSubRegKey As RegistryKey = NewBaseRegKey.CreateSubKey(subKeyName)
                    Dim SubRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & Livre & "\" & subKeyName, True)
                    Dim Note As Integer = SubRegKey.GetValue("Note")
                    Dim Desc As String = SubRegKey.GetValue("Description")
                    NewSubRegKey.SetValue("Note", Note)
                    NewSubRegKey.SetValue("Description", Desc)
                    Sourcekey.DeleteSubKey(subKeyName)
                Next
                Dim SRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
                SRegKey.DeleteSubKey(Livre)
            End If
        End If
    End Sub

    Private Sub ListViewRecettes_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListViewRecettes.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Dim NomRecette As String = ListViewRecettes.SelectedItems(0).Text
            frmMain.currentFile = NomRecette
            LoadRecette(NomRecette)
        End If
    End Sub

    Private Sub ListViewRecettes_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles ListViewRecettes.ColumnClick
        If e.Column <> 2 Then
            SortMyListView(ListViewRecettes, e.Column, False, True)
        End If
    End Sub

    Private Sub ListViewRecettes_AfterLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles ListViewRecettes.AfterLabelEdit
        ' Determine if label is changed by checking to see if it is equal to Nothing.
        If e.Label Is Nothing Then
            Return
        End If
        Dim SourceRecetteLabel As String = ListViewRecettes.SelectedItems(0).Text

        If LastLivre <> "" Then
            Dim LivreRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & LastLivre, True)
            If LivreRegKey Is Nothing Then
                LivreRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
                Dim NewLivreRegKey As RegistryKey = LivreRegKey.CreateSubKey(LastLivre)
            End If
            If Directory.Exists(PopotteDir & LastLivre) <> True Then
                CreateFolder(PopotteDir & LastLivre)
            End If
            If RenameFile(PopotteDir & LastLivre & "\" & SourceRecetteLabel & ".rtf", e.Label.ToString.Trim, ".rtf") <> -1 Then
                Dim SourceBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\", True)
                If SourceBaseRegKey IsNot Nothing Then
                    Dim NewSourceBaseRegKey As RegistryKey = SourceBaseRegKey.CreateSubKey(LastLivre)
                    If NewSourceBaseRegKey IsNot Nothing Then
                        Dim NewSrcRecetteBaseRegKey As RegistryKey = NewSourceBaseRegKey.CreateSubKey(e.Label.ToString.Trim)
                        If NewSrcRecetteBaseRegKey IsNot Nothing Then
                            Dim SourceBaseOldRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & LastLivre & "\" & SourceRecetteLabel, True)
                            If SourceBaseOldRegKey IsNot Nothing Then
                                NewSrcRecetteBaseRegKey.SetValue("Note", SourceBaseOldRegKey.GetValue("Note"))
                                NewSrcRecetteBaseRegKey.SetValue("Description", SourceBaseOldRegKey.GetValue("Description"))
                                Dim OldBaseRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & LastLivre, True)
                                If SourceBaseOldRegKey IsNot Nothing Then
                                    OldBaseRegKey.DeleteSubKey(SourceRecetteLabel)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ListViewRecherche_MouseDoubleClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles ListViewRecherche.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            RechercheItemClick()
        End If
    End Sub

    Private Sub ListViewRecherche_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles ListViewRecherche.ColumnClick
        If e.Column < 2 Then
            SortMyListView(ListViewRecherche, e.Column, False, True)
        End If
    End Sub

    Private Sub ListViewRecettes_MouseClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles ListViewRecettes.MouseClick
        If e.Button = MouseButtons.Right Then
            If ListViewRecettes.SelectedItems.Count > 1 Then
                RecetteContextMenuStrip.Show(ListViewRecettes, New Point(e.X, e.Y))
                EffacerLaRecetteToolStripMenuItem.Enabled = False
                OuvrirAvecEditeurExterneToolStripMenuItem.Enabled = False
                ToolStripMenuItemFAV.Enabled = False
            ElseIf ListViewRecettes.SelectedItems.Count = 1 Then
                RecetteContextMenuStrip.Show(ListViewRecettes, New Point(e.X, e.Y))
                EffacerLaRecetteToolStripMenuItem.Enabled = True
                OuvrirAvecEditeurExterneToolStripMenuItem.Enabled = True
                ToolStripMenuItemFAV.Enabled = True
            End If
        End If
    End Sub

    Private Sub ListViewRecherche_MouseClick(sender As Object, e As MouseEventArgs) Handles ListViewRecherche.MouseClick
        If Fav = True Then
            If e.Button = MouseButtons.Right Then
                If ListViewRecherche.SelectedItems.Count > 0 Then
                    FavorisContextMenuStrip.Show(ListViewRecherche, New Point(e.X, e.Y))
                End If
            End If
        End If
    End Sub

    Private Sub ListViewLivres_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ListViewLivres.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Dim NomLivre As String = ListViewLivres.SelectedItems(0).Text
                LastLivre = NomLivre
                GetRecettes(PopotteDir & NomLivre & "\")
                With ListViewRecettes
                    .Items.Item(0).Selected = True
                    .Items.Item(0).EnsureVisible()
                End With
                RevenirButton.Enabled = True
                ListViewRecettes.Focus()
            Case Keys.Delete
                DeleteLivre()
        End Select
    End Sub

    Private Sub ListViewRecettes_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ListViewRecettes.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                Dim NomRecette As String = ListViewRecettes.SelectedItems(0).Text
                frmMain.currentFile = NomRecette
                LoadRecette(NomRecette)
            Case Keys.Delete
                DeleteRecette()
            Case Keys.Back
                RevenirButton_Click(Me, e)
        End Select
    End Sub

    Private Sub ListViewRecherche_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ListViewRecherche.KeyDown
        If e.KeyCode = Keys.Return Then
            RechercheItemClick()
            e.Handled = True
        End If
    End Sub

    Private Sub RechercheItemClick()
        Dim NomRecette As String = ListViewRecherche.SelectedItems(0).Text
        Dim position As Integer = -1
        Dim Recherchetexte As String = ""

        frmMain.currentFile = NomRecette
        LastLivre = ListViewRecherche.SelectedItems(0).SubItems(3).Text

        If Fav = False Then
            position = CType(ListViewRecherche.SelectedItems(0).SubItems(4).Text, Integer)
            Recherchetexte = ListViewRecherche.SelectedItems(0).SubItems(5).Text
        End If

        Dim recette As String = NomRecette & ".rtf"
        Dim Path As String = ""
        If LastLivre <> "" Then
            Path = PopotteDir & LastLivre & "\" & recette
            frmMain.LivreOuvert = LastLivre
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            regKey.SetValue("DerRecette", Path)
            regKey.SetValue("Livre", LastLivre)
            regKey.SetValue("Recette", NomRecette)
        Else
            Path = PopotteDir & frmMain.LivreOuvert & "\" & recette
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            regKey.SetValue("DerRecette", Path)
            regKey.SetValue("Livre", frmMain.LivreOuvert)
            regKey.SetValue("Recette", NomRecette)
        End If

        frmMain.rtbDoc.LoadFile(Path, RichTextBoxStreamType.RichText)

        If Fav = False Then
            ' Highlight the search string
            If position <> -1 Then
                frmMain.rtbDoc.Select(position, Recherchetexte.Length)
                frmMain.Text = "Popotte - [" & recette & "]"
            Else
                frmMain.Text = "Popotte - [" & recette & "]"
            End If
        End If

        Fav = False
        Close()
        frmMain.rtbDoc.Modified = False
    End Sub

    Private Sub LivreContextMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LivreContextMenuStrip.Opening
        If ListViewLivres.SelectedItems.Count > 0 Then
            EffacerLeLivreToolStripMenuItem.Enabled = True
            ChangerLeNomDuLivreToolStripMenuItem.Enabled = True
        Else
            EffacerLeLivreToolStripMenuItem.Enabled = False
            ChangerLeNomDuLivreToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Function LoadRecette(ByVal nRecette As String)
        Dim recette As String = nRecette & ".rtf"
        Dim Path As String = ""
        If LastLivre <> "" Then
            Path = PopotteDir & LastLivre & "\" & recette
            frmMain.LivreOuvert = LastLivre
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            regKey.SetValue("DerRecette", Path)
            regKey.SetValue("Livre", LastLivre)
            regKey.SetValue("Recette", recette)
        Else
            Path = PopotteDir & frmMain.LivreOuvert & "\" & recette
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            regKey.SetValue("DerRecette", Path)
            regKey.SetValue("Livre", frmMain.LivreOuvert)
            regKey.SetValue("Recette", recette)
        End If
        frmMain.rtbDoc.LoadFile(Path, RichTextBoxStreamType.RichText)
        frmMain.Text = "Popotte - [" & recette & "]"
        frmMain.GetCharFormat()
        frmMain.rtbDoc.Modified = False
        frmMain.RappelTimer.Stop()
        frmMain.RappelTimer.Start()
        Me.Close()
        Return Nothing
    End Function

    Private Sub GetRecettes(ByVal Path As String)
        Dim objItem As ListViewItem
        Dim note As Integer
        Dim description As String

        'set search parameters
        Dim di As New DirectoryInfo(Path)
        Dim aryFi As FileInfo() = di.GetFiles("*.rtf")
        Dim fi As FileInfo
        'count files
        Dim Rcount As Integer = 0

        Me.ListViewRecettes.Items.Clear()
        imageListSmallRecette.Images.Clear()
        Me.ListViewLivres.Visible = False
        Me.ListViewRecettes.Visible = True

        Dim imgidx As Integer = 0

        If LastLivre <> "" Then
            Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "12") & " " & LastLivre & " (" & 0 & ")"
        Else
            Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "12") & " " & frmMain.LivreOuvert & " (" & 0 & ")"
        End If

        For Each fi In aryFi
            'Remove the extension
            Dim dotPosition As Integer = fi.Name.LastIndexOf(".")
            Dim rname As String = Strings.Left(fi.Name, fi.Name.Length - 4)
            'Get registry comments
            Dim key As String
            If LastLivre <> "" Then
                key = "Software\Popotte\Livres\" & LastLivre & "\" & rname
            Else
                key = "Software\Popotte\Livres\" & frmMain.LivreOuvert & "\" & rname
            End If

            regKey = Registry.CurrentUser.OpenSubKey(key, True)
            If regKey Is Nothing Then
                note = 5
                description = ""
            Else
                note = regKey.GetValue("Note", 5)
                description = regKey.GetValue("Description", "")
            End If

            AddImageToImagelist(rname, "")

            'Add to listview
            objItem = ListViewRecettes.Items.Add(rname)
            With objItem
                .SubItems.Add(ConvertNote(note))
                .SubItems.Add(description)
                .ImageIndex = imgidx
            End With

            imgidx += 1

            'Count items
            Rcount += 1

            If LastLivre <> "" Then
                Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "12") & " " & LastLivre & " (" & Rcount & ")"
            Else
                Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "12") & " " & frmMain.LivreOuvert & " (" & Rcount & ")"
            End If
        Next
    End Sub

    Private Function ConvertNote(ByVal Note As Integer) As String
        Dim CNote As String = ""
        Select Case Note
            Case 0
                CNote = "5 - " & LangINI.GetKeyValue("Popotte - BooksDialog", "13")
            Case 1
                CNote = "4 - " & LangINI.GetKeyValue("Popotte - BooksDialog", "14")
            Case 2
                CNote = "3 - " & LangINI.GetKeyValue("Popotte - BooksDialog", "15")
            Case 3
                CNote = "2 - " & LangINI.GetKeyValue("Popotte - BooksDialog", "16")
            Case 4
                CNote = "1 - " & LangINI.GetKeyValue("Popotte - BooksDialog", "17")
            Case 5
                CNote = ""
        End Select
        Return CNote
    End Function

    Private Sub TextBoxRecherche_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBoxRecherche.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Recherche()
            e.Handled = True
        End If
    End Sub

    Private Sub AddImageToImagelist(itemname As String, livre As String)
        'lis la recette dans une string
        Dim rtfStr As String = ""

        Try

            If ListViewRecettes.Visible = True Then
                If LastLivre <> "" Then
                    rtfStr = File.ReadAllText(PopotteDir & LastLivre & "\" & itemname & ".rtf")
                Else
                    rtfStr = File.ReadAllText(PopotteDir & frmMain.LivreOuvert & "\" & itemname & ".rtf")
                End If
            ElseIf ListViewRecherche.Visible = True Then
                rtfStr = File.ReadAllText(PopotteDir & livre & "\" & itemname & ".rtf")
            End If
        Catch ex As Exception

        End Try


        If frmMain.ImageRecette Then
            'extract image from rtf
            Dim imageDataHex As String = ExtractImgHex(rtfStr)
            If imageDataHex IsNot Nothing Then
                Dim imageBuffer As Byte() = ToBinary(imageDataHex)
                Using stream As New MemoryStream(imageBuffer)
                    Dim img = New Bitmap(stream)
                    imageListSmallRecette.Images.Add(img)
                End Using
            Else
                imageListSmallRecette.Images.Add(Image.FromFile(Application.StartupPath & "\Images\Recette.bmp"))
            End If
        Else
            imageListSmallRecette.Images.Add(Image.FromFile(Application.StartupPath & "\Images\Recette.bmp"))
        End If
    End Sub

    'use to extract image from rtf
    Public Function ExtractImgHex(s As String) As String
        Dim pictTagIdx As Integer = s.IndexOf("{\pict\")
        If pictTagIdx <> -1 Then
            Dim startIndex As Integer = s.IndexOf(" ", pictTagIdx) + 1
            Dim endIndex As Integer = s.IndexOf("}", startIndex)
            Return s.Substring(startIndex, endIndex - startIndex)
        Else
            Return Nothing
        End If
    End Function

    'use to extract image from rtf
    Public Function ToBinary(imageDataHex As String) As Byte()
        If (imageDataHex = Nothing) Then
            Throw New ArgumentNullException("imageDataHex")
        End If

        Dim hexDigits As Integer = imageDataHex.Length
        Dim dataSize As Integer = hexDigits / 2
        Dim imageDataBinary(dataSize) As Byte

        Dim Hex As StringBuilder = New StringBuilder(2)

        Dim dataPos As Integer = 0
        For i As Integer = 0 To hexDigits - 1
            Dim c As Char = imageDataHex(i)
            If (Char.IsWhiteSpace(c)) Then
                Continue For
            End If
            Hex.Append(imageDataHex(i))
            If (Hex.Length = 2) Then
                imageDataBinary(dataPos) = Byte.Parse(Hex.ToString(), System.Globalization.NumberStyles.HexNumber)
                dataPos += 1
                Hex.Remove(0, 2)
            End If
        Next
        Return imageDataBinary
    End Function

    Friend Sub SortMyListView(ByVal ListViewToSort As ListView, ByVal ColumnNumber As Integer, Optional ByVal Resort As Boolean = False, Optional ByVal ForceSort As Boolean = False)
        ' Sorts a list view column by string, number, or date.  The three types of sorts must be specified within the listview columns "tag" property unless the ForceSort option is enabled.
        ' ListViewToSort - The listview to sort
        ' ColumnNumber - The column number to sort by
        ' Resort - Resorts a listview in the same direction as the last sort
        ' ForceSort - Forces a sort even if no listview tag data exists and assumes a string sort.  If this is false (default) and no tag is specified the procedure will exit
        Dim SortOrder As SortOrder
        Static LastSortColumn As Integer = -1
        Static LastSortOrder As SortOrder = SortOrder.Ascending
        If Resort Then
            SortOrder = LastSortOrder
        Else
            If LastSortColumn = ColumnNumber Then
                If LastSortOrder = SortOrder.Ascending Then
                    SortOrder = SortOrder.Descending
                Else
                    SortOrder = SortOrder.Ascending
                End If
            Else
                SortOrder = SortOrder.Descending
            End If
        End If

        ' In case a tag wasn't specified check if we should force a string sort
        If String.IsNullOrEmpty(CStr(ListViewToSort.Columns(ColumnNumber).Tag)) Then
            If ForceSort Then
                ListViewToSort.Columns(ColumnNumber).Tag = "String"
            Else
                ' don't sort since no tag was specified.
                Exit Sub
            End If
        End If

        Select Case ListViewToSort.Columns(ColumnNumber).Tag.ToString
            Case "Numeric"
                ListViewToSort.ListViewItemSorter = New ListViewNumericSort(ColumnNumber, SortOrder)
            Case "Date"
                ListViewToSort.ListViewItemSorter = New ListViewDateSort(ColumnNumber, SortOrder)
            Case "String"
                ListViewToSort.ListViewItemSorter = New ListViewStringSort(ColumnNumber, SortOrder)
        End Select
        LastSortColumn = ColumnNumber
        LastSortOrder = SortOrder
        ListViewToSort.ListViewItemSorter = Nothing
    End Sub
#End Region

#Region "Buttons Methods"
    Private Sub FermerButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FermerButton.Click
        Livres_Closing(Me, e)
    End Sub

    Private Sub RevenirButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RevenirButton.Click
        GetLivres()
        Me.ListViewLivres.Visible = True
        Me.ListViewRecettes.Visible = False
        Me.ListViewRecherche.Visible = False
        RevenirButton.Enabled = False
        If LastLivre <> "" Then
            Dim itm As ListViewItem = ListViewLivres.FindItemWithText(LastLivre, False, 0, True)
            If Not itm Is Nothing Then
                ListViewLivres.Items.Item(itm.Index).Selected = True
                ListViewLivres.Items.Item(itm.Index).EnsureVisible()
                ListViewLivres.Items.Item(itm.Index).Focused = True
                ListViewLivres.Focus()
            End If
        End If
    End Sub

    Private Sub ButtonRecherche_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRecherche.Click
        Recherche()
    End Sub

    Private Sub Recherche()
        Dim objItem As ListViewItem
        imageListSmallRecette.Images.Clear()
        Dim RechercheTexte As String = Strings.LCase(TextBoxRecherche.Text.Trim)
        If RechercheTexte <> "" Then
            ListViewRecettes.Visible = False
            ListViewRecherche.Visible = True
            Fav = False
            Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "18") & 0 & LangINI.GetKeyValue("Popotte - BooksDialog", "19")
            Me.Cursor = Cursors.WaitCursor
            Dim RecetteTotalCount As Integer = 0
            Me.ListViewRecherche.Items.Clear()
            Dim imgidx As Integer = 0
            If (Directory.Exists(PopotteDir)) Then
                For Each Folder As String In My.Computer.FileSystem.GetDirectories(PopotteDir)
                    'Retourne le nom du dossier
                    Dim FolderName As String = Path.GetFileName(Folder)
                    'set search parameters
                    Dim di As New DirectoryInfo(PopotteDir & FolderName)
                    Dim aryFi As FileInfo() = di.GetFiles("*.rtf")
                    Dim fi As FileInfo
                    For Each fi In aryFi
                        Dim Filename As String = Strings.LCase(fi.Name)
                        Dim FirstCharacter As Integer = Strings.Left(Filename, Filename.Length - 4).IndexOf(RechercheTexte.Trim)
                        If FirstCharacter <> -1 Then
                            Dim key = "Software\Popotte\Livres\" & FolderName & "\" & Strings.Left(Filename, Filename.Length - 4)
                            Dim note As Integer = -1
                            Dim Description As String = ""
                            regKey = Registry.CurrentUser.OpenSubKey(key, True)
                            If regKey IsNot Nothing Then
                                note = CType(regKey.GetValue("Note", -1), Integer)
                                Description = regKey.GetValue("Description", "").ToString
                            End If

                            AddImageToImagelist(Strings.Left(Filename, Filename.Length - 4), FolderName)

                            'Add to listview
                            objItem = ListViewRecherche.Items.Add(Strings.Left(fi.Name, fi.Name.Length - 4))
                            With objItem
                                .SubItems.Add(ConvertNote(note))
                                .SubItems.Add(Description)
                                .SubItems.Add(FolderName)
                                .SubItems.Add(-1)
                                .SubItems.Add(RechercheTexte)
                                .ImageIndex = imgidx
                            End With
                            RecetteTotalCount += 1
                            imgidx += 1
                            Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "18") & RecetteTotalCount & LangINI.GetKeyValue("Popotte - BooksDialog", "19")
                        Else
                            Dim Path As String = PopotteDir & FolderName & "\" & Filename
                            Dim key As String = "Software\Popotte\Livres\" & FolderName & "\" & Strings.Left(Filename, Filename.Length - 4)
                            Dim note As Integer = -1
                            Dim Description As String = ""

                            'Search description
                            regKey = Registry.CurrentUser.OpenSubKey(key, True)
                            If regKey IsNot Nothing Then
                                note = CType(regKey.GetValue("Note", -1), Integer)
                                Description = regKey.GetValue("Description", "").ToString
                            End If
                            Dim DescFound As Integer = LCase(Description).IndexOf(LCase(RechercheTexte.Trim))
                            If DescFound <> -1 Then
                                AddImageToImagelist(Strings.Left(Filename, Filename.Length - 4), FolderName)

                                'Add to listview
                                objItem = ListViewRecherche.Items.Add(Strings.Left(fi.Name, fi.Name.Length - 4))
                                With objItem
                                    .SubItems.Add(ConvertNote(note))
                                    .SubItems.Add(Description)
                                    .SubItems.Add(FolderName)
                                    .SubItems.Add(-1)
                                    .SubItems.Add(RechercheTexte)
                                    .ImageIndex = imgidx
                                End With
                                RecetteTotalCount += 1
                                imgidx += 1
                                Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "18") & RecetteTotalCount & LangINI.GetKeyValue("Popotte - BooksDialog", "19")
                                GoTo FileFound
                            End If

                            'search Files
                            ScanRichTextBox.LoadFile(Path, RichTextBoxStreamType.RichText)
                            Dim Position As Integer = ScanRichTextBox.Find(RechercheTexte.Trim, 0, ScanRichTextBox.Text.Length, RichTextBoxFinds.None)
                            GC.Collect()
                            If Position <> -1 Then
                                regKey = Registry.CurrentUser.OpenSubKey(key, True)
                                If regKey IsNot Nothing Then
                                    note = CType(regKey.GetValue("Note", -1), Integer)
                                    Description = regKey.GetValue("Description", "").ToString
                                End If

                                AddImageToImagelist(Strings.Left(Filename, Filename.Length - 4), FolderName)

                                'Add to listview
                                objItem = ListViewRecherche.Items.Add(Strings.Left(fi.Name, fi.Name.Length - 4))
                                With objItem
                                    .SubItems.Add(ConvertNote(note))
                                    .SubItems.Add(Description)
                                    .SubItems.Add(FolderName)
                                    .SubItems.Add(Position.ToString)
                                    .SubItems.Add(RechercheTexte)
                                    .ImageIndex = imgidx
                                End With
                                RecetteTotalCount += 1
                                imgidx += 1
                                Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "18") & RecetteTotalCount & LangINI.GetKeyValue("Popotte - BooksDialog", "19")
                            End If
                            'Goto jump
FileFound:
                        End If
                    Next
                Next
            End If
            Me.Cursor = Cursors.Arrow
            Me.ListViewRecettes.Visible = False
            Me.ListViewRecherche.Visible = True
            Me.RevenirButton.Enabled = True
            ListViewRecherche.Focus()
            If RecetteTotalCount = 0 Then
                MsgBox(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "2"), MsgBoxStyle.Exclamation, "Popotte")
            End If
        End If
        ListViewRecherche.Focus()
        GC.Collect()
    End Sub

    'Bouton Favorites
    Private Sub ButtonFav_Click(sender As Object, e As EventArgs) Handles ButtonFav.Click
        imageListSmallRecette.Images.Clear()
        ListViewRecherche.Items.Clear()
        ListViewRecettes.Visible = False
        ListViewRecherche.Visible = True
        Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "20")

        Dim RecetteTotalCount As Integer = 0
        Dim objItem As ListViewItem
        Dim imgidx As Integer = 0
        Fav = True
        RevenirButton.Enabled = True

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites", True)
        If regKey IsNot Nothing Then
            For Each subKeyName As String In regKey.GetSubKeyNames()

                RecetteTotalCount += 1
                Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "20") & " - (" & RecetteTotalCount.ToString & ")"

                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & subKeyName, True)
                Dim Livre As String = regKey.GetValue("Livre").ToString

                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & Livre & "\" & subKeyName, True)
                If regKey IsNot Nothing Then
                    Dim note As Integer = CType(regKey.GetValue("Note"), Integer)
                    Dim description As String = regKey.GetValue("Description").ToString
                    AddImageToImagelist(subKeyName, Livre)
                    'Add to listview
                    objItem = ListViewRecherche.Items.Add(subKeyName)
                    With objItem
                        .SubItems.Add(ConvertNote(note))
                        .SubItems.Add(description)
                        .SubItems.Add(Livre)
                        .ImageIndex = imgidx
                    End With
                    imgidx += 1
                Else
                    AddImageToImagelist(subKeyName, Livre)
                    'Add to listview
                    objItem = ListViewRecherche.Items.Add(subKeyName)
                    With objItem
                        .SubItems.Add("")
                        .SubItems.Add("")
                        .SubItems.Add(Livre)
                        .ImageIndex = imgidx
                    End With
                    imgidx += 1
                End If
            Next
        End If

    End Sub

    Private Sub ButtonRandom_Click(sender As Object, e As EventArgs) Handles ButtonRandom.Click
        If (Directory.Exists(PopotteDir)) Then
            Dim tmpList As New List(Of String)
            Dim count As Integer = 0
            For Each Folder As String In My.Computer.FileSystem.GetDirectories(PopotteDir)
                'Retourne le nom du dossier
                Dim FolderName As String = Path.GetFileName(Folder)
                'set search parameters
                Dim di As New DirectoryInfo(PopotteDir & FolderName)
                Dim aryFi As FileInfo() = di.GetFiles("*.rtf")
                Dim fi As FileInfo


                For Each fi In aryFi
                    Dim Filename As String = Strings.LCase(fi.FullName)
                    'put file path into List
                    tmpList.Add(Filename)
                    count += 1
                Next
            Next

            If count > 0 Then
                Dim r As New Random()
                Dim resultInt As Integer = r.Next(0, count - 1)
                'Read file path from list at random index
                Dim Filepath As String = tmpList.Item(resultInt)
                Dim fn As String = Path.GetFileNameWithoutExtension(Filepath)
                'Get Book folder name
                Dim Livre As String = Path.GetDirectoryName(Filepath)
                Livre &= ".xxx"
                Livre = Path.GetFileNameWithoutExtension(Livre)

                Dim result As Integer = MessageBox.Show(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "11") & fn & Chr(13) & LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "12"), LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "13"), MessageBoxButtons.OKCancel)

                If result = DialogResult.OK Then
                    frmMain.rtbDoc.LoadFile(Filepath, RichTextBoxStreamType.RichText)
                    frmMain.Text = "Popotte - [" & fn & "]"
                    frmMain.GetCharFormat()
                    frmMain.rtbDoc.Modified = False
                    frmMain.LivreOuvert = Livre
                    frmMain.currentFile = Filepath
                    frmMain.RappelTimer.Stop()
                    frmMain.RappelTimer.Start()
                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
                    regKey.SetValue("DerRecette", Filepath)
                    regKey.SetValue("Livre", Livre)
                    regKey.SetValue("Recette", fn)
                    Me.Close()
                End If
            End If
        End If


    End Sub



#End Region

#Region "ContextMenu methods"


    Private Sub EnleverFavToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnleverFavToolStripMenuItem.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites", True)
        Dim NomRecette As String = ListViewRecherche.SelectedItems(0).Text
        regKey.DeleteSubKey(NomRecette)
        'remove item from list
        ListViewRecherche.FocusedItem.Remove()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & NomRecette, True)
        If regKey IsNot Nothing Then
            MessageBox.Show(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "7"), LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "8"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ChangerLeNomDuLivreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangerLeNomDuLivreToolStripMenuItem.Click
        Dim rdia As New RenommerLivreDialog(ListViewLivres.SelectedItems(0).Text)
        Dim dresult As Integer = rdia.ShowDialog()
        Select Case dresult
            Case DialogResult.OK
                GetLivres()
        End Select
    End Sub

    Private Sub EffaçerLeLivreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EffacerLeLivreToolStripMenuItem.Click
        DeleteLivre()
    End Sub

    Private Sub DeleteLivre()
        Dim answer As Integer = MessageBox.Show(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "3") & ListViewLivres.SelectedItems(0).Text & LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "4"), "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "1"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Select Case answer
            Case Windows.Forms.DialogResult.No
                Exit Sub
            Case Windows.Forms.DialogResult.Yes
                Dim NomLivre As String = ListViewLivres.SelectedItems(0).Text
                Dim path As String = PopotteDir & NomLivre
                'Send Folder to recycle bin
                If RecycleFolder(path) <> -1 Then
                    'Remove the key from registry
                    RemoveLivreKey(NomLivre)
                    'remove item from list using refresh
                    GetLivres()
                    If NomLivre = frmMain.LivreOuvert Then
                        frmMain.LivreOuvert = ""
                    End If
                End If
        End Select
    End Sub

    Private Sub RemoveLivreKey(ByVal NomLivre As String)
        Dim LivreRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)

        If LivreRegKey IsNot Nothing Then
            Dim subKeys As String() = LivreRegKey.GetSubKeyNames()
            If subKeys IsNot Nothing Then
                For Each subKeyName As String In subKeys
                    LivreRegKey.DeleteSubKey(subKeyName)
                    Dim FavRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & subKeyName, True)
                    If FavRegKey IsNot Nothing Then
                        FavRegKey.DeleteSubKey(subKeyName)
                    End If
                Next
                Dim SRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
                SRegKey.DeleteSubKey(NomLivre)
            End If
        End If
    End Sub

    Private Sub ModifierLesInfosDeLaRecetteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierLesInfosDeLaRecetteToolStripMenuItem.Click
        If ListViewRecettes.SelectedItems.Count > 1 Then
            Dim ModL As New dlgMultiModInfo(LastLivre, ListViewRecettes.SelectedItems)
            Dim dLresult As Integer = ModL.ShowDialog()
            If dLresult = DialogResult.OK Then
                If LastLivre <> "" Then
                    GetRecettes(PopotteDir & LastLivre)
                Else
                    GetRecettes(PopotteDir & frmMain.LivreOuvert)
                End If
            End If
        Else
            Dim ModR As New dlgInfoRecette(ListViewRecettes.SelectedItems(0).Text, LastLivre, False)
            Dim dresult As Integer = ModR.ShowDialog()
            Select Case dresult
                Case DialogResult.OK
                    If LastLivre <> "" Then
                        GetRecettes(PopotteDir & LastLivre)
                    Else
                        GetRecettes(PopotteDir & frmMain.LivreOuvert)
                    End If
            End Select
        End If
    End Sub

    Private Sub EffaçerLaRecetteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EffacerLaRecetteToolStripMenuItem.Click
        If ListViewRecettes.SelectedItems.Count = 1 Then
            DeleteRecette()
        End If
    End Sub

    Private Sub DeleteRecette()
        Dim answer As Integer = MessageBox.Show(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "5"), "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "1"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Select Case answer
            Case Windows.Forms.DialogResult.No
                Exit Sub
            Case Windows.Forms.DialogResult.Yes
                Dim path As String
                Dim NomRecette As String = ListViewRecettes.SelectedItems(0).Text
                If LastLivre <> "" Then
                    path = PopotteDir & LastLivre & "\" & NomRecette & ".rtf"
                Else
                    path = PopotteDir & frmMain.LivreOuvert & "\" & NomRecette & ".rtf"
                End If

                'Send Folder to recycle bin
                If RecycleFile(path) <> -1 Then
                    'remove item from list
                    ListViewRecettes.FocusedItem.Remove()

                    'Remove the key from registry
                    If LastLivre <> "" Then
                        RemoveRecetteKey(LastLivre, NomRecette)
                    Else
                        RemoveRecetteKey(frmMain.LivreOuvert, NomRecette)
                    End If

                    'Remove Fav Key
                    Dim FavRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & NomRecette, True)
                    If FavRegKey IsNot Nothing Then
                        FavRegKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\", True)
                        FavRegKey.DeleteSubKey(NomRecette)
                    End If

                    'recount item
                    Dim rcount As Integer = ListViewRecettes.Items.Count
                    If LastLivre <> "" Then
                        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "12") & " " & LastLivre & " (" & rcount & ")"
                    Else
                        Me.Text = "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog", "12") & " " & frmMain.LivreOuvert & " (" & rcount & ")"
                    End If
                End If
        End Select
    End Sub

    Private Sub RemoveRecetteKey(ByVal NomLivre As String, ByVal NomRecette As String)
        Dim RecetteRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre & "\" & NomRecette, True)
        If RecetteRegKey IsNot Nothing Then
            Dim SRegKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & NomLivre, True)
            SRegKey.DeleteSubKey(NomRecette)
        End If
    End Sub

    Private Sub NewBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewBookToolStripMenuItem.Click
        Dim NLdia As New NouveauLivreDialog()
        Dim dresult As Integer = NLdia.ShowDialog()
        Select Case dresult
            Case DialogResult.OK
                GetLivres()
        End Select
    End Sub

    Private Sub OuvrirAvecEditeurExterneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuvrirAvecEditeurExterneToolStripMenuItem.Click
        If ListViewRecettes.SelectedItems.Count = 1 Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\EditeurExt", True)
            Dim Editpath As String = regKey.GetValue("").ToString

            Dim NomRecette As String = ListViewRecettes.SelectedItems(0).Text
            Dim Argument As String
            If LastLivre <> "" Then
                Argument = PopotteDir & LastLivre & "\" & NomRecette & ".rtf"
            Else
                Argument = PopotteDir & frmMain.LivreOuvert & "\" & NomRecette & ".rtf"
            End If

            Argument = Chr(34) & Argument & Chr(34)

            Try
                Process.Start(Editpath, Argument)
            Catch ex As Exception
                MessageBox.Show(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "6") & " " & ex.ToString, "Popotte - " & LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
            End Try
        End If
    End Sub


    Private Sub ToolStripMenuItemFAV_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFAV.Click
        If ListViewRecettes.SelectedItems.Count = 1 Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites", True)
            If regKey Is Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                regKey.CreateSubKey("Favorites")
            End If
            Dim NomRecette As String = ListViewRecettes.SelectedItems(0).Text
            Dim Livre As String
            If LastLivre <> "" Then
                Livre = LastLivre
            Else
                Livre = frmMain.LivreOuvert
            End If

            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & NomRecette, True)

            If regKey Is Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites", True)
                regKey.CreateSubKey(NomRecette.Trim)
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & NomRecette, True)
                regKey.SetValue("Livre", Livre)
                MessageBox.Show(Me, LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "9"), LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "8"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "10"), LangINI.GetKeyValue("Popotte - BooksDialog - MessageBox", "8"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub



#End Region


End Class
