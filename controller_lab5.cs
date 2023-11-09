// controller_lab5.cs

using Lab4_23.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController_lab5 : ControllerBase
    {
        private readonly Lab4Context _lab4Context;

        public DatabaseController_lab5(Lab4Context lab4Context)
        {
            _lab4Context = lab4Context;
        }

        [HttpGet("model1")]
        public IActionResult GetModel1()
        {
            // Utilizarea Include pentru a aduce modelele asociate Model2
            var model1WithInclude = _lab4Context.Models1_lab5.Include(m1 => m1.Models2).ToList();
            return Ok(model1WithInclude);
        }

        [HttpPost("model1")]
        public async Task<IActionResult> Create(Model1DTO model1Dto)
        {
            var newModel1 = new Model1_lab5
            {
                Id = Guid.NewGuid(),
                Name = model1Dto.Name,
                Models2 = new List<Model2_lab5>() // Inițializare pentru a evita NullReferenceException
            };

            await _lab4Context.AddAsync(newModel1);
            await _lab4Context.SaveChangesAsync();

            return Ok(newModel1);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Model1DTO model1Dto)
        {
            // Utilizarea Join pentru a aduce modelele asociate Model2
            var model1WithJoin = _lab4Context.Models1_lab5
                .Join(_lab4Context.Models2_lab5, m1 => m1.Id, m2 => m2.Model1Id, (m1, m2) => new { Model1 = m1, Model2 = m2 })
                .Where(joined => joined.Model1.Id == model1Dto.Id)
                .Select(joined => new Model1_lab5
                {
                    Id = joined.Model1.Id,
                    Name = joined.Model1.Name,
                    Models2 = new List<Model2_lab5> { joined.Model2 } // Inițializare pentru a evita NullReferenceException
                })
                .FirstOrDefault();

            if (model1WithJoin == null)
            {
                return BadRequest("Object does not exist");
            }

            model1WithJoin.Name = model1Dto.Name;
            _lab4Context.Update(model1WithJoin);
            await _lab4Context.SaveChangesAsync();

            return Ok(model1WithJoin);
        }
    }
}
