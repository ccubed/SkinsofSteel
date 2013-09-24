Imports System.Xml
Class SystemData

    Dim Ratings As New List(Of Rating)
    Dim Keywords As New List(Of SOSKeywords)
    Dim Repairrates As New List(Of RepairRate)
    Dim Chassistypes As New List(Of Chassis)
    Dim Sizecats As New List(Of SizeCategories)
    Dim Ai As New List(Of AiType)
    Dim AiCharms As New List(Of ACharm)
    Dim Categories As New List(Of Syscat)
    Dim Systems As New List(Of SOSSystem)
    Dim SubSystems As New List(Of SubSystem)
    Dim TARS As New TarData
    Dim Wards As New WardData

    Public Sub LoadData()

        'Load XML Data
        Dim xmldoc As New Xml.XPath.XPathDocument("data.xml")
        Dim nav As Xml.XPath.XPathNavigator = xmldoc.CreateNavigator()

        'This is our Iterator. First job, Artifact Ratings
        Dim iterator As Xml.XPath.XPathNodeIterator = nav.Select("/SOS/ratings/rating")

        While iterator.MoveNext

            Dim child As Xml.XPath.XPathNodeIterator = iterator.Current.SelectChildren(XPath.XPathNodeType.Element)
            Dim temp As New Rating

            While child.MoveNext

                If child.Current.Name = "dots" Then
                    temp.Dots = child.Current.Value

                ElseIf child.Current.Name = "ap" Then
                    temp.AP = child.Current.Value

                ElseIf child.Current.Name = "attune" Then
                    temp.Attune = child.Current.Value

                ElseIf child.Current.Name = "repair" Then
                    temp.Repair = child.Current.Value

                End If

            End While

            Ratings.Add(temp)

        End While

        'Next Job: Keywords
        'Not implemented yet

        'Next Job: Repairates
        'Not implemented yet

        'Next Job: Chassis Types
        iterator = nav.Select("/SOS/chassistypes/chassis")

        While iterator.MoveNext

            Dim child As Xml.XPath.XPathNodeIterator = iterator.Current.SelectChildren(XPath.XPathNodeType.Element)
            Dim temp As New Chassis

            While child.MoveNext

                If child.Current.Name = "name" Then
                    temp.Name = child.Current.Value

                ElseIf child.Current.Name = "soak" Then

                    Dim child2 As Xml.XPath.XPathNodeIterator = child.Current.SelectChildren(XPath.XPathNodeType.Element)
                    temp.Soak = Utilities.SoakParse(child2)

                ElseIf child.Current.Name = "hardness" Then

                    Dim child2 As Xml.XPath.XPathNodeIterator = child.Current.SelectChildren(XPath.XPathNodeType.Element)
                    temp.Hardness = Utilities.SoakParse(child2)

                ElseIf child.Current.Name = "mobility" Then

                    temp.Mobility = child.Current.Value

                ElseIf child.Current.Name = "fatigue" Then

                    temp.Fatigue = child.Current.Value

                ElseIf child.Current.Name = "attune" Then

                    temp.Attune = child.Current.Value

                ElseIf child.Current.Name = "desc" Then

                    temp.Desc = child.Current.Value

                ElseIf child.Current.Name = "health" Then

                    Dim hl As String = child.Current.Value

                    If hl <> "None" Then
                        Dim i As Integer = 0
                        While i < 5

                            If i = 0 Then

                                temp.Health.Zeros = hl.Split(", ")(i)

                            ElseIf i = 1 Then

                                temp.Health.Ones = hl.Split(", ")(i)

                            ElseIf i = 2 Then

                                temp.Health.Twos = hl.Split(", ")(i)

                            ElseIf i = 3 Then

                                temp.Health.Fours = hl.Split(", ")(i)

                            ElseIf i = 4 Then

                                temp.Health.NonFunction = hl.Split(", ")(i)

                            End If

                            i = i + 1

                        End While

                    Else

                        temp.Health.Zeros = 0
                        temp.Health.Twos = 0
                        temp.Health.Ones = 0
                        temp.Health.Fours = 0
                        temp.Health.NonFunction = 0

                    End If

                ElseIf child.Current.Name = "strength" Then

                    temp.Strength = child.Current.Value

                End If

            End While

            Chassistypes.Add(temp)

        End While

        'Next Job: Size Categories
        iterator = nav.Select("/SOS/sizes/size")

        While iterator.MoveNext

            Dim child As Xml.XPath.XPathNodeIterator = iterator.Current.SelectChildren(XPath.XPathNodeType.Element)
            Dim temp As New SizeCategories

            While child.MoveNext

                If child.Current.Name = "number" Then

                    temp.Number = child.Current.Value

                ElseIf child.Current.Name = "soak" Then

                    Dim child2 As Xml.XPath.XPathNodeIterator = child.Current.SelectChildren(XPath.XPathNodeType.Element)
                    temp.Soak = Utilities.SoakParse(child2)

                ElseIf child.Current.Name = "hardness" Then

                    Dim child2 As Xml.XPath.XPathNodeIterator = child.Current.SelectChildren(XPath.XPathNodeType.Element)
                    temp.Hardness = Utilities.SoakParse(child2)

                ElseIf child.Current.Name = "attune" Then

                    temp.Attune = child.Current.Value

                ElseIf child.Current.Name = "speed" Then

                    temp.Speed = child.Current.Value

                ElseIf child.Current.Name = "perpen" Then

                    temp.Perception_Penalty = child.Current.Value

                ElseIf child.Current.Name = "humanpen" Then

                    temp.Human_Interaction_Penalty = child.Current.Value

                ElseIf child.Current.Name = "breakliftpen" Then

                    temp.Break_Lift_Multiplier = child.Current.Value

                ElseIf child.Current.Name = "attackb" Then

                    temp.Attack_Bonus = child.Current.Value

                ElseIf child.Current.Name = "attackp" Then

                    temp.Attack_Penalty = child.Current.Value

                ElseIf child.Current.Name = "defp" Then

                    temp.Defense_Penalty = child.Current.Value

                ElseIf child.Current.Name = "mindaminc" Then

                    temp.Minimum_Damage_Increase = child.Current.Value

                ElseIf child.Current.Name = "mindampen" Then

                    temp.Minimum_Damage_Penalty = child.Current.Value

                ElseIf child.Current.Name = "maxdam" Then

                    temp.Max_Damage = child.Current.Value

                ElseIf child.Current.Name = "dimension" Then

                    temp.Dimension = child.Current.Value

                ElseIf child.Current.Name = "desc" Then

                    temp.Desc = child.Current.Value

                End If

            End While

            Sizecats.Add(temp)

        End While

        'Next Job: Ais
        'Not implemented yet

        'Next Job: Ai Charms
        'Not implemented yet

        'Next Job: System Categories
        iterator = nav.Select("/SOS/syscats/syscat")

        While iterator.MoveNext

            Dim child As Xml.XPath.XPathNodeIterator = iterator.Current.SelectChildren(XPath.XPathNodeType.Element)
            Dim temp As New Syscat

            While child.MoveNext

                If child.Current.Name = "id" Then

                    temp.ID = child.Current.Value

                ElseIf child.Current.Name = "name" Then

                    temp.Category = child.Current.Value

                End If

            End While

            Categories.Add(temp)

        End While

        'Next Job: Systems
        iterator = nav.Select("SOS/systems/system")

        While iterator.MoveNext

            Dim child As Xml.XPath.XPathNodeIterator = iterator.Current.SelectChildren(XPath.XPathNodeType.Element)
            Dim temp As New SOSSystem

            While child.MoveNext

                '---NAME,ID,CATEGORY,COST,KEYWORDS,DESC
                If child.Current.Name = "name" Then

                    temp.Name = child.Current.Value

                ElseIf child.Current.Name = "id" Then

                    temp.ID = child.Current.Value

                ElseIf child.Current.Name = "category" Then

                    temp.Category = child.Current.Value

                ElseIf child.Current.Name = "cost" Then

                    temp.Cost = child.Current.Value

                    'ElseIf child.Current.Name = "keywords" Then

                ElseIf child.Current.Name = "desc" Then

                    temp.Desc = child.Current.Value

                End If

            End While

            Systems.Add(temp)

        End While


        'Next Job: Subsystems
        iterator = nav.Select("SOS/subsystems/subsystem")

        While iterator.MoveNext

            Dim child As Xml.XPath.XPathNodeIterator = iterator.Current.SelectChildren(XPath.XPathNodeType.Element)
            Dim temp As New SubSystem

            While child.MoveNext

                If child.Current.Name = "name" Then

                    temp.Name = child.Current.Value

                ElseIf child.Current.Name = "id" Then

                    temp.ID = child.Current.Value

                ElseIf child.Current.Name = "required" Then

                    temp.Required = child.Current.Value

                ElseIf child.Current.Name = "cost" Then

                    temp.Cost = child.Current.Value

                ElseIf child.Current.Name = "desc" Then

                    temp.Desc = child.Current.Value

                End If

            End While

            SubSystems.Add(temp)


        End While

        'Next Job: TARS
        'Not Implemented yet

        'Next Job: Wards
        'Not implemented yet

    End Sub

    Public Function GetWards()

        Return Wards

    End Function

    Public Function GetTARS()

        Return TARS

    End Function

    Public Function GetAiCharms()

        Return AiCharms

    End Function

    Public Function GetAi()

        Return Ai

    End Function

    Public Function GetSizeCats()

        Return Sizecats

    End Function

    Public Function GetChassis()

        Return Chassistypes

    End Function

    Public Function GetCategories()

        Return Categories

    End Function

    Public Function GetSystems()

        Return Systems

    End Function

    Public Function GetRatings()

        Return Ratings

    End Function

    Public Function GetSubSystems()

        Return SubSystems

    End Function


