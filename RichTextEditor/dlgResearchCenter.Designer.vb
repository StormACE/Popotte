<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResearchCenter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResearchCenter))
        Me.ADD_Button = New System.Windows.Forms.Button()
        Me.ListViewRC = New System.Windows.Forms.ListView()
        Me.DEL_Button = New System.Windows.Forms.Button()
        Me.TextBoxSite = New System.Windows.Forms.TextBox()
        Me.LabelNom = New System.Windows.Forms.Label()
        Me.TextBoxCom = New System.Windows.Forms.TextBox()
        Me.LabelCom = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ADD_Button
        '
        Me.ADD_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ADD_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ADD_Button.Location = New System.Drawing.Point(589, 402)
        Me.ADD_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ADD_Button.Name = "ADD_Button"
        Me.ADD_Button.Size = New System.Drawing.Size(111, 37)
        Me.ADD_Button.TabIndex = 2
        Me.ADD_Button.Text = "Ajouter"
        '
        'ListViewRC
        '
        Me.ListViewRC.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListViewRC.Location = New System.Drawing.Point(22, 21)
        Me.ListViewRC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListViewRC.Name = "ListViewRC"
        Me.ListViewRC.ShowItemToolTips = True
        Me.ListViewRC.Size = New System.Drawing.Size(681, 349)
        Me.ListViewRC.TabIndex = 3
        Me.ListViewRC.UseCompatibleStateImageBehavior = False
        '
        'DEL_Button
        '
        Me.DEL_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DEL_Button.Location = New System.Drawing.Point(589, 444)
        Me.DEL_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DEL_Button.Name = "DEL_Button"
        Me.DEL_Button.Size = New System.Drawing.Size(111, 37)
        Me.DEL_Button.TabIndex = 4
        Me.DEL_Button.Text = "Enlever"
        Me.DEL_Button.UseVisualStyleBackColor = True
        '
        'TextBoxSite
        '
        Me.TextBoxSite.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxSite.Location = New System.Drawing.Point(144, 405)
        Me.TextBoxSite.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxSite.Name = "TextBoxSite"
        Me.TextBoxSite.Size = New System.Drawing.Size(428, 29)
        Me.TextBoxSite.TabIndex = 0
        '
        'LabelNom
        '
        Me.LabelNom.AutoSize = True
        Me.LabelNom.Location = New System.Drawing.Point(17, 410)
        Me.LabelNom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelNom.Name = "LabelNom"
        Me.LabelNom.Size = New System.Drawing.Size(113, 21)
        Me.LabelNom.TabIndex = 4
        Me.LabelNom.Text = "Nom du Site :"
        '
        'TextBoxCom
        '
        Me.TextBoxCom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TextBoxCom.Location = New System.Drawing.Point(144, 447)
        Me.TextBoxCom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBoxCom.Name = "TextBoxCom"
        Me.TextBoxCom.Size = New System.Drawing.Size(428, 29)
        Me.TextBoxCom.TabIndex = 1
        '
        'LabelCom
        '
        Me.LabelCom.AutoSize = True
        Me.LabelCom.Location = New System.Drawing.Point(24, 452)
        Me.LabelCom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCom.Name = "LabelCom"
        Me.LabelCom.Size = New System.Drawing.Size(106, 21)
        Me.LabelCom.TabIndex = 6
        Me.LabelCom.Text = "Commande :"
        '
        'ResearchCenter
        '
        Me.AcceptButton = Me.ADD_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(144.0!, 144.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(724, 509)
        Me.Controls.Add(Me.LabelCom)
        Me.Controls.Add(Me.TextBoxCom)
        Me.Controls.Add(Me.LabelNom)
        Me.Controls.Add(Me.TextBoxSite)
        Me.Controls.Add(Me.DEL_Button)
        Me.Controls.Add(Me.ADD_Button)
        Me.Controls.Add(Me.ListViewRC)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ResearchCenter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Popotte - Centre de Recherche"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ADD_Button As System.Windows.Forms.Button
    Friend WithEvents ListViewRC As System.Windows.Forms.ListView
    Friend WithEvents DEL_Button As System.Windows.Forms.Button
    Friend WithEvents TextBoxSite As System.Windows.Forms.TextBox
    Friend WithEvents LabelNom As System.Windows.Forms.Label
    Friend WithEvents TextBoxCom As System.Windows.Forms.TextBox
    Friend WithEvents LabelCom As System.Windows.Forms.Label

End Class
