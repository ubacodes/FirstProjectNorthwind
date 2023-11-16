using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Territories")]
    public class Territory : IEntity
    {
        [Column("TerritoryID")]
        public int Id { get; set; }
        public int RegionId { get; set; }

        [Column("TerritoryDescription")]
        public string Description { get; set; }

    }
}
