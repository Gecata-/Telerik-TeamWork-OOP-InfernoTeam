﻿namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameLogic.Map.Fields;
    using GameLogic.Exceptions;
    using System.Drawing;
    using System.Collections;

    public class GameMap : IEnumerable<Field>
    {
        public static GameMap TestMap = CreateTestMap();

        private static GameMap CreateTestMap()
        {
            GameMap testMap = new GameMap(5, 12, 4, 11, Direction.Left);

            // add neighbourhood center
            Neighbourhood center = new Neighbourhood("Center", Color.DarkRed);

            Street patriarhaStreet = new Street("Patriarha", center, 4, 10);
            testMap.AddField(patriarhaStreet, new Field[] { testMap.Start });

            Street pirotskaStreet = new Street("Pirotska", center, 4, 9);
            testMap.AddField(pirotskaStreet, new Field[] { patriarhaStreet });

            Crossroad cross1 = new Crossroad("cross1", Color.Magenta, 4, 8);
            testMap.AddField(cross1, new Field[] { pirotskaStreet });

            Street vitoshkaStreet = new Street("Vitoshka", center, 4, 7);
            testMap.AddField(vitoshkaStreet, new Field[] { cross1 });

            // add many empty fields for test purpose
            EmptyField emptyField1 = new EmptyField("EmptyField1", Color.White, 4, 6);
            testMap.AddField(emptyField1, new Field[] { vitoshkaStreet });
            EmptyField emptyField2 = new EmptyField("EmptyField2", Color.White, 4, 5);
            testMap.AddField(emptyField2, new Field[] { emptyField1 });
            EmptyField emptyField3 = new EmptyField("EmptyField3", Color.White, 3, 5);
            testMap.AddField(emptyField3, new Field[] { emptyField2 });
            EmptyField emptyField4 = new EmptyField("EmptyField4", Color.White, 2, 5);
            testMap.AddField(emptyField4, new Field[] { emptyField3 });
            EmptyField emptyField5 = new EmptyField("EmptyField5", Color.White, 2, 6);
            testMap.AddField(emptyField5, new Field[] { emptyField4 });
            EmptyField emptyField6 = new EmptyField("EmptyField6", Color.White, 2, 7);
            testMap.AddField(emptyField6, new Field[] { emptyField5 });
            EmptyField emptyField7 = new EmptyField("EmptyField7", Color.White, 2, 8);
            testMap.AddField(emptyField7, new Field[] { emptyField6 });
            EmptyField emptyField8 = new EmptyField("EmptyField8", Color.White, 2, 9);
            testMap.AddField(emptyField8, new Field[] { emptyField7 });
            EmptyField emptyField9 = new EmptyField("EmptyField9", Color.White, 2, 10);
            testMap.AddField(emptyField9, new Field[] { emptyField8 });
            EmptyField emptyField10 = new EmptyField("EmptyField10", Color.White, 2, 11);
            testMap.AddField(emptyField10, new Field[] { emptyField9 });
            EmptyField emptyField11 = new EmptyField("EmptyField11", Color.White, 3, 11);
            testMap.AddField(emptyField11, new Field[] { emptyField10 });
            EmptyField emptyField12 = new EmptyField("EmptyField12", Color.White, 3, 8);
            testMap.AddField(emptyField12, new Field[] { cross1 });
            EmptyField emptyField13 = new EmptyField("EmptyField13", Color.White, 3, 9);
            testMap.AddField(emptyField13, new Field[] { emptyField12 });
            emptyField13.NextFields.Add(emptyField8);
            emptyField11.NextFields.Add(testMap.Start);


            return testMap;
        }

        public Field[,] FieldsMatrix { get; private set; }

        internal GameMap(int mapRows, int mapCols, int startRow, int startColumn, Direction startDirection)
        {
            this.FieldsMatrix = new Field[mapRows, mapCols];
            this.Start = new StartField(Color.WhiteSmoke, startRow, startColumn, startDirection);
            this.FieldsMatrix[startRow, startColumn] = this.Start;
        }

        public StartField Start { get; set; }

        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            foreach (var fields in firstField.NextFields)
            {
                var tempFiled = fields;
                for (int i = 0; i < diceValue - 1; i++)
                {
                    tempFiled = tempFiled.NextFields[0];
                }
                if (tempFiled == secondField)
                {
                    return true;
                }

            }

            return false;
        }

        internal void AddField(Field fieldToBeAdd, Field[] previousFields)
        {
            if (FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] != null)
            {
                throw new InvalidOperationException("You try to add field on position(row, col), where already exists one!");
            }

            if (previousFields.Length < 1)
            {
                throw new GameMapInvalidConnectivityException("Every field must have at least one previous field", fieldToBeAdd);
            }

            this.FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] = fieldToBeAdd;

            foreach (var field in previousFields)
            {
                field.NextFields.Add(fieldToBeAdd);
                fieldToBeAdd.PrevFields.Add(field);
            }
        }

        public IEnumerator<Field> GetEnumerator()
        {
            HashSet<Field> mapFields = new HashSet<Field>();
            GetAllFields(this.Start, mapFields);

            return mapFields.GetEnumerator();
        }

        private void GetAllFields(Field currField, ICollection<Field> mapFields)
        {
            if (mapFields.Contains(currField))
            {
                return;
            }
            else
            {
                mapFields.Add(currField);

                foreach (var field in currField.NextFields)
                {
                    GetAllFields(field, mapFields);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}