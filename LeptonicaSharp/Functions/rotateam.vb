Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\rotateam.c (149, 1)
' pixRotateAM()
' pixRotateAM(PIX *, l_float32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Rotates about image center.
''' (2) A positive angle gives a clockwise rotation.
''' (3) Brings in either black or white pixels from the boundary.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 2, 4, 8 bpp gray or colormapped, or 32 bpp RGB</param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="incolor">[in] - L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAM(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal incolor as Enumerations.L_BRING_IN) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAM( pixs.Pointer, angle, incolor)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\rotateam.c (212, 1)
' pixRotateAMColor()
' pixRotateAMColor(PIX *, l_float32, l_uint32) as PIX *
'''  <summary>
''' Notes
''' (1) Rotates about image center.
''' (2) A positive angle gives a clockwise rotation.
''' (3) Specify the color to be brought in from outside the image.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 32 bpp</param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="colorval">[in] - e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAMColor(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal colorval as UInteger) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")
	If IsNothing (colorval) then Throw New ArgumentNullException  ("colorval cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAMColor( pixs.Pointer, angle, colorval)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\rotateam.c (266, 1)
' pixRotateAMGray()
' pixRotateAMGray(PIX *, l_float32, l_uint8) as PIX *
'''  <summary>
''' Notes
''' (1) Rotates about image center.
''' (2) A positive angle gives a clockwise rotation.
''' (3) Specify the grayvalue to be brought in from outside the image.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="grayval">[in] - 0 to bring in BLACK, 255 for WHITE</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAMGray(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal grayval as Byte) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")
	If IsNothing (grayval) then Throw New ArgumentNullException  ("grayval cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp") ' All Functions - All Parameters - CommentCheck


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAMGray( pixs.Pointer, angle, grayval)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\rotateam.c (447, 1)
' pixRotateAMCorner()
' pixRotateAMCorner(PIX *, l_float32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Rotates about the UL corner of the image.
''' (2) A positive angle gives a clockwise rotation.
''' (3) Brings in either black or white pixels from the boundary.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1, 2, 4, 8 bpp gray or colormapped, or 32 bpp RGB</param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="incolor">[in] - L_BRING_IN_WHITE, L_BRING_IN_BLACK</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAMCorner(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal incolor as Enumerations.L_BRING_IN) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAMCorner( pixs.Pointer, angle, incolor)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\rotateam.c (508, 1)
' pixRotateAMColorCorner()
' pixRotateAMColorCorner(PIX *, l_float32, l_uint32) as PIX *
'''  <summary>
''' Notes
''' (1) Rotates the image about the UL corner.
''' (2) A positive angle gives a clockwise rotation.
''' (3) Specify the color to be brought in from outside the image.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="fillval">[in] - e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAMColorCorner(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal fillval as UInteger) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")
	If IsNothing (fillval) then Throw New ArgumentNullException  ("fillval cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAMColorCorner( pixs.Pointer, angle, fillval)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\rotateam.c (562, 1)
' pixRotateAMGrayCorner()
' pixRotateAMGrayCorner(PIX *, l_float32, l_uint8) as PIX *
'''  <summary>
''' Notes
''' (1) Rotates the image about the UL corner.
''' (2) A positive angle gives a clockwise rotation.
''' (3) Specify the grayvalue to be brought in from outside the image.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="grayval">[in] - 0 to bring in BLACK, 255 for WHITE</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAMGrayCorner(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal grayval as Byte) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")
	If IsNothing (grayval) then Throw New ArgumentNullException  ("grayval cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAMGrayCorner( pixs.Pointer, angle, grayval)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\rotateam.c (741, 1)
' pixRotateAMColorFast()
' pixRotateAMColorFast(PIX *, l_float32, l_uint32) as PIX *
'''  <summary>
''' Notes
''' (1) This rotates a color image about the image center.
''' (2) A positive angle gives a clockwise rotation.
''' (3) It uses area mapping, dividing each pixel into
''' 16 subpixels.
''' (4) It is about 10% to 20% faster than the more accurate linear
''' interpolation function pixRotateAMColor(),
''' which uses 256 subpixels.
''' (5) For some reason it shifts the image center.
''' No attempt is made to rotate the alpha component.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="angle">[in] - radians; clockwise is positive</param>
'''  <param name="colorval">[in] - e.g., 0 to bring in BLACK, 0xffffff00 for WHITE</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixRotateAMColorFast(
				ByVal pixs as Pix, 
				ByVal angle as Single, 
				ByVal colorval as UInteger) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (angle) then Throw New ArgumentNullException  ("angle cannot be Nothing")
	If IsNothing (colorval) then Throw New ArgumentNullException  ("colorval cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRotateAMColorFast( pixs.Pointer, angle, colorval)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

End Class
