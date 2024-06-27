Ktx2.ErrorCode err = Ktx2.Create(new Ktx2.TextureCreateInfo()
{
    BaseWidth = 16,
    BaseHeight = 16,
    BaseDepth = 1,
    NumDimensions = 2,
    NumLayers = 1,
    NumLevels = 1,
    NumFaces = 1,
    VkFormat = Ktx2.VkFormat.BC7SrgbBlock,
},
Ktx2.TextureCreateStorage.AllocStorage, out Ktx2.Texture* test);

nuint size = Ktx2.GetImageSize(test, 0);
byte[] data = new byte[size];
Ktx2.ErrorCode err = Ktx2.SetImageFromMemory(test, 0, 0, 0, data[0], size);

Ktx2.ErrorCode err = Ktx2.CreateCopy(test, out Ktx2.Texture* newTest);