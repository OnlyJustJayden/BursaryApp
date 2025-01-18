using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TeamKappa
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        string _ytUrl;

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            new NewAccount().Show();
            this.Close();
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            //282, 94 Location
            //485, 374 Size
            pnlModule.Location = new Point(282, 94);
            pnlModule.Width = 485;
            pnlModule.Height = 374;
            pnlModule.Visible = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlBudgetTools.Location = new Point(282, 94);
            pnlBudgetTools.Width = 485;
            pnlBudgetTools.Height = 374;
            pnlBudgetTools.Visible = true;

        }
        private string VideoId
        {
            get
            {
                var ytMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(_ytUrl);
                return ytMatch.Success ? ytMatch.Groups[1].Value : string.Empty;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            _ytUrl = txtVideoLink.Text;
            webVideo.Navigate($"http://youtube.com/v/{VideoId}?version=3");
            //string html = "<html><head>"; 
            //html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible '/>";
            //html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}'  width='600' height='300' frameborder='0' allowfullscreen></iframe>";
            //html += "</head></html>";
            //this.webVideo.DocumentText = string.Format(html, txtVideoLink.Text.Split('=')[1]);
        }

        private void btnEdVideo_Click(object sender, EventArgs e)
        {
            pnlEdVideos.Location = new Point(308, 23);
            pnlEdVideos.Width = 485;
            pnlEdVideos.Height = 445;
            pnlEdVideos.Visible = true;
        }
    }
}
