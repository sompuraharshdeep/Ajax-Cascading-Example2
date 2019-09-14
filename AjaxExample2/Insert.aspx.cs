using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AjaxExample2
{
    public partial class Insert : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        string opr, empName;
        protected void Page_Load(object sender, EventArgs e)
        {
            opr = Request.QueryString["opr"].ToString();
            if (opr == "search")
            {
                empName = Request.QueryString["name"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from employee where empId like('" + empName.ToString() + "%')", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Response.Write("<table style='boader= bold 1'>");
                Response.Write("<tr>");
                Response.Write("<td>"); Response.Write("Name"); Response.Write("</td>");
                Response.Write("<td>"); Response.Write("Email"); Response.Write("</td>");
                Response.Write("<td>"); Response.Write("Number"); Response.Write("</td>");

                Response.Write("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr["empName"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["empEmail"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["empContact"].ToString()); Response.Write("</td>");

                    Response.Write("</tr>");
                }
                Response.Write("</table>");
                con.Close();
            }

        }
    }
}