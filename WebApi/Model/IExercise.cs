using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public interface IExercise
    {
        string QuestionId { get; set; }
        int FirstNumber { get; set; }
        int SecondNumber { get; set; }
        string Level { get; set; }
        Exercise CreateExercise(int correctCount);
    }
}
