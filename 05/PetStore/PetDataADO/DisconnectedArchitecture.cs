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

        public static DataRow GetCatById(string conStr, int id, out SqlConnection connection, out SqlDataAdapter da, out DataSet ds)
        {
            using (connection = new SqlConnection(conStr))
            {
                SqlCommand cmd;
                da = new SqlDataAdapter();
                ds = new DataSet();
                cmd = new SqlCommand("DA_GetCatById",connection);
                cmd.Parameters.Add(new SqlParameter("@ID",id));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                int rows = da.Fill(ds, "Cats");
                if (rows != 0)
                {
                    var cat = ds.Tables["Cats"].Rows;
                    return cat[0];
                }
            }
            return null;
        }
        public static void DeleteCatByName(string conStr, string query, out SqlConnection connection, out SqlDataAdapter da, out DataSet ds, string name)
        {
            using (connection = new SqlConnection(conStr))
            {
                da = new SqlDataAdapter(query, connection);
                ds = new DataSet();//to hold data from db

                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Fill(ds, "Cats");
                var data = ds.Tables["Cats"].Rows;
                foreach (DataRow row in data)
                {
                    if (row["Name"].ToString() == name)
                    {
                        row.Delete();
                        Console.WriteLine("Deleting");
                    }
                }

                try
                {
                    int result = da.Update(ds, "Cats");
                    if (result > 0)
                        Console.WriteLine("Success");
                    else
                        Console.WriteLine("Failed");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
