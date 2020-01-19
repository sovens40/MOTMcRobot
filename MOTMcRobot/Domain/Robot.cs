using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Robot
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Facing Facing { get; set; }
    }
}
