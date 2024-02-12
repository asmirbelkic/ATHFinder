Imports System.Xml.Linq
Imports System.IO
Imports System.Net
Imports System.Diagnostics ' Pour Process.Start


Public Class FormATHFinder
    ' Liste pour stocker les chemins des fichiers trouvés correspondants
    Private ReadOnly foundFilePaths As New List(Of String)

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim txtBox As String = ORTextBox.Text
        Dim directory As String = GlobalVariables.Dir
        SearchFile(txtBox, directory)
    End Sub

    Private Async Sub Ouvrir_Click(sender As Object, e As EventArgs) Handles Ouvrir.Click
        ' Ouvre tous les fichiers XML où la référence de l'OR a été trouvée
        If foundFilePaths.Count > 0 Then
            For Each filePath In foundFilePaths
                Try
                    ' Ouvre chaque fichier avec l'application par défaut pour les fichiers XML
                    Process.Start(filePath)
                    ' Attendre 500 ms avant d'ouvrir le prochain fichier
                    Await Task.Delay(500)
                Catch ex As Exception
                    ' Afficher un message d'erreur si le fichier ne peut pas être ouvert
                    MessageBox.Show($"Impossible d'ouvrir le fichier : {filePath}" & vbCrLf & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next
        Else
            MessageBox.Show("Aucun fichier trouvé à ouvrir.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub Changer_Click(sender As Object, e As EventArgs) Handles Changer.Click
        Dir = GetFolder()
        CheminDossier.Text = Dir
    End Sub

    Private Sub FormATHFinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForUpdates()
        Dim currentVersion As New Version(Application.ProductVersion)
        Dim shortVersion As String = String.Format("{0}.{1}", currentVersion.Major, currentVersion.Minor)
        Label4.Text = String.Format("ATH Finder by Asmir {0} - Pour Solware 2024", shortVersion)

        ActiveControl = ORTextBox

        ' Liste des chemins de dossiers potentiels
        Dim potentialPaths As New List(Of String) From {
            "C:\MicrautoASP\ASP\Fichier\FleetBox\",
            "C:WINmotor\SOC1\Fleetbox\log",
            "R:WINmotor\SOC1\Fleetbox\log"
        }

        ' Trouver le chemin avec le fichier *_RETOUR.xml le plus récent
        Dim mostRecentPath = FindMostRecentFilePath(potentialPaths)

        If Not String.IsNullOrEmpty(mostRecentPath) Then
            GlobalVariables.Dir = mostRecentPath
            CheminDossier.Text = mostRecentPath
        Else
            GlobalVariables.Dir = GetFolder("Le dossier spécifié n'a pas été trouvé. Merci de localiser le dossier.")
            CheminDossier.Text = GlobalVariables.Dir
        End If
    End Sub

    Public Sub CheckForUpdates()
        Dim currentVersion As New Version(Application.ProductVersion)
        ' Créer une instance de MyWebClient avec un timeout de 10 secondes (10000 millisecondes)
        Dim webClient As New MyWebClient(10000)

        ' Vérifier la connexion Internet avant de continuer
        If Not NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            MessageBox.Show("Aucune connexion Internet détectée. La vérification de mise à jour est impossible.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Modifier l'URL par l'emplacement de votre fichier version.txt ou update.json sur GitHub
            Dim latestVersionString As String = webClient.DownloadString("https://pastebin.com/raw/vvXtLBvm")
            Dim latestVersion As New Version(latestVersionString.Trim())

            If latestVersion > currentVersion Then
                ' Une nouvelle version est disponible, demandez si l'utilisateur souhaite la télécharger
                Dim result As DialogResult = MessageBox.Show("Une nouvelle version est disponible. Voulez-vous la télécharger ?", "Mise à jour disponible", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    ' Ouvrir le navigateur par défaut à l'adresse de la page de téléchargement
                    Process.Start("https://github.com/asmirbelkic/ATHFinder/releases/")
                    ' Fermer l'application
                    Application.Exit()
                End If
            End If
        Catch ex As WebException When ex.Status = WebExceptionStatus.Timeout
            MessageBox.Show("La vérification des mises à jour a expiré. Veuillez réessayer plus tard.", "Erreur de mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            ' Gérer spécifiquement les exceptions liées au réseau
            MessageBox.Show("Impossible de vérifier les mises à jour: vérifiez votre connexion Internet.", "Erreur de mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Gérer les autres types d'exceptions
            MessageBox.Show("Impossible de vérifier les mises à jour: " & ex.Message, "Erreur de mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NumeroOr_KeyDown(sender As Object, e As KeyEventArgs) Handles ORTextBox.KeyDown
        ' Vérifier si la touche Entrée est pressée
        If e.KeyCode = Keys.Enter Then
            ' Empêcher le signal sonore de confirmation
            e.SuppressKeyPress = True
            ' Appeler la méthode SearchFile
            Dim directory As String = GlobalVariables.Dir
            SearchFile(ORTextBox.Text, directory)
        End If
    End Sub

    Private Sub CheminDossier_TextChanged(sender As Object, e As EventArgs) Handles CheminDossier.TextChanged
        GlobalVariables.Dir = CheminDossier.Text
    End Sub

    Private Sub CheminDossier_DoubleClick(sender As Object, e As EventArgs) Handles CheminDossier.DoubleClick
        ' Ouvrir le dossier sélectionné dans l'explorateur de fichiers
        Process.Start("explorer.exe", GlobalVariables.Dir)
    End Sub

    Private Function GetFolder(Optional ByVal message As String = "Merci de localiser le dossier.") As String
        Using dialog As New FolderBrowserDialog()
            dialog.Description = message
            dialog.ShowNewFolderButton = False

            ' Vérifier si GlobalVariables.Dir contient un chemin valide et l'utiliser comme chemin initial
            If Not String.IsNullOrWhiteSpace(GlobalVariables.Dir) AndAlso Directory.Exists(GlobalVariables.Dir) Then
                dialog.SelectedPath = GlobalVariables.Dir
            Else
                ' Sinon, définir le chemin initial au Bureau
                dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            End If

            If dialog.ShowDialog() = DialogResult.OK Then
                ' L'utilisateur a sélectionné un dossier
                Return dialog.SelectedPath
            Else
                ' L'utilisateur a annulé la sélection
                Return GlobalVariables.Dir ' Ou une valeur par défaut / gestion d'erreur
            End If
        End Using
    End Function


    Private Function FindMostRecentFilePath(potentialPaths As List(Of String)) As String
        Dim mostRecentDate As DateTime = DateTime.MinValue
        Dim mostRecentPath As String = String.Empty

        For Each path In potentialPaths
            If Directory.Exists(path) Then
                Dim files = Directory.GetFiles(path, "*_RETOUR.xml")
                For Each file As String In files
                    Dim fileInfo = New FileInfo(file)
                    Dim lastWriteTime = fileInfo.LastWriteTime ' Utilisation de FileInfo ici
                    If lastWriteTime > mostRecentDate Then
                        mostRecentDate = lastWriteTime
                        mostRecentPath = path
                    End If
                Next
            End If
        Next

        Return mostRecentPath
    End Function


    ' Définissez un objet personnalisé pour contenir les données extraites
    Public Class WorkOrderData
        Public Property InputDate As DateTime ' Ajouter cette ligne pour la date d'entrée
        Public Property AthorisReferences As List(Of String) = New List(Of String)()
        Public Property ORStatus As List(Of String) = New List(Of String)()
        Public Property StatusCodeDescription As String = String.Empty
        Public Property FormattedDate As String = String.Empty
    End Class


    Private Function ExtractDataFromXml(file As String, txtBox As String) As WorkOrderData
        Dim data As New WorkOrderData()

        Try
            Dim doc As XDocument = XDocument.Load(file)

            ' Extraire l'espace de noms du premier élément workOrder (ou tout autre élément pertinent)
            Dim workOrderElement = doc.Descendants().FirstOrDefault(Function(x) x.Name.LocalName = "workOrder")
            If workOrderElement Is Nothing Then
                Return data ' Retourne un objet data vide si aucun workOrder n'est trouvé
            End If

            Dim ns As XNamespace = workOrderElement.Name.Namespace

            ' Utiliser l'espace de noms extrait pour accéder aux éléments workOrder
            Dim workOrders = doc.Descendants(ns + "workOrder").Where(Function(x) x.Attribute("repairerReference") IsNot Nothing AndAlso x.Attribute("repairerReference").Value = txtBox)



            If workOrders.Any() Then
                data.AthorisReferences.AddRange(workOrders.Select(Function(x) x.Attribute("athorisReference").Value))
                data.ORStatus.AddRange(workOrders _
                        .Where(Function(x) x.Attribute("state") IsNot Nothing) _
                        .Select(Function(x) x.Attribute("state").Value))


                ' Accéder à l'élément status en utilisant l'espace de noms extrait
                Dim status = doc.Descendants(ns + "status").FirstOrDefault()
                If status IsNot Nothing Then
                    data.StatusCodeDescription = status.Element(ns + "statusCode").Attribute("description").Value
                    Dim timeInput = status.Attribute("timeInput").Value
                    If DateTime.TryParse(timeInput, data.InputDate) Then
                        ' Si le parsing est réussi, data.InputDate contiendra la date d'entrée
                        data.FormattedDate = data.InputDate.ToString("le dd/MM/yyyy à HH:mm")
                    End If
                End If
            End If
        Catch ex As System.IO.FileNotFoundException
            Console.WriteLine("Le fichier spécifié n'a pas été trouvé : " & ex.Message)
        Catch ex As System.Xml.XmlException
            Console.WriteLine("Erreur de lecture du fichier XML : " & ex.Message)
        Catch ex As Exception
            Console.WriteLine("Une erreur inattendue est survenue : " & ex.Message)
        End Try

        Return data
    End Function

    Private Sub SearchFile(ByVal txtBox As String, ByVal directory As String)
        foundFilePaths.Clear()
        BoxORStatus.Clear()
        ATHRef.Clear()
        ATHStatus.Clear()
        Ouvrir.Enabled = False
        StatusDate.Clear()

        Dim latestFileDate As DateTime = DateTime.MinValue
        Dim latestInputDate As DateTime = DateTime.MinValue
        Dim selectedFileData As WorkOrderData = Nothing

        If txtBox.Length > 1 AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(txtBox, "[^a-zA-Z0-9 .-]") Then
            Dim files As String() = System.IO.Directory.GetFiles(directory, "*_RETOUR.XML")
            If files.Length > 0 Then
                For Each file As String In files
                    Dim data As WorkOrderData = ExtractDataFromXml(file, txtBox)
                    ' Ajoutez le fichier à foundFilePaths si la référence correspond, indépendamment des conditions de date
                    If data.AthorisReferences.Count > 0 Then
                        Console.WriteLine(file)
                        foundFilePaths.Add(file)
                        ' Sélectionnez séparément le fichier le plus récent
                        Dim fileCreationDate As Date = IO.File.GetCreationTime(file)
                        If data.InputDate > latestInputDate OrElse (data.InputDate = latestInputDate AndAlso fileCreationDate > latestFileDate) Then
                            latestInputDate = data.InputDate
                            latestFileDate = fileCreationDate
                            selectedFileData = data
                        End If
                    End If
                Next

                If selectedFileData IsNot Nothing Then
                    ' Mise à jour de l'UI avec les données du fichier sélectionné
                    athorisReference = selectedFileData.AthorisReferences.First()
                    CopyATH.Enabled = True
                    ATHRef.Text = String.Join(", ", selectedFileData.AthorisReferences)
                    BoxORStatus.Text = String.Join(", ", selectedFileData.ORStatus)
                    StatusDate.Text = selectedFileData.FormattedDate
                    ATHStatus.Text = selectedFileData.StatusCodeDescription
                    Ouvrir.Enabled = True
                ElseIf foundFilePaths.Count > 0 Then
                    ' Si des fichiers correspondants ont été trouvés mais aucun n'est sélectionné comme le plus récent
                    MessageBox.Show("Des fichiers correspondants ont été trouvés mais aucun n'a pu être identifié comme le plus récent basé sur les critères donnés.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("L'OR " & txtBox & " est introuvable dans les fichiers existants", "Erreur")
                End If
            Else
                MessageBox.Show("Aucun fichier XML trouvé dans le répertoire spécifié.", "Erreur")
            End If
        Else
            MessageBox.Show("Veuillez entrer un numéro d'OR valide.", "Erreur")
        End If
    End Sub


    Private Sub CopyATH_Click(sender As Object, e As EventArgs) Handles CopyATH.Click
        If Not String.IsNullOrEmpty(GlobalVariables.athorisReference) Then
            My.Computer.Clipboard.SetText(athorisReference)
        End If
    End Sub
End Class

Public Class MyWebClient
    Inherits WebClient
    Private _timeout As Integer

    Public Sub New(ByVal timeout As Integer)
        MyBase.New()
        Me._timeout = timeout
    End Sub

    Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
        Dim request As WebRequest = MyBase.GetWebRequest(address)
        If request IsNot Nothing Then
            request.Timeout = _timeout
        End If
        Return request
    End Function
End Class

Public Module GlobalVariables
    Public Dir As String
    Public athorisReference As String
End Module