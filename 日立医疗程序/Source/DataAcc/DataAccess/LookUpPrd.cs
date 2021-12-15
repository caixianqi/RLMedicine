using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace DataAccess
{
    public class LookUpPrd:ILookUp2
    {

        #region ILookUp2 ≥…‘±

        public System.Data.DataSet GetInfo()
        {
            System.Data.DataSet dataset1=new System.Data.DataSet();
            
            Prd PrdObj = new Prd();
            PrdType PrdTypeObj = new PrdType();
            dataset1.Tables.Add(PrdObj.GetInfo());
            dataset1.Tables.Add(PrdTypeObj.GetInfo());

            System.Data.DataRelation TypePrdRel = new DataRelation("TypePrds", dataset1.Tables[0].Columns["cInvcCode"],
                                                        dataset1.Tables[2].Columns["cInvcCode"]);

            dataset1.Relations.Add(TypePrdRel);
            return dataset1;
        }

        #endregion
    }
}
