using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
     public interface IPersonService<PersonModel>
    {
        Task<List<PersonModel>> GetAll();
        Task<PersonModel> GetById(int id);
        Task<bool> DeleteEmployee(int id);
        Task Create(PersonModel employee);
        Task Update(PersonModel employee);
       
       
    }
}
