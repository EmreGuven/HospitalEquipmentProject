using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Clinic:IEntity
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }

    }
}
