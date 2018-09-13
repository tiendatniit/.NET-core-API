using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public partial class Team
    {
        public Team()
        {
            InverseSport = new HashSet<Team>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FoundingDate { get; set; }
        public int? Sportid { get; set; }

        [ForeignKey("Sportid")]
        [InverseProperty("InverseSport")]
        public Team Sport { get; set; }
        [InverseProperty("Sport")]
        public ICollection<Team> InverseSport { get; set; }
    }
}
