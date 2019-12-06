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

        ChromiumWebBrowser chromium;

        private void Acronix_Load(object sender, EventArgs e)
        {
            //Initialize cefsettings / A cefsettings inicializálása
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            urlBar.Text = "https://www.google.com/";
            chromium = new ChromiumWebBrowser(urlBar.Text);
            this.webRenderer.Controls.Add(chromium);
            chromium.Dock = DockStyle.Fill;
            chromium.AddressChanged += OnBrowserAddressChanged;
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlBar.Text = args.Address);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);

        }

        private void urlBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chromium.Load(urlBar.Text);

                //Fix for windows ding sound when pressing enter / Windows hang némítása enter nyomás közben
                e.Handled = true;
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            chromium.Reload();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if(chromium.CanGoBack)
            {
                chromium.Back();
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if(chromium.CanGoForward)
            {
                chromium.Forward();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}