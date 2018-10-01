Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\strokes.c (75, 1)
' pixFindStrokeLength()
' pixFindStrokeLength(PIX *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) Returns half the number of fg boundary pixels.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="tab8">[in][optional] - table for counting fg pixels; can be NULL</param>
'''  <param name="plength">[out] - estimated length of the strokes</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindStrokeLength(
				ByVal pixs as Pix, 
				ByVal tab8 as Integer(), 
				ByRef plength as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindStrokeLength( pixs.Pointer, tab8, plength)

	Return _Result
End Function

' SRC\strokes.c (123, 1)
' pixFindStrokeWidth()
' pixFindStrokeWidth(PIX *, l_float32, l_int32 *, l_float32 *, NUMA **) as l_ok
'''  <summary>
''' Notes
''' (1) This uses two methods to estimate the stroke width
''' (a) half the fg boundary length
''' (b) a value derived from the histogram of the fg distance transform
''' (2) Distance is measured in 8-connected
''' (3) %thresh is the minimum fraction N(dist=d)/N(dist=1) of pixels
''' required to determine if the pixels at distance d are above
''' the noise. It is typically about 0.15.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="thresh">[in] - fractional count threshold relative to distance 1</param>
'''  <param name="tab8">[in][optional] - table for counting fg pixels; can be NULL</param>
'''  <param name="pwidth">[out] - estimated width of the strokes</param>
'''  <param name="pnahisto">[out][optional] - histo of pixel distances from bg</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindStrokeWidth(
				ByVal pixs as Pix, 
				ByVal thresh as Single, 
				ByVal tab8 as Integer(), 
				ByRef pwidth as Single(), 
				ByRef pnahisto as Numa) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (thresh) then Throw New ArgumentNullException  ("thresh cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

Dim pnahistoPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnahisto) Then pnahistoPTR = pnahisto.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindStrokeWidth( pixs.Pointer, thresh, tab8, pwidth, pnahistoPTR)
	if pnahistoPTR <> IntPtr.Zero then pnahisto = new Numa(pnahistoPTR)

	Return _Result
End Function

' SRC\strokes.c (208, 1)
' pixaFindStrokeWidth()
' pixaFindStrokeWidth(PIXA *, l_float32, l_int32 *, l_int32) as NUMA *
'''  <summary>
''' Notes
''' (1) See pixFindStrokeWidth() for details.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp images</param>
'''  <param name="thresh">[in] - fractional count threshold relative to distance 1</param>
'''  <param name="tab8">[in][optional] - table for counting fg pixels; can be NULL</param>
'''  <param name="debug">[in] - 1 for debug output; 0 to skip</param>
'''   <returns>na  array of stroke widths for each pix in %pixa; NULL on error</returns>
Public Shared Function pixaFindStrokeWidth(
				ByVal pixa as Pixa, 
				ByVal thresh as Single, 
				ByVal tab8 as Integer(), 
				ByVal debug as Enumerations.DebugOnOff) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")
	If IsNothing (thresh) then Throw New ArgumentNullException  ("thresh cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindStrokeWidth( pixa.Pointer, thresh, tab8, debug)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\strokes.c (254, 1)
' pixaModifyStrokeWidth()
' pixaModifyStrokeWidth(PIXA *, l_float32) as PIXA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - of 1 bpp pix</param>
'''  <param name="targetw">[out] - desired width for strokes in each pix</param>
'''   <returns>pixa  with modified stroke widths, or NULL on error</returns>
Public Shared Function pixaModifyStrokeWidth(
				ByVal pixas as Pixa, 
				ByRef targetw as Single) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaModifyStrokeWidth( pixas.Pointer, targetw)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\strokes.c (298, 1)
' pixModifyStrokeWidth()
' pixModifyStrokeWidth(PIX *, l_float32, l_float32) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - of 1 bpp pix</param>
'''  <param name="width">[in] - measured average stroke width</param>
'''  <param name="targetw">[in] - desired stroke width</param>
'''   <returns>pix  with modified stroke width, or NULL on error</returns>
Public Shared Function pixModifyStrokeWidth(
				ByVal pixs as Pix, 
				ByVal width as Single, 
				ByVal targetw as Single) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (width) then Throw New ArgumentNullException  ("width cannot be Nothing")
	If IsNothing (targetw) then Throw New ArgumentNullException  ("targetw cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixModifyStrokeWidth( pixs.Pointer, width, targetw)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\strokes.c (345, 1)
' pixaSetStrokeWidth()
' pixaSetStrokeWidth(PIXA *, l_int32, l_int32, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) If %thinfirst == 1, thin to a skeleton using the specified
''' %connectivity.  Use %thinfirst == 0 if all pix in pixas
''' have already been thinned as far as possible.
''' (2) The image is dilated to the required %width.  This dilation
''' is not connectivity preserving, so this is typically
''' used in a situation where merging of c.c. in the individual
''' pix is not a problem; e.g., where each pix is a single c.c.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - of 1 bpp pix</param>
'''  <param name="width">[in] - set stroke width to this value, in [1 ... 100].</param>
'''  <param name="thinfirst">[in] - 1 to thin all pix to a skeleton first; 0 to skip</param>
'''  <param name="connectivity">[in] - 4 or 8, to be used if %thinfirst == 1</param>
'''   <returns>pixa  with all stroke widths being %width, or NULL on error</returns>
Public Shared Function pixaSetStrokeWidth(
				ByVal pixas as Pixa, 
				ByVal width as Integer, 
				ByVal thinfirst as Integer, 
				ByVal connectivity as Integer) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaSetStrokeWidth( pixas.Pointer, width, thinfirst, connectivity)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\strokes.c (397, 1)
' pixSetStrokeWidth()
' pixSetStrokeWidth(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) See notes in pixaSetStrokeWidth().
''' (2) A white border of sufficient width to avoid boundary
''' artifacts in the thickening step is added before thinning.
''' (3) %connectivity == 8 usually gives a slightly smoother result.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp pix</param>
'''  <param name="width">[in] - set stroke width to this value, in [1 ... 100].</param>
'''  <param name="thinfirst">[in] - 1 to thin all pix to a skeleton first; 0 to skip</param>
'''  <param name="connectivity">[in] - 4 or 8, to be used if %thinfirst == 1</param>
'''   <returns>pixd  with stroke width set to %width, or NULL on error</returns>
Public Shared Function pixSetStrokeWidth(
				ByVal pixs as Pix, 
				ByVal width as Integer, 
				ByVal thinfirst as Integer, 
				ByVal connectivity as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixSetStrokeWidth( pixs.Pointer, width, thinfirst, connectivity)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

End Class