using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioSimples
{
    public class WorkingWithXML
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private void SetApplication()

        {
            SAPbouiCOM.SboGuiApi oSboGuiApi = null;
            string sConnectionString = null;

            oSboGuiApi = new SAPbouiCOM.SboGuiApi();

            sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

            oSboGuiApi.Connect(sConnectionString);

            oApplication = oSboGuiApi.GetApplication(-1);


        }
        private void LoadFromXML( ref string pFileName)
        {
            System.Xml.XmlDocument oXmlDoc = null;

            string sPath = null;
            sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();
            sPath = System.IO.Directory.GetParent(sPath).ToString();

            oXmlDoc.Load(sPath + "\\" + pFileName);

            string sXml = oXmlDoc.InnerXml.ToString();
            oApplication.LoadBatchActions(ref sXml);

        }
        private void SaveAsXML(ref SAPbouiCOM.Form pForm)
        {
            System.Xml.XmlDocument oXmlDoc = null;
            oXmlDoc = new System.Xml.XmlDocument();
            string sXmlString = null;

            sXmlString = oForm.GetAsXML();

            oXmlDoc.LoadXml(sXmlString);

            string sPath = null;
            sPath = System.IO.Directory.GetParent(Application.StartupPath).ToString();

            oXmlDoc.Save(sPath + @"\FormSimples_1.xml");

            //oApplication.SetStatusBarMessage("Dir:" + sPath, SAPbouiCOM.BoMessageTime.bmt_Short, false);
        }
        public WorkingWithXML()
        {
            SetApplication();

            string sXMLFormName = "FormSimples.xml";
            LoadFromXML(ref sXMLFormName);

            oForm = oApplication.Forms.Item("MeuFormSimples");
            oForm.Visible = true;

            SaveAsXML(ref oForm);

        }
    }
}
