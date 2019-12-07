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

namespace Acronix
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ChromiumWebBrowser chromium;

        private void Acronix_Load(object sender, EventArgs e)
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

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlBar.Text = args.Address);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => tabControl.SelectedTab.Text = args.Title);

        }

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}