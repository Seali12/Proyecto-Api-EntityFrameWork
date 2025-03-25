using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace DataAccess.Generic
{
    public interface IUnitOfWork : IDisposable
    {

        ProyectoFinalContext Context { get; }
        void Commit();

    }
    public class UnitOfWork : IUnitOfWork
    {
        public ProyectoFinalContext Context { get; }
        public UnitOfWork(ProyectoFinalContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
