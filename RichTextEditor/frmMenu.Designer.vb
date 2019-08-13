<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.LabelMonday = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListBoxSunday = New System.Windows.Forms.ListBox()
        Me.ListBoxMonday = New System.Windows.Forms.ListBox()
        Me.ListBoxTuesday = New System.Windows.Forms.ListBox()
        Me.ListBoxWednesday = New System.Windows.Forms.ListBox()
        Me.ListBoxThursday = New System.Windows.Forms.ListBox()
        Me.ListBoxFriday = New System.Windows.Forms.ListBox()
        Me.ListBoxSaturday = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ButtonClose
        '
        Me.ButtonClose.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClose.Location = New System.Drawing.Point(744, 695)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(94, 47)
        Me.ButtonClose.TabIndex = 7
        Me.ButtonClose.Text = "Fermer"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'LabelMonday
        '
        Me.LabelMonday.AutoSize = True
        Me.LabelMonday.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMonday.Location = New System.Drawing.Point(12, 148)
        Me.LabelMonday.Name = "LabelMonday"
        Me.LabelMonday.Size = New System.Drawing.Size(178, 54)
        Me.LabelMonday.TabIndex = 8
        Me.LabelMonday.Text = "Monday"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 54)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tuesday"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 326)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 54)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Wednesday"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 54)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Sunday"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 413)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 54)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Thursday"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 505)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 54)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Friday"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 593)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 54)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Saturday"
        '
        'ListBoxSunday
        '
        Me.ListBoxSunday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxSunday.FormattingEnabled = True
        Me.ListBoxSunday.ItemHeight = 28
        Me.ListBoxSunday.Location = New System.Drawing.Point(260, 57)
        Me.ListBoxSunday.Name = "ListBoxSunday"
        Me.ListBoxSunday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxSunday.TabIndex = 15
        '
        'ListBoxMonday
        '
        Me.ListBoxMonday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxMonday.FormattingEnabled = True
        Me.ListBoxMonday.ItemHeight = 28
        Me.ListBoxMonday.Location = New System.Drawing.Point(261, 148)
        Me.ListBoxMonday.Name = "ListBoxMonday"
        Me.ListBoxMonday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxMonday.TabIndex = 16
        '
        'ListBoxTuesday
        '
        Me.ListBoxTuesday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxTuesday.FormattingEnabled = True
        Me.ListBoxTuesday.ItemHeight = 28
        Me.ListBoxTuesday.Location = New System.Drawing.Point(261, 233)
        Me.ListBoxTuesday.Name = "ListBoxTuesday"
        Me.ListBoxTuesday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxTuesday.TabIndex = 17
        '
        'ListBoxWednesday
        '
        Me.ListBoxWednesday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxWednesday.FormattingEnabled = True
        Me.ListBoxWednesday.ItemHeight = 28
        Me.ListBoxWednesday.Location = New System.Drawing.Point(260, 326)
        Me.ListBoxWednesday.Name = "ListBoxWednesday"
        Me.ListBoxWednesday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxWednesday.TabIndex = 18
        '
        'ListBoxThursday
        '
        Me.ListBoxThursday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxThursday.FormattingEnabled = True
        Me.ListBoxThursday.ItemHeight = 28
        Me.ListBoxThursday.Location = New System.Drawing.Point(260, 413)
        Me.ListBoxThursday.Name = "ListBoxThursday"
        Me.ListBoxThursday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxThursday.TabIndex = 19
        '
        'ListBoxFriday
        '
        Me.ListBoxFriday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxFriday.FormattingEnabled = True
        Me.ListBoxFriday.ItemHeight = 28
        Me.ListBoxFriday.Location = New System.Drawing.Point(260, 505)
        Me.ListBoxFriday.Name = "ListBoxFriday"
        Me.ListBoxFriday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxFriday.TabIndex = 20
        '
        'ListBoxSaturday
        '
        Me.ListBoxSaturday.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxSaturday.FormattingEnabled = True
        Me.ListBoxSaturday.ItemHeight = 28
        Me.ListBoxSaturday.Location = New System.Drawing.Point(260, 593)
        Me.ListBoxSaturday.Name = "ListBoxSaturday"
        Me.ListBoxSaturday.Size = New System.Drawing.Size(577, 60)
        Me.ListBoxSaturday.TabIndex = 21
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 754)
        Me.Controls.Add(Me.ListBoxSaturday)
        Me.Controls.Add(Me.ListBoxFriday)
        Me.Controls.Add(Me.ListBoxThursday)
        Me.Controls.Add(Me.ListBoxWednesday)
        Me.Controls.Add(Me.ListBoxTuesday)
        Me.Controls.Add(Me.ListBoxMonday)
        Me.Controls.Add(Me.ListBoxSunday)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelMonday)
        Me.Controls.Add(Me.ButtonClose)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonClose As Button
    Friend WithEvents LabelMonday As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ListBoxSunday As ListBox
    Friend WithEvents ListBoxMonday As ListBox
    Friend WithEvents ListBoxTuesday As ListBox
    Friend WithEvents ListBoxWednesday As ListBox
    Friend WithEvents ListBoxThursday As ListBox
    Friend WithEvents ListBoxFriday As ListBox
    Friend WithEvents ListBoxSaturday As ListBox
End Class
