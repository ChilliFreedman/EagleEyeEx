using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace DAL
{
    public class AgentDAL
    {
        private string ConnectionString; 
        public AgentDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public void AddAgent(Agent agent)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);

            conn.Open();

            string query = @"INSERT INTO agents (codeName, realName, location, status)
                  VALUES (@codeName, @realName, @location, @status)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@codeName", agent.CodeName);
            cmd.Parameters.AddWithValue("@realName", agent.RealName);
            cmd.Parameters.AddWithValue("@location", agent.Location);
            cmd.Parameters.AddWithValue("@status", agent.Status.ToString());
      
            cmd.ExecuteNonQuery();
            conn.Close();

        }




        public List<Agent> GetAllAgents()
        {
            List<Agent> listagent = new List<Agent>();

            MySqlConnection conn = new MySqlConnection(ConnectionString);

            conn.Open();

            string query = "SELECT * FROM agents";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                int Id = reader.GetInt32("id");
                   string CodeName = reader.GetString("codeName");
                   string RealName = reader.GetString("realName");
                   string Location = reader.GetString("location");
                   statusenum Status = (statusenum)Enum.Parse(typeof(statusenum), reader.GetString("status"));
                int MissionsCompleted = reader.GetInt32("missionsCompleted");

                Agent agent = new Agent(Id, CodeName, RealName, Location, Status, MissionsCompleted);
                listagent.Add(agent);
            }

            reader.Close();  
            conn.Close();    

            return listagent;

        }
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            string query = "UPDATE agents SET location = @location WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@location", newLocation);
            cmd.Parameters.AddWithValue("@id", agentId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteAgent(int agentId)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            string query = "DELETE FROM agents WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", agentId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }






    }
}
