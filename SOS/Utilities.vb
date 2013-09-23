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

    Public Vehicles As New List(Of VehicleCase)
    Public Data As New SystemData
    'Public TARWeapons as new list(of TARWeapon)
    'Public WWards as new list(of wward)

End Module

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