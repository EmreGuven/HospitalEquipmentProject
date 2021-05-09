using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class EquipmentManager:IEquipmentService
    {
        readonly IEquipmentDal _equipmentDal;

        public EquipmentManager(IEquipmentDal equipmentDal)
        {
            _equipmentDal = equipmentDal;
        }

        [ValidationAspect(typeof(EquipmentValidator))]
        public async Task<IResult> Add(Equipment equipment)
        {
            await _equipmentDal.Add(equipment);
            return new SuccessResult(Messages.EquipmentAdded);
        }

        public async Task<IResult> Delete(Equipment equipment)
        {
            await _equipmentDal.Delete(equipment);
            return new SuccessResult(Messages.EquipmentDeleted);
        }

        [ValidationAspect(typeof(EquipmentValidator))]
        public async Task<IResult> Update(Equipment equipment)
        {
            await _equipmentDal.Update(equipment);
            return new SuccessResult(Messages.EquipmentUpdated);
        }

        public async Task<IDataResult<List<Equipment>>> GetAll()
        {
            return new SuccessDataResult<List<Equipment>>(await _equipmentDal.GetAll() , Messages.EquipmentListed);
        }

        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<Equipment>> GetById(int equipmentId)
        {
            return new SuccessDataResult<Equipment>(await _equipmentDal.Get(e => e.EquipmentId == equipmentId));
        }
    }
}
