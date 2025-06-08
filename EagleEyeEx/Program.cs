using System;
using System.Collections.Generic;
using System.IO.Ports;
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
            //הכנסת המחרוזת של קונקשן שמתאימה לmysql
            AgentDAL dal = new AgentDAL("server = localhost; " + "user=root;" + "database=eagleeyedb;" + "port=3306;");

            //יצירת מופע לAgent כדי להוסיף אותו לפונקתיה של ההוספה
            Agent agent1 = new Agent("Shadow", "Liam Smith", "Berlin", statusenum.Active);
            //בדיקה לפונקציה של ההוספה
            dal.AddAgent(agent1);
            //בדיקה לפונקציה של הקריאה מקבל ליסט של מופעיםם ורץ על זה ומחזיר את כל הערכים של כל מופע
            List<Agent> listagent = dal.GetAllAgents();
            foreach (Agent agent in listagent)
            {
                Console.WriteLine($"Id: {agent.Id}, CodeName: {agent.CodeName}, RealName: {agent.RealName}, Location: {agent.Location}, Status: {agent.Status}, MissionsCompleted: {agent.MissionsCompleted}");
            }
            //קריאה לפונקציה של השינוי של ערך מסוים בתנאי מסוים
            dal.UpdateAgentLocation(10, "Paris");
            //קריאה לפונקציה שמוחקת שורה 
            dal.DeleteAgent(11);

        }
            
    }
}
