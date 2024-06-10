using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Ktx
{
    public static unsafe partial class Ktx2
    {
        public static class Helper
        {
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
                public uint Model;
                public uint Primaries;
                public uint ransfer;
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

                    dfd.Model = converter.ReadBits(8);
                    dfd.Primaries = converter.ReadBits(8);
                    dfd.ransfer = converter.ReadBits(8);
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
