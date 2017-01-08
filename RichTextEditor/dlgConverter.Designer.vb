<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgConverter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgConverter))
        Me.Close_Button = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ConverterComboBox = New System.Windows.Forms.ComboBox()
        Me.LabelIn = New System.Windows.Forms.Label()
        Me.LabelConv = New System.Windows.Forms.Label()
        Me.LabelOut = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Close_Button
        '
        Me.Close_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Close_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Close_Button.Location = New System.Drawing.Point(407, 147)
        Me.Close_Button.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Close_Button.Name = "Close_Button"
        Me.Close_Button.Size = New System.Drawing.Size(112, 37)
        Me.Close_Button.TabIndex = 4
        Me.Close_Button.Text = "Fermer"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox2.Location = New System.Drawing.Point(407, 69)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(110, 29)
        Me.TextBox2.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox1.Location = New System.Drawing.Point(20, 69)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(110, 29)
        Me.TextBox1.TabIndex = 1
        '
        'ConverterComboBox
        '
        Me.ConverterComboBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ConverterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConverterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ConverterComboBox.FormattingEnabled = True
        Me.ConverterComboBox.Location = New System.Drawing.Point(142, 69)
        Me.ConverterComboBox.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.ConverterComboBox.Name = "ConverterComboBox"
        Me.ConverterComboBox.Size = New System.Drawing.Size(252, 29)
        Me.ConverterComboBox.TabIndex = 2
        '
        'LabelIn
        '
        Me.LabelIn.AutoSize = True
        Me.LabelIn.Location = New System.Drawing.Point(16, 43)
        Me.LabelIn.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LabelIn.Name = "LabelIn"
        Me.LabelIn.Size = New System.Drawing.Size(67, 21)
        Me.LabelIn.TabIndex = 6
        Me.LabelIn.Text = "Entrée :"
        '
        'LabelConv
        '
        Me.LabelConv.AutoSize = True
        Me.LabelConv.Location = New System.Drawing.Point(138, 44)
        Me.LabelConv.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LabelConv.Name = "LabelConv"
        Me.LabelConv.Size = New System.Drawing.Size(103, 21)
        Me.LabelConv.TabIndex = 7
        Me.LabelConv.Text = "Convertion :"
        '
        'LabelOut
        '
        Me.LabelOut.AutoSize = True
        Me.LabelOut.Location = New System.Drawing.Point(403, 44)
        Me.LabelOut.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LabelOut.Name = "LabelOut"
        Me.LabelOut.Size = New System.Drawing.Size(63, 21)
        Me.LabelOut.TabIndex = 8
        Me.LabelOut.Text = "Sortie :"
        '
        'dlgConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.CancelButton = Me.Close_Button
        Me.ClientSize = New System.Drawing.Size(538, 204)
        Me.Controls.Add(Me.LabelOut)
        Me.Controls.Add(Me.LabelConv)
        Me.Controls.Add(Me.LabelIn)
        Me.Controls.Add(Me.ConverterComboBox)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Close_Button)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgConverter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Popotte - Convertisseur"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Close_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ConverterComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LabelIn As System.Windows.Forms.Label
    Friend WithEvents LabelConv As System.Windows.Forms.Label
    Friend WithEvents LabelOut As System.Windows.Forms.Label

End Class
