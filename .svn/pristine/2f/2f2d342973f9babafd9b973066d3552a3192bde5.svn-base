<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class VehicleMain
    Inherits TabPage

    'UserControl overrides dispose to clean up the component list.
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

    Public Sub Handle_Text_Entry(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Me.Text = TextBox1.Text

    End Sub

    Public Sub Handle_System_Select(sender As Object, e As EventArgs) Handles TreeView1.AfterSelect

        If (TreeView1.SelectedNode.Level > 0) Then

            Dim x As Integer = 0

            For i As Integer = 0 To TreeView1.SelectedNode.Parent.Index - 1 Step 1

                x = x + TreeView1.Nodes(i).GetNodeCount(False)

            Next

            x = x + (TreeView1.SelectedNode.Index)

            Dim temp As String = Data.GetSystems()(x).Desc
            temp = temp.Replace("[NEWLINE]", vbNewLine + vbNewLine)
            RichTextBox1.Text = temp

            FillSubSystems(TreeView2, x)

        End If


    End Sub

    Public Sub Handle_SubSystem_Select(sender As Object, e As EventArgs) Handles TreeView2.AfterSelect

        Dim temp As List(Of SubSystem) = Data.GetSubSystems

        For Each item As SubSystem In temp

            If TreeView2.SelectedNode.Text = item.Name Then

                RichTextBox1.Text = item.Desc

            End If

        Next

    End Sub

    Public Sub Handle_ARating_Change(sender As Object, e As EventArgs) Handles ARatingCBox.SelectedIndexChanged

        If CType(Data.GetRatings()(ARatingCBox.SelectedIndex), Rating).AP < CType(APSpent.Text, Integer) Then

            Dim Result = MsgBox("Changing the Artifact Rating will mean that you have spent more AP than you would have available at the new Artifact Rating. Do you still want to change it? You will lose all your current system selections.", MsgBoxStyle.YesNo, "Artifact Rating")

            If Result = DialogResult.Yes Then

                TreeView3.Nodes.Clear()

                APSpent.Text = "0"

                APAmt.Text = CType(Data.GetRatings()(ARatingCBox.SelectedIndex), Rating).AP
                APBalance.Text = CType(Data.GetRatings()(ARatingCBox.SelectedIndex), Rating).AP

            ElseIf Result = DialogResult.No Then

                For Each item As Rating In Data.GetRatings()

                    If APAmt.Text = item.AP Then

                        ARatingCBox.SelectedIndex = item.Dots - 1

                    End If

                Next

            End If

        Else

            APAmt.Text = CType(Data.GetRatings()(ARatingCBox.SelectedIndex), Rating).AP
            APBalance.Text = CType(Data.GetRatings()(ARatingCBox.SelectedIndex), Rating).AP

            If APSpent.Text = "" Then

                APSpent.Text = "0"

            End If

            If CType(APSpent.Text, Integer) > 0 Then

                APBalance.Text = APBalance.Text - APSpent.Text

            Else

                APSpent.Text = "0"

            End If

        End If

    End Sub

    Public Sub Handle_System_DblClick(Sender As Object, e As EventArgs) Handles TreeView1.DoubleClick

        If (TreeView1.SelectedNode.Level > 0) Then

            Dim x As Integer = 0

            For i As Integer = 0 To TreeView1.SelectedNode.Parent.Index - 1 Step 1

                x = x + TreeView1.Nodes(i).GetNodeCount(False)

            Next

            x = x + (TreeView1.SelectedNode.Index)

            Dim temp As SOSSystem = Data.GetSystems()(x)

            Dim f As Integer = APBalance.Text
            Dim d As Integer = APSpent.Text
            Dim n As Integer

            If temp.Cost.Contains("Size") Then

                If ComboBox2.SelectedIndex = -1 Then

                    MsgBox("You can't pick that system yet, you need a size category selected.")

                Else

                    Dim ts As String = temp.Cost.Replace("Size Category", ComboBox2.SelectedItem)
                    n = ts.Split("/")(0) / ts.Split("/")(1)

                    If n = 0 Then

                        n = 1

                    End If

                    d = d + n
                    f = f - n

                    APSpent.Text = d
                    APBalance.Text = f
                    TreeView3.Nodes.Add(temp.Name)

                End If

            Else

                If temp.Cost.Contains("Varies") Then

                    n = 0

                Else

                    n = temp.Cost

                End If

                d = d + n
                f = f - n

                APSpent.Text = d
                APBalance.Text = f
                TreeView3.Nodes.Add(temp.Name)

            End If

        End If

    End Sub

    Public Sub Handle_SubSystem_DblClick(Sender As Object, e As EventArgs) Handles TreeView2.DoubleClick

        If (TreeView1.SelectedNode.Level > 0) Then

            Dim temp As List(Of SubSystem) = Data.GetSubSystems


            For Each item As SubSystem In temp

                If item.Name = TreeView2.SelectedNode.Text Then

                    Dim f As Integer = APBalance.Text
                    Dim n As Integer = item.Cost
                    Dim d As Integer = APSpent.Text

                    d = d + n
                    f = f - n

                    APSpent.Text = d
                    APBalance.Text = f

                    TreeView3.Nodes.Add(TreeView2.SelectedNode.Text)


                End If

            Next

        End If

    End Sub

    Public Sub Handle_Final_DblClick(Sender As Object, e As EventArgs) Handles TreeView3.DoubleClick

        Dim temp As List(Of SubSystem) = Data.GetSubSystems

        For Each item As SubSystem In temp

            If TreeView3.SelectedNode.Text = item.Name Then

                Dim f As Integer = APBalance.Text
                Dim d As Integer = APSpent.Text
                Dim n As Integer

                If item.Cost.Contains("Size") Then

                    Dim ts As String = item.Cost.Replace("Size Category", ComboBox2.SelectedItem)
                    n = ts.Split("/")(0) / ts.Split("/")(1)

                    If n = 0 Then

                        n = 1

                    End If

                    d = d + n
                    f = f - n

                    APSpent.Text = d
                    APBalance.Text = f
                    TreeView3.SelectedNode.Remove()
                    Exit For

                Else

                    If item.Cost.Contains("Varies") Then
                        n = 0
                    Else
                        n = item.Cost
                    End If

                    d = d + n
                    f = f - n

                    APSpent.Text = d
                    APBalance.Text = f
                    TreeView3.SelectedNode.Remove()
                    Exit For

                End If

            End If

        Next

        If TreeView3.GetNodeCount(True) > 0 Then

            Dim temp2 As List(Of SOSSystem) = Data.GetSystems()

            For Each item As SOSSystem In temp2

                If TreeView3.SelectedNode.Text = item.Name Then

                    Dim f As Integer = APBalance.Text
                    Dim d As Integer = APSpent.Text
                    Dim n As Integer

                    If item.Cost.Contains("Size") Then

                        Dim ts As String = item.Cost.Replace("Size Category", ComboBox2.SelectedItem)
                        n = ts.Split("/")(0) / ts.Split("/")(1)

                        If n = 0 Then

                            n = 1

                        End If

                        d = d + n
                        f = f - n

                        APSpent.Text = d
                        APBalance.Text = f
                        TreeView3.SelectedNode.Remove()
                        Exit For

                    Else

                        If item.Cost.Contains("Varies") Then
                            n = 0
                        Else
                            n = item.Cost
                        End If

                        d = d + n
                        f = f - n

                        APSpent.Text = d
                        APBalance.Text = f
                        TreeView3.SelectedNode.Remove()
                        Exit For

                    End If

                End If

            Next

        End If

    End Sub

    Public Sub Handle_Chassis_Select(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        If ComboBox2.SelectedIndex > -1 And ComboBox1.SelectedIndex = 1 Then

            'Vehicle rules for calculating soak/hard
            Dim tempch As Chassis = Data.GetChassis()(ComboBox3.SelectedIndex)
            Dim tempsc As SizeCategories = Data.GetSizeCats()(ComboBox2.SelectedIndex)

            Dim HL As Integer = 0
            Dim HB As Integer = 0
            Dim SL As Integer = 0
            Dim SB As Integer = 0

            HL = tempch.Hardness.lethal + tempsc.Hardness.lethal
            HB = tempch.Hardness.bashing + tempsc.Hardness.bashing
            SL = tempch.Soak.lethal + tempsc.Soak.lethal
            SB = tempch.Soak.bashing + tempsc.Soak.bashing

            HL = HL + Math.Floor((HL * 0.5))
            HB = HB + Math.Floor((HB * 0.5))
            SL = SL + Math.Floor((SL * 0.5))
            SB = SB + Math.Floor((SB * 0.5))

            LethalHard.Text = "Lethal: " + HL.ToString
            BashingHard.Text = "Bashing: " + HB.ToString
            LethalSoak.Text = "Lethal: " + SL.ToString
            BashingSoak.Text = "Bashing: " + SB.ToString

        ElseIf ComboBox2.SelectedIndex > -1 Then

            'non vehicle rules
            Dim tempch As Chassis = Data.GetChassis()(ComboBox3.SelectedIndex)
            Dim tempsc As SizeCategories = Data.GetSizeCats()(ComboBox2.SelectedIndex)

            Dim HL As Integer = 0
            Dim HB As Integer = 0
            Dim SL As Integer = 0
            Dim SB As Integer = 0

            HL = tempch.Hardness.lethal + tempsc.Hardness.lethal
            HB = tempch.Hardness.bashing + tempsc.Hardness.bashing
            SL = tempch.Soak.lethal + tempsc.Soak.lethal
            SB = tempch.Soak.bashing + tempsc.Soak.bashing

            LethalHard.Text = "Lethal: " + HL.ToString
            BashingHard.Text = "Bashing: " + HB.ToString
            LethalSoak.Text = "Lethal: " + SL.ToString
            BashingSoak.Text = "Bashing: " + SB.ToString

        End If

    End Sub

    Public Sub Handle_SizeCat_Select(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox3.SelectedIndex > -1 And ComboBox1.SelectedIndex = 1 Then

            'Vehicle rules for calculating soak/hard
            Dim tempch As Chassis = Data.GetChassis()(ComboBox3.SelectedIndex)
            Dim tempsc As SizeCategories = Data.GetSizeCats()(ComboBox2.SelectedIndex)

            Dim HL As Integer = 0
            Dim HB As Integer = 0
            Dim SL As Integer = 0
            Dim SB As Integer = 0

            HL = tempch.Hardness.lethal + tempsc.Hardness.lethal
            HB = tempch.Hardness.bashing + tempsc.Hardness.bashing
            SL = tempch.Soak.lethal + tempsc.Soak.lethal
            SB = tempch.Soak.bashing + tempsc.Soak.bashing

            HL = HL + Math.Floor((HL * 0.5))
            HB = HB + Math.Floor((HB * 0.5))
            SL = SL + Math.Floor((SL * 0.5))
            SB = SB + Math.Floor((SB * 0.5))

            LethalHard.Text = "Lethal: " + HL.ToString
            BashingHard.Text = "Bashing: " + HB.ToString
            LethalSoak.Text = "Lethal: " + SL.ToString
            BashingSoak.Text = "Bashing: " + SB.ToString

        ElseIf ComboBox3.SelectedIndex > -1 Then

            'non vehicle rules
            Dim tempch As Chassis = Data.GetChassis()(ComboBox3.SelectedIndex)
            Dim tempsc As SizeCategories = Data.GetSizeCats()(ComboBox2.SelectedIndex)

            Dim HL As Integer = 0
            Dim HB As Integer = 0
            Dim SL As Integer = 0
            Dim SB As Integer = 0

            HL = tempch.Hardness.lethal + tempsc.Hardness.lethal
            HB = tempch.Hardness.bashing + tempsc.Hardness.bashing
            SL = tempch.Soak.lethal + tempsc.Soak.lethal
            SB = tempch.Soak.bashing + tempsc.Soak.bashing

            LethalHard.Text = "Lethal: " + HL.ToString
            BashingHard.Text = "Bashing: " + HB.ToString
            LethalSoak.Text = "Lethal: " + SL.ToString
            BashingSoak.Text = "Bashing: " + SB.ToString

        End If

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.APBalance = New System.Windows.Forms.Label()
        Me.APSpent = New System.Windows.Forms.Label()
        Me.APAmt = New System.Windows.Forms.Label()
        Me.SPPot = New System.Windows.Forms.Label()
        Me.SPBase = New System.Windows.Forms.Label()
        Me.MMaterial = New System.Windows.Forms.ComboBox()
        Me.ARating = New System.Windows.Forms.Label()
        Me.ARatingCBox = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LethalHard = New System.Windows.Forms.Label()
        Me.BashingHard = New System.Windows.Forms.Label()
        Me.LethalSoak = New System.Windows.Forms.Label()
        Me.BashingSoak = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.TreeView3 = New System.Windows.Forms.TreeView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TreeView1
        '
        Me.TreeView1.LineColor = System.Drawing.Color.Empty
        Me.TreeView1.Location = New System.Drawing.Point(3, 19)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(190, 293)
        Me.TreeView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Systems"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SubSystems"
        '
        'TreeView2
        '
        Me.TreeView2.LineColor = System.Drawing.Color.Empty
        Me.TreeView2.Location = New System.Drawing.Point(3, 331)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.Size = New System.Drawing.Size(190, 214)
        Me.TreeView2.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.APBalance)
        Me.GroupBox1.Controls.Add(Me.APSpent)
        Me.GroupBox1.Controls.Add(Me.APAmt)
        Me.GroupBox1.Controls.Add(Me.SPPot)
        Me.GroupBox1.Controls.Add(Me.SPBase)
        Me.GroupBox1.Controls.Add(Me.MMaterial)
        Me.GroupBox1.Controls.Add(Me.ARating)
        Me.GroupBox1.Controls.Add(Me.ARatingCBox)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.LethalHard)
        Me.GroupBox1.Controls.Add(Me.BashingHard)
        Me.GroupBox1.Controls.Add(Me.LethalSoak)
        Me.GroupBox1.Controls.Add(Me.BashingSoak)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(221, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1004, 116)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Information"
        '
        'APBalance
        '
        Me.APBalance.AutoSize = True
        Me.APBalance.Location = New System.Drawing.Point(939, 90)
        Me.APBalance.Name = "APBalance"
        Me.APBalance.Text = "15"
        Me.APBalance.Size = New System.Drawing.Size(0, 13)
        Me.APBalance.TabIndex = 6
        '
        'APSpent
        '
        Me.APSpent.AutoSize = True
        Me.APSpent.Location = New System.Drawing.Point(928, 65)
        Me.APSpent.Name = "APSpent"
        Me.APSpent.Text = "0"
        Me.APSpent.Size = New System.Drawing.Size(0, 13)
        Me.APSpent.TabIndex = 7
        '
        'APAmt
        '
        Me.APAmt.AutoSize = True
        Me.APAmt.Location = New System.Drawing.Point(929, 39)
        Me.APAmt.Name = "APAmt"
        Me.APAmt.Text = "15"
        Me.APAmt.Size = New System.Drawing.Size(0, 13)
        Me.APAmt.TabIndex = 8
        '
        'SPPot
        '
        Me.SPPot.AutoSize = True
        Me.SPPot.Location = New System.Drawing.Point(717, 65)
        Me.SPPot.Name = "SPPot"
        Me.SPPot.Size = New System.Drawing.Size(0, 13)
        Me.SPPot.TabIndex = 6
        '
        'SPBase
        '
        Me.SPBase.AutoSize = True
        Me.SPBase.Location = New System.Drawing.Point(700, 39)
        Me.SPBase.Name = "SPBase"
        Me.SPBase.Size = New System.Drawing.Size(0, 13)
        Me.SPBase.TabIndex = 6
        '
        'MMaterial
        '
        Me.MMaterial.AutoSize = True
        Me.MMaterial.Items.AddRange(New Object() {"None", "Orichalcum", "Moonsilver", "Jade", "Starmetal", "Soulsteel", "Helltech"})
        Me.MMaterial.SelectedIndex = 0
        Me.MMaterial.Location = New System.Drawing.Point(365, 85)
        Me.MMaterial.Name = "MMaterial"
        Me.MMaterial.Size = New System.Drawing.Size(121, 21)
        Me.MMaterial.TabIndex = 5        '
        '
        'Artifact Rating
        '
        Me.ARating.AutoSize = True
        Me.ARating.Location = New System.Drawing.Point(660, 90)
        Me.ARating.Name = "ARating"
        Me.ARating.Size = New System.Drawing.Size(0, 13)
        Me.ARating.TabIndex = 5
        Me.ARating.Text = "Artifact Rating:"
        '
        ' ARatingCBox
        '
        Me.ARatingCBox.FormattingEnabled = True
        Me.ARatingCBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ARatingCBox.Location = New System.Drawing.Point(740, 85)
        Me.ARatingCBox.Name = "ARatingCBox"
        Me.ARatingCBox.Size = New System.Drawing.Size(121, 21)
        Me.ARatingCBox.TabIndex = 5
        Me.ARatingCBox.SelectedIndex = 0
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(58, 87)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 5
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(86, 62)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Worn", "Vehicle", "Warstrider"})
        Me.ComboBox1.Location = New System.Drawing.Point(50, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(143, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(50, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(143, 20)
        Me.TextBox1.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(235, 90)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(123, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Magical Material (If Any):"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(660, 65)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Potential:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(660, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Base:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(884, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Amount:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(884, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Spent:"
        '   
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(884, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Balance:"
        '
        'LethalHard
        '
        Me.LethalHard.AutoSize = True
        Me.LethalHard.Location = New System.Drawing.Point(444, 65)
        Me.LethalHard.Name = "LethalHard"
        Me.LethalHard.Size = New System.Drawing.Size(39, 13)
        Me.LethalHard.TabIndex = 5
        Me.LethalHard.Text = "Lethal:"
        '
        'BashingHard
        '
        Me.BashingHard.AutoSize = True
        Me.BashingHard.Location = New System.Drawing.Point(444, 39)
        Me.BashingHard.Name = "BashingHard"
        Me.BashingHard.Size = New System.Drawing.Size(48, 13)
        Me.BashingHard.TabIndex = 5
        Me.BashingHard.Text = "Bashing:"
        '
        'LethalSoak
        '
        Me.LethalSoak.AutoSize = True
        Me.LethalSoak.Location = New System.Drawing.Point(235, 65)
        Me.LethalSoak.Name = "LethalSoak"
        Me.LethalSoak.Size = New System.Drawing.Size(39, 13)
        Me.LethalSoak.TabIndex = 5
        Me.LethalSoak.Text = "Lethal:"
        '
        'BashingSoak
        '
        Me.BashingSoak.AutoSize = True
        Me.BashingSoak.Location = New System.Drawing.Point(235, 39)
        Me.BashingSoak.Name = "BashingSoak"
        Me.BashingSoak.Size = New System.Drawing.Size(48, 13)
        Me.BashingSoak.TabIndex = 5
        Me.BashingSoak.Text = "Bashing:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(884, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "AP Total Balance"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(660, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Sustained Power:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(444, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Hardness Information"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(235, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Soak Information"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Chassis:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Size Category:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Type: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Name:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RichTextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(221, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(717, 420)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "System Selection Information"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Enabled = True
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(705, 395)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Font = New System.Drawing.Font(Me.RichTextBox1.Font.Name, 12)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox3.Controls.Add(Me.TreeView3)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(962, 125)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(263, 420)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Current Build Information"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = My.Resources.Resources.ai2
        Me.PictureBox2.Location = New System.Drawing.Point(206, 367)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(51, 47)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = My.Resources.Resources.ward2
        Me.PictureBox3.Location = New System.Drawing.Point(107, 367)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(50, 47)
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"1. Type in a Name", "2. Pick an Artifact Rating", "3. Pick a Chassis", "4. Pick a Size Category", "5. Pick Modules to Create your Item", "6. TARS Weapons, Click the gun.", "7. Wards, click the shield.", "8. AIs, click the blue mind flare."})
        Me.CheckedListBox1.Location = New System.Drawing.Point(8, 222)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(249, 139)
        Me.CheckedListBox1.TabIndex = 0
        '
        'TreeView3
        '
        Me.TreeView3.LineColor = System.Drawing.Color.Empty
        Me.TreeView3.Location = New System.Drawing.Point(8, 19)
        Me.TreeView3.Name = "TreeView3"
        Me.TreeView3.Size = New System.Drawing.Size(249, 197)
        Me.TreeView3.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = My.Resources.Resources.weapon2
        Me.PictureBox1.Location = New System.Drawing.Point(8, 367)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 47)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'VehicleMain
        '
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TreeView2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeView1)
        Me.Size = New System.Drawing.Size(1241, 548)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()


    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SPPot As System.Windows.Forms.Label
    Friend WithEvents SPBase As System.Windows.Forms.Label
    Friend WithEvents MMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents ARating As System.Windows.Forms.Label
    Friend WithEvents ARatingCBox As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LethalHard As System.Windows.Forms.Label
    Friend WithEvents BashingHard As System.Windows.Forms.Label
    Friend WithEvents LethalSoak As System.Windows.Forms.Label
    Friend WithEvents BashingSoak As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents APBalance As System.Windows.Forms.Label
    Friend WithEvents APSpent As System.Windows.Forms.Label
    Friend WithEvents APAmt As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents TreeView3 As System.Windows.Forms.TreeView
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

End Class
