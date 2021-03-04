using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarraProgresso
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetApplication();
            oApplication.ProgressBarEvent += OApplication_ProgressBarEvent;
            btnFrente.Enabled = false;
            btnTras.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;

        }

       
        private void OApplication_ProgressBarEvent(ref ProgressBarEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if(pVal.EventType == BoProgressBarEventTypes.pbet_ProgressBarStopped & pVal.BeforeAction)
            {
                oApplication.MessageBox("Progress Bar Stop", 1, "OK", "", "");
                ReleaseBar();

            }
            else if (pVal.EventType == BoProgressBarEventTypes.pbet_ProgressBarCreated & pVal.BeforeAction)
            {
                oApplication.MessageBox("Progress Bar Criado", 1, "OK", "", "");

            }
            else if (pVal.EventType == BoProgressBarEventTypes.pbet_ProgressBarReleased & pVal.BeforeAction)
            {
                oApplication.MessageBox("Progress Bar Liberado", 1, "OK", "", "");

            }
            else
            {
                oApplication.SetStatusBarMessage("O evento" + pVal.EventType.ToString() + "foi acionado",
                BoMessageTime.bmt_Short
                , false);

            }


                

        }
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.ProgressBar oProgressBar;
        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;

            oSboGuiApi = new SAPbouiCOM.SboGuiApi();

            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            try
            {
                oSboGuiApi.Connect(sConnectionString);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
            oApplication = oSboGuiApi.GetApplication(-1);

            oApplication.SetStatusBarMessage(string.Format("Addon {0} Conectado com sucesso!!!);",
                            System.Windows.Forms.Application.ProductName),
                            BoMessageTime.bmt_Medium
                            , false);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            oProgressBar.Value -= 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            oProgressBar.Value += 1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            oProgressBar = oApplication.StatusBar.CreateProgressBar("Exemplode ProgressBar", 27, true);
            btnFrente.Enabled = true;
            btnTras.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }
        private void ReleaseBar()
        {
            oProgressBar.Stop();
            btnFrente.Enabled = false;
            btnTras.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ReleaseBar();
        }
    }
}
