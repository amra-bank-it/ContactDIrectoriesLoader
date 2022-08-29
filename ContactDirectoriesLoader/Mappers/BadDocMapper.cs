using ContactDirectoriesLoader.Contracts;
using ContactDirectoriesLoader.Models;
using ContactDirectoriesLoader.Repository.Entities;
using ContactDirectoriesLoader.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Mappers
{
    internal class BadDocMapper : IMapper<BadDocModel, BadDoc>
    {
        public BadDoc Map(BadDocModel badmod)
        {
            return new BadDoc()
            {
              Version = badmod.Version,
              Erased = badmod.Erased,
              Id = badmod.ID,
              Country = badmod.COUNTRY,
              nDoc = badmod.N_DOC,
              sDoc = badmod.S_DOC,
              info = badmod.INFO,
              info1 = badmod.INFO1,
              c10 = badmod.c10,
              c11 = badmod.c11,
              TypeDoc = badmod.TYPDOC,
              blocked = badmod.BLOCKED
            };
        }
    }
}
