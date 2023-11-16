﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Regions")]
    public class Region : IEntity
    {
        [Column("RegionID")]
        public int Id { get; set; }
        [Column("RegionDescription")]
        public string Description { get; set; }
    }
}
