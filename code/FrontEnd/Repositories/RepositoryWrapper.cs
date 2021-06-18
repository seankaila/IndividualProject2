using FrontEnd.Data;
using FrontEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDBContext _repoContext;
        public RepositoryWrapper(ApplicationDBContext repoContext)
        {
            _repoContext = repoContext;
        }
        IHistoryRepository _historys;

        public IHistoryRepository Historys
        {
            get
            {
                if (_historys == null)
                {
                    _historys = new HistoryRepository(_repoContext);
                }
                return _historys;
            }
        }

        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
