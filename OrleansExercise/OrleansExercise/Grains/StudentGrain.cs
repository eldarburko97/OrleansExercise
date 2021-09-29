using AutoMapper;
using Orleans;
using OrleansExercise.Database;
using OrleansExercise.Models;
using OrleansExercise.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrleansExercise.Grains
{
    public class StudentGrain : Grain<StudentGrainState>, IStudentGrain
    {
        private readonly IMapper _mapper;
        private readonly OrleansDbContext _context;
        //List<Database.Student> students = null;
        public StudentGrain(OrleansDbContext context, IMapper mapper)
        {
            //students = new List<Database.Student>();
            //students.Add(new Database.Student { Id = 1, FirstName = "Eldar", LastName = "Burko", Address = "Nugle II 4/b", Phone = "062 440 933" });
            //students.Add(new Database.Student { Id = 2, FirstName = "Haris", LastName = "Agic", Address = "Mostarska bb", Phone = "061 765 143" });
            //students.Add(new Database.Student { Id = 3, FirstName = "Dzenis", LastName = "Brkan", Address = "Mostarska bb", Phone = "062 543 556" });
            _mapper = mapper;
            _context = context;
        }

        public Task<List<Models.Student>> Get()
        {
            var primaryKey = this.GetPrimaryKey();
            bool retreivedBefore = this.State.RetrievedList;

            return Task.FromResult(this.State.students);

       
            //return Task.FromResult(_mapper.Map<List<Models.Student>>(_context.Students.ToList()));
        }

        public async Task<Models.Student> Insert(StudentInsertRequest request)
        {

            var result = _mapper.Map<Database.Student>(request);
            //students.Add(result);
            //students.Add(new Database.Student { Id = request.Id, FirstName = request.FirstName, LastName = request.LastName, Address = request.Address, Phone = request.Phone });
            //return Task.FromResult(_mapper.Map<Models.Student>(result));

            var entity = _context.Students.Add(result);
            _context.SaveChanges();


            var primaryKey = this.GetPrimaryKey();
            var list = this.State.students;
            List<Models.Student> newList = new List<Models.Student>();
            foreach (var item in list)
            {
                newList.Add(item);
            }

            this.State.students = newList;
            await this.WriteStateAsync();

            return _mapper.Map<Models.Student>(entity.Entity);

            //return Task.FromResult(_mapper.Map<Models.Student>(entity.Entity));
        }
    }
}
