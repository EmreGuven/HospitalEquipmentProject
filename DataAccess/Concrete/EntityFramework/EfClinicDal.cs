using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClinicDal:IEntityRepositoryBase<Clinic,HospitalContext> , IClinicDal
    {
    }
}
