using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Model;

namespace WebApi.Tests.ExcerciseTests
{
    [TestClass]
    public class ExerciseTest
    {
        [TestMethod]
        public void CreateExercise_returns_an_instance_of_exercise_type()
        {
            int correctCount = 0;
            Exercise exercise = new Exercise().CreateExercise(correctCount);
            Assert.IsInstanceOfType(exercise, typeof(Exercise));
        }
    }
}
