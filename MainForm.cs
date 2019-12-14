using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using System.Runtime.InteropServices;

namespace Acronix
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ChromiumWebBrowser chromium;

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Starting CefSettings from Settings.cs / A CefSettings indítása a Settings.cs classból
            Settings.InitCefSettings();

            //Creating the first tab / Az első tab létrehozása
            CreateTab();
        }

        
        private void newTabButton_Click(object sender, EventArgs e)
        {
            CreateTab();
        }
        

        //TabControl:
        private void CreateTab()
        {
            TabPage tab = new TabPage();
            tab.Text = "New Tab";
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            chromium = new ChromiumWebBrowser(Settings.homepage)
            {
                Parent = tab,
                Dock = DockStyle.Fill
            };
            urlBar.Text = Settings.homepage;

            chromium.AddressChanged += OnBrowserAddressChanged;
            chromium.TitleChanged += OnBrowserTitleChanged;
        }

        //Address and title update method / Link és cím frissítés módja
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlBar.Text = args.Address);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => tabControl.SelectedTab.Text = args.Title);

        }

        //URL bar enter navigation / Link szövegdoboz enterrel történő navigálása
        private void urlBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Go to the typed link if enter was pressed / Enter lenyomására menj az adott linkre
            chromium = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chromium != null)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    chromium.Load(urlBar.Text);

                    //Fix for windows ding sound when pressing enter / Windows hang némítása enter nyomás közben
                    e.Handled = true;
                }
            }
        }

        //Base navigation buttons / Alapvető navigálási gombok
        private void reloadButton_Click(object sender, EventArgs e)
        {
            chromium = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chromium != null)
            {
                chromium.Reload();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            chromium = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chromium != null)
            {
                if (chromium.CanGoBack)
                {
                    chromium.Back();
                }
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            chromium = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (chromium != null)
            {
                if(chromium.CanGoForward)
                {
                chromium.Forward();
                }
            }
        }

        //Self-made border content / Saját készítésű border tartalma

            //Drag & move solution for the self-made border / Drag & move megoldás a saját készítésű borderhez
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void borderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //When all windows had been closed, stop the CefSharp engine / Ha minden ablak bezárult, állítsd le a CefSharp motort
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}