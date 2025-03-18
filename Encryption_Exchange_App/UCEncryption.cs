namespace Encryption_Exchange_App
{
    public partial class UCEncryption : UserControl
    {
        private MainForm mainForm;
        public UCEncryption(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            rbBifid.Checked = mainForm.BifidChecked;
            rbRC6OFB.Checked = mainForm.RC6Checked;
        }

        private void rbBifid_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.BifidChecked = rbBifid.Checked;
            MessageBox.Show("Bifid" + mainForm.BifidChecked.ToString());
        }

        private void rbRC6OFB_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.RC6Checked = rbRC6OFB.Checked;
            MessageBox.Show("RC6+OFB" + mainForm.RC6Checked.ToString());
        }
    }
}