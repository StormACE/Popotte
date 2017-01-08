<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSave))
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxNouveauDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxNouveauNote = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxNouveauNomRecette = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxNouveauNomLivre = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBoxNote = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxNomRecette = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxLivres = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBoxNouveauLivre = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLivreExistant = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSave
        '
        Me.ButtonSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonSave.Location = New System.Drawing.Point(183, 257)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(85, 31)
        Me.ButtonSave.TabIndex = 10
        Me.ButtonSave.Text = "Sauvegarder"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(295, 257)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(85, 31)
        Me.ButtonCancel.TabIndex = 11
        Me.ButtonCancel.Text = "Annuler"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxNouveauDescription)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ComboBoxNouveauNote)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxNouveauNomRecette)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBoxNouveauNomLivre)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 226)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'TextBoxNouveauDescription
        '
        Me.TextBoxNouveauDescription.Location = New System.Drawing.Point(18, 180)
        Me.TextBoxNouveauDescription.Name = "TextBoxNouveauDescription"
        Me.TextBoxNouveauDescription.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxNouveauDescription.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Description :"
        '
        'ComboBoxNouveauNote
        '
        Me.ComboBoxNouveauNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNouveauNote.FormattingEnabled = True
        Me.ComboBoxNouveauNote.Location = New System.Drawing.Point(18, 135)
        Me.ComboBoxNouveauNote.Name = "ComboBoxNouveauNote"
        Me.ComboBoxNouveauNote.Size = New System.Drawing.Size(140, 21)
        Me.ComboBoxNouveauNote.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Note :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nom de la Recette :"
        '
        'TextBoxNouveauNomRecette
        '
        Me.TextBoxNouveauNomRecette.Location = New System.Drawing.Point(18, 91)
        Me.TextBoxNouveauNomRecette.Name = "TextBoxNouveauNomRecette"
        Me.TextBoxNouveauNomRecette.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxNouveauNomRecette.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nom du Livre :"
        '
        'TextBoxNouveauNomLivre
        '
        Me.TextBoxNouveauNomLivre.Location = New System.Drawing.Point(18, 48)
        Me.TextBoxNouveauNomLivre.Name = "TextBoxNouveauNomLivre"
        Me.TextBoxNouveauNomLivre.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxNouveauNomLivre.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxDescription)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ComboBoxNote)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBoxNomRecette)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ComboBoxLivres)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(295, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(253, 226)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(18, 180)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxDescription.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Description :"
        '
        'ComboBoxNote
        '
        Me.ComboBoxNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNote.FormattingEnabled = True
        Me.ComboBoxNote.Location = New System.Drawing.Point(18, 135)
        Me.ComboBoxNote.Name = "ComboBoxNote"
        Me.ComboBoxNote.Size = New System.Drawing.Size(140, 21)
        Me.ComboBoxNote.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Note :"
        '
        'TextBoxNomRecette
        '
        Me.TextBoxNomRecette.Location = New System.Drawing.Point(18, 91)
        Me.TextBoxNomRecette.Name = "TextBoxNomRecette"
        Me.TextBoxNomRecette.Size = New System.Drawing.Size(217, 20)
        Me.TextBoxNomRecette.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Nom de la Recette :"
        '
        'ComboBoxLivres
        '
        Me.ComboBoxLivres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLivres.FormattingEnabled = True
        Me.ComboBoxLivres.Location = New System.Drawing.Point(18, 48)
        Me.ComboBoxLivres.Name = "ComboBoxLivres"
        Me.ComboBoxLivres.Size = New System.Drawing.Size(140, 21)
        Me.ComboBoxLivres.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Livre :"
        '
        'CheckBoxNouveauLivre
        '
        Me.CheckBoxNouveauLivre.AutoSize = True
        Me.CheckBoxNouveauLivre.Location = New System.Drawing.Point(33, 14)
        Me.CheckBoxNouveauLivre.Name = "CheckBoxNouveauLivre"
        Me.CheckBoxNouveauLivre.Size = New System.Drawing.Size(139, 17)
        Me.CheckBoxNouveauLivre.TabIndex = 0
        Me.CheckBoxNouveauLivre.Text = "Dans un Nouveau Livre"
        Me.CheckBoxNouveauLivre.UseVisualStyleBackColor = True
        '
        'CheckBoxLivreExistant
        '
        Me.CheckBoxLivreExistant.AutoSize = True
        Me.CheckBoxLivreExistant.Location = New System.Drawing.Point(313, 14)
        Me.CheckBoxLivreExistant.Name = "CheckBoxLivreExistant"
        Me.CheckBoxLivreExistant.Size = New System.Drawing.Size(132, 17)
        Me.CheckBoxLivreExistant.TabIndex = 1
        Me.CheckBoxLivreExistant.Text = "Dans un Livre Existant"
        Me.CheckBoxLivreExistant.UseVisualStyleBackColor = True
        '
        'frmSave
        '
        Me.AcceptButton = Me.ButtonSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(563, 300)
        Me.Controls.Add(Me.CheckBoxLivreExistant)
        Me.Controls.Add(Me.CheckBoxNouveauLivre)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSave"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Popotte - Sauvegarder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxNouveauDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNouveauNote As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNouveauNomRecette As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNouveauNomLivre As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxNote As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomRecette As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLivres As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxNouveauLivre As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLivreExistant As System.Windows.Forms.CheckBox

End Class
