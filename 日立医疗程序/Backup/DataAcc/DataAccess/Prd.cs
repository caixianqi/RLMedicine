using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Prd
    {
        public  System.Data.DataTable GetInfo()
        {
            string sql = 
              "SELECT  cast(0 as bit) as bRefSelectColumn,'' as SelCol,"+
                "[InventoryEntity_Inventory].[cInvCode] as cInvCode,[InventoryEntity_Inventory].[cInvName] as cInvName,"+
                "[InventoryEntity_Inventory].[bTrackSaleBill] as bTrackSaleBill,"+
                "[InventoryEntity_Inventory].[cInvStd] as cInvStd,"+
                "[InventoryEntity_Inventory].[bProxyForeign] as bProxyForeign,"+
                "[InventoryEntity_Inventory].[bPTOModel] as bPTOModel,"+
                "[InventoryEntity_Inventory].[bATOModel] as bATOModel,"+
                "[InventoryEntity_Inventory].[bCheckItem] as bCheckItem,"+
                "[InventoryEntity_Inventory].[bPlanInv] as bPlanInv,[InventoryEntity_Inventory].[cInvABC] as cInvABC,"+
                "[InventoryEntity_Inventory].[bInvBatch] as bInvBatch,[InventoryEntity_Inventory].[bSerial] as bSerial,"+
                "[InventoryEntity_Inventory].[dSDate] as dSDate,"+
                "[InventoryEntity_Inventory].[bConfigFree2] as bConfigFree2,"+
                "[InventoryEntity_Inventory].[bConfigFree3] as bConfigFree3,"+
                "[InventoryEntity_ComputationGroup].[cGroupName] as cGroupName,"+
                "[InventoryEntity_ComputationUnit].[cComUnitName] as cComUnitName,"+
                "[InventoryEntity_Inventory].[iROPMethod] as iROPMethod,"+
                "(CASE [InventoryEntity_Inventory].[iROPMethod]  WHEN '1' THEN '手工' WHEN '2' THEN '自动' ELSE '' END) as iROPMethod_Enum_Caption,"+
                "[InventoryEntity_Inventory].[bROP] as bROP,[InventoryEntity_Inventory].cInvcCode " +
             "FROM [Inventory] AS [InventoryEntity_Inventory] "+
                "LEFT JOIN [ComputationGroup] AS [InventoryEntity_ComputationGroup] ON  [InventoryEntity_ComputationGroup].[cGroupCode] = [InventoryEntity_Inventory].[cGroupCode] "+
                "LEFT JOIN [ComputationUnit] AS [InventoryEntity_ComputationUnit] ON  [InventoryEntity_ComputationUnit].[cComunitCode] = [InventoryEntity_Inventory].[cComUnitCode] "+
             "WHERE 1=1  and (dEDate is null or dEDate>N'2006-11-20') and (bBomSub = 1) "+
             " Order by cInvCode ASC  ";
            return U8Global.U8DataAcc.ExecuteQuery(sql, "Prd");

        }
    }
}
