Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _All


' SRC\pdfio2.c (182, 1)
' pixConvertToPdfData(pix, type, quality, pdata, pnbytes, x, y, res, title, plpd, position) as Integer
' pixConvertToPdfData(PIX *, l_int32, l_int32, l_uint8 **, size_t *, l_int32, l_int32, l_int32, const char *, L_PDF_DATA **, l_int32) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If %res == 0 and the input resolution field is 0,<para/>
''' this will use DEFAULT_INPUT_RES.<para/>
''' (2) This only writes %data if it is the last image to be<para/>
''' written on the page.<para/>
''' (3) See comments in convertToPdf().<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pix">[in] - all depths cmap OK</param>
'''  <param name="type">[in] - L_G4_ENCODE, L_JPEG_ENCODE, L_FLATE_ENCODE</param>
'''  <param name="quality">[in] - used for JPEG only 0 for default (75)</param>
'''  <param name="pdata">[out] - pdf array</param>
'''  <param name="pnbytes">[out] - number of bytes in pdf array</param>
'''  <param name="x">[in] - location of lower-left corner of image, in pixels, relative to the PostScript origin (0,0) at the lower-left corner of the page)</param>
'''  <param name="y">[in] - location of lower-left corner of image, in pixels, relative to the PostScript origin (0,0) at the lower-left corner of the page)</param>
'''  <param name="res">[in] - override the resolution of the input image, in ppi use 0 to respect the resolution embedded in the input</param>
'''  <param name="title">[in][optional] - pdf title</param>
'''  <param name="plpd">[in,out] - ptr to lpd, which is created on the first invocation and returned until last image is processed</param>
'''  <param name="position">[in] - in image sequence: L_FIRST_IMAGE, L_NEXT_IMAGE, L_LAST_IMAGE</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixConvertToPdfData(
				 ByVal pix as Pix, 
				 ByVal type as Enumerations.L_ENCODE, 
				 ByVal quality as Integer, 
				<Out()> ByRef pdata as Byte(), 
				<Out()> ByRef pnbytes as UInteger, 
				 ByVal x as Integer, 
				 ByVal y as Integer, 
				 ByVal res as Integer, 
				 ByVal title as String, 
				 ByRef plpd as L_Pdf_Data, 
				 ByVal position as Enumerations.L_T_IMAGE) as Integer

	If IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")



	Dim pdataPTR As IntPtr = IntPtr.Zero
	Dim plpdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(plpd) Then plpdPTR = plpd.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixConvertToPdfData( pix.Pointer, type, quality, pdataPTR, pnbytes, x, y, res, title, plpdPTR, position)
	ReDim pdata(IIf(pnbytes > 0, pnbytes, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)
	if plpdPTR <> IntPtr.Zero then plpd = new L_Pdf_Data(plpdPTR)

	Return _Result
End Function

' SRC\pdfio2.c (307, 1)
' ptraConcatenatePdfToData(pa_data, sa, pdata, pnbytes) as Integer
' ptraConcatenatePdfToData(L_PTRA *, SARRAY *, l_uint8 **, size_t *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This only works with leptonica-formatted single-page pdf files.<para/>
''' pdf files generated by other programs will have unpredictable<para/>
''' (and usually bad) results.  The requirements for each pdf file:<para/>
''' (a) The Catalog and Info objects are the first two.<para/>
''' (b) Object 3 is Pages<para/>
''' (c) Object 4 is Page<para/>
''' (d) The remaining objects are Contents, XObjects, and ColorSpace<para/>
''' (2) We remove trailers from each page, and append the full trailer<para/>
''' for all pages at the end.<para/>
''' (3) For all but the first file, remove the ID and the first 3<para/>
''' objects (catalog, info, pages), so that each subsequent<para/>
''' file has only objects of these classes:<para/>
''' Page, Contents, XObject, ColorSpace (Indexed RGB).<para/>
''' For those objects, we substitute these refs to objects<para/>
''' in the local file:<para/>
''' Page:  Parent(object 3), Contents, XObject(typically multiple)<para/>
''' XObject:  [ColorSpace if indexed]<para/>
''' The Pages object on the first page (object 3) has a Kids array<para/>
''' of references to all the Page objects, with a Count equal<para/>
''' to the number of pages.  Each Page object refers back to<para/>
''' this parent.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pa_data">[in] - ptra array of pdf strings, each for a single-page pdf file</param>
'''  <param name="sa">[in] - string array [optional] of pathnames for input pdf files</param>
'''  <param name="pdata">[out] - concatenated pdf data in memory</param>
'''  <param name="pnbytes">[out] - number of bytes in pdf data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function ptraConcatenatePdfToData(
				 ByVal pa_data as L_Ptra, 
				 ByVal sa as Sarray, 
				<Out()> ByRef pdata as Byte(), 
				<Out()> ByRef pnbytes as UInteger) as Integer

	If IsNothing (pa_data) then Throw New ArgumentNullException  ("pa_data cannot be Nothing")



	Dim saPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sa) Then saPTR = sa.Pointer
	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.ptraConcatenatePdfToData( pa_data.Pointer, saPTR, pdataPTR, pnbytes)
	ReDim pdata(IIf(pnbytes > 0, pnbytes, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

' SRC\pdfio2.c (471, 1)
' convertTiffMultipageToPdf(filein, fileout) as Integer
' convertTiffMultipageToPdf(const char *, const char *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) A multipage tiff file can also be converted to PS, using<para/>
''' convertTiffMultipageToPS()<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filein">[in] - (tiff)</param>
'''  <param name="fileout">[in] - (pdf)</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function convertTiffMultipageToPdf(
				 ByVal filein as String, 
				 ByVal fileout as String) as Integer

	If IsNothing (filein) then Throw New ArgumentNullException  ("filein cannot be Nothing")
	If IsNothing (fileout) then Throw New ArgumentNullException  ("fileout cannot be Nothing")




	Dim _Result as Integer = LeptonicaSharp.Natives.convertTiffMultipageToPdf( filein, fileout)

	Return _Result
End Function

' SRC\pdfio2.c (520, 1)
' l_generateCIDataForPdf(fname, pix, quality, pcid) as Integer
' l_generateCIDataForPdf(const char *, PIX *, l_int32, L_COMP_DATA **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) You must set either filename or pix.<para/>
''' (2) Given an image file and optionally a pix raster of that data,<para/>
''' this provides a CID that is compatible with PDF, preferably<para/>
''' without transcoding.<para/>
''' (3) The pix is included for efficiency, in case transcoding<para/>
''' is required and the pix is available to the caller.<para/>
''' (4) We don't try to open files named "stdin" or "-" for Tesseract<para/>
''' compatibility reasons. We may remove this restriction<para/>
''' in the future.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fname">[in][optional] - can be null</param>
'''  <param name="pix">[in][optional] - can be null</param>
'''  <param name="quality">[in] - for jpeg if transcoded 75 is standard</param>
'''  <param name="pcid">[out] - compressed data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function l_generateCIDataForPdf(
				 ByVal fname as String, 
				 ByVal pix as Pix, 
				 ByVal quality as Integer, 
				<Out()> ByRef pcid as L_Compressed_Data) as Integer




	Dim pixPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pix) Then pixPTR = pix.Pointer
	Dim pcidPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pcid) Then pcidPTR = pcid.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.l_generateCIDataForPdf( fname, pixPTR, quality, pcidPTR)
	if pcidPTR <> IntPtr.Zero then pcid = new L_Compressed_Data(pcidPTR)

	Return _Result
