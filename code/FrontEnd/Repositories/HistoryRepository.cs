using FrontEnd.Data;
using FrontEnd.Interfaces;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    public class HistoryRepository : Repositroy<History>, IHistoryRepository
    {
        public HistoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        { 

        }
    }
}
