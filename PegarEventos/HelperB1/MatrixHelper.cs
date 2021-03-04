using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperB1
{
    public static class MatrixHelper
    {
        public static void addoColumn(
            SAPbouiCOM.IMatrix pMatrix
            , string pUID, BoFormItemTypes pType
            , int pWidth
            , string pCaption
            , string pDescription
            , bool pDisplayDesc

            , bool  pBound
            , string  pTableName
            , string pAlias
            , bool pEditable
            , int pForeColor
            ) 
        {
            SAPbouiCOM.IColumn oColumn;
            
            oColumn = pMatrix.Columns.Add(pUID, pType);
            if (pWidth>0)
            {
                oColumn.Width = pWidth;
            }
            if (!string.IsNullOrEmpty(pCaption))
            {
                oColumn.TitleObject.Caption = pCaption;
            }
            if (!string.IsNullOrEmpty(pDescription))
            {
                oColumn.Description = pDescription;
            }
            if (pBound)
            {
                oColumn.DataBind.SetBound(pBound, pTableName, pAlias);
            }
            
            oColumn.DisplayDesc = pDisplayDesc;
            oColumn.Editable = pEditable;
            if (pForeColor>0)
            {
                oColumn.ForeColor = pForeColor;
            }
     
        } 
    }

}
    

