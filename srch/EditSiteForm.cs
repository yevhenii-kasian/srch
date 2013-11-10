using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srch
{
    public partial class EditSiteForm : Form
    {
        public EditSiteForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            MainForm own = this.Owner as MainForm;
            int indx = own.siteListView.SelectedItems[0].Index;
            own.siteList.ElementAt(indx).SiteName = siteNameTextBox.Text;
            own.siteList.ElementAt(indx).SiteUri = urlTextBox.Text;
            own.siteList.ElementAt(indx).Filter = filterTextBox.Text;
            own.filterTextBox.Text = filterTextBox.Text;
            own.filterTextBox.Update();
            own.siteListView.Items[indx].Text = siteNameTextBox.Text;
            own.siteListView.Update();
            Close();
        }
    }
}
