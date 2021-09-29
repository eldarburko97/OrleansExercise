using Orleans;
using OrleansExercise.Models;
using OrleansExercise.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrleansExercise.Grains
{
    public interface IStudentGrain : IGrainWithGuidKey
    {
        Task<List<Student>> Get();
        Task<Models.Student> Insert(StudentInsertRequest request);
    }
}
