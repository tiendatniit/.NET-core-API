using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class SportTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sportid { get; set; }
        public string SportName { get; set; }
        public SportTeam(int _id, string _name, int _sportid, string _sportName)
        {
            this.Id = _id;
            this.Name = _name;
            this.Sportid = _sportid;
            this.SportName = _sportName;
        }
    }
}
