﻿using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Infrastructure.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>
    {
        private readonly ApplicationDbContext _context;
        public PedidoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}