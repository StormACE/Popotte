<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.LabelMonday = New System.Windows.Forms.Label()
        Me.LabelTuesday = New System.Windows.Forms.Label()
        Me.LabelWednesday = New System.Windows.Forms.Label()
        Me.LabelSunday = New System.Windows.Forms.Label()
        Me.LabelThursday = New System.Windows.Forms.Label()
        Me.LabelFriday = New System.Windows.Forms.Label()
        Me.LabelSaturday = New System.Windows.Forms.Label()
        Me.ListBoxSunday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModifierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EffacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBoxMonday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Modifier2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Effacer2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBoxTuesday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Modifier3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Effacer3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBoxWednesday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Modifier4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Effacer4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBoxThursday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip5 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Modifier5ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Effacer5ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBoxFriday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip6 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Modifier6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Effacer6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBoxSaturday = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip7 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Modifier7ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Effacer7ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonPreview = New System.Windows.Forms.Button()
        Me.Button1Touteff = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.ContextMenuStrip4.SuspendLayout()
        Me.ContextMenuStrip5.SuspendLayout()
        Me.ContextMenuStrip6.SuspendLayout()
        Me.ContextMenuStrip7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonClose
        '
        Me.ButtonClose.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose.Location = New System.Drawing.Point(600, 508)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(94, 47)
        Me.ButtonClose.TabIndex = 7
        Me.ButtonClose.Text = "Fermer"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'LabelMonday
        '
        Me.LabelMonday.AutoSize = True
        Me.LabelMonday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMonday.Location = New System.Drawing.Point(12, 87)
        Me.LabelMonday.Name = "LabelMonday"
        Me.LabelMonday.Size = New System.Drawing.Size(178, 54)
        Me.LabelMonday.TabIndex = 8
        Me.LabelMonday.Text = "Monday"
        '
        'LabelTuesday
        '
        Me.LabelTuesday.AutoSize = True
        Me.LabelTuesday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTuesday.Location = New System.Drawing.Point(14, 153)
        Me.LabelTuesday.Name = "LabelTuesday"
        Me.LabelTuesday.Size = New System.Drawing.Size(176, 54)
        Me.LabelTuesday.TabIndex = 9
        Me.LabelTuesday.Text = "Tuesday"
        '
        'LabelWednesday
        '
        Me.LabelWednesday.AutoSize = True
        Me.LabelWednesday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWednesday.Location = New System.Drawing.Point(12, 219)
        Me.LabelWednesday.Name = "LabelWednesday"
        Me.LabelWednesday.Size = New System.Drawing.Size(242, 54)
        Me.LabelWednesday.TabIndex = 10
        Me.LabelWednesday.Text = "Wednesday"
        '
        'LabelSunday
        '
        Me.LabelSunday.AutoSize = True
        Me.LabelSunday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSunday.Location = New System.Drawing.Point(12, 21)
        Me.LabelSunday.Name = "LabelSunday"
        Me.LabelSunday.Size = New System.Drawing.Size(162, 54)
        Me.LabelSunday.TabIndex = 11
        Me.LabelSunday.Text = "Sunday"
        '
        'LabelThursday
        '
        Me.LabelThursday.AutoSize = True
        Me.LabelThursday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelThursday.Location = New System.Drawing.Point(14, 285)
        Me.LabelThursday.Name = "LabelThursday"
        Me.LabelThursday.Size = New System.Drawing.Size(197, 54)
        Me.LabelThursday.TabIndex = 12
        Me.LabelThursday.Text = "Thursday"
        '
        'LabelFriday
        '
        Me.LabelFriday.AutoSize = True
        Me.LabelFriday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFriday.Location = New System.Drawing.Point(14, 351)
        Me.LabelFriday.Name = "LabelFriday"
        Me.LabelFriday.Size = New System.Drawing.Size(140, 54)
        Me.LabelFriday.TabIndex = 13
        Me.LabelFriday.Text = "Friday"
        '
        'LabelSaturday
        '
        Me.LabelSaturday.AutoSize = True
        Me.LabelSaturday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSaturday.Location = New System.Drawing.Point(12, 417)
        Me.LabelSaturday.Name = "LabelSaturday"
        Me.LabelSaturday.Size = New System.Drawing.Size(192, 54)
        Me.LabelSaturday.TabIndex = 14
        Me.LabelSaturday.Text = "Saturday"
        '
        'ListBoxSunday
        '
        Me.ListBoxSunday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxSunday.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBoxSunday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxSunday.FormattingEnabled = True
        Me.ListBoxSunday.ItemHeight = 28
        Me.ListBoxSunday.Location = New System.Drawing.Point(261, 21)
        Me.ListBoxSunday.Name = "ListBoxSunday"
        Me.ListBoxSunday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxSunday.TabIndex = 15
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModifierToolStripMenuItem, Me.EffacerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 68)
        '
        'ModifierToolStripMenuItem
        '
        Me.ModifierToolStripMenuItem.Name = "ModifierToolStripMenuItem"
        Me.ModifierToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.ModifierToolStripMenuItem.Text = "Modifier"
        '
        'EffacerToolStripMenuItem
        '
        Me.EffacerToolStripMenuItem.Image = CType(resources.GetObject("EffacerToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EffacerToolStripMenuItem.Name = "EffacerToolStripMenuItem"
        Me.EffacerToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.EffacerToolStripMenuItem.Text = "Effacer"
        '
        'ListBoxMonday
        '
        Me.ListBoxMonday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxMonday.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListBoxMonday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxMonday.FormattingEnabled = True
        Me.ListBoxMonday.ItemHeight = 28
        Me.ListBoxMonday.Location = New System.Drawing.Point(261, 87)
        Me.ListBoxMonday.Name = "ListBoxMonday"
        Me.ListBoxMonday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxMonday.TabIndex = 16
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Modifier2ToolStripMenuItem, Me.Effacer2ToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(160, 68)
        '
        'Modifier2ToolStripMenuItem
        '
        Me.Modifier2ToolStripMenuItem.Name = "Modifier2ToolStripMenuItem"
        Me.Modifier2ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Modifier2ToolStripMenuItem.Text = "Modifier"
        '
        'Effacer2ToolStripMenuItem
        '
        Me.Effacer2ToolStripMenuItem.Image = CType(resources.GetObject("Effacer2ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Effacer2ToolStripMenuItem.Name = "Effacer2ToolStripMenuItem"
        Me.Effacer2ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Effacer2ToolStripMenuItem.Text = "Effacer"
        '
        'ListBoxTuesday
        '
        Me.ListBoxTuesday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxTuesday.ContextMenuStrip = Me.ContextMenuStrip3
        Me.ListBoxTuesday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxTuesday.FormattingEnabled = True
        Me.ListBoxTuesday.ItemHeight = 28
        Me.ListBoxTuesday.Location = New System.Drawing.Point(261, 153)
        Me.ListBoxTuesday.Name = "ListBoxTuesday"
        Me.ListBoxTuesday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxTuesday.TabIndex = 17
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Modifier3ToolStripMenuItem, Me.Effacer3ToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(160, 68)
        '
        'Modifier3ToolStripMenuItem
        '
        Me.Modifier3ToolStripMenuItem.Name = "Modifier3ToolStripMenuItem"
        Me.Modifier3ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Modifier3ToolStripMenuItem.Text = "Modifier"
        '
        'Effacer3ToolStripMenuItem
        '
        Me.Effacer3ToolStripMenuItem.Image = CType(resources.GetObject("Effacer3ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Effacer3ToolStripMenuItem.Name = "Effacer3ToolStripMenuItem"
        Me.Effacer3ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Effacer3ToolStripMenuItem.Text = "Effacer"
        '
        'ListBoxWednesday
        '
        Me.ListBoxWednesday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxWednesday.ContextMenuStrip = Me.ContextMenuStrip4
        Me.ListBoxWednesday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxWednesday.FormattingEnabled = True
        Me.ListBoxWednesday.ItemHeight = 28
        Me.ListBoxWednesday.Location = New System.Drawing.Point(260, 219)
        Me.ListBoxWednesday.Name = "ListBoxWednesday"
        Me.ListBoxWednesday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxWednesday.TabIndex = 18
        '
        'ContextMenuStrip4
        '
        Me.ContextMenuStrip4.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Modifier4ToolStripMenuItem, Me.Effacer4ToolStripMenuItem})
        Me.ContextMenuStrip4.Name = "ContextMenuStrip4"
        Me.ContextMenuStrip4.Size = New System.Drawing.Size(160, 68)
        '
        'Modifier4ToolStripMenuItem
        '
        Me.Modifier4ToolStripMenuItem.Name = "Modifier4ToolStripMenuItem"
        Me.Modifier4ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Modifier4ToolStripMenuItem.Text = "Modifier"
        '
        'Effacer4ToolStripMenuItem
        '
        Me.Effacer4ToolStripMenuItem.Image = CType(resources.GetObject("Effacer4ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Effacer4ToolStripMenuItem.Name = "Effacer4ToolStripMenuItem"
        Me.Effacer4ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Effacer4ToolStripMenuItem.Text = "Effacer"
        '
        'ListBoxThursday
        '
        Me.ListBoxThursday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxThursday.ContextMenuStrip = Me.ContextMenuStrip5
        Me.ListBoxThursday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxThursday.FormattingEnabled = True
        Me.ListBoxThursday.ItemHeight = 28
        Me.ListBoxThursday.Location = New System.Drawing.Point(261, 285)
        Me.ListBoxThursday.Name = "ListBoxThursday"
        Me.ListBoxThursday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxThursday.TabIndex = 19
        '
        'ContextMenuStrip5
        '
        Me.ContextMenuStrip5.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Modifier5ToolStripMenuItem, Me.Effacer5ToolStripMenuItem})
        Me.ContextMenuStrip5.Name = "ContextMenuStrip5"
        Me.ContextMenuStrip5.Size = New System.Drawing.Size(160, 68)
        '
        'Modifier5ToolStripMenuItem
        '
        Me.Modifier5ToolStripMenuItem.Name = "Modifier5ToolStripMenuItem"
        Me.Modifier5ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Modifier5ToolStripMenuItem.Text = "Modifier"
        '
        'Effacer5ToolStripMenuItem
        '
        Me.Effacer5ToolStripMenuItem.Image = CType(resources.GetObject("Effacer5ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Effacer5ToolStripMenuItem.Name = "Effacer5ToolStripMenuItem"
        Me.Effacer5ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Effacer5ToolStripMenuItem.Text = "Effacer"
        '
        'ListBoxFriday
        '
        Me.ListBoxFriday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxFriday.ContextMenuStrip = Me.ContextMenuStrip6
        Me.ListBoxFriday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxFriday.FormattingEnabled = True
        Me.ListBoxFriday.ItemHeight = 28
        Me.ListBoxFriday.Location = New System.Drawing.Point(260, 351)
        Me.ListBoxFriday.Name = "ListBoxFriday"
        Me.ListBoxFriday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxFriday.TabIndex = 20
        '
        'ContextMenuStrip6
        '
        Me.ContextMenuStrip6.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Modifier6ToolStripMenuItem, Me.Effacer6ToolStripMenuItem})
        Me.ContextMenuStrip6.Name = "ContextMenuStrip6"
        Me.ContextMenuStrip6.Size = New System.Drawing.Size(160, 68)
        '
        'Modifier6ToolStripMenuItem
        '
        Me.Modifier6ToolStripMenuItem.Name = "Modifier6ToolStripMenuItem"
        Me.Modifier6ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Modifier6ToolStripMenuItem.Text = "Modifier"
        '
        'Effacer6ToolStripMenuItem
        '
        Me.Effacer6ToolStripMenuItem.Image = CType(resources.GetObject("Effacer6ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Effacer6ToolStripMenuItem.Name = "Effacer6ToolStripMenuItem"
        Me.Effacer6ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Effacer6ToolStripMenuItem.Text = "Effacer"
        '
        'ListBoxSaturday
        '
        Me.ListBoxSaturday.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ListBoxSaturday.ContextMenuStrip = Me.ContextMenuStrip7
        Me.ListBoxSaturday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxSaturday.FormattingEnabled = True
        Me.ListBoxSaturday.ItemHeight = 28
        Me.ListBoxSaturday.Location = New System.Drawing.Point(260, 417)
        Me.ListBoxSaturday.Name = "ListBoxSaturday"
        Me.ListBoxSaturday.Size = New System.Drawing.Size(434, 60)
        Me.ListBoxSaturday.TabIndex = 21
        '
        'ContextMenuStrip7
        '
        Me.ContextMenuStrip7.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Modifier7ToolStripMenuItem, Me.Effacer7ToolStripMenuItem})
        Me.ContextMenuStrip7.Name = "ContextMenuStrip7"
        Me.ContextMenuStrip7.Size = New System.Drawing.Size(160, 68)
        '
        'Modifier7ToolStripMenuItem
        '
        Me.Modifier7ToolStripMenuItem.Name = "Modifier7ToolStripMenuItem"
        Me.Modifier7ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Modifier7ToolStripMenuItem.Text = "Modifier"
        '
        'Effacer7ToolStripMenuItem
        '
        Me.Effacer7ToolStripMenuItem.Image = CType(resources.GetObject("Effacer7ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Effacer7ToolStripMenuItem.Name = "Effacer7ToolStripMenuItem"
        Me.Effacer7ToolStripMenuItem.Size = New System.Drawing.Size(159, 32)
        Me.Effacer7ToolStripMenuItem.Text = "Effacer"
        '
        'ButtonPreview
        '
        Me.ButtonPreview.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPreview.Location = New System.Drawing.Point(465, 508)
        Me.ButtonPreview.Name = "ButtonPreview"
        Me.ButtonPreview.Size = New System.Drawing.Size(129, 47)
        Me.ButtonPreview.TabIndex = 22
        Me.ButtonPreview.Text = "Version Papier"
        Me.ButtonPreview.UseVisualStyleBackColor = True
        '
        'Button1Touteff
        '
        Me.Button1Touteff.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1Touteff.Location = New System.Drawing.Point(330, 508)
        Me.Button1Touteff.Name = "Button1Touteff"
        Me.Button1Touteff.Size = New System.Drawing.Size(129, 47)
        Me.Button1Touteff.TabIndex = 23
        Me.Button1Touteff.Text = "Tout Effacer"
        Me.Button1Touteff.UseVisualStyleBackColor = True
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 567)
        Me.Controls.Add(Me.Button1Touteff)
        Me.Controls.Add(Me.ButtonPreview)
        Me.Controls.Add(Me.ListBoxSaturday)
        Me.Controls.Add(Me.ListBoxFriday)
        Me.Controls.Add(Me.ListBoxThursday)
        Me.Controls.Add(Me.ListBoxWednesday)
        Me.Controls.Add(Me.ListBoxTuesday)
        Me.Controls.Add(Me.ListBoxMonday)
        Me.Controls.Add(Me.ListBoxSunday)
        Me.Controls.Add(Me.LabelSaturday)
        Me.Controls.Add(Me.LabelFriday)
        Me.Controls.Add(Me.LabelThursday)
        Me.Controls.Add(Me.LabelSunday)
        Me.Controls.Add(Me.LabelWednesday)
        Me.Controls.Add(Me.LabelTuesday)
        Me.Controls.Add(Me.LabelMonday)
        Me.Controls.Add(Me.ButtonClose)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ContextMenuStrip4.ResumeLayout(False)
        Me.ContextMenuStrip5.ResumeLayout(False)
        Me.ContextMenuStrip6.ResumeLayout(False)
        Me.ContextMenuStrip7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonClose As Button
    Friend WithEvents LabelMonday As Label
    Friend WithEvents LabelTuesday As Label
    Friend WithEvents LabelWednesday As Label
    Friend WithEvents LabelSunday As Label
    Friend WithEvents LabelThursday As Label
    Friend WithEvents LabelFriday As Label
    Friend WithEvents LabelSaturday As Label
    Friend WithEvents ListBoxSunday As ListBox
    Friend WithEvents ListBoxMonday As ListBox
    Friend WithEvents ListBoxTuesday As ListBox
    Friend WithEvents ListBoxWednesday As ListBox
    Friend WithEvents ListBoxThursday As ListBox
    Friend WithEvents ListBoxFriday As ListBox
    Friend WithEvents ListBoxSaturday As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ModifierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EffacerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Modifier2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Effacer2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents Modifier3ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Effacer3ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip4 As ContextMenuStrip
    Friend WithEvents Modifier4ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Effacer4ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip5 As ContextMenuStrip
    Friend WithEvents Modifier5ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Effacer5ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip6 As ContextMenuStrip
    Friend WithEvents Modifier6ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Effacer6ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip7 As ContextMenuStrip
    Friend WithEvents Modifier7ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Effacer7ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonPreview As Button
    Friend WithEvents Button1Touteff As Button
End Class
