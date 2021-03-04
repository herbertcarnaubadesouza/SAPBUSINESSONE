using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace AdicionarMenus
{
    public class AddMenus
    {
        private SAPbouiCOM.Application oApplication;
        private SAPbouiCOM.Form oForm;
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
            oApplication.SetStatusBarMessage("Addon Conectado com sucesso!!!);");



        }
        private void AddMenuItems()
        {
            SAPbouiCOM.Menus oMenus = null;
            SAPbouiCOM.MenuItem oMenuItem = null;

            int i = 0;
            int iAddAfter = 0;
            string sXML = null;
            string sPath = null;

            oMenus = oApplication.Menus;

            SAPbouiCOM.MenuCreationParams oMenuCreationParams = null;
            oMenuCreationParams = (SAPbouiCOM.MenuCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams));

            oMenuItem = oApplication.Menus.Item("43520");

            sPath = Application.StartupPath;
            //sPath = sPath.Remove(sPath.Length - 9, 0);

            oMenuCreationParams.Type = BoMenuType.mt_POPUP;
            oMenuCreationParams.UniqueID = "menu01";
            oMenuCreationParams.String = "Menu Exemplo";
            oMenuCreationParams.Enabled = true;
            oMenuCreationParams.Image = sPath + @"\\UI.bmp";
            oMenuCreationParams.Position = 99;


            oMenus = oMenuItem.SubMenus;

            try
            {
                oMenus.AddEx(oMenuCreationParams);

                oMenuItem = oApplication.Menus.Item("menu01");
                oMenus = oMenuItem.SubMenus;

                oMenuCreationParams.Type = BoMenuType.mt_STRING;
                oMenuCreationParams.UniqueID = "menu02";
                oMenuCreationParams.String = "Sub Menu Exemplo";
                oMenus.AddEx(oMenuCreationParams);

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);

            }






        }

        public AddMenus()
        {
            SetApplication();
            AddMenuItems();

            oApplication.MenuEvent += OApplication_MenuEvent;
            oApplication.AppEvent += OApplication_AppEvent;
        }

        private void OApplication_AppEvent(BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    oApplication.MessageBox("A Empresa foi trocada");
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    oApplication.MessageBox("O evento Shut Down foi chamado!!"
                                            + Environment.NewLine
                                            + "Fechando o Addon..."
                                            , 1, "OK", "", "");
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    oApplication.MessageBox("O Idioma Foi modificado");
                    AddMenuItems();
                    break;
                




            }
        }

        private void addMenuItemsToForm(SAPbouiCOM.Form pMenuForm)

        {
            SAPbouiCOM.MenuCreationParams oMenuCreationParams = null;
            oMenuCreationParams = (SAPbouiCOM.MenuCreationParams)(oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams));

            string sPath = null;
            sPath = Application.StartupPath;

            oMenuCreationParams.Type = BoMenuType.mt_STRING;
            oMenuCreationParams.UniqueID = "menuGoTo1";
            oMenuCreationParams.String = "Menu Relativo ao form";
            //oMenuCreationParams.Enabled = true;
            oMenuCreationParams.Image = sPath + @"\\UT1.bmp";


            try
            {
                pMenuForm.Menu.AddEx(oMenuCreationParams);


            }
            catch(Exception ex)
            {
                oMenuCreationParams.UniqueID = "mnuGoTo2";
                oMenuCreationParams.String = "Menu Relativo ao form 2";
                oMenuCreationParams.Image = sPath + @"\\UI2.bmp";



            }
            try
            {
                pMenuForm.Menu.AddEx(oMenuCreationParams);

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);



            }



        }
        private void OApplication_MenuEvent(ref MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if((pVal.MenuUID.Equals("menu02")) & (!pVal.BeforeAction))
            {
                oApplication.MessageBox("Meu sub menu foi clicado!", 1, "", "OK", "");
                try
                {
                    oForm = oApplication.Forms.Item("myMenuForm");
                    oApplication.MessageBox("O formulário ja existe", 1, "OK", "", "");

                }
                catch
                {
                    oForm = null;
                    oForm = oApplication.Forms.Add("MyMenuForm", BoFormTypes.ft_Sizable, -1);
                    oForm.Title = "Novo Sub Menu Item";
                    oForm.Left = 400;
                    oForm.Top = 100;
                    oForm.Visible = true;

                    addMenuItemsToForm(oForm);

                }
            }
            else if ((pVal.MenuUID.Equals("menuGoTo1")) & (!pVal.BeforeAction))
            {
                oApplication.MessageBox("Menu GoTo1 foi clicado", 1, "OK", "", "");

            }
            else if((pVal.MenuUID.Equals("menuGoTo2")) & (!pVal.BeforeAction))
            {
                oApplication.MessageBox("Menu GoTo2 foi clicado", 1, "OK", "", "");

            }
        }
    }
}
