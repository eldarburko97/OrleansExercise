using AutoMapper;
using OrleansExercise.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrleansExercise.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Database.Student, Models.Student>().ReverseMap();
            CreateMap<Database.Student, StudentInsertRequest>().ReverseMap();
        }
    }
}
