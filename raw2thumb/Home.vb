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
            GeneratePreview(GetRaw.FileName)
        End If

    End Sub

    Private Sub GeneratePreview(RawDir As String)

        Dim temp, arguments As String

        temp = AppDomain.CurrentDomain.BaseDirectory & "\temp"

        If (Not System.IO.Directory.Exists(temp)) Then
            System.IO.Directory.CreateDirectory(temp)
            System.IO.File.SetAttributes(temp, System.IO.FileAttributes.Hidden)
        Else
            System.IO.Directory.Delete(temp, True)
            System.IO.Directory.CreateDirectory(temp)
            System.IO.File.SetAttributes(temp, System.IO.FileAttributes.Hidden)
        End If

        arguments = "/k exiv2 -ep -l" & temp & " " & RawDir

        Dim exiv2 As New ProcessStartInfo("cmd", arguments)
        exiv2.WindowStyle = ProcessWindowStyle.Hidden
        exiv2.CreateNoWindow = True
        Process.Start(exiv2)

        System.IO.Directory.Delete(temp, True)

    End Sub

End Class