using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Web
{
    public partial class Cat : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string Constring = ConfigurationManager.ConnectionStrings["PetDbConnectionString"].ConnectionString;
                LoadBindGridView(Constring);
                Load_dd_CatType(Constring);
                Load_dd_FurType(Constring);
            }
        }

        private void LoadBindGridView(string constring)
        {
            string catQuery = "select id, Name,Dob, GenderId, catType, FurType from Cats";
            using (SqlConnection cons = new SqlConnection(constring))
            {
                using (SqlDataAdapter ads = new SqlDataAdapter(catQuery, constring))
                {
                    using (DataTable dt = new DataTable())
                    {
                        ads.Fill(dt);
                        gv_cats.DataSource = dt;
                        gv_cats.DataBind();
                    }
                }
            }
        }

        private void Load_dd_CatType(string Constring)
        {
            string query = "select * from catType";
            using(SqlConnection cons = new SqlConnection(Constring))
            {
                using(SqlDataAdapter ads = new SqlDataAdapter(query, Constring))
                {
                    using (DataTable dt = new DataTable())
                    {
                        ads.Fill(dt);
                        dd_CatType.DataSource = dt;
                        dd_CatType.DataBind();
                        dd_CatType.DataTextField = "Name";
                        dd_CatType.DataValueField = "Id";
                        dd_CatType.DataBind();
                    }
                }
            }
        }
        private void Load_dd_FurType(string Constring)
        {
            string query = "select * from FurType";
            using (SqlConnection cons = new SqlConnection(Constring))
            {
                using (SqlDataAdapter ads = new SqlDataAdapter(query, Constring))
                {
                    using (DataTable dt = new DataTable())
                    {
                        ads.Fill(dt);
                        dd_FurType.DataSource = dt;
                        dd_FurType.DataBind();
                        dd_FurType.DataTextField = "Name";
                        dd_FurType.DataValueField = "Id";
                        dd_FurType.DataBind();
                    }
                }
            }
        }
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string name = tb_Name.Text;
            string dob = tb_Dob.Text;
            int genderId;
            if (rb_Male.Checked)
            {
                genderId = 1;
            }
            else
            {
                genderId = 2;
            }
            string catType = dd_CatType.SelectedValue;
            string furType = dd_FurType.SelectedValue;
            string ConString = ConfigurationManager.ConnectionStrings["PetDbConnectionString"].ConnectionString;
            string insertQuery = "INSERT INTO Cats(Name, Dob, GenderId,CatType,FurType) Values(@Name,@Dob,@GenderId,@CatType,@FurType)";
            using(SqlConnection connection = new SqlConnection(ConString))
            {
                using(SqlCommand cmd = new SqlCommand(insertQuery))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Dob", dob);
                    cmd.Parameters.AddWithValue("@GenderId", genderId);
                    cmd.Parameters.AddWithValue("@CatType", catType);
                    cmd.Parameters.AddWithValue("@FurType", furType);
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            LoadBindGridView(ConString);
        }
        
    }
}