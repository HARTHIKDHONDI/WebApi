using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPI_Pratices.Models;
namespace WebAPI_Pratices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurdPracController : ControllerBase
    {
        private readonly Databasecontext db;
        public CurdPracController(Databasecontext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("GetAllData")]
        public  Task<List<CurdModel>> GetAllData()
        {
            return db.CurdModel.FromSqlRaw<CurdModel>("GetAllData").ToListAsync();
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<int> Insert( CurdModel curdModel)
        {
            var parameter = new List<SqlParameter>();
            
            parameter.Add(new SqlParameter("@FullName", curdModel.FullName));
            parameter.Add(new SqlParameter("@DateOfBirth",Convert.ToDateTime( curdModel.DateOfBirth)));
            parameter.Add(new SqlParameter("@EmailID",curdModel.EmailID));
            parameter.Add(new SqlParameter("@Mobile",Convert.ToInt64( curdModel.Mobile)));
            parameter.Add(new SqlParameter("@Gender", curdModel.Gender));
            parameter.Add(new SqlParameter("@TypeOfWork",curdModel.TypeOfWork));
            parameter.Add(new SqlParameter("@Password", curdModel.Password));
            parameter.Add(new SqlParameter("@Status", curdModel.Status));

            var result = await Task.Run(() => db.Database
            .ExecuteSqlRawAsync(@"exec InsertStu @FullName,@DateOfBirth,@EmailID,@Mobile,@Gender,@TypeOfWork,@Password,@Status", parameter.ToArray()));
            
            return result;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<int> Update(CurdModel curdModel)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Id", Convert.ToInt32(curdModel.Id)));
            parameter.Add(new SqlParameter("@FullName", curdModel.FullName));
            parameter.Add(new SqlParameter("@DateOfBirth", Convert.ToDateTime(curdModel.DateOfBirth)));
            parameter.Add(new SqlParameter("@EmailID", curdModel.EmailID));
            parameter.Add(new SqlParameter("@Mobile", Convert.ToInt64(curdModel.Mobile)));
            parameter.Add(new SqlParameter("@Gender", curdModel.Gender));
            parameter.Add(new SqlParameter("@TypeOfWork", curdModel.TypeOfWork));
            parameter.Add(new SqlParameter("@Password", curdModel.Password));
            parameter.Add(new SqlParameter("@Status", curdModel.Status));

            var result = await Task.Run(() => db.Database
            .ExecuteSqlRawAsync(@"exec UpdateStu @Id,@FullName,@DateOfBirth,@EmailID,@Mobile,@Gender,@TypeOfWork,@Password,@Status", parameter.ToArray()));

            return result;
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<int>Delete(int Id)
        {
            return await Task.Run(() => db.Database.ExecuteSqlInterpolatedAsync($"DeleteStu {Id}"));
        }
    }
}
