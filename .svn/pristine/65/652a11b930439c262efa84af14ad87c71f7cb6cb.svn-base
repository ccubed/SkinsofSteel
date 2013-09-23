Imports System.Windows.Forms.TreeView
Public Class Form1

    Private Sub VehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click

        Dim ctrl As New VehicleMain
        Dim temp As New VehicleCase

        TabControl1.TabPages().Add(ctrl)

        temp.Vehicle = ctrl
        temp.Position = TabControl1.TabCount

        Vehicles.Add(temp)

        FillSystems(Vehicles(Vehicles.Count - 1).Vehicle, Data.GetSystems, Data.GetCategories)

        FillSizeCats(Vehicles(Vehicles.Count - 1).Vehicle, Data.GetSizeCats)

        FillChassis(Vehicles(Vehicles.Count - 1).Vehicle, Data.GetChassis)

        TabControl1.SelectedTab = Vehicles(Vehicles.Count - 1).Vehicle

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Data.LoadData()

    End Sub

    Private Sub MushOutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MushOutputToolStripMenuItem.Click

        Dim a As New Form
        a.Size = New System.Drawing.Size(800, 600)
        a.Controls.Add(New MushOutSelection)
        a.Visible = True
        a.Focus()

    End Sub

End Class
