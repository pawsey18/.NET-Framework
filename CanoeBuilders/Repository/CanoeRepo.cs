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

            DataAccess db = new DataAccess();
            return db.ExecuteNonQuery("CanoeBuilders", CommandType.StoredProcedure, parms) > 0;
        }

        public bool MaxFourCanoesOfSameTypeDuringWeek(int builderId, int canoeType)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@BuilderID", builderId, SqlDbType.Int));
            parms.Add(new ParmStruct("@CanoeType", canoeType, SqlDbType.Int));
            string sql = "SELECT COUNT(CanoeType), BuilderId from Canoe where BuilderId = @BuilderID" +
                " AND CanoeType = @CanoeType GROUP BY BuilderID HAVING COUNT(*) >= 4 WHERE DateAdded < dateadd(week,-1,getdate()) ";
            DataAccess db = new DataAccess();
            return Convert.ToInt32(db.ExecuteScaler(sql, CommandType.Text, parms)) > 0;
        }

        public bool TwoNegativeReviews(int builderId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@BuilderID", builderId, SqlDbType.Int));
            string sql = "SELECT COUNT(*) FROM CANOE JOIN REVIEW" +
                " ON Canoe.CanoeId = Review.CanoeId WHERE BuilderId = @BuilderID AND Review.Stars" +
                " <= 2 and ReviewDate < (SELECT DATEADD(YEAR, -1, GETDATE()))HAVING COUNT(*) >= 2";
            DataAccess db = new DataAccess();
            return Convert.ToInt32(db.ExecuteScaler(sql, CommandType.Text, parms)) > 0;
        }

        public bool CederStripBuilderOnly(int builderId)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@BuilderID", builderId, SqlDbType.Int));
            string sql = "SELECT COUNT(*), BuilderId, BuilderTypeId FROM Builder where BuilderId = @BuilderID AND " +
                 "BuilderTypeId = 4 GROUP by BuilderId, BuilderTypeId HAVING COUNT(*) > 0";
            DataAccess db = new DataAccess();
            return Convert.ToInt32(db.ExecuteScaler(sql, CommandType.Text, parms)) > 0;
        }
    }
    }

