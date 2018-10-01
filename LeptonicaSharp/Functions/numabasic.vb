Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\numabasic.c (187, 1)
' numaCreate()
' numaCreate(l_int32) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="n">[in] - size of number array to be alloc'd 0 for default</param>
'''   <returns>na, or NULL on error</returns>
Public Shared Function numaCreate(
				ByVal n as Integer) as Numa



	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaCreate( n)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (228, 1)
' numaCreateFromIArray()
' numaCreateFromIArray(l_int32 *, l_int32) as NUMA *
'''  <summary>
''' Notes
''' (1) We can't insert this int array into the numa, because a numa
''' takes a float array.  So this just copies the data from the
''' input array into the numa.  The input array continues to be
''' owned by the caller.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="iarray">[in] - integer</param>
'''  <param name="size">[in] - of the array</param>
'''   <returns>na, or NULL on error</returns>
Public Shared Function numaCreateFromIArray(
				ByVal iarray as Integer(), 
				ByVal size as Integer) as Numa

	If IsNothing (iarray) then Throw New ArgumentNullException  ("iarray cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaCreateFromIArray( iarray, size)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (265, 1)
' numaCreateFromFArray()
' numaCreateFromFArray(l_float32 *, l_int32, l_int32) as NUMA *
'''  <summary>
''' Notes
''' (1) With L_INSERT, ownership of the input array is transferred
''' to the returned numa, and all %size elements are considered
''' to be valid.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="farray">[in] - float</param>
'''  <param name="size">[in] - of the array</param>
'''  <param name="copyflag">[in] - L_INSERT or L_COPY</param>
'''   <returns>na, or NULL on error</returns>
Public Shared Function numaCreateFromFArray(
				ByVal farray as Single(), 
				ByVal size as Integer, 
				ByVal copyflag as Enumerations.L_access_storage) as Numa

	If IsNothing (farray) then Throw New ArgumentNullException  ("farray cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaCreateFromFArray( farray, size, copyflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (309, 1)
' numaCreateFromString()
' numaCreateFromString(const char *) as NUMA *
'''  <summary>
''' Notes
''' (1) The numbers can be ints or floats; they will be interpreted
''' and stored as floats.  To use them as integers (e.g., for
''' indexing into arrays), use numaGetIValue(...).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="str">[in] - string of comma-separated numbers</param>
'''   <returns>na, or NULL on error</returns>
Public Shared Function numaCreateFromString(
				ByVal str as String) as Numa

	If IsNothing (str) then Throw New ArgumentNullException  ("str cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaCreateFromString( str)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (360, 1)
' numaDestroy()
' numaDestroy(NUMA **) as void
'''  <summary>
''' Notes
''' (1) Decrements the ref count and, if 0, destroys the numa.
''' (2) Always nulls the input ptr.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pna">[in,out] - to be nulled if it exists</param>
Public Shared Sub numaDestroy(
				ByRef pna as Numa)


	Dim pnaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pna) Then pnaPTR = pna.Pointer

	LeptonicaSharp.Natives.numaDestroy( pnaPTR)
	if pnaPTR <> IntPtr.Zero then pna = new Numa(pnaPTR)

End Sub

' SRC\numabasic.c (394, 1)
' numaCopy()
' numaCopy(NUMA *) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''   <returns>copy of numa, or NULL on error</returns>
Public Shared Function numaCopy(
				ByVal na as Numa) as Numa

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaCopy( na.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (423, 1)
' numaClone()
' numaClone(NUMA *) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''   <returns>ptr to same numa, or NULL on error</returns>
Public Shared Function numaClone(
				ByVal na as Numa) as Numa

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaClone( na.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (449, 1)
' numaEmpty()
' numaEmpty(NUMA *) as l_ok
'''  <summary>
''' Notes
''' (1) This does not change the allocation of the array.
''' It just clears the number of stored numbers, so that
''' the array appears to be empty.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function numaEmpty(
				ByVal na as Numa) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaEmpty( na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (473, 1)
' numaAddNumber()
' numaAddNumber(NUMA *, l_float32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="val">[in] - float or int to be added; stored as a float</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaAddNumber(
				ByVal na as Numa, 
				ByVal val as Single) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If IsNothing (val) then Throw New ArgumentNullException  ("val cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaAddNumber( na.Pointer, val)

	Return _Result
End Function

' SRC\numabasic.c (534, 1)
' numaInsertNumber()
' numaInsertNumber(NUMA *, l_int32, l_float32) as l_ok
'''  <summary>
''' Notes
''' (1) This shifts na[i] --GT na[i + 1] for all i GT= index,
''' and then inserts val as na[index].
''' (2) It should not be used repeatedly on large arrays,
''' because the function is O(n).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - location in na to insert new value</param>
'''  <param name="val">[in] - float32 or integer to be added</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaInsertNumber(
				ByVal na as Numa, 
				ByVal index as Integer, 
				ByVal val as Single) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If IsNothing (val) then Throw New ArgumentNullException  ("val cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaInsertNumber( na.Pointer, index, val)

	Return _Result
End Function

' SRC\numabasic.c (573, 1)
' numaRemoveNumber()
' numaRemoveNumber(NUMA *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This shifts na[i] --GT na[i - 1] for all i GT index.
''' (2) It should not be used repeatedly on large arrays,
''' because the function is O(n).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - element to be removed</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaRemoveNumber(
				ByVal na as Numa, 
				ByVal index as Integer) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaRemoveNumber( na.Pointer, index)

	Return _Result
End Function

' SRC\numabasic.c (602, 1)
' numaReplaceNumber()
' numaReplaceNumber(NUMA *, l_int32, l_float32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - element to be replaced</param>
'''  <param name="val">[in] - new value to replace old one</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaReplaceNumber(
				ByVal na as Numa, 
				ByVal index as Integer, 
				ByVal val as Single) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If IsNothing (val) then Throw New ArgumentNullException  ("val cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaReplaceNumber( na.Pointer, index, val)

	Return _Result
End Function

' SRC\numabasic.c (631, 1)
' numaGetCount()
' numaGetCount(NUMA *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''   <returns>count, or 0 if no numbers or on error</returns>
Public Shared Function numaGetCount(
				ByVal na as Numa) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaGetCount( na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (658, 1)
' numaSetCount()
' numaSetCount(NUMA *, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) If newcount LT= na-GTnalloc, this resets na-GTn.
''' Using newcount = 0 is equivalent to numaEmpty().
''' (2) If newcount GT na-GTnalloc, this causes a realloc
''' to a size na-GTnalloc = newcount.
''' (3) All the previously unused values in na are set to 0.0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="newcount">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaSetCount(
				ByVal na as Numa, 
				ByVal newcount as Integer) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaSetCount( na.Pointer, newcount)

	Return _Result
End Function

' SRC\numabasic.c (692, 1)
' numaGetFValue()
' numaGetFValue(NUMA *, l_int32, l_float32 *) as l_ok
'''  <summary>
''' Notes
''' (1) Caller may need to check the function return value to
''' decide if a 0.0 in the returned ival is valid.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - into numa</param>
'''  <param name="pval">[out] - float value; 0.0 on error</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function numaGetFValue(
				ByVal na as Numa, 
				ByVal index as Integer, 
				ByRef pval as Single()) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaGetFValue( na.Pointer, index, pval)

	Return _Result
End Function

' SRC\numabasic.c (727, 1)
' numaGetIValue()
' numaGetIValue(NUMA *, l_int32, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) Caller may need to check the function return value to
''' decide if a 0 in the returned ival is valid.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - into numa</param>
'''  <param name="pival">[out] - integer value; 0 on error</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function numaGetIValue(
				ByVal na as Numa, 
				ByVal index as Integer, 
				ByRef pival as Integer) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaGetIValue( na.Pointer, index, pival)

	Return _Result
End Function

' SRC\numabasic.c (759, 1)
' numaSetValue()
' numaSetValue(NUMA *, l_int32, l_float32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - to element to be set</param>
'''  <param name="val">[in] - to set element</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function numaSetValue(
				ByVal na as Numa, 
				ByVal index as Integer, 
				ByVal val as Single) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If IsNothing (val) then Throw New ArgumentNullException  ("val cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaSetValue( na.Pointer, index, val)

	Return _Result
End Function

' SRC\numabasic.c (784, 1)
' numaShiftValue()
' numaShiftValue(NUMA *, l_int32, l_float32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="index">[in] - to element to change relative to the current value</param>
'''  <param name="diff">[in] - increment if diff GT 0 or decrement if diff LT 0</param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function numaShiftValue(
				ByVal na as Numa, 
				ByVal index as Integer, 
				ByVal diff as Single) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If IsNothing (diff) then Throw New ArgumentNullException  ("diff cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaShiftValue( na.Pointer, index, diff)

	Return _Result
End Function

' SRC\numabasic.c (820, 1)
' numaGetIArray()
' numaGetIArray(NUMA *) as l_int32 *
'''  <summary>
''' Notes
''' (1) A copy of the array is always made, because we need to
''' generate an integer array from the bare float array.
''' The caller is responsible for freeing the array.
''' (2) The array size is determined by the number of stored numbers,
''' not by the size of the allocated array in the Numa.
''' (3) This function is provided to simplify calculations
''' using the bare internal array, rather than continually
''' calling accessors on the numa.  It is typically used
''' on an array of size 256.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''   <returns>a copy of the bare internal array, integerized by rounding, or NULL on error</returns>
Public Shared Function numaGetIArray(
				ByVal na as Numa) as Integer()

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer() = LeptonicaSharp.Natives.numaGetIArray( na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (865, 1)
' numaGetFArray()
' numaGetFArray(NUMA *, l_int32) as l_float32 *
'''  <summary>
''' Notes
''' (1) If copyflag == L_COPY, it makes a copy which the caller
''' is responsible for freeing.  Otherwise, it operates
''' directly on the bare array of the numa.
''' (2) Very important for L_NOCOPY, any writes to the array
''' will be in the numa.  Do not write beyond the size of
''' the count field, because it will not be accessible
''' from the numa!  If necessary, be sure to set the count
''' field to a larger number (such as the alloc size)
''' BEFORE calling this function.  Creating with numaMakeConstant()
''' is another way to insure full initialization.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="copyflag">[in] - L_NOCOPY or L_COPY</param>
'''   <returns>either the bare internal array or a copy of it, or NULL on error</returns>
Public Shared Function numaGetFArray(
				ByVal na as Numa, 
				ByVal copyflag as Enumerations.L_access_storage) as Single()

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Single() = LeptonicaSharp.Natives.numaGetFArray( na.Pointer, copyflag)

	Return _Result
End Function

' SRC\numabasic.c (897, 1)
' numaGetRefCount()
' numaGetRefcount(NUMA *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''   <returns>refcount, or UNDEF on error</returns>
Public Shared Function numaGetRefcount(
				ByVal na as Numa) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaGetRefcount( na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (915, 1)
' numaChangeRefCount()
' numaChangeRefcount(NUMA *, l_int32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="delta">[in] - change to be applied</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaChangeRefcount(
				ByVal na as Numa, 
				ByVal delta as Integer) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaChangeRefcount( na.Pointer, delta)

	Return _Result
End Function

' SRC\numabasic.c (936, 1)
' numaGetParameters()
' numaGetParameters(NUMA *, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="pstartx">[out][optional] - startx</param>
'''  <param name="pdelx">[out][optional] - delx</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaGetParameters(
				ByVal na as Numa, 
				ByRef pstartx as Single(), 
				ByRef pdelx as Single()) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaGetParameters( na.Pointer, pstartx, pdelx)

	Return _Result
End Function

' SRC\numabasic.c (966, 1)
' numaSetParameters()
' numaSetParameters(NUMA *, l_float32, l_float32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="startx">[in] - x value corresponding to na[0]</param>
'''  <param name="delx">[in] - difference in x values for the situation where the elements of na correspond to the evaulation of a function at equal intervals of size %delx</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaSetParameters(
				ByVal na as Numa, 
				ByVal startx as Single, 
				ByVal delx as Single) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If IsNothing (startx) then Throw New ArgumentNullException  ("startx cannot be Nothing")
	If IsNothing (delx) then Throw New ArgumentNullException  ("delx cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaSetParameters( na.Pointer, startx, delx)

	Return _Result
End Function

' SRC\numabasic.c (989, 1)
' numaCopyParameters()
' numaCopyParameters(NUMA *, NUMA *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="nad">[in] - destination Numa</param>
'''  <param name="nas">[in] - source Numa</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaCopyParameters(
				ByVal nad as Numa, 
				ByVal nas as Numa) as Integer

	If IsNothing (nad) then Throw New ArgumentNullException  ("nad cannot be Nothing")
	If IsNothing (nas) then Throw New ArgumentNullException  ("nas cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaCopyParameters( nad.Pointer, nas.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1027, 1)
' numaConvertToSarray()
' numaConvertToSarray(NUMA *, l_int32, l_int32, l_int32, l_int32) as SARRAY *
'''  <summary>
''' Notes
''' (1) For integer conversion, size2 is ignored.
''' For float conversion, addzeroes is ignored.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="na">[in] - </param>
'''  <param name="size1">[in] - size of conversion field</param>
'''  <param name="size2">[in] - for float conversion size of field to the right of the decimal point</param>
'''  <param name="addzeros">[in] - for integer conversion to add lead zeros</param>
'''  <param name="type">[in] - L_INTEGER_VALUE, L_FLOAT_VALUE</param>
'''   <returns>a sarray of the float values converted to strings representing either integer or float values; or NULL on error.</returns>
Public Shared Function numaConvertToSarray(
				ByVal na as Numa, 
				ByVal size1 as Integer, 
				ByVal size2 as Integer, 
				ByVal addzeros as Integer, 
				ByVal type as Enumerations.L_VALUE) as Sarray

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaConvertToSarray( na.Pointer, size1, size2, addzeros, type)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\numabasic.c (1083, 1)
' numaRead()
' numaRead(const char *) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''   <returns>na, or NULL on error</returns>
Public Shared Function numaRead(
				ByVal filename as String) as Numa

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If My.Computer.Filesystem.Fileexists (filename) = false then Throw New ArgumentException ("File is missing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaRead( filename)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (1110, 1)
' numaReadStream()
' numaReadStream(FILE *) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''   <returns>numa, or NULL on error</returns>
Public Shared Function numaReadStream(
				ByVal fp as FILE) as Numa

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaReadStream( fp.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (1156, 1)
' numaReadMem()
' numaReadMem(const l_uint8 *, size_t) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="data">[in] - numa serialization; in ascii</param>
'''  <param name="size">[in] - of data; can use strlen to get it</param>
'''   <returns>na, or NULL on error</returns>
Public Shared Function numaReadMem(
				ByVal data as Byte(), 
				ByVal size as UInteger) as Numa

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaReadMem( data, size)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (1193, 1)
' numaWriteDebug()
' numaWriteDebug(const char *, NUMA *) as l_ok
'''  <summary>
''' Notes
''' (1) Debug version, intended for use in the library when writing
''' to files in a temp directory with names that are compiled in.
''' This is used instead of numaWrite() for all such library calls.
''' (2) The global variable LeptDebugOK defaults to 0, and can be set
''' or cleared by the function setLeptDebugOK().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''  <param name="na">[in] - </param>
'''   <returns>0 if OK; 1 on error</returns>
Public Shared Function numaWriteDebug(
				ByVal filename as String, 
				ByVal na as Numa) as Integer

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If My.Computer.Filesystem.Fileexists (filename) = false then Throw New ArgumentException ("File is missing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaWriteDebug( filename, na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1214, 1)
' numaWrite()
' numaWrite(const char *, NUMA *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''  <param name="na">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaWrite(
				ByVal filename as String, 
				ByVal na as Numa) as Integer

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")
	If My.Computer.Filesystem.Fileexists (filename) = false then Throw New ArgumentException ("File is missing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaWrite( filename, na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1245, 1)
' numaWriteStream()
' numaWriteStream(FILE *, NUMA *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''  <param name="na">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaWriteStream(
				ByVal fp as FILE, 
				ByVal na as Numa) as Integer

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaWriteStream( fp.Pointer, na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1288, 1)
' numaWriteMem()
' numaWriteMem(l_uint8 **, size_t *, NUMA *) as l_ok
'''  <summary>
''' Notes
''' (1) Serializes a numa in memory and puts the result in a buffer.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pdata">[out] - data of serialized numa; ascii</param>
'''  <param name="psize">[out] - size of returned data</param>
'''  <param name="na">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaWriteMem(
				ByRef pdata as Byte(), 
				ByRef psize as UInteger, 
				ByVal na as Numa) as Integer

	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")

	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.numaWriteMem( pdataPTR, psize, na.Pointer)
	ReDim pdata(IIf(psize > 0, psize, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

' SRC\numabasic.c (1339, 1)
' numaaCreate()
' numaaCreate(l_int32) as NUMAA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="n">[in] - size of numa ptr array to be alloc'd 0 for default</param>
'''   <returns>naa, or NULL on error</returns>
Public Shared Function numaaCreate(
				ByVal n as Integer) as Numaa



	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaCreate( n)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numaa(_Result)
End Function

' SRC\numabasic.c (1377, 1)
' numaaCreateFull()
' numaaCreateFull(l_int32, l_int32) as NUMAA *
'''  <summary>
''' Notes
''' (1) This allocates numaa and fills the array with allocated numas.
''' In use, after calling this function, use
''' numaaAddNumber(naa, index, val);
''' to add val to the index-th numa in naa.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="nptr">[in] - size of numa ptr array to be alloc'd</param>
'''  <param name="n">[in] - size of individual numa arrays to be alloc'd 0 for default</param>
'''   <returns>naa, or NULL on error</returns>
Public Shared Function numaaCreateFull(
				ByVal nptr as Integer, 
				ByVal n as Integer) as Numaa



	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaCreateFull( nptr, n)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numaa(_Result)
End Function

' SRC\numabasic.c (1408, 1)
' numaaTruncate()
' numaaTruncate(NUMAA *) as l_ok
'''  <summary>
''' Notes
''' (1) This identifies the largest index containing a numa that
''' has any numbers within it, destroys all numa beyond that
''' index, and resets the count.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaTruncate(
				ByVal naa as Numaa) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaTruncate( naa.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1442, 1)
' numaaDestroy()
' numaaDestroy(NUMAA **) as void
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pnaa">[in,out] - to be nulled if it exists</param>
Public Shared Sub numaaDestroy(
				ByRef pnaa as Numaa)


	Dim pnaaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnaa) Then pnaaPTR = pnaa.Pointer

	LeptonicaSharp.Natives.numaaDestroy( pnaaPTR)
	if pnaaPTR <> IntPtr.Zero then pnaa = new Numaa(pnaaPTR)

End Sub

' SRC\numabasic.c (1480, 1)
' numaaAddNuma()
' numaaAddNuma(NUMAA *, NUMA *, l_int32) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''  <param name="na">[in] - to be added</param>
'''  <param name="copyflag">[in] - L_INSERT, L_COPY, L_CLONE</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaAddNuma(
				ByVal naa as Numaa, 
				ByVal na as Numa, 
				ByVal copyflag as Enumerations.L_access_storage) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")
	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaAddNuma( naa.Pointer, na.Pointer, copyflag)

	Return _Result
End Function

' SRC\numabasic.c (1548, 1)
' numaaGetCount()
' numaaGetCount(NUMAA *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''   <returns>count number of numa, or 0 if no numa or on error</returns>
Public Shared Function numaaGetCount(
				ByVal naa as Numaa) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaGetCount( naa.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1566, 1)
' numaaGetNumaCount()
' numaaGetNumaCount(NUMAA *, l_int32) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''  <param name="index">[in] - of numa in naa</param>
'''   <returns>count of numbers in the referenced numa, or 0 on error.</returns>
Public Shared Function numaaGetNumaCount(
				ByVal naa as Numaa, 
				ByVal index as Integer) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaGetNumaCount( naa.Pointer, index)

	Return _Result
End Function

' SRC\numabasic.c (1587, 1)
' numaaGetNumberCount()
' numaaGetNumberCount(NUMAA *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''   <returns>count total number of numbers in the numaa, or 0 if no numbers or on error</returns>
Public Shared Function numaaGetNumberCount(
				ByVal naa as Numaa) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaGetNumberCount( naa.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1636, 1)
' numaaGetPtrArray()
' numaaGetPtrArray(NUMAA *) as NUMA **
'''  <summary>
''' Notes
''' (1) This function is convenient for doing direct manipulation on
''' a fixed size array of Numas.  To do this, it sets the count
''' to the full size of the allocated array of Numa ptrs.
''' The originating Numaa owns this array DO NOT free it!
''' (2) Intended usage
''' Numaa naa = numaaCreate(n);
''' Numa array = numaaGetPtrArray(naa);
''' ...  [manipulate Numas directly on the array]
''' numaaDestroy(naa);
''' (3) Cautions
''' ~ Do not free this array; it is owned by tne Numaa.
''' ~ Do not call any functions on the Numaa, other than
''' numaaDestroy() when you're finished with the array.
''' Adding a Numa will force a resize, destroying the ptr array.
''' ~ Do not address the array outside its allocated size.
''' With the bare array, there are no protections.  If the
''' allocated size is n, array[n] is an error.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''   <returns>the internal array of ptrs to Numa, or NULL on error</returns>
Public Shared Function numaaGetPtrArray(
				ByVal naa as Numaa) as Numa

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaGetPtrArray( naa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing
Dim B as new Numa(_Result)

	Return B
End Function

' SRC\numabasic.c (1657, 1)
' numaaGetNuma()
' numaaGetNuma(NUMAA *, l_int32, l_int32) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''  <param name="index">[in] - to the index-th numa</param>
'''  <param name="accessflag">[in] - L_COPY or L_CLONE</param>
'''   <returns>numa, or NULL on error</returns>
Public Shared Function numaaGetNuma(
				ByVal naa as Numaa, 
				ByVal index as Integer, 
				ByVal accessflag as Enumerations.L_access_storage) as Numa

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaGetNuma( naa.Pointer, index, accessflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\numabasic.c (1693, 1)
' numaaReplaceNuma()
' numaaReplaceNuma(NUMAA *, l_int32, NUMA *) as l_ok
'''  <summary>
''' Notes
''' (1) Any existing numa is destroyed, and the input one
''' is inserted in its place.
''' (2) If the index is invalid, return 1 (error)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''  <param name="index">[in] - to the index-th numa</param>
'''  <param name="na">[in] - insert and replace any existing one</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaReplaceNuma(
				ByVal naa as Numaa, 
				ByVal index as Integer, 
				ByVal na as Numa) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")
	If IsNothing (na) then Throw New ArgumentNullException  ("na cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaReplaceNuma( naa.Pointer, index, na.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1726, 1)
' numaaGetValue()
' numaaGetValue(NUMAA *, l_int32, l_int32, l_float32 *, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''  <param name="i">[in] - index of numa within numaa</param>
'''  <param name="j">[in] - index into numa</param>
'''  <param name="pfval">[out][optional] - float value</param>
'''  <param name="pival">[out][optional] - int value</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaGetValue(
				ByVal naa as Numaa, 
				ByVal i as Integer, 
				ByVal j as Integer, 
				ByRef pfval as Single(), 
				ByRef pival as Integer) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaGetValue( naa.Pointer, i, j, pfval, pival)

	Return _Result
End Function

' SRC\numabasic.c (1769, 1)
' numaaAddNumber()
' numaaAddNumber(NUMAA *, l_int32, l_float32) as l_ok
'''  <summary>
''' Notes
''' (1) Adds to an existing numa only.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="naa">[in] - </param>
'''  <param name="index">[in] - of numa within numaa</param>
'''  <param name="val">[in] - float or int to be added; stored as a float</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaAddNumber(
				ByVal naa as Numaa, 
				ByVal index as Integer, 
				ByVal val as Single) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")
	If IsNothing (val) then Throw New ArgumentNullException  ("val cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaAddNumber( naa.Pointer, index, val)

	Return _Result
End Function

' SRC\numabasic.c (1801, 1)
' numaaRead()
' numaaRead(const char *) as NUMAA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''   <returns>naa, or NULL on error</returns>
Public Shared Function numaaRead(
				ByVal filename as String) as Numaa

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If My.Computer.Filesystem.Fileexists (filename) = false then Throw New ArgumentException ("File is missing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaRead( filename)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numaa(_Result)
End Function

' SRC\numabasic.c (1828, 1)
' numaaReadStream()
' numaaReadStream(FILE *) as NUMAA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''   <returns>naa, or NULL on error</returns>
Public Shared Function numaaReadStream(
				ByVal fp as FILE) as Numaa

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaReadStream( fp.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numaa(_Result)
End Function

' SRC\numabasic.c (1873, 1)
' numaaReadMem()
' numaaReadMem(const l_uint8 *, size_t) as NUMAA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="data">[in] - numaa serialization; in ascii</param>
'''  <param name="size">[in] - of data; can use strlen to get it</param>
'''   <returns>naa, or NULL on error</returns>
Public Shared Function numaaReadMem(
				ByVal data as Byte(), 
				ByVal size as UInteger) as Numaa

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.numaaReadMem( data, size)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numaa(_Result)
End Function

' SRC\numabasic.c (1900, 1)
' numaaWrite()
' numaaWrite(const char *, NUMAA *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''  <param name="naa">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaWrite(
				ByVal filename as String, 
				ByVal naa as Numaa) as Integer

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")
	If My.Computer.Filesystem.Fileexists (filename) = false then Throw New ArgumentException ("File is missing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaWrite( filename, naa.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1931, 1)
' numaaWriteStream()
' numaaWriteStream(FILE *, NUMAA *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fp">[in] - file stream</param>
'''  <param name="naa">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaWriteStream(
				ByVal fp as FILE, 
				ByVal naa as Numaa) as Integer

	If IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.numaaWriteStream( fp.Pointer, naa.Pointer)

	Return _Result
End Function

' SRC\numabasic.c (1973, 1)
' numaaWriteMem()
' numaaWriteMem(l_uint8 **, size_t *, NUMAA *) as l_ok
'''  <summary>
''' Notes
''' (1) Serializes a numaa in memory and puts the result in a buffer.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pdata">[out] - data of serialized numaa; ascii</param>
'''  <param name="psize">[out] - size of returned data</param>
'''  <param name="naa">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function numaaWriteMem(
				ByRef pdata as Byte(), 
				ByRef psize as UInteger, 
				ByVal naa as Numaa) as Integer

	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")

	Dim pdataPTR As IntPtr = IntPtr.Zero

	Dim _Result as Integer = LeptonicaSharp.Natives.numaaWriteMem( pdataPTR, psize, naa.Pointer)
	ReDim pdata(IIf(psize > 0, psize, 1) - 1) : If pdataPTR <> IntPtr.Zero Then Marshal.Copy(pdataPTR, pdata, 0, pdata.count)

	Return _Result
End Function

End Class