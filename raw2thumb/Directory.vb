Public Class Directory
    Shared temp As String

    Shared Function CreateTemp()

        'Funtion creates hidden  temporary directory /temp in program running directory and returns full path
        'to tempotary directory

        temp = AppDomain.CurrentDomain.BaseDirectory & "temp"

        If System.IO.Directory.Exists(temp) Then
            System.IO.Directory.Delete(temp, True)
        End If

        System.IO.Directory.CreateDirectory(temp)

        If System.IO.Directory.Exists(temp) Then
            System.IO.File.SetAttributes(temp, System.IO.FileAttributes.Hidden)
        End If

        Return temp

    End Function

    Shared Sub DisposeTemp()
        System.IO.Directory.Delete(temp, True)
    End Sub

    Shared Function GetTemp()

        Return temp

    End Function

End Class