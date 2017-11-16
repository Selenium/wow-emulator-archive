Option Strict Off
Option Explicit On
Module SHA1
	
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
	
	Private Structure Word
		Dim B0 As Byte
		Dim B1 As Byte
		Dim B2 As Byte
		Dim B3 As Byte
	End Structure
	
	'Public Function idcode(cr As Range) As String
	'Dim tx As String
	'Dim ob As Object
	'For Each ob In cr
	' tx = tx & LCase(CStr(ob.Value2))
	'Next
	'idcode = sha1(tx)
	'End Function
	
	Private Function AndW(ByRef w1 As Word, ByRef w2 As Word) As Word
		AndW.B0 = w1.B0 And w2.B0
		AndW.B1 = w1.B1 And w2.B1
		AndW.B2 = w1.B2 And w2.B2
		AndW.B3 = w1.B3 And w2.B3
	End Function
	
	Private Function OrW(ByRef w1 As Word, ByRef w2 As Word) As Word
		OrW.B0 = w1.B0 Or w2.B0
		OrW.B1 = w1.B1 Or w2.B1
		OrW.B2 = w1.B2 Or w2.B2
		OrW.B3 = w1.B3 Or w2.B3
	End Function
	
	Private Function XorW(ByRef w1 As Word, ByRef w2 As Word) As Word
		XorW.B0 = w1.B0 Xor w2.B0
		XorW.B1 = w1.B1 Xor w2.B1
		XorW.B2 = w1.B2 Xor w2.B2
		XorW.B3 = w1.B3 Xor w2.B3
	End Function
	
	Private Function NotW(ByRef w As Word) As Word
		NotW.B0 = Not w.B0
		NotW.B1 = Not w.B1
		NotW.B2 = Not w.B2
		NotW.B3 = Not w.B3
	End Function
	
	Private Function AddW(ByRef w1 As Word, ByRef w2 As Word) As Word
		Dim i As Integer
		Dim w As Word
		
		i = CInt(w1.B3) + w2.B3
		w.B3 = i Mod 256
		i = CInt(w1.B2) + w2.B2 + (i \ 256)
		w.B2 = i Mod 256
		i = CInt(w1.B1) + w2.B1 + (i \ 256)
		w.B1 = i Mod 256
		i = CInt(w1.B0) + w2.B0 + (i \ 256)
		w.B0 = i Mod 256
		
		'UPGRADE_WARNING: Couldn't resolve default property of object AddW. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		AddW = w
	End Function
	Private Function CircShiftLeftW(ByRef w As Word, ByRef N As Integer) As Word
		Dim d1, d2 As Double
		
		d1 = WordToDouble(w)
		d2 = d1
		d1 = d1 * (2 ^ N)
		d2 = d2 / (2 ^ (32 - N))
		CircShiftLeftW = OrW(DoubleToWord(d1), DoubleToWord(d2))
	End Function
	
	Private Function WordToHex(ByRef w As Word) As String
		WordToHex = Right("0" & Hex(w.B0), 2) & Right("0" & Hex(w.B1), 2) & Right("0" & Hex(w.B2), 2) & Right("0" & Hex(w.B3), 2)
	End Function
	
	Private Function HexToWord(ByRef h As String) As Word
		HexToWord = DoubleToWord(Val("&H" & h & "#"))
	End Function
	
	Private Function DoubleToWord(ByRef N As Double) As Word
		DoubleToWord.B0 = Int(DMod(N, 2 ^ 32) / (2 ^ 24))
		DoubleToWord.B1 = Int(DMod(N, 2 ^ 24) / (2 ^ 16))
		DoubleToWord.B2 = Int(DMod(N, 2 ^ 16) / (2 ^ 8))
		DoubleToWord.B3 = Int(DMod(N, 2 ^ 8))
	End Function
	
	Private Function WordToDouble(ByRef w As Word) As Double
		WordToDouble = (w.B0 * (2 ^ 24)) + (w.B1 * (2 ^ 16)) + (w.B2 * (2 ^ 8)) + w.B3
	End Function
	
	Private Function DMod(ByRef value As Double, ByRef divisor As Double) As Double
		DMod = value - (Int(value / divisor) * divisor)
		If DMod < 0 Then DMod = DMod + divisor
	End Function
	
	Private Function F(ByRef t As Integer, ByRef B As Word, ByRef C As Word, ByRef D As Word) As Word
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
	
	Public Function sha1(ByRef inMessage As String) As String
		
		Dim i, inLen, numBlocks, t As Integer
		Dim D, B, H4, H2, H0, inLenW, temp, H1, H3, A, C, E As Word
		Dim blockText, padMessage, wordText As String
		Dim w(79) As Word
		Dim k(3) As Word
		
		inLen = Len(inMessage)
		'UPGRADE_WARNING: Couldn't resolve default property of object inLenW. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		inLenW = DoubleToWord(CDbl(inLen) * 8)
		
		padMessage = inMessage & Chr(128) & New String(Chr(0), (128 - (inLen Mod 64) - 9) Mod 64) & New String(Chr(0), 4) & Chr(inLenW.B0) & Chr(inLenW.B1) & Chr(inLenW.B2) & Chr(inLenW.B3)
		
		numBlocks = Len(padMessage) / 64
		
		' initialize constants
		'UPGRADE_WARNING: Couldn't resolve default property of object k(0). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		k(0) = HexToWord("5A827999")
		'UPGRADE_WARNING: Couldn't resolve default property of object k(1). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		k(1) = HexToWord("6ED9EBA1")
		'UPGRADE_WARNING: Couldn't resolve default property of object k(2). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		k(2) = HexToWord("8F1BBCDC")
		'UPGRADE_WARNING: Couldn't resolve default property of object k(3). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		k(3) = HexToWord("CA62C1D6")
		
		'initialize 160-bit (5 words) buffer
		'UPGRADE_WARNING: Couldn't resolve default property of object H0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		H0 = HexToWord("67452301")
		'UPGRADE_WARNING: Couldn't resolve default property of object H1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		H1 = HexToWord("EFCDAB89")
		'UPGRADE_WARNING: Couldn't resolve default property of object H2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		H2 = HexToWord("98BADCFE")
		'UPGRADE_WARNING: Couldn't resolve default property of object H3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		H3 = HexToWord("10325476")
		'UPGRADE_WARNING: Couldn't resolve default property of object H4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		H4 = HexToWord("C3D2E1F0")
		
		'each 512 byte message block consists of 16 words (W) but W is expanded to 80 words
		For i = 0 To numBlocks - 1
			blockText = Mid(padMessage, (i * 64) + 1, 64)
			'initialize a message block
			For t = 0 To 15
				wordText = Mid(blockText, (t * 4) + 1, 4)
				w(t).B0 = Asc(Mid(wordText, 1, 1))
				w(t).B1 = Asc(Mid(wordText, 2, 1))
				w(t).B2 = Asc(Mid(wordText, 3, 1))
				w(t).B3 = Asc(Mid(wordText, 4, 1))
			Next 
			
			'create extra words from the message block
			For t = 16 To 79
				'W(t) = S^1 (W(t-3) XOR W(t-8) XOR W(t-14) XOR W(t-16))
				'UPGRADE_WARNING: Couldn't resolve default property of object w(t). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				w(t) = CircShiftLeftW(XorW(XorW(XorW(w(t - 3), w(t - 8)), w(t - 14)), w(t - 16)), 1)
			Next 
			
			'make initial assignments to the buffer
			'UPGRADE_WARNING: Couldn't resolve default property of object A. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			A = H0
			'UPGRADE_WARNING: Couldn't resolve default property of object B. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			B = H1
			'UPGRADE_WARNING: Couldn't resolve default property of object C. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			C = H2
			'UPGRADE_WARNING: Couldn't resolve default property of object D. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			D = H3
			'UPGRADE_WARNING: Couldn't resolve default property of object E. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			E = H4
			
			'process the block
			For t = 0 To 79
				'UPGRADE_WARNING: Couldn't resolve default property of object temp. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				temp = AddW(AddW(AddW(AddW(CircShiftLeftW(A, 5), F(t, B, C, D)), E), w(t)), k(t \ 20))
				'UPGRADE_WARNING: Couldn't resolve default property of object E. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				E = D
				'UPGRADE_WARNING: Couldn't resolve default property of object D. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				D = C
				'UPGRADE_WARNING: Couldn't resolve default property of object C. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				C = CircShiftLeftW(B, 30)
				'UPGRADE_WARNING: Couldn't resolve default property of object B. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				B = A
				'UPGRADE_WARNING: Couldn't resolve default property of object A. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				A = temp
			Next 
			
			'UPGRADE_WARNING: Couldn't resolve default property of object H0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			H0 = AddW(H0, A)
			'UPGRADE_WARNING: Couldn't resolve default property of object H1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			H1 = AddW(H1, B)
			'UPGRADE_WARNING: Couldn't resolve default property of object H2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			H2 = AddW(H2, C)
			'UPGRADE_WARNING: Couldn't resolve default property of object H3. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			H3 = AddW(H3, D)
			'UPGRADE_WARNING: Couldn't resolve default property of object H4. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			H4 = AddW(H4, E)
		Next 
		
		sha1 = WordToHex(H0) & WordToHex(H1) & WordToHex(H2) & WordToHex(H3) & WordToHex(H4)
		
	End Function
	
	
	
	Public Function GenerateX(ByRef user As String, ByRef Pass As String, ByRef Salt As Object) As String
		Dim TempHash As String
		Dim temp As String
		Dim x As String
		'Dim Salt As String
		Dim i As Short
		
		temp = ""
		'Salt = "33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f"
		For i = 1 To Len(Salt) Step 2
			'UPGRADE_WARNING: Couldn't resolve default property of object Salt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			temp = temp & Chr(Val("&H" & Mid(Salt, i, 2)))
		Next i
		'UPGRADE_WARNING: Couldn't resolve default property of object Salt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Salt = temp
		temp = UCase(user) & ":" & UCase(Pass)
		
		TempHash = sha1(UCase(temp))
		temp = ""
		For i = 1 To Len(TempHash) Step 2
			temp = temp & Chr(Val("&H" & Mid(TempHash, i, 2)))
		Next i
		TempHash = temp
		'UPGRADE_WARNING: Couldn't resolve default property of object Salt. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		x = sha1(Salt & TempHash)
		GenerateX = x
	End Function
End Module