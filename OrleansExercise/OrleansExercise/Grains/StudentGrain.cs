using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;
using OrleansExercise.Database;
using OrleansExercise.Models;
using OrleansExercise.Requests;

namespace OrleansExercise.Grains
{
    public class StudentGrain : Grain<Student>, IStudentGrain
    {
        private readonly IPersistentState<Student> _persistent;

        public StudentGrain(IPersistentState<Student> persistent)
        {
            _persistent = persistent;
        }

        public async Task<List<StudentModel>> Get()
        {
            if (State != null)
            {
                await _persistent.ReadStateAsync();
            }

            return State;
        }

        public Task<StudentModel> Insert(StudentInsertRequest request)
        {
            throw new NotImplementedException();
        }
    }
}