Imports System.Drawing.Text
Imports Microsoft.Win32
Imports System.Text
Imports System.IO
Imports System.ComponentModel
Imports System.Threading
Imports System.Globalization
Imports ExtendedRichTextBox.AdvRichTextBoxPrintCtrl

''' <summary>
''' Popotte 5.4.0.99
''' 1 mars 2016 au 8 Novembre 2022
''' Work on Windows 7 sp1, windows 8, Windows 8.1, Windows 10, Windows 11  Need .Net Framework 4.8
''' Copyright Martin Laflamme 2003/2023
''' Read licence.txt
''' </summary>
''' 
''' ////////// Changes Logs ///////////////////////
''' ////////// English //////////////////////
''' Optimized ram usage
''' Use .NET Framework 4.8 now
''' Show images in the list checkbox in Books Dialog
''' Fix some errors and minor bugs
''' ////////// Francais /////////////////////
''' Optimisé l'usage de la ram
''' Utilise le .NET framework 4.8 maintenant
''' Une case à cocher pour assicher les images de la liste dans le dialogue Mes Livres de Recette
''' Réparé quelques erreurs et bogues mineurs


Public Class frmMain

    Public Shared Sub Main()
        ' Add the event handler.
        AddHandler Application.ThreadException,
        AddressOf CustomExceptionHandler.OnThreadException
    End Sub


#Region "Declarations"

    Private checkPrint As Integer
    Private DefaultFontName As String = "Calibri"
    Private DefaultFontSize As Integer = 16
    Private DefaultFontColor As Color = Color.Black
    Private HighlightColor As Color = Color.Yellow
    Private DefaultFontEffect As String
    Private FontLoaded As Boolean = False
    Private GCF As Boolean = False  'use to fix bug

    Private UserName As String = Environment.UserName
    Private demarrage As Boolean 'is the application starting up
    Private FileAssoValue As Boolean = False
    Private firststart As Boolean = True
    Private restart As Boolean = False

    Public regKey As RegistryKey
    Public PopotteDir As String = "c:\users\" & UserName & "\Popotte\"  'default recipe dir
    Public LivreOuvert As String = ""  ' Le Livre qui est ouvert
    Public FindFormOpen As Boolean = False
    Public FindReplaceFormOpen As Boolean = False
    Public ImageRecette As Boolean = True  'Option image dans la liste des recette
    Public DPI As Integer = 0
    Public LangIni As New IniFile
    Public currentFile As String  ' le fichier ouvert
    Public Language As String

#End Region



#Region "Form Methods"
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CreateRegKey()

        FaireMiseaJour()

        'Get Windows DPI
        DPI = CInt(CreateGraphics.DpiX)

        'Get Windows Language ISO 3 letter code DEFAULT = English
        Dim SystemLang As String = CultureInfo.CurrentCulture.ThreeLetterISOLanguageName
        Select Case SystemLang
            Case "fre", "fra"
                SystemLang = "Francais"
            Case "eng"
                SystemLang = "English"
            Case Else
                SystemLang = "English" 'default
        End Select
        Language = SystemLang

        'Get language from registry
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Language", True)
        If regKey IsNot Nothing Then
            Language = regKey.GetValue("", "").ToString
            If Language <> "" Then
                'load Language ini
                Dim inifilen As String = Application.StartupPath & "\Languages\" & Language & ".ini"
                Dim isINIloaded As Boolean = LangIni.Load(inifilen)
                If Not isINIloaded Then
                    MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - MessageBox", "35"), "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - MessageBox", "36"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
            End If
        Else 'no language key found (First Start)
            If Language <> "" Then
                'load Language ini
                Dim inifilen As String = Application.StartupPath & "\Languages\" & Language & ".ini"
                Dim isINIloaded As Boolean = LangIni.Load(inifilen)
                If Not isINIloaded Then
                    MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - MessageBox", "35"), "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - MessageBox", "36"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
            End If
        End If

        'Setting language
        'Menu
        FileToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "1")
        EditToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "2")
        FontToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "3")
        SpecialToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "4")
        OutilsToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "5")
        OptionsToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "6")
        AideToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "7")

        'Menu Fichier
        ToolStripMenuItemLivres.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "8")
        NewToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "9")
        OpenToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "10")
        SaveToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "11")
        SaveAsANSIToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "12") & " ANSI"
        SaveAsUNICODEToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "12") & " UNICODE"
        mnuPageSetup.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "13")
        PreviewToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "14")
        PrintToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "15")
        ExitToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "16")

        'Menu Éditer
        mnuUndo.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "17")
        mnuRedo.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "18")
        FindToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "19")
        FindAndReplaceToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "20")
        SelectAllToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "21")
        CopyToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "22")
        CutToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "23")
        PasteToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "24")
        InsertImageToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "25")
        InsertlocalfileToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "26")
        CouleurDeSurbrillanceToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "96")
        SurlignerLaSélectionToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "97")
        AnnulerLaSurbrillanceToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "98")
        AutoCeditToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "100")

        'Menu Polices
        SelectFontToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "27")
        BoldToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "28")
        ItalicToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "29")
        UnderlineToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "30")
        NormalToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "31")

        'Menu Carateres speciaux
        DateToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "32")
        ListeToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "33")
        DegreToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "34")
        QuartToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "35")
        DemiToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "36")
        Quart3ToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "37")
        TableDesCharactèresToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "38")
        CourteToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "39")
        LongueToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "40")
        CourteHeureToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "41")
        LongueHeureToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "42")
        AddBulletsToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "43")
        RemoveBulletsToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "44")

        'Menu Paragraphe
        ParagrapheToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "69")
        ÉchancrureToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "70")
        PositionToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "71")
        AucunToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "72")
        TexteÀGaucheToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "73")
        TexteCentréToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "74")
        TexteÀDroiteToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "75")
        MargeDToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "88")
        CMToolStripMenuItem8.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "72")
        TexteJustifiéToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "89")

        'Menu Outils
        ConvertisseurToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "45")
        ResearchCenter__ToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "46")
        CrypterToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "47")
        ToolStripMenuItemArchiverLesRecettes.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "48")
        SaveBD_ToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "49")
        OuvrirLeRépertoireDesRecettesToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "50")
        ToolStripMenuItemMenu.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "102")

        'Menu Options
        AffichageToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "51")
        ÉditeurExterneParDéfautToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "52")
        DossierRecetteToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "53")
        OuvrirMesLivresAuDémarrageToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "54")
        OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "55")
        VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "56")
        BarDoutilsToolStripMenuItem1.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "57")
        DMLRToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "58")
        ToolStripMenuItemURL.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "59")
        LireSeulementToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "60")
        NavigationToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "61")
        TexteToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "62")
        AfficherLesImagesDesRecettesDansLaListeToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "63")
        LanguageToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "77")
        ToolStripMenuItemOnedrive.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "93")
        ToolStripMenuItemDropbox.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "94")
        OptRTFToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "95")
        AutoCToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "101")

        'Menu Aide
        AidesToolStripMenuItem1.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "64")
        ToolStripMenuItemSiteWeb.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "65")
        UpdateToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "67")
        AproposToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "68")

        'Toolbar Tooltips
        ToolStripButtonLivres.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "1")
        ToolStripButtonNRecette.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "2")
        ToolStripButtonOuvrir.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "3")
        ToolStripButtonSave.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "4")
        ToolStripButtonImage.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "5")
        FileLinkToolStripButton.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "6")
        ToolStripButtonCut.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "7")
        ToolStripButtonCopy.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "8")
        ToolStripButtonPaste.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "9")
        ToolStripButtonPrint.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "10")
        ToolStripComboBoxPolices.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "11")
        ToolStripComboBoxSize.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "12")
        ToolStripButtonCouleurs.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "13")
        ToolStripButtonBold.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "14")
        ToolStripButtonItalic.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "15")
        ToolStripButtonUnderline.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "16")
        ToolStripButtonGauche.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "17")
        ToolStripButtonCentre.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "18")
        ToolStripButtonDroite.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "19")
        PageUpToolStripButton.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "20")
        JustifyToolStripButton.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "21")
        ToolStripButtonBulletList.ToolTipText = LangIni.GetKeyValue("Popotte - ToolBar Tooltips", "22")

        'Rich Text Box Context Menu
        ToolStripMenuItemToutSel.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "1")
        ToolStripMenuItemImage.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "2")
        InsertlocalfileContextToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "3")
        ResearchCenter_ContextMenuItem.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "4")
        CopierToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "5")
        CouperToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "6")
        CollerToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - ContextMenu", "7")
        SurlignerToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "97")
        AnnulerSurbrillanceToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "98")
        AutoCcontextToolStripMenuItem.Text = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "100")


        'Vérifier si la form a été redimensionner
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\WinSize", True)
        If regKey IsNot Nothing Then
            If CBool(regKey.GetValue("Maximized", False)) Then
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.Size = New Size(CInt(regKey.GetValue("Width", "800")), CInt(regKey.GetValue("Height", "602")))
            End If
        Else
            Me.Size = New Size(800, 602)
        End If

        CenterToScreen()

        'les boutons de sauvegarde sont déactivé tant que le texte n'est pas modifié
        ToolStripButtonSave.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        SaveAsANSIToolStripMenuItem.Enabled = False
        SaveAsUNICODEToolStripMenuItem.Enabled = False

        'Charge les engins de recherche
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche", True)
        If regKey IsNot Nothing Then
            Dim valuename As String() = regKey.GetValueNames()
            System.Array.Sort(Of String)(valuename) 'classe les noms des engins de recherche par ordre alphabétique
            For Each items As String In valuename
                Dim item1 As New ToolStripMenuItem
                item1.Text = items
                ResearchCenter_ContextMenuItem.DropDownItems.Add(item1)
            Next
        End If
        'Add Click Event handler for each link 
        For Each C As ToolStripMenuItem In ResearchCenter_ContextMenuItem.DropDownItems
            AddHandler C.Click, AddressOf ToolStripMenuItem_Click
        Next

        'Chargement de la police par default
        ToolStripComboBoxPolices.ComboBox.DrawMode = DrawMode.OwnerDrawVariable
        ToolStripComboBoxPolices.DropDownHeight = 268
        AddHandler ToolStripComboBoxPolices.ComboBox.DrawItem, AddressOf ToolStripComboBoxPolices_DrawItem
        AddHandler ToolStripComboBoxPolices.ComboBox.MeasureItem, AddressOf ToolStripComboBoxPolices_MeasureItem
        GetFont()
        GetSize()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DefaultFont", True)
        If regKey IsNot Nothing Then
            DefaultFontName = CType(regKey.GetValue("Fontname", "Calibri"), String)
            DefaultFontSize = CInt(regKey.GetValue("Size", 16))
        End If
        SetDefaultFont()
        FontLoaded = True

        'Set default alignment
        ToolStripButtonGauche.Checked = True
        TexteÀGaucheToolStripMenuItem.Checked = True

        'Get and set indent
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey IsNot Nothing Then
            rtbDoc.SelectionIndent = CInt(regKey.GetValue("", 0))
            Select Case regKey.GetValue("", 0)
                Case 0
                    AucunToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 14.173228346
                    APtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 28.346456693
                    BPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 42.519685039
                    CPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 56.692913386
                    DPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 70.866141732
                    EPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 85.039370079
                    FPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 99.212598425
                    GPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 113.385826772
                    HPtsToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
            End Select
        Else
            AucunToolStripMenuItem.Checked = True
            APtsToolStripMenuItem.Checked = False
            BPtsToolStripMenuItem.Checked = False
            CPtsToolStripMenuItem.Checked = False
            DPtsToolStripMenuItem.Checked = False
            EPtsToolStripMenuItem.Checked = False
            FPtsToolStripMenuItem.Checked = False
            GPtsToolStripMenuItem.Checked = False
            HPtsToolStripMenuItem.Checked = False
            rtbDoc.SelectionIndent = 0
        End If
        rtbDoc.Modified = False

        'MargeDroite
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey IsNot Nothing Then
            Dim MargeDroite As Integer
            MargeDroite = CInt(regKey.GetValue("", 8)) 'defaut aucun
            Select Case MargeDroite
                Case 0
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 14.173228346)
                    CmToolStripMenuItem.Checked = True
                Case 1
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 28.346456693)
                    CmToolStripMenuItem1.Checked = True
                Case 2
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 42.519685039)
                    CmToolStripMenuItem2.Checked = True
                Case 3
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 56.692913386)
                    CmToolStripMenuItem3.Checked = True
                Case 4
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 70.866141732)
                    CmToolStripMenuItem4.Checked = True
                Case 5
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 85.039370079)
                    CmToolStripMenuItem5.Checked = True
                Case 6
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 99.212598425)
                    CmToolStripMenuItem6.Checked = True
                Case 7
                    rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 113.385826772)
                    CmToolStripMenuItem7.Checked = True
                Case 8
                    rtbDoc.RightMargin = rtbDoc.Width - 30
                    CMToolStripMenuItem8.Checked = True
            End Select
        Else
            rtbDoc.RightMargin = rtbDoc.Width - 30
            CMToolStripMenuItem8.Checked = True
        End If


        'Detection des URL
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\UrlDetect", True)
        Dim URLDetect As Integer
        If regKey IsNot Nothing Then
            URLDetect = CInt(regKey.GetValue("check", 1))
        Else
            URLDetect = 1
        End If

        If URLDetect = 1 Then
            ToolStripMenuItemURL.Checked = True
            rtbDoc.DetectUrls = True
        Else
            ToolStripMenuItemURL.Checked = False
            rtbDoc.DetectUrls = False
        End If

        'Toolbars
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Toolbars", True)
        Dim TextTool As Integer
        Dim NavTool As Integer
        If regKey IsNot Nothing Then
            TextTool = CInt(regKey.GetValue("TexteCheck", 1))
            NavTool = CInt(regKey.GetValue("NavigationCheck", 1))
        Else
            TextTool = 1
            NavTool = 1
        End If

        If TextTool = 1 Then
            If NavTool = 0 Then
                ToolStrip1.Visible = True
                ToolStrip2.Visible = False
                rtbDoc.Top = 91 - 40
                rtbDoc.Height = rtbDoc.Height + 37
                TexteToolStripMenuItem.Checked = True
                NavigationToolStripMenuItem.Checked = False
            Else
                ToolStrip1.Visible = True
                ToolStrip2.Visible = True
                rtbDoc.Top = 91
                TexteToolStripMenuItem.Checked = True
                NavigationToolStripMenuItem.Checked = True
            End If
        Else
            If NavTool = 0 Then
                ToolStrip1.Visible = False
                ToolStrip2.Visible = False
                rtbDoc.Top = 91 - 68
                rtbDoc.Height = rtbDoc.Height + 68
                TexteToolStripMenuItem.Checked = False
                NavigationToolStripMenuItem.Checked = False
            Else
                ToolStrip1.Visible = False
                ToolStrip2.Visible = True
                rtbDoc.Top = 91 - 28
                rtbDoc.Height = rtbDoc.Height + 28
                TexteToolStripMenuItem.Checked = False
                NavigationToolStripMenuItem.Checked = True
            End If
        End If

        'Lire seulement
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LireSeulement", True)
        Dim LireSeul As Integer
        If regKey IsNot Nothing Then
            LireSeul = CInt(regKey.GetValue("check", 0))
        Else
            LireSeul = 0
        End If

        If LireSeul = 1 Then
            LireSeulementToolStripMenuItem.Checked = True
            DisableControl()
            rtbDoc.ReadOnly = True
        Else
            LireSeulementToolStripMenuItem.Checked = False
            rtbDoc.ReadOnly = False
        End If

        'Afficher les images dans la liste du dialogue mes livres de recettes
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\ImageRecette", True)
        If regKey IsNot Nothing Then
            ImageRecette = CBool(regKey.GetValue("", True))
            AfficherLesImagesDesRecettesDansLaListeToolStripMenuItem.Checked = ImageRecette
        Else
            ImageRecette = True
            AfficherLesImagesDesRecettesDansLaListeToolStripMenuItem.Checked = ImageRecette
        End If

        'Options de dossier de sauvegarde
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
        If regKey IsNot Nothing Then
            Dim DossierOpt As Integer = CInt(regKey.GetValue("FolderOpt", 3))
            Select Case DossierOpt
                Case 1
                    ToolStripMenuItemOnedrive.Checked = True
                Case 2
                    ToolStripMenuItemDropbox.Checked = True
                Case 3
                    DossierRecetteToolStripMenuItem.Checked = True
            End Select
        End If

        'look if file associations is set or not
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\FileAsso", True)
        If regKey IsNot Nothing Then
            FileAssoValue = CBool(regKey.GetValue("", False))
        End If

        If FileAssoValue Then
            Dim rtfvalue As String = ""
            regKey = Registry.CurrentUser.OpenSubKey("Software\Classes\.rtf", True)
            If regKey IsNot Nothing Then
                rtfvalue = CType(regKey.GetValue("", ""), String)
                If rtfvalue = "Popotte" Then
                    OptRTFToolStripMenuItem.Checked = True
                Else
                    OptRTFToolStripMenuItem.Checked = False
                End If
            Else
                OptRTFToolStripMenuItem.Checked = False
            End If
        Else
            OptRTFToolStripMenuItem.Checked = False
        End If

        'HighLightColor
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\HLColor", True)
        If regKey IsNot Nothing Then
            HighlightColor = ColorFromData(CType(regKey.GetValue(""), String))
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\AutoCExt", True)
        If regKey Is Nothing Then
            AutoCeditToolStripMenuItem.Enabled = False
            AutoCcontextToolStripMenuItem.Enabled = False
        End If

    End Sub


    'Create startup registry key
    Private Sub CreateRegKey()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software", True)
            regKey.CreateSubKey("Popotte")
        End If
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte", True)
            regKey.CreateSubKey("Settings")
        End If
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
        If Not regKey Is Nothing Then
            regKey.CreateSubKey("DerRecette")
            regKey.CreateSubKey("LivreDem")
            regKey.CreateSubKey("Menu")
        End If
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte", True)
            regKey.CreateSubKey("Livres")
        End If
    End Sub

    'Do update if necessary
    Private Sub FaireMiseaJour()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Version", True)
        If regKey Is Nothing Then
            'do update here
            'update is done
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey.CreateSubKey("Version")
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Version", True)
        End If
        regKey.SetValue("", My.Application.Info.Version)
    End Sub

    'Handler for context search
    Private Sub ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Quand un engins de recherche est sélectionné dans le context menu
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche", True)
        If regKey IsNot Nothing Then
            Dim Link As String = CType(regKey.GetValue(sender.ToString, ""), String)
            Dim Word As String = rtbDoc.SelectedText
            If Word <> "" Then
                Dim Position As Integer = InStr(Link, ";in;")
                If Position <> 0 Then
                    Link = Microsoft.VisualBasic.Left(Link, Position - 1) & Word & Mid(Link, Position + Len(";in;"))
                    Process.Start(Link)
                Else
                    MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "1"), "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "3"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            Else
                MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "2"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    'Ask to copy recipes examples at first installations
    Public Sub askforexamples()
        Dim answer As Integer = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "5"), "Popotte", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If answer = Windows.Forms.DialogResult.Yes Then
            CopyFolder(Application.StartupPath & "\exemples\Poutine", PopotteDir & "Poutine")
            CopyFolder(Application.StartupPath & "\exemples\Desserts", PopotteDir & "Desserts")
            CopyFolder(Application.StartupPath & "\exemples\Pâtes", PopotteDir & "Pâtes")
            CopyFolder(Application.StartupPath & "\exemples\Fruits de mer", PopotteDir & "Fruits de mer")
        End If
    End Sub

    'command line parsing
    Private Function ParseCommandLineArgs() As Integer
        For Each s As String In My.Application.CommandLineArgs
            If Path.GetExtension(s.ToLower) = ".rtf" Then
                rtbDoc.LoadFile(s, RichTextBoxStreamType.RichText)
                rtbDoc.Modified = False
                LivreOuvert = ""
                currentFile = s
                Me.Text = "Popotte - [" & s & "]"
                Return 1
            Else
                rtbDoc.LoadFile(s, RichTextBoxStreamType.PlainText)
                rtbDoc.Modified = False
                LivreOuvert = ""
                currentFile = s
                Me.Text = "Popotte - [" & s & "]"
                Return 1
            End If
            Return 0
        Next
        Return 0
    End Function


    Private Sub frmMain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        'Vérifier si un dossier a été sélectionné
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
        If regKey IsNot Nothing Then
            PopotteDir = CType(regKey.GetValue("", ""), String)
        Else
            Dim f As New dlgStartup
            f.ShowDialog(Me)
            f.Dispose()
        End If

        'Vérifier mise à jour
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\VerUpdate", True)
        Dim VerUpdate As Integer
        If regKey IsNot Nothing Then
            VerUpdate = CInt(regKey.GetValue("check", 1))
        Else
            VerUpdate = 1
        End If

        demarrage = True
        If VerUpdate = 1 Then
            VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem.Checked = True
            UpdateToolStripMenuItem_Click(Me, e)
        End If
        demarrage = False

        If ParseCommandLineArgs() <> 1 Then
            'Ouvrir mes livres au demarrage
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LivreDem", True)
            Dim LivreDem As Integer
            If regKey IsNot Nothing Then
                LivreDem = CInt(regKey.GetValue("check", 0))
            Else
                LivreDem = 0
            End If

            If LivreDem = 1 Then
                OuvrirMesLivresAuDémarrageToolStripMenuItem.Checked = True
                ToolStripMenuItemLivres_Click(Me, e)
            Else
                OuvrirMesLivresAuDémarrageToolStripMenuItem.Checked = False
            End If

            'Ouvrir la derniere recette au demarage
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            Dim DerRecette As Integer
            If regKey IsNot Nothing Then
                DerRecette = CInt(regKey.GetValue("check", 0))
            Else
                DerRecette = 0
            End If

            If DerRecette = 1 Then
                OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Checked = True
                Dim Recette As String = CType(regKey.GetValue("DerRecette", ""), String)
                Dim strExt As String
                strExt = Path.GetExtension(Recette)
                strExt = strExt.ToLower()

                Select Case strExt
                    Case ".rtf"
                        rtbDoc.LoadFile(Recette, RichTextBoxStreamType.RichText)
                        Me.Text = "Popotte - [" & Recette & "]"
                    Case Else
                        If is_unicode(Recette) = True Then
                            rtbDoc.Text = File.ReadAllText(Recette)
                            Me.Text = "Popotte - [" & Recette & "] - UNICODE"
                        Else
                            rtbDoc.LoadFile(Recette, RichTextBoxStreamType.PlainText)
                            Me.Text = "Popotte - [" & Recette & "] - ANSI"
                        End If
                End Select

                rtbDoc.Modified = False
                LivreOuvert = CType(regKey.GetValue("Livre", ""), String)
                currentFile = CType(regKey.GetValue("Recette", ""), String)
            Else
                OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Checked = False
            End If
        End If
    End Sub

    Private Sub GetFont()
        ' Get the installed fonts collection.
        Dim installed_fonts As New InstalledFontCollection

        ' Get an array of the system's font families.
        Dim font_families() As FontFamily = installed_fonts.Families()

        Dim Style As FontStyle

        ' Display the font families.
        For Each font_family As FontFamily In font_families
            Style = FontStyle.Regular
            'check if font as regular style
            If font_family.IsStyleAvailable(Style) Then
                If font_family.Name <> "" Then
                    Me.ToolStripComboBoxPolices.Items.Add(font_family.Name)
                End If
            End If
        Next font_family
    End Sub

    Private Sub GetSize()
        'get font size in combobox
        With Me
            ToolStripComboBoxSize.Items.Add("8")
            ToolStripComboBoxSize.Items.Add("9")
            ToolStripComboBoxSize.Items.Add("10")
            ToolStripComboBoxSize.Items.Add("11")
            ToolStripComboBoxSize.Items.Add("12")
            ToolStripComboBoxSize.Items.Add("14")
            ToolStripComboBoxSize.Items.Add("16")
            ToolStripComboBoxSize.Items.Add("18")
            ToolStripComboBoxSize.Items.Add("20")
            ToolStripComboBoxSize.Items.Add("22")
            ToolStripComboBoxSize.Items.Add("24")
            ToolStripComboBoxSize.Items.Add("26")
            ToolStripComboBoxSize.Items.Add("28")
            ToolStripComboBoxSize.Items.Add("36")
            ToolStripComboBoxSize.Items.Add("48")
            ToolStripComboBoxSize.Items.Add("72")
        End With
    End Sub

    Public Sub SetDefaultFont()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DefaultFont", True)
        If regKey IsNot Nothing Then
            DefaultFontEffect = CType(regKey.GetValue("Effects", "Standard"), String)
        Else
            DefaultFontEffect = "Standard"
        End If

        Select Case DefaultFontEffect
            Case "Bold"
                rtbDoc.SelectionFont = New Font(DefaultFontName, DefaultFontSize, FontStyle.Bold)
                ToolStripButtonBold.Checked = True
                ToolStripButtonItalic.Checked = False
                ToolStripButtonUnderline.Checked = False
                BoldToolStripMenuItem.Checked = True
                ItalicToolStripMenuItem.Checked = False
                UnderlineToolStripMenuItem.Checked = False
                NormalToolStripMenuItem.Checked = False
            Case "BoldItalic"
                rtbDoc.SelectionFont = New Font(DefaultFontName, DefaultFontSize, FontStyle.Bold Xor FontStyle.Italic)
                ToolStripButtonBold.Checked = True
                ToolStripButtonItalic.Checked = True
                ToolStripButtonUnderline.Checked = False
                BoldToolStripMenuItem.Checked = True
                ItalicToolStripMenuItem.Checked = True
                UnderlineToolStripMenuItem.Checked = False
                NormalToolStripMenuItem.Checked = False
            Case "Italic"
                rtbDoc.SelectionFont = New Font(DefaultFontName, DefaultFontSize, FontStyle.Italic)
                ToolStripButtonItalic.Checked = True
                ToolStripButtonBold.Checked = False
                ToolStripButtonUnderline.Checked = False
                BoldToolStripMenuItem.Checked = False
                ItalicToolStripMenuItem.Checked = True
                UnderlineToolStripMenuItem.Checked = False
                NormalToolStripMenuItem.Checked = False
            Case "Standard"
                rtbDoc.SelectionFont = New Font(DefaultFontName, DefaultFontSize, FontStyle.Regular)
                ToolStripButtonBold.Checked = False
                ToolStripButtonItalic.Checked = False
                ToolStripButtonUnderline.Checked = False
                BoldToolStripMenuItem.Checked = False
                ItalicToolStripMenuItem.Checked = False
                UnderlineToolStripMenuItem.Checked = False
                NormalToolStripMenuItem.Checked = True
        End Select

        Dim Index As Integer = ToolStripComboBoxPolices.FindStringExact(DefaultFontName)
        ToolStripComboBoxPolices.SelectedIndex = Index
        Dim Index2 As Integer = ToolStripComboBoxSize.FindStringExact(CStr(DefaultFontSize))
        ToolStripComboBoxSize.SelectedIndex = Index2
        rtbDoc.ForeColor = DefaultFontColor
        ToolStripButtonCouleurs.BackColor = DefaultFontColor

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not restart Then
            If CloseApp(e) = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Public Function CloseApp(ByVal e As EventArgs) As DialogResult
        If rtbDoc.Modified Then
            Dim answer As Integer = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "8"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            Select Case answer
                Case DialogResult.Yes
                    SaveToolStripMenuItem_Click(Me, e)
                    SaveSize()

                    If Not restart Then
                        End
                    End If
                Case DialogResult.No
                    SaveSize()

                    If Not restart Then
                        End
                    End If
                Case DialogResult.Cancel
                    Return DialogResult.Cancel
            End Select
        Else
            SaveSize()

            If Not restart Then
                End
            End If
        End If
    End Function

    Private Sub SaveSize()
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\WinSize", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("WinSize")
        End If
        If Me.WindowState = FormWindowState.Maximized Then
            regKey.SetValue("Maximized", True)
        ElseIf Me.WindowState = FormWindowState.Normal Then
            regKey.SetValue("Maximized", False)
            regKey.SetValue("Height", Me.Height)
            regKey.SetValue("Width", Me.Width)
        End If
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            'resize la marge dans rtbDoc
            Dim Size As Integer = 0
            If CmToolStripMenuItem.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 14.173228346)
            ElseIf CmToolStripMenuItem1.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 28.346456693)
            ElseIf CmToolStripMenuItem2.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 42.519685039)
            ElseIf CmToolStripMenuItem3.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 56.692913386)
            ElseIf CmToolStripMenuItem4.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 70.866141732)
            ElseIf CmToolStripMenuItem5.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 85.039370079)
            ElseIf CmToolStripMenuItem6.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 99.212598425)
            ElseIf CmToolStripMenuItem7.Checked Then
                Size = CInt(rtbDoc.Width - 30 - 113.385826772)
            ElseIf CMToolStripMenuItem8.Checked Then
                Size = rtbDoc.Width - 30
            End If
            If Size >= 0 Then
                rtbDoc.RightMargin = Size
            End If
        End If
    End Sub

    Private Sub rtbDoc_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbDoc.MouseUp
        GetCharFormat()
    End Sub

    Private Sub rtbDoc_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbDoc.SelectionChanged
        GetCharFormat()
    End Sub

    Private Sub rtbDoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtbDoc.KeyDown
        Select Case e.KeyCode
            Case Keys.Down, Keys.Left, Keys.Right, Keys.Up, Keys.Enter, Keys.Back
                GetCharFormat()
        End Select
    End Sub

    Public Sub GetCharFormat()
        If rtbDoc.SelectionFont IsNot Nothing Then
            Dim currentFont As System.Drawing.Font = rtbDoc.SelectionFont

            'if GetCharFormat() is running (Fix a bug)
            GCF = True
            ToolStripComboBoxPolices.SelectedItem = currentFont.Name
            ToolStripComboBoxSize.SelectedItem = CStr(Math.Round(currentFont.Size, 0))
            GCF = False

            If rtbDoc.SelectionColor <> Nothing Then
                ToolStripButtonCouleurs.BackColor = rtbDoc.SelectionColor
            End If

            If rtbDoc.SelectionFont.Bold Then
                ToolStripButtonBold.Checked = True
                NormalToolStripMenuItem.Checked = False
            Else
                ToolStripButtonBold.Checked = False
                NormalToolStripMenuItem.Checked = True
            End If
            If rtbDoc.SelectionFont.Italic Then
                ToolStripButtonItalic.Checked = True
                NormalToolStripMenuItem.Checked = False
            Else
                ToolStripButtonItalic.Checked = False
            End If
            If rtbDoc.SelectionFont.Underline Then
                ToolStripButtonUnderline.Checked = True
                NormalToolStripMenuItem.Checked = False
            Else
                ToolStripButtonUnderline.Checked = False
            End If


            If rtbDoc.SelectionAlignment = TextAlign.Left Then
                ToolStripButtonGauche.Checked = True
                TexteÀGaucheToolStripMenuItem.Checked = True
            Else
                ToolStripButtonGauche.Checked = False
                TexteÀGaucheToolStripMenuItem.Checked = False
            End If
            If rtbDoc.SelectionAlignment = TextAlign.Center Then
                ToolStripButtonCentre.Checked = True
                TexteCentréToolStripMenuItem.Checked = True
            Else
                ToolStripButtonCentre.Checked = False
                TexteCentréToolStripMenuItem.Checked = False
            End If
            If rtbDoc.SelectionAlignment = TextAlign.Right Then
                ToolStripButtonDroite.Checked = True
                TexteÀDroiteToolStripMenuItem.Checked = True
            Else
                ToolStripButtonDroite.Checked = False
                TexteÀDroiteToolStripMenuItem.Checked = False
            End If
            If rtbDoc.SelectionAlignment = TextAlign.Justify Then
                JustifyToolStripButton.Checked = True
                TexteJustifiéToolStripMenuItem.Checked = True
            Else
                JustifyToolStripButton.Checked = False
                TexteJustifiéToolStripMenuItem.Checked = False
            End If

            'marge gauche indentation
            Select Case rtbDoc.SelectionIndent
                Case 0
                    AucunToolStripMenuItem.Checked = True
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 14.173228346
                    APtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 28.346456693
                    BPtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 42.519685039
                    CPtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 56.692913386
                    DPtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 70.866141732
                    EPtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 85.039370079
                    FPtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 99.212598425
                    GPtsToolStripMenuItem.Checked = True
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = False
                Case 113.385826772
                    AucunToolStripMenuItem.Checked = False
                    APtsToolStripMenuItem.Checked = False
                    BPtsToolStripMenuItem.Checked = False
                    CPtsToolStripMenuItem.Checked = False
                    DPtsToolStripMenuItem.Checked = False
                    EPtsToolStripMenuItem.Checked = False
                    FPtsToolStripMenuItem.Checked = False
                    GPtsToolStripMenuItem.Checked = False
                    HPtsToolStripMenuItem.Checked = True
            End Select

            'if list selected
            If rtbDoc.SelectionList = True Then
                ToolStripButtonBulletList.Checked = True
                AddBulletsToolStripMenuItem.Checked = True
            Else
                ToolStripButtonBulletList.Checked = False
                AddBulletsToolStripMenuItem.Checked = False
            End If

        End If
    End Sub

    'Hyperlink clicked in RTB
    Private Sub rtbDoc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbDoc.LinkClicked
        Try
            Process.Start(e.LinkText)
        Catch ex As Win32Exception
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "9"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As FileNotFoundException
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "9"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub rtbDoc_ModifiedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbDoc.ModifiedChanged
        If rtbDoc.Modified Then
            ToolStripButtonSave.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            SaveAsANSIToolStripMenuItem.Enabled = True
            SaveAsUNICODEToolStripMenuItem.Enabled = True
        Else
            ToolStripButtonSave.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            SaveAsANSIToolStripMenuItem.Enabled = False
            SaveAsUNICODEToolStripMenuItem.Enabled = False
        End If
    End Sub

    'draw font list
    Private Sub ToolStripComboBoxPolices_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        If e.Index >= 0 Then
            Dim txt$ = ToolStripComboBoxPolices.Items(e.Index).ToString
            Dim fnt As Font = New Font(e.Font.Name, 12, FontStyle.Bold) 'Default = legible text

            'Selected line will draw in the default font
            'All others will draw in the individual line's named font
            If e.State And DrawItemState.ComboBoxEdit Then
                fnt = e.Font    'Combobox's edit text always draws in the box's own font

            ElseIf (e.State And DrawItemState.Selected) = 0 Then
                'If not the selected line, create a custom font
                'Try all permutations of regular/bold/italic/underline/strikeout
                'If it can't do any of them, you still have the default
                Dim ff As FontFamily = New FontFamily(txt)
                For tStyle As FontStyle = 0 To 15
                    If (ff.IsStyleAvailable(tStyle)) Then
                        fnt = New Font(ff.Name, 12, tStyle)
                        Exit For
                    End If
                Next
            End If

            'Draw the drop-down item - you could easily adapt this to display a font icon, etc
            e.DrawBackground()
            e.DrawFocusRectangle()
            e.Graphics.DrawString(txt, fnt, New SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y)
        End If
    End Sub

    Private Sub ToolStripComboBoxPolices_MeasureItem(ByVal sender As Object, ByVal e As MeasureItemEventArgs)
        e.ItemHeight = 30
    End Sub

#End Region



#Region "Menu Methods"


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

        If rtbDoc.Modified Then

            Dim answer As Integer = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "10"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            Select Case answer
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
                Case Windows.Forms.DialogResult.No
                    rtbDoc.Clear()
                    SetDefaultFont()
                    rtbDoc.Focus()
                Case Windows.Forms.DialogResult.Yes
                    SaveToolStripMenuItem_Click(Me, e)
                    rtbDoc.Clear()
                    SetDefaultFont()
                    rtbDoc.Focus()
            End Select

        Else

            rtbDoc.Clear()
            SetDefaultFont()
            rtbDoc.Focus()

        End If

        currentFile = ""
        Me.Text = "Popotte"
        LivreOuvert = ""
        rtbDoc.SelectionAlignment = TextAlign.Left
        ToolStripButtonGauche.Checked = True
        ToolStripButtonCentre.Checked = False
        ToolStripButtonDroite.Checked = False
        TexteÀGaucheToolStripMenuItem.Checked = True
        TexteCentréToolStripMenuItem.Checked = False
        TexteÀDroiteToolStripMenuItem.Checked = False
        rtbDoc.Modified = False

    End Sub


    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        If rtbDoc.Modified Then

            Dim answer As Integer = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "11"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Select Case answer
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
                Case Windows.Forms.DialogResult.No
                    OpenFile()
                Case Windows.Forms.DialogResult.Yes
                    SaveToolStripMenuItem_Click(Me, e)
                    OpenFile()
            End Select

        Else

            OpenFile()

        End If

    End Sub


    Private Sub OpenFile()

        OpenFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "78")
        OpenFileDialog1.DefaultExt = "rtf"
        OpenFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "79") & "|*.*|Rich Text|*.rtf|" & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "80") & "|*.txt"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()


        If OpenFileDialog1.FileName = Nothing Then Exit Sub
        Dim strExt As String
        strExt = Path.GetExtension(OpenFileDialog1.FileName)
        strExt = strExt.ToLower()

        Select Case strExt
            Case ".rtf"
                rtbDoc.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.RichText)
                Me.Text = "Popotte - [" & OpenFileDialog1.FileName.ToString() & "]"

            Case Else
                If is_unicode(OpenFileDialog1.FileName) = True Then
                    rtbDoc.Clear()
                    SetDefaultFont()
                    rtbDoc.Text = File.ReadAllText(OpenFileDialog1.FileName)
                    Me.Text = "Popotte - [" & OpenFileDialog1.FileName.ToString() & "] - UNICODE"
                Else
                    rtbDoc.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                    Me.Text = "Popotte - [" & OpenFileDialog1.FileName.ToString() & "]"
                End If
        End Select

        currentFile = OpenFileDialog1.FileName
        OpenFileDialog1.FileName = Nothing
        rtbDoc.Modified = False
        LivreOuvert = ""
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
        regKey.SetValue("DerRecette", currentFile.ToString())
        regKey.SetValue("Livre", "")
        regKey.SetValue("Recette", "")
        OpenFileDialog1.Dispose()
    End Sub

    Private Function is_unicode(ByVal path As String) As Boolean
        Dim enc As System.Text.Encoding = Nothing
        Dim file As System.IO.FileStream = New System.IO.FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
        If file.CanSeek Then
            Dim bom As Byte() = New Byte(3) {} ' Get the byte-order mark, if there is one
            file.Read(bom, 0, 4)
            If (bom(0) = &HEF AndAlso bom(1) = &HBB AndAlso bom(2) = &HBF) OrElse (bom(0) = &HFF AndAlso bom(1) = &HFE) OrElse (bom(0) = &HFE AndAlso bom(1) = &HFF) OrElse (bom(0) = 0 AndAlso bom(1) = 0 AndAlso bom(2) = &HFE AndAlso bom(3) = &HFF) Then ' ucs-4
                Return True
            Else
                Return False
            End If

            ' Now reposition the file cursor back to the start of the file
            file.Seek(0, System.IO.SeekOrigin.Begin)
        Else
            Return False
        End If
    End Function

    Public Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
        Dim livre As String = CType(regKey.GetValue("Livre"), String)
        Dim recette As String = CType(regKey.GetValue("Recette"), String)
        If recette <> "" Then
            recette = Path.GetFileNameWithoutExtension(recette)
        End If

        If LivreOuvert = "" Then
            livre = ""
            recette = ""
        End If

        Dim SaveDialogue As New dlgInfoRecette(recette, livre, True)
        Dim result As DialogResult = SaveDialogue.ShowDialog()
        If result = DialogResult.OK Then
        End If
        SaveDialogue.Dispose()


    End Sub

    Private Sub SaveAsToolANSIStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsANSIToolStripMenuItem.Click

        SaveFileDialog1.Title = "Popotte - Sauvegarder sous... ANSI"
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = "Tout les fichiers|*.*|Rich Text|*.rtf|Texte|*.txt"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.ShowDialog()


        If SaveFileDialog1.FileName = "" Then Exit Sub

        Dim strExt As String
        strExt = Path.GetExtension(SaveFileDialog1.FileName)
        strExt = strExt.ToLower()

        Select Case strExt
            Case ".rtf"
                rtbDoc.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtWriter As StreamWriter
                'encode as ansi
                txtWriter = New StreamWriter(SaveFileDialog1.FileName, True, System.Text.Encoding.Default)
                txtWriter.Write(rtbDoc.Text)
                txtWriter.Close()
                txtWriter = Nothing
                txtWriter.Dispose()
                rtbDoc.SelectionStart = 0
                rtbDoc.SelectionLength = 0
        End Select

        currentFile = SaveFileDialog1.FileName
        rtbDoc.Modified = False
        Me.Text = "Popotte - [" & currentFile.ToString() & "]"
        SaveFileDialog1.Dispose()
    End Sub

    Private Sub SaveAsUNICODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsUNICODEToolStripMenuItem.Click
        SaveFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "85") & " UNICODE"
        SaveFileDialog1.DefaultExt = "txt"
        SaveFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "79") & "|*.*|Rich Text|*.rtf|" & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "80") & "|*.txt"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.ShowDialog()


        If SaveFileDialog1.FileName = "" Then Exit Sub

        Dim strExt As String
        strExt = Path.GetExtension(SaveFileDialog1.FileName)
        strExt = strExt.ToLower()

        Select Case strExt
            Case ".rtf"
                rtbDoc.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtWriter As StreamWriter
                'encode as Unicode
                txtWriter = New StreamWriter(SaveFileDialog1.FileName, True, System.Text.Encoding.Unicode)
                txtWriter.Write(rtbDoc.Text)
                txtWriter.Close()
                txtWriter = Nothing
                txtWriter.Dispose()
                rtbDoc.SelectionStart = 0
                rtbDoc.SelectionLength = 0
        End Select

        currentFile = SaveFileDialog1.FileName
        rtbDoc.Modified = False
        Me.Text = "Popotte - [" & currentFile.ToString() & "]"
        SaveFileDialog1.Dispose()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        CloseApp(e)
    End Sub


    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click

        rtbDoc.SelectAll()

    End Sub


    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        rtbDoc.Copy()
        Dim iData As IDataObject = Clipboard.GetDataObject()

        If iData.GetDataPresent(DataFormats.Text) Then
            Clipboard.SetText(rtbDoc.SelectedText.ToString())
        ElseIf iData.GetDataPresent(DataFormats.Rtf) Then
            rtbDoc.Copy()
        End If
    End Sub


    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        rtbDoc.Cut()
        Dim iData As IDataObject = Clipboard.GetDataObject()
        If iData.GetDataPresent(DataFormats.Text) Then
            If rtbDoc.SelectedText.ToString() <> "" Then
                Clipboard.SetText(rtbDoc.SelectedText.ToString())
            End If
        ElseIf iData.GetDataPresent(DataFormats.Rtf) Then
            rtbDoc.Cut()
        End If
    End Sub


    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'fix un bogue avec rtbDoc.Paste()
        ' Declares an IDataObject to hold the data returned from the clipboard.
        ' Retrieves the data from the clipboard.
        Dim iData As IDataObject = Clipboard.GetDataObject()

        If iData.GetDataPresent(DataFormats.Bitmap) Then

            Dim df As DataFormats.Format
            df = DataFormats.GetFormat(DataFormats.Bitmap)
            If Me.rtbDoc.CanPaste(df) Then
                Me.rtbDoc.Paste(df)
            End If

        ElseIf iData.GetDataPresent(DataFormats.Text) Then
            ' Yes it is, so display it in a text box.
            rtbDoc.SelectedText = CType(iData.GetData(DataFormats.Text), String)
        Else
            rtbDoc.Paste()
        End If
    End Sub


    Private Sub SelectFontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SelectFontToolStripMenuItem.Click
        Select Case DefaultFontEffect
            Case "Bold"
                FontDialog1.Font = New Font(DefaultFontName, DefaultFontSize, FontStyle.Bold)
            Case "BoldItalic"
                FontDialog1.Font = New Font(DefaultFontName, DefaultFontSize, FontStyle.Bold Xor FontStyle.Italic)
            Case "Italic"
                FontDialog1.Font = New Font(DefaultFontName, DefaultFontSize, FontStyle.Italic)
            Case "Standard"
                FontDialog1.Font = New Font(DefaultFontName, DefaultFontSize, FontStyle.Regular)
        End Select

        FontDialog1.ShowEffects = True
        FontDialog1.ShowApply = True

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DefaultFont", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("DefaultFont")
        End If

        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DefaultFontName = FontDialog1.Font.Name
            DefaultFontSize = CInt(FontDialog1.Font.Size)
            regKey.SetValue("Fontname", DefaultFontName)
            regKey.SetValue("Size", DefaultFontSize)
            Dim newFontStyle As System.Drawing.FontStyle = FontDialog1.Font.Style
            Select Case newFontStyle
                Case FontStyle.Bold
                    regKey.SetValue("Effects", "Bold")
                Case FontStyle.Bold Xor FontStyle.Italic
                    regKey.SetValue("Effects", "BoldItalic")
                Case FontStyle.Italic
                    regKey.SetValue("Effects", "Italic")
                Case FontStyle.Regular
                    regKey.SetValue("Effects", "Standard")
            End Select
            FontDialog1.Dispose()
        End If

    End Sub


    Private Sub BoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BoldToolStripMenuItem.Click

        If Not rtbDoc.SelectionFont Is Nothing Then
            If rtbDoc.SelectionFont.Bold Then
                ToolStripButtonBold.Checked = False
                BoldToolStripMenuItem.Checked = False
                If rtbDoc.SelectionFont.Italic = False And rtbDoc.SelectionFont.Underline = False Then
                    NormalToolStripMenuItem.Checked = True
                Else
                    NormalToolStripMenuItem.Checked = False
                End If
            Else
                ToolStripButtonBold.Checked = True
                BoldToolStripMenuItem.Checked = True
                NormalToolStripMenuItem.Checked = False
            End If

            SetStyles()
        End If

    End Sub


    Private Sub ItalicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ItalicToolStripMenuItem.Click

        If Not rtbDoc.SelectionFont Is Nothing Then
            If rtbDoc.SelectionFont.Italic Then
                ToolStripButtonItalic.Checked = False
                ItalicToolStripMenuItem.Checked = False
                If rtbDoc.SelectionFont.Bold = False And rtbDoc.SelectionFont.Underline = False Then
                    NormalToolStripMenuItem.Checked = True
                Else
                    NormalToolStripMenuItem.Checked = False
                End If
            Else
                ToolStripButtonItalic.Checked = True
                ItalicToolStripMenuItem.Checked = True
                NormalToolStripMenuItem.Checked = False
            End If

            SetStyles()
        End If

    End Sub


    Private Sub UnderlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles UnderlineToolStripMenuItem.Click

        If Not rtbDoc.SelectionFont Is Nothing Then
            If rtbDoc.SelectionFont.Underline Then
                ToolStripButtonUnderline.Checked = False
                UnderlineToolStripMenuItem.Checked = False
                If rtbDoc.SelectionFont.Italic = False And rtbDoc.SelectionFont.Bold = False Then
                    NormalToolStripMenuItem.Checked = True
                Else
                    NormalToolStripMenuItem.Checked = False
                End If
            Else
                ToolStripButtonUnderline.Checked = True
                UnderlineToolStripMenuItem.Checked = True
                NormalToolStripMenuItem.Checked = False
            End If

            SetStyles()
        End If

    End Sub

    Private Sub SetStyles()
        Dim currentFont As System.Drawing.Font = rtbDoc.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle

        If (ToolStripButtonBold.Checked = True) And (ToolStripButtonItalic.Checked = False) And (ToolStripButtonUnderline.Checked = False) Then
            newFontStyle = FontStyle.Bold
        ElseIf (ToolStripButtonBold.Checked = True) And (ToolStripButtonItalic.Checked = True) And (ToolStripButtonUnderline.Checked = False) Then
            newFontStyle = FontStyle.Bold + FontStyle.Italic
        ElseIf (ToolStripButtonBold.Checked = True) And (ToolStripButtonItalic.Checked = True) And (ToolStripButtonUnderline.Checked = True) Then
            newFontStyle = FontStyle.Bold + FontStyle.Italic + FontStyle.Underline
        ElseIf (ToolStripButtonBold.Checked = False) And (ToolStripButtonItalic.Checked = True) And (ToolStripButtonUnderline.Checked = True) Then
            newFontStyle = FontStyle.Italic + FontStyle.Underline
        ElseIf (ToolStripButtonBold.Checked = False) And (ToolStripButtonItalic.Checked = False) And (ToolStripButtonUnderline.Checked = True) Then
            newFontStyle = FontStyle.Underline
        ElseIf (ToolStripButtonBold.Checked = False) And (ToolStripButtonItalic.Checked = False) And (ToolStripButtonUnderline.Checked = False) Then
            newFontStyle = FontStyle.Regular
        ElseIf (ToolStripButtonBold.Checked = False) And (ToolStripButtonItalic.Checked = True) And (ToolStripButtonUnderline.Checked = False) Then
            newFontStyle = FontStyle.Italic
        ElseIf (ToolStripButtonBold.Checked = True) And (ToolStripButtonItalic.Checked = False) And (ToolStripButtonUnderline.Checked = True) Then
            newFontStyle = FontStyle.Bold + FontStyle.Underline
        End If

        rtbDoc.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
    End Sub


    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NormalToolStripMenuItem.Click

        If Not rtbDoc.SelectionFont Is Nothing Then

            Dim currentFont As Font = rtbDoc.SelectionFont
            Dim newFontStyle As FontStyle
            newFontStyle = FontStyle.Regular
            ToolStripButtonBold.Checked = False
            ToolStripButtonItalic.Checked = False
            ToolStripButtonUnderline.Checked = False
            BoldToolStripMenuItem.Checked = False
            ItalicToolStripMenuItem.Checked = False
            UnderlineToolStripMenuItem.Checked = False
            NormalToolStripMenuItem.Checked = True
            rtbDoc.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        End If

    End Sub


    Private Sub mnuUndo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuUndo.Click

        If rtbDoc.CanUndo Then rtbDoc.Undo()

    End Sub


    Private Sub mnuRedo_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuRedo.Click

        If rtbDoc.CanRedo Then rtbDoc.Redo()

    End Sub


    Private Sub AddBulletsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles AddBulletsToolStripMenuItem.Click
        If rtbDoc.SelectionList = True Then
            rtbDoc.SelectionList = False
        Else
            rtbDoc.BulletIndent = 10
            rtbDoc.ListFormat = ListFormats.Bullets
            rtbDoc.SelectionList = True
        End If
        rtbDoc.Focus()
        GetCharFormat()
    End Sub

    Private Sub BalleToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BalleToolStripMenuItem.Click
        If rtbDoc.SelectionList = True Then
            rtbDoc.SelectionList = False
        Else
            rtbDoc.BulletIndent = 10
            rtbDoc.ListFormat = ListFormats.Bullets
            rtbDoc.SelectionList = True
            BalleToolStripMenuItem.Checked = True
        End If
        rtbDoc.Focus()
        GetCharFormat()
    End Sub

    Private Sub NumériqueToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NumériqueToolStripMenuItem.Click
        If rtbDoc.SelectionList = True Then
            rtbDoc.SelectionList = False
        Else
            rtbDoc.BulletIndent = 10
            rtbDoc.ListFormat = ListFormats.Numbered
            rtbDoc.SelectionList = True
            NumériqueToolStripMenuItem.Checked = True
        End If
        rtbDoc.Focus()
        GetCharFormat()
    End Sub


    Private Sub RemoveBulletsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles RemoveBulletsToolStripMenuItem.Click

        rtbDoc.SelectionBullet = False

    End Sub


    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FindToolStripMenuItem.Click

        If FindFormOpen = False Then
            Dim f As New dlgFind()
            FindFormOpen = True
            f.Show()
        End If

    End Sub


    Private Sub FindAndReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FindAndReplaceToolStripMenuItem.Click

        If FindReplaceFormOpen = False Then
            Dim f As New dlgReplace()
            FindReplaceFormOpen = True
            f.Show()
        End If

    End Sub


    Private Sub PreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PreviewToolStripMenuItem.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()

    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PrintToolStripMenuItem.Click

        PrintDialog1.Document = PrintDocument1

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
            PrintPreviewDialog1.Dispose()
        End If

    End Sub


    Private Sub mnuPageSetup_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles mnuPageSetup.Click

        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.EnableMetric = True
        PageSetupDialog1.ShowDialog()
        PageSetupDialog1.Dispose()

    End Sub


    Private Sub InsertImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InsertImageToolStripMenuItem.Click

        OpenFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "81")
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        OpenFileDialog1.DefaultExt = "jpg"
        OpenFileDialog1.Filter = "PNGs (*.png), Bitmaps (*.bmp), GIFs (*.gif), JPEGs (*.jpg, *.jpeg)|*.bmp;*.gif;*.jpg;*.png;*.jpeg|PNGs (*.png)|*.png|Bitmaps (*.bmp)|*.bmp|GIFs (*.gif)|*.gif|JPEGs (*.jpg, *.jpeg)|*.jpg;*.jpeg"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.ShowDialog()


        If OpenFileDialog1.FileName = "" Then Exit Sub

        Try
            Dim strImagePath As String = OpenFileDialog1.FileName

            'backup clipboard
            Dim orgData As Object = Clipboard.GetDataObject

            Dim img As Image
            img = Image.FromFile(strImagePath)
            Clipboard.SetDataObject(img)
            Dim df As DataFormats.Format
            df = DataFormats.GetFormat(DataFormats.Bitmap)
            If Me.rtbDoc.CanPaste(df) Then
                Me.rtbDoc.Paste(df)
            End If

            'Restore clipboard
            Clipboard.SetDataObject(orgData)
        Catch ex As Exception
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "12") & " " & ex.ToString, LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
        End Try
        OpenFileDialog1.Dispose()
    End Sub


    Private Sub AproposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles AproposToolStripMenuItem.Click
        Dim Abb As New dlgAboutBox
        Abb.ShowDialog()
        Abb.Dispose()
    End Sub


    Private Sub DegreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DegreToolStripMenuItem.Click
        rtbDoc.SelectedText = "°"
    End Sub


    Private Sub QuartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles QuartToolStripMenuItem.Click
        rtbDoc.SelectedText = "¼"
    End Sub


    Private Sub DemiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DemiToolStripMenuItem.Click
        rtbDoc.SelectedText = "½"
    End Sub


    Private Sub Quart3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Quart3ToolStripMenuItem.Click
        rtbDoc.SelectedText = "¾"
    End Sub


    Private Sub TableDesCharactèresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles TableDesCharactèresToolStripMenuItem.Click
        Process.Start("charmap.exe")
    End Sub


    Private Sub OuvrirLeRépertoireDesRecettesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OuvrirLeRépertoireDesRecettesToolStripMenuItem.Click
        Process.Start(PopotteDir)
    End Sub

    Private Sub AucunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AucunToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 0
        AucunToolStripMenuItem.Checked = True
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 0)
    End Sub

    Private Sub APtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles APtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 14.173228346
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = True
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 14.173228346)
    End Sub

    Private Sub BPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 28.346456693
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = True
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 28.346456693)
    End Sub

    Private Sub CPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 42.519685039
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = True
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 42.519685039)
    End Sub

    Private Sub DPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 56.692913386
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = True
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 56.692913386)
    End Sub

    Private Sub EPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 70.866141732
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = True
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 70.866141732)
    End Sub

    Private Sub FPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 85.039370079
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = True
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 85.039370079)
    End Sub

    Private Sub GPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 99.212598425
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = True
        HPtsToolStripMenuItem.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 99.212598425)
    End Sub

    Private Sub HPtsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HPtsToolStripMenuItem.Click
        rtbDoc.SelectionIndent = 113.385826772
        AucunToolStripMenuItem.Checked = False
        APtsToolStripMenuItem.Checked = False
        BPtsToolStripMenuItem.Checked = False
        CPtsToolStripMenuItem.Checked = False
        DPtsToolStripMenuItem.Checked = False
        EPtsToolStripMenuItem.Checked = False
        FPtsToolStripMenuItem.Checked = False
        GPtsToolStripMenuItem.Checked = False
        HPtsToolStripMenuItem.Checked = True
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Indent")
        End If
        regKey.SetValue("", 113.385826772)
    End Sub


    Private Sub TexteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles TexteToolStripMenuItem.Click

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Toolbars", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Toolbars")
        End If

        If TexteToolStripMenuItem.Checked Then
            If NavigationToolStripMenuItem.Checked = False Then
                ToolStrip1.Visible = False
                rtbDoc.Top = 91 - 68
                rtbDoc.Height = rtbDoc.Height + 28
                TexteToolStripMenuItem.Checked = False
                regKey.SetValue("TexteCheck", 0)
            Else
                ToolStrip1.Visible = False
                rtbDoc.Top = 91 - 28
                rtbDoc.Height = rtbDoc.Height + 28
                TexteToolStripMenuItem.Checked = False
                regKey.SetValue("TexteCheck", 0)
            End If
        Else
            If NavigationToolStripMenuItem.Checked = False Then
                ToolStrip1.Visible = True
                rtbDoc.Top = 91 - 40
                rtbDoc.Height = rtbDoc.Height - 28
                TexteToolStripMenuItem.Checked = True
                regKey.SetValue("TexteCheck", 1)
            Else
                ToolStrip1.Visible = True
                rtbDoc.Top = 91
                rtbDoc.Height = rtbDoc.Height - 28
                TexteToolStripMenuItem.Checked = True
                regKey.SetValue("TexteCheck", 1)
            End If
        End If
    End Sub


    Private Sub NavigationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NavigationToolStripMenuItem.Click

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Toolbars", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("Toolbars")
        End If

        If NavigationToolStripMenuItem.Checked Then
            If TexteToolStripMenuItem.Checked = False Then
                ToolStrip2.Visible = False
                rtbDoc.Top = 91 - 68
                rtbDoc.Height = rtbDoc.Height + 40
                NavigationToolStripMenuItem.Checked = False
                regKey.SetValue("NavigationCheck", 0)
            Else
                ToolStrip2.Visible = False
                rtbDoc.Top = 91 - 40
                rtbDoc.Height = rtbDoc.Height + 40
                NavigationToolStripMenuItem.Checked = False
                regKey.SetValue("NavigationCheck", 0)
            End If
        Else
            If TexteToolStripMenuItem.Checked = False Then
                ToolStrip2.Visible = True
                rtbDoc.Top = 91 - 28
                rtbDoc.Height = rtbDoc.Height - 40
                NavigationToolStripMenuItem.Checked = True
                regKey.SetValue("NavigationCheck", 1)
            Else
                ToolStrip2.Visible = True
                rtbDoc.Top = 91
                rtbDoc.Height = rtbDoc.Height - 40
                NavigationToolStripMenuItem.Checked = True
                regKey.SetValue("NavigationCheck", 1)
            End If
        End If
    End Sub


    Private Sub LireSeulementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LireSeulementToolStripMenuItem.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LireSeulement", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("LireSeulement")
        End If

        If LireSeulementToolStripMenuItem.Checked = False Then
            DisableControl()
            rtbDoc.ReadOnly = True
            regKey.SetValue("check", 1)
            LireSeulementToolStripMenuItem.Checked = True
        Else
            EnableControl()
            rtbDoc.ReadOnly = False
            regKey.SetValue("check", 0)
            LireSeulementToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub DisableControl()
        NewToolStripMenuItem.Enabled = False
        ToolStripButtonNRecette.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ToolStripButtonSave.Enabled = False
        mnuUndo.Enabled = False
        mnuRedo.Enabled = False
        CutToolStripMenuItem.Enabled = False
        ToolStripButtonCut.Enabled = False
        PasteToolStripMenuItem.Enabled = False
        ToolStripButtonPaste.Enabled = False
        InsertImageToolStripMenuItem.Enabled = False
        ToolStripButtonImage.Enabled = False
        FindAndReplaceToolStripMenuItem.Enabled = False
        FontToolStripMenuItem.Enabled = False
        SpecialToolStripMenuItem.Enabled = False
        InsertlocalfileToolStripMenuItem.Enabled = False
        FileLinkToolStripButton.Enabled = False
        InsertlocalfileContextToolStripMenuItem.Enabled = False
        ToolStripComboBoxPolices.Enabled = False
        ToolStripComboBoxSize.Enabled = False
        ToolStripButtonCouleurs.Enabled = False
        ToolStripButtonBold.Enabled = False
        ToolStripButtonItalic.Enabled = False
        ToolStripButtonUnderline.Enabled = False
        ToolStripButtonCentre.Enabled = False
        ToolStripButtonDroite.Enabled = False
        ToolStripButtonGauche.Enabled = False
        ToolStripMenuItemImage.Enabled = False
        CouperToolStripMenuItem.Enabled = False
        CollerToolStripMenuItem.Enabled = False
        ParagrapheToolStripMenuItem.Enabled = False
        JustifyToolStripButton.Enabled = False
        ToolStripButtonBulletList.Enabled = False
    End Sub

    Private Sub EnableControl()
        NewToolStripMenuItem.Enabled = True
        ToolStripButtonNRecette.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        ToolStripButtonSave.Enabled = True
        mnuUndo.Enabled = True
        mnuRedo.Enabled = True
        CutToolStripMenuItem.Enabled = True
        ToolStripButtonCut.Enabled = True
        PasteToolStripMenuItem.Enabled = True
        ToolStripButtonPaste.Enabled = True
        InsertImageToolStripMenuItem.Enabled = True
        ToolStripButtonImage.Enabled = True
        FindAndReplaceToolStripMenuItem.Enabled = True
        FontToolStripMenuItem.Enabled = True
        SpecialToolStripMenuItem.Enabled = True
        InsertlocalfileToolStripMenuItem.Enabled = True
        FileLinkToolStripButton.Enabled = True
        InsertlocalfileContextToolStripMenuItem.Enabled = True
        ToolStripComboBoxPolices.Enabled = True
        ToolStripComboBoxSize.Enabled = True
        ToolStripButtonCouleurs.Enabled = True
        ToolStripButtonBold.Enabled = True
        ToolStripButtonItalic.Enabled = True
        ToolStripButtonUnderline.Enabled = True
        ToolStripButtonCentre.Enabled = True
        ToolStripButtonDroite.Enabled = True
        ToolStripButtonGauche.Enabled = True
        ToolStripMenuItemImage.Enabled = True
        CouperToolStripMenuItem.Enabled = True
        CollerToolStripMenuItem.Enabled = True
        ParagrapheToolStripMenuItem.Enabled = True
        JustifyToolStripButton.Enabled = True
        ToolStripButtonBulletList.Enabled = True
    End Sub


    Private Sub ToolStripMenuItemURL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripMenuItemURL.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\UrlDetect", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("UrlDetect")
        End If

        If ToolStripMenuItemURL.Checked = False Then
            rtbDoc.DetectUrls = True
            regKey.SetValue("check", 1)
            ToolStripMenuItemURL.Checked = True
            rtbDoc.Modified = False
        Else
            rtbDoc.DetectUrls = False
            regKey.SetValue("check", 0)
            ToolStripMenuItemURL.Checked = False
            rtbDoc.Modified = False
        End If
    End Sub


    Private Sub ToolStripMenuItemLivres_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripMenuItemLivres.Click
        Dim Livre As New dlgLivres
        If rtbDoc.Modified Then

            Dim answer As Integer
            answer = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "13"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

            Select Case answer
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
                Case Windows.Forms.DialogResult.No
                    Livre.ShowDialog()
                    Livre.Dispose()
                Case Windows.Forms.DialogResult.Yes
                    SaveToolStripMenuItem_Click(Me, e)
                    Livre.ShowDialog()
                    Livre.Dispose()
            End Select

        Else

            Livre.ShowDialog()
            Livre.Dispose()
        End If

    End Sub

    Private Sub OuvrirMesLivresAuDémarrageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OuvrirMesLivresAuDémarrageToolStripMenuItem.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LivreDem", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("LivreDem")
        End If

        If OuvrirMesLivresAuDémarrageToolStripMenuItem.Checked Then
            OuvrirMesLivresAuDémarrageToolStripMenuItem.Checked = False
            regKey.SetValue("check", 0)
        Else
            OuvrirMesLivresAuDémarrageToolStripMenuItem.Checked = True
            regKey.SetValue("check", 1)
            Dim regKey2 As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
            OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Checked = False
            regKey2.SetValue("check", 0)
        End If
    End Sub

    Private Sub OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\DerRecette", True)
        If OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Checked Then
            OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Checked = False
            regKey.SetValue("check", 0)
        Else
            OuvrirLaDernièrerecetteAuDémarrageToolStripMenuItem.Checked = True
            regKey.SetValue("check", 1)
            Dim regKey2 As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LivreDem", True)
            OuvrirMesLivresAuDémarrageToolStripMenuItem.Checked = False
            regKey2.SetValue("check", 0)
        End If
    End Sub

    Private Sub ConvertisseurToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles ConvertisseurToolStripMenuItem.Click
        Dim f As New dlgConverter()
        f.ShowDialog()
        f.Dispose()
    End Sub

    Public Sub DossierRecetteToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles DossierRecetteToolStripMenuItem.Click
        FolderBrowserDialog1.Description = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "90")
        FolderBrowserDialog1.SelectedPath = PopotteDir
        Dim dlgResult As DialogResult = FolderBrowserDialog1.ShowDialog()
        If dlgResult = DialogResult.OK Then
            PopotteDir = FolderBrowserDialog1.SelectedPath & "\"
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
            If regKey Is Nothing Then
                Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                regKey = newregKey.CreateSubKey("RecetteDir")
            End If
            regKey.SetValue("", PopotteDir)
            regKey.SetValue("FolderOpt", 3)
            ToolStripMenuItemOnedrive.Checked = False
            ToolStripMenuItemDropbox.Checked = False
            DossierRecetteToolStripMenuItem.Checked = True
        ElseIf dlgResult = DialogResult.Cancel Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
            If regKey Is Nothing Then
                Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                regKey = newregKey.CreateSubKey("RecetteDir")
                regKey.SetValue("", PopotteDir)
            End If
        End If
    End Sub

    Private Sub ResearchCenter__ToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles ResearchCenter__ToolStripMenuItem.Click
        Dim rc As New ResearchCenter
        rc.ShowDialog()
        rc.Dispose()
    End Sub

    Private Sub SaveBD_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveBD_ToolStripMenuItem.Click
        SaveFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "91")
        SaveFileDialog1.DefaultExt = "reg"
        SaveFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "92") & "|*.reg"
        SaveFileDialog1.FilterIndex = 1


        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            SaveFileDialog1.Dispose()
            Exit Sub
        End If


        '////////////////////////////////// Add Livres ///////////////////////////////////////////////////////

        Dim regKeyLivre As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres", True)
        Dim KeyLivreCount As Integer = regKeyLivre.SubKeyCount()
        If KeyLivreCount > 0 Then
            Dim sb As New StringBuilder()
            sb.AppendLine("Windows Registry Editor Version 5.00")
            sb.AppendLine()
            If regKeyLivre IsNot Nothing Then
                For Each KeyLivre As String In regKeyLivre.GetSubKeyNames()
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Livres\" & KeyLivre & "]")
                    sb.AppendLine()
                    Dim regKeyRecette As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & KeyLivre, True)
                    If regKeyRecette IsNot Nothing Then
                        Dim KeyRecetteCount As Integer = regKeyRecette.SubKeyCount()
                        If KeyRecetteCount > 0 Then
                            For Each KeyRecette As String In regKeyRecette.GetSubKeyNames()
                                Dim regKeyRecette2 As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Livres\" & KeyLivre & "\" & KeyRecette, True)
                                If regKeyRecette2 IsNot Nothing Then
                                    Dim description As String = CType(regKeyRecette2.GetValue("Description"), String)
                                    Dim note As String = CType(regKeyRecette2.GetValue("Note"), String)
                                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Livres\" & KeyLivre & "\" & KeyRecette & "]")
                                    sb.AppendLine(Chr(34) & "Description" & Chr(34) & "=" & Chr(34) & description & Chr(34))
                                    sb.AppendLine(Chr(34) & "Note" & Chr(34) & "=dword:" & note)
                                    sb.AppendLine()
                                End If
                            Next
                        End If
                    End If
                Next
            End If


            '////////////////////// Add settings /////////////////////////////////////////////////

            'Ajoute les favoris
            Dim regKeyFAV As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\", True)
            If regKeyFAV IsNot Nothing Then
                For Each subkeyname As String In regKeyFAV.GetSubKeyNames()
                    regKeyFAV = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Favorites\" & subkeyname, True)
                    Dim Livre As String = regKeyFAV.GetValue("Livre").ToString()
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\Favorites\" & subkeyname & "]")
                    sb.AppendLine(Chr(34) & "Livre" & Chr(34) & "=" & Chr(34) & Livre & Chr(34))
                    sb.AppendLine()
                Next
            End If

            'Ajoute les engins de recherche
            Dim regKeySearch As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\CentreRecherche\", True)
            If regKeySearch IsNot Nothing Then
                Dim ValueSearchCount As Integer = regKeySearch.ValueCount()
                If ValueSearchCount > 0 Then
                    For Each valueName As String In regKeySearch.GetValueNames()
                        Dim Command As String = regKeySearch.GetValue(valueName).ToString()
                        sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\CentreRecherche\" & "]")
                        sb.AppendLine(Chr(34) & valueName & Chr(34) & "=" & Chr(34) & Command & Chr(34))
                        sb.AppendLine()
                    Next
                End If
            End If

            'Lire seulement
            Dim regLireS As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LireSeulement\", True)
            If regLireS IsNot Nothing Then
                Dim ValueLireSCount As Integer = regLireS.ValueCount()
                If ValueLireSCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\LireSeulement\" & "]")
                    sb.AppendLine(Chr(34) & "check" & Chr(34) & "=dword:" & regLireS.GetValue("check").ToString())
                    sb.AppendLine()
                End If
            End If

            'Livre au démarrage
            Dim regLivreDem As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\LivreDem\", True)
            If regLivreDem IsNot Nothing Then
                Dim ValueLivreDemCount As Integer = regLivreDem.ValueCount()
                If ValueLivreDemCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\LivreDem\" & "]")
                    sb.AppendLine(Chr(34) & "check" & Chr(34) & "=dword:" & regLivreDem.GetValue("check").ToString())
                    sb.AppendLine()
                End If
            End If

            'Toolbar
            Dim regToolbars As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Toolbars\", True)
            If regToolbars IsNot Nothing Then
                Dim ValueToolbarsCount As Integer = regToolbars.ValueCount()
                If ValueToolbarsCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\Toolbars\" & "]")
                    sb.AppendLine(Chr(34) & "NavigationCheck" & Chr(34) & "=dword:" & regToolbars.GetValue("NavigationCheck").ToString())
                    sb.AppendLine(Chr(34) & "TexteCheck" & Chr(34) & "=dword:" & regToolbars.GetValue("TexteCheck").ToString())
                    sb.AppendLine()
                End If
            End If

            'Url Detect
            Dim regUrlDetect As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\UrlDetect\", True)
            If regUrlDetect IsNot Nothing Then
                Dim ValueUrlDetectCount As Integer = regUrlDetect.ValueCount()
                If ValueUrlDetectCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\UrlDetect\" & "]")
                    sb.AppendLine(Chr(34) & "check" & Chr(34) & "=dword:" & regUrlDetect.GetValue("check").ToString())
                    sb.AppendLine()
                End If
            End If

            'Check for update
            Dim regVerUpdate As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\VerUpdate\", True)
            If regVerUpdate IsNot Nothing Then
                Dim ValueVerUpdateCount As Integer = regVerUpdate.ValueCount()
                If ValueVerUpdateCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\VerUpdate\" & "]")
                    sb.AppendLine(Chr(34) & "check" & Chr(34) & "=dword:" & regVerUpdate.GetValue("check").ToString())
                    sb.AppendLine()
                End If
            End If

            'HighLight Color
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\HLColor\", True)
            If regKey IsNot Nothing Then
                Dim ValueCount As Integer = regKey.ValueCount()
                If ValueCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\HLColor\" & "]")
                    sb.AppendLine(CType(Chr(34) & "" & Chr(34) & "=" & Chr(34) & CType(regKey.GetValue(""), String) & Chr(34), String))
                    sb.AppendLine()
                End If
            End If

            'Indent
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Indent\", True)
            If regKey IsNot Nothing Then
                Dim ValueCount As Integer = regKey.ValueCount()
                If ValueCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\Indent\" & "]")
                    sb.AppendLine(CType(Chr(34) & "" & Chr(34) & "=" & Chr(34) & CType(regKey.GetValue(""), String) & Chr(34), String))
                    sb.AppendLine()
                End If
            End If

            'Language
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\Language\", True)
            If regKey IsNot Nothing Then
                Dim ValueCount As Integer = regKey.ValueCount()
                If ValueCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\Language\" & "]")
                    sb.AppendLine(CType(Chr(34) & "" & Chr(34) & "=" & Chr(34) & CType(regKey.GetValue(""), String) & Chr(34), String))
                    sb.AppendLine()
                End If
            End If

            'Marge Droite
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite\", True)
            If regKey IsNot Nothing Then
                Dim ValueCount As Integer = regKey.ValueCount()
                If ValueCount > 0 Then
                    sb.AppendLine("[HKEY_CURRENT_USER\Software\Popotte\Settings\MargeDroite\" & "]")
                    sb.AppendLine(Chr(34) & "" & Chr(34) & "=dword:" & regKey.GetValue("").ToString())
                    sb.AppendLine()
                End If
            End If

            'Write to file UNICODE
            Using outfile As New StreamWriter(SaveFileDialog1.FileName, False, Encoding.Unicode)
                outfile.Write(sb.ToString())
            End Using
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "14"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "15"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        SaveFileDialog1.Dispose()
    End Sub

    Private Sub LanguageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LanguageToolStripMenuItem.Click
        Dim d As New LanguageDialog
        d.ShowDialog()
        If d.DialogResult = DialogResult.Yes Then
            d.Dispose()
            restart = True
            If Not CloseApp(e) = DialogResult.Cancel Then
                Process.Start(Application.ExecutablePath)
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub AidesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AidesToolStripMenuItem1.Click
        Process.Start(Application.StartupPath & "\Popotte.pdf")
    End Sub

    Private Sub ToolStripMenuItemSiteWeb_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSiteWeb.Click
        Process.Start("https://github.com/StormACE/Popotte")
    End Sub

    Private Sub CourteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourteToolStripMenuItem.Click
        Dim thisDay As DateTime = DateTime.Now
        rtbDoc.SelectedText = thisDay.ToString("d")
    End Sub

    Private Sub LongueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LongueToolStripMenuItem.Click
        Dim thisDay As DateTime = DateTime.Now
        rtbDoc.SelectedText = thisDay.ToString("D")
    End Sub

    Private Sub CourteHeureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourteHeureToolStripMenuItem.Click
        Dim thisDay As DateTime = DateTime.Now
        rtbDoc.SelectedText = thisDay.ToString("g")
    End Sub

    Private Sub LongueHeureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LongueHeureToolStripMenuItem.Click
        Dim thisDay As DateTime = DateTime.Now
        rtbDoc.SelectedText = thisDay.ToString("f")
    End Sub

    Private Sub crypter_Click(sender As Object, e As EventArgs) Handles CrypterToolStripMenuItem.Click
        Dim crypt As New dlgCrypterDécrypter
        crypt.ShowDialog()
        crypt.Dispose()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        'Lancer dans un nouveau thread
        Dim Tasks As New CVérifierMiseAJour(demarrage)
        Dim Thread1 As New System.Threading.Thread(
            AddressOf Tasks.CheckForupdate)
        Thread1.Name = "CheckUpdatePopotte"
        Thread1.Priority = Threading.ThreadPriority.Normal
        Thread1.Start() ' Start the new thread.
        'Thread1.Join() ' Wait for thread 1 to finish.
    End Sub

    Private Sub VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\VerUpdate", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("VerUpdate")
        End If

        If VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem.Checked Then
            VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem.Checked = False
            regKey.SetValue("check", 0)
        Else
            VérifierSiUneMiseÀJourEstDisponibleAuDémarrageToolStripMenuItem.Checked = True
            regKey.SetValue("check", 1)
        End If
    End Sub

    Private Sub InsertlocalfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertlocalfileToolStripMenuItem.Click
        OpenFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "82")
        OpenFileDialog1.DefaultExt = ""
        OpenFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "79") & "|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = Nothing Then Exit Sub
        Dim Filen As String = "file:/" & OpenFileDialog1.FileName

        'enlever les espaces par %20
        Dim Position As Integer = 0
        Do
            Position = InStr(Filen, " ")
            If Position <> 0 Then
                Filen = Microsoft.VisualBasic.Left(Filen, Position - 1) & "%20" & Mid(Filen, Position + Len(" "))
            End If
        Loop Until Position = 0

        rtbDoc.SelectedText = Filen

        OpenFileDialog1.Dispose()
    End Sub

    Private Sub ToolStripMenuItemArchiverLesRecettes_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemArchiverLesRecettes.Click
        If IsDirectoryEmpty(PopotteDir) = False Then
            SaveFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "83")
            SaveFileDialog1.DefaultExt = "zip"
            SaveFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "84") & " (*.zip)|*.zip"
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName = "" Then Exit Sub

            Using zip As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile
                Me.Cursor = Cursors.WaitCursor
                zip.AddDirectory(PopotteDir)
                zip.Save(SaveFileDialog1.FileName)
                Me.Cursor = Cursors.Arrow
                MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "16"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Else
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "17"), LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        SaveFileDialog1.Dispose()
    End Sub

    Private Sub ÉditeurExterneParDéfautToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÉditeurExterneParDéfautToolStripMenuItem.Click
        Dim ppath As String = ""
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\EditeurExt", True)
        If regKey IsNot Nothing Then
            ppath = CType(regKey.GetValue(""), String)
        End If

        OpenFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "86")
        OpenFileDialog1.DefaultExt = "exe"
        OpenFileDialog1.InitialDirectory = ppath
        OpenFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "87") & "|*.exe"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = Nothing Then Exit Sub

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\EditeurExt", True)
        If regKey Is Nothing Then
            Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey = newregKey.CreateSubKey("EditeurExt")
        End If
        regKey.SetValue("", OpenFileDialog1.FileName)
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub AfficherLesImagesDesRecettesDansLaListeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherLesImagesDesRecettesDansLaListeToolStripMenuItem.Click
        If AfficherLesImagesDesRecettesDansLaListeToolStripMenuItem.Checked Then
            ImageRecette = True
        Else
            ImageRecette = False
        End If

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\ImageRecette", True)
        If regKey IsNot Nothing Then
            regKey.SetValue("", ImageRecette)
        Else
            Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey = newregKey.CreateSubKey("ImageRecette")
            regKey.SetValue("", ImageRecette)
        End If
    End Sub

    Private Sub CmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 14.173228346)
        CmToolStripMenuItem.Checked = True
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 0)
    End Sub

    Private Sub CmToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem1.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 28.346456693)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = True
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 1)
    End Sub

    Private Sub CmToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem2.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 42.519685039)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = True
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 2)
    End Sub

    Private Sub CmToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem3.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 56.692913386)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = True
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 3)
    End Sub

    Private Sub CmToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem4.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 70.866141732)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = True
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 4)
    End Sub

    Private Sub CmToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem5.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 85.039370079)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = True
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 5)
    End Sub

    Private Sub CmToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem6.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 99.212598425)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = True
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 6)
    End Sub

    Private Sub CmToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles CmToolStripMenuItem7.Click
        rtbDoc.RightMargin = CInt(rtbDoc.Width - 30 - 113.385826772)
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = True
        CMToolStripMenuItem8.Checked = False
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 7)
    End Sub

    Private Sub CMToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles CMToolStripMenuItem8.Click
        rtbDoc.RightMargin = rtbDoc.Width - 30
        CmToolStripMenuItem.Checked = False
        CmToolStripMenuItem1.Checked = False
        CmToolStripMenuItem2.Checked = False
        CmToolStripMenuItem3.Checked = False
        CmToolStripMenuItem4.Checked = False
        CmToolStripMenuItem5.Checked = False
        CmToolStripMenuItem6.Checked = False
        CmToolStripMenuItem7.Checked = False
        CMToolStripMenuItem8.Checked = True
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\MargeDroite", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\", True)
            regKey = regKey.CreateSubKey("MargeDroite")
        End If
        regKey.SetValue("", 8)
    End Sub

    Public Sub ToolStripMenuItemOnedrive_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemOnedrive.Click
        Dim Lastdir As String = ""
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\FirstStart", True)
        If regKey IsNot Nothing Then
            firststart = False
        End If
        If Not firststart Then
            Lastdir = PopotteDir
        End If
        regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\OneDrive\Accounts\Personal", True)
        If regKey IsNot Nothing Then
            PopotteDir = CType(regKey.GetValue("UserFolder", ""), String)
            If PopotteDir = "" Then
                MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "39"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                PopotteDir = PopotteDir & "\Popotte\"
                If Not File.Exists(PopotteDir) Then
                    If CreateFolder(PopotteDir) = -1 Then
                        MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "40"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
                If regKey Is Nothing Then
                    regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                    regKey.CreateSubKey("RecetteDir")
                End If
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
                If regKey IsNot Nothing Then
                    regKey.SetValue("", PopotteDir)
                    regKey.SetValue("FolderOpt", 1)
                    ToolStripMenuItemOnedrive.Checked = True
                    ToolStripMenuItemDropbox.Checked = False
                    DossierRecetteToolStripMenuItem.Checked = False
                    If Lastdir = "" Then
                        MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "41"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        askforexamples()
                    Else
                        Dim answer As DialogResult = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "41") & " " & LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "42"), "Popotte", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If answer = DialogResult.Yes Then
                            If Not IsDirectoryEmpty(Lastdir) Then
                                If CopyFolder(Lastdir, PopotteDir) <> -1 Then
                                    MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "43"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Else
                                MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "46"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    End If
                End If

            End If
        Else
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "39"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub ToolStripMenuItemDropbox_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDropbox.Click
        Dim Lastdir As String = ""
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\FirstStart", True)
        If regKey IsNot Nothing Then
            firststart = False
        End If
        If Not firststart Then
            Lastdir = PopotteDir
        End If
        Dim DropboxPath As String = GetDropBoxPath()
        If DropboxPath = "" Then
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "44"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PopotteDir = DropboxPath & "\Popotte\"
            If Not File.Exists(PopotteDir) Then
                If CreateFolder(PopotteDir) = -1 Then
                    MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "40"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
            If regKey Is Nothing Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
                regKey.CreateSubKey("RecetteDir")
            End If
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\RecetteDir", True)
            If regKey IsNot Nothing Then
                regKey.SetValue("", PopotteDir)
                regKey.SetValue("FolderOpt", 2)
                ToolStripMenuItemDropbox.Checked = True
                ToolStripMenuItemOnedrive.Checked = False
                DossierRecetteToolStripMenuItem.Checked = False
                If Lastdir = "" Then
                    MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "45"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    askforexamples()
                Else
                    Dim answer As DialogResult = MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "45") & " " & LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "42"), "Popotte", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If answer = DialogResult.Yes Then
                        If Not IsDirectoryEmpty(Lastdir) Then
                            If CopyFolder(Lastdir, PopotteDir) <> -1 Then
                                MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "43"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "46"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Function GetDropBoxPath() As String
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Dim dbPath As String = Path.Combine(appDataPath, "Dropbox\host.db")

        If Not File.Exists(dbPath) Then
            Return ""
        End If

        Dim Lines As String() = File.ReadAllLines(dbPath)
        Dim dbBase64Text As Byte() = Convert.FromBase64String(Lines(1))
        Dim folderPath As String = Encoding.UTF8.GetString(dbBase64Text)

        Return folderPath
    End Function

    Private Sub OptRTFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptRTFToolStripMenuItem.Click
        'Create file association in registry

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\FileAsso", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey.CreateSubKey("FileAsso")
            regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\FileAsso", True)
            FileAssoValue = False
        Else
            FileAssoValue = CBool(regKey.GetValue("", True))
        End If

        If FileAssoValue Then
            DelFileAsso()
            regKey.SetValue("", False)
            OptRTFToolStripMenuItem.Checked = False
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "48"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            SetFileAsso()
            regKey.SetValue("", True)
            OptRTFToolStripMenuItem.Checked = True
            MessageBox.Show(LangIni.GetKeyValue("Popotte - EditorWindow - Messagebox", "47"), "Popotte", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub SetFileAsso()
        Dim SregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Classes", True)
        SregKey.CreateSubKey(".rtf")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\.rtf", True)
        SregKey.SetValue("", "Popotte")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes", True)
        SregKey.CreateSubKey("popotte")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte", True)
        SregKey.SetValue("", "rtf File")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte", True)
        SregKey.CreateSubKey("DefaultIcon")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte\DefaultIcon", True)
        SregKey.SetValue("", Application.StartupPath() & "\images\Popotte.ico")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte", True)
        SregKey.CreateSubKey("Shell")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte\Shell", True)
        SregKey.CreateSubKey("open")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte\Shell\open", True)
        SregKey.CreateSubKey("command")
        SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes\popotte\Shell\open\command", True)
        SregKey.SetValue("", Application.StartupPath() & "\popotte.exe " & Chr(34) & Chr(37) & "1" & Chr(34))
    End Sub

    Private Sub DelFileAsso()
        Dim SregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Classes\.rtf", True)
        If SregKey IsNot Nothing Then
            SregKey.SetValue("", "")
            SregKey = Registry.CurrentUser.OpenSubKey("Software\Classes", True)
            SregKey.DeleteSubKeyTree("popotte")
        End If
    End Sub

    Private Sub SurlignerLaSélectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SurlignerLaSélectionToolStripMenuItem.Click
        If rtbDoc.SelectedText <> "" Then
            rtbDoc.SelectionHighLight = HighlightColor
        End If
    End Sub

    Private Sub CouleurDeSurbrillanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CouleurDeSurbrillanceToolStripMenuItem.Click
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\HLColor", True)

        If regKey Is Nothing Then
            Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey = newregKey.CreateSubKey("HLColor")
        Else
            HighlightColor = ColorFromData(CType(regKey.GetValue(""), String))
        End If

        ColorDialog1.Color = HighlightColor

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            regKey.SetValue("", ColorDialog1.Color, RegistryValueKind.String)
            HighlightColor = ColorDialog1.Color
            ColorDialog1.Dispose()
        End If
    End Sub

    Private Sub AnnulerLaSurbrillanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulerLaSurbrillanceToolStripMenuItem.Click
        If rtbDoc.SelectedText <> "" Then
            rtbDoc.SelectionHighLight = Color.White
        End If
    End Sub

    Private Sub AutoCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoCToolStripMenuItem.Click
        Dim ppath As String = ""
        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\AutoCExt", True)
        If regKey IsNot Nothing Then
            ppath = CType(regKey.GetValue(""), String)
        End If

        OpenFileDialog1.Title = "Popotte - " & LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "99")
        OpenFileDialog1.DefaultExt = "exe"
        OpenFileDialog1.InitialDirectory = ppath
        OpenFileDialog1.Filter = LangIni.GetKeyValue("Popotte - EditorWindow - Menu", "87") & "|*.exe"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = Nothing Then Exit Sub

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\AutoCExt", True)
        If regKey Is Nothing Then
            Dim newregKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings", True)
            regKey = newregKey.CreateSubKey("AutoCExt")
        End If
        regKey.SetValue("", OpenFileDialog1.FileName)
        AutoCcontextToolStripMenuItem.Enabled = True
        AutoCeditToolStripMenuItem.Enabled = True
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub AutoCeditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoCeditToolStripMenuItem.Click

        Dim txtWriter As StreamWriter
        'encode as ansi
        Dim appData As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)
        Dim Destpath As String = appData & "\Popotte\AutoCText.txt"

        If System.IO.File.Exists(Destpath) Then
            My.Computer.FileSystem.DeleteFile(Destpath)
        End If

        txtWriter = New StreamWriter(Destpath, True, System.Text.Encoding.Unicode)
        txtWriter.Write(rtbDoc.SelectedText)
        txtWriter.Close()
        txtWriter = Nothing

        rtbDoc.SelectionStart = 0
        rtbDoc.SelectionLength = 0
        rtbDoc.Modified = False

        Dim ppath As String = ""

        regKey = Registry.CurrentUser.OpenSubKey("Software\Popotte\Settings\AutoCExt", True)

        If regKey IsNot Nothing Then
            ppath = CType(regKey.GetValue(""), String)
        End If

        Dim Argument As String
        Argument = Destpath
        Argument = Chr(34) & Argument & Chr(34)

        Try
            Process.Start(ppath, Argument)
        Catch ex As Exception
            MessageBox.Show(LangIni.GetKeyValue("Popotte - BooksDialog - MessageBox", "6") & " " & ex.ToString, "Popotte - " & LangIni.GetKeyValue("Popotte - BooksDialog - MessageBox", "1"), MessageBoxButtons.OK, MessageBoxIcon.Warning) 'else display any possible error
        End Try
    End Sub

#End Region



#Region "Contextmenu Methods"

    Private Sub ToolStripMenuItemToutSel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripMenuItemToutSel.Click
        rtbDoc.SelectAll()
    End Sub

    Private Sub ToolStripMenuItemImage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripMenuItemImage.Click
        InsertImageToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CopierToolStripMenuItem.Click
        CopyToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub CouperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CouperToolStripMenuItem.Click
        CutToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub CollerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CollerToolStripMenuItem.Click
        PasteToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub InsertlocalfileContextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertlocalfileContextToolStripMenuItem.Click
        InsertlocalfileToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub SurlignerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SurlignerToolStripMenuItem.Click
        SurlignerLaSélectionToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub AnnulerSurbrillanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulerSurbrillanceToolStripMenuItem.Click
        AnnulerLaSurbrillanceToolStripMenuItem_Click(Me, e)
    End Sub
    Private Sub AutoCcontextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoCcontextToolStripMenuItem.Click
        AutoCeditToolStripMenuItem_Click(Me, e)
    End Sub
#End Region



#Region "Toolbar Methods"

    Private Sub ToolStripComboBoxPolices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBoxPolices.SelectedIndexChanged
        SetFont()
        rtbDoc.Focus()
    End Sub

    Private Sub ToolStripComboBoxSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBoxSize.SelectedIndexChanged
        SetFont()
        rtbDoc.Focus()
    End Sub

    Private Sub SetFont()
        If GCF = False Then
            If FontLoaded Then

                If rtbDoc.SelectionFont IsNot Nothing Then
                    Dim SelectedFont As String = CType(ToolStripComboBoxPolices.SelectedItem, String)
                    Dim newFontStyle As System.Drawing.FontStyle = rtbDoc.SelectionFont.Style
                    Dim SelectedSize As String = CType(ToolStripComboBoxSize.SelectedItem, String)

                    rtbDoc.SelectionFont = New Font(
                       SelectedFont,
                       CInt(SelectedSize),
                       newFontStyle
                    )
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSave.Click
        SaveToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonOuvrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonOuvrir.Click
        OpenToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonNRecette_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonNRecette.Click
        NewToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBold.Click
        BoldToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonItalic.Click
        ItalicToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonUnderline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonUnderline.Click
        UnderlineToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonGauche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonGauche.Click
        rtbDoc.SelectionAlignment = TextAlign.Left
        ToolStripButtonGauche.Checked = True
        ToolStripButtonCentre.Checked = False
        ToolStripButtonDroite.Checked = False
        JustifyToolStripButton.Checked = False
        TexteÀGaucheToolStripMenuItem.Checked = True
        TexteCentréToolStripMenuItem.Checked = False
        TexteÀDroiteToolStripMenuItem.Checked = False
        TexteJustifiéToolStripMenuItem.Checked = False
    End Sub

    Private Sub TexteÀGaucheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TexteÀGaucheToolStripMenuItem.Click
        ToolStripButtonGauche_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonCentre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCentre.Click
        rtbDoc.SelectionAlignment = TextAlign.Center
        ToolStripButtonCentre.Checked = True
        ToolStripButtonDroite.Checked = False
        ToolStripButtonGauche.Checked = False
        JustifyToolStripButton.Checked = False
        TexteÀGaucheToolStripMenuItem.Checked = False
        TexteCentréToolStripMenuItem.Checked = True
        TexteÀDroiteToolStripMenuItem.Checked = False
        TexteJustifiéToolStripMenuItem.Checked = False
    End Sub

    Private Sub TexteCentréToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TexteCentréToolStripMenuItem.Click
        ToolStripButtonCentre_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonDroite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonDroite.Click
        rtbDoc.SelectionAlignment = TextAlign.Right
        ToolStripButtonDroite.Checked = True
        ToolStripButtonGauche.Checked = False
        ToolStripButtonCentre.Checked = False
        JustifyToolStripButton.Checked = False
        TexteÀGaucheToolStripMenuItem.Checked = False
        TexteCentréToolStripMenuItem.Checked = False
        TexteJustifiéToolStripMenuItem.Checked = False
        TexteÀDroiteToolStripMenuItem.Checked = True
    End Sub

    Private Sub JustifyToolStripButton_Click(sender As Object, e As EventArgs) Handles JustifyToolStripButton.Click
        rtbDoc.SelectionAlignment = TextAlign.Justify
        JustifyToolStripButton.Checked = True
        ToolStripButtonDroite.Checked = False
        ToolStripButtonGauche.Checked = False
        ToolStripButtonCentre.Checked = False
        TexteÀGaucheToolStripMenuItem.Checked = False
        TexteCentréToolStripMenuItem.Checked = False
        TexteÀDroiteToolStripMenuItem.Checked = False
        TexteJustifiéToolStripMenuItem.Checked = True
    End Sub


    Private Sub TexteÀDroiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TexteÀDroiteToolStripMenuItem.Click
        ToolStripButtonDroite_Click(Me, e)
    End Sub

    Private Sub TexteJustifiéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TexteJustifiéToolStripMenuItem.Click
        JustifyToolStripButton_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonPrint.Click
        PrintToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonImage.Click
        InsertImageToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCut.Click
        CutToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCopy.Click
        CopyToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonPaste.Click
        PasteToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub ToolStripButtonCouleurs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCouleurs.Click
        ColorDialog1.Color = DefaultFontColor

        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ToolStripButtonCouleurs.BackColor = ColorDialog1.Color
            rtbDoc.SelectionColor = ColorDialog1.Color
            ColorDialog1.Dispose()
        End If
    End Sub

    Private Sub ToolStripButtonLivres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonLivres.Click
        ToolStripMenuItemLivres_Click(Me, e)
    End Sub

    Private Sub FileLinkToolStripButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FileLinkToolStripButton.Click
        InsertlocalfileToolStripMenuItem_Click(Me, e)
    End Sub

    Private Sub PageUpToolStripButton_Click(sender As Object, e As EventArgs) Handles PageUpToolStripButton.Click
        rtbDoc.SelectionStart = 0
    End Sub

    Private Sub ToolStripButtonBulletList_Click(sender As Object, e As EventArgs) Handles ToolStripButtonBulletList.Click
        AddBulletsToolStripMenuItem_Click(Me, e)
    End Sub



#End Region



#Region "Printing"


    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        ' Adapted from Microsoft's example for extended richtextbox control
        '
        checkPrint = 0

    End Sub


    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' Adapted from Microsoft's example for extended richtextbox control
        '
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = rtbDoc.Print(checkPrint, rtbDoc.TextLength, e)

        ' Look for more pages
        If checkPrint < rtbDoc.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub ToolStripMenuItemMenu_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMenu.Click
        Dim mn As New frmMenu
        mn.Show()
    End Sub



#End Region


End Class


' Create a class to handle the exception event.
Friend Class CustomExceptionHandler
    'Handle the exception event.
    Public Shared Sub OnThreadException(sender As Object, t As ThreadExceptionEventArgs)
        Dim result As DialogResult = ShowThreadExceptionDialog(t.Exception)

        ' Exit the program when the user clicks Abort.
        If result = DialogResult.Abort Then
            Application.Exit()
        End If
    End Sub

    ' Create and display the error message.
    Private Shared Function ShowThreadExceptionDialog(e As Exception) As DialogResult
        Dim errorMsg As String = "An error occurred.  Please contact the " &
            "adminstrator with the following information:" &
            vbCrLf & vbCrLf
        errorMsg &= "Exception Type: " & e.GetType().Name & vbCrLf & vbCrLf
        errorMsg &= e.Message & vbCrLf & vbCrLf
        errorMsg &= "Stack Trace: " & vbCrLf & e.StackTrace

        Return MessageBox.Show(errorMsg, "Application Error",
               MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
    End Function
End Class


