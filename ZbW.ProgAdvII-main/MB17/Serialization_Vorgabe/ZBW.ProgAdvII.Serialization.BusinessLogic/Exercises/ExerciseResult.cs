namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises
{
    public class ExerciseResult
    {
        public ExerciseResult(bool finished, string message)
        {
            Finished = finished;
            Message = message;
        }

        public bool Finished { get; set; }

        public string Message { get; set; }
    }
}