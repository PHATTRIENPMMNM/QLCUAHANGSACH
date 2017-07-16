using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Data_Tier;
namespace Business_Tier
{
    public class B_MuonTraSach
    {
        D_MuonTraSach objMuonTra = new D_MuonTraSach();
        public DataTable getTableMuonTraSach()
        {
            return objMuonTra.getAllTable("MuonTraSach").Tables["MuonTRaSach"];
        }
        public void CapNhatTable_MuonTra(DataTable tbMuonTra)
        {
            objMuonTra.CapNhatDuLieu(tbMuonTra, "MuonTraSach");
        }
    }
}
