using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Ktx
{
    public static unsafe partial class Ktx2
    {
        public static class Helper
        {
            public enum DFModel : uint
            {
                /** No interpretation of color channels defined */
                UNSPECIFIED = 0U,
                /** Color primaries (red, green, blue) + alpha, depth and stencil */
                RGBSDA = 1U,
                /** Color differences (Y', Cb, Cr) + alpha, depth and stencil */
                YUVSDA = 2U,
                /** Color differences (Y', I, Q) + alpha, depth and stencil */
                YIQSDA = 3U,
                /** Perceptual color (CIE L*a*b*) + alpha, depth and stencil */
                LABSDA = 4U,
                /** Subtractive colors (cyan, magenta, yellow, black) + alpha */
                CMYKA = 5U,
                /** Non-color coordinate data (X, Y, Z, W) */
                XYZW = 6U,
                /** Hue, saturation, value, hue angle on color circle, plus alpha */
                HSVA_ANG = 7U,
                /** Hue, saturation, lightness, hue angle on color circle, plus alpha */
                HSLA_ANG = 8U,
                /** Hue, saturation, value, hue on color hexagon, plus alpha */
                HSVA_HEX = 9U,
                /** Hue, saturation, lightness, hue on color hexagon, plus alpha */
                HSLA_HEX = 10U,
                /** Lightweight approximate color difference (luma, orange, green) */
                YCGCOA = 11U,
                /** ITU BT.2020 constant luminance YcCbcCrc */
                YCCBCCRC = 12U,
                /** ITU BT.2100 constant intensity ICtCp */
                ICTCP = 13U,
                /** CIE 1931 XYZ color coordinates (X, Y, Z) */
                CIEXYZ = 14U,
                /** CIE 1931 xyY color coordinates (X, Y, Y) */
                CIEXYY = 15U,

                /* Compressed formats start at 128. */
                /* These compressed formats should generally have a single sample,
                   sited at the 0,0 position of the texel block. Where multiple
                   channels are used to distinguish formats, these should be cosited. */
                /* Direct3D (and S3) compressed formats */
                /* Note that premultiplied status is recorded separately */
                /** DXT1 "channels" are RGB (0), Alpha (1)
                    DXT1/BC1 with one channel is opaque
                    DXT1/BC1 with a cosited alpha sample is transparent */
                DXT1A = 128U,
                BC1A = 128U,
                /** DXT2/DXT3/BC2, with explicit 4-bit alpha */
                DXT2 = 129U,
                DXT3 = 129U,
                BC2 = 129U,
                /** DXT4/DXT5/BC3, with interpolated alpha */
                DXT4 = 130U,
                DXT5 = 130U,
                BC3 = 130U,
                /** BC4 - single channel interpolated 8-bit data
                    (The UNORM/SNORM variation is recorded in the channel data) */
                BC4 = 131U,
                /** BC5 - two channel interpolated 8-bit data
                    (The UNORM/SNORM variation is recorded in the channel data) */
                BC5 = 132U,
                /** BC6H - DX11 format for 16-bit float channels */
                BC6H = 133U,
                /** BC7 - DX11 format */
                BC7 = 134U,
                /* Gap left for future desktop expansion */

                /* Mobile compressed formats follow */
                /** A format of ETC1 indicates that the format shall be decodable
                    by an ETC1-compliant decoder and not rely on ETC2 features */
                ETC1 = 160U,
                /** A format of ETC2 is permitted to use ETC2 encodings on top of
                    the baseline ETC1 specification.
                    The ETC2 format has channels "red", "green", "RGB" and "alpha",
                    which should be cosited samples.
                    Punch-through alpha can be distinguished from full alpha by
                    the plane size in bytes required for the texel block */
                ETC2 = 161U,
                /** Adaptive Scalable Texture Compression */
                /** ASTC HDR vs LDR is determined by the float flag in the channel */
                /** ASTC block size can be distinguished by texel block size */
                ASTC = 162U,
                /** ETC1S is a simplified subset of ETC1 */
                ETC1S = 163U,
                /** PowerVR Texture Compression v1 */
                PVRTC = 164U,
                /** PowerVR Texture Compression v2 */
                PVRTC2 = 165U,
                /** UASTC is a transcodable subset of ASTC
                    with additions to support the transcoding. */
                UASTC = 166U,
                /* Proprietary formats (ATITC, etc.) should follow */
                MAX = 0xFFU
            }

            public struct Sample
            {
                public uint BitOffset;
                public uint BitLength;
                public uint ChannelType;
                public uint SamplePosition0;
                public uint SamplePosition1;
                public uint SamplePosition2;
                public uint SamplePosition3;
                public uint Lower;
                public uint Upper;
            }

            public struct DataFormatDescriptor
            {
                public uint VendorId;
                public uint DescriptorType;
                public uint VersionNumber;
                public uint DescriptorBlockSize;
                public DFModel Model;
                public uint Primaries;
                public uint Transfer;
                public uint Flags;
                public uint TexelBlockDimension0;
                public uint TexelBlockDimension1;
                public uint TexelBlockDimension2;
                public uint TexelBlockDimension3;
                public uint BytesPlane0;
                public uint BytesPlane1;
                public uint BytesPlane2;
                public uint BytesPlane3;
                public uint BytesPlane4;
                public uint BytesPlane5;
                public uint BytesPlane6;
                public uint BytesPlane7;
                public SamplesArray_6 Samples;
            }

            public static DataFormatDescriptor GetDataFormatDescriptor(Texture* texture)
            {
                // +1 because https://github.com/BoyBaykiller/KTX-Software/blob/29aeddefd6d02630a3e8bcda7c6202aac4a58c77/lib/basis_encode.cpp#L435
                ref readonly BDFD bdfd = ref Unsafe.AsRef<BDFD>(texture->PDfd + 1);
                return GetDataFormatDescriptor(bdfd);
            }

            public static DataFormatDescriptor GetDataFormatDescriptor(VkFormat vkFormat)
            {
                // +1 because https://github.com/BoyBaykiller/KTX-Software/blob/29aeddefd6d02630a3e8bcda7c6202aac4a58c77/lib/basis_encode.cpp#L435
                uint* dfd = Vk2Dfd(vkFormat);
                ref readonly BDFD bdfd = ref Unsafe.AsRef<BDFD>(dfd + 1);
                DataFormatDescriptor result = GetDataFormatDescriptor(bdfd);

                // Free because https://github.com/BoyBaykiller/KTX-Software/blob/29aeddefd6d02630a3e8bcda7c6202aac4a58c77/external/dfdutils/vk2dfd.c#L23
                NativeMemory.Free(dfd);

                return result;
            }

            private static DataFormatDescriptor GetDataFormatDescriptor(in BDFD bdfd)
            {
                fixed (void* ptrBdfd = &bdfd)
                {
                    BitfieldConverter converter = new BitfieldConverter(ptrBdfd);

                    DataFormatDescriptor dfd = new DataFormatDescriptor();

                    // Format of DFD: https://github.com/BoyBaykiller/KTX-Software/blob/29aeddefd6d02630a3e8bcda7c6202aac4a58c77/lib/texture2.c#L66
                    dfd.VendorId = converter.ReadBits(17);
                    dfd.DescriptorType = converter.ReadBits(15);

                    dfd.VersionNumber = converter.ReadBits(16);
                    dfd.DescriptorBlockSize = converter.ReadBits(16);

                    dfd.Model = (DFModel)converter.ReadBits(8);
                    dfd.Primaries = converter.ReadBits(8);
                    dfd.Transfer = converter.ReadBits(8);
                    dfd.Flags = converter.ReadBits(8);

                    dfd.TexelBlockDimension0 = converter.ReadBits(8);
                    dfd.TexelBlockDimension1 = converter.ReadBits(8);
                    dfd.TexelBlockDimension2 = converter.ReadBits(8);
                    dfd.TexelBlockDimension3 = converter.ReadBits(8);

                    dfd.BytesPlane0 = converter.ReadBits(8);
                    dfd.BytesPlane1 = converter.ReadBits(8);
                    dfd.BytesPlane2 = converter.ReadBits(8);
                    dfd.BytesPlane3 = converter.ReadBits(8);
                    dfd.BytesPlane4 = converter.ReadBits(8);
                    dfd.BytesPlane5 = converter.ReadBits(8);
                    dfd.BytesPlane6 = converter.ReadBits(8);
                    dfd.BytesPlane7 = converter.ReadBits(8);

                    for (int i = 0; i < 6; i++)
                    {
                        dfd.Samples[i].BitOffset = converter.ReadBits(16);
                        dfd.Samples[i].BitLength = converter.ReadBits(8);
                        dfd.Samples[i].ChannelType = converter.ReadBits(8);

                        dfd.Samples[i].SamplePosition0 = converter.ReadBits(8);
                        dfd.Samples[i].SamplePosition1 = converter.ReadBits(8);
                        dfd.Samples[i].SamplePosition2 = converter.ReadBits(8);
                        dfd.Samples[i].SamplePosition3 = converter.ReadBits(8);

                        dfd.Samples[i].Lower = converter.ReadBits(32);
                        dfd.Samples[i].Upper = converter.ReadBits(32);
                    }

                    return dfd;
                }
            }

            [InlineArray(6)]
            public struct SamplesArray_6
            {
                private Sample _sample;
            }

            private class BitfieldConverter
            {
                public uint* Position;
                public int LocalBitsRead;
                public BitfieldConverter(void* ptrToBitfield)
                {
                    Position = (uint*)ptrToBitfield;
                }

                public uint ReadBits(int numBits)
                {
                    Debug.Assert(LocalBitsRead + numBits <= 32, "Bitfield values can not span accross 4byte boundary.");

                    uint result = GetBits(*Position, LocalBitsRead, numBits);
                    LocalBitsRead += numBits;

                    if (LocalBitsRead % 32 == 0)
                    {
                        LocalBitsRead = 0;
                        Position++;
                    }

                    return result;
                }

                public static uint GetBits(uint data, int offset, int bits)
                {
                    Debug.Assert(bits <= 32 - offset);

                    uint mask = (1u << bits) - 1u;
                    return (data >> offset) & mask;
                }
            }
        }
    }
}
