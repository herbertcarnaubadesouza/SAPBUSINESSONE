using System;
using System.Runtime.InteropServices;
using HelperB1;
using SAPbouiCOM;
//using UIHelper;



namespace StatusBar
{
    public class frmStatusBar
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
        private SAPbouiCOM.EditText oEditTextMessage;
        private SAPbouiCOM.ComboBox oComboBoxTypeMessage;

        private SAPbouiCOM.Button oButtonOK;
        private SAPbouiCOM.Button oButtonMenssagem;
        private SAPbouiCOM.Item oItemRect;
        private SAPbouiCOM.StaticText oStaticTextMensagem;
        private SAPbouiCOM.StaticText oStaticTextTipoMensagem;
        public frmStatusBar()
        {
            SetApplication();
            CriarFormulario();
            oForm.Visible = true;

            oApplication.ItemEvent += OApplication_ItemEvent;
            oApplication.AppEvent += OApplication_AppEvent;

            
        }

        private void OApplication_AppEvent(BoAppEventTypes EventType)
        {
            if(EventType == BoAppEventTypes.aet_ShutDown)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void OApplication_ItemEvent(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (
                pVal.ItemUID.Equals(this.oButtonMenssagem.Item.UniqueID)
                & pVal.EventType == BoEventTypes.et_ITEM_PRESSED
                & !pVal.BeforeAction
                )
            {
                BoStatusBarMessageType vTypeMessage;
                vTypeMessage = BoStatusBarMessageType.smt_None;
                if (oComboBoxTypeMessage.Value.Equals(Convert.ToString(BoStatusBarMessageType.smt_None)))
                {
                    vTypeMessage = BoStatusBarMessageType.smt_None;

                }
                else if (oComboBoxTypeMessage.Value.Equals(Convert.ToString(BoStatusBarMessageType.smt_Warning)))
                {
                    vTypeMessage = BoStatusBarMessageType.smt_Warning;

                }
                else if (oComboBoxTypeMessage.Value.Equals(Convert.ToString(BoStatusBarMessageType.smt_Error)))
                {
                    vTypeMessage = BoStatusBarMessageType.smt_Error;

                }
                else if (oComboBoxTypeMessage.Value.Equals(Convert.ToString(BoStatusBarMessageType.smt_Success)))
                {
                    vTypeMessage = BoStatusBarMessageType.smt_Success;

                }
                else
                {
                    vTypeMessage = BoStatusBarMessageType.smt_None;


                }

                oApplication.StatusBar.SetText(
                    oEditTextMessage.Value
                    ,BoMessageTime.bmt_Short
                    ,(SAPbouiCOM.BoStatusBarMessageType)vTypeMessage
                    );


            }
            else if(pVal.EventType == BoEventTypes.et_FORM_UNLOAD & pVal.FormUID.Equals(this.oForm.UniqueID))
            {
                this.oApplication.MessageBox("Addon Finalizado!!",1,"OK","","");
                System.Windows.Forms.Application.Exit();
            }

            

            
        }

        


        //private void SetApplication()
        //{
        //    SAPbouiCOM.SboGuiApi oSboGuiApi = null;
        //    string sConnectionString = null;

        //    oSboGuiApi = new SAPbouiCOM.SboGuiApi();

        //    sConnectionString = System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1));

        //    try
        //    {
        //        oSboGuiApi.Connect(sConnectionString);

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        System.Environment.Exit(0);
        //    }
        //    oApplication = oSboGuiApi.GetApplication(-1);

        //    oApplication.SetStatusBarMessage(string.Format("Addon {0} Conectado com sucesso!!!);",
        //                    System.Windows.Forms.Application.ProductName),
        //                    BoMessageTime.bmt_Medium
        //                    , false); ;



        //}
        private void AddDataSources()
        {

            //this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_Warning), "Warning");
            //this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_Error), "Error");
            //this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_None), "None");
            //this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_Success), "Sucess");

            //this.oComboBoxTypeMessage.Select(0, BoSearchKey.psk_Index);






            this.oForm.DataSources.UserDataSources.Add("EditSource", BoDataType.dt_SHORT_TEXT, 40);
            this.oForm.DataSources.UserDataSources.Add("CmbSource", BoDataType.dt_SHORT_TEXT, 40);
            this.oEditTextMessage.DataBind.SetBound(true, "", "EditSource");
            this.oComboBoxTypeMessage.DataBind.SetBound(true, "", "CmbSource");
            this.oEditTextMessage.String = "Digite sua mensagem aqui";

            //BoStatusBarMessageType.smt_Error

        }


        private void CriarFormulario()
        {
            SAPbouiCOM.Item oItem = null;
            //SAPbouiCOM.Button oButton = null;
            SAPbouiCOM.StaticText oStaticText = null;
            SAPbouiCOM.ComboBox oComboBox = null;
            SAPbouiCOM.EditText oEditText = null;

            try
            {
                this.oForm = this.oApplication.Forms.Add("frmStatusBar", BoFormTypes.ft_Fixed, -1);

            }
            catch (COMException ex)
            {
                //if (ex.ErrorCode == -7010)
                //{
                //    this.oForm = this.oApplication.Forms.Add("frmStatusBar");


                //}
                //else
                //{
                    System.Windows.Forms.MessageBox.Show(
                    ex.Message
                    , "Erro"
                    , System.Windows.Forms.MessageBoxButtons.OK
                    , System.Windows.Forms.MessageBoxIcon.Error
                    );
                    System.Environment.Exit(0);

                //}

            }
            
            ConfiguraForm(
                "Exemplo Status Bar"
                , 400
                , 350
                , 100
                , 80
                );
            //add botao ok
            this.oButtonOK = UIHelper.AddBotaoAoFormulario(this.oForm,"1", 6, 65, 53, 19, "OK");
            this.oButtonMenssagem = UIHelper.AddBotaoAoFormulario(this.oForm,"BTN_STATUS", 90, 150, 53, 19, "Mostrar Mensagem");
            this.oItemRect = UIHelper.AddRectAoFormulario(this.oForm, "Rect1", 0,344,1,45);
            this.oComboBoxTypeMessage = UIHelper.AddComboBoxAoFormulario(this.oForm,"ComboBox1", 157, 163, 24, 14);
            this.oEditTextMessage = UIHelper.AddEditTextAoFormulario(this.oForm,"edtMessage",157,163,8,14);

            
            

            this.oStaticTextMensagem = UIHelper.AddStaticTextAoFormulario(this.oForm,"st01", 7, 148, 8, 14, "Mensagem de texto:", "edtMessage");
            this.oStaticTextTipoMensagem = UIHelper.AddStaticTextAoFormulario(this.oForm,"st02", 7, 148, 8, 14, "Mensagem de texto:", "ComboBox1");
            
            this.AddDataSources();


            this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_Warning), "Warning");
            this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_Error), "Error");
            this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_None), "None");
            this.oComboBoxTypeMessage.ValidValues.Add(Convert.ToString(BoStatusBarMessageType.smt_Success), "Sucess");

            this.oComboBoxTypeMessage.Select(0, BoSearchKey.psk_Index);
        }


        private void ConfiguraForm(string pTitle, int pFleft,int pClientWidth, int pTop,int pClientHeight)
        {
            this.oForm.Title =  pTitle;
            this.oForm.Left = pFleft;
            this.oForm.ClientWidth = pClientWidth;
            this.oForm.Top = pTop;
            this.oForm.ClientHeight = pClientHeight;
        }
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
                            , false); ;



        }
    }

    
}
