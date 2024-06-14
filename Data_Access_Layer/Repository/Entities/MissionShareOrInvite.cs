using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class MissionShareOrInvite
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string EmailAddress { get; set; }
        public string MissionShareUserEmailAddress { get; set; }
        public string baseUrl { get; set; }
        public int MissionId { get; set; }

    }
}