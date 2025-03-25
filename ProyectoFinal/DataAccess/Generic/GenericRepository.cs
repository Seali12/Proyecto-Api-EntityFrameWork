using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Generic
{

    public interface IGenericRepository<T> where T : class
    {

        Task Create(T entity);
        Task Delete(T entity);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task Create(T entity)
        {
            try
            {
                _unitOfWork.Context.Add(entity);
               await _unitOfWork.Context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Delete(T entity)
        {
            _unitOfWork.Context.Remove(entity);
            await _unitOfWork.Context.SaveChangesAsync();

        }

    }
}
