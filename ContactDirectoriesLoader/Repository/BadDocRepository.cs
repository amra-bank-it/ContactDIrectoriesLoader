using ContactDirectoriesLoader.Repository.Base;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ContactDirectoriesLoader.Repository
{
    public class BadDocRepository : BaseRepository<BadDoc>
    {
        public BadDocRepository(IDbContext dbContext) : base(dbContext)
        {
        }

    }
}
