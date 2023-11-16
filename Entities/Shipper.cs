using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Shippers")]
    public class Shipper : IEntity
    {
        [Column("ShipperID")]
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
