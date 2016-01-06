Public Class LoadForm
    Dim BombsMax = 0
    Private Sub LoadGame_Click(sender As System.Object, e As System.EventArgs) Handles LoadGame.Click
        Main.Show()
        Me.Hide()
    End Sub
    Function ValidInt(ByVal maxvalue As Integer, ByVal MinValue As Integer, ByVal Input As String)
        Dim ints As Integer
        Try
            If Input < MinValue Or Int32.TryParse(Input, ints) = False Or Int(Input) > (maxvalue) Then
                Return False
            Else
                Return True
            End If
        Catch
            Return False
        End Try
    End Function

    Private Sub ColTb_TextChanged(sender As System.Object, e As System.EventArgs) Handles ColTb.TextChanged
        If ValidInt(15, 5, ColTb.Text) And ValidInt(15, 5, RowsTb.Text) Then
            BombsTb.Enabled = True
            BombsMax = Int(ColTb.Text) * Int(RowsTb.Text) - 1
            BombsLb.Text = ("(1-" + Str(BombsMax) + ")")
        Else
            BombsTb.Enabled = False
        End If
    End Sub

    Private Sub RowsTb_TextChanged(sender As System.Object, e As System.EventArgs) Handles RowsTb.TextChanged
        If ValidInt(15, 5, ColTb.Text) And ValidInt(15, 5, RowsTb.Text) Then
            BombsTb.Enabled = True
            BombsMax = Int(ColTb.Text) * Int(RowsTb.Text) - 1
            BombsLb.Text = ("(1-" + Str(BombsMax) + ")")
        Else
            BombsTb.Enabled = False
        End If
    End Sub

    Private Sub BombsTb_TextChanged(sender As System.Object, e As System.EventArgs) Handles BombsTb.TextChanged
        If ValidInt(BombsMax, 1, BombsTb.Text) Then
            LoadGame.Enabled = True
        Else
            LoadGame.Enabled = False
        End If

    End Sub
End Class