using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        // GET api/exercise
        [HttpGet]
        public Exercise GetExercise()
        {
            return _exerciseService.CreateExercise(0);
        }

        // POST api/exercise
        [HttpPost]
        public Exercise PostAnswer([FromBody]UserAnswer userAnswer)
        {
            int correctCount = _exerciseService.CountCorrectAnswers(userAnswer);
            return _exerciseService.CreateExercise(correctCount);
        }
    }
}
