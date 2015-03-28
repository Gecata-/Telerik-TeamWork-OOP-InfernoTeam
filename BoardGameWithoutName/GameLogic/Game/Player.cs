﻿namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
   
    using GameLogic.Map;
    using GlobalConst;
    using GameLogic.Map.Fields;
using System.Drawing;

    public class Player
    {
        
        private readonly string name;
        private Field field;
        private int healthStatus;
        private int moneyStatus;
      

        private int[] countOfRolls; // Every Player have 1 Attempt fo roll a dice.
   
        internal Player(string namePlayer, Field field)
        {
            this.HealthStatus = GlobalConst.InitialHealth;
            this.MoneyStatus = GlobalConst.InitialMoney;

            this.Field = field;
            this.Name = namePlayer;
        }

        public Field Field { get; set; }

        public int MoneyStatus { get; private set; }

        public int HealthStatus { get; private set; }

        public string Name { get; private set; }

        public void TakeHealth(int value)
        {
            this.HealthStatus -= value;
            
            if (this.HealthStatus < 10)
            {
                this.HealthStatus = 10;
            }
        }

        public void Buy(int moneyForTheStreet) 
        {
            if (this.MoneyStatus < moneyForTheStreet) { return; }
            this.MoneyStatus = this.MoneyStatus - moneyForTheStreet;
        }
        internal void MyTurn(Field targetField)
        {
            this.Field.Leave(this);
            targetField.Visit(this);
            if (targetField is Street) 
            {
                var streetStepOn = targetField as Street;
                if (streetStepOn.Owner != null && streetStepOn.Owner!=this) 
                {
                    PayRent(streetStepOn);
                }
                else if (streetStepOn.Neighbourhood.Owner ==this) 
                {
                    BuildHouse(streetStepOn);
                }
                else
                {
                    Buy(streetStepOn.Price);
                }
            }
        }

        private void BuildHouse(Street currentStreet)
        {
            if (this.MoneyStatus < currentStreet.building.Price) { return; }
            this.MoneyStatus = this.MoneyStatus - currentStreet.building.Price;
        }

        private void PayRent(Street currentStreet) 
        {
            currentStreet.Owner.moneyStatus += currentStreet.Rent;
            this.MoneyStatus = this.MoneyStatus - currentStreet.Rent;
        }
    }
}
