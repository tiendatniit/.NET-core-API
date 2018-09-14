using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public partial class Sport
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public Sport(int _id, string _Name)
        {
            this.Id = _id;
            this.Name = _Name;
        }
    }
}
