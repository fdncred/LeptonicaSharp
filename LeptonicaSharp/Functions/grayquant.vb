Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\grayquant.c (171, 1)
' pixDitherToBinary()
' pixDitherToBinary(PIX *) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''   <returns>pixd dithered binary, or NULL on error The Floyd-Steinberg error diffusion dithering algorithm binarizes an 8 bpp grayscale image to a threshold of 128. If a pixel has a value above 127, it is binarized to white and the excess below 255 is subtracted from three neighboring pixels in the fractions 3/8 to i, j+1, 3/8 to i+1, j) and 1/4 to (i+1,j+1, truncating to 0 if necessary.  Likewise, if it the pixel has a value below 128, it is binarized to black and the excess above 0 is added to the neighboring pixels, truncating to 255 if necessary. This function differs from straight dithering in that it allows clipping of grayscale to 0 or 255 if the values are sufficiently close, without distribution of the excess. This uses default values to specify the range of lower and upper values near 0 and 255, rsp that are clipped to black and white without propagating the excess. Not propagating the excess has the effect of reducing the snake patterns in parts of the image that are nearly black or white; however, it also prevents the attempt to reproduce gray for those values. The implementation is straightforward.  It uses a pair of line buffers to avoid changing pixs.  It is about the same speed as pixDitherToBinaryLUT(), which uses three LUTs.</returns>
Public Shared Function pixDitherToBinary(
				ByVal pixs as Pix) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixDitherToBinary( pixs.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (203, 1)
' pixDitherToBinarySpec()
' pixDitherToBinarySpec(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) See comments above in pixDitherToBinary() for details.
''' (2) The input parameters lowerclip and upperclip specify the range
''' of lower and upper values (near 0 and 255, rsp) that are
''' clipped to black and white without propagating the excess.
''' For that reason, lowerclip and upperclip should be small numbers.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="lowerclip">[in] - lower clip distance to black; use 0 for default</param>
'''  <param name="upperclip">[in] - upper clip distance to white; use 0 for default</param>
'''   <returns>pixd dithered binary, or NULL on error</returns>
Public Shared Function pixDitherToBinarySpec(
				ByVal pixs as Pix, 
				ByVal lowerclip as Integer, 
				ByVal upperclip as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixDitherToBinarySpec( pixs.Pointer, lowerclip, upperclip)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (322, 1)
' ditherToBinaryLineLow()
' ditherToBinaryLineLow(l_uint32 *, l_int32, l_uint32 *, l_uint32 *, l_int32, l_int32, l_int32) as void
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="lined">[in] - ptr to beginning of dest line</param>
'''  <param name="w">[in] - width of image in pixels</param>
'''  <param name="bufs1">[in] - buffer of current source line</param>
'''  <param name="bufs2">[in] - buffer of next source line</param>
'''  <param name="lowerclip">[in] - lower clip distance to black</param>
'''  <param name="upperclip">[in] - upper clip distance to white</param>
'''  <param name="lastlineflag">[in] - 0 if not last dest line, 1 if last dest line</param>
Public Shared Sub ditherToBinaryLineLow(
				ByVal lined as Byte(), 
				ByVal w as Integer, 
				ByVal bufs1 as Byte(), 
				ByVal bufs2 as Byte(), 
				ByVal lowerclip as Integer, 
				ByVal upperclip as Integer, 
				ByVal lastlineflag as Integer)

	If IsNothing (lined) then Throw New ArgumentNullException  ("lined cannot be Nothing")
	If IsNothing (bufs1) then Throw New ArgumentNullException  ("bufs1 cannot be Nothing")
	If IsNothing (bufs2) then Throw New ArgumentNullException  ("bufs2 cannot be Nothing")

	Dim linedPTR As IntPtr = Marshal.AllocHGlobal(lined.Count) : Marshal.Copy(lined, 0, linedPTR, lined.Length)
	Dim bufs1PTR As IntPtr = Marshal.AllocHGlobal(bufs1.Count) : Marshal.Copy(bufs1, 0, bufs1PTR, bufs1.Length)
	Dim bufs2PTR As IntPtr = Marshal.AllocHGlobal(bufs2.Count) : Marshal.Copy(bufs2, 0, bufs2PTR, bufs2.Length)

	LeptonicaSharp.Natives.ditherToBinaryLineLow( linedPTR, w, bufs1PTR, bufs2PTR, lowerclip, upperclip, lastlineflag)

End Sub

' SRC\grayquant.c (443, 1)
' pixThresholdToBinary()
' pixThresholdToBinary(PIX *, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) If the source pixel is less than the threshold value,
''' the dest will be 1; otherwise, it will be 0.
''' (2) For example, for 8 bpp src pix, if %thresh == 256, the dest
''' 1 bpp pix is all ones (fg), and if %thresh == 0, the dest
''' pix is all zeros (bg).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 4 or 8 bpp</param>
'''  <param name="thresh">[in] - threshold value</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixThresholdToBinary(
				ByVal pixs as Pix, 
				ByVal thresh as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If {4,8}.contains (pixs.d) = false then Throw New ArgumentException ("4 or 8 bpp")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixThresholdToBinary( pixs.Pointer, thresh)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (519, 1)
' 
' thresholdToBinaryLineLow(l_uint32 *, l_int32, l_uint32 *, l_int32, l_int32) as void
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
Public Shared Sub thresholdToBinaryLineLow(
				ByRef lined as Object, 
				ByRef w as Integer, 
				ByRef lines as Object, 
				ByRef d as Integer, 
				ByRef thresh as Integer)

	If IsNothing (lined) then Throw New ArgumentNullException  ("lined cannot be Nothing")
	If IsNothing (lines) then Throw New ArgumentNullException  ("lines cannot be Nothing")


	LeptonicaSharp.Natives.thresholdToBinaryLineLow( lined, w, lines, d, thresh)

End Sub

' SRC\grayquant.c (650, 1)
' pixVarThresholdToBinary()
' pixVarThresholdToBinary(PIX *, PIX *) as PIX *
'''  <summary>
''' Notes
''' (1) If the pixel in pixs is less than the corresponding pixel
''' in pixg, the dest will be 1; otherwise it will be 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="pixg">[in] - 8 bpp; contains threshold values for each pixel</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixVarThresholdToBinary(
				ByVal pixs as Pix, 
				ByVal pixg as Pix) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixg) then Throw New ArgumentNullException  ("pixg cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixVarThresholdToBinary( pixs.Pointer, pixg.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (725, 1)
' pixAdaptThresholdToBinary()
' pixAdaptThresholdToBinary(PIX *, PIX *, l_float32) as PIX *
'''  <summary>
''' Notes
''' (1) This is a simple convenience function for doing adaptive
''' thresholding on a grayscale image with variable background.
''' It uses default parameters appropriate for typical text images.
''' (2) %pixm is a 1 bpp mask over "image" regions, which are not
''' expected to have a white background.  The mask inhibits
''' background finding under the fg pixels of the mask.  For
''' images with both text and image, the image regions would
''' be binarized (or quantized) by a different set of operations.
''' (3) As %gamma is increased, the foreground pixels are reduced.
''' (4) Under the covers  The default background value for normalization
''' is 200, so we choose 170 for 'maxval' in pixGammaTRC.  Likewise,
''' the default foreground threshold for normalization is 60,
''' so we choose 50 for 'minval' in pixGammaTRC.  Because
''' 170 was mapped to 255, choosing 200 for the threshold is
''' quite safe for avoiding speckle noise from the background.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="pixm">[in][optional] - 1 bpp image mask; can be null</param>
'''  <param name="gamma">[in] - gamma correction; must be GT 0.0; typically ~1.0</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixAdaptThresholdToBinary(
				ByVal pixs as Pix, 
				ByVal pixm as Pix, 
				ByVal gamma as Single) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (gamma) then Throw New ArgumentNullException  ("gamma cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")

	Dim pixmPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixm) Then pixmPTR = pixm.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixAdaptThresholdToBinary( pixs.Pointer, pixmPTR, gamma)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (765, 1)
' pixAdaptThresholdToBinaryGen()
' pixAdaptThresholdToBinaryGen(PIX *, PIX *, l_float32, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This is a convenience function for doing adaptive thresholding
''' on a grayscale image with variable background.  Also see notes
''' in pixAdaptThresholdToBinary().
''' (2) Reducing %gamma increases the foreground (text) pixels.
''' Use a low value (e.g., 0.5) for images with light text.
''' (3) For normal images, see default args in pixAdaptThresholdToBinary().
''' For images with very light text, these values are appropriate
''' gamma  ~0.5
''' blackval  ~70
''' whiteval  ~190
''' thresh ~200
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="pixm">[in][optional] - 1 bpp image mask; can be null</param>
'''  <param name="gamma">[in] - gamma correction; must be GT 0.0; typically ~1.0</param>
'''  <param name="blackval">[in] - dark value to set to black (0)</param>
'''  <param name="whiteval">[in] - light value to set to white (255)</param>
'''  <param name="thresh">[in] - final threshold for binarization</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixAdaptThresholdToBinaryGen(
				ByVal pixs as Pix, 
				ByVal pixm as Pix, 
				ByVal gamma as Single, 
				ByVal blackval as Integer, 
				ByVal whiteval as Integer, 
				ByVal thresh as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (gamma) then Throw New ArgumentNullException  ("gamma cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")

	Dim pixmPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixm) Then pixmPTR = pixm.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixAdaptThresholdToBinaryGen( pixs.Pointer, pixmPTR, gamma, blackval, whiteval, thresh)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (810, 1)
' pixGenerateMaskByValue()
' pixGenerateMaskByValue(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) %val is the pixel value that we are selecting.  It can be
''' either a gray value or a colormap index.
''' (2) If pixs is colormapped, %usecmap determines if the colormap
''' index values are used, or if the colormap is removed to gray and
''' the gray values are used.  For the latter, it generates
''' an approximate grayscale value for each pixel, and then looks
''' for gray pixels with the value %val.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 2, 4 or 8 bpp, or colormapped</param>
'''  <param name="val">[in] - of pixels for which we set 1 in dest</param>
'''  <param name="usecmap">[in] - 1 to retain cmap values; 0 to convert to gray</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixGenerateMaskByValue(
				ByVal pixs as Pix, 
				ByVal val as Integer, 
				ByVal usecmap as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixGenerateMaskByValue( pixs.Pointer, val, usecmap)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (900, 1)
' pixGenerateMaskByBand()
' pixGenerateMaskByBand(PIX *, l_int32, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Generates a 1 bpp mask pixd, the same size as pixs, where
''' the fg pixels in the mask are those either within the specified
''' band (for inband == 1) or outside the specified band
''' (for inband == 0).
''' (2) If pixs is colormapped, %usecmap determines if the colormap
''' values are used, or if the colormap is removed to gray and
''' the gray values are used.  For the latter, it generates
''' an approximate grayscale value for each pixel, and then looks
''' for gray pixels with the value %val.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 2, 4 or 8 bpp, or colormapped</param>
'''  <param name="lower">[in] - two pixel values from which a range, either between (inband) or outside of (!inband), determines which pixels in pixs cause us to set a 1 in the dest mask</param>
'''  <param name="upper">[in] - two pixel values from which a range, either between (inband) or outside of (!inband), determines which pixels in pixs cause us to set a 1 in the dest mask</param>
'''  <param name="inband">[in] - 1 for finding pixels in [lower, upper]; 0 for finding pixels in [0, lower) union (upper, 255]</param>
'''  <param name="usecmap">[in] - 1 to retain cmap values; 0 to convert to gray</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixGenerateMaskByBand(
				ByVal pixs as Pix, 
				ByVal lower as Integer, 
				ByVal upper as Integer, 
				ByVal inband as Integer, 
				ByVal usecmap as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixGenerateMaskByBand( pixs.Pointer, lower, upper, inband, usecmap)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1013, 1)
' pixDitherTo2bpp()
' pixDitherTo2bpp(PIX *, l_int32) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="cmapflag">[in] - 1 to generate a colormap</param>
'''   <returns>pixd dithered 2 bpp, or NULL on error An analog of the Floyd-Steinberg error diffusion dithering algorithm is used to "dibitize" an 8 bpp grayscale image to 2 bpp, using equally spaced gray values of 0, 85, 170, and 255, which are served by thresholds of 43, 128 and 213. If cmapflag == 1, the colormap values are set to 0, 85, 170 and 255. If a pixel has a value between 0 and 42, it is dibitized to 0, and the excess above 0 is added to the three neighboring pixels, in the fractions 3/8 to i, j+1, 3/8 to i+1, j) and 1/4 to (i+1, j+1, truncating to 255 if necessary.  If a pixel has a value between 43 and 127, it is dibitized to 1, and the excess above 85 is added to the three neighboring pixels as before.  If the value is below 85, the excess is subtracted.  With a value between 128 and 212, it is dibitized to 2, with the excess on either side of 170 distributed as before.  Finally, with a value between 213 and 255, it is dibitized to 3, with the excess below 255 subtracted from the neighbors.  We always truncate to 0 or 255. The details can be seen in the lookup table generation. This function differs from straight dithering in that it allows clipping of grayscale to 0 or 255 if the values are sufficiently close, without distribution of the excess. This uses default values from pix.h to specify the range of lower and upper values near 0 and 255, rsp that are clipped to black and white without propagating the excess. Not propagating the excess has the effect of reducing the snake patterns in parts of the image that are nearly black or white; however, it also prevents any attempt to reproduce gray for those values. The implementation uses 3 lookup tables for simplicity, and a pair of line buffers to avoid modifying pixs.</returns>
Public Shared Function pixDitherTo2bpp(
				ByVal pixs as Pix, 
				ByVal cmapflag as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixDitherTo2bpp( pixs.Pointer, cmapflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1047, 1)
' pixDitherTo2bppSpec()
' pixDitherTo2bppSpec(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) See comments above in pixDitherTo2bpp() for details.
''' (2) The input parameters lowerclip and upperclip specify the range
''' of lower and upper values (near 0 and 255, rsp) that are
''' clipped to black and white without propagating the excess.
''' For that reason, lowerclip and upperclip should be small numbers.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="lowerclip">[in] - lower clip distance to black; use 0 for default</param>
'''  <param name="upperclip">[in] - upper clip distance to white; use 0 for default</param>
'''  <param name="cmapflag">[in] - 1 to generate a colormap</param>
'''   <returns>pixd dithered 2 bpp, or NULL on error</returns>
Public Shared Function pixDitherTo2bppSpec(
				ByVal pixs as Pix, 
				ByVal lowerclip as Integer, 
				ByVal upperclip as Integer, 
				ByVal cmapflag as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixDitherTo2bppSpec( pixs.Pointer, lowerclip, upperclip, cmapflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1373, 1)
' pixThresholdTo2bpp()
' pixThresholdTo2bpp(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Valid values for nlevels is the set {2, 3, 4}.
''' (2) Any colormap on the input pixs is removed to 8 bpp grayscale.
''' (3) This function is typically invoked with cmapflag == 1.
''' In the situation where no colormap is desired, nlevels is
''' ignored and pixs is thresholded to 4 levels.
''' (4) The target output colors are equally spaced, with the
''' darkest at 0 and the lightest at 255.  The thresholds are
''' chosen halfway between adjacent output values.  A table
''' is built that specifies the mapping from src to dest.
''' (5) If cmapflag == 1, a colormap of size 'nlevels' is made,
''' and the pixel values in pixs are replaced by their
''' appropriate color indices.  The number of holdouts,
''' 4 - nlevels, will be between 0 and 2.
''' (6) If you don't want the thresholding to be equally spaced,
''' either first transform the 8 bpp src using pixGammaTRC().
''' or, if cmapflag == 1, after calling this function you can use
''' pixcmapResetColor() to change any individual colors.
''' (7) If a colormap is generated, it will specify (to display
''' programs) exactly how each level is to be represented in RGB
''' space.  When representing text, 3 levels is far better than
''' 2 because of the antialiasing of the single gray level,
''' and 4 levels (black, white and 2 gray levels) is getting
''' close to the perceptual quality of a (nearly continuous)
''' grayscale image.  With 2 bpp, you can set up a colormap
''' and allocate from 2 to 4 levels to represent antialiased text.
''' Any left over colormap entries can be used for coloring regions.
''' For the same number of levels, the file size of a 2 bpp image
''' is about 10% smaller than that of a 4 bpp result for the same
''' number of levels.  For both 2 bpp and 4 bpp, using 4 levels you
''' get compression far better than that of jpeg, because the
''' quantization to 4 levels will remove the jpeg ringing in the
''' background near character edges.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="nlevels">[in] - equally spaced; must be between 2 and 4</param>
'''  <param name="cmapflag">[in] - 1 to build colormap; 0 otherwise</param>
'''   <returns>pixd 2 bpp, optionally with colormap, or NULL on error</returns>
Public Shared Function pixThresholdTo2bpp(
				ByVal pixs as Pix, 
				ByVal nlevels as Integer, 
				ByVal cmapflag as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixThresholdTo2bpp( pixs.Pointer, nlevels, cmapflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1515, 1)
' pixThresholdTo4bpp()
' pixThresholdTo4bpp(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Valid values for nlevels is the set {2, ... 16}.
''' (2) Any colormap on the input pixs is removed to 8 bpp grayscale.
''' (3) This function is typically invoked with cmapflag == 1.
''' In the situation where no colormap is desired, nlevels is
''' ignored and pixs is thresholded to 16 levels.
''' (4) The target output colors are equally spaced, with the
''' darkest at 0 and the lightest at 255.  The thresholds are
''' chosen halfway between adjacent output values.  A table
''' is built that specifies the mapping from src to dest.
''' (5) If cmapflag == 1, a colormap of size 'nlevels' is made,
''' and the pixel values in pixs are replaced by their
''' appropriate color indices.  The number of holdouts,
''' 16 - nlevels, will be between 0 and 14.
''' (6) If you don't want the thresholding to be equally spaced,
''' either first transform the 8 bpp src using pixGammaTRC().
''' or, if cmapflag == 1, after calling this function you can use
''' pixcmapResetColor() to change any individual colors.
''' (7) If a colormap is generated, it will specify, to display
''' programs, exactly how each level is to be represented in RGB
''' space.  When representing text, 3 levels is far better than
''' 2 because of the antialiasing of the single gray level,
''' and 4 levels (black, white and 2 gray levels) is getting
''' close to the perceptual quality of a (nearly continuous)
''' grayscale image.  Therefore, with 4 bpp, you can set up a
''' colormap, allocate a relatively small fraction of the 16
''' possible values to represent antialiased text, and use the
''' other colormap entries for other things, such as coloring
''' text or background.  Two other reasons for using a small number
''' of gray values for antialiased text are (1) PNG compression
''' gets worse as the number of levels that are used is increased,
''' and (2) using a small number of levels will filter out most of
''' the jpeg ringing that is typically introduced near sharp edges
''' of text.  This filtering is partly responsible for the improved
''' compression.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp, can have colormap</param>
'''  <param name="nlevels">[in] - equally spaced; must be between 2 and 16</param>
'''  <param name="cmapflag">[in] - 1 to build colormap; 0 otherwise</param>
'''   <returns>pixd 4 bpp, optionally with colormap, or NULL on error</returns>
Public Shared Function pixThresholdTo4bpp(
				ByVal pixs as Pix, 
				ByVal nlevels as Integer, 
				ByVal cmapflag as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixThresholdTo4bpp( pixs.Pointer, nlevels, cmapflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1632, 1)
' pixThresholdOn8bpp()
' pixThresholdOn8bpp(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Valid values for nlevels is the set {2,...,256}.
''' (2) Any colormap on the input pixs is removed to 8 bpp grayscale.
''' (3) If cmapflag == 1, a colormap of size 'nlevels' is made,
''' and the pixel values in pixs are replaced by their
''' appropriate color indices.  Otherwise, the pixel values
''' are the actual thresholded (i.e., quantized) grayscale values.
''' (4) If you don't want the thresholding to be equally spaced,
''' first transform the input 8 bpp src using pixGammaTRC().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp, can have colormap</param>
'''  <param name="nlevels">[in] - equally spaced; must be between 2 and 256</param>
'''  <param name="cmapflag">[in] - 1 to build colormap; 0 otherwise</param>
'''   <returns>pixd 8 bpp, optionally with colormap, or NULL on error</returns>
Public Shared Function pixThresholdOn8bpp(
				ByVal pixs as Pix, 
				ByVal nlevels as Integer, 
				ByVal cmapflag as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixThresholdOn8bpp( pixs.Pointer, nlevels, cmapflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1733, 1)
' pixThresholdGrayArb()
' pixThresholdGrayArb(PIX *, const char *, l_int32, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This function allows exact specification of the quantization bins.
''' The string %edgevals is a space-separated set of values
''' specifying the dividing points between output quantization bins.
''' These threshold values are assigned to the bin with higher
''' values, so that each of them is the smallest value in their bin.
''' (2) The output image (pixd) depth is specified by %outdepth.  The
''' number of bins is the number of edgevals + 1.  The
''' relation between outdepth and the number of bins is
''' outdepth = 2 nbins LT= 4
''' outdepth = 4 nbins LT= 16
''' outdepth = 8 nbins LT= 256
''' With %outdepth == 0, the minimum required depth for the
''' given number of bins is used.
''' The output pixd has a colormap.
''' (3) The last 3 args determine the specific values that go into
''' the colormap.
''' (4) For %use_average
''' ~ if TRUE, the average value of pixels falling in the bin is
''' chosen as the representative gray value.  Otherwise,
''' ~ if FALSE, the central value of each bin is chosen as
''' the representative value.
''' The colormap holds the representative value.
''' (5) For %setblack, if TRUE the darkest color is set to (0,0,0).
''' (6) For %setwhite, if TRUE the lightest color is set to (255,255,255).
''' (7) An alternative to using this function to quantize to
''' unequally-spaced bins is to first transform the 8 bpp pixs
''' using pixGammaTRC(), and follow this with pixThresholdTo4bpp().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp grayscale; can have colormap</param>
'''  <param name="edgevals">[in] - string giving edge value of each bin</param>
'''  <param name="outdepth">[in] - 0, 2, 4 or 8 bpp; 0 is default for min depth</param>
'''  <param name="use_average">[in] - 1 if use the average pixel value in colormap</param>
'''  <param name="setblack">[in] - 1 if darkest color is set to black</param>
'''  <param name="setwhite">[in] - 1 if lightest color is set to white</param>
'''   <returns>pixd 2, 4 or 8 bpp quantized image with colormap, or NULL on error</returns>
Public Shared Function pixThresholdGrayArb(
				ByVal pixs as Pix, 
				ByVal edgevals as String, 
				ByVal outdepth as Integer, 
				ByVal use_average as Integer, 
				ByVal setblack as Integer, 
				ByVal setwhite as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (edgevals) then Throw New ArgumentNullException  ("edgevals cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixThresholdGrayArb( pixs.Pointer, edgevals, outdepth, use_average, setblack, setwhite)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (1843, 1)
' makeGrayQuantIndexTable()
' makeGrayQuantIndexTable(l_int32) as l_int32 *
'''  <summary>
''' Notes
''' (1) 'nlevels' is some number between 2 and 256 (typically 8 or less).
''' (2) The table is typically used for quantizing 2, 4 and 8 bpp
''' grayscale src pix, and generating a colormapped dest pix.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="nlevels">[in] - number of output levels</param>
'''   <returns>table maps input gray level to colormap index, or NULL on error</returns>
Public Shared Function makeGrayQuantIndexTable(
				ByVal nlevels as Integer) as Integer()



	Dim _Result as Integer() = LeptonicaSharp.Natives.makeGrayQuantIndexTable( nlevels)

	Return _Result
End Function

' SRC\grayquant.c (1952, 1)
' makeGrayQuantTableArb()
' makeGrayQuantTableArb(NUMA *, l_int32, l_int32 **, PIXCMAP **) as l_ok
'''  <summary>
''' Notes
''' (1) The number of bins is the count of %na + 1.
''' (2) The bin boundaries in na must be sorted in increasing order.
''' (3) The table is an inverse colormap it maps input gray level
''' to colormap index (the bin number).
''' (4) The colormap generated here has quantized values at the
''' center of each bin.  If you want to use the average gray
''' value of pixels within the bin, discard the colormap and
''' compute it using makeGrayQuantColormapArb().
''' (5) Returns an error if there are not enough levels in the
''' output colormap for the number of bins.  The number
''' of bins must not exceed 2^outdepth.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - numa of bin boundaries</param>
'''  <param name="outdepth">[in] - of colormap 1, 2, 4 or 8</param>
'''  <param name="ptab">[out] - table mapping input gray level to cmap index</param>
'''  <param name="pcmap">[out] - colormap</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function makeGrayQuantTableArb(
				ByVal na as Numa, 
				ByVal outdepth as Integer, 
				ByRef ptab as List (of Integer()), 
				ByRef pcmap as PixColormap) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")

Dim ptabPTR As IntPtr = Marshal.AllocHGlobal(0)
	Dim pcmapPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pcmap) Then pcmapPTR = pcmap.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.makeGrayQuantTableArb( na.Pointer, outdepth, ptabPTR, pcmapPTR)
	if pcmapPTR <> IntPtr.Zero then pcmap = new PixColormap(pcmapPTR)

	Return _Result
End Function

' SRC\grayquant.c (2129, 1)
' pixGenerateMaskByBand32()
' pixGenerateMaskByBand32(PIX *, l_uint32, l_int32, l_int32, l_float32, l_float32) as PIX *
'''  <summary>
''' Notes
''' (1) Generates a 1 bpp mask pixd, the same size as pixs, where
''' the fg pixels in the mask within a band of rgb values
''' surrounding %refval.  The band can be chosen in two ways
''' for each component
''' (a) Use (%delm, %delp) to specify how many levels down and up
''' (b) Use (%fractm, %fractp) to specify the fractional
''' distance toward 0 and 255, respectively.
''' Note that %delm and %delp must be in [0 ... 255], whereas
''' %fractm and %fractp must be in [0.0 - 1.0].
''' (2) Either (%delm, %delp) or (%fractm, %fractp) can be used.
''' Set each value in the other pair to 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 32 bpp</param>
'''  <param name="refval">[in] - reference rgb value</param>
'''  <param name="delm">[in] - max amount below the ref value for any component</param>
'''  <param name="delp">[in] - max amount above the ref value for any component</param>
'''  <param name="fractm">[in] - fractional amount below ref value for all components</param>
'''  <param name="fractp">[in] - fractional amount above ref value for all components</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixGenerateMaskByBand32(
				ByVal pixs as Pix, 
				ByVal refval as UInteger, 
				ByVal delm as Integer, 
				ByVal delp as Integer, 
				ByVal fractm as Single, 
				ByVal fractp as Single) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (fractm) then Throw New ArgumentNullException  ("fractm cannot be Nothing")
	If IsNothing (fractp) then Throw New ArgumentNullException  ("fractp cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixGenerateMaskByBand32( pixs.Pointer, refval, delm, delp, fractm, fractp)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (2227, 1)
' pixGenerateMaskByDiscr32()
' pixGenerateMaskByDiscr32(PIX *, l_uint32, l_uint32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Generates a 1 bpp mask pixd, the same size as pixs, where
''' the fg pixels in the mask are those where the pixel in pixs
''' is "closer" to refval1 than to refval2.
''' (2) "Closer" can be defined in several ways, such as
''' ~ manhattan distance (L1)
''' ~ euclidean distance (L2)
''' ~ majority vote of the individual components
''' Here, we have a choice of L1 or L2.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 32 bpp</param>
'''  <param name="refval1">[in] - reference rgb value</param>
'''  <param name="refval2">[in] - reference rgb value</param>
'''  <param name="distflag">[in] - L_MANHATTAN_DISTANCE, L_EUCLIDEAN_DISTANCE</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixGenerateMaskByDiscr32(
				ByVal pixs as Pix, 
				ByVal refval1 as UInteger, 
				ByVal refval2 as UInteger, 
				ByVal distflag as Enumerations.L_AN_DISTANCE) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixGenerateMaskByDiscr32( pixs.Pointer, refval1, refval2, distflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (2341, 1)
' pixGrayQuantFromHisto()
' pixGrayQuantFromHisto(PIX *, PIX *, PIX *, l_float32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This is useful for quantizing images with relatively few
''' colors, but which may have both color and gray pixels.
''' If there are color pixels, it is assumed that an input
''' rgb image has been color quantized first so that
''' ~ pixd has a colormap describing the color pixels
''' ~ pixm is a mask over the non-color pixels in pixd
''' ~ the colormap in pixd, and the color pixels in pixd,
''' have been repacked to go from 0 to n-1 (n colors)
''' If there are no color pixels, pixd and pixm are both null,
''' and all pixels in pixs are quantized to gray.
''' (2) A 256-entry histogram is built of the gray values in pixs.
''' If pixm exists, the pixels contributing to the histogram are
''' restricted to the fg of pixm.  A colormap and LUT are generated
''' from this histogram.  We break up the array into a set
''' of intervals, each one constituting a color in the colormap
''' An interval is identified by summing histogram bins until
''' either the sum equals or exceeds the %minfract of the total
''' number of pixels, or the span itself equals or exceeds %maxsize.
''' The color of each bin is always an average of the pixels
''' that constitute it.
''' (3) Note that we do not specify the number of gray colors in
''' the colormap.  Instead, we specify two parameters that
''' describe the accuracy of the color assignments; this and
''' the actual image determine the number of resulting colors.
''' (4) If a mask exists and it is not the same size as pixs, make
''' a new mask the same size as pixs, with the original mask
''' aligned at the UL corners.  Set all additional pixels
''' in the (larger) new mask set to 1, causing those pixels
''' in pixd to be set as gray.
''' (5) We estimate the total number of colors (color plus gray);
''' if it exceeds 255, return null.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixd">[in][optional] - quantized pix with cmap; can be null</param>
'''  <param name="pixs">[in] - 8 bpp gray input pix; not cmapped</param>
'''  <param name="pixm">[in][optional] - mask over pixels in pixs to quantize</param>
'''  <param name="minfract">[in] - minimum fraction of pixels in a set of adjacent histo bins that causes the set to be automatically set aside as a color in the colormap; must be at least 0.01</param>
'''  <param name="maxsize">[in] - maximum number of adjacent bins allowed to represent a color, regardless of the population of pixels in the bins; must be at least 2</param>
'''   <returns>pixd 8 bpp, cmapped, or NULL on error</returns>
Public Shared Function pixGrayQuantFromHisto(
				ByVal pixd as Pix, 
				ByVal pixs as Pix, 
				ByVal pixm as Pix, 
				ByVal minfract as Single, 
				ByVal maxsize as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (minfract) then Throw New ArgumentNullException  ("minfract cannot be Nothing")

	Dim pixdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixd) Then pixdPTR = pixd.Pointer
	Dim pixmPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixm) Then pixmPTR = pixm.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixGrayQuantFromHisto( pixdPTR, pixs.Pointer, pixmPTR, minfract, maxsize)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\grayquant.c (2564, 1)
' pixGrayQuantFromCmap()
' pixGrayQuantFromCmap(PIX *, PIXCMAP *, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) In use, pixs is an 8 bpp grayscale image without a colormap.
''' If there is an existing colormap, a warning is issued and
''' a copy of the input pixs is returned.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp grayscale without cmap</param>
'''  <param name="cmap">[in] - to quantize to; of dest pix</param>
'''  <param name="mindepth">[in] - minimum depth of pixd can be 2, 4 or 8 bpp</param>
'''   <returns>pixd 2, 4 or 8 bpp, colormapped, or NULL on error</returns>
Public Shared Function pixGrayQuantFromCmap(
				ByVal pixs as Pix, 
				ByVal cmap as PixColormap, 
				ByVal mindepth as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (cmap) then Throw New ArgumentNullException  ("cmap cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixGrayQuantFromCmap( pixs.Pointer, cmap.Pointer, mindepth)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

End Class