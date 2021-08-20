using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;
using DAL;
using System.Data;

namespace Repository
{
    public class CanoeRepo
    {

        public bool Insert(Canoe canoe)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@Name", canoe.Name, SqlDbType.NVarChar));
            parms.Add(new ParmStruct("@BuilderId", canoe.BuilderID, SqlDbType.Int));
            parms.Add(new ParmStruct("@Qty", canoe.QTY, SqlDbType.Int));
            parms.Add(new ParmStruct("@DateAdded", canoe.Date, SqlDbType.DateTime));
            parms.Add(new ParmStruct("@Archived", canoe.Archived, SqlDbType.Bit));
            parms.Add(new ParmStruct("@CanoeType", canoe.CanoeType, SqlDbType.Int));

            DataAcess db = new DataAcess();
            return db.ExecuteNonQuery("CanoeBuilders", CommandType.StoredProcedure, parms) > 0;
        }

        public bool MaxFourCanoesOfSameTypeDuringWeek(int canoeID, int canoeType)
        {
            return false;
        }

        public bool TwoNegativeReviews(int canoeID)
        {
            return false;
        }

        public bool CederStripBuilderOnly(int builderID)
        {
            return false;
        }
    }
}
