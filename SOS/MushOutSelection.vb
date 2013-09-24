﻿Public Class MushOutSelection

    Private Sub MushOutSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each item As VehicleCase In Vehicles

            ComboBox1.Items.Add(item.Vehicle.TextBox1.Text)

        Next

    End Sub

    Private Sub Handle_Selection_Change(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim output As String
        Dim tempve As VehicleMain = Vehicles(ComboBox1.SelectedIndex).Vehicle

        'Name of Thing
        output = tempve.TextBox1.Text + vbNewLine

        'Attune Calculation
        Dim i As Integer = 0
        Dim tempar As Rating = Data.GetRatings()(tempve.ARatingCBox.SelectedIndex)
        Dim tempch As Chassis = Data.GetChassis()(tempve.ComboBox3.SelectedIndex)
        Dim tempsc As SizeCategories = Data.GetSizeCats()(tempve.ComboBox2.SelectedIndex)
        i = i + tempar.Attune
        i = i + tempch.Attune
        i = i + tempsc.Attune

        'Artifact Rating and then Attune
        output = output + "Artifact Rating: " + tempar.Dots.ToString + vbNewLine
        output = output + "Attune Cost: " + i.ToString + vbNewLine

        'Cost in XP
        output = output + "XP Cost: " + Math.Ceiling(tempar.Dots / 3).ToString + vbNewLine

        'Size Category
        output = output + "Size Category: " + tempsc.Number.ToString + vbNewLine

        'Chassis
        output = output + "Chassis Type: " + tempch.Name + vbNewLine + vbNewLine

        'AP Amount
        output = output + "Starting AP: " + tempve.APAmt.Text + vbNewLine + vbNewLine

        'List of Systems and SubSystems
        output = output + "Listing of Systems and SubSystems" + vbNewLine + "---------------------------------" + vbNewLine

        For Each a As TreeNode In tempve.TreeView3.Nodes

            output = output + a.Text + " - "

            Dim cost As Integer = 0
            Dim temp As SOSSystem = GetSystem(a.Text, Data.GetSystems())

            If temp.Cost.Contains("MATH") Then
                'Account for MATH - costs that begin with MATH indicate a formula that must be parsed
                For Each item As Char In temp.Cost

                    If item = "+" Then
                        Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                        Dim parttwo As String = temp.Cost.Split("+")(1)

                        If partone = "SC" Then

                            If tempve.ComboBox2.SelectedIndex = -1 Then

                                MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                Exit Sub

                            Else

                                cost = (tempve.ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                                Exit For

                            End If

                        End If

                    ElseIf item = "/" Then
                        Dim partone As String = temp.Cost.Split("/")(0).Split(":")(1)
                        Dim parttwo As String = temp.Cost.Split("/")(1)

                        If partone = "SC" Then

                            If tempve.ComboBox2.SelectedIndex = -1 Then

                                MsgBox("This system requires a size category to be selected. Please select a Size Category and repurchase this module.", MsgBoxStyle.Critical, "Skins of Steel")
                                Exit Sub

                            Else

                                cost = (tempve.ComboBox2.SelectedIndex + 1) / CType(parttwo, Integer)
                                Exit For

                            End If

                        End If

                    End If

                Next

            ElseIf temp.Cost.Contains("SPECIAL") Then
                'Account for SPECIAL - costs that begin with SPECIAL indicate either something that requires another 
                'tool to come up with a cost (TARS, WARDS, AIS) or that are calculated a special way (Reality, Artifact Integration)

                cost = 0

            ElseIf temp.Cost.Contains("MULTI") Then
                'Account for MULTI - costs that begin with MULTI indicate an item that can be purchased either more than once and stacked
                'or that have two variations in terms of what it does built into the description

                Dim number As Integer = 0

                For Each item As Multistage In tempve.Purchases

                    If item.ID = temp.ID Then

                        number = item.Number
                        Exit For

                    End If

                Next

                cost = CType(temp.Cost.Split(":")(1).Split(";")(number), Integer)

            Else
                'If none of those match, the cost must be a number. Handle as normal.

                cost = temp.Cost


            End If

            output = output + cost.ToString + vbNewLine

            If a.Nodes.Count > 0 Then

                'Children
                For Each item As TreeNode In a.Nodes

                    cost = 0
                    Dim tempsub As SubSystem = GetSubSystem(item.Text, Data.GetSubSystems())

                    If a.Text = "Artifact Integration" Then

                        'Artifacts
                        For Each artifact As ArtInts In tempve.Artifacts

                            output = output + vbTab + artifact.Name + " - " + CType(artifact.Rating * 3, String) + vbNewLine

                        Next

                    ElseIf item.Text = "Sorcery" Then

                        'Sorc Wards
                        output = output + vbTab + "Sorcery Wards - 0" + vbNewLine
                        For Each node As TreeNode In item.Nodes

                            output = output + vbTab + vbTab + node.Text + " - " + CType((CType(node.Text.Split(" ")(1), Integer) * 2) + tempve.ComboBox2.SelectedIndex + 1, String) + vbNewLine

                        Next

                    Else

                        If tempsub.Cost.Contains("MATH") Then

                            'Only one math formula here, but will parse it in case more modules are added with different formulas
                            For Each thing As Char In tempsub.Cost

                                If thing = "+" Then
                                    Dim partone As String = tempsub.Cost.Split("+")(0).Split(":")(1)
                                    Dim parttwo As String = tempsub.Cost.Split("+")(1)

                                    If partone = "SC" Then

                                        cost = (tempve.ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)

                                    End If

                                ElseIf thing = "/" Then
                                    Dim partone As String = tempsub.Cost.Split("/")(0).Split(":")(1)
                                    Dim parttwo As String = tempsub.Cost.Split("/")(1)

                                    If partone = "SC" Then

                                        cost = (tempve.ComboBox2.SelectedIndex + 1) / CType(parttwo, Integer)
                                        If cost < 1 Then cost = 1

                                    End If

                                End If

                            Next

                            output = output + vbTab + tempsub.Name + " - " + cost.ToString + vbNewLine

                        ElseIf tempsub.Cost.Contains("RealityC") Then

                            output = output + vbTab + tempsub.Name + " - " + CType((tempve.ComboBox2.SelectedIndex + 1) * 2, String) + vbNewLine

                        Else

                            output = output + vbTab + tempsub.Name + " - " + tempsub.Cost + vbNewLine

                        End If

                    End If

                Next

            End If

            output = output + vbNewLine + vbNewLine

        Next

        'AP Spent
        output = output + vbNewLine + "AP Spent: " + tempve.APSpent.Text
        RichTextBox1.Text = output

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim temp As String = ""

        For Each line As String In RichTextBox1.Lines

            temp = temp + line.Replace(vbTab, "%T") + "%R"

        Next

        RichTextBox1.Text = temp

    End Sub
End Class
