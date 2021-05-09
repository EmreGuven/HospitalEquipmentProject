using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Localization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private IClinicServis _clinicServis;
        private readonly IStringLocalizer<ClinicsController> _localizer;

        public ClinicsController(IClinicServis clinicServis , IStringLocalizer<ClinicsController> localizer)
        {
            _clinicServis = clinicServis;
            _localizer = localizer;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Clinic clinic)
        {
            var result =await _clinicServis.Add(clinic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(Clinic clinic)
        {
            var result = await _clinicServis.Delete(clinic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Clinic clinic)
        {
            var result =await _clinicServis.Update(clinic);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _clinicServis.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int clinicId)
        {
            var result =await _clinicServis.GetById(clinicId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
