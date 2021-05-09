using System;
using System.Collections.Generic;
using System.Security.AccessControl;
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
    public class ClinicManager:IClinicServis
    {
        readonly IClinicDal _clinicDal;

        public ClinicManager(IClinicDal clinicDal)
        {
            _clinicDal = clinicDal;
        }

        [ValidationAspect(typeof(ClinicValidator))]
        public async Task<IResult> Add(Clinic clinic)
        {
            await _clinicDal.Add(clinic);
            return new SuccessResult(Messages.ClinicAdded);
        }

        public async Task<IResult> Delete(Clinic clinic)
        {
            await _clinicDal.Delete(clinic);
            return new SuccessResult(Messages.ClinicDeleted);
        }

        [ValidationAspect(typeof(ClinicValidator))]
        public async Task<IResult> Update(Clinic clinic)
        {
            await _clinicDal.Update(clinic);
            return new SuccessResult(Messages.ClinicUpdated);
        }

        public async Task<IDataResult<List<Clinic>>> GetAll()
        {
            return  new SuccessDataResult<List<Clinic>>(await _clinicDal.GetAll() , Messages.ClinicListed);
        }

        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<Clinic>> GetById(int clinicId)
        {
            return new SuccessDataResult<Clinic>(await _clinicDal.Get(c => c.ClinicId == clinicId));
        }
    }
}
