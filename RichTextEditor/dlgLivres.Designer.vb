<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgLivres
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgLivres))
        Me.ListViewLivres = New System.Windows.Forms.ListView()
        Me.LivreContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewBookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangerLeNomDuLivreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EffacerLeLivreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevenirButton = New System.Windows.Forms.Button()
        Me.FermerButton = New System.Windows.Forms.Button()
        Me.ListViewRecettes = New System.Windows.Forms.ListView()
        Me.RecetteContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemFAV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModifierLesInfosDeLaRecetteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.OuvrirAvecEditeurExterneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EffacerLaRecetteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListViewRecherche = New System.Windows.Forms.ListView()
        Me.ButtonRecherche = New System.Windows.Forms.Button()
        Me.ScanRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ButtonFav = New System.Windows.Forms.Button()
        Me.TextBoxRecherche = New System.Windows.Forms.TextBox()
        Me.FavorisContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnleverFavToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LivreContextMenuStrip.SuspendLayout()
        Me.RecetteContextMenuStrip.SuspendLayout()
        Me.FavorisContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewLivres
        '
        Me.ListViewLivres.ContextMenuStrip = Me.LivreContextMenuStrip
        Me.ListViewLivres.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewLivres.LabelEdit = True
        Me.ListViewLivres.Location = New System.Drawing.Point(13, 54)
        Me.ListViewLivres.Name = "ListViewLivres"
        Me.ListViewLivres.Size = New System.Drawing.Size(675, 407)
        Me.ListViewLivres.TabIndex = 0
        Me.ListViewLivres.UseCompatibleStateImageBehavior = False
        Me.ListViewLivres.View = System.Windows.Forms.View.Details
        '
        'LivreContextMenuStrip
        '
        Me.LivreContextMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.LivreContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewBookToolStripMenuItem, Me.ChangerLeNomDuLivreToolStripMenuItem, Me.ToolStripSeparator1, Me.EffacerLeLivreToolStripMenuItem})
        Me.LivreContextMenuStrip.Name = "LivreContextMenuStrip"
        Me.LivreContextMenuStrip.Size = New System.Drawing.Size(215, 100)
        '
        'NewBookToolStripMenuItem
        '
        Me.NewBookToolStripMenuItem.Image = CType(resources.GetObject("NewBookToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewBookToolStripMenuItem.Name = "NewBookToolStripMenuItem"
        Me.NewBookToolStripMenuItem.Size = New System.Drawing.Size(214, 30)
        Me.NewBookToolStripMenuItem.Text = "Nouveau Livre"
        '
        'ChangerLeNomDuLivreToolStripMenuItem
        '
        Me.ChangerLeNomDuLivreToolStripMenuItem.Name = "ChangerLeNomDuLivreToolStripMenuItem"
        Me.ChangerLeNomDuLivreToolStripMenuItem.Size = New System.Drawing.Size(214, 30)
        Me.ChangerLeNomDuLivreToolStripMenuItem.Text = "Changer le Nom du Livre"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(211, 6)
        '
        'EffacerLeLivreToolStripMenuItem
        '
        Me.EffacerLeLivreToolStripMenuItem.Image = CType(resources.GetObject("EffacerLeLivreToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EffacerLeLivreToolStripMenuItem.Name = "EffacerLeLivreToolStripMenuItem"
        Me.EffacerLeLivreToolStripMenuItem.Size = New System.Drawing.Size(214, 30)
        Me.EffacerLeLivreToolStripMenuItem.Text = "Effacer le Livre"
        '
        'RevenirButton
        '
        Me.RevenirButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RevenirButton.Location = New System.Drawing.Point(13, 520)
        Me.RevenirButton.Name = "RevenirButton"
        Me.RevenirButton.Size = New System.Drawing.Size(83, 25)
        Me.RevenirButton.TabIndex = 0
        Me.RevenirButton.Text = "&Revenir"
        Me.RevenirButton.UseVisualStyleBackColor = True
        '
        'FermerButton
        '
        Me.FermerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.FermerButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.FermerButton.Location = New System.Drawing.Point(605, 520)
        Me.FermerButton.Name = "FermerButton"
        Me.FermerButton.Size = New System.Drawing.Size(83, 25)
        Me.FermerButton.TabIndex = 1
        Me.FermerButton.Text = "&Fermer"
        Me.FermerButton.UseVisualStyleBackColor = True
        '
        'ListViewRecettes
        '
        Me.ListViewRecettes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewRecettes.FullRowSelect = True
        Me.ListViewRecettes.GridLines = True
        Me.ListViewRecettes.HideSelection = False
        Me.ListViewRecettes.LabelEdit = True
        Me.ListViewRecettes.Location = New System.Drawing.Point(13, 54)
        Me.ListViewRecettes.Name = "ListViewRecettes"
        Me.ListViewRecettes.ShowItemToolTips = True
        Me.ListViewRecettes.Size = New System.Drawing.Size(673, 407)
        Me.ListViewRecettes.TabIndex = 3
        Me.ListViewRecettes.UseCompatibleStateImageBehavior = False
        Me.ListViewRecettes.Visible = False
        '
        'RecetteContextMenuStrip
        '
        Me.RecetteContextMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.RecetteContextMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.RecetteContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemFAV, Me.ToolStripSeparator4, Me.ModifierLesInfosDeLaRecetteToolStripMenuItem, Me.ToolStripSeparator3, Me.OuvrirAvecEditeurExterneToolStripMenuItem, Me.ToolStripSeparator2, Me.EffacerLaRecetteToolStripMenuItem})
        Me.RecetteContextMenuStrip.Name = "RecetteContextMenuStrip"
        Me.RecetteContextMenuStrip.Size = New System.Drawing.Size(241, 142)
        '
        'ToolStripMenuItemFAV
        '
        Me.ToolStripMenuItemFAV.Image = CType(resources.GetObject("ToolStripMenuItemFAV.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemFAV.Name = "ToolStripMenuItemFAV"
        Me.ToolStripMenuItemFAV.Size = New System.Drawing.Size(240, 30)
        Me.ToolStripMenuItemFAV.Text = "Ajouter aux Favoris"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(237, 6)
        '
        'ModifierLesInfosDeLaRecetteToolStripMenuItem
        '
        Me.ModifierLesInfosDeLaRecetteToolStripMenuItem.Name = "ModifierLesInfosDeLaRecetteToolStripMenuItem"
        Me.ModifierLesInfosDeLaRecetteToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.ModifierLesInfosDeLaRecetteToolStripMenuItem.Text = "Modifier les infos de la recette"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(237, 6)
        '
        'OuvrirAvecEditeurExterneToolStripMenuItem
        '
        Me.OuvrirAvecEditeurExterneToolStripMenuItem.Enabled = False
        Me.OuvrirAvecEditeurExterneToolStripMenuItem.Name = "OuvrirAvecEditeurExterneToolStripMenuItem"
        Me.OuvrirAvecEditeurExterneToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.OuvrirAvecEditeurExterneToolStripMenuItem.Text = "Ouvrir avec l'éditeur externe"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(237, 6)
        '
        'EffacerLaRecetteToolStripMenuItem
        '
        Me.EffacerLaRecetteToolStripMenuItem.Image = CType(resources.GetObject("EffacerLaRecetteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EffacerLaRecetteToolStripMenuItem.Name = "EffacerLaRecetteToolStripMenuItem"
        Me.EffacerLaRecetteToolStripMenuItem.Size = New System.Drawing.Size(240, 30)
        Me.EffacerLaRecetteToolStripMenuItem.Text = "Effacer la recette"
        '
        'ListViewRecherche
        '
        Me.ListViewRecherche.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ListViewRecherche.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewRecherche.Location = New System.Drawing.Point(13, 54)
        Me.ListViewRecherche.Name = "ListViewRecherche"
        Me.ListViewRecherche.Size = New System.Drawing.Size(673, 407)
        Me.ListViewRecherche.TabIndex = 4
        Me.ListViewRecherche.UseCompatibleStateImageBehavior = False
        '
        'ButtonRecherche
        '
        Me.ButtonRecherche.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButtonRecherche.Location = New System.Drawing.Point(306, 520)
        Me.ButtonRecherche.Name = "ButtonRecherche"
        Me.ButtonRecherche.Size = New System.Drawing.Size(83, 25)
        Me.ButtonRecherche.TabIndex = 5
        Me.ButtonRecherche.Text = "Re&chercher"
        Me.ButtonRecherche.UseVisualStyleBackColor = True
        '
        'ScanRichTextBox
        '
        Me.ScanRichTextBox.DetectUrls = False
        Me.ScanRichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ScanRichTextBox.Name = "ScanRichTextBox"
        Me.ScanRichTextBox.Size = New System.Drawing.Size(1, 1)
        Me.ScanRichTextBox.TabIndex = 6
        Me.ScanRichTextBox.Text = ""
        Me.ScanRichTextBox.Visible = False
        '
        'ButtonFav
        '
        Me.ButtonFav.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ButtonFav.BackgroundImage = CType(resources.GetObject("ButtonFav.BackgroundImage"), System.Drawing.Image)
        Me.ButtonFav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonFav.Location = New System.Drawing.Point(13, 4)
        Me.ButtonFav.Name = "ButtonFav"
        Me.ButtonFav.Size = New System.Drawing.Size(44, 44)
        Me.ButtonFav.TabIndex = 7
        Me.ButtonFav.UseVisualStyleBackColor = False
        '
        'TextBoxRecherche
        '
        Me.TextBoxRecherche.AcceptsTab = True
        Me.TextBoxRecherche.AccessibleDescription = ""
        Me.TextBoxRecherche.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TextBoxRecherche.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxRecherche.Location = New System.Drawing.Point(243, 477)
        Me.TextBoxRecherche.Name = "TextBoxRecherche"
        Me.TextBoxRecherche.Size = New System.Drawing.Size(211, 22)
        Me.TextBoxRecherche.TabIndex = 4
        '
        'FavorisContextMenuStrip
        '
        Me.FavorisContextMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.FavorisContextMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.FavorisContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnleverFavToolStripMenuItem})
        Me.FavorisContextMenuStrip.Name = "RecetteContextMenuStrip"
        Me.FavorisContextMenuStrip.Size = New System.Drawing.Size(180, 34)
        '
        'EnleverFavToolStripMenuItem
        '
        Me.EnleverFavToolStripMenuItem.Image = CType(resources.GetObject("EnleverFavToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EnleverFavToolStripMenuItem.Name = "EnleverFavToolStripMenuItem"
        Me.EnleverFavToolStripMenuItem.Size = New System.Drawing.Size(179, 30)
        Me.EnleverFavToolStripMenuItem.Text = "Enlever des favoris"
        '
        'dlgLivres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.CancelButton = Me.FermerButton
        Me.ClientSize = New System.Drawing.Size(702, 557)
        Me.Controls.Add(Me.TextBoxRecherche)
        Me.Controls.Add(Me.ButtonFav)
        Me.Controls.Add(Me.ScanRichTextBox)
        Me.Controls.Add(Me.ButtonRecherche)
        Me.Controls.Add(Me.ListViewRecherche)
        Me.Controls.Add(Me.ListViewRecettes)
        Me.Controls.Add(Me.ListViewLivres)
        Me.Controls.Add(Me.FermerButton)
        Me.Controls.Add(Me.RevenirButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgLivres"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.LivreContextMenuStrip.ResumeLayout(False)
        Me.RecetteContextMenuStrip.ResumeLayout(False)
        Me.FavorisContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListViewLivres As System.Windows.Forms.ListView
    Friend WithEvents RevenirButton As System.Windows.Forms.Button
    Friend WithEvents FermerButton As System.Windows.Forms.Button
    Friend WithEvents ListViewRecettes As System.Windows.Forms.ListView
    Friend WithEvents LivreContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EffacerLeLivreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecetteContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModifierLesInfosDeLaRecetteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EffacerLaRecetteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewRecherche As System.Windows.Forms.ListView
    Friend WithEvents ButtonRecherche As System.Windows.Forms.Button
    Friend WithEvents ScanRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents NewBookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OuvrirAvecEditeurExterneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangerLeNomDuLivreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ButtonFav As Button
    Friend WithEvents TextBoxRecherche As TextBox
    Friend WithEvents ToolStripMenuItemFAV As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents FavorisContextMenuStrip As ContextMenuStrip
    Friend WithEvents EnleverFavToolStripMenuItem As ToolStripMenuItem
End Class
