﻿namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Street : Field
    {
        private StreetBuilding building;

        public Neighbourhood Neighbouhood { get; private set; }


        public  System.Drawing.Color ColorField
        {
            get { throw new NotImplementedException(); }
        }
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
