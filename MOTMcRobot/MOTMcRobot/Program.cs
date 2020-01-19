using Infrastructure;
using System.IO;

namespace MOTMcRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var gridLength = 5;
            var path = Directory.GetCurrentDirectory() + "/Commands/Commands.txt";
            var commands = new CommandReader(path).Read();
            new RobotController(gridLength, new CommandValidator(gridLength)).Execute(commands);
        }
    }
}
