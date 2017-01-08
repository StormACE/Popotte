<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgInfoRecette
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgInfoRecette))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.NomTextBox = New System.Windows.Forms.TextBox()
        Me.NoteComboBox = New System.Windows.Forms.ComboBox()
        Me.DescTextBox = New System.Windows.Forms.TextBox()
        Me.LabelRecette = New System.Windows.Forms.Label()
        Me.LabelNote = New System.Windows.Forms.Label()
        Me.LabelDesc = New System.Windows.Forms.Label()
        Me.LabelLivre = New System.Windows.Forms.Label()
        Me.ComboBoxLivre = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Location = New System.Drawing.Point(502, 265)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(111, 37)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = "Annuler"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK_Button.Location = New System.Drawing.Point(380, 265)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(111, 37)
        Me.OK_Button.TabIndex = 4
        Me.OK_Button.Text = "OK"
        '
        'NomTextBox
        '
        Me.NomTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.NomTextBox.Location = New System.Drawing.Point(20, 47)
        Me.NomTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.Size = New System.Drawing.Size(591, 29)
        Me.NomTextBox.TabIndex = 0
        '
        'NoteComboBox
        '
        Me.NoteComboBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.NoteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NoteComboBox.FormattingEnabled = True
        Me.NoteComboBox.Location = New System.Drawing.Point(380, 129)
        Me.NoteComboBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NoteComboBox.Name = "NoteComboBox"
        Me.NoteComboBox.Size = New System.Drawing.Size(231, 29)
        Me.NoteComboBox.TabIndex = 2
        '
        'DescTextBox
        '
        Me.DescTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DescTextBox.Location = New System.Drawing.Point(20, 208)
        Me.DescTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DescTextBox.Name = "DescTextBox"
        Me.DescTextBox.Size = New System.Drawing.Size(591, 29)
        Me.DescTextBox.TabIndex = 3
        '
        'LabelRecette
        '
        Me.LabelRecette.AutoSize = True
        Me.LabelRecette.Location = New System.Drawing.Point(16, 21)
        Me.LabelRecette.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecette.Name = "LabelRecette"
        Me.LabelRecette.Size = New System.Drawing.Size(158, 21)
        Me.LabelRecette.TabIndex = 5
        Me.LabelRecette.Text = "Nom de la Recette :"
        '
        'LabelNote
        '
        Me.LabelNote.AutoSize = True
        Me.LabelNote.Location = New System.Drawing.Point(376, 103)
        Me.LabelNote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Size = New System.Drawing.Size(56, 21)
        Me.LabelNote.TabIndex = 6
        Me.LabelNote.Text = "Note :"
        '
        'LabelDesc
        '
        Me.LabelDesc.AutoSize = True
        Me.LabelDesc.Location = New System.Drawing.Point(16, 182)
        Me.LabelDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDesc.Name = "LabelDesc"
        Me.LabelDesc.Size = New System.Drawing.Size(106, 21)
        Me.LabelDesc.TabIndex = 7
        Me.LabelDesc.Text = "Description :"
        '
        'LabelLivre
        '
        Me.LabelLivre.AutoSize = True
        Me.LabelLivre.Location = New System.Drawing.Point(16, 103)
        Me.LabelLivre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelLivre.Name = "LabelLivre"
        Me.LabelLivre.Size = New System.Drawing.Size(55, 21)
        Me.LabelLivre.TabIndex = 8
        Me.LabelLivre.Text = "Livre :"
        '
        'ComboBoxLivre
        '
        Me.ComboBoxLivre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxLivre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxLivre.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ComboBoxLivre.DropDownHeight = 118
        Me.ComboBoxLivre.FormattingEnabled = True
        Me.ComboBoxLivre.IntegralHeight = False
        Me.ComboBoxLivre.Location = New System.Drawing.Point(20, 129)
        Me.ComboBoxLivre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBoxLivre.Name = "ComboBoxLivre"
        Me.ComboBoxLivre.Size = New System.Drawing.Size(347, 29)
        Me.ComboBoxLivre.Sorted = True
        Me.ComboBoxLivre.TabIndex = 1
        '
        'dlgInfoRecette
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(636, 321)
        Me.Controls.Add(Me.ComboBoxLivre)
        Me.Controls.Add(Me.LabelLivre)
        Me.Controls.Add(Me.LabelDesc)
        Me.Controls.Add(Me.LabelNote)
        Me.Controls.Add(Me.LabelRecette)
        Me.Controls.Add(Me.DescTextBox)
        Me.Controls.Add(Me.NoteComboBox)
        Me.Controls.Add(Me.NomTextBox)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgInfoRecette"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Popotte - Modifier les Infos de la Recette"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NoteComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DescTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LabelRecette As System.Windows.Forms.Label
    Friend WithEvents LabelNote As System.Windows.Forms.Label
    Friend WithEvents LabelDesc As System.Windows.Forms.Label
    Friend WithEvents LabelLivre As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLivre As System.Windows.Forms.ComboBox

End Class
