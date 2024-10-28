using Edenmao.Domain.Entities;
using Edenmao.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Infrastructure.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>
    {
        private readonly ApplicationDbContext _context;
        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
