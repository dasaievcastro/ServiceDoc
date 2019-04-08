using System;
using System.Threading.Tasks;

namespace Domain.Context
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
