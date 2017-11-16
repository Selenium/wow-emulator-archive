Attribute VB_Name = "SHA1"
Option Explicit

' TITLE:
' Secure Hash Algorithm, SHA-1

' AUTHORS:
' Adapted by Iain Buchan from Visual Basic code posted at Planet-Source-Code by Peter Girard
' http://www.planetsourcecode.com/xq/ASP/txtCodeId.13565/lngWId.1/qx/vb/scripts/ShowCode.htm

' PURPOSE:
' Creating a secure identifier from person-identifiable data

' The function SecureHash generates a 160-bit (20-hex-digit) message digest for a given message (String).
' It is computationally infeasable to recover the message from the digest.
' The digest is unique to the message within the realms of practical probability.
' The only way to find the source message for a digest is by hashing all possible messages and comparison of their digests.

' REFERENCES:
' For a fuller description see FIPS Publication 180-1:
' http://www.itl.nist.gov/fipspubs/fip180-1.htm

' SAMPLE:
' Message: "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq"
' Returns Digest: "84983E441C3BD26EBAAE4AA1F95129E5E54670F1"
' Message: "abc"
' Returns Digest: "A9993E364706816ABA3E25717850C26C9CD0D89D"

Private Type Word
 B0 As Byte
 B1 As Byte
 B2 As Byte
 B3 As Byte
End Type

'Public Function idcode(cr As Range) As String
'Dim tx As String
'Dim ob As Object
'For Each ob In cr
' tx = tx & LCase(CStr(ob.Value2))
'Next
'idcode = sha1(tx)
'End Function

Private Function AndW(w1 As Word, w2 As Word) As Word
 AndW.B0 = w1.B0 And w2.B0
 AndW.B1 = w1.B1 And w2.B1
 AndW.B2 = w1.B2 And w2.B2
 AndW.B3 = w1.B3 And w2.B3
End Function

Private Function OrW(w1 As Word, w2 As Word) As Word
 OrW.B0 = w1.B0 Or w2.B0
 OrW.B1 = w1.B1 Or w2.B1
 OrW.B2 = w1.B2 Or w2.B2
 OrW.B3 = w1.B3 Or w2.B3
End Function

Private Function XorW(w1 As Word, w2 As Word) As Word
 XorW.B0 = w1.B0 Xor w2.B0
 XorW.B1 = w1.B1 Xor w2.B1
 XorW.B2 = w1.B2 Xor w2.B2
 XorW.B3 = w1.B3 Xor w2.B3
End Function

Private Function NotW(w As Word) As Word
 NotW.B0 = Not w.B0
 NotW.B1 = Not w.B1
 NotW.B2 = Not w.B2
 NotW.B3 = Not w.B3
End Function

Private Function AddW(w1 As Word, w2 As Word) As Word
 Dim i As Long, w As Word

 i = CLng(w1.B3) + w2.B3
 w.B3 = i Mod 256
 i = CLng(w1.B2) + w2.B2 + (i \ 256)
 w.B2 = i Mod 256
 i = CLng(w1.B1) + w2.B1 + (i \ 256)
 w.B1 = i Mod 256
 i = CLng(w1.B0) + w2.B0 + (i \ 256)
 w.B0 = i Mod 256
  
 AddW = w
End Function
Private Function CircShiftLeftW(w As Word, N As Long) As Word
 Dim d1 As Double, d2 As Double
  
 d1 = WordToDouble(w)
 d2 = d1
 d1 = d1 * (2 ^ N)
 d2 = d2 / (2 ^ (32 - N))
 CircShiftLeftW = OrW(DoubleToWord(d1), DoubleToWord(d2))
End Function

Private Function WordToHex(w As Word) As String
 WordToHex = Right$("0" & hex$(w.B0), 2) & Right$("0" & hex$(w.B1), 2) & Right$("0" & hex$(w.B2), 2) & Right$("0" & hex$(w.B3), 2)
End Function

Private Function HexToWord(h As String) As Word
 HexToWord = DoubleToWord(Val("&H" & h & "#"))
End Function

Private Function DoubleToWord(N As Double) As Word
 DoubleToWord.B0 = Int(DMod(N, 2 ^ 32) / (2 ^ 24))
 DoubleToWord.B1 = Int(DMod(N, 2 ^ 24) / (2 ^ 16))
 DoubleToWord.B2 = Int(DMod(N, 2 ^ 16) / (2 ^ 8))
 DoubleToWord.B3 = Int(DMod(N, 2 ^ 8))
End Function

Private Function WordToDouble(w As Word) As Double
 WordToDouble = (w.B0 * (2 ^ 24)) + (w.B1 * (2 ^ 16)) + (w.B2 * (2 ^ 8)) + w.B3
