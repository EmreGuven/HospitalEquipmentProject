using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClinicServis
    {
        Task<IResult> Add(Clinic clinic);
        Task<IResult> Delete(Clinic clinic);
        Task<IResult> Update(Clinic clinic);
        Task<IDataResult<List<Clinic>>> GetAll();
        Task<IDataResult<Clinic>> GetById(int clinicId);
    }
}
