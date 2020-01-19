using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class RobotController
    {
        private Robot robot = new Robot();
        private readonly int gridLength;
        private readonly CommandValidator commandValidator;

        public RobotController(int gridLength, CommandValidator commandValidator)
        {
            this.gridLength = gridLength;
            this.commandValidator = commandValidator;
        }

        public Robot Execute(List<string> commands)
        {
            foreach(var command in commands)
            {
                if(command.StartsWith(Enum.GetName(typeof(Commands), Commands.PLACE)))
                {
                    Place(command);
                }
                else if(command == Enum.GetName(typeof(Commands), Commands.REPORT))
                {
                     Report();
                }
                else {
                    Move(command);
                }
            }

            return robot;
        }

        private void Place(string command)
        {
            robot = commandValidator.Place(command);
        }

        private void Move(string command)
        {
            Enum.TryParse<Commands>(command, out Commands commandParsed);
            switch (robot.Facing)
            {
                case Facing.NORTH:
                    if (commandParsed == Commands.LEFT)
                        robot.Facing = Facing.WEST;
                    else if (commandParsed == Commands.RIGHT)
                        robot.Facing = Facing.EAST;
                    else if (commandParsed == Commands.MOVE)
                        robot.PositionX++;
                    break;
                case Facing.EAST:
                    if (commandParsed == Commands.LEFT)
                        robot.Facing = Facing.NORTH;
                    else if (commandParsed == Commands.RIGHT)
                        robot.Facing = Facing.SOUTH;
                    else if (commandParsed == Commands.MOVE)
                        robot.PositionY++;
                    break;
                case Facing.SOUTH:
                    if (commandParsed == Commands.LEFT)
                        robot.Facing = Facing.EAST;
                    else if (commandParsed == Commands.RIGHT)
                        robot.Facing = Facing.WEST;
                    else if (commandParsed == Commands.MOVE)
                        robot.PositionX--;
                    break;
                case Facing.WEST:
                    if (commandParsed == Commands.LEFT)
                        robot.Facing = Facing.SOUTH;
                    else if (commandParsed == Commands.RIGHT)
                        robot.Facing = Facing.NORTH;
                    else if (commandParsed == Commands.MOVE)
                        robot.PositionY--;
                    break;
            }

            FallProtector(robot);
        }

        private Robot Report()
        {
            Console.WriteLine($"Robots position: {robot.PositionX},{robot.PositionY},{robot.Facing}");
            return robot;
        }

        private void FallProtector(Robot robot)
        {
            if (robot.PositionX < 0)
                robot.PositionX = 0;
            else if (robot.PositionX > gridLength)
                robot.PositionX = gridLength;

            if (robot.PositionY < 0)
                robot.PositionY = 0;
            else if (robot.PositionY > gridLength)
                robot.PositionY = gridLength;
        }
    }
}
