using System;
using System.Collections.Generic;

namespace WebApi.Model
{
    public class Exercise: IExercise
    {
        public string QuestionId { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public string Level { get; set; } 

        public Exercise() {
        }

        // Method to create an exercise of type a + b = ?
        public Exercise CreateExercise(int correctCount)
        {
            Exercise excercise = CreateQuestion(correctCount);
            return excercise;
        }

        private Exercise CreateQuestion(int correctCount)
        {
            return new Exercise() { Level = AssignUserLevel(correctCount), QuestionId = CreateQuestionId(), FirstNumber = GenerateRandomNumber(), SecondNumber = GenerateRandomNumber() };
        }

        private int GenerateRandomNumber()
        {
            return new Random().Next(1, 100);
        }

        private string CreateQuestionId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        private string AssignUserLevel(int correctCount)
        {
            string level = Level;
            var ranks = GetRanks();
            if (correctCount % 3 == 0)
            {
                level = ranks[correctCount];
            }
            else
            {
                var floor = Math.Floor(correctCount % 3.0);
                var previousLevel = (int)(correctCount - floor);
                level = ranks[previousLevel];
            }

            return level;
        }

        private Dictionary<int, string> GetRanks()
        {
           return new Dictionary<int, string> { { 0, "Beginner" }, { 3, "Talented" }, { 6, "Intermediate" }, { 9, "Advanced" }, { 12, "Expert" } };
        }

    }
}
