Public Class Main
    Dim myButtons As List(Of Button) = New List(Of Button)
    Dim Rows As Byte = Val(LoadForm.RowsTb.Text)
    Dim Columns As Byte = Val(LoadForm.ColTb.Text)
    Dim ColumnsLarge As Byte = Columns + 2
    Dim RowsLarge As Byte = Rows + 2
    Dim NoSq As Byte = (Rows * Columns)
    Dim NoSqLarge As Single = (Rows + 2) * (Columns + 2)
    Dim NoBombs As Byte = Val(LoadForm.BombsTb.Text)
    Dim field(NoSq) As Integer
    Dim LargeField(NoSqLarge)
    Dim FieldValue(NoSqLarge) As String
    Function NormToLarge(ByVal pos As Integer)
        Return (Math.Ceiling(pos / Columns) * 2) + pos + (Columns + 1)
    End Function
    Function LargeToNorm(ByVal pos As Integer)
        Return (pos - (Columns - 1) - (Math.Ceiling(pos / (Columns + 2)) * 2))
    End Function
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        createbuttons()
        createfield()
        ' creates the dynamic buttons events
        For Each btn As Button In myButtons
            AddHandler btn.Click, AddressOf myButton_Click
            AddHandler btn.MouseDown, AddressOf myButton_MouseDown
        Next

        For i = 1 To (NoSq)
            Dim pos As Integer
            pos = ((Math.Ceiling(i / Columns) * 2) + i + (Columns + 1))
            'myButtons(i - 1).Text = FieldValue(pos)
            'MsgBox(FieldValue(pos))
        Next

    End Sub
    Private Sub myButton_MouseDown(sender As Object, e As MouseEventArgs)
        ' this entire event handle is used to flag a potential square as a bomb
        Dim btn As Button = DirectCast(sender, Button)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If btn.BackColor = Color.White Then
                btn.BackColor = Color.Black
            Else
                btn.BackColor = Color.White
            End If
        End If
    End Sub
    Private Sub myButton_Click(ByVal sender As Object, ByVal e As EventArgs)


        ' used to determine which button has been clicked
        Dim btn As Button = DirectCast(sender, Button)
        ' disabled the button so it cant be pressed again
        'MsgBox(btn.TabIndex)
        btn.Enabled = False
        ' works out the posistion of the button on field
        Dim Normpos As Byte
        Normpos = btn.Name
        'converts the posistion on field to larger field
        Dim posLarge = NormToLarge(Normpos)
        btn.Text = FieldValue(posLarge)
        ' chooses what to do to the button depending on what the outcome is
        Select Case btn.Text
            Case " 0"
                removespaces(Normpos)
            Case " 1"
                btn.BackColor = Color.LightBlue
            Case " 2"
                btn.BackColor = Color.LightGreen
            Case " 3"
                btn.BackColor = Color.LightCoral
            Case " 4"
                btn.BackColor = Color.Khaki
            Case " 5"
                btn.BackColor = Color.Red
            Case " 6"
                btn.BackColor = Color.Green
            Case " 7"
                btn.BackColor = Color.Gray
            Case " 8"
                btn.BackColor = Color.Yellow
            Case ""
                searchforbombs()
                MsgBox("Game over :/ close this box to end the game")
                reset()
                'Timer1.Enabled = False
        End Select
        endgamecheck()
    End Sub
    Sub createfield()
        'Randomly generates the bombs posistions on the board.
        Randomize()
        For i = 1 To NoBombs
            Dim pos = 1 + Int(Rnd() * NoSq)
            'MsgBox(pos)
            If field(pos) = True Then
                i -= 1
            Else
                field(pos) = True
            End If
        Next
        'converts the smaller board into the larger board so we can more easily detect for bombs 
        For i = 1 To NoSq
            Dim pos
            pos = NormToLarge(i)
            'MsgBox(pos)
            'MsgBox(i)
            LargeField(pos) = field(i)
        Next
        ' searches around to calculate the numbers on the board used to indicate where the bombs are to the user.
        For i = (Columns + 4) To NoSqLarge - (Columns + 3)
            Dim count = 0
            If LargeField(i - ColumnsLarge) = True Then
                count += 1
            End If
            If LargeField(i + ColumnsLarge) = True Then
                count += 1
            End If
            If LargeField(i - 1) = True Then
                count += 1
            End If
            If LargeField(i + 1) = True Then
                count += 1
            End If
            If LargeField(i - (ColumnsLarge - 1)) = True Then
                count += 1
            End If
            If LargeField(i + (ColumnsLarge - 1)) = True Then
                count += 1
            End If
            If LargeField(i - (ColumnsLarge + 1)) = True Then
                count += 1
            End If
            If LargeField(i + (ColumnsLarge + 1)) = True Then
                count += 1
            End If
            FieldValue(i) = Str(count)
            If LargeField(i) = True Then FieldValue(i) = ""
        Next

    End Sub
    Sub removespaces(ByVal pos1 As Integer)
        'MsgBox(pos1)

        Dim cases = 0
        If pos1 Mod Columns = 1 Then
            cases = 1
        End If
        If pos1 Mod Columns = 0 Then
            cases = 2
        End If
        If pos1 <= Columns Then
            If cases = 1 Then
                cases = 3
            ElseIf cases = 2 Then
                cases = 4
            Else
                cases = 5
            End If
        End If
        If pos1 > (NoSq - Columns) Then
            If cases = 1 Then
                cases = 6
            ElseIf cases = 2 Then
                cases = 7
            Else
                cases = 8
            End If
        End If
        'MsgBox(cases)
        pos1 -= 1
        Select Case cases

            Case 0
                Me.myButtons(pos1 - 1).PerformClick()
                Me.myButtons(pos1 + 1).PerformClick()
                Me.myButtons(pos1 - Columns).PerformClick()
                Me.myButtons(pos1 - (Columns - 1)).PerformClick()
                Me.myButtons(pos1 - (Columns + 1)).PerformClick()
                Me.myButtons(pos1 + Columns).PerformClick()
                Me.myButtons(pos1 + (Columns - 1)).PerformClick()
                Me.myButtons(pos1 + (Columns + 1)).PerformClick()
            Case 1
                Me.myButtons(pos1 + 1).PerformClick()
                Me.myButtons(pos1 + Columns).PerformClick()
                Me.myButtons(pos1 + (Columns + 1)).PerformClick()
                Me.myButtons(pos1 - Columns).PerformClick()
                Me.myButtons(pos1 - (Columns - 1)).PerformClick()
            Case 2
                Me.myButtons(pos1 - 1).PerformClick()
                Me.myButtons(pos1 + Columns).PerformClick()
                Me.myButtons(pos1 + (Columns - 1)).PerformClick()
                Me.myButtons(pos1 - Columns).PerformClick()
                Me.myButtons(pos1 - (Columns + 1)).PerformClick()
            Case 3
                Me.myButtons(pos1 + 1).PerformClick()
                Me.myButtons(pos1 + Columns).PerformClick()
                Me.myButtons(pos1 + (Columns + 1)).PerformClick()
            Case 4
                Me.myButtons(pos1 - 1).PerformClick()
                Me.myButtons(pos1 + Columns).PerformClick()
                Me.myButtons(pos1 + (Columns - 1)).PerformClick()
            Case 5
                Me.myButtons(pos1 - 1).PerformClick()
                Me.myButtons(pos1 + 1).PerformClick()
                Me.myButtons(pos1 + (Columns - 1)).PerformClick()
                Me.myButtons(pos1 + Columns).PerformClick()
                Me.myButtons(pos1 + (Columns + 1)).PerformClick()
            Case 6
                Me.myButtons(pos1 + 1).PerformClick()
                Me.myButtons(pos1 - Columns).PerformClick()
                Me.myButtons(pos1 - (Columns - 1)).PerformClick()
            Case 7
                Me.myButtons(pos1 - 1).PerformClick()
                Me.myButtons(pos1 - Columns).PerformClick()
                Me.myButtons(pos1 - (Columns + 1)).PerformClick()
            Case 8
                Me.myButtons(pos1 - 1).PerformClick()
                Me.myButtons(pos1 + 1).PerformClick()
                Me.myButtons(pos1 - (Columns - 1)).PerformClick()
                Me.myButtons(pos1 - Columns).PerformClick()
                Me.myButtons(pos1 - (Columns + 1)).PerformClick()
        End Select
    End Sub
    Sub searchforbombs()
        For i = Columns + 4 To NoSqLarge - (Columns + 3)
            If FieldValue(i) = "" Then
                Dim pos = LargeToNorm(i)
                'MsgBox(pos)
                myButtons(pos - 1).BackColor = Color.DarkRed
            End If
        Next
    End Sub
    Sub endgamecheck()
        Dim endgame = True
        For i = 1 To NoSq
            If field(i) <> -1 And myButtons(i - 1).Enabled = True Then
                endgame = False
            End If
        Next
        If endgame = True Then
            MsgBox("CONGRATULATIONS YOU WON!!!")
            Timer1.Enabled = False
            reset()
        End If
    End Sub
    Sub reset()
        For i = 0 To NoSq - 1
            myButtons(i).Enabled = True
            myButtons(i).Text = ""
            myButtons(i).BackColor = Color.White
            field(i + 1) = 0
        Next
        createfield()
        Label1.Text = Str(0)
        Timer1.Enabled = True
    End Sub
    Sub createbuttons()
        Dim width = Rows * 55 + 100
        Dim height = Columns * 55 + 115
        Me.Size = New Size(width, height)
        Dim count = 0
        For i = 1 To Rows
            For j = 1 To Columns
                count += 1
                Dim button As Button
                button = New Button
                With button
                    .Size = New Size(50, 50)
                    .Visible = True
                    .BackColor = Color.White
                    .Font = New Font("Verdana", 16)
                    .Location = New Point(i * 55, j * 52)
                    .Name = Str(count)
                End With
                myButtons.Add(button)
                Me.Controls.Add(button)
            Next

        Next
        Label1.Top = 10
        Label1.Left = (Me.Width / 2) - (Label1.Width / 2)
        ResetBtn.Top = (Columns * 52) + 60
        ResetBtn.Left = (Me.Width / 2) - (ResetBtn.Width / 2)
    End Sub
    Private Sub ResetBtn_Click(sender As System.Object, e As System.EventArgs) Handles ResetBtn.Click
        Reset()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'used to keep track of time
        Label1.Text = Str(Val(Label1.Text) + 1)
    End Sub
End Class
