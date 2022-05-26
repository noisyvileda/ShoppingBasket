using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.SQLService
{
    public class DataHandler
    {
        public DataSet GetProductDataSet()
        {
            DataSet ds = new DataSet();
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingData.mdf;Integrated Security=True");
            using(SqlCommand cmd = new SqlCommand("Select * from dbo.Products",connection))
            {
                cmd.Connection.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                ds.Tables.Add(dataTable);                               
            }
           return ds;            
        }
        public DataSet GetOffersDataSet()
        {
            DataSet ds = new DataSet();
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingData.mdf;Integrated Security=True");
            using (SqlCommand cmd = new SqlCommand("Select * from dbo.SpecialOffers", connection))
            {
                cmd.Connection.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                ds.Tables.Add(dataTable);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                }
            }
            return ds;
        }
    }
}
