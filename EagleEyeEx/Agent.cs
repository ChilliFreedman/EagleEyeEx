using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public enum statusenum {  Active, Injured, Missing, Retired}
    public class Agent
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public statusenum Status { get; set; }
        public int MissionsCompleted { get; set; }

        public Agent(string codeName, string realName, string location, statusenum status)
        {
            this.CodeName = codeName;
            this.RealName = realName;
            this.Location = location;
            this.Status = status;

        }

        public Agent(int id, string codeName, string realName, string location, statusenum status, int missionsCompleted)
        {
            this.Id = id;
            this.CodeName = codeName;
            this.RealName = realName;
            this.Location = location;
            this.Status = status;
            this.MissionsCompleted = missionsCompleted;
        }

        
    }
}
