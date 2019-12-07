using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace Acronix
{
    class Settings
    {
        public static string homepage = "https://www.google.com/";

        public static void InitCefSettings()
        {
            CefSettings settings = new CefSettings();
            
            //Setting up cache path / A cache path beállítása
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Acronix";

            //Initialize cefsettings / A cefsettings inicializálása
            Cef.Initialize(settings);
        }
    }
}
