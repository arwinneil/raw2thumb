Imports MaterialSkin

Public Class Home

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Cyan300, Primary.Cyan400, Primary.Cyan200, Accent.LightBlue200, TextShade.WHITE)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        GetRaw.Filter = "Raw File|*.ari;*.arw;*.bay;*.crw;*.cr2;*.cap;*.dcs;*.dcr;*.dng;*.drf;*.eip;*.erf;*.fff;*.iiq;*.k25;*.kdc;*.mdc;*.mef;*.mos;*.mrw;*.nef;*.nrw;*.obm;*.orf;*.pef;*.ptx;*.pxn;*.r3d;*.raf;*.raw;*.rwl;*.rw2;*.rwz;*.sr2;*.srf;*.srw', '.x3f'"

        If GetRaw.ShowDialog() = DialogResult.OK Then
            ExtractThumb(GetRaw.FileName)
        End If

    End Sub

    Sub ExtractThumb(RawDir As String)

        Dim arguments As String

        Dim temp = Directory.CreateTemp()

        arguments = "/k exiv2 -ep -l " & temp & " " & RawDir

        Dim exiv2 As New ProcessStartInfo("cmd", arguments)
        exiv2.WindowStyle = ProcessWindowStyle.Hidden
        exiv2.CreateNoWindow = True

        Process.Start(exiv2)
        MsgBox("number of files is ")

        ' Directory.DisposeTemp(temp)

        Dim counter As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
        counter = My.Computer.FileSystem.GetFiles(temp)
        MsgBox("number of files is " & (counter.Count))

        Dim i As Integer = counter.Count - 1

        Result(counter(i))

    End Sub

    Sub Result(Preview As String)

        OpenPanel.Visible = False
        PictureBox2.Image = Image.FromFile(Preview)

    End Sub

    'Private Sub ScanRaw(RawDir As String)
    '    Dim arguments As String

    '    Dim temp = Directory.CreateTemp()

    '    arguments = "/k exiv2 -pp " & RawDir & " > " & temp & "\log.txt"

    '    Dim exiv2 As New ProcessStartInfo("cmd", arguments)
    '    exiv2.WindowStyle = ProcessWindowStyle.Hidden
    '    exiv2.CreateNoWindow = True

    '    Process.Start(exiv2)

    '    Directory.DisposeTemp(temp)

    'End Sub

End Class