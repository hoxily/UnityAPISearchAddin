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
    class SearchReferenceCommandHandlerOnline : SearchReferenceCommandHandler
    {
        public SearchReferenceCommandHandlerOnline()
        {
            LoadConfig();
        }

        protected override void Run()
        {
            string currentToken = TokenScrape.GetCurrentToken();
            if (string.IsNullOrEmpty(currentToken))
            {
                DesktopService.ShowUrl(config["OnlineApiBase"]);
            }
            else
            {
                DesktopService.ShowUrl(string.Format("{0}/{1}?q={2}", config["OnlineApiBase"], config["SearchPage"], Uri.EscapeDataString(currentToken)));
            }
        }
    }
}

