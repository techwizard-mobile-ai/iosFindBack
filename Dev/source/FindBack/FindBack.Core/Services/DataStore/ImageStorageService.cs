using System;
using Cirrious.MvvmCross.Plugins.File;

namespace FindBack.Core.Services.DataStore
{
    public class ImageStorageService : IImageStorageService
    {
        private IMvxFileStore _fileStore;

        public ImageStorageService(IMvxFileStore fileStore)
        {
            this._fileStore = fileStore;
        }

        public string SaveImageToFile(byte[] pictureBytes)
        {
            if (pictureBytes == null)
            {
                return null;
            }

            var randomFileName = "Image" + Guid.NewGuid().ToString("N") + ".jpg";
            _fileStore.EnsureFolderExists("Images");
            var path = _fileStore.PathCombine("Images", randomFileName);

            _fileStore.WriteFile(path, pictureBytes);
            return path;
        }
    }
}