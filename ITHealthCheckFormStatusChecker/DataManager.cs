using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ITHealthCheckFormStatusChecker.InputOutputModel;

namespace ITHealthCheckFormStatusChecker
{
    class DataManager
    {
        List<string> Tickets = new List<string>();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        public List<string> FetchData()
        {
            try
            {
                
                string checkuser = "select TicketId from ITHealthCheckFormPortal where status = 'Open'";
                SqlCommand cmd = new SqlCommand(checkuser, connection);
                connection.Open();
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    Tickets.Add((string)reader1["TicketId"]);
                }
                connection.Close();
                return Tickets;
            }

            catch(Exception ex)
            {
                return Tickets;
            }
           
        }

        public void WriteData(List<KeyValuePair<string, string>> responselist)
        {
            try
            {
                connection.Open();
                foreach (KeyValuePair<string, string> kvp in responselist)
                {
                    string insertQuery = "update ITHealthCheckFormPortal set Status = '" + kvp.Value + "' WHERE TicketId = '" + kvp.Key + "';";
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

            catch(Exception ex)
            {

            }
            
        }  
    }
}
