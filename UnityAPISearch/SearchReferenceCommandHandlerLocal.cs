using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace UnityAPISearch
{
    class SearchReferenceCommandHandlerLocal : SearchReferenceCommandHandler
    {
        private const string FILE_SCHEME = "file://";
        public SearchReferenceCommandHandlerLocal()
        {
            LoadConfig();
            string localApiBase = config["LocalApiBase"];
            if (localApiBase.StartsWith(FILE_SCHEME, StringComparison.OrdinalIgnoreCase))
            {
                config["LocalApiBase"] = localApiBase.Substring(FILE_SCHEME.Length);
            }
        }
        private void ShowLocalFile(string path)
        {
            DesktopService.ShowUrl(FILE_SCHEME + path);
        }
        protected override void Run()
        {
            ShowLocalFile(Path.Combine(config["LocalApiBase"], "index.html"));
        }
    }
}

