using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Data_Tier;

namespace Business_Tier
{
    public class B_TacGia
    {
        D_TacGia objTacGia=new D_TacGia();
        public DataTable getTableTacGia()
        {
            return objTacGia.getAllTable("TacGia").Tables["TacGia"];
        }
        public DataTable getTableTG_Theo_MaTG(string strMaTG) 
        {
            return objTacGia.getTacGia_Theo_MaTG(strMaTG).Tables["TacGia"];
        }
        public void CapNhatTable_TacGia(DataTable tbTacGia)
        {
            objTacGia.CapNhatDuLieu(tbTacGia, "TacGia");
        }
    }
}
