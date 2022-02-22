using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PersonDAL : IPersonDAL<PersonModel>
    {
        ApplicationDbContext _dbContext;
        public PersonDAL(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<int> Create(PersonModel _object)
        {
            int result;
            try
            {
                _dbContext.Add(_object);
                result = await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            if (id > 0)
            {
                var studentbyid = _dbContext.PersonModels.Where(x => x.Id == id).FirstOrDefault();
                if (studentbyid != null)
                {
                    _dbContext.Entry(studentbyid).State = EntityState.Deleted;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;

        }
        public async Task<List<PersonModel>> GetAll()
        {
            return await _dbContext.PersonModels.ToListAsync();
        }
        public async Task<PersonModel> GetById(int id)
        {
            var data = await _dbContext.PersonModels.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<bool> Update(PersonModel model)
        {
            var data = await _dbContext.PersonModels.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (data != null)
            {
                data.UserName = model.UserName;
                data.UserEmail = model.UserEmail;
                data.UserPassword = model.UserPassword;
                data.CreatedOn = model.CreatedOn;
                data.IsDeleted = model.IsDeleted;
                _dbContext.Entry(data).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

