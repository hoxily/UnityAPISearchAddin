using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Collections.Generic;

namespace UnityAPISearch
{
    public class SearchReferenceCommandHandler : CommandHandler
    {
        public Dictionary<string, string> config = new Dictionary<string, string>();
        public void LoadConfig()
        {
            Assembly current = Assembly.GetExecutingAssembly();
            string location = current.Location;
            int index = location.LastIndexOf("UnityAPISearch.dll", StringComparison.OrdinalIgnoreCase);
            string path = location.Remove(index);
            string configPath = path + "UnityAPISearch.config.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(configPath);
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode e in root.ChildNodes)
            {
                string key = e.Attributes["key"].Value;
                string value = e.Attributes["value"].Value;
                config[key] = value;
            }
        }
        protected override void Update(CommandInfo item)
        {
            item.Visible = item.Enabled = true;
        }
    }
}
