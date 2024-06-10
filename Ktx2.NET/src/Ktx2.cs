using System.Runtime.InteropServices;

namespace Ktx
{
    public static unsafe partial class Ktx2
    {
        private const string LIBRARY_NAME_KTX = "ktx";

        public enum ErrorCode : int
        {
            Success = 0,
            FileDataError,
            FileIsPipe,
            FileOpenFailed,
            FileOverflow,
            FileReadError,
            FileSeekError,
            FileUnexpectedEof,
            FileWriteError,
            GlError,
            InvalidOperation,
            InvalidValue,
            NotFound,
            OutOfMemory,
            TranscodeFailed,
            UnknownFileFormat,
            UnsupportedTextureType,
            UnsupportedFeature,
            LibraryNotLinked,
            DecompressLengthError,
            DecompressChecksumError,
            ErrorMaxEnum
        }

        public enum OrientationX : int
        {
            OrientXLeft = 'l',
            OrientXRight = 'r',
        }

        public enum ClassId : int
        {
            Texture1 = 1,
            Texture2 = 2,
        }

        public struct Orientation
        {
            public OrientationX X;
            public OrientationX Y;
            public OrientationX Z;
        };

        public enum VkFormat : int
        {
            Undefined = 0,
            R4G4UnormPack8 = 1,
            R4G4B4A4UnormPack16 = 2,
            B4G4R4A4UnormPack16 = 3,
            R5G6B5UnormPack16 = 4,
            B5G6R5UnormPack16 = 5,
            R5G5B5A1UnormPack16 = 6,
            B5G5R5A1UnormPack16 = 7,
            A1R5G5B5UnormPack16 = 8,
            R8Unorm = 9,
            R8Snorm = 10,
            R8Uscaled = 11,
            R8Sscaled = 12,
            R8Uint = 13,
            R8Sint = 14,
            R8Srgb = 15,
            R8G8Unorm = 16,
            R8G8Snorm = 17,
            R8G8Uscaled = 18,
            R8G8Sscaled = 19,
            R8G8Uint = 20,
            R8G8Sint = 21,
            R8G8Srgb = 22,
            R8G8B8Unorm = 23,
            R8G8B8Snorm = 24,
            R8G8B8Uscaled = 25,
            R8G8B8Sscaled = 26,
            R8G8B8Uint = 27,
            R8G8B8Sint = 28,
            R8G8B8Srgb = 29,
            B8G8R8Unorm = 30,
            B8G8R8Snorm = 31,
            B8G8R8Uscaled = 32,
            B8G8R8Sscaled = 33,
            B8G8R8Uint = 34,
            B8G8R8Sint = 35,
            B8G8R8Srgb = 36,
            R8G8B8A8Unorm = 37,
            R8G8B8A8Snorm = 38,
            R8G8B8A8Uscaled = 39,
            R8G8B8A8Sscaled = 40,
            R8G8B8A8Uint = 41,
            R8G8B8A8Sint = 42,
            R8G8B8A8Srgb = 43,
            B8G8R8A8Unorm = 44,
            B8G8R8A8Snorm = 45,
            B8G8R8A8Uscaled = 46,
            B8G8R8A8Sscaled = 47,
            B8G8R8A8Uint = 48,
            B8G8R8A8Sint = 49,
            B8G8R8A8Srgb = 50,
            A8B8G8R8UnormPack32 = 51,
            A8B8G8R8SnormPack32 = 52,
            A8B8G8R8UscaledPack32 = 53,
            A8B8G8R8SscaledPack32 = 54,
            A8B8G8R8UintPack32 = 55,
            A8B8G8R8SintPack32 = 56,
            A8B8G8R8SrgbPack32 = 57,
            A2R10G10B10UnormPack32 = 58,
            A2R10G10B10SnormPack32 = 59,
            A2R10G10B10UscaledPack32 = 60,
            A2R10G10B10SscaledPack32 = 61,
            A2R10G10B10UintPack32 = 62,
            A2R10G10B10SintPack32 = 63,
            A2B10G10R10UnormPack32 = 64,
            A2B10G10R10SnormPack32 = 65,
            A2B10G10R10UscaledPack32 = 66,
            A2B10G10R10SscaledPack32 = 67,
            A2B10G10R10UintPack32 = 68,
            A2B10G10R10SintPack32 = 69,
            R16Unorm = 70,
            R16Snorm = 71,
            R16Uscaled = 72,
            R16Sscaled = 73,
            R16Uint = 74,
            R16Sint = 75,
            R16Sfloat = 76,
            R16G16Unorm = 77,
            R16G16Snorm = 78,
            R16G16Uscaled = 79,
            R16G16Sscaled = 80,
            R16G16Uint = 81,
            R16G16Sint = 82,
            R16G16Sfloat = 83,
            R16G16B16Unorm = 84,
            R16G16B16Snorm = 85,
            R16G16B16Uscaled = 86,
            R16G16B16Sscaled = 87,
            R16G16B16Uint = 88,
            R16G16B16Sint = 89,
            R16G16B16Sfloat = 90,
            R16G16B16A16Unorm = 91,
            R16G16B16A16Snorm = 92,
            R16G16B16A16Uscaled = 93,
            R16G16B16A16Sscaled = 94,
            R16G16B16A16Uint = 95,
            R16G16B16A16Sint = 96,
            R16G16B16A16Sfloat = 97,
            R32Uint = 98,
            R32Sint = 99,
            R32Sfloat = 100,
            R32G32Uint = 101,
            R32G32Sint = 102,
            R32G32Sfloat = 103,
            R32G32B32Uint = 104,
            R32G32B32Sint = 105,
            R32G32B32Sfloat = 106,
            R32G32B32A32Uint = 107,
            R32G32B32A32Sint = 108,
            R32G32B32A32Sfloat = 109,
            R64Uint = 110,
            R64Sint = 111,
            R64Sfloat = 112,
            R64G64Uint = 113,
            R64G64Sint = 114,
            R64G64Sfloat = 115,
            R64G64B64Uint = 116,
            R64G64B64Sint = 117,
            R64G64B64Sfloat = 118,
            R64G64B64A64Uint = 119,
            R64G64B64A64Sint = 120,
            R64G64B64A64Sfloat = 121,
            B10G11R11UfloatPack32 = 122,
            E5B9G9R9UfloatPack32 = 123,
            D16Unorm = 124,
            X8D24UnormPack32 = 125,
            D32Sfloat = 126,
            S8Uint = 127,
            D16UnormS8Uint = 128,
            D24UnormS8Uint = 129,
            D32SfloatS8Uint = 130,
            Bc1RgbUnormBlock = 131,
            Bc1RgbSrgbBlock = 132,
            Bc1RgbaUnormBlock = 133,
            Bc1RgbaSrgbBlock = 134,
            Bc2UnormBlock = 135,
            Bc2SrgbBlock = 136,
            Bc3UnormBlock = 137,
            Bc3SrgbBlock = 138,
            Bc4UnormBlock = 139,
            Bc4SnormBlock = 140,
            Bc5UnormBlock = 141,
            Bc5SnormBlock = 142,
            Bc6HUfloatBlock = 143,
            Bc6HSfloatBlock = 144,
            Bc7UnormBlock = 145,
            Bc7SrgbBlock = 146,
            Etc2R8G8B8UnormBlock = 147,
            Etc2R8G8B8SrgbBlock = 148,
            Etc2R8G8B8A1UnormBlock = 149,
            Etc2R8G8B8A1SrgbBlock = 150,
            Etc2R8G8B8A8UnormBlock = 151,
            Etc2R8G8B8A8SrgbBlock = 152,
            EacR11UnormBlock = 153,
            EacR11SnormBlock = 154,
            EacR11G11UnormBlock = 155,
            EacR11G11SnormBlock = 156,
            Astc4X4UnormBlock = 157,
            Astc4X4SrgbBlock = 158,
            Astc5X4UnormBlock = 159,
            Astc5X4SrgbBlock = 160,
            Astc5X5UnormBlock = 161,
            Astc5X5SrgbBlock = 162,
            Astc6X5UnormBlock = 163,
            Astc6X5SrgbBlock = 164,
            Astc6X6UnormBlock = 165,
            Astc6X6SrgbBlock = 166,
            Astc8X5UnormBlock = 167,
            Astc8X5SrgbBlock = 168,
            Astc8X6UnormBlock = 169,
            Astc8X6SrgbBlock = 170,
            Astc8X8UnormBlock = 171,
            Astc8X8SrgbBlock = 172,
            Astc10X5UnormBlock = 173,
            Astc10X5SrgbBlock = 174,
            Astc10X6UnormBlock = 175,
            Astc10X6SrgbBlock = 176,
            Astc10X8UnormBlock = 177,
            Astc10X8SrgbBlock = 178,
            Astc10X10UnormBlock = 179,
            Astc10X10SrgbBlock = 180,
            Astc12X10UnormBlock = 181,
            Astc12X10SrgbBlock = 182,
            Astc12X12UnormBlock = 183,
            Astc12X12SrgbBlock = 184,
            G8B8G8R8422Unorm = 1000156000,
            B8G8R8G8422Unorm = 1000156001,
            G8B8R83Plane420Unorm = 1000156002,
            G8B8R82Plane420Unorm = 1000156003,
            G8B8R83Plane422Unorm = 1000156004,
            G8B8R82Plane422Unorm = 1000156005,
            G8B8R83Plane444Unorm = 1000156006,
            R10X6UnormPack16 = 1000156007,
            R10X6G10X6Unorm2Pack16 = 1000156008,
            R10X6G10X6B10X6A10X6Unorm4Pack16 = 1000156009,
            G10X6B10X6G10X6R10X6422Unorm4Pack16 = 1000156010,
            B10X6G10X6R10X6G10X6422Unorm4Pack16 = 1000156011,
            G10X6B10X6R10X63Plane420Unorm3Pack16 = 1000156012,
            G10X6B10X6R10X62Plane420Unorm3Pack16 = 1000156013,
            G10X6B10X6R10X63Plane422Unorm3Pack16 = 1000156014,
            G10X6B10X6R10X62Plane422Unorm3Pack16 = 1000156015,
            G10X6B10X6R10X63Plane444Unorm3Pack16 = 1000156016,
            R12X4UnormPack16 = 1000156017,
            R12X4G12X4Unorm2Pack16 = 1000156018,
            R12X4G12X4B12X4A12X4Unorm4Pack16 = 1000156019,
            G12X4B12X4G12X4R12X4422Unorm4Pack16 = 1000156020,
            B12X4G12X4R12X4G12X4422Unorm4Pack16 = 1000156021,
            G12X4B12X4R12X43Plane420Unorm3Pack16 = 1000156022,
            G12X4B12X4R12X42Plane420Unorm3Pack16 = 1000156023,
            G12X4B12X4R12X43Plane422Unorm3Pack16 = 1000156024,
            G12X4B12X4R12X42Plane422Unorm3Pack16 = 1000156025,
            G12X4B12X4R12X43Plane444Unorm3Pack16 = 1000156026,
            G16B16G16R16422Unorm = 1000156027,
            B16G16R16G16422Unorm = 1000156028,
            G16B16R163Plane420Unorm = 1000156029,
            G16B16R162Plane420Unorm = 1000156030,
            G16B16R163Plane422Unorm = 1000156031,
            G16B16R162Plane422Unorm = 1000156032,
            G16B16R163Plane444Unorm = 1000156033,
            Pvrtc12BppUnormBlockImg = 1000054000,
            Pvrtc14BppUnormBlockImg = 1000054001,
            Pvrtc22BppUnormBlockImg = 1000054002,
            Pvrtc24BppUnormBlockImg = 1000054003,
            Pvrtc12BppSrgbBlockImg = 1000054004,
            Pvrtc14BppSrgbBlockImg = 1000054005,
            Pvrtc22BppSrgbBlockImg = 1000054006,
            Pvrtc24BppSrgbBlockImg = 1000054007,
            Astc4X4SfloatBlockExt = 1000066000,
            Astc5X4SfloatBlockExt = 1000066001,
            Astc5X5SfloatBlockExt = 1000066002,
            Astc6X5SfloatBlockExt = 1000066003,
            Astc6X6SfloatBlockExt = 1000066004,
            Astc8X5SfloatBlockExt = 1000066005,
            Astc8X6SfloatBlockExt = 1000066006,
            Astc8X8SfloatBlockExt = 1000066007,
            Astc10X5SfloatBlockExt = 1000066008,
            Astc10X6SfloatBlockExt = 1000066009,
            Astc10X8SfloatBlockExt = 1000066010,
            Astc10X10SfloatBlockExt = 1000066011,
            Astc12X10SfloatBlockExt = 1000066012,
            Astc12X12SfloatBlockExt = 1000066013,
            Astc3X3X3UnormBlockExt = 1000288000,
            Astc3X3X3SrgbBlockExt = 1000288001,
            Astc3X3X3SfloatBlockExt = 1000288002,
            Astc4X3X3UnormBlockExt = 1000288003,
            Astc4X3X3SrgbBlockExt = 1000288004,
            Astc4X3X3SfloatBlockExt = 1000288005,
            Astc4X4X3UnormBlockExt = 1000288006,
            Astc4X4X3SrgbBlockExt = 1000288007,
            Astc4X4X3SfloatBlockExt = 1000288008,
            Astc4X4X4UnormBlockExt = 1000288009,
            Astc4X4X4SrgbBlockExt = 1000288010,
            Astc4X4X4SfloatBlockExt = 1000288011,
            Astc5X4X4UnormBlockExt = 1000288012,
            Astc5X4X4SrgbBlockExt = 1000288013,
            Astc5X4X4SfloatBlockExt = 1000288014,
            Astc5X5X4UnormBlockExt = 1000288015,
            Astc5X5X4SrgbBlockExt = 1000288016,
            Astc5X5X4SfloatBlockExt = 1000288017,
            Astc5X5X5UnormBlockExt = 1000288018,
            Astc5X5X5SrgbBlockExt = 1000288019,
            Astc5X5X5SfloatBlockExt = 1000288020,
            Astc6X5X5UnormBlockExt = 1000288021,
            Astc6X5X5SrgbBlockExt = 1000288022,
            Astc6X5X5SfloatBlockExt = 1000288023,
            Astc6X6X5UnormBlockExt = 1000288024,
            Astc6X6X5SrgbBlockExt = 1000288025,
            Astc6X6X5SfloatBlockExt = 1000288026,
            Astc6X6X6UnormBlockExt = 1000288027,
            Astc6X6X6SrgbBlockExt = 1000288028,
            Astc6X6X6SfloatBlockExt = 1000288029,
            A4R4G4B4UnormPack16Ext = 1000340000,
            A4B4G4R4UnormPack16Ext = 1000340001,
            MaxEnum = 0x7FFFFFFF
        }

