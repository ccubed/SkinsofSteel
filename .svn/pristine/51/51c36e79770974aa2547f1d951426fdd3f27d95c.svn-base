Imports System.Xml
Class DataFactory

    Dim Ratings As New List(Of Rating)
    Dim Keywords As New List(Of Keywords)
    Dim Repairrates As New List(Of RepairRate)
    Dim Chassistypes As New List(Of Chassis)
    Dim Sizecats As New List(Of Sizes)
    Dim Ai As New List(Of AiType)
    Dim AiCharms As New List(Of ACharm)
    Dim Categories As New List(Of Syscat)
    Dim Systems As New List(Of System)
    Dim SubSystems As New List(Of SubSystem)
    Dim TARS As New TarData
    Dim Wards As New WardData

    Public Sub LoadData()

        'Load XML Data
        Dim xmldoc As New Xml.XPath.XPathDocument("Data.xml")
        Dim nav As Xml.XPath.XPathNavigator = xmldoc.CreateNavigator()
        Dim iterator As Xml.XPath.XPathNodeIterator = nav.Select("//@version")

        MsgBox(iterator.Current.Value)

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

        Return SizeCats

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

End Structure

Structure Keywords

End Structure

Structure RepairRate

End Structure

Structure Chassis

End Structure

Structure Sizes

End Structure

Structure AiType

End Structure

Structure ACharm

End Structure

Structure Syscat

End Structure

Structure System

End Structure

Structure SubSystem

End Structure

Structure TarData

End Structure

Structure WardData

End Structure