using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

namespace BookLibrary
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string source = Request.QueryString["isbn"];

                if (!String.IsNullOrEmpty(source))
                {
                    string isbn = Request.QueryString["isbn"];

                    DataTable dt = LoadBookData(isbn);
                    if (dt.Rows.Count > 0)
                    {
                        lblLN.Text = dt.Rows[0]["Title"].ToString();
                        txtIsbn.Text = dt.Rows[0]["ISBN"].ToString();
                        txtTitle.Text = dt.Rows[0]["Title"].ToString();
                        txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                        txtPrice.Text = dt.Rows[0]["Price"].ToString();
                        txtPublish.Checked = dt.Rows[0]["Publish"].Equals(true);
                        txtPublishDate.Text = Convert.ToDateTime(dt.Rows[0]["PublishDate"]).ToString("yyyy-MM-dd");
                    }
                }
                else
                {

                    lblLN.Text = "Add Books";
                }

            }
        }

        private DataTable LoadBookData(string isbn)
        {
            string connStr = ConfigurationManager.ConnectionStrings["BooksDBConnection"].ConnectionString;
            string query = "SELECT * FROM TBooks WHERE ISBN = @ISBN";


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;


            }

        }


        protected void SaveBtn_Click(object sender, EventArgs e)
        {



            bool publish = txtPublish.Checked;
            string isbn = txtIsbn.Text.Trim();
            bool isValid = ValidateInputs();
            System.Diagnostics.Debug.WriteLine("is Valid: " + isValid);
            if (isValid)
            {
                string connStr = ConfigurationManager.ConnectionStrings["BooksDBConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {

                    decimal price = Decimal.Parse(txtPrice.Text);
                    if (String.IsNullOrEmpty(Request.QueryString["isbn"]))
                    {
                        string query = "INSERT INTO TBooks (ISBN, Title, Author, PublishDate, Price, Publish) " +
                   "VALUES(@ISBN, @Title, @Author, @PublishDate, @Price, @Publish)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@ISBN", txtIsbn.Text.Trim());
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                            cmd.Parameters.AddWithValue("@PublishDate", DateTime.Parse(txtPublishDate.Text));
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Publish", txtPublish.Checked);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        Response.Redirect("Books.aspx");
                    }
                    else
                    {
                        string query = "UPDATE  TBooks SET ISBN=@ISBN, Title=@Title, Author=@Author, PublishDate=@PublishDate, Price=@Price, Publish=@Publish " +
              "WHERE ISBN=@oldIsbn";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@ISBN", txtIsbn.Text.Trim());
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                            cmd.Parameters.AddWithValue("@PublishDate", DateTime.Parse(txtPublishDate.Text));
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Publish", txtPublish.Checked);
                            cmd.Parameters.AddWithValue("@oldIsbn", Request.QueryString["isbn"]);
                            conn.Open();
                            cmd.ExecuteNonQuery();


                            Response.Redirect("Books.aspx");
                        }


                    }
                }
            }

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");

        }

        public bool ValidateInputs()
        {
            DateTime publishDate;
            decimal price;
            bool publish = txtPublish.Checked;
            string isbn = txtIsbn.Text.Trim();
            int counter = 0;
            
            TextBox[] fields = { txtAuthor, txtIsbn, txtTitle, txtPublishDate, txtPrice };
            if (fields.Any(f => string.IsNullOrWhiteSpace(f.Text)))
            {
                lblMessage.Text = "All fields must be filled.";
                counter++;
            }
            if (DateTime.TryParse(txtPublishDate.Text.Trim(), out publishDate))
            {

                if (publish && publishDate > DateTime.Now)
                {
                    Label4.Text = "Publish date cannot be in the future when publishing.";
                    counter++;
                }
                else if (!publish && publishDate <= DateTime.Now)
                {
                    Label4.Text = "Unpublished books cannot have a publish date in the past or today.";
                    counter++;
                }
                else
                {
                    Label4.Text = "";
                }
            }
            if (!decimal.TryParse(txtPrice.Text.Trim(), out price))
            {
                price = 0;
                counter++;
            }
            else
            {
                if (price <= 0)
                {
                    priceError.Text = "The value of a book can't be smaller than Zero";
                    counter++;
                }
                else
                {
                    priceError.Text = "";
                }
            }

            if (Request.QueryString["isbn"] == null)
            {

                DataTable dt = LoadBookData(isbn);
                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "ISBN already exists.";
                    counter++;
                }

            }
            else if (!Request.QueryString["isbn"].Equals(isbn))
            {
               
                DataTable dt = LoadBookData(isbn);
                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "ISBN already exists.";
                    counter++;
                }
            }
        

            if (counter > 0)
            {
                return false;
            }


            return true;

        }
    }
}