        public enum TranscodeFormat : int
        {
            // Compressed formats

            // ETC1-2
            Etc1Rgb = 0, // Opaque only, returns RGB or alpha data if cDecodeFlagsTranscodeAlphaDataToOpaqueFormats flag is specified
            Etc2Rgba = 1, // Opaque+alpha, ETC2_EAC_A8 block followed by a ETC1 block, alpha channel will be opaque for opaque .basis files

            // BC1-5, BC7 (desktop, some mobile devices)
            Bc1Rgb = 2, // Opaque only, no punchthrough alpha support yet, transcodes alpha slice if cDecodeFlagsTranscodeAlphaDataToOpaqueFormats flag is specified
            Bc3Rgba = 3, // Opaque+alpha, BC4 followed by a BC1 block, alpha channel will be opaque for opaque .basis files
            Bc4R = 4, // Red only, alpha slice is transcoded to output if cDecodeFlagsTranscodeAlphaDataToOpaqueFormats flag is specified
            Bc5Rg = 5, // XY: Two BC4 blocks, X=R and Y=Alpha, .basis file should have alpha data (if not Y will be all 255's)
            Bc7Rgba = 6, // !< RGB or RGBA mode 5 for ETC1S,  modes 1, 2, 3, 4, 5, 6, 7 for UASTC.

