Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\pixcomp.c (185, 1)
' pixcompCreateFromPix()
' pixcompCreateFromPix(PIX *, l_int32) as PIXC *
'''  <summary>
''' Notes
''' (1) Use %comptype == IFF_DEFAULT to have the compression
''' type automatically determined.
''' (2) To compress jpeg with a quality other than the default (75), use
''' l_jpegSetQuality()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pix">[in] - </param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>pixc, or NULL on error</returns>
Public Shared Function pixcompCreateFromPix(
				ByVal pix as Pix, 
				ByVal comptype as Enumerations.IFF) as PixComp

	If IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixcompCreateFromPix( pix.Pointer, comptype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixComp(_Result)
End Function

' SRC\pixcomp.c (242, 1)
' pixcompCreateFromString()
' pixcompCreateFromString(l_uint8 *, size_t, l_int32) as PIXC *
'''  <summary>
''' Notes
''' (1) This works when the compressed string is png, jpeg or tiffg4.
''' (2) The copyflag determines if the data in the new Pixcomp is
''' a copy of the input data.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="data">[in] - compressed string</param>
'''  <param name="size">[in] - number of bytes</param>
'''  <param name="copyflag">[in] - L_INSERT or L_COPY</param>
'''   <returns>pixc, or NULL on error</returns>
Public Shared Function pixcompCreateFromString(
				ByVal data as Byte(), 
				ByVal size as UInteger, 
				ByVal copyflag as Enumerations.L_access_storage) as PixComp

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")
	If IsNothing (size) then Throw New ArgumentNullException  ("size cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixcompCreateFromString( data, size, copyflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixComp(_Result)
End Function

' SRC\pixcomp.c (291, 1)
' pixcompCreateFromFile()
' pixcompCreateFromFile(const char *, l_int32) as PIXC *
'''  <summary>
''' Notes
''' (1) Use %comptype == IFF_DEFAULT to have the compression
''' type automatically determined.
''' (2) If the comptype is invalid for this file, the default will
''' be substituted.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>pixc, or NULL on error</returns>
Public Shared Function pixcompCreateFromFile(
				ByVal filename as String, 
				ByVal comptype as Enumerations.IFF) as PixComp

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixcompCreateFromFile( filename, comptype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixComp(_Result)
End Function

' SRC\pixcomp.c (354, 1)
' pixcompDestroy()
' pixcompDestroy(PIXC **) as void
'''  <summary>
''' Notes
''' (1) Always nulls the input ptr.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="ppixc">[in,out] - will be nulled</param>
Public Shared Sub pixcompDestroy(
				ByRef ppixc as PixComp)


	Dim ppixcPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixc) Then ppixcPTR = ppixc.Pointer

	LeptonicaSharp.Natives.pixcompDestroy( ppixcPTR)
	if ppixcPTR <> IntPtr.Zero then ppixc = new PixComp(ppixcPTR)

End Sub

' SRC\pixcomp.c (384, 1)
' pixcompCopy()
' pixcompCopy(PIXC *) as PIXC *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixcs">[in] - </param>
'''   <returns>pixcd, or NULL on error</returns>
Public Shared Function pixcompCopy(
				ByVal pixcs as PixComp) as PixComp

	If IsNothing (pixcs) then Throw New ArgumentNullException  ("pixcs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixcompCopy( pixcs.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixComp(_Result)
End Function

' SRC\pixcomp.c (429, 1)
' pixcompGetDimensions()
' pixcompGetDimensions(PIXC *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixc">[in] - </param>
'''  <param name="pw">[out][optional] - </param>
'''  <param name="ph">[out][optional] - </param>
'''  <param name="pd">[out][optional] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixcompGetDimensions(
				ByVal pixc as PixComp, 
				Optional ByRef pw as Integer = Nothing, 
				Optional ByRef ph as Integer = Nothing, 
				Optional ByRef pd as Integer = Nothing) as Integer

	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixcompGetDimensions( pixc.Pointer, pw, ph, pd)

	Return _Result
End Function

' SRC\pixcomp.c (453, 1)
' pixcompGetParameters()
' pixcompGetParameters(PIXC *, l_int32 *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixc">[in] - </param>
'''  <param name="pxres">[out][all optional] - </param>
'''  <param name="pyres">[out][all optional] - </param>
'''  <param name="pcomptype">[out][all optional] - </param>
'''  <param name="pcmapflag">[out][all optional] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixcompGetParameters(
				ByVal pixc as PixComp, 
				Optional ByRef pxres as Integer = Nothing, 
				Optional ByRef pyres as Integer = Nothing, 
				Optional ByRef pcomptype as Integer = Nothing, 
				Optional ByRef pcmapflag as Integer = Nothing) as Integer

	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixcompGetParameters( pixc.Pointer, pxres, pyres, pcomptype, pcmapflag)

	Return _Result
End Function

' SRC\pixcomp.c (495, 1)
' pixcompDetermineFormat()
' pixcompDetermineFormat(l_int32, l_int32, l_int32, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) This determines the best format for a pix, given both
''' the request (%comptype) and the image characteristics.
''' (2) If %comptype == IFF_DEFAULT, this does not necessarily result
''' in png encoding.  Instead, it returns one of the three formats
''' that is both valid and most likely to give best compression.
''' (3) If the pix cannot be compressed by the input value of
''' %comptype, this selects IFF_PNG, which can compress all pix.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''  <param name="d">[in] - pix depth</param>
'''  <param name="cmapflag">[in] - 1 if pix to be compressed as a colormap; 0 otherwise</param>
'''  <param name="pformat">[out] - return IFF_TIFF, IFF_PNG or IFF_JFIF_JPEG</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function pixcompDetermineFormat(
				ByVal comptype as Enumerations.IFF, 
				ByVal d as Integer, 
				ByVal cmapflag as Integer, 
				ByRef pformat as Integer) as Integer



	Dim _Result as Integer = LeptonicaSharp.Natives.pixcompDetermineFormat( comptype, d, cmapflag, pformat)

	Return _Result
End Function

' SRC\pixcomp.c (537, 1)
' pixCreateFromPixcomp()
' pixCreateFromPixcomp(PIXC *) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixc">[in] - </param>
'''   <returns>pix, or NULL on error</returns>
Public Shared Function pixCreateFromPixcomp(
				ByVal pixc as PixComp) as Pix

	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixCreateFromPixcomp( pixc.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pixcomp.c (590, 1)
' pixacompCreate()
' pixacompCreate(l_int32) as PIXAC *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="n">[in] - initial number of ptrs</param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompCreate(
				ByVal n as Integer) as PixaComp



	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompCreate( n)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (657, 1)
' pixacompCreateWithInit()
' pixacompCreateWithInit(l_int32, l_int32, PIX *, l_int32) as PIXAC *
'''  <summary>
''' Notes
''' (1) Initializes a pixacomp to be fully populated with %pix,
''' compressed using %comptype.  If %pix == NULL, %comptype
''' is ignored.
''' (2) Typically, the array is initialized with a tiny pix.
''' This is most easily done by setting %pix == NULL, causing
''' initialization of each array element with a tiny placeholder
''' pix (w = h = d = 1), using comptype = IFF_TIFF_G4 .
''' (3) Example usage
''' // Generate pixacomp for pages 30 - 49.  This has an array
''' // size of 20 and the page number offset is 30.
''' PixaComp pixac = pixacompCreateWithInit(20, 30, NULL,
''' IFF_TIFF_G4);
''' // Now insert png-compressed images into the initialized array
''' for (pageno = 30; pageno LT 50; pageno++) {
''' Pix pixt = ...   // derived from image[pageno]
''' if (pixt)
''' pixacompReplacePix(pixac, pageno, pixt, IFF_PNG);
''' pixDestroy(pixt);
''' }
''' The result is a pixac with 20 compressed strings, and with
''' selected pixt replacing the placeholders.
''' To extract the image for page 38, which is decompressed
''' from element 8 in the array, use
''' pixt = pixacompGetPix(pixac, 38);
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="n">[in] - initial number of ptrs</param>
'''  <param name="offset">[in] - difference accessor index - pixacomp array index</param>
'''  <param name="pix">[in][optional] - initialize each ptr in pixacomp to this pix; can be NULL</param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompCreateWithInit(
				ByVal n as Integer, 
				ByVal offset as Integer, 
				ByVal comptype as Enumerations.IFF, 
				Optional ByVal pix as Pix = Nothing) as PixaComp


	Dim pixPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pix) Then pixPTR = pix.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompCreateWithInit( n, offset, pixPTR, comptype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (721, 1)
' pixacompCreateFromPixa()
' pixacompCreateFromPixa(PIXA *, l_int32, l_int32) as PIXAC *
'''  <summary>
''' Notes
''' (1) If %format == IFF_DEFAULT, the conversion format for each
''' image is chosen automatically.  Otherwise, we use the
''' specified format unless it can't be done (e.g., jpeg
''' for a 1, 2 or 4 bpp pix, or a pix with a colormap),
''' in which case we use the default (assumed best) compression.
''' (2) %accesstype is used to extract a boxa from %pixa.
''' (3) To compress jpeg with a quality other than the default (75), use
''' l_jpegSetQuality()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - </param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''  <param name="accesstype">[in] - L_COPY, L_CLONE, L_COPY_CLONE</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompCreateFromPixa(
				ByVal pixa as Pixa, 
				ByVal comptype as Enumerations.IFF, 
				ByVal accesstype as Enumerations.L_access_storage) as PixaComp

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompCreateFromPixa( pixa.Pointer, comptype, accesstype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (780, 1)
' pixacompCreateFromFiles()
' pixacompCreateFromFiles(const char *, const char *, l_int32) as PIXAC *
'''  <summary>
''' Notes
''' (1) %dirname is the full path for the directory.
''' (2) %substr is the part of the file name (excluding
''' the directory) that is to be matched.  All matching
''' filenames are read into the Pixa.  If substr is NULL,
''' all filenames are read into the Pixa.
''' (3) Use %comptype == IFF_DEFAULT to have the compression
''' type automatically determined for each file.
''' (4) If the comptype is invalid for a file, the default will
''' be substituted.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="dirname">[in] - </param>
'''  <param name="substr">[in][optional] - substring filter on filenames; can be null</param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompCreateFromFiles(
				ByVal dirname as String, 
				ByVal comptype as Enumerations.IFF, 
				Optional ByVal substr as String = Nothing) as PixaComp

	If IsNothing (dirname) then Throw New ArgumentNullException  ("dirname cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompCreateFromFiles( dirname, substr, comptype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (819, 1)
' pixacompCreateFromSA()
' pixacompCreateFromSA(SARRAY *, l_int32) as PIXAC *
'''  <summary>
''' Notes
''' (1) Use %comptype == IFF_DEFAULT to have the compression
''' type automatically determined for each file.
''' (2) If the comptype is invalid for a file, the default will
''' be substituted.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa">[in] - full pathnames for all files</param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompCreateFromSA(
				ByVal sa as Sarray, 
				ByVal comptype as Enumerations.IFF) as PixaComp

	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompCreateFromSA( sa.Pointer, comptype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (861, 1)
' pixacompDestroy()
' pixacompDestroy(PIXAC **) as void
'''  <summary>
''' Notes
''' (1) Always nulls the input ptr.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="ppixac">[in,out] - to be nulled</param>
Public Shared Sub pixacompDestroy(
				ByRef ppixac as PixaComp)


	Dim ppixacPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixac) Then ppixacPTR = ppixac.Pointer

	LeptonicaSharp.Natives.pixacompDestroy( ppixacPTR)
	if ppixacPTR <> IntPtr.Zero then ppixac = new PixaComp(ppixacPTR)

End Sub

' SRC\pixcomp.c (908, 1)
' pixacompAddPix()
' pixacompAddPix(PIXAC *, PIX *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) The array is filled up to the (n-1)-th element, and this
''' converts the input pix to a pixc and adds it at
''' the n-th position.
''' (2) The pixc produced from the pix is owned by the pixac.
''' The input pix is not affected.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="pix">[in] - to be added</param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function pixacompAddPix(
				ByVal pixac as PixaComp, 
				ByVal pix as Pix, 
				ByVal comptype as Enumerations.IFF) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompAddPix( pixac.Pointer, pix.Pointer, comptype)

	Return _Result
End Function

' SRC\pixcomp.c (950, 1)
' pixacompAddPixcomp()
' pixacompAddPixcomp(PIXAC *, PIXC *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) Anything added to a pixac is owned by the pixac.
''' So do not L_INSERT a pixc that is owned by another pixac,
''' or destroy a pixc that has been L_INSERTed.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="pixc">[in] - to be added by insertion</param>
'''  <param name="copyflag">[in] - L_INSERT, L_COPY</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function pixacompAddPixcomp(
				ByVal pixac as PixaComp, 
				ByVal pixc as PixComp, 
				ByVal copyflag as Enumerations.L_access_storage) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompAddPixcomp( pixac.Pointer, pixc.Pointer, copyflag)

	Return _Result
End Function

' SRC\pixcomp.c (1028, 1)
' pixacompReplacePix()
' pixacompReplacePix(PIXAC *, l_int32, PIX *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
''' (2) The input %pix is converted to a pixc, which is then inserted
''' into the pixac.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''  <param name="pix">[in] - owned by the caller</param>
'''  <param name="comptype">[in] - IFF_DEFAULT, IFF_TIFF_G4, IFF_PNG, IFF_JFIF_JPEG</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function pixacompReplacePix(
				ByVal pixac as PixaComp, 
				ByVal index as Integer, 
				ByVal pix as Pix, 
				ByVal comptype as Enumerations.IFF) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompReplacePix( pixac.Pointer, index, pix.Pointer, comptype)

	Return _Result
End Function

' SRC\pixcomp.c (1073, 1)
' pixacompReplacePixcomp()
' pixacompReplacePixcomp(PIXAC *, l_int32, PIXC *) as l_ok
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
''' (2) The inserted %pixc is now owned by the pixac.  The caller
''' must not destroy it.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''  <param name="pixc">[in] - to replace existing one, which is destroyed</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function pixacompReplacePixcomp(
				ByVal pixac as PixaComp, 
				ByVal index as Integer, 
				ByVal pixc as PixComp) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompReplacePixcomp( pixac.Pointer, index, pixc.Pointer)

	Return _Result
End Function

' SRC\pixcomp.c (1108, 1)
' pixacompAddBox()
' pixacompAddBox(PIXAC *, BOX *, l_int32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="box">[in] - </param>
'''  <param name="copyflag">[in] - L_INSERT, L_COPY</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompAddBox(
				ByVal pixac as PixaComp, 
				ByVal box as Box, 
				ByVal copyflag as Enumerations.L_access_storage) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompAddBox( pixac.Pointer, box.Pointer, copyflag)

	Return _Result
End Function

' SRC\pixcomp.c (1136, 1)
' pixacompGetCount()
' pixacompGetCount(PIXAC *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''   <returns>count, or 0 if no pixa</returns>
Public Shared Function pixacompGetCount(
				ByVal pixac as PixaComp) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompGetCount( pixac.Pointer)

	Return _Result
End Function

' SRC\pixcomp.c (1164, 1)
' pixacompGetPixcomp()
' pixacompGetPixcomp(PIXAC *, l_int32, l_int32) as PIXC *
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
''' (2) If copyflag == L_NOCOPY, the pixc is owned by %pixac; do
''' not destroy.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''  <param name="copyflag">[in] - L_NOCOPY, L_COPY</param>
'''   <returns>pixc, or NULL on error</returns>
Public Shared Function pixacompGetPixcomp(
				ByVal pixac as PixaComp, 
				ByVal index as Integer, 
				ByVal copyflag as Enumerations.L_access_storage) as PixComp

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompGetPixcomp( pixac.Pointer, index, copyflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixComp(_Result)
End Function

' SRC\pixcomp.c (1201, 1)
' pixacompGetPix()
' pixacompGetPix(PIXAC *, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''   <returns>pix, or NULL on error</returns>
Public Shared Function pixacompGetPix(
				ByVal pixac as PixaComp, 
				ByVal index as Integer) as Pix

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompGetPix( pixac.Pointer, index)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pixcomp.c (1235, 1)
' pixacompGetPixDimensions()
' pixacompGetPixDimensions(PIXAC *, l_int32, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''  <param name="pw">[out][optional] - each can be null</param>
'''  <param name="ph">[out][optional] - each can be null</param>
'''  <param name="pd">[out][optional] - each can be null</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompGetPixDimensions(
				ByVal pixac as PixaComp, 
				ByVal index as Integer, 
				Optional ByRef pw as Integer = Nothing, 
				Optional ByRef ph as Integer = Nothing, 
				Optional ByRef pd as Integer = Nothing) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompGetPixDimensions( pixac.Pointer, index, pw, ph, pd)

	Return _Result
End Function

' SRC\pixcomp.c (1267, 1)
' pixacompGetBoxa()
' pixacompGetBoxa(PIXAC *, l_int32) as BOXA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="accesstype">[in] - L_COPY, L_CLONE, L_COPY_CLONE</param>
'''   <returns>boxa, or NULL on error</returns>
Public Shared Function pixacompGetBoxa(
				ByVal pixac as PixaComp, 
				ByVal accesstype as Enumerations.L_access_storage) as Boxa

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompGetBoxa( pixac.Pointer, accesstype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Boxa(_Result)
End Function

' SRC\pixcomp.c (1291, 1)
' pixacompGetBoxaCount()
' pixacompGetBoxaCount(PIXAC *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''   <returns>count, or 0 on error</returns>
Public Shared Function pixacompGetBoxaCount(
				ByVal pixac as PixaComp) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompGetBoxaCount( pixac.Pointer)

	Return _Result
End Function

' SRC\pixcomp.c (1325, 1)
' pixacompGetBox()
' pixacompGetBox(PIXAC *, l_int32, l_int32) as BOX *
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
''' (2) There is always a boxa with a pixac, and it is initialized so
''' that each box ptr is NULL.
''' (3) In general, we expect that there is either a box associated
''' with each pixc, or no boxes at all in the boxa.
''' (4) Having no boxes is thus not an automatic error.  Whether it
''' is an actual error is determined by the calling program.
''' If the caller expects to get a box, it is an error; see, e.g.,
''' pixacGetBoxGeometry().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''  <param name="accesstype">[in] - L_COPY or L_CLONE</param>
'''   <returns>box if null, not automatically an error, or NULL on error</returns>
Public Shared Function pixacompGetBox(
				ByVal pixac as PixaComp, 
				ByVal index as Integer, 
				ByVal accesstype as Enumerations.L_access_storage) as Box

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompGetBox( pixac.Pointer, index, accesstype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Box(_Result)
End Function

' SRC\pixcomp.c (1371, 1)
' pixacompGetBoxGeometry()
' pixacompGetBoxGeometry(PIXAC *, l_int32, l_int32 *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) The %index includes the offset, which must be subtracted
''' to get the actual index into the ptr array.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="index">[in] - caller's view of index within pixac; includes offset</param>
'''  <param name="px">[out][optional] - each can be null</param>
'''  <param name="py">[out][optional] - each can be null</param>
'''  <param name="pw">[out][optional] - each can be null</param>
'''  <param name="ph">[out][optional] - each can be null</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompGetBoxGeometry(
				ByVal pixac as PixaComp, 
				ByVal index as Integer, 
				Optional ByRef px as Integer = Nothing, 
				Optional ByRef py as Integer = Nothing, 
				Optional ByRef pw as Integer = Nothing, 
				Optional ByRef ph as Integer = Nothing) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompGetBoxGeometry( pixac.Pointer, index, px, py, pw, ph)

	Return _Result
End Function

' SRC\pixcomp.c (1411, 1)
' pixacompGetOffset()
' pixacompGetOffset(PIXAC *) as l_int32
'''  <summary>
''' Notes
''' (1) The offset is the difference between the caller's view of
''' the index into the array and the actual array index.
''' By default it is 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''   <returns>offset, or 0 on error</returns>
Public Shared Function pixacompGetOffset(
				ByVal pixac as PixaComp) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompGetOffset( pixac.Pointer)

	Return _Result
End Function

' SRC\pixcomp.c (1436, 1)
' pixacompSetOffset()
' pixacompSetOffset(PIXAC *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) The offset is the difference between the caller's view of
''' the index into the array and the actual array index.
''' By default it is 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="offset">[in] - non-negative</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompSetOffset(
				ByVal pixac as PixaComp, 
				ByVal offset as Integer) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompSetOffset( pixac.Pointer, offset)

	Return _Result
End Function

' SRC\pixcomp.c (1466, 1)
' pixaCreateFromPixacomp()
' pixaCreateFromPixacomp(PIXAC *, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) Because the pixa has no notion of offset, the offset must
''' be set to 0 before the conversion, so that pixacompGetPix()
''' fetches all the pixcomps.  It is reset at the end.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="accesstype">[in] - L_COPY, L_CLONE, L_COPY_CLONE; for boxa</param>
'''   <returns>pixa if OK, or NULL on error</returns>
Public Shared Function pixaCreateFromPixacomp(
				ByVal pixac as PixaComp, 
				ByVal accesstype as Enumerations.L_access_storage) as Pixa

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaCreateFromPixacomp( pixac.Pointer, accesstype)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\pixcomp.c (1524, 1)
' pixacompJoin()
' pixacompJoin(PIXAC *, PIXAC *, l_int32, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This appends a clone of each indicated pixc in pixcas to pixcad
''' (2) istart LT 0 is taken to mean 'read from the start' (istart = 0)
''' (3) iend LT 0 means 'read to the end'
''' (4) If pixacs is NULL or contains no pixc, this is a no-op.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixacd">[in] - dest pixac; add to this one</param>
'''  <param name="pixacs">[in][optional] - source pixac; add from this one</param>
'''  <param name="istart">[in] - starting index in pixacs</param>
'''  <param name="iend">[in] - ending index in pixacs; use -1 to cat all</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompJoin(
				ByVal pixacd as PixaComp, 
				ByVal istart as Integer, 
				ByVal iend as Integer, 
				Optional ByVal pixacs as PixaComp = Nothing) as Integer

	If IsNothing (pixacd) then Throw New ArgumentNullException  ("pixacd cannot be Nothing")

	Dim pixacsPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixacs) Then pixacsPTR = pixacs.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompJoin( pixacd.Pointer, pixacsPTR, istart, iend)

	Return _Result
End Function

' SRC\pixcomp.c (1577, 1)
' pixacompInterleave()
' pixacompInterleave(PIXAC *, PIXAC *) as PIXAC *
'''  <summary>
''' Notes
''' (1) If the two pixac have different sizes, a warning is issued,
''' and the number of pairs returned is the minimum size.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac1">[in] - first src pixac</param>
'''  <param name="pixac2">[in] - second src pixac</param>
'''   <returns>pixacd  interleaved from sources, or NULL on error.</returns>
Public Shared Function pixacompInterleave(
				ByVal pixac1 as PixaComp, 
				ByVal pixac2 as PixaComp) as PixaComp

	If IsNothing (pixac1) then Throw New ArgumentNullException  ("pixac1 cannot be Nothing")
	If IsNothing (pixac2) then Throw New ArgumentNullException  ("pixac2 cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompInterleave( pixac1.Pointer, pixac2.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (1639, 1)
' pixacompRead()
' pixacompRead(const char *) as PIXAC *
'''  <summary>
''' Notes
''' (1) Unlike the situation with serialized Pixa, where the image
''' data is stored in png format, the Pixacomp image data
''' can be stored in tiffg4, png and jpg formats.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompRead(
				ByVal filename as String) as PixaComp

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompRead( filename)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (1666, 1)
' pixacompReadStream()
' pixacompReadStream(FILE *) as PIXAC *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompReadStream(
				ByVal fp as FILE) as PixaComp

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompReadStream( fp.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (1764, 1)
' pixacompReadMem()
' pixacompReadMem(const l_uint8 *, size_t) as PIXAC *
'''  <summary>
''' Notes
''' (1) Deseralizes a buffer of pixacomp data into a pixac in memory.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="data">[in] - const; pixacomp format</param>
'''  <param name="size">[in] - of data</param>
'''   <returns>pixac, or NULL on error</returns>
Public Shared Function pixacompReadMem(
				ByVal data as Byte(), 
				ByVal size as UInteger) as PixaComp

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")
	If IsNothing (size) then Throw New ArgumentNullException  ("size cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompReadMem( data, size)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new PixaComp(_Result)
End Function

' SRC\pixcomp.c (1799, 1)
' pixacompWrite()
' pixacompWrite(const char *, PIXAC *) as l_ok
'''  <summary>
''' Notes
''' (1) Unlike the situation with serialized Pixa, where the image
''' data is stored in png format, the Pixacomp image data
''' can be stored in tiffg4, png and jpg formats.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''  <param name="pixac">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompWrite(
				ByVal filename as String, 
				ByVal pixac as PixaComp) as Integer

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompWrite( filename, pixac.Pointer)

	Return _Result
End Function

' SRC\pixcomp.c (1830, 1)
' pixacompWriteStream()
' pixacompWriteStream(FILE *, PIXAC *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''  <param name="pixac">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompWriteStream(
				ByVal fp as FILE, 
				ByVal pixac as PixaComp) as Integer

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompWriteStream( fp.Pointer, pixac.Pointer)

	Return _Result
End Function

' SRC\pixcomp.c (1878, 1)
' pixacompWriteMem()
' pixacompWriteMem(l_uint8 **, size_t *, PIXAC *) as l_ok
'''  <summary>
''' Notes
''' (1) Serializes a pixac in memory and puts the result in a buffer.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pdata">[out] - serialized data of pixac</param>
'''  <param name="psize">[out] - size of serialized data</param>
'''  <param name="pixac">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompWriteMem(
				ByRef pdata as Byte(), 
				ByRef psize as UInteger, 
				ByVal pixac as PixaComp) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")

	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompWriteMem( pdataPTR, psize, pixac.Pointer)
ReDim pdata(IIf(psize > 0, psize, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

' SRC\pixcomp.c (1952, 1)
' pixacompConvertToPdf()
' pixacompConvertToPdf(PIXAC *, l_int32, l_float32, l_int32, l_int32, const char *, const char *) as l_ok
'''  <summary>
''' Notes
''' (1) This follows closely the function pixaConvertToPdf() in pdfio.c.
''' (2) The images are encoded with G4 if 1 bpp; JPEG if 8 bpp without
''' colormap and many colors, or 32 bpp; FLATE for anything else.
''' (3) The scalefactor must be GT 0.0; otherwise it is set to 1.0.
''' (4) Specifying one of the three encoding types for %type forces
''' all images to be compressed with that type.  Use 0 to have
''' the type determined for each image based on depth and whether
''' or not it has a colormap.
''' (5) If all images are jpeg compressed, don't require scaling
''' and have the same resolution, it is much faster to skip
''' transcoding with pixacompFastConvertToPdfData(), and then
''' write the data out to file.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - containing images all at the same resolution</param>
'''  <param name="res">[in] - override the resolution of each input image, in ppi; use 0 to respect the resolution embedded in the input</param>
'''  <param name="scalefactor">[in] - scaling factor applied to each image; GT 0.0</param>
'''  <param name="type">[in] - encoding type (L_JPEG_ENCODE, L_G4_ENCODE, L_FLATE_ENCODE, or L_DEFAULT_ENCODE for default</param>
'''  <param name="quality">[in] - used for JPEG only; 0 for default (75)</param>
'''  <param name="title">[in][optional] - pdf title</param>
'''  <param name="fileout">[in] - pdf file of all images</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompConvertToPdf(
				ByVal pixac as PixaComp, 
				ByVal res as Integer, 
				ByVal scalefactor as Single, 
				ByVal type as Enumerations.L_ENCODE, 
				ByVal quality as Integer, 
				ByVal fileout as String, 
				Optional ByVal title as String = Nothing) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (scalefactor) then Throw New ArgumentNullException  ("scalefactor cannot be Nothing")
	If IsNothing (fileout) then Throw New ArgumentNullException  ("fileout cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompConvertToPdf( pixac.Pointer, res, scalefactor, type, quality, title, fileout)

	Return _Result
End Function

' SRC\pixcomp.c (2004, 1)
' pixacompConvertToPdfData()
' pixacompConvertToPdfData(PIXAC *, l_int32, l_float32, l_int32, l_int32, const char *, l_uint8 **, size_t *) as l_ok
'''  <summary>
''' Notes
''' (1) See pixacompConvertToPdf().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - containing images all at the same resolution</param>
'''  <param name="res">[in] - input resolution of all images</param>
'''  <param name="scalefactor">[in] - scaling factor applied to each image; GT 0.0</param>
'''  <param name="type">[in] - encoding type (L_JPEG_ENCODE, L_G4_ENCODE, L_FLATE_ENCODE, or L_DEFAULT_ENCODE for default</param>
'''  <param name="quality">[in] - used for JPEG only; 0 for default (75)</param>
'''  <param name="title">[in][optional] - pdf title</param>
'''  <param name="pdata">[out] - output pdf data (of all images</param>
'''  <param name="pnbytes">[out] - size of output pdf data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompConvertToPdfData(
				ByVal pixac as PixaComp, 
				ByVal res as Integer, 
				ByVal scalefactor as Single, 
				ByVal type as Enumerations.L_ENCODE, 
				ByVal quality as Integer, 
				ByRef pdata as Byte(), 
				ByRef pnbytes as UInteger, 
				Optional ByVal title as String = Nothing) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (scalefactor) then Throw New ArgumentNullException  ("scalefactor cannot be Nothing")

	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompConvertToPdfData( pixac.Pointer, res, scalefactor, type, quality, title, pdataPTR, pnbytes)
ReDim pdata(IIf(pnbytes > 0, pnbytes, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

' SRC\pixcomp.c (2115, 1)
' pixacompFastConvertToPdfData()
' pixacompFastConvertToPdfData(PIXAC *, const char *, l_uint8 **, size_t *) as l_ok
'''  <summary>
''' Notes
''' (1) This generates the pdf without transcoding if all the
''' images in %pixac are compressed with jpeg.
''' Images not jpeg compressed are skipped.
''' (2) It assumes all images have the same resolution, and that
''' the resolution embedded in each jpeg file is correct.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - containing images all at the same resolution</param>
'''  <param name="title">[in][optional] - pdf title</param>
'''  <param name="pdata">[out] - output pdf data (of all images</param>
'''  <param name="pnbytes">[out] - size of output pdf data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompFastConvertToPdfData(
				ByVal pixac as PixaComp, 
				ByRef pdata as Byte(), 
				ByRef pnbytes as UInteger, 
				Optional ByVal title as String = Nothing) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")

	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompFastConvertToPdfData( pixac.Pointer, title, pdataPTR, pnbytes)
ReDim pdata(IIf(pnbytes > 0, pnbytes, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

' SRC\pixcomp.c (2240, 1)
' pixacompWriteStreamInfo()
' pixacompWriteStreamInfo(FILE *, PIXAC *, const char *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''  <param name="pixac">[in] - </param>
'''  <param name="text">[in][optional] - identifying string; can be null</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompWriteStreamInfo(
				ByVal fp as FILE, 
				ByVal pixac as PixaComp, 
				Optional ByVal text as String = Nothing) as Integer

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompWriteStreamInfo( fp.Pointer, pixac.Pointer, text)

	Return _Result
End Function

' SRC\pixcomp.c (2284, 1)
' pixcompWriteStreamInfo()
' pixcompWriteStreamInfo(FILE *, PIXC *, const char *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''  <param name="pixc">[in] - </param>
'''  <param name="text">[in][optional] - identifying string; can be null</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixcompWriteStreamInfo(
				ByVal fp as FILE, 
				ByVal pixc as PixComp, 
				Optional ByVal text as String = Nothing) as Integer

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixcompWriteStreamInfo( fp.Pointer, pixc.Pointer, text)

	Return _Result
End Function

' SRC\pixcomp.c (2340, 1)
' pixacompDisplayTiledAndScaled()
' pixacompDisplayTiledAndScaled(PIXAC *, l_int32, l_int32, l_int32, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This is the same function as pixaDisplayTiledAndScaled(),
''' except it works on a Pixacomp instead of a Pix.  It is particularly
''' useful for showing the images in a Pixacomp at reduced resolution.
''' (2) See pixaDisplayTiledAndScaled() for details.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="outdepth">[in] - output depth 1, 8 or 32 bpp</param>
'''  <param name="tilewidth">[in] - each pix is scaled to this width</param>
'''  <param name="ncols">[in] - number of tiles in each row</param>
'''  <param name="background">[in] - 0 for white, 1 for black; this is the color of the spacing between the images</param>
'''  <param name="spacing">[in] - between images, and on outside</param>
'''  <param name="border">[in] - width of additional black border on each image; use 0 for no border</param>
'''   <returns>pix of tiled images, or NULL on error</returns>
Public Shared Function pixacompDisplayTiledAndScaled(
				ByVal pixac as PixaComp, 
				ByVal outdepth as Integer, 
				ByVal tilewidth as Integer, 
				ByVal ncols as Integer, 
				ByVal background as Integer, 
				ByVal spacing as Integer, 
				ByVal border as Integer) as Pix

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixacompDisplayTiledAndScaled( pixac.Pointer, outdepth, tilewidth, ncols, background, spacing, border)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pixcomp.c (2374, 1)
' pixacompWriteFiles()
' pixacompWriteFiles(PIXAC *, const char *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixac">[in] - </param>
'''  <param name="subdir">[in] - (subdirectory of /tmp)</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixacompWriteFiles(
				ByVal pixac as PixaComp, 
				ByVal subdir as String) as Integer

	If IsNothing (pixac) then Throw New ArgumentNullException  ("pixac cannot be Nothing")
	If IsNothing (subdir) then Throw New ArgumentNullException  ("subdir cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixacompWriteFiles( pixac.Pointer, subdir)

	Return _Result
End Function

' SRC\pixcomp.c (2414, 1)
' pixcompWriteFile()
' pixcompWriteFile(const char *, PIXC *) as l_ok
'''  <summary>
''' Notes
''' (1) The compressed data is written to file, and the filename is
''' generated by appending the format extension to %rootname.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="rootname">[in] - </param>
'''  <param name="pixc">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixcompWriteFile(
				ByVal rootname as String, 
				ByVal pixc as PixComp) as Integer

	If IsNothing (rootname) then Throw New ArgumentNullException  ("rootname cannot be Nothing")
	If IsNothing (pixc) then Throw New ArgumentNullException  ("pixc cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixcompWriteFile( rootname, pixc.Pointer)

	Return _Result
End Function

End Class
