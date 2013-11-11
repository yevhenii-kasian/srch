using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiteMonitorInterface;

namespace srch
{
    public partial class MainForm : Form
    {
        internal List<ISiteInterface> siteList;
        private Task<Dictionary<string, string>>[] tasks;
        public MainForm()
        {
            siteList = new List<ISiteInterface>();
            InitializeComponent();
            tasks = new Task<Dictionary<string, string>>[siteList.Count];
            
        }

        private void StartThreads()
        {for (int i = 0; i < siteList.Count; i++)
            {
                tasks[i] = Task<Dictionary<string, string>>.Factory.StartNew(siteList[i].Checker);
            }
            Task.WaitAll(tasks);
        }


        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddSiteForm addSite = new AddSiteForm();
            addSite.Owner = this;
            addSite.ShowDialog();
        }

        private void siteListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (siteListView.SelectedItems.Count != 0)
            {
                filterTextBox.ReadOnly = false;
                filterTextBox.Text = siteList.ElementAt(siteListView.SelectedItems[0].Index).Filter;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (siteListView.SelectedItems.Count != 0 && siteList.Count > 0)
            {
                sitesMenu.Update();
                siteList.RemoveAt(siteListView.SelectedItems[0].Index);
                siteListView.SelectedItems[0].Remove();
                filterTextBox.Text = string.Empty;
                filterTextBox.ReadOnly = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (siteListView.SelectedItems.Count != 0)
            {
                sitesMenu.Update();
                int indx = siteListView.SelectedItems[0].Index;
                EditSiteForm editSite = new EditSiteForm();
                editSite.Owner = this;
                editSite.siteNameTextBox.Text = siteList.ElementAt(indx).SiteName;
                editSite.urlTextBox.Text = siteList.ElementAt(indx).SiteUri;
                editSite.filterTextBox.Text = siteList.ElementAt(indx).Filter;
                editSite.ShowDialog();
            }
        }

        private void filterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            siteList.ElementAt(siteListView.SelectedItems[0].Index).Filter = filterTextBox.Text;
        }
    }
}