            // PVRTC1 4bpp (mobile, PowerVR devices)
            Pvrtc14Rgb = 8, // Opaque only, RGB or alpha if cDecodeFlagsTranscodeAlphaDataToOpaqueFormats flag is specified, nearly lowest quality of any texture format.
            Pvrtc14Rgba = 9, // Opaque+alpha, most useful for simple opacity maps. If .basis file doens't have alpha PVRTC1_4_RGB will be used instead. Lowest quality of any supported texture format.

            // ASTC (mobile, Intel devices, hopefully all desktop GPU's one day)
            Astc4X4Rgba = 10, // Opaque+alpha, ASTC 4x4, alpha channel will be opaque for opaque .basis files. Transcoder uses RGB/RGBA/L/LA modes, void extent, and up to two ([0,47] and [0,255]) endpoint precisions.

            // ATC (mobile, Adreno devices, this is a niche format)
            AtcRgb = 11, // Opaque, RGB or alpha if cDecodeFlagsTranscodeAlphaDataToOpaqueFormats flag is specified. ATI ATC (GL_ATC_RGB_AMD)
            AtcRgba = 12, // Opaque+alpha, alpha channel will be opaque for opaque .basis files. ATI ATC (GL_ATC_RGBA_INTERPOLATED_ALPHA_AMD) 

