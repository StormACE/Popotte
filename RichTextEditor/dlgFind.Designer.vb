<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgFind))
        Me.LabelMot = New System.Windows.Forms.Label()
        Me.txtSearchTerm = New System.Windows.Forms.TextBox()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnFindNext = New System.Windows.Forms.Button()
        Me.OpacityHScrollBar = New System.Windows.Forms.HScrollBar()
        Me.SuspendLayout()
        '
        'LabelMot
        '
        Me.LabelMot.AutoSize = True
        Me.LabelMot.Location = New System.Drawing.Point(22, 21)
        Me.LabelMot.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelMot.Name = "LabelMot"
        Me.LabelMot.Size = New System.Drawing.Size(73, 21)
        Me.LabelMot.TabIndex = 0
        Me.LabelMot.Text = "Mot Clé:"
        '
        'txtSearchTerm
        '
        Me.txtSearchTerm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtSearchTerm.Location = New System.Drawing.Point(27, 47)
        Me.txtSearchTerm.Margin = New System.Windows.Forms.Padding(5)
        Me.txtSearchTerm.Name = "txtSearchTerm"
        Me.txtSearchTerm.Size = New System.Drawing.Size(417, 29)
        Me.txtSearchTerm.TabIndex = 1
        '
        'chkMatchCase
        '
        Me.chkMatchCase.AutoSize = True
        Me.chkMatchCase.BackColor = System.Drawing.SystemColors.Control
        Me.chkMatchCase.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkMatchCase.Location = New System.Drawing.Point(27, 100)
        Me.chkMatchCase.Margin = New System.Windows.Forms.Padding(5)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(220, 26)
        Me.chkMatchCase.TabIndex = 4
        Me.chkMatchCase.Text = "Sensible aux Majuscules"
        Me.chkMatchCase.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFind.Location = New System.Drawing.Point(457, 47)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(5)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(125, 34)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "&Rechercher"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnFindNext
        '
        Me.btnFindNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindNext.Location = New System.Drawing.Point(457, 100)
        Me.btnFindNext.Margin = New System.Windows.Forms.Padding(5)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(125, 34)
        Me.btnFindNext.TabIndex = 3
        Me.btnFindNext.Text = "&Suivant"
        Me.btnFindNext.UseVisualStyleBackColor = True
        '
        'OpacityHScrollBar
        '
        Me.OpacityHScrollBar.Location = New System.Drawing.Point(27, 150)
        Me.OpacityHScrollBar.Name = "OpacityHScrollBar"
        Me.OpacityHScrollBar.Size = New System.Drawing.Size(555, 26)
        Me.OpacityHScrollBar.TabIndex = 5
        '
        'dlgFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(602, 199)
        Me.Controls.Add(Me.OpacityHScrollBar)
        Me.Controls.Add(Me.btnFindNext)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.chkMatchCase)
        Me.Controls.Add(Me.txtSearchTerm)
        Me.Controls.Add(Me.LabelMot)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgFind"
        Me.ShowInTaskbar = False
        Me.Text = "Popotte - Rechercher"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelMot As System.Windows.Forms.Label
    Friend WithEvents txtSearchTerm As System.Windows.Forms.TextBox
    Friend WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnFindNext As System.Windows.Forms.Button
    Friend WithEvents OpacityHScrollBar As HScrollBar
End Class
