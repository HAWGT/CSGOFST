using System;
using System.Windows.Forms;
using CSGOFST.Modules;

namespace CSGOFST
{
    public partial class MainForm : Form
    {
        private CSGOCore csgoCore;
        public MainForm()
        {
            InitializeComponent();
            csgoCore = new CSGOCore(this);
        }

        public bool MVPLogger()
        {
            return chk_mvplogger.Checked;
        }

        public bool Sounds()
        {
            return chk_flash.Checked;
        }

        public bool ReloadFlash()
        {
            return chk_reloadflash.Checked;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void btn_dump_Click(object sender, EventArgs e)
        {
            csgoCore.DumpGS();
        }
    }
}
