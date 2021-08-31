using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetDataADO
{
    public class DisconnectedArchitecture
    {
        public static DataRowCollection GetCats(string conStr, string query, out SqlConnection connection, out SqlDataAdapter da, out DataSet ds)
        {
            using (connection= new SqlConnection(conStr))
            {
                da = new SqlDataAdapter(query, connection);// opens sql connection, fire the query, executes the query and get results
                ds = new DataSet();//to hold data from db
                int rows=da.Fill(ds, "Cats");
                if (rows != 0)
                {
                    return ds.Tables["Cats"].Rows;
                }
                else
                    throw new NullReferenceException();
            }
        }

        //  We can do it in 2 ways 1st(commented) wil loop from whole dataset and 2nd will only get required row

        /*public static DataRow GetCatById(string conStr, string query, int id, out SqlConnection connection, out SqlDataAdapter da, out DataSet ds)
        {
            using (connection = new SqlConnection(conStr))
            {
                da = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                int rows = da.Fill(ds, "Cats");
                if (rows != 0)
                {
                    var cat = ds.Tables["Cats"].Rows;
                    foreach (DataRow item in cat)
                    {
                        if (item["id"].ToString() == id.ToString())
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }*/


        public static DataRow GetCatById(string conStr, string query, int id, out SqlConnection connection, out SqlDataAdapter da, out DataSet ds)
        {
            using (connection = new SqlConnection(conStr))
            {
                da = new SqlDataAdapter(query, connection);
                ds = new DataSet();
                int rows = da.Fill(ds, "Cats");
                if (rows != 0)
                {
                    var cat = ds.Tables["Cats"].Rows;
                    return cat[0];
                }
            }
            return null;
        }
    }
}
