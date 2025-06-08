using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;


namespace EagleEyeEx
{
    public class Program
    {
        static void Main(string[] args)
        {

            AgentDAL dal = new AgentDAL("server = localhost; " + "user=root;" + "database=eagleeyedb;" + "port=3306;");


            Agent agent1 = new Agent("Shadow", "Liam Smith", "Berlin", statusenum.Active);

            //dal.AddAgent(agent1);

            List<Agent> listagent = dal.GetAllAgents();
            foreach (Agent agent in listagent)
            {
                Console.WriteLine($"Id: {agent.Id}, CodeName: {agent.CodeName}, RealName: {agent.RealName }, Location: {agent.Location}, Status: {agent.Status}, MissionsCompleted: {agent.MissionsCompleted}");
            }

        }  
            
    }
}
