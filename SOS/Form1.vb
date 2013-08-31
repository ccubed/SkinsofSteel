Imports System.Windows.Forms.TreeView
Public Class Form1

    Private Sub VehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VehicleToolStripMenuItem.Click

        Dim ctrl As New VehicleMain
        Dim temp As New VehicleCase

        TabControl1.TabPages().Add(ctrl)

        temp.Vehicle = ctrl
        temp.Position = TabControl1.TabCount

        Vehicles.Add(temp)
        Vehicles(Vehicles.Count - 1).Vehicle.ComboBox1.SelectedIndex = 1

        FillSystems(Vehicles(Vehicles.Count - 1).Vehicle, Data.GetSystems, Data.GetCategories)

        FillSizeCats(Vehicles(Vehicles.Count - 1).Vehicle, Data.GetSizeCats)

        FillChassis(Vehicles(Vehicles.Count - 1).Vehicle, Data.GetChassis)

        TabControl1.SelectedTab = Vehicles(Vehicles.Count - 1).Vehicle

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Data.LoadData()

    End Sub

    'Private Sub ArmorToolStripMenuItem_Click(sender As Object, e As EventArgs)

    '    Dim ctrl As New WornMain
    '    Dim temp As New WornCase

    '    TabControl1.TabPages().Add(ctrl)

    '    temp.Worn = ctrl
    '    temp.Position = TabControl1.TabCount - 1

    '    WornItems.Add(temp)
    '    WornItems(WornItems.Count - 1).Worn.ComboBox1.SelectedIndex = 0

    '    TabControl1.SelectedTab = WornItems(WornItems.Count - 1).Worn

    'End Sub

    'Private Sub WarstriderToolStripMenuItem_Click(sender As Object, e As EventArgs)

    '    Dim ctrl As New StriderMain
    '    Dim temp As New StriderCase

    '    TabControl1.TabPages().Add(ctrl)

    '    temp.Strider = ctrl
    '    temp.Position = TabControl1.TabCount - 1

    '    Striders.Add(temp)
    '    Striders(Striders.Count - 1).Strider.ComboBox1.SelectedIndex = 2

    '    TabControl1.SelectedTab = Striders(Striders.Count - 1).Strider

    'End Sub

    Private Sub MushOutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MushOutputToolStripMenuItem.Click

        Dim a As New Form
        a.Size = New System.Drawing.Size(800, 600)
        a.Controls.Add(New MushOutSelection)
        a.Visible = True
        a.Focus()

    End Sub
End Class
