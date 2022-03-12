using Grpc.Core;
using Grpc.Data.Repositories.Abstract;
using ProjectModule.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectModule.Grpc.Services
{
    public class ProjectService : ProjectPBProtoService.ProjectPBProtoServiceBase
    {
        private readonly IRepository _repository;

        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }
        public override  async Task<VerifyProjectResponse> VerifyProjectExist(VerifyProjectRequest request, ServerCallContext context)
        {
          //  bool res = false;
            VerifyProjectResponse rp = new VerifyProjectResponse();
            var exist =await  _repository.Exist(request.Id);
            if(exist)
            {
                rp.Exist = true;
                   
            } else
            {
                rp.Exist = false;
            }
            
            //   return base.VerifyProjectExist(request, context);

          
            return rp;
        }
    }
}
