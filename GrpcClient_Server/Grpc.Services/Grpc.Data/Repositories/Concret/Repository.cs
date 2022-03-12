using Grpc.Data.Context;
using Grpc.Data.Entities;
using Grpc.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Grpc.Data.Repositories.Concret
{
    public class Repository : IRepository
    {
      private  readonly  PDbContext _context;
       private readonly DbSet<Project> _projects;

        public Repository(DbContextOptions<PDbContext> options)
        {
            _context =new PDbContext(options);
            _projects = _context.Set<Project>();
        }
        public async  Task<bool> Exist(int id)
        {
            bool res = false;

            if (id > 0)
            {
                try
                {
                   var pr = await _projects.Where(temp => temp.id == id).ToListAsync();
                    if(pr.Count>0 )
                    {
                        res = true;
                    }
                }
                catch (Exception exp)
                {

                }
            }
            return res;
        }

        public async Task<List<Entities.Project>> GetAll()
        {
              List<Project> res = new List<Project>();
           
                try
                {
                    res = await _projects.ToListAsync();

                }
                catch (Exception exp)
                {

                }
            
            return res;
        }

        public async  Task<Entities.Project> GetByIdAsync(int id)
        {
            var res = new Project();
            if (id > 0)
            {
                try
                {
                     res = await _projects.Where(temp => temp.id == id).FirstOrDefaultAsync();

                }
                catch (Exception exp)
                {

                }
            }
            return res;
        }

        public Task<Entities.Project> Insert(Entities.Project proj)
        {
            throw new NotImplementedException();
        }
    }
}
