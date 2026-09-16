'==================================================================================================
' Abaks - A simple calculator application
'    © 2026 Remus Rigo
'       v1.1.20260912
'==================================================================================================

Imports Abaks.API

Public Class frmAbaks

   Private op As String
   Private opResult As String
   Private opInitial As Double

   Private Const SYSMENU_ABOUT_ID As UInteger = 1000

   '===============================================================================================
   Protected Overrides Sub OnHandleCreated(e As EventArgs)
      MyBase.OnHandleCreated(e)
      Dim hSysMenu As IntPtr = GetSystemMenu(Me.Handle, False)
      AppendMenu(hSysMenu, MF_SEPARATOR, 0, String.Empty)
      AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "About...")
   End Sub

   '===============================================================================================
   Protected Overrides Sub WndProc(ByRef m As Message)
      MyBase.WndProc(m)
      If m.Msg = WM_SYSCOMMAND Then
         If CUInt(m.WParam) = SYSMENU_ABOUT_ID Then
            frmAbout.ShowDialog()
         End If
      End If
   End Sub

   '===============================================================================================
   ' Applies the pending operation to the current result and updates the display
   Private Sub ApplyPendingOperation()
      If opResult <> "" Then
         Dim value = Double.Parse(opResult)

         Select Case op
            Case "+"
               opInitial += value
            Case "-"
               opInitial -= value
            Case "*"
               opInitial *= value
            Case "/"
               If value <> 0 Then
                  opInitial /= value
               Else
                  MessageBox.Show("Cannot divide by zero")
               End If
            Case ""   ' first number entered
               opInitial = value
         End Select
      End If

      txtBoxResult.Text = opInitial.ToString()
      opResult = ""
   End Sub

   '===============================================================================================
   ' Shows the operation in progress, e.g. "20-10"
   Private Sub UpdateCurrentDisplay()
      If op = "" Then
         txtBoxCurrent.Text = opResult
      Else
         txtBoxCurrent.Text = opInitial.ToString() & op & opResult
      End If
   End Sub

   '===============================================================================================
   ' frmAbaks: OnLoad
   Private Sub frmAbaks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.KeyPreview = True
      txtBoxCurrent.Text = ""
      txtBoxResult.Text = ""
      opResult = ""
      opInitial = 0
      op = ""
   End Sub

   '===============================================================================================
   ' frmAbaks: Shown
   Private Sub frmAbaks_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' 0-9 buttons
   Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
      opResult += "1"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
      opResult += "2"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub
   Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
      opResult += "3"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
      opResult += "4"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
      opResult += "5"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
      opResult += "6"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
      opResult += "7"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
      opResult += "8"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
      opResult += "9"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
      opResult += "0"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Backspace
   Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
      If opResult.Length > 0 Then
         opResult = opResult.Substring(0, opResult.Length - 1)
         UpdateCurrentDisplay()
      End If
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Clear
   Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
      txtBoxCurrent.Text = ""
      txtBoxResult.Text = ""
      opResult = ""
      opInitial = 0
      op = ""
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Clear Entry
   Private Sub btnCE_Click(sender As Object, e As EventArgs) Handles btnCE.Click
      opResult = ""
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Divide
   Private Sub btnDivide_Click(sender As Object, e As EventArgs) Handles btnDivide.Click
      ApplyPendingOperation()
      op = "/"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Enter
   Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
      Dim expression = If(op = "", opResult, opInitial.ToString() & op & opResult)
      ApplyPendingOperation()
      op = ""
      txtBoxCurrent.Text = expression & "="
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Minus
   Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
      ApplyPendingOperation()
      op = "-"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Multiply
   Private Sub btnMultiply_Click(sender As Object, e As EventArgs) Handles btnMultiply.Click
      ApplyPendingOperation()
      op = "*"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Plus
   Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
      ApplyPendingOperation()
      op = "+"
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' Plus/Minus
   Private Sub btnPlusMinus_Click(sender As Object, e As EventArgs) Handles btnPlusMinus.Click
      opResult = (-Double.Parse(opResult)).ToString()
      UpdateCurrentDisplay()
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' KeyPress
   Private Sub frmAbaks_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
      Select Case e.KeyChar
         Case "0"c To "9"c
            opResult += e.KeyChar
            UpdateCurrentDisplay()
         Case "+"c : btnPlus_Click(sender, e)
         Case "-"c : btnMinus_Click(sender, e)
         Case "*"c : btnMultiply_Click(sender, e)
         Case "/"c : btnDivide_Click(sender, e)
      End Select
      e.Handled = True
      txtBoxResult.Focus()
   End Sub

   '===============================================================================================
   ' KeyDown
   Private Sub frmAbaks_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
      Select Case e.KeyCode
         Case Keys.Back : btnBack_Click(sender, e)
         Case Keys.Delete : btnCE_Click(sender, e)
         Case Keys.Enter : btnEnter_Click(sender, e)
         Case Keys.Escape : btnC_Click(sender, e)
            ' if uncommented, pressing the numpad keys will double the numbers
            'Case Keys.NumPad0 : btn0_Click(sender, e)
            'Case Keys.NumPad1 : btn1_Click(sender, e)
            'Case Keys.NumPad2 : btn2_Click(sender, e)
            'Case Keys.NumPad3 : btn3_Click(sender, e)
            'Case Keys.NumPad4 : btn4_Click(sender, e)
            'Case Keys.NumPad5 : btn5_Click(sender, e)
            'Case Keys.NumPad6 : btn6_Click(sender, e)
            'Case Keys.NumPad7 : btn7_Click(sender, e)
            'Case Keys.NumPad8 : btn8_Click(sender, e)
            'Case Keys.NumPad9 : btn9_Click(sender, e)
      End Select
      txtBoxResult.Focus()
   End Sub

   Private Sub btnPercent_Click(sender As Object, e As EventArgs) Handles btnPercent.Click
      '
   End Sub
End Class
