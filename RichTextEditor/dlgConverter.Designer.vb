﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Close_Button.Location = New System.Drawing.Point(271, 98)
        Me.Close_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Close_Button.Name = "Close_Button"
        Me.Close_Button.Size = New System.Drawing.Size(75, 25)
        Me.Close_Button.TabIndex = 4
        Me.Close_Button.Text = "Fermer"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox2.Location = New System.Drawing.Point(271, 46)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(75, 22)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.WordWrap = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox1.Location = New System.Drawing.Point(13, 46)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(75, 22)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.WordWrap = False
        '
        'ConverterComboBox
        '
        Me.ConverterComboBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ConverterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConverterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ConverterComboBox.FormattingEnabled = True
        Me.ConverterComboBox.Location = New System.Drawing.Point(95, 46)
        Me.ConverterComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ConverterComboBox.Name = "ConverterComboBox"
        Me.ConverterComboBox.Size = New System.Drawing.Size(169, 21)
        Me.ConverterComboBox.TabIndex = 2
        '
        'LabelIn
        '
        Me.LabelIn.AutoSize = True
        Me.LabelIn.Location = New System.Drawing.Point(11, 29)
        Me.LabelIn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelIn.Name = "LabelIn"
        Me.LabelIn.Size = New System.Drawing.Size(46, 13)
        Me.LabelIn.TabIndex = 6
        Me.LabelIn.Text = "Entrée :"
        '
        'LabelConv
        '
        Me.LabelConv.AutoSize = True
        Me.LabelConv.Location = New System.Drawing.Point(92, 29)
        Me.LabelConv.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelConv.Name = "LabelConv"
        Me.LabelConv.Size = New System.Drawing.Size(71, 13)
        Me.LabelConv.TabIndex = 7
        Me.LabelConv.Text = "Convertion :"
        '
        'LabelOut
        '
        Me.LabelOut.AutoSize = True
        Me.LabelOut.Location = New System.Drawing.Point(269, 29)
        Me.LabelOut.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelOut.Name = "LabelOut"
        Me.LabelOut.Size = New System.Drawing.Size(43, 13)
        Me.LabelOut.TabIndex = 8
        Me.LabelOut.Text = "Sortie :"
        '
        'dlgConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.CancelButton = Me.Close_Button
        Me.ClientSize = New System.Drawing.Size(359, 136)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
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
