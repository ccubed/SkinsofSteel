Module Utilities

    'utility function for parsing health
    Function HealthParse(ByVal which As Integer, ByVal health As String, ByVal amount As Integer) As Integer

        'If i = 0 Then



        'ElseIf i = 1 Then



        'ElseIf i = 2 Then



        'ElseIf i = 3 Then



        'ElseIf i = 4 Then



        'End If

        Return 0

    End Function

    Function SoakParse(ByVal path As System.Xml.XPath.XPathNodeIterator) As Defense

        Dim temp As Defense

        While path.MoveNext

            If path.Current.Name = "bashing" Then
                temp.bashing = path.Current.Value

            ElseIf path.Current.Name = "lethal" Then
                temp.lethal = path.Current.Value

            End If

        End While

        Return temp

    End Function

    Sub FillSystems(ByRef where As VehicleMain, ByVal what As List(Of SOSSystem), ByVal cats As List(Of Syscat))

        For Each item As Syscat In cats

            where.TreeView1.Nodes.Add(item.Category)

        Next

        For Each item As SOSSystem In what

            where.TreeView1.Nodes(item.Category - 1).Nodes.Add(item.ID.ToString, item.Name)

        Next

    End Sub

    Sub FillSubSystems(ByRef where As TreeView, ByVal what As Integer)

        where.Nodes.Clear()

        Dim temp As New List(Of SubSystem)
        temp = Data.GetSubSystems

        For Each item As SubSystem In temp

            If item.Required = what Then

                where.Nodes.Add(item.ID.ToString, item.Name)

            End If

        Next

    End Sub

    Sub FillSizeCats(ByRef where As VehicleMain, ByVal what As List(Of SizeCategories))

        For Each item As SizeCategories In what

            where.ComboBox2.Items.Add(item.Number)

        Next

    End Sub

    Sub FillChassis(ByRef where As VehicleMain, ByVal what As List(Of Chassis))

        For Each item As Chassis In what

            where.ComboBox3.Items.Add(item.Name)

        Next

    End Sub

    Function GetSystem(ByVal name As String, ByVal Items As List(Of SOSSystem)) As SOSSystem

        For Each thing As SOSSystem In Items

            If thing.Name = name Then

                Return thing
                Exit Function

            End If

        Next

        Return Nothing

    End Function

    Function GetSubSystem(ByVal name As String, ByVal Items As List(Of SubSystem)) As SubSystem

        For Each thing As SubSystem In Items

            If thing.Name = name Then

                Return thing
                Exit Function

            End If

        Next

        Return Nothing

    End Function

    Function GetSystemCost(ByVal temp As SOSSystem, ByVal where As VehicleMain) As Integer

        Dim cost As Integer = 0

        If temp.Cost.Contains("MATH") Then
            'Account for MATH - costs that begin with MATH indicate a formula that must be parsed
            For Each a As Char In temp.Cost

                If a = "+" Then
                    Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                    Dim parttwo As String = temp.Cost.Split("+")(1)

                    If partone = "SC" Then

                        If where.ComboBox2.SelectedIndex = -1 Then

                            Return -1

                        Else

                            cost = (where.ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                            Exit For

                        End If

                    End If

                ElseIf a = "/" Then
                    Dim partone As String = temp.Cost.Split("/")(0).Split(":")(1)
                    Dim parttwo As String = temp.Cost.Split("/")(1)

                    If partone = "SC" Then

                        If where.ComboBox2.SelectedIndex = -1 Then

                            Return -1

                        Else

                            cost = where.ComboBox2.SelectedIndex / CType(parttwo, Integer)
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

                    Return -2

                Else

                    cost = 3 * CType(i, Integer)

                    tai.Name = Artifact
                    tai.Rating = i

                    where.Artifacts.Add(tai)

                End If

            ElseIf tempstr = "TARS" Then

                Return -3

            ElseIf tempstr = "WARDS" Then

                Return -4

            End If


        ElseIf temp.Cost.Contains("MULTI") Then
            'Account for MULTI - costs that begin with MULTI indicate an item that can be purchased either more than once and stacked
            'or that have two variations in terms of what it does built into the description

            Dim i As Integer = 0
            Dim x As Integer = 0
            Dim tms As New Multistage

            For Each item As Multistage In where.Purchases

                If item.ID = temp.ID Then

                    tms = item
                    i = item.Number
                    Exit For

                End If

                x = x + 1

            Next

            If i > 0 Then

                where.Purchases.RemoveAt(x)

            End If

            If i = 0 Then

                cost = CType(temp.Cost.Split(":")(1).Split(";")(0), Integer)
                tms.Number = 1
                tms.ID = temp.ID
                tms.Name = temp.Name
                where.Purchases.Add(tms)

            ElseIf i > 0 And i < 5 Then

                cost = CType(temp.Cost.Split(":")(1).Split(";")(i), Integer)
                tms.Number = i + 1
                tms.ID = temp.ID
                tms.Name = temp.Name
                where.Purchases.Add(tms)

            Else

                Return -5

            End If

        Else
            'If none of those match, the cost must be a number. Handle as normal.

            cost = temp.Cost


        End If

        Return cost

    End Function

    Function GetSubCost(ByVal temp As SubSystem, ByVal where As VehicleMain) As Integer

        Dim cost As Integer = 0

        If temp.Cost.Contains("MATH") Then

            'Only one math formula here, but will parse it in case more modules are added with different formulas
            For Each a As Char In temp.Cost

                If a = "+" Then
                    Dim partone As String = temp.Cost.Split("+")(0).Split(":")(1)
                    Dim parttwo As String = temp.Cost.Split("+")(1)

                    If partone = "SC" Then

                        If where.ComboBox2.SelectedIndex = -1 Then

                            Return -1

                        Else

                            cost = (where.ComboBox2.SelectedIndex + 1) + CType(parttwo, Integer)
                            Exit For

                        End If

                    End If

                ElseIf a = "/" Then
                    Dim partone As String = temp.Cost.Split("/")(0)
                    Dim parttwo As String = temp.Cost.Split("/")(1)

                    If partone = "SC" Then

                        If where.ComboBox2.SelectedIndex = -1 Then

                            Return -1

                        Else

                            cost = where.ComboBox2.SelectedIndex / CType(parttwo, Integer)
                            Exit For

                        End If

                    End If

                End If

            Next

        ElseIf temp.Cost.Contains("SPECIAL") Then

            'Only two things to do here: RealityC and SorcWard
            If temp.Cost.Contains("RealityC") Then

                If where.ComboBox2.SelectedIndex = -1 Then

                    Return -1

                Else

                    cost = (where.ComboBox2.SelectedIndex + 1) * 3

                End If

            ElseIf temp.Cost.Contains("SorcWard") Then

                Dim Circle As String = InputBox("Please input the circle of the spell to be warded against using 1, 2 or 3.", "Skins of Steel", "0")

                If where.ComboBox2.SelectedIndex = -1 Then

                    Return -1

                ElseIf Not IsNumeric(Circle) Then

                    Return -2

                ElseIf CType(Circle, Integer) > 3 Or CType(Circle, Integer) < 1 Then

                    Return -3

                Else

                    cost = (where.ComboBox2.SelectedIndex + 1) + (CType(Circle, Integer) * 2)

                End If

            End If

        Else

            'regular number
            cost = temp.Cost

        End If

        Return cost

    End Function

    Public Vehicles As New List(Of VehicleCase)
    Public Data As New SystemData
    'Public WWards as new list(of wward)

End Module

Public Structure TARWeapon

    Dim Name As String
    Dim Speed As Integer
    Dim Accuracy As Integer
    Dim Damage As Integer
    Dim Defense As Integer
    Dim Rate As Integer
    Dim Cost As Integer
    Dim Modules As List(Of TarData)

End Structure

Public Structure ArtInts

    Dim Name As String
    Dim Rating As Integer

End Structure

Public Structure Multistage

    Dim Number As Integer
    Dim ID As Integer
    Dim Name As String

End Structure

Public Structure Defense

    Dim bashing As Integer
    Dim lethal As Integer

End Structure

Public Structure HealthLevels

    Dim Zeros As String
    Dim Ones As String
    Dim Twos As String
    Dim Fours As String
    Dim NonFunction As String

End Structure

Public Structure ChassisFlags

    Dim Vehicle As Boolean
    Dim Mechanized As Boolean
    Dim Automaton As Boolean
    Dim Necrotech As Boolean
    Dim Biotech As Boolean

End Structure

Public Structure SystemEffects

    Dim Acc As Integer
    Dim Dam As Integer
    Dim Speed As Integer
    Dim Def As Integer
    Dim Rate As Integer
    Dim Overwhelm As Integer
    Dim Special As Integer
    Dim Clinch As Integer

End Structure

Public Structure PreRequisites

    Dim Sizeplus As Integer
    Dim Othersys As Integer
    Dim AI As Integer

End Structure

'Helper Structures for MDI stuff
Public Structure VehicleCase

    Dim Vehicle As VehicleMain
    Dim Position As Integer

End Structure