End Class

Structure Rating

    Dim Dots As Integer
    Dim Attune As Integer
    Dim AP As Integer
    Dim Repair As Integer

End Structure

Structure SOSKeywords

    Dim Kword As String
    Dim Desc As String

End Structure

Structure RepairRate

    Dim Rating As Integer
    Dim ExtendedRollInterval As String
    Dim Interval As String
    Dim UnrolledInterval As String

End Structure

Structure Chassis

    Dim Name As String
    Dim Soak As Defense
    Dim Hardness As Defense
    Dim Mobility As Integer
    Dim Fatigue As Integer
    Dim Attune As Integer
    Dim Desc As String
    Dim Health As HealthLevels
    Dim Strength As Integer
    Dim Flags As ChassisFlags

End Structure

Structure SizeCategories

    Dim Number As Integer
    Dim Soak As Defense
    Dim Hardness As Defense
    Dim Attune As Integer
    Dim Speed As Integer
    Dim Perception_Penalty As String
    Dim Human_Interaction_Penalty As String
    Dim Break_Lift_Multiplier As String
    Dim Attack_Bonus As String
    Dim Attack_Penalty As String
    Dim Defense_Penalty As String
    Dim Minimum_Damage_Increase As Integer
    Dim Minimum_Damage_Penalty As Integer
    Dim Max_Damage As String
    Dim Dimension As String
    Dim Desc As String

End Structure

Structure AiType

End Structure

Structure ACharm

End Structure

Structure Syscat

    Dim ID As Integer
    Dim Category As String


End Structure

Structure SOSSystem

    Dim Name As String
    Dim ID As Integer
    Dim Category As Integer
    Dim Cost As String
    'Dim Keywords As ? - Work in progress
    Dim Desc As String

End Structure

Structure SubSystem

    Dim Name As String
    Dim ID As Integer
    Dim Required As Integer
    Dim Cost As String
    Dim Desc As String
    'Dim Effects As SystemEffects
    Dim PreReqs As PreRequisites

End Structure

Public Structure TarData

End Structure

Structure WardData

End Structure