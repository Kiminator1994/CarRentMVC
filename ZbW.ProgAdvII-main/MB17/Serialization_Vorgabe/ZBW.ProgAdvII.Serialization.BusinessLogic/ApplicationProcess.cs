using System;
using System.Collections.Generic;
using System.Text.Json;
using ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises;
using ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._1;
using ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._2;
using ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._3;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic
{
    public class ApplicationProcess
    {
        private readonly IEnumerable<IExercise> _exercises = new List<IExercise>()
        {
            new Exercise1(),
            new Exercise2(),
            new Exercise3()
        };

        public void Run()
        {
            foreach (var exercise in _exercises)
            {
                var result = exercise.Execute();
                var fulfilledText = result.Finished ? "ERFÜLLT" : "NICHT ERFÜLLT";
                var color = result.Finished ? ConsoleColor.Green : ConsoleColor.Red;
                
                Console.ForegroundColor = color;
                Console.WriteLine($"Übung {exercise.GetNumber()}: {exercise.GetDescription()}");
                Console.WriteLine($"       {fulfilledText}");
            }
        }
    }
}