            // FXT1 (desktop, Intel devices, this is a super obscure format)
            Fxt1Rgb = 17, // Opaque only, uses exclusively CC_MIXED blocks. Notable for having a 8x4 block size. GL_3DFX_texture_compression_FXT1 is supported on Intel integrated GPU's (such as HD 630).
                          // Punch-through alpha is relatively easy to support, but full alpha is harder. This format is only here for completeness so opaque-only is fine for now.
                          // See the BASISU_USE_ORIGINAL_3DFX_FXT1_ENCODING macro in basisu_transcoder_internal.h.

            Pvrtc24Rgb = 18,                    // Opaque-only, almost BC1 quality, much faster to transcode and supports arbitrary texture dimensions (unlike PVRTC1 RGB).
            Pvrtc24Rgba = 19,                   // Opaque+alpha, slower to encode than PVRTC2_4_RGB. Premultiplied alpha is highly recommended, otherwise the color channel can leak into the alpha channel on transparent blocks.

            Etc2EacR11 = 20,                    // R only (ETC2 EAC R11 unsigned)
            Etc2EacRg11 = 21,                   // RG only (ETC2 EAC RG11 unsigned), R=opaque.r, G=alpha - for tangent space normal maps

            // Uncompressed (raw pixel) formats
            Rgba32 = 13,                            // 32bpp RGBA image stored in raster (not block) order in memory, R is first byte, A is last byte.
            Rgb565 = 14,                            // 166pp RGB image stored in raster (not block) order in memory, R at bit position 11
            Bgr565 = 15,                            // 16bpp RGB image stored in raster (not block) order in memory, R at bit position 0
            Rgba4444 = 16,                          // 16bpp RGBA image stored in raster (not block) order in memory, R at bit position 12, A at bit position 0
        }

