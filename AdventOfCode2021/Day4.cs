using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day4
    {
        public static int PartOne()
        {
            var lines = File.ReadLines("aoc4.txt").ToList();
            string[] values = lines[0].Split(",");

            List<Card> cards = GetCards(lines);

            return CallNumbers(values, cards);
        }

        private static int CallNumbers(string[] values, List<Card> cards)
        {
            foreach(var value in values)
            {
                foreach(var card in cards)
                {
                    if (card.Mark(value))
                    {
                        return card.GetValue(int.Parse(value));
                    }
                }
            }
            return 0;
        }

        private static List<Card> GetCards(List<string> lines)
        {
            List<Card> cards = new List<Card>() { new Card() };

            for(int i = 1; i < lines.Count; i++)
            {
                if(!cards[cards.Count - 1].AddRow(lines[i]))
                {
                    cards.Add(new Card());
                    cards[cards.Count - 1].AddRow(lines[i]);
                }
            }

            return cards;
        }
    }

    internal class Card
    {
        public string[][] Board { get; set; }
        public int NumRows { get; set; }
        public int NumberMarked { get; set; }
        public Card()
        {
            Board = new string[5][];
            NumRows = 0;
            NumberMarked = 0;
        }

        public bool AddRow(string row)
        {
            if(NumRows == 5)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(row))
            {
                string[] values = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Board[NumRows] = values;

                NumRows++;
            }

            return true;
        }

        public bool Mark(string number)
        {
            for(int x = 0; x < 5; x++)
            {
                for(int y = 0; y < 5; y++)
                {
                    if(Board[x][y] == number)
                    {
                        Board[x][y] = "X"+Board[x][y];
                        NumberMarked++;

                        if(CheckVertical()
                        || CheckHorizontal()
                        || CheckDiagonal())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int GetValue(int finalNumber)
        {
            int sum = 0;
            for(int x = 0; x < 5; x++)
            {
                for(int y = 0; y < 5; y++)
                {
                    if(!Board[x][y].Contains("X"))
                    {
                        sum += int.Parse(Board[x][y]);
                    }
                }
            }
            return sum * finalNumber;
        }

        private bool CheckDiagonal()
        {
            bool possibleGoingDown = true;
            bool possibleGoingUp = true;
            for(int i = 0; i < 5; i++)
            {
                if(possibleGoingDown && !Board[i][i].Contains("X"))
                {
                    possibleGoingDown = false;
                }
                if(possibleGoingUp && !Board[i][4 - i].Contains("X"))
                {
                    possibleGoingUp = false;
                }
                if(!possibleGoingUp && !possibleGoingDown)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckHorizontal()
        {
            var result = Board.Any(row => row.All(val => val.Contains("X")));
            if (result)
            {
                return result;
            }
            return result;
        }

        private bool CheckVertical()
        {

            for(int i = 0; i < 5; i++)
            {
                if(Board.All(row => row[i].Contains("X")))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
