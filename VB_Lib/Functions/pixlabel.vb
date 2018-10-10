Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _All


' SRC\pixlabel.c (114, 1)
' pixConnCompTransform(pixs, connect, depth) as Pix
' pixConnCompTransform(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) pixd is 8, 16 or 32 bpp, and the pixel values label the<para/>
''' fg component, starting with 1.  Pixels in the bg are labelled 0.<para/>
''' (2) If %depth = 0, the depth of pixd is 8 if the number of c.c.<para/>
''' is less than 254, 16 if the number of c.c is less than 0xfffe,<para/>
''' and 32 otherwise.<para/>
''' (3) If %depth = 8, the assigned label for the n-th component is<para/>
''' 1 + n % 254.  We use mod 254 because 0 is uniquely assigned<para/>
''' to black: e.g., see pixcmapCreateRandom().  Likewise,<para/>
''' if %depth = 16, the assigned label uses mod(2^16 - 2), and<para/>
''' if %depth = 32, no mod is taken.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="connect">[in] - connectivity: 4 or 8</param>
'''  <param name="depth">[in] - of pixd: 8 or 16 bpp use 0 for auto determination</param>
'''   <returns>pixd 8, 16 or 32 bpp, or NULL on error</returns>
Public Shared Function pixConnCompTransform(
				 ByVal pixs as Pix, 
				 ByVal connect as Integer, 
				 ByVal depth as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixConnCompTransform( pixs.Pointer, connect, depth)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pixlabel.c (194, 1)
' pixConnCompAreaTransform(pixs, connect) as Pix
' pixConnCompAreaTransform(PIX *, l_int32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The pixel values in pixd label the area of the fg component<para/>
''' to which the pixel belongs.  Pixels in the bg are labelled 0.<para/>
''' (2) For purposes of visualization, the output can be converted<para/>
''' to 8 bpp, using pixConvert32To8() or pixMaxDynamicRange().<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="connect">[in] - connectivity: 4 or 8</param>
'''   <returns>pixd 32 bpp, 1 spp, or NULL on error</returns>
Public Shared Function pixConnCompAreaTransform(
				 ByVal pixs as Pix, 
				 ByVal connect as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixConnCompAreaTransform( pixs.Pointer, connect)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pixlabel.c (267, 1)
' pixConnCompIncrInit(pixs, conn, ppixd, pptaa, pncc) as Integer
' pixConnCompIncrInit(PIX *, l_int32, PIX **, PTAA **, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This labels the connected components in a 1 bpp pix, and<para/>
''' additionally sets up a ptaa that lists the locations of pixels<para/>
''' in each of the components.<para/>
''' (2) It can be used to initialize the output image and arrays for<para/>
''' an application that maintains information about connected<para/>
''' components incrementally as pixels are added.<para/>
''' (3) pixs can be empty or have some foreground pixels.<para/>
''' (4) The connectivity is stored in pixd- is greater special.<para/>
''' (5) Always initialize with the first pta in ptaa being empty<para/>
''' and representing the background value (index 0) in the pix.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="conn">[in] - connectivity: 4 or 8</param>
'''  <param name="ppixd">[out] - 32 bpp, with c.c. labelled</param>
'''  <param name="pptaa">[out] - with pixel locations indexed by c.c.</param>
'''  <param name="pncc">[out] - initial number of c.c.</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixConnCompIncrInit(
				 ByVal pixs as Pix, 
				 ByVal conn as Integer, 
				<Out()> ByRef ppixd as Pix, 
				<Out()> ByRef pptaa as Ptaa, 
				<Out()> ByRef pncc as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim ppixdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixd) Then ppixdPTR = ppixd.Pointer
	Dim pptaaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pptaa) Then pptaaPTR = pptaa.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixConnCompIncrInit( pixs.Pointer, conn, ppixdPTR, pptaaPTR, pncc)
	if ppixdPTR <> IntPtr.Zero then ppixd = new Pix(ppixdPTR)
	if pptaaPTR <> IntPtr.Zero then pptaa = new Ptaa(pptaaPTR)

	Return _Result
End Function

' SRC\pixlabel.c (351, 1)
' pixConnCompIncrAdd(pixs, ptaa, pncc, x, y, debug) as Integer
' pixConnCompIncrAdd(PIX *, PTAA *, l_int32 *, l_float32, l_float32, l_int32) as l_int32
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This adds a pixel and updates the labeled connected components.<para/>
''' Before calling this function, initialize the process using<para/>
''' pixConnCompIncrInit().<para/>
''' (2) As a result of adding a pixel, one of the following can happen,<para/>
''' depending on the number of neighbors with non-zero value:<para/>
''' (a) nothing: the pixel is already a member of a c.c.<para/>
''' (b) no neighbors: a new component is added, increasing the<para/>
''' number of c.c.<para/>
''' (c) one neighbor: the pixel is added to an existing c.c.<para/>
''' (d) more than one neighbor: the added pixel causes joining of<para/>
''' two or more c.c., reducing the number of c.c.  A maximum<para/>
''' of 4 c.c. can be joined.<para/>
''' (3) When two c.c. are joined, the pixels in the larger index are<para/>
''' relabeled to those of the smaller in pixs, and their locations<para/>
''' are transferred to the pta with the smaller index in the ptaa.<para/>
''' The pta corresponding to the larger index is then deleted.<para/>
''' (4) This is an efficient implementation of a "union-find" operation,<para/>
''' which supports the generation and merging of disjoint sets<para/>
''' of pixels.  This function can be called about 1.3 million times<para/>
''' per second.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 32 bpp, with pixels labeled by c.c.</param>
'''  <param name="ptaa">[in] - with each pta of pixel locations indexed by c.c.</param>
'''  <param name="pncc">[out] - number of c.c</param>
'''  <param name="x">[in] - ,y location of added pixel</param>
'''  <param name="debug">[in] - 0 for no output otherwise output whenever debug  is lower = nvals, up to debug == 3</param>
'''   <returns>-1 if nothing happens 0 if a pixel is added 1 on error</returns>
Public Shared Function pixConnCompIncrAdd(
				 ByVal pixs as Pix, 
				 ByVal ptaa as Ptaa, 
				<Out()> ByRef pncc as Integer, 
				 ByVal x as Single, 
				 ByVal y as Single, 
				 Optional ByVal debug as DebugOnOff = DebugOnOff.DebugOn) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (ptaa) then Throw New ArgumentNullException  ("ptaa cannot be Nothing")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixConnCompIncrAdd( pixs.Pointer, ptaa.Pointer, pncc, x, y, debug)

	Return _Result
End Function

' SRC\pixlabel.c (481, 1)
' pixGetSortedNeighborValues(pixs, x, y, conn, pneigh, pnvals) as Integer
' pixGetSortedNeighborValues(PIX *, l_int32, l_int32, l_int32, l_int32 **, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The returned %neigh array is the unique set of neighboring<para/>
''' pixel values, of size nvals, sorted from smallest to largest.<para/>
''' The value 0, which represents background pixels that do<para/>
''' not belong to any set of connected components, is discarded.<para/>
''' (2) If there are no neighbors, this returns %neigh = NULL otherwise,<para/>
''' the caller must free the array.<para/>
''' (3) For either 4 or 8 connectivity, the maximum number of unique<para/>
''' neighbor values is 4.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8, 16 or 32 bpp, with pixels labeled by c.c.</param>
'''  <param name="x">[in] - location of pixel</param>
'''  <param name="y">[in] - location of pixel</param>
'''  <param name="conn">[in] - 4 or 8 connected neighbors</param>
'''  <param name="pneigh">[out] - array of integers, to be filled with the values of the neighbors, if any</param>
'''  <param name="pnvals">[out] - the number of unique neighbor values found</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixGetSortedNeighborValues(
				 ByVal pixs as Pix, 
				 ByVal x as Integer, 
				 ByVal y as Integer, 
				 ByVal conn as Integer, 
				<Out()> ByRef pneigh as List (of Integer()), 
				<Out()> ByRef pnvals as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

Dim pneighPTR As IntPtr = Marshal.AllocHGlobal(0)

	Dim _Result as Integer = LeptonicaSharp.Natives.pixGetSortedNeighborValues( pixs.Pointer, x, y, conn, pneighPTR, pnvals)

	Return _Result
End Function

' SRC\pixlabel.c (567, 1)
' pixLocToColorTransform(pixs) as Pix
' pixLocToColorTransform(PIX *) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This generates an RGB image where each component value<para/>
''' is coded depending on the (x.y) location and the size<para/>
''' of the fg connected component that the pixel in pixs belongs to.<para/>
''' It is independent of the 4-fold orthogonal orientation, and<para/>
''' only weakly depends on translations and small angle rotations.<para/>
''' Background pixels are black.<para/>
''' (2) Such encodings can be compared between two 1 bpp images<para/>
''' by performing this transform and calculating the<para/>
''' "earth-mover" distance on the resulting R,G,B histograms.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''   <returns>pixd 32 bpp rgb, or NULL on error</returns>
Public Shared Function pixLocToColorTransform(
				 ByVal pixs as Pix) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixLocToColorTransform( pixs.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

End Class