        public enum TranscodeFlagBits
        {
            PvrtcDecodeToNextPow2 = 2,
            TranscodeAlphaDataToOpaqueFormats = 4,
            HighQuality = 32,
        }

        public enum SupercmpScheme : int
        {
            None = 0,
            BasisLZ = 1, 
            ZSTD = 2,
            ZLIB = 3,
            BeginRange = None,
            EndRange = ZLIB,
            BeginVendorRange = 0x10000,
            EnvVendorRange = 0x1ffff,
            BeginReserved = 0x20000,
            SupercompressionBasis = BasisLZ,
            SupercompressionZSTD = ZSTD
        }

        [Flags]
        public enum TextureCreateFlag : int
        {
            NoFlas = 0x00,
            LoadImageDataBit = 0x01,
            RawKeyValueDataBit = 0x02,
            SkipKeyValueDataBit = 0x04,
            CheckGltfBasisUBit = 0x08
        }

        public struct Texture
        {
            public ClassId ClassId;                         
            public IntPtr Vtbl;             
            public IntPtr Vvtbl;           
            public IntPtr _protected;  
            [MarshalAs(UnmanagedType.I1)] public bool IsArray;
            [MarshalAs(UnmanagedType.I1)] public bool IsCubemap;                   
            [MarshalAs(UnmanagedType.I1)] public bool IsCompressed;                
            [MarshalAs(UnmanagedType.I1)] public bool GenerateMipmaps;             
            public uint BaseWidth;                   
            public uint BaseHeight;                  
            public uint BaseDepth;                   
            public uint NumDimensions;               
            public uint NumLevels;                   
            public uint NumLayers;                   
            public uint NumFaces;                    
            public Orientation Orientation;        
            public IntPtr KvDataHead;                  
            public uint KvDataLen;                   
            public byte* PKvData;                      
            public nuint DataSize;                      
            public byte* PData;

