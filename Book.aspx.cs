using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BookLibrary
{
    public partial class Books : System.Web.UI.Page

    {
        string connStr = WebConfigurationManager.ConnectionStrings["BookDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadBooks();
        }

        void LoadBooks()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBooks", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewBooks.DataSource = dt;
                GridViewBooks.DataBind();
            }
        }
    }
}
