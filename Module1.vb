Imports System.IO
Imports System.Security.Policy
Imports Newtonsoft.Json

'TODO:1. Change Procedure name to your own procedure name
'TODO:2.  Add Json package to the resources
'TODO:3. Create A Project Class
'TODO:4.  Create A Json file for the Project Class
'TODO:5.  Refactor writeFile procedure to take a string for data input
'TODO:6.  move the input variable up to the global class variable access
'TODO:7.  Seralize Project Class
'TODO:8.  Deseralize The Project json Class
'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions
'TODO:10.Refactor your code to create subfolders in a separate procedure
'TODO:11.Remove reference comments


Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead
    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view


    Dim ProjectName As String
    Dim FullDirectory As String

    Sub Main()

        Dim input As String = 0
        While input <> "exit"
            Console.WriteLine("BeatBridge")
            Console.WriteLine("create your music world project.")
            Console.WriteLine()

            Console.WriteLine("Enter your music project name:")
            ProjectName = Console.ReadLine()

            'create project folder on Desktop'
            Dim desktop As String =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            FullDirectory = Path.Combine(desktop, ProjectName)

            Directory.CreateDirectory(FullDirectory)

            Console.WriteLine()
            Console.WriteLine("choose a command:")
            Console.WriteLine("create - build ypur music world")
            Console.WriteLine("exit - close BeatBridge")


            UserInput = Console.ReadLine().ToLower()


            If UserInput = "create" Then

                CreateSubFolders()

                SaveProjectJSON()



                Console.WriteLine()
                Console.WriteLine("Your BeatBridge project has been created successfully!")
                Console.WriteLine("project saved at: " & FullDirectory)

            ElseIf UserInput <> "exit" Then

                Console.WriteLine("command not recognized.")
            End If

        End While

    End Sub

    Private Sub MakeP2PProjectFolders()
        ''' <summary>
        ''' Creates project subfolders.
        ''' </summary>

        'Documentation folders
        CreateProjectFolder(FullDirectory, "Docs")
        CreateProjectFolder($"{FullDirectory}\Docs", "Research")
        CreateProjectFolder($"{FullDirectory}\Docs", "Design")
        CreateProjectFolder($"{FullDirectory}\Docs", "References")

        'Asset folders
        CreateProjectFolder(FullDirectory, "Assets")
        CreateProjectFolder($"{FullDirectory}\Assets", "Art")
        CreateProjectFolder($"{FullDirectory}\Assets", "AlbumArt")
        CreateProjectFolder($"{FullDirectory}\Assets", "Images")
        CreateProjectFolder($"{FullDirectory}\Assets", "Icons")


        'Data folders
        CreateProjectFolder(FullDirectory, "Data")
        CreateProjectFolder($"{FullDirectory}\Data", "Playlists")
        CreateProjectFolder($"{FullDirectory}\Data", "Songs")
        CreateProjectFolder($"{FullDirectory}\Data", "JSON")

        'Music folders
        CreateProjectFolder(FullDirectory, "Audio")
        CreateProjectFolder($"{FullDirectory}\Audio", "Songs")
        CreateProjectFolder($"{FullDirectory}\Audio", "Effects")

        'Music Playlists
        CreateProjectFolder(FullDirectory,
                            "MusicPlaylists")
        CreateProjectFolder($"{FullDirectory}\MusicPlaylists", "RNB")
        CreateProjectFolder($"{FullDirectory}\MusicPlaylists", "Rap")
        CreateProjectFolder($"{FullDirectory}\MusicPlaylists", "Indie")
        CreateProjectFolder($"{FullDirectory}\MusicPlaylists", "Rock")

        'Screenshots
        CreateProjectFolder(FullDirectory, "Screenshots")

    Private Sub WriteFile(fileName As String, location As String)
        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            file.WriteLine("This is a readme file for the team")
            file.Close()
        End If

    End Sub

    Sub CreateProjectFolder(newFolderPath As String, ProjectName As String)
        My.Computer.FileSystem.CreateDirectory(newFolderPath + ProjectName)
    End Sub

End Module