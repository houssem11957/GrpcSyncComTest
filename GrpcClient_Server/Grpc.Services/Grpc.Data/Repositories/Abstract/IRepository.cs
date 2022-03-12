using Grpc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Data.Repositories.Abstract
{
public  interface IRepository
    {
        public  Task<Project> GetByIdAsync(int id);
        public Task<List<Project>> GetAll();
        public Task<Project> Insert( Project proj);
        public Task<bool> Exist(int id);
        
    }
}
