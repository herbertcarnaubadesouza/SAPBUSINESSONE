using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace UsandoMatrix
{
    public class UsandoMatrix
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.Matrix oMatrix;
        private SAPbouiCOM.Columns oColumns;
        private SAPbouiCOM.Column oColumn;

        private SAPbouiCOM.DBDataSource oDBDataSource;
        private SAPbouiCOM.UserDataSource oUserDataSource;
        private SAPbouiCOM.Item oItem;

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
        private void OApplication_AppEvent(BoAppEventTypes EventType)
        {
            switch (EventType)
            {

                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    oApplication.MessageBox("O evento Shut Down foi chamado!!"
                                            + Environment.NewLine
                                            + string.Format("Fechando o Addon {0}...",
                                            System.Windows.Forms.Application.ProductName)
                                            , 1, "OK", "", "");
                    System.Windows.Forms.Application.Exit();
                    break;





            }
        }
        public UsandoMatrix()
        {
            SetApplication();
            CriarFormularioComMatrix();
            AddDataSourceNoForm();
            BindDataNoForm();
            GetDataFromDataSource();
            AddPrefix();

            oForm.Visible = true;







            oApplication.AppEvent += OApplication_AppEvent;
            oApplication.ItemEvent += OApplication_ItemEvent;


        }

        private void OApplication_ItemEvent(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.FormUID.Equals("frmMtx"))
            {
                if (pVal.ItemUID.Equals("btnPhone") & (pVal.EventType == BoEventTypes.et_ITEM_PRESSED) & (!pVal.BeforeAction))
                {
                    // ADD PREFIX

                }
                else if ((pVal.EventType == BoEventTypes.et_FORM_UNLOAD) &(!pVal.BeforeAction)) 
                {
                    System.Windows.Forms.MessageBox.Show("Formulario Fechado, addon será finalizado");
                    System.Windows.Forms.Application.Exit();

                }
                

            }

        }

        private void AddPrefix()
        {
            //int i = 0;
            EditText oEditText = null;
            string newPhone = String.Empty;

            oItem = oForm.Items.Item("txtPhone");
            oEditText = (EditText)oItem.Specific;

            oMatrix.FlushToDataSource();

            oDBDataSource = oForm.DataSources.DBDataSources.Item("OCRD");

            for (int i = 0; i<= oDBDataSource.Size - 1; i++)
            {
                newPhone = oDBDataSource.GetValue("Phone1", i);
                newPhone = newPhone.Trim(Char.Parse(" "));
                oDBDataSource.SetValue("Phone1", 1, oEditText.String + newPhone);


            }
            oMatrix.LoadFromDataSource();
        }

        private void GetDataFromDataSource()
        {
            oMatrix.Clear();
            oMatrix.AutoResizeColumns();
            oDBDataSource.Query(null);
            oUserDataSource.Value = "Telefone com prefixo";
            oMatrix.LoadFromDataSource();

        }

        private void BindDataNoForm()
        {
            oColumn = oColumns.Item("DSCardCode");
            oColumn.DataBind.SetBound(true, "OCRD", "CardCode");

            oColumn = oColumns.Item("DSCardName");
            oColumn.DataBind.SetBound(true, "OCRD", "CardName");

            oColumn = oColumns.Item("DSPhone");
            oColumn.DataBind.SetBound(true, "OCRD", "Phone1");

            //oColumn = oColumns.Item("DSPhoneInt");
            //oColumn.DataBind.SetBound(true, "", "IntPhone");




        }

        private void AddDataSourceNoForm()
        {

            oUserDataSource = oForm.DataSources.UserDataSources.Add("IntPhone", BoDataType.dt_SHORT_TEXT, 20);
            oDBDataSource = oForm.DataSources.DBDataSources.Add("OCRD");


        }
        private void CriarFormularioComMatrix()
        {
            SAPbouiCOM.Button oButton = null;
            SAPbouiCOM.StaticText oStaticText = null;
            SAPbouiCOM.EditText oEditText = null;

            SAPbouiCOM.FormCreationParams oCreationParams = null;
            oCreationParams = ((SAPbouiCOM.FormCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams)));
            //oCreationParams.BorderStyle = SAPbouiCOM.BoFormBorderStyle.fbs_Fixed;
            oCreationParams.UniqueID = "frmMtx";
            oCreationParams.FormType = "frmMtx";

            oForm = oApplication.Forms.AddEx(oCreationParams);

            oForm.Title = "Matrix, DataSources and Linked Buttons";
            oForm.Left = 336;
            oForm.ClientWidth = 520;
            oForm.Top = 44;
            oForm.ClientHeight = 200;


            oItem = oForm.Items.Add("1 ", BoFormItemTypes.it_BUTTON);
            oItem.Left = 5;
            oItem.Width = 65;
            oItem.Top = 170;
            oItem.Height = 19;
            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = "OK";

            oItem = oForm.Items.Add("2 ", BoFormItemTypes.it_BUTTON);
            oItem.Left = 75;
            oItem.Width = 65;
            oItem.Top = 170;
            oItem.Height = 19;
            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = "Cancel";

            oItem = oForm.Items.Add("txtPhone", SAPbouiCOM.BoFormItemTypes.it_EDIT);
            oItem.Left = 265;
            oItem.Width = 163;
            oItem.Top = 172;
            oItem.Height = 14;

            oItem = oForm.Items.Add("btnPhone ", BoFormItemTypes.it_BUTTON);
            oItem.Left = 160;
            oItem.Width = 100;
            oItem.Top = 170;
            oItem.Height = 19;
            oButton = ((SAPbouiCOM.Button)(oItem.Specific));
            oButton.Caption = "Add Phone Prefix";

            this.oForm.Visible = true;

            AddMatrixNoForm();
        }

        private void AddMatrixNoForm()
        {
            LinkedButton oLink = null;

            oItem = oForm.Items.Add("Matrix1", BoFormItemTypes.it_MATRIX);
            oItem.Left = 5;
            oItem.Width = 500;
            oItem.Top = 5;
            oItem.Height = 150;

            oMatrix = ((SAPbouiCOM.Matrix)(oItem.Specific));

            oColumns = oMatrix.Columns;

            oColumn = oColumns.Add("#", BoFormItemTypes.it_EDIT);
            oColumn.TitleObject.Caption = "#";
            oColumn.Width = 30;
            oColumn.Editable = false;

            oColumn = oColumns.Add("DSCardCode", BoFormItemTypes.it_LINKED_BUTTON);
            oColumn.TitleObject.Caption = "Card Code";
            oColumn.Width = 40;
            oColumn.Editable = true;

            oLink = (oColumn).ExtendedObject;
            oLink.LinkedObject = BoLinkedObject.lf_BusinessPartner;

            oColumn = oColumns.Add("DSCardName", BoFormItemTypes.it_EDIT);
            oColumn.TitleObject.Caption = "Name";
            oColumn.Width = 40;
            oColumn.Editable = true;


            oColumn = oColumns.Add("DSPhone", BoFormItemTypes.it_EDIT);
            oColumn.TitleObject.Caption = "Phone";
            oColumn.Width = 40;
            oColumn.Editable = true;


            //oColumn = oColumns.Add("DSPhone", BoFormItemTypes.it_EDIT);
            //oColumn.TitleObject.Caption = "Int.Phone";
            //oColumn.Width = 40;
            //oColumn.Editable = true;
        }
    }
}
