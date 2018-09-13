using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public partial class Player
    {
        //pri int _id { get; set; }
        //public string _FirstName { get; set; }
        //public string _LastName { get; set; }
        //public DateTime _birthday { get; set; }


        public Player(int id ,string FirstName, string LastName, DateTime birthday)
        {
            InverseTeam = new HashSet<Player>();
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = birthday;
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        [InverseProperty("InverseTeam")]
        public Player Team { get; set; }
        [InverseProperty("Team")]
        public ICollection<Player> InverseTeam { get; set; }
    }
}
