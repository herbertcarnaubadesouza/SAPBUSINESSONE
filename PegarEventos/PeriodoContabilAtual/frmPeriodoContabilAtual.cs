using HelperB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodoContabilAtual
{
    public class frmPeriodoContabilAtual
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;

        private SAPbouiCOM.EditText oEditInformacoes;
        private SAPbouiCOM.Button oButtonOK;
        public frmPeriodoContabilAtual()
        {
            AppHelper.SetApplication(ref this.oApplication);

            this.oForm = UIHelper.CriarForm(this.oApplication, SAPbouiCOM.BoFormBorderStyle.fbs_Sizable, "InfoPer", "Infoper", 0, 0, true,0, "Periodo Contabil Atual", 70, 150, 0, 0);
            this.oEditInformacoes = UIHelper.AddEditTextAoFormulario(this.oForm, "EditInfo", 10, 100, 10, 0, "", false, 0, 0);
            this.oButtonOK = UIHelper.AddBotaoAoFormulario(this.oForm, "1", 10, 65, 25, 19, "Ok", false);
            this.oEditInformacoes.Value = oApplication.Company.CurrentPeriod.ToString();

            this.oForm.Visible = true;
        }
    }
}
