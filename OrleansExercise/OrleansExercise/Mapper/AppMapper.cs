using AutoMapper;
using OrleansExercise.Database;
using OrleansExercise.Models;
using OrleansExercise.Requests;

namespace OrleansExercise.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Student, StudentInsertRequest>().ReverseMap();
        }
    }
}