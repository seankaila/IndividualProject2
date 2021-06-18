using FrontEnd.Data;
using FrontEnd.Interfaces;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    [ExcludeFromCodeCoverage]
    public class HistoryRepository : Repositroy<History>, IHistoryRepository
    {
        public HistoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        { 

        }
    }
}
