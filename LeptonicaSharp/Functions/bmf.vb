Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\bmf.c (114, 1)
' bmfCreate()
' bmfCreate(const char *, l_int32) as L_BMF *
'''  <summary>
''' Notes
''' (1) If %dir == null, this generates the font bitmaps from a
''' compiled string.
''' (2) Otherwise, this tries to read a pre-computed pixa file with the
''' 95 ascii chars in it.  If the file is not found, it then
''' attempts to generate the pixa and associated baseline
''' data from a tiff image containing all the characters.  If
''' that fails, it uses the compiled string.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="dir">[in][optional] - directory holding pixa of character set</param>
'''  <param name="fontsize">[in] - 4, 6, 8, ... , 20</param>
'''   <returns>bmf holding the bitmap font and associated information</returns>
Public Shared Function bmfCreate(
				ByVal fontsize as Integer, 
				Optional ByVal dir as String = Nothing) as L_Bmf



	Dim _Result as IntPtr = LeptonicaSharp.Natives.bmfCreate( dir, fontsize)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Bmf(_Result)
End Function

' SRC\bmf.c (166, 1)
' bmfDestroy()
' bmfDestroy(L_BMF **) as void
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pbmf">[in,out] - set to null</param>
Public Shared Sub bmfDestroy(
				ByRef pbmf as L_Bmf)


	Dim pbmfPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pbmf) Then pbmfPTR = pbmf.Pointer

	LeptonicaSharp.Natives.bmfDestroy( pbmfPTR)
	if pbmfPTR <> IntPtr.Zero then pbmf = new L_Bmf(pbmfPTR)

End Sub

' SRC\bmf.c (202, 1)
' bmfGetPix()
' bmfGetPix(L_BMF *, char) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="bmf">[in] - </param>
'''  <param name="chr">[in] - should be one of the 95 supported printable bitmaps</param>
'''   <returns>pix clone of pix in bmf, or NULL on error</returns>
Public Shared Function bmfGetPix(
				ByVal bmf as L_Bmf, 
				ByVal chr as Char) as Pix

	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (chr) then Throw New ArgumentNullException  ("chr cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.bmfGetPix( bmf.Pointer, chr)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\bmf.c (237, 1)
' bmfGetWidth()
' bmfGetWidth(L_BMF *, char, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="bmf">[in] - </param>
'''  <param name="chr">[in] - should be one of the 95 supported bitmaps</param>
'''  <param name="pw">[out] - character width; -1 if not printable</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function bmfGetWidth(
				ByVal bmf as L_Bmf, 
				ByVal chr as Char, 
				ByRef pw as Integer) as Integer

	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (chr) then Throw New ArgumentNullException  ("chr cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.bmfGetWidth( bmf.Pointer, chr, pw)

	Return _Result
End Function

' SRC\bmf.c (276, 1)
' bmfGetBaseline()
' bmfGetBaseline(L_BMF *, char, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="bmf">[in] - </param>
'''  <param name="chr">[in] - should be one of the 95 supported bitmaps</param>
'''  <param name="pbaseline">[out] - distance below UL corner of bitmap char</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function bmfGetBaseline(
				ByVal bmf as L_Bmf, 
				ByVal chr as Char, 
				ByRef pbaseline as Integer) as Integer

	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (chr) then Throw New ArgumentNullException  ("chr cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.bmfGetBaseline( bmf.Pointer, chr, pbaseline)

	Return _Result
End Function

' SRC\bmf.c (322, 1)
' pixaGetFont()
' pixaGetFont(const char *, l_int32, l_int32 *, l_int32 *, l_int32 *) as PIXA *
'''  <summary>
''' Notes
''' (1) This reads a pre-computed pixa file with the 95 ascii chars.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="dir">[in] - directory holding pixa of character set</param>
'''  <param name="fontsize">[in] - 4, 6, 8, ... , 20</param>
'''  <param name="pbl0">[out] - baseline of row 1</param>
'''  <param name="pbl1">[out] - baseline of row 2</param>
'''  <param name="pbl2">[out] - baseline of row 3</param>
'''   <returns>pixa of font bitmaps for 95 characters, or NULL on error</returns>
Public Shared Function pixaGetFont(
				ByVal dir as String, 
				ByVal fontsize as Integer, 
				ByRef pbl0 as Integer, 
				ByRef pbl1 as Integer, 
				ByRef pbl2 as Integer) as Pixa

	If IsNothing (dir) then Throw New ArgumentNullException  ("dir cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaGetFont( dir, fontsize, pbl0, pbl1, pbl2)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\bmf.c (372, 1)
' pixaSaveFont()
' pixaSaveFont(const char *, const char *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This saves a font of a particular size.
''' (2) If %dir == null, this generates the font bitmaps from a
''' compiled string.
''' (3) prog/genfonts calls this function for each of the
''' nine font sizes, to generate all the font pixa files.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="indir">[in][optional] - directory holding image of character set</param>
'''  <param name="outdir">[in] - directory into which the output pixa file will be written</param>
'''  <param name="fontsize">[in] - in pts, at 300 ppi</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixaSaveFont(
				ByVal outdir as String, 
				ByVal fontsize as Integer, 
				Optional ByVal indir as String = Nothing) as Integer

	If IsNothing (outdir) then Throw New ArgumentNullException  ("outdir cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixaSaveFont( indir, outdir, fontsize)

	Return _Result
End Function

End Class
