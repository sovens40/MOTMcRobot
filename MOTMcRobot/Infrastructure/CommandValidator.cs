using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CommandValidator
    {
        private readonly int gridLength;

        public CommandValidator(int gridLength)
        {
            this.gridLength = gridLength;
        }

        public Robot Place(string placeCommandInput)
        {
            if (!placeCommandInput.StartsWith("PLACE"))
            {
                throw new InvalidOperationException("Command must start with PLACE");
            }
            placeCommandInput = placeCommandInput.Replace("PLACE", "").TrimStart();
            var placeCommands = placeCommandInput.Split(',');
            if(placeCommands.Length != 3)
            {
                throw new InvalidOperationException("PLACE command requires a X,Y,F");
            }
            if(!int.TryParse(placeCommands[0], out int positionX))
            {
                throw new InvalidOperationException("PLACE X needs to be a valid number");
            }
            if(positionX < 0 || positionX > gridLength)
            {
                throw new InvalidOperationException("PLACE X is invalid");
            }
            if (!int.TryParse(placeCommands[1], out int positionY))
            {
                throw new InvalidOperationException("PLACE Y needs to be a valid number");
            }
            if (positionY < 0 || positionY > gridLength)
            {
                throw new InvalidOperationException("PLACE Y is invalid");
            }
            var validFacing = Enum.TryParse<Facing>(placeCommands[2], out Facing facing);
            if (!validFacing)
            {
                throw new InvalidOperationException("PLACE F is an invalid direction");
            }
            
            var robot = new Robot();
            robot.PositionX = positionX;
            robot.PositionY = positionY;
            robot.Facing = facing;

            return robot;
        }
    }
}
