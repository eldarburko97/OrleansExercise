using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrleansExercise.Grains
{
    public class StudentGrainState
    {
        public bool RetrievedList { get; set; }
        public List<Models.Student> students { get; set; }
    }
}
