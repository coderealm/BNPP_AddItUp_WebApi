using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Tests.ExcerciseServiceTests
{
    [TestClass]
    public class ExerciseServiceTest
    {
        [TestMethod]
        public void CreateExercise_returns_an_instance_of_exercise_type()
        {
            Mock<IExercise> mockExercise = new Mock<IExercise>();
            int correctCount = 0;
            mockExercise.Setup(x => x.CreateExercise(correctCount)).Returns(() => new Exercise());
            ExerciseService exerciseService = new ExerciseService(mockExercise.Object);
            Exercise exercise = exerciseService.CreateExercise(correctCount);
            Assert.IsInstanceOfType(exercise, typeof(Exercise));
        }

        [TestMethod]
        public void SaveExcerciseAnswer_increase_the_list_count_by_one()
        {
            Exercise exercise = new Exercise { FirstNumber = 1, SecondNumber = 2, Level = "Beginner", QuestionId = "someguid" };
            Mock<IExercise> mockExercise = new Mock<IExercise>();
            ExerciseService exerciseService = new ExerciseService(mockExercise.Object);
            exerciseService.SaveExcerciseAnswer(exercise);
            Assert.IsTrue(exerciseService.Answers.Count == 1);
        }

        [TestMethod]
        public void CountCorrectAnswers_increase_the_count_by_one()
        {
            int actualCount = 1;
            Exercise exercise = new Exercise { FirstNumber = 1, SecondNumber = 1, Level = "Beginner", QuestionId = "someguid" };
            Mock<IExercise> mockExercise = new Mock<IExercise>();
            ExerciseService exerciseService = new ExerciseService(mockExercise.Object);
            exerciseService.Answers.Add(new SysAnswer { QuestionId = "someguid", Answer = 2 } );
            UserAnswer userAnswer = new UserAnswer { QuestionId = "someguid", Answer = 2 };

            int expectedCount = exerciseService.CountCorrectAnswers(userAnswer);
            Assert.IsTrue(expectedCount == actualCount);
        }

        [TestMethod]
        public void CountCorrectAnswers_set_the_count_to_zero()
        {
            int actualCount = 0;
            Exercise exercise = new Exercise { FirstNumber = 1, SecondNumber = 1, Level = "Beginner", QuestionId = "someguid" };
            Mock<IExercise> mockExercise = new Mock<IExercise>();
            ExerciseService exerciseService = new ExerciseService(mockExercise.Object);
            exerciseService.Answers.Add(new SysAnswer { QuestionId = "someguid", Answer = 2 });
            UserAnswer userAnswer = new UserAnswer { QuestionId = "someguid", Answer = 3 };
            int expectedCount = exerciseService.CountCorrectAnswers(userAnswer);
            Assert.IsTrue(expectedCount == actualCount);
        }
    }
}
