using System.Collections.Generic;
using System.Linq;
using WebApi.Model;

namespace WebApi.Service
{
    public class ExerciseService: IExerciseService
    {
        private static int correctCount = 0;
        private readonly IExercise _exercise;

        public List<SysAnswer> Answers { get; }

        public ExerciseService(IExercise exercise)
        {
            _exercise = exercise;
            Answers = new List<SysAnswer>();
        }

        public Exercise CreateExercise(int correctCount)
        {
            Exercise exercise = _exercise.CreateExercise(correctCount);
            SaveExcerciseAnswer(exercise);
            return exercise;
        }
        public void SaveExcerciseAnswer(Exercise excercise)
        {
            var answer = new SysAnswer { QuestionId = excercise.QuestionId, Answer = excercise.FirstNumber + excercise.SecondNumber };
            Answers.Add(answer);
        }

        public int CountCorrectAnswers(UserAnswer userAnswer)
        {
            var query = Answers.FirstOrDefault(q => q.QuestionId == userAnswer.QuestionId);

            if (query.Answer == userAnswer.Answer)
            {
                ++correctCount;
            }
            else
            {
                correctCount = 0;
            }

            return correctCount;
        }
    }
}
