Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

'''Apache license v2.0
'Read "Apache v2.txt"


Module EncryptionSHA1

    'Get Language
    Dim LangINI As IniFile = frmMain.LangIni
    Public Function Encrypt(ByVal plainText As String, ByVal passPhrase As String, saltValue As String, iterration As Integer) As String
        Dim hashAlgorithm As String = "SHA1"
        Dim password As Rfc2898DeriveBytes

        Dim passwordIterations As Integer

        If iterration <> 0 Then
            passwordIterations = iterration
        Else
            passwordIterations = 7
        End If

        Dim initVector As String = "^t!$Wh*IvXH50fS4"
        Dim keySize As Integer = 256

        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

        Try
            password = New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)
        Catch ex As Exception
            MsgBox(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "4"), MsgBoxStyle.Exclamation, LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"))
            Exit Function
        End Try

        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
        Dim symmetricKey As New RijndaelManaged()

        symmetricKey.Mode = CipherMode.CBC

        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

        Dim memoryStream As New MemoryStream()
        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText
#Disable Warning BC42105 ' La fonction ne renvoie pas de valeur sur tous les chemins de code
    End Function
#Enable Warning BC42105 ' La fonction ne renvoie pas de valeur sur tous les chemins de code


    <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Ne pas supprimer d'objets plusieurs fois")>
    Public Function Decrypt(ByVal cipherText As String, ByVal passPhrase As String, saltValue As String, iterration As Integer) As String

        If saltValue.Length < 8 Then
            MsgBox(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "4"), MsgBoxStyle.Exclamation, LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"))
            Exit Function
        End If

        Dim hashAlgorithm As String = "SHA1"

        Dim passwordIterations As Integer

        If iterration <> 0 Then
            passwordIterations = iterration
        Else
            passwordIterations = 7
        End If


        Dim initVector As String = "^t!$Wh*IvXH50fS4"
        Dim keySize As Integer = 256
        ' Convert strings defining encryption key characteristics into byte
        ' arrays. Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        ' encoding.
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        ' Convert our ciphertext into a byte array.
        Dim cipherTextBytes As Byte()
        Try
            cipherTextBytes = Convert.FromBase64String(cipherText)
        Catch ex As Exception
            MsgBox("Le texte n'est pas crypté!", MsgBoxStyle.Exclamation, "Attention!")
            Return ""
            Exit Function
        End Try

        ' First, we must create a password, from which the key will be 
        ' derived. This password will be generated from the specified 
        ' passphrase and salt value. The password will be created using
        ' the specified hash algorithm. Password creation can be done in
        ' several iterations.
        Dim password As New Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations)

        ' Use the password to generate pseudo-random bytes for the encryption
        ' key. Specify the size of the key in bytes (instead of bits).
        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

        ' Create uninitialized Rijndael encryption object.
        Dim symmetricKey As New RijndaelManaged()

        ' It is reasonable to set encryption mode to Cipher Block Chaining
        ' (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC

        ' Generate decryptor from the existing key bytes and initialization 
        ' vector. Key size will be defined based on the number of the key 
        ' bytes.
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim memoryStream As New MemoryStream(cipherTextBytes)

        ' Define cryptographic stream (always use Read mode for encryption).
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

        ' Since at this point we don't know what the size of decrypted data
        ' will be, allocate the buffer long enough to hold ciphertext;
        ' plaintext is never longer than ciphertext.
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
        Dim decryptedByteCount As Integer
        Try
            ' Start decrypting.
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        Catch ex As Exception
            MsgBox(LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "50"), MsgBoxStyle.Exclamation, LangINI.GetKeyValue("Popotte - EditorWindow - Messagebox", "7"))
            Exit Function
        End Try

        ' Close both streams.
        Try
            memoryStream.Close()
            cryptoStream.Close()
        Catch ex As Exception
        End Try

        ' Convert decrypted data into a string. 
        ' Let us assume that the original plaintext string was UTF8-encoded.
        Dim plainText As String = ""
        Try
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
        Catch ex As Exception
        End Try

        ' Return decrypted string.   
        Return plainText
#Disable Warning BC42105 ' La fonction ne renvoie pas de valeur sur tous les chemins de code
    End Function

#Enable Warning BC42105 ' La fonction ne renvoie pas de valeur sur tous les chemins de code

End Module
