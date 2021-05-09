using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEquipmentService
    {
        Task<IResult> Add(Equipment equipment);
        Task<IResult> Delete(Equipment equipment);
        Task<IResult> Update(Equipment equipment);
        Task<IDataResult<List<Equipment>>> GetAll();
        Task<IDataResult<Equipment>> GetById(int equipmentId);
    }
}
