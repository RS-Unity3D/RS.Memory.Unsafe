
namespace RS.MemoryUnsafe
{
   
    using RS.MemoryPinned;
    using RS.MemoryPinned.Model;
    using RS.MemoryUnsafe.Internals;    
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class Unsafe
    {
        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T Add<T>(ref T source,int elementOffset) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* ptr = (T*)PinHandler.Pin(((IntPtr)((long)pinnedStructure.IntPtr + (long)elementOffset * (long)Marshal.SizeOf(typeof(T)))).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
                return ref *ptr;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void* Add<T>(void* source,int elementOffset) where T : struct
        {
            return PinHandler.Pin(((IntPtr)((long)PinHandler.Pin(source).IntPtr + (long)elementOffset * (long)Marshal.SizeOf(typeof(T)))).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T Add<T>(ref T source,IntPtr elementOffset) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* ptr = (T*)PinHandler.Pin(((IntPtr)((long)pinnedStructure.IntPtr + (long)elementOffset * Marshal.SizeOf(typeof(T)))).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
                return ref *ptr;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T AddByteOffset<T>(ref T source,IntPtr byteOffset) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* ptr = (T*)PinHandler.Pin(((IntPtr)((long)pinnedStructure.IntPtr + (long)byteOffset)).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
                return ref *ptr;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static bool AreSame<T>(ref T left,ref T right) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref left))
            {
                using (PinnedStructure<T> pinnedStructure2 = PinHandler.PinAsStructure(ref right))
                {
                    return (long)pinnedStructure.IntPtr == (long)pinnedStructure2.IntPtr;
                }
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static T As<T>(object o) where T : class
        {
            return (T)o;
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref TTo As<TFrom, TTo>(ref TFrom source) where TFrom : struct where TTo : struct
        {
            using (PinnedStructure<TFrom> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                TTo* pointer = (TTo*)pinnedStructure.Pointer;
                return ref *pointer;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void* AsPointer<T>(ref T value) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref value))
            {
                return pinnedStructure.Pointer;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T AsRef<T>(void* source)
        {
            return ref *(T*)source;
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T AsRef<T>(T source) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* pointer = (T*)pinnedStructure.Pointer;
                return ref *pointer;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static IntPtr ByteOffset<T>(ref T origin,ref T target) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure2 = PinHandler.PinAsStructure(ref origin))
            {
                using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref target))
                {
                    return (IntPtr)((long)pinnedStructure.IntPtr - (long)pinnedStructure2.IntPtr);
                }
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void Copy<T>(void* destination,ref T source) where T : struct
        {
            PinHandler.Pin(destination).WriteElementAtIndex(0,source);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void Copy<T>(ref T destination,void* source) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref destination))
            {
                PinnedPointer pinnedPointer = PinHandler.Pin(source);
                pinnedStructure.WriteElementAtIndex(0,pinnedPointer.ReadElementAtIndex<T>(0));
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void CopyBlock(void* destination,void* source,uint byteCount)
        {
            MemCpy((IntPtr)destination,(IntPtr)source,(UIntPtr)byteCount);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static void CopyBlock(ref byte destination,ref byte source,uint byteCount)
        {
            using (PinnedStructure<byte> pinnedStructure2 = PinHandler.PinAsStructure(ref source))
            {
                using (PinnedStructure<byte> pinnedStructure = PinHandler.PinAsStructure(ref destination))
                {
                    MemCpy(pinnedStructure.IntPtr,pinnedStructure2.IntPtr,(UIntPtr)byteCount);
                }
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void CopyBlockUnaligned(void* destination,void* source,uint byteCount)
        {
            MemCpy((IntPtr)destination,(IntPtr)source,(UIntPtr)byteCount);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static void CopyBlockUnaligned(ref byte destination,ref byte source,uint byteCount)
        {
            using (PinnedStructure<byte> pinnedStructure2 = PinHandler.PinAsStructure(ref source))
            {
                using (PinnedStructure<byte> pinnedStructure = PinHandler.PinAsStructure(ref destination))
                {
                    MemCpy(pinnedStructure.IntPtr,pinnedStructure2.IntPtr,(UIntPtr)byteCount);
                }
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void InitBlock(void* startAddress,byte value,uint byteCount)
        {
            MemSet((IntPtr)startAddress,value,byteCount);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static void InitBlock(ref byte startAddress,byte value,uint byteCount)
        {
            using (PinnedStructure<byte> pinnedStructure = PinHandler.PinAsStructure(ref startAddress))
            {
                MemSet(pinnedStructure.IntPtr,value,byteCount);
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void InitBlockUnaligned(void* startAddress,byte value,uint byteCount)
        {
            MemSet((IntPtr)startAddress,value,byteCount);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static void InitBlockUnaligned(ref byte startAddress,byte value,uint byteCount)
        {
            using (PinnedStructure<byte> pinnedStructure = PinHandler.PinAsStructure(ref startAddress))
            {
                MemSet(pinnedStructure.IntPtr,value,byteCount);
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static bool IsAddressGreaterThan<T>(ref T left,ref T right) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref left))
            {
                using (PinnedStructure<T> pinnedStructure2 = PinHandler.PinAsStructure(ref right))
                {
                    return (long)pinnedStructure.IntPtr > (long)pinnedStructure2.IntPtr;
                }
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static bool IsAddressLessThan<T>(ref T left,ref T right) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref left))
            {
                using (PinnedStructure<T> pinnedStructure2 = PinHandler.PinAsStructure(ref right))
                {
                    return (long)pinnedStructure.IntPtr < (long)pinnedStructure2.IntPtr;
                }
            }
        }
        //Todo:windows平台下的msvcrt.dll可加速内存复制和初始化，但其它平台需要兼容
        [DllImport("msvcrt.dll",CallingConvention = CallingConvention.Cdecl,EntryPoint = "memcpy")]
        public static extern IntPtr MemCpy(IntPtr dest,IntPtr src,UIntPtr count);

        [DllImport("msvcrt.dll",CallingConvention = CallingConvention.Cdecl,EntryPoint = "memset")]
        public static extern IntPtr MemSet(IntPtr dest,int c,uint byteCount);

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static T Read<T>(void* source) where T : struct
        {
            return PinHandler.Pin(source).ReadElementAtIndex<T>(0);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static T ReadUnaligned<T>(void* source) where T : struct
        {
            return PinHandler.Pin(source).ReadElementAtIndex<T>(0);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static T ReadUnaligned<T>(ref byte source) where T : struct
        {
            using (PinnedStructure<byte> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                return pinnedStructure.ReadElementAtIndex<T>(0);
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static int SizeOf<T>() where T : struct
        {
            return Marshal.SizeOf(typeof(T));
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T Subtract<T>(ref T source,int elementOffset) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* ptr = (T*)PinHandler.Pin(((IntPtr)((long)pinnedStructure.IntPtr - (long)elementOffset * (long)Marshal.SizeOf(typeof(T)))).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
                return ref *ptr;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void* Subtract<T>(void* source,int elementOffset) where T : struct
        {
            return PinHandler.Pin(((IntPtr)((long)PinHandler.Pin(source).IntPtr - (long)elementOffset * (long)Marshal.SizeOf(typeof(T)))).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T Subtract<T>(ref T source,IntPtr elementOffset) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* ptr = (T*)PinHandler.Pin(((IntPtr)((long)pinnedStructure.IntPtr - (long)elementOffset * Marshal.SizeOf(typeof(T)))).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
                return ref *ptr;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T SubtractByteOffset<T>(ref T source,IntPtr byteOffset) where T : struct
        {
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref source))
            {
                T* ptr = (T*)PinHandler.Pin(((IntPtr)((long)pinnedStructure.IntPtr - (long)byteOffset)).ToPointer()).GetPointerAtIndex<T>(0).ToPointer();
                return ref *ptr;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static ref T Unbox<T>(object box) where T : struct
        {
            T variable = (T)box;
            using (PinnedStructure<T> pinnedStructure = PinHandler.PinAsStructure(ref variable))
            {
                T* pointer = (T*)pinnedStructure.Pointer;
                return ref *pointer;
            }
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void Write<T>(void* destination,T value) where T : struct
        {
            PinHandler.Pin(destination).WriteElementAtIndex(0,value);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public unsafe static void WriteUnaligned<T>(void* destination,T value) where T : struct
        {
            PinHandler.Pin(destination).WriteElementAtIndex(0,value);
        }

        [MethodImpl((MethodImplOptions)256)]
        [NonVersionable]
        public static void WriteUnaligned<T>(ref byte destination,T value) where T : struct
        {
            using (PinnedStructure<byte> pinnedStructure = PinHandler.PinAsStructure(ref destination))
            {
                pinnedStructure.WriteElementAtIndex(0,value);
            }
        }
    }

}