            public VkFormat VkFormat;
            public uint* PDfd;
            public SupercmpScheme SupercompressionScheme;
            [MarshalAs(UnmanagedType.I1)] public bool IsVideo;
            public uint Duration;
            public uint Timescale;
            public uint Loopcount;
            private IntPtr _private;
        }

        private struct BDFD
        {
            // https://github.com/BoyBaykiller/KTX-Software/blob/29aeddefd6d02630a3e8bcda7c6202aac4a58c77/lib/texture2.c#L66
            // C# doesn't have bitfields so we just give the struct the correct size here and do the translation in a wrapper.

            private fixed uint data[6];
            private fixed uint samples[6];
        }


        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_CreateFromNamedFile", StringMarshalling = StringMarshalling.Utf8)]
        public static partial ErrorCode CreateFromNamedFile(string filename, TextureCreateFlag textureCreateFlag, out Texture* texture);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_CreateFromMemory")]
        public static partial ErrorCode CreateFromMemory(in byte bytes, nuint size, TextureCreateFlag textureCreateFlag, out Texture* texture);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_WriteToNamedFile", StringMarshalling = StringMarshalling.Utf8)]
        public static partial ErrorCode WriteToNamedFile(Texture* texture, string dstname);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_WriteToMemory")]
        public static partial ErrorCode WriteToMemory(Texture* texture, out byte* pDstBytes, out nuint size);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_TranscodeBasis")]
        public static partial ErrorCode TranscodeBasis(Texture* texture, TranscodeFormat transcodeFormat, TranscodeFlagBits transcodeFlags);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_NeedsTranscoding")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool NeedsTranscoding(Texture* texture);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_GetPremultipliedAlpha")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static partial bool GetPremultipliedAlpha(Texture* texture);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_GetNumComponents")]
        public static partial uint GetNumComponents(Texture* texture);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_GetImageOffset")]
        public static partial ErrorCode GetImageOffset(Texture* texture, uint level, uint layer, uint faceSlice, out nuint offset);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_GetImageSize")]
        public static partial nuint GetImageSize(Texture* texture, uint level);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "ktxTexture2_Destroy")]
        public static partial void Destroy(Texture* texture);

        [LibraryImport(LIBRARY_NAME_KTX, EntryPoint = "vk2dfd")]
        public static partial uint* Vk2Dfd(VkFormat format);
    }
}
