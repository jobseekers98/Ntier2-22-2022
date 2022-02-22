using BAL.IService;
using DAL.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class PersonService : IPersonDAL<PersonModel>
    {

        private readonly IPersonDAL<PersonModel> _personDAL;

        public PersonService(IPersonDAL<PersonModel> personDAL)
        {
            _personDAL = personDAL;
        }
        public async Task<int> Create(PersonModel _object)
        {
            return await _personDAL.Create(_object);
        }

        public Task<bool> DeleteEmployee(int id)
        {
            return _personDAL.DeleteEmployee(id);
        }

        public Task<List<PersonModel>> GetAll()
        {
            return _personDAL.GetAll();
        }

        public Task<PersonModel> GetById(int id)
        {
            return _personDAL.GetById(id);
        }

        public Task<bool> Update(PersonModel model)
        {
            return _personDAL.Update(model);
        }
    }
}