End Function

' SRC\pdfio2.c (598, 1)
' l_generateFlateDataPdf(fname, pixs) as L_Compressed_Data
' l_generateFlateDataPdf(const char *, PIX *) as L_COMP_DATA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If you hand this a png file, you are going to get<para/>
''' png predictors embedded in the flate data. So it has<para/>
''' come to this. http://xkcd.com/1022/<para/>
''' (2) Exception: if the png is interlaced or if it is RGBA,<para/>
''' it will be transcoded.<para/>
''' (3) If transcoding is required, this will not have to read from<para/>
''' file if you also input a pix.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fname">[in] - preferably png</param>
'''  <param name="pixs">[in][optional] - can be null</param>
'''   <returns>cid containing png data, or NULL on error</returns>
Public Shared Function l_generateFlateDataPdf(
				 ByVal fname as String, 
				 ByVal pixs as Pix) as L_Compressed_Data

	If IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")



	Dim pixsPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixs) Then pixsPTR = pixs.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_generateFlateDataPdf( fname, pixsPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Compressed_Data(_Result)
End Function

' SRC\pdfio2.c (795, 1)
' l_generateJpegData(fname, ascii85flag) as L_Compressed_Data
' l_generateJpegData(const char *, l_int32) as L_COMP_DATA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Set ascii85flag:<para/>
''' ~ 0 for binary data (not permitted in PostScript)<para/>
''' ~ 1 for ascii85 (5 for 4) encoded binary data<para/>
''' (not permitted in pdf)<para/>
''' (2) Do not free the data.  l_generateJpegDataMem() will free<para/>
''' the data if it does not use ascii encoding.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fname">[in] - of jpeg file</param>
'''  <param name="ascii85flag">[in] - 0 for jpeg 1 for ascii85-encoded jpeg</param>
'''   <returns>cid containing jpeg data, or NULL on error</returns>
Public Shared Function l_generateJpegData(
				 ByVal fname as String, 
				 ByVal ascii85flag as Integer) as L_Compressed_Data

	If IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")




	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_generateJpegData( fname, ascii85flag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Compressed_Data(_Result)
End Function

' SRC\pdfio2.c (829, 1)
' l_generateJpegDataMem(data, nbytes, ascii85flag) as L_Compressed_Data
' l_generateJpegDataMem(l_uint8 *, size_t, l_int32) as L_COMP_DATA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) See l_generateJpegData().<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="data">[in] - of jpeg file</param>
'''  <param name="nbytes">[in] - </param>
'''  <param name="ascii85flag">[in] - 0 for jpeg 1 for ascii85-encoded jpeg</param>
'''   <returns>cid containing jpeg data, or NULL on error</returns>
Public Shared Function l_generateJpegDataMem(
				 ByVal data as Byte(), 
				 ByVal nbytes as UInteger, 
				 ByVal ascii85flag as Integer) as L_Compressed_Data

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")




	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_generateJpegDataMem( data, nbytes, ascii85flag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Compressed_Data(_Result)
End Function

' SRC\pdfio2.c (943, 1)
' l_generateCIData(fname, type, quality, ascii85, pcid) as Integer
' l_generateCIData(const char *, l_int32, l_int32, l_int32, L_COMP_DATA **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This can be used for both PostScript and pdf.<para/>
''' (1) Set ascii85:<para/>
''' ~ 0 for binary data (not permitted in PostScript)<para/>
''' ~ 1 for ascii85 (5 for 4) encoded binary data<para/>
''' (2) This attempts to compress according to the requested type.<para/>
''' If this can't be done, it falls back to ordinary flate encoding.<para/>
''' (3) This differs from l_generateCIDataPdf(), which determines<para/>
''' the format and attempts to generate the CID without transcoding.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fname">[in] - </param>
'''  <param name="type">[in] - L_G4_ENCODE, L_JPEG_ENCODE, L_FLATE_ENCODE, L_JP2K_ENCODE</param>
'''  <param name="quality">[in] - used for jpeg only 0 for default (75)</param>
'''  <param name="ascii85">[in] - 0 for binary 1 for ascii85-encoded</param>
'''  <param name="pcid">[out] - compressed data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function l_generateCIData(
				 ByVal fname as String, 
				 ByVal type as Enumerations.L_ENCODE, 
				 ByVal quality as Integer, 
				 ByVal ascii85 as Integer, 
				<Out()> ByRef pcid as L_Compressed_Data) as Integer

	If IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")



	Dim pcidPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pcid) Then pcidPTR = pcid.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.l_generateCIData( fname, type, quality, ascii85, pcidPTR)
	if pcidPTR <> IntPtr.Zero then pcid = new L_Compressed_Data(pcidPTR)

	Return _Result
End Function

' SRC\pdfio2.c (1039, 1)
' pixGenerateCIData(pixs, type, quality, ascii85, pcid) as Integer
' pixGenerateCIData(PIX *, l_int32, l_int32, l_int32, L_COMP_DATA **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Set ascii85:<para/>
''' ~ 0 for binary data (not permitted in PostScript)<para/>
''' ~ 1 for ascii85 (5 for 4) encoded binary data<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 or 32 bpp, no colormap</param>
'''  <param name="type">[in] - L_G4_ENCODE, L_JPEG_ENCODE, L_FLATE_ENCODE</param>
'''  <param name="quality">[in] - used for jpeg only 0 for default (75)</param>
'''  <param name="ascii85">[in] - 0 for binary 1 for ascii85-encoded</param>
'''  <param name="pcid">[out] - compressed data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixGenerateCIData(
				 ByVal pixs as Pix, 
				 ByVal type as Enumerations.L_ENCODE, 
				 ByVal quality as Integer, 
				 ByVal ascii85 as Integer, 
				<Out()> ByRef pcid as L_Compressed_Data) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")



	Dim pcidPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pcid) Then pcidPTR = pcid.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixGenerateCIData( pixs.Pointer, type, quality, ascii85, pcidPTR)
	if pcidPTR <> IntPtr.Zero then pcid = new L_Compressed_Data(pcidPTR)

	Return _Result
End Function

' SRC\pdfio2.c (1112, 1)
' l_generateFlateData(fname, ascii85flag) as L_Compressed_Data
' l_generateFlateData(const char *, l_int32) as L_COMP_DATA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The input image is converted to one of these 4 types:<para/>
''' ~ 1 bpp<para/>
''' ~ 8 bpp, no colormap<para/>
''' ~ 8 bpp, colormap<para/>
''' ~ 32 bpp rgb<para/>
''' (2) Set ascii85flag:<para/>
''' ~ 0 for binary data (not permitted in PostScript)<para/>
''' ~ 1 for ascii85 (5 for 4) encoded binary data<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fname">[in] - </param>
'''  <param name="ascii85flag">[in] - 0 for gzipped 1 for ascii85-encoded gzipped</param>
'''   <returns>cid flate compressed image data, or NULL on error</returns>
Public Shared Function l_generateFlateData(
				 ByVal fname as String, 
				 ByVal ascii85flag as Integer) as L_Compressed_Data

	If IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")




	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_generateFlateData( fname, ascii85flag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Compressed_Data(_Result)
End Function

' SRC\pdfio2.c (1350, 1)
' l_generateG4Data(fname, ascii85flag) as L_Compressed_Data
' l_generateG4Data(const char *, l_int32) as L_COMP_DATA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Set ascii85flag:<para/>
''' ~ 0 for binary data (not permitted in PostScript)<para/>
''' ~ 1 for ascii85 (5 for 4) encoded binary data<para/>
''' (not permitted in pdf)<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fname">[in] - of g4 compressed file</param>
'''  <param name="ascii85flag">[in] - 0 for g4 compressed 1 for ascii85-encoded g4</param>
'''   <returns>cid g4 compressed image data, or NULL on error</returns>
Public Shared Function l_generateG4Data(
				 ByVal fname as String, 
				 ByVal ascii85flag as Integer) as L_Compressed_Data

	If IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")




	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_generateG4Data( fname, ascii85flag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Compressed_Data(_Result)
End Function

' SRC\pdfio2.c (1427, 1)
' cidConvertToPdfData(cid, title, pdata, pnbytes) as Integer
' cidConvertToPdfData(L_COMP_DATA *, const char *, l_uint8 **, size_t *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Caller must not destroy the cid.  It is absorbed in the<para/>
''' lpd and destroyed by this function.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="cid">[in] - compressed image data -- of jp2k image</param>
'''  <param name="title">[in][optional] - pdf title can be NULL</param>
'''  <param name="pdata">[out] - output pdf data for image</param>
'''  <param name="pnbytes">[out] - size of output pdf data</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function cidConvertToPdfData(
				 ByVal cid as L_Compressed_Data, 
				 ByVal title as String, 
				<Out()> ByRef pdata as Byte(), 
				<Out()> ByRef pnbytes as UInteger) as Integer

	If IsNothing (cid) then Throw New ArgumentNullException  ("cid cannot be Nothing")



	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.cidConvertToPdfData( cid.Pointer, title, pdataPTR, pnbytes)
	ReDim pdata(IIf(pnbytes > 0, pnbytes, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

' SRC\pdfio2.c (1476, 1)
' l_CIDataDestroy(pcid) as Object
' l_CIDataDestroy(L_COMP_DATA **) as void
'''  <remarks>
'''  </remarks>
'''  <param name="pcid">[in,out] - will be set to null before returning</param>
Public Shared Sub l_CIDataDestroy(
				 ByRef pcid as L_Compressed_Data)




	Dim pcidPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pcid) Then pcidPTR = pcid.Pointer

	LeptonicaSharp.Natives.l_CIDataDestroy( pcidPTR)
	if pcidPTR <> IntPtr.Zero then pcid = new L_Compressed_Data(pcidPTR)

End Sub

' SRC\pdfio2.c (2438, 1)
' l_pdfSetG4ImageMask(flag) as Object
' l_pdfSetG4ImageMask(l_int32) as void
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The default is for writing only the fg (through the mask).<para/>
''' That way when you write a 1 bpp image, the bg is transparent,<para/>
''' so any previously written image remains visible behind it.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="flag">[in] - 1 for writing g4 data as fg only through a mask 0 for writing fg and bg</param>
Public Shared Sub l_pdfSetG4ImageMask(
				 ByVal flag as Integer)





	LeptonicaSharp.Natives.l_pdfSetG4ImageMask( flag)

End Sub

' SRC\pdfio2.c (2458, 1)
' l_pdfSetDateAndVersion(flag) as Object
' l_pdfSetDateAndVersion(l_int32) as void
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The default is for writing this data.  For regression tests<para/>
''' that compare output against golden files, it is useful to omit.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="flag">[in] - 1 for writing date/time and leptonica version 0 for omitting this from the metadata</param>
Public Shared Sub l_pdfSetDateAndVersion(
				 ByVal flag as Integer)





	LeptonicaSharp.Natives.l_pdfSetDateAndVersion( flag)

End Sub

End Class
