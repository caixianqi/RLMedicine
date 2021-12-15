using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bao.BillBase
{
    /// <summary>
    /// 用于基本档案的实现
    /// </summary>
    public interface IChildForm
    {
        /// <summary>
        /// 得到基本档案的列表
        /// </summary>
        /// <returns>基本档案表</returns>
        System.Data.DataTable GetTableList();
        /// <summary>
        /// 新增基本档案
        /// </summary>
        void Append();
        /// <summary>
        /// 修改基本档案
        /// </summary>
        void Update();
        /// <summary>
        /// 删除基本档案
        /// </summary>
        /// <param name="row1"></param>
        void Delete(System.Data.DataRow row1);
        /// <summary>
        /// 将数据显示在编辑界面中
        /// </summary>
        /// <param name="row1">数据行</param>
        /// <param name="Is_Update">目前状态是新增false还是修改true</param>
        void SetValueToControl(System.Data.DataRow row1,Boolean Is_Update);
    }
}
