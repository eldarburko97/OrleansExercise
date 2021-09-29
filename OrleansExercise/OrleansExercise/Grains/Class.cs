using System;
using System.Linq;
using System.Threading.Tasks;
using Orleans.Runtime;
using OrleansExercise.Database;

namespace OrleansExercise.Grains
{
    public class StudentPersistentState : IPersistentState<Student>
    {
        private readonly OrleansDbContext _dbContext;

        public StudentPersistentState(OrleansDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ClearStateAsync()
        {
            _dbContext.Students.Remove(entity: State);
            _dbContext.SaveChanges();
        }

        public Task WriteStateAsync()
        {
            if (State != null)
            {
                var exists = _dbContext.Students.Any(predicate: k => k.Id == State.Id);
                if (exists)
                {
                    _dbContext.Students.Update(entity: State);
                }
                else
                {
                    _dbContext.Students.Add(entity: State);
                }

                _dbContext.SaveChanges();
            }

            return Task.CompletedTask;
        }

        public Task ReadStateAsync()
        {
            throw new NotImplementedException();
        }

        public string Etag { get; }
        public bool RecordExists { get; }
        public Student State { get; set; }
    }
}