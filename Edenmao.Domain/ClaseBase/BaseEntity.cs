﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Domain.ClaseBase
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.Eliminado = false;
        }
        [Key]
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Eliminado { get; set; }
    }
}
