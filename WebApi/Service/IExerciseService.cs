using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Service
{
    public interface IExerciseService
    {
        List<SysAnswer> Answers { get; }
        Exercise CreateExercise(int correctCount);
        int CountCorrectAnswers(UserAnswer userAnswer);
    }
}
