<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class VehicleMain
    Inherits TabPage

    Public Purchases As New List(Of Multistage)
    Public Artifacts As New List(Of ArtInts)
    Public TARWeapons As New List(Of TARWeapon)

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

            Dim sosmod As SOSSystem = Data.GetSystems()(CType(TreeView1.SelectedNode.Name, Integer) - 1)
            Dim temp As String = sosmod.Desc
            Dim cost As String
            temp = temp.Replace("[NEWLINE]", vbNewLine + vbNewLine)

            If sosmod.Cost.Contains(":") Then

                If sosmod.Cost.Contains("SPECIAL") Then

                    'SPECIAL
                    If sosmod.Cost.Contains("ArtInt") Then

                        cost = "3 * Artifact Rating"

                    ElseIf sosmod.Cost.Contains("SorcWard") Then

                        cost = "Size Category + (Circle * 2)"

                    ElseIf sosmod.Cost.Contains("RealityC") Then

                        cost = "3 * Size Category per Purchase (2 AP per if Size Category 0)"

                    Else

                        cost = "Varies"

                    End If

                Else

                    'MATH
                    cost = sosmod.Cost.Split(":")(1).Replace("SC", "Size Category")

                End If

            Else

                cost = sosmod.Cost

            End If

            RichTextBox1.Text = "Cost: " + cost + vbNewLine + vbNewLine + temp

            FillSubSystems(TreeView2, CType(TreeView1.SelectedNode.Name, Integer))

        End If


    End Sub

    Public Sub Handle_SubSystem_Select(sender As Object, e As EventArgs) Handles TreeView2.AfterSelect

        Dim sosmod As SubSystem = Data.GetSubSystems()((CType(TreeView2.SelectedNode.Name, Integer) - CType(Data.GetSystems, List(Of SOSSystem)).Count) - 1)
        Dim temp As String = sosmod.Desc
        Dim cost As String

        temp = temp.Replace("[NEWLINE]", vbNewLine + vbNewLine)

        If sosmod.Cost.Contains(":") Then

            If sosmod.Cost.Contains("SPECIAL") Then

                'SPECIAL
                If sosmod.Cost.Contains("ArtInt") Then

                    cost = "3 * Artifact Rating"

                ElseIf sosmod.Cost.Contains("SorcWard") Then

                    cost = "Size Category + (Circle * 2)"

                ElseIf sosmod.Cost.Contains("RealityC") Then

                    cost = "3 * Size Category per Purchase (2 AP per if Size Category 0)"

                Else

                    cost = "Varies"

                End If

            Else

                'MATH
                cost = sosmod.Cost.Split(":")(1).Replace("SC", "Size Category")

            End If

        Else

            cost = sosmod.Cost

        End If

        RichTextBox1.Text = "Cost: " + cost + vbNewLine + vbNewLine + temp

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

            Dim temp As SOSSystem = Data.GetSystems()(CType(TreeView1.SelectedNode.Name, Integer) - 1)

            Dim cost As Integer = 0

            If temp.Cost.Contains("MATH") Then
                'Account for MATH - costs that begin with MATH indicate a formula that must be parsed
                For Each a As Char In temp.Cost

                    If a = "+" Then
                        Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                        Dim parttwo As String = temp.Cost.Split("+")(1)

                        If partone = "SC" Then

                            If ComboBox2.SelectedIndex = -1 Then

                                MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                Exit Sub

                            Else

                                cost = (ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                                Exit For

                            End If

                        End If

                    ElseIf a = "/" Then
                        Dim partone As String = temp.Cost.Split("/")(0).Split(":")(1)
                        Dim parttwo As String = temp.Cost.Split("/")(1)

                        If partone = "SC" Then

                            If ComboBox2.SelectedIndex = -1 Then

                                MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                Exit Sub

                            Else

                                cost = ComboBox2.SelectedIndex / CType(parttwo, Integer)
                                Exit For

                            End If

                        End If

                    End If

                Next

            ElseIf temp.Cost.Contains("SPECIAL") Then
                'Account for SPECIAL - costs that begin with SPECIAL indicate either something that requires another 
                'tool to come up with a cost (TARS, WARDS, AIS) or that are calculated a special way (Reality, Artifact Integration)

                Dim tempstr As String = temp.Cost.Split(":")(1)
                Dim tai As New ArtInts

                If tempstr = "ArtInt" Then

                    Dim i As String = InputBox("Enter the Artifact Rating of the Artifact being integrated.", "Skins of Steel")
                    Dim Artifact As String = InputBox("Enter the name of the Artifact you're integrating.", "Skins of Steel")

                    If Not IsNumeric(i) Then

                        MsgBox("That was not a valid number! Artifact Ratings must be numbers! Did not add module.", MsgBoxStyle.Critical, "Skins of Steel")
                        Exit Sub

                    Else

                        cost = 3 * CType(i, Integer)

                        tai.Name = Artifact
                        tai.Rating = i

                        Artifacts.Add(tai)

                    End If

                ElseIf tempstr = "TARS" Then

                    MsgBox("You don't actually buy this module. Costs associated with this module are created in the TARS Creator.", MsgBoxStyle.Information, "Skins of Steel")

                ElseIf tempstr = "WARDS" Then

                    MsgBox("You don't actually buy this module. Costs associated with this module are created in the WARDS Creator.", MsgBoxStyle.Information, "Skins of Steel")

                End If


            ElseIf temp.Cost.Contains("MULTI") Then
                'Account for MULTI - costs that begin with MULTI indicate an item that can be purchased either more than once and stacked
                'or that have two variations in terms of what it does built into the description

                Dim i As Integer = 0
                Dim x As Integer = 0
                Dim tms As New Multistage

                For Each item As Multistage In Purchases

                    If item.ID = temp.ID Then

                        tms = item
                        i = item.Number
                        Exit For

                    End If

                    x = x + 1

                Next

                If i > 0 Then

                    Purchases.RemoveAt(x)

                End If

                If i = 0 Then

                    cost = CType(temp.Cost.Split(":")(1).Split(";")(0), Integer)
                    tms.Number = 1
                    tms.ID = temp.ID
                    tms.Name = temp.Name
                    Purchases.Add(tms)

                ElseIf i > 0 And i < 5 Then

                    cost = CType(temp.Cost.Split(":")(1).Split(";")(i), Integer)
                    tms.Number = i + 1
                    tms.ID = temp.ID
                    tms.Name = temp.Name
                    Purchases.Add(tms)

                Else

                    MsgBox("You can only purchase a module up to 5 times at the moment! Module not added. You have already purchased it the max number of times!", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                End If

            Else
                'If none of those match, the cost must be a number. Handle as normal.

                cost = temp.Cost


            End If

            If CType(APBalance.Text, Integer) - cost > 0 Then

                'Before applying Cost, run a check real quick
                'First, Has it already been bought?
                Dim AlreadyBought As Boolean = False
                Dim tempNodes As TreeNodeCollection
                Dim tempnode As New TreeNode

                'see if it's already here and save it and children
                If TreeView3.Nodes.ContainsKey(temp.ID.ToString) Then

                    AlreadyBought = True
                    If TreeView3.Nodes(temp.ID.ToString).Nodes.Count > 0 Then

                        'well shit, it has children
                        tempNodes = TreeView3.Nodes(temp.ID.ToString).Nodes
                        tempnode = TreeView3.Nodes(temp.ID.ToString)


                    Else

                        'oh good, no children
                        tempnode = TreeView3.Nodes(temp.ID.ToString)

                    End If

                Else

                    AlreadyBought = False

                End If

                If AlreadyBought And Not temp.Cost.Contains("MULTI") And Not temp.Cost.Contains("ArtInt") Then

                    'Alreadybought and not multi
                    MsgBox("You have already purchased that module and it has no multistage costing. You can't purchase this multiple times.", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                ElseIf AlreadyBought And temp.Cost.Contains("MULTI") Then

                    'AlreadyBought and it is a multi
                    TreeView3.Nodes.Remove(tempnode)
                    tempnode = TreeView3.Nodes.Add(temp.ID.ToString, temp.Name + " (" + Purchases(Purchases.Count - 1).Number.ToString + ")")
                    'Did it have children?
                    If tempNodes.Count > 0 Then

                        For Each i As TreeNode In tempNodes

                            TreeView3.Nodes(tempnode.Index).Nodes.Add(i)

                        Next


                    End If
                    APSpent.Text = CType(CType(APSpent.Text, Integer) + cost, String)
                    APBalance.Text = CType(CType(APBalance.Text, Integer) - cost, String)

                ElseIf AlreadyBought And temp.Cost.Contains("ArtInt") Then

                    'Artifact integration, need to add new artifact below primary node
                    TreeView3.Nodes(tempnode.Name).Nodes.Add(Artifacts(Artifacts.Count - 1).Name)
                    APSpent.Text = CType(CType(APSpent.Text, Integer) + cost, String)
                    APBalance.Text = CType(CType(APBalance.Text, Integer) - cost, String)

                ElseIf Not AlreadyBought And temp.Cost.Contains("ArtInt") Then

                    'Artifact integration, need to add new artifact below primary node and add primary node
                    tempnode = TreeView3.Nodes.Add(temp.ID.ToString, temp.Name)
                    TreeView3.Nodes(tempnode.Index).Nodes.Add(Artifacts(Artifacts.Count - 1).Name)
                    APSpent.Text = CType(CType(APSpent.Text, Integer) + cost, String)
                    APBalance.Text = CType(CType(APBalance.Text, Integer) - cost, String)

                Else

                    'it has not already been bought and we can add it
                    TreeView3.Nodes.Add(temp.ID.ToString, temp.Name)
                    APSpent.Text = CType(CType(APSpent.Text, Integer) + cost, String)
                    APBalance.Text = CType(CType(APBalance.Text, Integer) - cost, String)

                End If

            Else

                MsgBox("You don't have enough AP to buy that.", MsgBoxStyle.Information, "Skins of Steel")

            End If

        End If

    End Sub

    Public Sub Handle_SubSystem_DblClick(Sender As Object, e As EventArgs) Handles TreeView2.DoubleClick

        Dim temp As SubSystem = Data.GetSubSystems()((CType(TreeView2.SelectedNode.Name, Integer) - CType(Data.GetSystems, List(Of SOSSystem)).Count) - 1)
        Dim cost As Integer = 0

        If temp.Cost.Contains("MATH") Then

            'Only one math formula here, but will parse it in case more modules are added with different formulas
            For Each a As Char In temp.Cost

                If a = "+" Then
                    Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                    Dim parttwo As String = temp.Cost.Split("+")(1)

                    If partone = "SC" Then

                        If ComboBox2.SelectedIndex = -1 Then

                            MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                            Exit Sub

                        Else

                            cost = (ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                            Exit For

                        End If

                    End If

                ElseIf a = "/" Then
                    Dim partone As String = temp.Cost.Split("/")(0)
                    Dim parttwo As String = temp.Cost.Split("/")(1)

                    If partone = "SC" Then

                        If ComboBox2.SelectedIndex = -1 Then

                            MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                            Exit Sub

                        Else

                            cost = ComboBox2.SelectedIndex / CType(parttwo, Integer)
                            Exit For

                        End If

                    End If

                End If

            Next

        ElseIf temp.Cost.Contains("SPECIAL") Then

            'Only two things to do here: RealityC and SorcWard
            If temp.Cost.Contains("RealityC") Then

                If ComboBox2.SelectedIndex = -1 Then

                    MsgBox("This module requires a Size Category to be selected.", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                Else

                    cost = (ComboBox2.SelectedIndex + 1) * 3

                End If

            ElseIf temp.Cost.Contains("SorcWard") Then

                Dim Circle As String = InputBox("Please input the circle of the spell to be warded against using 1, 2 or 3.", "Skins of Steel", "0")

                If ComboBox2.SelectedIndex = -1 Then

                    MsgBox("This system requires a size category to have been selected.", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                ElseIf Not IsNumeric(Circle) Then

                    MsgBox("The circle must be a number! Module not added.", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                ElseIf CType(Circle, Integer) > 3 Then

                    MsgBox("There is no circle of magic higher than 3. Review your response. Module not added.", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                Else

                    cost = (ComboBox2.SelectedIndex + 1) + (CType(Circle, Integer) * 2)

                End If

            End If

        Else

            'regular number
            cost = temp.Cost

        End If

        'Cost is obtained, Player can afford?
        If CType(APBalance.Text, Integer) - CType(cost, Integer) > 0 Then

            'Player can afford the module
            'does it already exist?
            If TreeView3.Nodes.ContainsKey(temp.ID) Then

                If Not temp.Cost.Contains("MULTI") Then

                    'they already have this but it's not a multi purchase
                    MsgBox("You can't purchase this module more than once.", MsgBoxStyle.Critical, "Skins of Steel")
                    Exit Sub

                Else

                    MsgBox("No submodules are multistage yet.", MsgBoxStyle.Information, "Skins of Steel")
                    Exit Sub

                End If


            ElseIf Not TreeView3.Nodes.ContainsKey(temp.Required.ToString) Then

                'do they have the required module?
                MsgBox("That's a submodule and you don't have the required module.", MsgBoxStyle.Exclamation, "Skins of Steel")
                Exit Sub

            ElseIf temp.Cost.Contains("SorcWard") Then

                'Sorcery Ward is Handled Differently
                Dim circle As Integer = System.Math.Floor((cost - ComboBox2.SelectedIndex) / 2)

                If TreeView3.Nodes(temp.Required.ToString).Nodes.ContainsKey(temp.ID.ToString) Then

                    'they already have sorc ward
                    TreeView3.Nodes(temp.Required.ToString).Nodes(temp.ID.ToString).Nodes.Add(temp.ID, "Circle " + circle.ToString)

                Else

                    'they don't already have a sorc ward
                    TreeView3.Nodes(temp.Required.ToString).Nodes.Add(temp.ID, temp.Name)
                    TreeView3.Nodes(temp.Required.ToString).Nodes(temp.ID.ToString).Nodes.Add(temp.ID.ToString, "Circle " + circle.ToString)

                End If

                APBalance.Text = CType(APBalance.Text, Integer) - cost
                APSpent.Text = CType(APSpent.Text, Integer) + cost

            Else

                TreeView3.Nodes(temp.Required.ToString).Nodes.Add(temp.ID, temp.Name)
                APBalance.Text = CType(APBalance.Text, Integer) - cost
                APSpent.Text = CType(APSpent.Text, Integer) + cost

            End If

        Else

            'player cannot afford the module
            MsgBox("You don't have enough AP to purchase that module.", MsgBoxStyle.Critical, "Skins of Steel")
            Exit Sub

        End If

    End Sub

    Public Sub Handle_Final_DblClick(Sender As Object, e As EventArgs) Handles TreeView3.DoubleClick

        Dim cost As Integer = 0

        If IsNothing(TreeView3.SelectedNode) Then

            Exit Sub

        End If

        If TreeView3.SelectedNode.Level = 0 Then

            'SOSSystem
            Dim temp As SOSSystem = Data.GetSystems(CType(TreeView3.SelectedNode.Name, Integer))

            If temp.Cost.Contains("MATH") Then
                'Account for MATH - costs that begin with MATH indicate a formula that must be parsed
                For Each a As Char In temp.Cost

                    If a = "+" Then
                        Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                        Dim parttwo As String = temp.Cost.Split("+")(1)

                        If partone = "SC" Then

                            If ComboBox2.SelectedIndex = -1 Then

                                MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                Exit Sub

                            Else

                                cost = (ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                                Exit For

                            End If

                        End If

                    ElseIf a = "/" Then
                        Dim partone As String = temp.Cost.Split("/")(0).Split(":")(1)
                        Dim parttwo As String = temp.Cost.Split("/")(1)

                        If partone = "SC" Then

                            If ComboBox2.SelectedIndex = -1 Then

                                MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                Exit Sub

                            Else

                                cost = (ComboBox2.SelectedIndex + 1) / CType(parttwo, Integer)
                                Exit For

                            End If

                        End If

                    End If

                Next

            ElseIf temp.Cost.Contains("SPECIAL") Then
                'Account for SPECIAL - costs that begin with SPECIAL indicate either something that requires another 
                'tool to come up with a cost (TARS, WARDS, AIS) or that are calculated a special way (Reality, Artifact Integration)

                Dim tempstr As String = temp.Cost.Split(":")(1)
                Dim tai As New ArtInts

                If tempstr = "ArtInt" Then

                    Dim Result As DialogResult = MessageBox.Show("Removing Artifact Integration will remove all current Artifacts. Is that what you want to do?", "Skins of Steel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                    If Result = DialogResult.Yes Then

                        For Each item As ArtInts In Artifacts

                            cost = cost + (item.Rating * 3)

                        Next

                        Artifacts.Clear()

                    Else

                        Exit Sub

                    End If

                ElseIf tempstr = "TARS" Then

                    MsgBox("Not Implemented.", MsgBoxStyle.Information, "Skins of Steel")

                ElseIf tempstr = "WARDS" Then

                    MsgBox("Not Implemented.", MsgBoxStyle.Information, "Skins of Steel")

                End If


            ElseIf temp.Cost.Contains("MULTI") Then
                'Account for MULTI - costs that begin with MULTI indicate an item that can be purchased either more than once and stacked
                'or that have two variations in terms of what it does built into the description

                Dim i As Integer = 0
                Dim x As Integer = 0
                Dim tms As New Multistage

                For Each item As Multistage In Purchases

                    If item.ID = temp.ID Then

                        tms = item
                        i = item.Number
                        Exit For

                    End If

                    x = x + 1

                Next

                cost = CType(temp.Cost.Split(":")(1).Split(";")(i - 1), Integer)

                If i - 1 = 0 Then

                    Purchases.RemoveAt(x)

                Else

                    tms.Number = i - 1
                    tms.ID = temp.ID
                    tms.Name = temp.Name
                    Purchases.RemoveAt(x)
                    Purchases.Add(tms)

                End If

            Else
                'If none of those match, the cost must be a number. Handle as normal.

                cost = temp.Cost


            End If

        Else

            'SubSystem
            'Artifact Integration Breaks shit
            If TreeView3.SelectedNode.Parent.Text = "Artifact Integration" Then

                'They are removing an artifact
                For Each item As ArtInts In Artifacts

                    If item.Name = TreeView3.SelectedNode.Text Then

                        cost = item.Rating * 3
                        Artifacts.Remove(item)
                        TreeView3.SelectedNode.Remove()
                        Exit For

                    End If

                Next

            Else

                'Not an Artifact
                Dim temp As SubSystem = Data.GetSubSystems()((CType(TreeView3.SelectedNode.Name, Integer) - CType(Data.GetSystems, List(Of SOSSystem)).Count) + 1)

                If temp.Cost.Contains("MATH") Then

                    'Only one math formula here, but will parse it in case more modules are added with different formulas
                    For Each a As Char In temp.Cost

                        If a = "+" Then
                            Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                            Dim parttwo As String = temp.Cost.Split("+")(1)

                            If partone = "SC" Then

                                If ComboBox2.SelectedIndex = -1 Then

                                    MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                    Exit Sub

                                Else

                                    cost = (ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                                    Exit For

                                End If

                            End If

                        ElseIf a = "/" Then
                            Dim partone As String = temp.Cost.Split("/")(0).Split(":")(1)
                            Dim parttwo As String = temp.Cost.Split("/")(1)

                            If partone = "SC" Then

                                If ComboBox2.SelectedIndex = -1 Then

                                    MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                    Exit Sub

                                Else

                                    cost = (ComboBox2.SelectedIndex + 1) / CType(parttwo, Integer)
                                    If cost < 1 Then cost = 1
                                    Exit For

                                End If

                            End If

                        End If

                    Next

                ElseIf temp.Cost.Contains("SPECIAL") Then

                    'Only two things to do here: RealityC and SorcWard
                    If temp.Cost.Contains("RealityC") Then

                        cost = (ComboBox2.SelectedIndex + 1) * 3

                    ElseIf temp.Cost.Contains("SorcWard") Then

                        If TreeView3.SelectedNode.Text = "Sorcery" Then

                            Dim Result As DialogResult = MessageBox.Show("Removing Sorcery will remove all current Sorcery Wards. Is that what you want to do?", "Skins of Steel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                            If Result = DialogResult.Yes Then

                                For Each item As TreeNode In TreeView3.SelectedNode.Nodes

                                    cost = cost + ((ComboBox2.SelectedIndex + 1) + (CType(item.Text.Split(" ")(1), Integer) * 2))

                                Next

                            Else

                                Exit Sub

                            End If

                        Else

                            cost = (ComboBox2.SelectedIndex + 1) + (CType(TreeView3.SelectedNode.Text.Split(" ")(1), Integer) * 2)

                        End If

                    End If

                Else

                    'regular number
                    cost = temp.Cost

                End If

            End If

        End If

        If cost > 0 Then
            'cost obtained
            APSpent.Text = CType(CType(APSpent.Text, Integer) - cost, String)
            APBalance.Text = CType(CType(APBalance.Text, Integer) + cost, String)
            TreeView3.SelectedNode.Remove()
        End If

        If Not IsNothing(TreeView3.SelectedNode) Then

            If TreeView3.SelectedNode.Nodes.Count = 0 And cost = 0 Then

                TreeView3.SelectedNode.Remove()

            End If

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

    Public Sub Handle_TARS_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        MsgBox("TARS!")

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
