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
    class TokenScrape
    {
        private static char[] tokenBreakers = new char[]
		{
			' ',
			'\t',
			'(',
			')',
			'[',
			']',
			'{',
			'}',
			';',
			':'
		};
        public static string GetCurrentToken()
        {
            Document activeDocument = IdeApp.Workbench.ActiveDocument;
            string result;
            if (null != activeDocument)
            {
                if (activeDocument.Editor.IsSomethingSelected)
                {
                    result = activeDocument.Editor.SelectedText.Trim();
                    return result;
                }
                int num = Math.Max(1, activeDocument.Editor.Caret.Column - 1);
                string lineText = activeDocument.Editor.GetLineText(activeDocument.Editor.Caret.Line);
                if (3 < lineText.Length)
                {
                    int num2 = lineText.LastIndexOfAny(tokenBreakers, num - 1);
                    int num3 = lineText.IndexOfAny(tokenBreakers, num);
                    if (0 > num3)
                    {
                        num3 = lineText.Length;
                    }
                    int num4 = num3 - num2 - 1;
                    if (0 < num4 && lineText.Length >= num2 + 1 + num4)
                    {
                        result = lineText.Substring(num2 + 1, num4).Trim();
                        return result;
                    }
                }
            }
            result = string.Empty;
            return result;
        }
        public static string GetBaseToken(string token)
        {
            string result;
            if (!string.IsNullOrEmpty(token))
            {
                int num = token.LastIndexOf('.');
                if (0 <= num && token.Length - 1 > num)
                {
                    result = token.Substring(num + 1);
                    return result;
                }
            }
            result = token;
            return result;
        }
    }
}
