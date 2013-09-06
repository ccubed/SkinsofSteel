Public Class MushOutSelection

    Private Sub MushOutSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each item As VehicleCase In Vehicles

            ComboBox1.Items.Add(item.Vehicle.TextBox1.Text)

        Next

    End Sub

    Private Sub Handle_Selection_Change(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim temp As String
        Dim tempve As VehicleMain = Vehicles(ComboBox1.SelectedIndex).Vehicle

        'Name of Thing
        temp = tempve.TextBox1.Text + vbNewLine

        'Attune Calculation
        Dim i As Integer = 0
        Dim tempar As Rating = Data.GetRatings()(tempve.ARatingCBox.SelectedIndex)
        Dim tempch As Chassis = Data.GetChassis()(tempve.ComboBox3.SelectedIndex)
        Dim tempsc As SizeCategories = Data.GetSizeCats()(tempve.ComboBox2.SelectedIndex)
        i = i + tempar.Attune
        i = i + tempch.Attune
        i = i + tempsc.Attune

        'Artifact Rating and then Attune
        temp = temp + "Artifact Rating: " + tempar.Dots.ToString + vbNewLine
        temp = temp + "Attune Cost: " + i.ToString + vbNewLine

        'Cost in XP
        temp = temp + "XP Cost: " + Math.Ceiling(tempar.Dots / 3).ToString + vbNewLine

        'Size Category
        temp = temp + "Size Category: " + tempsc.Number.ToString + vbNewLine

        'Chassis
        temp = temp + "Chassis Type: " + tempch.Name + vbNewLine + vbNewLine

        'AP Amount
        temp = temp + "Starting AP: " + tempve.APAmt.Text + vbNewLine + vbNewLine

        'List of Systems and SubSystems
        temp = temp + "Listing of Systems and SubSystems" + vbNewLine + "---------------------------------" + vbNewLine

        For Each a As TreeNode In tempve.TreeView3.Nodes

            temp = temp + a.Text + " - "

            Dim protect As Integer = 0

            For Each b As SOSSystem In Data.GetSystems

                If b.Name = a.Text Then

                    temp = temp + b.Cost.ToString + vbNewLine
                    protect = 1

                End If

            Next

            For Each b As SubSystem In Data.GetSubSystems

                If b.Name = a.Text Then

                    temp = temp + b.Cost.ToString + vbNewLine
                    protect = 1

                End If

            Next

            If protect = 0 Then

                temp = temp + vbNewLine

            End If

        Next

        'AP Spent
        temp = temp + vbNewLine + "AP Spent: " + tempve.APSpent.Text
        RichTextBox1.Text = temp

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim temp As String = ""

        For Each line As String In RichTextBox1.Lines

            temp = temp + line + "%R"

        Next

        RichTextBox1.Text = temp

    End Sub
End Class
