using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookLibrary
{


    public partial class Books : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBookData();
            }
           

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            string selectedISBN = datatable.SelectedRow.Cells[1].Text;


            string connStr = ConfigurationManager.ConnectionStrings["BooksDBConnection"].ConnectionString;
  
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE  FROM tbooks WHERE ISBN=@ISBN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", selectedISBN);
                    conn.Open();
                    cmd.ExecuteNonQuery(); ;
                    System.Diagnostics.Debug.WriteLine("Delete completed");

                }
            }
            Response.Redirect("Books.aspx");
        }

     

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookDetails.aspx");
        }


        protected void EditBtn_Click(object sender, EventArgs e)
        {
            string selectedISBN = datatable.SelectedRow.Cells[1].Text;
            Response.Redirect("BookDetails.aspx?isbn="+ selectedISBN);
        }
        private void LoadBookData()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BooksDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM TBooks";
               
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datatable.DataSource = dt;
                datatable.DataBind();
            }
        }

        protected void displaybuttons(object sender, EventArgs e)
        {
                edit.Enabled = true;
                delete.Enabled = true;
        }

    }
}