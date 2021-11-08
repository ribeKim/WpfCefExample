using System;
using System.Collections.Generic;
using System.IO;
using CefSharp;

namespace WpfTest.Handlers
{
    public class ResourcesHandler : ResourceHandler
    {
        private readonly string FolderPath;
        
        public ResourcesHandler()
        {
            FolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./html");
        }

        public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
        {
            var uri = new Uri(request.Url);
            var fileName = uri.AbsolutePath;

            var requestedFilePath = FolderPath + fileName;

            if (File.Exists(requestedFilePath))
            {
                byte[] bytes = File.ReadAllBytes(requestedFilePath);
                Stream = new MemoryStream(bytes);
            
                var fileExtension = Path.GetExtension(fileName);
                MimeType = GetMimeType(fileExtension);
            
                callback.Continue();
                return CefReturnValue.Continue;
            }
            
            callback.Dispose();
            return CefReturnValue.Cancel;
        }
    }
}