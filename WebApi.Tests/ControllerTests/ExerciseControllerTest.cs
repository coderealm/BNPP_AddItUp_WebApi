using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Tests.ControllerTests
{
    [TestClass]
    public class ExerciseControllerTest
    {
        [TestMethod]
        public void GetExercise_returns_an_instance_of_exercise_type()
        {
            Mock<IExerciseService> mockExerciseService = new Mock<IExerciseService>();
            int correctCount = 0;
            ExerciseController exerciseController = new ExerciseController(mockExerciseService.Object);
            mockExerciseService.Setup(x => x.CreateExercise(correctCount)).Returns(() => new Exercise());
            Exercise exercise = exerciseController.GetExercise();
            Assert.IsInstanceOfType(exercise, typeof(Exercise));
        }

        [TestMethod]
        public void PostAnswer_returns_an_instance_of_exercise_type()
        {
            UserAnswer userAnswer = new UserAnswer { QuestionId = "someguid", Answer = 2 };
            Mock<IExerciseService> mockExerciseService = new Mock<IExerciseService>();
            int correctCount = 0;
            ExerciseController exerciseController = new ExerciseController(mockExerciseService.Object);
            mockExerciseService.Setup(x => x.CountCorrectAnswers(userAnswer)).Returns(() => It.IsAny<int>());
            mockExerciseService.Setup(x => x.CreateExercise(correctCount)).Returns(() => new Exercise());
            Exercise exercise = exerciseController.GetExercise();
            Assert.IsInstanceOfType(exercise, typeof(Exercise));
        }
    }
}
