using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using OrleansExercise.Models;
using OrleansExercise.Requests;

namespace OrleansExercise.Grains
{
    public interface IStudentGrain : IGrainWithGuidKey
    {
        Task<List<StudentModel>> Get();
        Task<StudentModel> Insert(StudentInsertRequest request);
    }
}