﻿namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // this field do not offer any actions to players
    public class EmptyField : Field
    {
        public EmptyField(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }
    }
}
