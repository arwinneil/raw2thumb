Public Class Directory

    Shared Function CreateTemp()

        'Funtion creates hidden  temporary directory /temp in program running directory and returns full path
        'to tempotary directory

        Dim temp As String

        temp = AppDomain.CurrentDomain.BaseDirectory & "temp"

        If System.IO.Directory.Exists(temp) Then
            System.IO.Directory.Delete(temp, True)
        End If

        System.IO.Directory.CreateDirectory(temp)
        System.IO.File.SetAttributes(temp, System.IO.FileAttributes.Hidden)

        Return temp

    End Function

    Shared Sub DisposeTemp(temp As String)
        System.IO.Directory.Delete(temp, True)
    End Sub

End Class