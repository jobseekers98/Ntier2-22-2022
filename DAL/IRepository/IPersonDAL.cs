using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IPersonDAL<PersonModel>
    {
        Task<List<PersonModel>> GetAll();
        Task<PersonModel> GetById(int id);
        Task<int> Create(PersonModel _object);
        Task<bool> Update(PersonModel model);
        Task<bool> DeleteEmployee(int id);
    }
}
