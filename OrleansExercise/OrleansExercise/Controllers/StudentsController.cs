using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using OrleansExercise.Grains;
using OrleansExercise.Models;
using OrleansExercise.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrleansExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IClusterClient _clusterClient;

        //List<Database.Student> students = null;
        public StudentsController(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
            //students = new List<Database.Student>();
            //students.Add(new Database.Student { Id = 1, FirstName = "Eldar", LastName = "Burko", Address = "Nugle II 4/b", Phone = "062 440 933" });
            //students.Add(new Database.Student { Id = 2, FirstName = "Haris", LastName = "Agic", Address = "Mostarska bb", Phone = "061 765 143" });
            //students.Add(new Database.Student { Id = 3, FirstName = "Dzenis", LastName = "Brkan", Address = "Mostarska bb", Phone = "062 543 556" });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _clusterClient.GetGrain<IStudentGrain>(Guid.NewGuid()).Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentInsertRequest request)
        {
            try
            {
                //var result = await _clusterClient.GetGrain<IStudentGrain>(Guid.NewGuid()).Insert(request);
                //return StatusCode(StatusCodes.Status201Created, result);

                var result = await _clusterClient.GetGrain<IStudentGrain>(Guid.NewGuid()).Insert(request);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
