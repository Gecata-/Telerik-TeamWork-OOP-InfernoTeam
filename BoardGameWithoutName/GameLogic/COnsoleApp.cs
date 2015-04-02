﻿namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Fields;
    using GameLogic.Fields.Institutions;
    using GameLogic.Game;
    using GameLogic.Map;
    using GameLogic.Disasters;
    public class ConsoleApp
    {
        public static void Main()
        {
            Bank bankFiled = new Bank("KTB", Color.Red, 2, 1);
            Player playerOne = new Player("Gosho", bankFiled, Color.AliceBlue);
            Console.WriteLine(playerOne.Name);
            Console.WriteLine(playerOne.Field.Color.Name);
            Console.WriteLine(playerOne.Field.Name);

            Dice dice= Dice.Instance;
           
            //Console.WriteLine(valueDice.DiceValue);
            //valueDice.RollingTheDice();
            //Console.WriteLine(valueDice.DiceValue);

            Virus virus = new Virus();
             
            Console.WriteLine(virus.PowerVirus);

            GameMap map = GameMap.TestMap;

            foreach (var item in GameMap.TestMap)
            {
                Console.WriteLine(item.Name);
            }
          //GameMap.FieldCanBeReached(map.FieldsMatrix.,4);
            var pole1=map.FieldsMatrix[4,10];
            var pole2=map.FieldsMatrix[4,7];
            Console.WriteLine(GameMap.FieldCanBeReached(pole1,pole2,3));
            
            //Console.WriteLine(MapValidator.ValidateMap(map));
        }

    }
}
