using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Infrastructure.Repositories
{
    public class ArticuloRepository : RepositoryBase<Articulo>
    {
        private readonly ApplicationDbContext _context;
        public ArticuloRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
