using System;
using System.Collections.Generic;
using System.IO;
using CefSharp;

namespace WpfTest.Handlers
{
    public class DiskSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public const string SchemeName = "local";

        
        static DiskSchemeHandlerFactory()
        {
        }
        
        // https://github.com/cefsharp/CefSharp/wiki/General-Usage#scheme-handler
        // https://stackoverflow.com/questions/35965912/cefsharp-custom-schemehandler
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            return new ResourcesHandler();
        }
    }
}