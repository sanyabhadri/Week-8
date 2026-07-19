Imports Newtonsoft.Json

Module Module1

    Sub Main()
        SerializePlayer()
    End Sub

    Sub SerializePlayer()
        Dim myPlayer As New Players()
        myPlayer.Name= "Sanya"
        myPlayer.Age= "21"

        Dim json As String = JsonConvert.SerializeObject(myPlayer)

        Dim location As String = My.Computer.FileSystem.SpecialDirectories.Desktop



        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(location + "\jsobData.json", True)
        file.WriteLine(json)
        file.Close()


    End Sub

End Module