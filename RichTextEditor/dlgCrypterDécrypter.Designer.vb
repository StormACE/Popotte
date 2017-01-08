<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCrypterDécrypter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgCrypterDécrypter))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.LabelMotdePasse = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBoxCrypt = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDeCrypt = New System.Windows.Forms.CheckBox()
        Me.TextBoxSel = New System.Windows.Forms.TextBox()
        Me.LabelSalt = New System.Windows.Forms.Label()
        Me.TextBoxIteration = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxVerifyPass = New System.Windows.Forms.TextBox()
        Me.LabelVerifyPass = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(238, 322)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(243, 47)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK_Button.Location = New System.Drawing.Point(6, 5)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(109, 37)
        Me.OK_Button.TabIndex = 2
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Location = New System.Drawing.Point(127, 5)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(110, 37)
        Me.Cancel_Button.TabIndex = 3
        Me.Cancel_Button.Text = "Annuler"
        '
        'LabelMotdePasse
        '
        Me.LabelMotdePasse.AutoSize = True
        Me.LabelMotdePasse.Location = New System.Drawing.Point(22, 21)
        Me.LabelMotdePasse.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LabelMotdePasse.Name = "LabelMotdePasse"
        Me.LabelMotdePasse.Size = New System.Drawing.Size(118, 21)
        Me.LabelMotdePasse.TabIndex = 1
        Me.LabelMotdePasse.Text = "Mot de passe :"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBox1.Location = New System.Drawing.Point(26, 47)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(457, 29)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.UseSystemPasswordChar = True
        '
        'CheckBoxCrypt
        '
        Me.CheckBoxCrypt.AutoSize = True
        Me.CheckBoxCrypt.Checked = True
        Me.CheckBoxCrypt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCrypt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxCrypt.Location = New System.Drawing.Point(26, 272)
        Me.CheckBoxCrypt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.CheckBoxCrypt.Name = "CheckBoxCrypt"
        Me.CheckBoxCrypt.Size = New System.Drawing.Size(92, 26)
        Me.CheckBoxCrypt.TabIndex = 4
        Me.CheckBoxCrypt.Text = "Crypter"
        Me.CheckBoxCrypt.UseVisualStyleBackColor = True
        '
        'CheckBoxDeCrypt
        '
        Me.CheckBoxDeCrypt.AutoSize = True
        Me.CheckBoxDeCrypt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxDeCrypt.Location = New System.Drawing.Point(125, 273)
        Me.CheckBoxDeCrypt.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.CheckBoxDeCrypt.Name = "CheckBoxDeCrypt"
        Me.CheckBoxDeCrypt.Size = New System.Drawing.Size(111, 26)
        Me.CheckBoxDeCrypt.TabIndex = 5
        Me.CheckBoxDeCrypt.Text = "Décrypter"
        Me.CheckBoxDeCrypt.UseVisualStyleBackColor = True
        '
        'TextBoxSel
        '
        Me.TextBoxSel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxSel.Location = New System.Drawing.Point(26, 204)
        Me.TextBoxSel.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.TextBoxSel.Name = "TextBoxSel"
        Me.TextBoxSel.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxSel.Size = New System.Drawing.Size(457, 29)
        Me.TextBoxSel.TabIndex = 0
        Me.TextBoxSel.TabStop = False
        Me.TextBoxSel.Text = "U9N!nvikY87gT#Hb"
        '
        'LabelSalt
        '
        Me.LabelSalt.AutoSize = True
        Me.LabelSalt.Location = New System.Drawing.Point(22, 177)
        Me.LabelSalt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LabelSalt.Name = "LabelSalt"
        Me.LabelSalt.Size = New System.Drawing.Size(146, 21)
        Me.LabelSalt.TabIndex = 5
        Me.LabelSalt.Text = "Une Pincée de Sel"
        '
        'TextBoxIteration
        '
        Me.TextBoxIteration.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxIteration.Location = New System.Drawing.Point(365, 272)
        Me.TextBoxIteration.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxIteration.Name = "TextBoxIteration"
        Me.TextBoxIteration.ShortcutsEnabled = False
        Me.TextBoxIteration.Size = New System.Drawing.Size(111, 29)
        Me.TextBoxIteration.TabIndex = 6
        Me.TextBoxIteration.Text = "7"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(260, 276)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Itérations :"
        '
        'TextBoxVerifyPass
        '
        Me.TextBoxVerifyPass.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxVerifyPass.Location = New System.Drawing.Point(26, 125)
        Me.TextBoxVerifyPass.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxVerifyPass.Name = "TextBoxVerifyPass"
        Me.TextBoxVerifyPass.Size = New System.Drawing.Size(457, 29)
        Me.TextBoxVerifyPass.TabIndex = 1
        Me.TextBoxVerifyPass.UseSystemPasswordChar = True
        '
        'LabelVerifyPass
        '
        Me.LabelVerifyPass.AutoSize = True
        Me.LabelVerifyPass.Location = New System.Drawing.Point(22, 101)
        Me.LabelVerifyPass.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelVerifyPass.Name = "LabelVerifyPass"
        Me.LabelVerifyPass.Size = New System.Drawing.Size(196, 21)
        Me.LabelVerifyPass.TabIndex = 9
        Me.LabelVerifyPass.Text = "Vérifier le mot de passe :"
        '
        'dlgCrypterDécrypter
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(502, 388)
        Me.Controls.Add(Me.LabelVerifyPass)
        Me.Controls.Add(Me.TextBoxVerifyPass)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxIteration)
        Me.Controls.Add(Me.LabelSalt)
        Me.Controls.Add(Me.TextBoxSel)
        Me.Controls.Add(Me.CheckBoxDeCrypt)
        Me.Controls.Add(Me.CheckBoxCrypt)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LabelMotdePasse)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCrypterDécrypter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Popotte - Crypter/Décrypter SHA1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LabelMotdePasse As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxCrypt As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDeCrypt As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxSel As TextBox
    Friend WithEvents LabelSalt As Label
    Friend WithEvents TextBoxIteration As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxVerifyPass As TextBox
    Friend WithEvents LabelVerifyPass As Label
End Class
