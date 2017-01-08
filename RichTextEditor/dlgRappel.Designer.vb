<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RappelDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RappelDialog))
        Me.DelayLabel = New System.Windows.Forms.Label()
        Me.DelayTextBox = New System.Windows.Forms.TextBox()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DeactivateButton = New System.Windows.Forms.Button()
        Me.ActivateButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DelayLabel
        '
        Me.DelayLabel.Location = New System.Drawing.Point(94, 23)
        Me.DelayLabel.Name = "DelayLabel"
        Me.DelayLabel.Size = New System.Drawing.Size(286, 36)
        Me.DelayLabel.TabIndex = 1
        Me.DelayLabel.Text = "Delais en secs  :"
        Me.DelayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DelayTextBox
        '
        Me.DelayTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DelayTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DelayTextBox.Location = New System.Drawing.Point(98, 62)
        Me.DelayTextBox.Name = "DelayTextBox"
        Me.DelayTextBox.Size = New System.Drawing.Size(286, 39)
        Me.DelayTextBox.TabIndex = 1
        '
        'Cancel_Button
        '
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Location = New System.Drawing.Point(362, 130)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(112, 42)
        Me.Cancel_Button.TabIndex = 4
        Me.Cancel_Button.Text = "Annuler"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'DeactivateButton
        '
        Me.DeactivateButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DeactivateButton.Location = New System.Drawing.Point(243, 130)
        Me.DeactivateButton.Name = "DeactivateButton"
        Me.DeactivateButton.Size = New System.Drawing.Size(112, 42)
        Me.DeactivateButton.TabIndex = 3
        Me.DeactivateButton.Text = "Déactivé"
        Me.DeactivateButton.UseVisualStyleBackColor = True
        '
        'ActivateButton
        '
        Me.ActivateButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ActivateButton.Location = New System.Drawing.Point(124, 130)
        Me.ActivateButton.Name = "ActivateButton"
        Me.ActivateButton.Size = New System.Drawing.Size(112, 42)
        Me.ActivateButton.TabIndex = 0
        Me.ActivateButton.Text = "Activé"
        Me.ActivateButton.UseVisualStyleBackColor = True
        '
        'RappelDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(490, 185)
        Me.Controls.Add(Me.ActivateButton)
        Me.Controls.Add(Me.DeactivateButton)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.DelayTextBox)
        Me.Controls.Add(Me.DelayLabel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RappelDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rappel de sauvegarde"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DelayLabel As Label
    Friend WithEvents DelayTextBox As TextBox
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents DeactivateButton As Button
    Friend WithEvents ActivateButton As Button
End Class
