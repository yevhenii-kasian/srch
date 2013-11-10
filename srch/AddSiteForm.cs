using System.Windows.Forms;
using ZeroDayChecker;

namespace srch
{
    public partial class AddSiteForm : Form
    {
        public AddSiteForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            MainForm own = this.Owner as MainForm;
            Checker0day oday = new Checker0day{Filter = filterTextBox.Text,SiteName = siteNameTextBox.Text,SiteUri = urlTextBox.Text};
            own.siteList.Add(oday);
            own.siteListView.Items.Add(oday.SiteName);
            own.filterTextBox.Text = string.Empty;
            own.filterTextBox.ReadOnly = true;
            Close();
        }
    }
}