End Function

Private Function DMod(value As Double, divisor As Double) As Double
 DMod = value - (Int(value / divisor) * divisor)
 If DMod < 0 Then DMod = DMod + divisor
End Function

Private Function F(t As Long, B As Word, C As Word, D As Word) As Word
Select Case t
 Case Is <= 19
  F = OrW(AndW(B, C), AndW(NotW(B), D))
 Case Is <= 39
  F = XorW(XorW(B, C), D)
 Case Is <= 59
  F = OrW(OrW(AndW(B, C), AndW(B, D)), AndW(C, D))
 Case Else
  F = XorW(XorW(B, C), D)
 End Select
End Function

Public Function sha1(inMessage As String) As String

Dim inLen As Long, inLenW As Word, padMessage As String, numBlocks As Long, w(0 To 79) As Word, blockText As String, wordText As String, i As Long, t As Long, temp As Word, k(0 To 3) As Word, H0 As Word, H1 As Word, H2 As Word, H3 As Word, H4 As Word, A As Word, B As Word, C As Word, D As Word, E As Word

inLen = Len(inMessage)
inLenW = DoubleToWord(CDbl(inLen) * 8)
  
padMessage = inMessage & Chr$(128) & String$((128 - (inLen Mod 64) - 9) Mod 64, Chr$(0)) & String$(4, Chr$(0)) & Chr$(inLenW.B0) & Chr$(inLenW.B1) & Chr$(inLenW.B2) & Chr$(inLenW.B3)
  
numBlocks = Len(padMessage) / 64
  
' initialize constants
k(0) = HexToWord("5A827999")
k(1) = HexToWord("6ED9EBA1")
k(2) = HexToWord("8F1BBCDC")
k(3) = HexToWord("CA62C1D6")

'initialize 160-bit (5 words) buffer
H0 = HexToWord("67452301")
H1 = HexToWord("EFCDAB89")
H2 = HexToWord("98BADCFE")
H3 = HexToWord("10325476")
H4 = HexToWord("C3D2E1F0")

'each 512 byte message block consists of 16 words (W) but W is expanded to 80 words
For i = 0 To numBlocks - 1
 blockText = Mid$(padMessage, (i * 64) + 1, 64)
 'initialize a message block
 For t = 0 To 15
  wordText = Mid$(blockText, (t * 4) + 1, 4)
  w(t).B0 = Asc(Mid$(wordText, 1, 1))
  w(t).B1 = Asc(Mid$(wordText, 2, 1))
  w(t).B2 = Asc(Mid$(wordText, 3, 1))
  w(t).B3 = Asc(Mid$(wordText, 4, 1))
 Next
    
 'create extra words from the message block
 For t = 16 To 79
  'W(t) = S^1 (W(t-3) XOR W(t-8) XOR W(t-14) XOR W(t-16))
  w(t) = CircShiftLeftW(XorW(XorW(XorW(w(t - 3), w(t - 8)), w(t - 14)), w(t - 16)), 1)
 Next
    
 'make initial assignments to the buffer
 A = H0
 B = H1
 C = H2
 D = H3
 E = H4
    
 'process the block
 For t = 0 To 79
  temp = AddW(AddW(AddW(AddW(CircShiftLeftW(A, 5), F(t, B, C, D)), E), w(t)), k(t \ 20))
  E = D
  D = C
  C = CircShiftLeftW(B, 30)
  B = A
  A = temp
 Next
    
 H0 = AddW(H0, A)
 H1 = AddW(H1, B)
 H2 = AddW(H2, C)
 H3 = AddW(H3, D)
 H4 = AddW(H4, E)
Next

sha1 = WordToHex(H0) & WordToHex(H1) & WordToHex(H2) & WordToHex(H3) & WordToHex(H4)

End Function



Public Function GenerateX(user As String, Pass As String, Salt) As String
    Dim TempHash As String
    Dim temp As String
    Dim x As String
    'Dim Salt As String
    Dim i As Integer
    
    temp = ""
    'Salt = "33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f"
    For i = 1 To Len(Salt) Step 2
        temp = temp & Chr(Val("&H" & Mid(Salt, i, 2)))
    Next i
    Salt = temp
    temp = UCase(user) & ":" & UCase(Pass)
    
    TempHash = sha1(UCase(temp))
    temp = ""
    For i = 1 To Len(TempHash) Step 2
        temp = temp & Chr(Val("&H" & Mid(TempHash, i, 2)))
    Next i
    TempHash = temp
    x = sha1(Salt & TempHash)
    GenerateX = x
End Function
