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
        Me.TextBoxPass = New System.Windows.Forms.TextBox()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(159, 215)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 31)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.OK_Button.Location = New System.Drawing.Point(4, 3)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(73, 25)
        Me.OK_Button.TabIndex = 8
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseCompatibleTextRendering = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Location = New System.Drawing.Point(85, 3)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(73, 25)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.Text = "Annuler"
        Me.Cancel_Button.UseCompatibleTextRendering = True
        '
        'LabelMotdePasse
        '
        Me.LabelMotdePasse.AutoSize = True
        Me.LabelMotdePasse.Location = New System.Drawing.Point(15, 14)
        Me.LabelMotdePasse.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelMotdePasse.Name = "LabelMotdePasse"
        Me.LabelMotdePasse.Size = New System.Drawing.Size(79, 19)
        Me.LabelMotdePasse.TabIndex = 0
        Me.LabelMotdePasse.Text = "Mot de passe :"
        Me.LabelMotdePasse.UseCompatibleTextRendering = True
        '
        'TextBoxPass
        '
        Me.TextBoxPass.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxPass.Location = New System.Drawing.Point(17, 31)
        Me.TextBoxPass.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBoxPass.Name = "TextBoxPass"
        Me.TextBoxPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPass.Size = New System.Drawing.Size(306, 22)
        Me.TextBoxPass.TabIndex = 1
        Me.TextBoxPass.UseSystemPasswordChar = True
        Me.TextBoxPass.WordWrap = False
        '
        'CheckBoxCrypt
        '
        Me.CheckBoxCrypt.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.CheckBoxCrypt.AutoSize = True
        Me.CheckBoxCrypt.Checked = True
        Me.CheckBoxCrypt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCrypt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxCrypt.Location = New System.Drawing.Point(17, 181)
        Me.CheckBoxCrypt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CheckBoxCrypt.Name = "CheckBoxCrypt"
        Me.CheckBoxCrypt.Size = New System.Drawing.Size(70, 18)
        Me.CheckBoxCrypt.TabIndex = 4
        Me.CheckBoxCrypt.Text = "Crypter"
        Me.CheckBoxCrypt.UseCompatibleTextRendering = True
        Me.CheckBoxCrypt.UseVisualStyleBackColor = True
        '
        'CheckBoxDeCrypt
        '
        Me.CheckBoxDeCrypt.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.CheckBoxDeCrypt.AutoSize = True
        Me.CheckBoxDeCrypt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBoxDeCrypt.Location = New System.Drawing.Point(83, 182)
        Me.CheckBoxDeCrypt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CheckBoxDeCrypt.Name = "CheckBoxDeCrypt"
        Me.CheckBoxDeCrypt.Size = New System.Drawing.Size(82, 18)
        Me.CheckBoxDeCrypt.TabIndex = 5
        Me.CheckBoxDeCrypt.Text = "Décrypter"
        Me.CheckBoxDeCrypt.UseCompatibleTextRendering = True
        Me.CheckBoxDeCrypt.UseVisualStyleBackColor = True
        '
        'TextBoxSel
        '
        Me.TextBoxSel.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.TextBoxSel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxSel.Location = New System.Drawing.Point(17, 136)
        Me.TextBoxSel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TextBoxSel.Name = "TextBoxSel"
        Me.TextBoxSel.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxSel.Size = New System.Drawing.Size(306, 22)
        Me.TextBoxSel.TabIndex = 3
        Me.TextBoxSel.Text = "U9N!nvikY87gT#Hb"
        Me.TextBoxSel.UseSystemPasswordChar = True
        Me.TextBoxSel.WordWrap = False
        '
        'LabelSalt
        '
        Me.LabelSalt.AutoSize = True
        Me.LabelSalt.Location = New System.Drawing.Point(15, 118)
        Me.LabelSalt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelSalt.Name = "LabelSalt"
        Me.LabelSalt.Size = New System.Drawing.Size(99, 13)
        Me.LabelSalt.TabIndex = 0
        Me.LabelSalt.Text = "Une Pincée de Sel"
        '
        'TextBoxIteration
        '
        Me.TextBoxIteration.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.TextBoxIteration.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxIteration.Location = New System.Drawing.Point(243, 181)
        Me.TextBoxIteration.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.TextBoxIteration.Name = "TextBoxIteration"
        Me.TextBoxIteration.ShortcutsEnabled = False
        Me.TextBoxIteration.Size = New System.Drawing.Size(75, 22)
        Me.TextBoxIteration.TabIndex = 6
        Me.TextBoxIteration.Text = "7"
        '
        'Label1
        '
        Me.Label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(173, 184)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Itérations :"
        Me.Label1.UseCompatibleTextRendering = True
        '
        'TextBoxVerifyPass
        '
        Me.TextBoxVerifyPass.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.TextBoxVerifyPass.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxVerifyPass.Location = New System.Drawing.Point(17, 83)
        Me.TextBoxVerifyPass.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.TextBoxVerifyPass.Name = "TextBoxVerifyPass"
        Me.TextBoxVerifyPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxVerifyPass.Size = New System.Drawing.Size(306, 22)
        Me.TextBoxVerifyPass.TabIndex = 2
        Me.TextBoxVerifyPass.UseSystemPasswordChar = True
        Me.TextBoxVerifyPass.WordWrap = False
        '
        'LabelVerifyPass
        '
        Me.LabelVerifyPass.AutoSize = True
        Me.LabelVerifyPass.Location = New System.Drawing.Point(15, 67)
        Me.LabelVerifyPass.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.LabelVerifyPass.Name = "LabelVerifyPass"
        Me.LabelVerifyPass.Size = New System.Drawing.Size(133, 13)
        Me.LabelVerifyPass.TabIndex = 0
        Me.LabelVerifyPass.Text = "Vérifier le mot de passe :"
        '
        'dlgCrypterDécrypter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(335, 259)
        Me.Controls.Add(Me.TextBoxPass)
        Me.Controls.Add(Me.LabelVerifyPass)
        Me.Controls.Add(Me.TextBoxVerifyPass)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxIteration)
        Me.Controls.Add(Me.LabelSalt)
        Me.Controls.Add(Me.TextBoxSel)
        Me.Controls.Add(Me.CheckBoxDeCrypt)
        Me.Controls.Add(Me.CheckBoxCrypt)
        Me.Controls.Add(Me.LabelMotdePasse)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
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
    Friend WithEvents TextBoxPass As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxCrypt As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDeCrypt As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxSel As TextBox
    Friend WithEvents LabelSalt As Label
    Friend WithEvents TextBoxIteration As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxVerifyPass As TextBox
    Friend WithEvents LabelVerifyPass As Label
End Class
