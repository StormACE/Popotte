<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgReplace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgReplace))
        Me.btnFindNext = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.txtSearchTerm = New System.Windows.Forms.TextBox()
        Me.LabelMot = New System.Windows.Forms.Label()
        Me.txtReplacementText = New System.Windows.Forms.TextBox()
        Me.LabelRemplacer = New System.Windows.Forms.Label()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.btnReplaceAll = New System.Windows.Forms.Button()
        Me.OpacityHScrollBar = New System.Windows.Forms.HScrollBar()
        Me.SuspendLayout()
        '
        'btnFindNext
        '
        Me.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindNext.Location = New System.Drawing.Point(157, 201)
        Me.btnFindNext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(124, 34)
        Me.btnFindNext.TabIndex = 5
        Me.btnFindNext.Text = "&Suivant"
        Me.btnFindNext.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFind.Location = New System.Drawing.Point(22, 201)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(124, 34)
        Me.btnFind.TabIndex = 4
        Me.btnFind.Text = "&Rechercher"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'chkMatchCase
        '
        Me.chkMatchCase.AutoSize = True
        Me.chkMatchCase.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkMatchCase.Location = New System.Drawing.Point(22, 152)
        Me.chkMatchCase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(220, 26)
        Me.chkMatchCase.TabIndex = 3
        Me.chkMatchCase.Text = "Sensible aux majuscules"
        Me.chkMatchCase.UseVisualStyleBackColor = True
        '
        'txtSearchTerm
        '
        Me.txtSearchTerm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtSearchTerm.Location = New System.Drawing.Point(20, 40)
        Me.txtSearchTerm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchTerm.Name = "txtSearchTerm"
        Me.txtSearchTerm.Size = New System.Drawing.Size(533, 29)
        Me.txtSearchTerm.TabIndex = 1
        '
        'LabelMot
        '
        Me.LabelMot.AutoSize = True
        Me.LabelMot.Location = New System.Drawing.Point(16, 13)
        Me.LabelMot.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelMot.Name = "LabelMot"
        Me.LabelMot.Size = New System.Drawing.Size(73, 21)
        Me.LabelMot.TabIndex = 5
        Me.LabelMot.Text = "Mot Clé:"
        '
        'txtReplacementText
        '
        Me.txtReplacementText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtReplacementText.Location = New System.Drawing.Point(22, 113)
        Me.txtReplacementText.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtReplacementText.Name = "txtReplacementText"
        Me.txtReplacementText.Size = New System.Drawing.Size(531, 29)
        Me.txtReplacementText.TabIndex = 2
        '
        'LabelRemplacer
        '
        Me.LabelRemplacer.AutoSize = True
        Me.LabelRemplacer.Location = New System.Drawing.Point(17, 86)
        Me.LabelRemplacer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRemplacer.Name = "LabelRemplacer"
        Me.LabelRemplacer.Size = New System.Drawing.Size(125, 21)
        Me.LabelRemplacer.TabIndex = 10
        Me.LabelRemplacer.Text = "Remplacer par:"
        '
        'btnReplace
        '
        Me.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReplace.Location = New System.Drawing.Point(291, 201)
        Me.btnReplace.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(124, 34)
        Me.btnReplace.TabIndex = 6
        Me.btnReplace.Text = "Rem&placer"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'btnReplaceAll
        '
        Me.btnReplaceAll.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReplaceAll.Location = New System.Drawing.Point(427, 201)
        Me.btnReplaceAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnReplaceAll.Name = "btnReplaceAll"
        Me.btnReplaceAll.Size = New System.Drawing.Size(124, 34)
        Me.btnReplaceAll.TabIndex = 7
        Me.btnReplaceAll.Text = "&Tous"
        Me.btnReplaceAll.UseVisualStyleBackColor = True
        '
        'OpacityHScrollBar
        '
        Me.OpacityHScrollBar.Location = New System.Drawing.Point(20, 250)
        Me.OpacityHScrollBar.Name = "OpacityHScrollBar"
        Me.OpacityHScrollBar.Size = New System.Drawing.Size(530, 26)
        Me.OpacityHScrollBar.TabIndex = 11
        '
        'dlgReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(573, 294)
        Me.Controls.Add(Me.OpacityHScrollBar)
        Me.Controls.Add(Me.btnReplaceAll)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.txtReplacementText)
        Me.Controls.Add(Me.LabelRemplacer)
        Me.Controls.Add(Me.btnFindNext)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.chkMatchCase)
        Me.Controls.Add(Me.txtSearchTerm)
        Me.Controls.Add(Me.LabelMot)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgReplace"
        Me.ShowInTaskbar = False
        Me.Text = "Popotte - Rechercher/Remplacer"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFindNext As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchTerm As System.Windows.Forms.TextBox
    Friend WithEvents LabelMot As System.Windows.Forms.Label
    Friend WithEvents txtReplacementText As System.Windows.Forms.TextBox
    Friend WithEvents LabelRemplacer As System.Windows.Forms.Label
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents btnReplaceAll As System.Windows.Forms.Button
    Friend WithEvents OpacityHScrollBar As HScrollBar
End Class
