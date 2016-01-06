<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BombsTb = New System.Windows.Forms.TextBox()
        Me.RowsTb = New System.Windows.Forms.TextBox()
        Me.ColTb = New System.Windows.Forms.TextBox()
        Me.LoadGame = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BombsLb = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BombsTb
        '
        Me.BombsTb.Enabled = False
        Me.BombsTb.Location = New System.Drawing.Point(47, 212)
        Me.BombsTb.Name = "BombsTb"
        Me.BombsTb.Size = New System.Drawing.Size(100, 20)
        Me.BombsTb.TabIndex = 0
        '
        'RowsTb
        '
        Me.RowsTb.Location = New System.Drawing.Point(47, 139)
        Me.RowsTb.Name = "RowsTb"
        Me.RowsTb.Size = New System.Drawing.Size(100, 20)
        Me.RowsTb.TabIndex = 1
        '
        'ColTb
        '
        Me.ColTb.Location = New System.Drawing.Point(47, 57)
        Me.ColTb.Name = "ColTb"
        Me.ColTb.Size = New System.Drawing.Size(100, 20)
        Me.ColTb.TabIndex = 2
        '
        'LoadGame
        '
        Me.LoadGame.Enabled = False
        Me.LoadGame.Location = New System.Drawing.Point(23, 284)
        Me.LoadGame.Name = "LoadGame"
        Me.LoadGame.Size = New System.Drawing.Size(149, 132)
        Me.LoadGame.TabIndex = 3
        Me.LoadGame.Text = "Lock In"
        Me.LoadGame.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "No. Columns (5-15)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "No. Rows(5-15)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "No. Of Bombs"
        '
        'BombsLb
        '
        Me.BombsLb.AutoSize = True
        Me.BombsLb.Location = New System.Drawing.Point(80, 235)
        Me.BombsLb.Name = "BombsLb"
        Me.BombsLb.Size = New System.Drawing.Size(28, 13)
        Me.BombsLb.TabIndex = 7
        Me.BombsLb.Text = "(1-?)"
        '
        'LoadForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(198, 428)
        Me.Controls.Add(Me.BombsLb)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LoadGame)
        Me.Controls.Add(Me.ColTb)
        Me.Controls.Add(Me.RowsTb)
        Me.Controls.Add(Me.BombsTb)
        Me.Name = "LoadForm"
        Me.Text = "Load"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BombsTb As System.Windows.Forms.TextBox
    Friend WithEvents RowsTb As System.Windows.Forms.TextBox
    Friend WithEvents ColTb As System.Windows.Forms.TextBox
    Friend WithEvents LoadGame As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BombsLb As System.Windows.Forms.Label
End Class
