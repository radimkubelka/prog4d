﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ukolmatice
{
    internal class Program
    {
        //naplní pole od 1 dál
        static void FillArray(int[,] array)
        {
            int numbertoadd = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = numbertoadd;
                    numbertoadd++;
                }
            }
        }
        //naplní pole náhodně
        static void FillArrayRandom(int[,] array)
        {
            Random rng = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rng.Next(1, 10);
                }
            }
        }
        //vypíše pole
        static void WriteArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        //vynásobí pole číslem
        static void MultiplyArray(int[,] array, int constant)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = constant * array[i, j];
                }
            }
        }
        //vynásobí řádek číslem
        static void MultiplyRow(int[,] array, int constant, int row)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[row, i] = constant * array[row, i];
            }
        }
        //vynásobí sloupec číslem
        static void MultiplyColumn(int[,] array, int constant, int column)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, column] = constant * array[i, column];
            }
        }
        //jistota zadání správného čísla; nápověda z chatgpt
        static int NumberInRange(int input, int min, int max)
        {
            bool InRange = false;

            while (InRange == false)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= min && input < max)
                    {
                        InRange = true;
                        return input;
                    }
                    else
                    {
                        Console.WriteLine($"můžeš jen mezi {min} a {max - 1}");
                    }
                }
                else
                {
                    Console.WriteLine("napiš platné číslo");
                }
            }
            return -1;
        }
        //odečtení původního pole od nového
        static void Subtract(int[,] array, int rows, int columns)
        {
            int[,] Sum2DArray = new int[rows, columns];
            //FillArray(Sum2DArray);
            FillArrayRandom(Sum2DArray);
            Console.WriteLine("odčítám od pole");
            WriteArray(Sum2DArray);
            Console.Write("\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = Sum2DArray[i, j] - array[i, j];
                }
            }
        }
        //sečtení s novým polem
        static void Add(int[,] array, int rows, int columns)
        {
            int[,] Sum2DArray = new int[rows, columns];
            //FillArray(Sum2DArray);
            FillArrayRandom(Sum2DArray);
            Console.WriteLine("sčítám s polem");
            WriteArray(Sum2DArray);
            Console.Write("\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = Sum2DArray[i, j] + array[i, j];
                }
            }
        }
        //vynásobí pole s druhou maticí stejných rozměrů; nápověda z photomath a chatgpt
        static void MultiplyWithArray(int[,] array, int rows, int columns, int[,] ResultArray)
        {
            if (rows != columns)
            {
                Console.WriteLine("tyto matice nejde násobit (počet řádků u 1. není stejný jako počet sloupců u 2.)");
                return;
            }
            int[,] Multiply2DArray = new int[rows, columns];
            //FillArray(Multiply2DArray);
            FillArrayRandom(Multiply2DArray);
            Console.WriteLine("násobím s polem");
            WriteArray(Multiply2DArray);
            Console.Write("\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        ResultArray[i, j] += array[i, k] * Multiply2DArray[k, j];
                    }
                }
            }
        }
        //sečte všechny čísla v matici
        static int SumOfArray(int[,] array, int Sum)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Sum += array[i, j];
                }
            }
            return Sum;
        }
        static int MaxOfArray(int[,] array, int Max)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > Max)
                    {
                        Max = array[i, j];
                    }
                }
            }
            return Max;
        }
        static int MinOfArray(int[,] array, int Min)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < Min)
                    {
                        Min = array[i, j];
                    }
                }
            }
            return Min;
        }
        //prohodí prvky v rowfirst, columnfirst a rovsecond, columnsecond
        static void MoveElement(int[,] array)
        {
            int rowfirst = 0, columnfirst = 0, rowsecond = 0, columnsecond = 0;
            int memory;
            Console.WriteLine("řádek 1. prvku na prohození");
            rowfirst = NumberInRange(rowfirst, 0, array.GetLength(0));
            Console.WriteLine("sloupec 1. prvku na prohození");
            columnfirst = NumberInRange(columnfirst, 0, array.GetLength(1));
            Console.WriteLine("řádek 2. prvku na prohození");
            rowsecond = NumberInRange(rowsecond, 0, array.GetLength(0));
            Console.WriteLine("sloupec 2. prvku na prohození");
            columnsecond = NumberInRange(columnsecond, 0, array.GetLength(1));
            memory = array[rowfirst, columnfirst];
            array[rowfirst, columnfirst] = array[rowsecond, columnsecond];
            array[rowsecond, columnsecond] = memory;
        }
        //prohodí dvě řady
        static void MoveRow(int[,] array)
        {
            int firstrow = 0, secondrow = 0;
            int memory;
            Console.WriteLine("1. řádek na prohození");
            firstrow = NumberInRange(firstrow, 0, array.GetLength(0));
            Console.WriteLine("2. řádek na prohození");
            secondrow = NumberInRange(secondrow, 0, array.GetLength(0));
            for (int i = 0; i < array.GetLength(1); i++)
            {
                memory= array[firstrow, i];
                array[firstrow, i] = array[secondrow, i];
                array[secondrow, i] = memory;
            }
        }
        //prohodí dva sloupce
        static void MoveColumn(int[,] array)
        {
            int firstcolumn = 0, secondcolumn = 0;
            int memory;
            Console.WriteLine("1. řádek na prohození");
            firstcolumn = NumberInRange(firstcolumn, 0, array.GetLength(0));
            Console.WriteLine("2. řádek na prohození");
            secondcolumn = NumberInRange(secondcolumn, 0, array.GetLength(0));
            for (int i = 0; i < array.GetLength(0); i++)
            {
                memory = array[i, firstcolumn];
                array[i, firstcolumn] = array[i, secondcolumn];
                array[i, secondcolumn] = memory;
            }
        }
        //převrátí hlavní diagonálu
        static void SwapMainDiagonal(int[,] array, int rows, int columns)
        {
            if (rows != columns)
            {
                Console.WriteLine("jde jen u čtvercových matic");
                return;
            }
            for (int i = 0; i < array.GetLength(0) / 2; i++)
            {
                int memory = array[i, i];
                int reversedindex = array.GetLength(0) - 1 - i;
                array[i, i] = array[reversedindex, reversedindex];
                array[reversedindex, reversedindex] = memory;
            }
        }
        //převrátí vedlejší diagonálu
        static void SwapSideDiagonal(int[,] array, int rows, int columns)
        {
            if (rows != columns)
            {
                Console.WriteLine("jde jen u čtvercových matic");
                return;
            }
            for (int i = 0; i < array.GetLength(0) / 2; i++)
            {
                int reversedindex1 = array.GetLength(1) - 1 - i;
                int reversedindex0 = array.GetLength(0) - 1 - i;
                int memory = array[i, reversedindex1];
                array[i, reversedindex1] = array[reversedindex0, i];
                array[reversedindex0, i] = memory;
            }
        }
        //transpozice
        static void Transposition(int[,] array, int[,] transposedarray)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    transposedarray[j, i] = array[i, j];
                }
            }
        }
        //body 12 + 5 + 7,5 (nebo 10) + 8 + 12,5 + 15
        static void Main(string[] args)
        {
            int rows = 0, columns = 0;
            Console.WriteLine("Zadej počet řádků");
            rows = NumberInRange(rows, 1, 20);
            Console.WriteLine("Zadej počet sloupců");
            columns = NumberInRange(columns, 1, 20);
            int[,] my2DArray = new int[rows, columns];
            //FillArray(my2DArray);
            FillArrayRandom(my2DArray);
            WriteArray(my2DArray);
            Console.WriteLine("Co chceš dělat? (možnosti: multiply, subtract, add, multiplywitharray, sum, max, min, moveelement, moverow, movecolumn, swapmaindiagonal, swapsidediagonal, transposition)");
            string operation = Console.ReadLine();
            while (operation != "multiply" && operation != "subtract" && operation != "add" && operation != "multiplywitharray" && operation != "sum" && operation != "max" && operation != "min" && operation != "moveelement" && operation != "moverow" && operation != "movecolumn" && operation != "swapmaindiagonal" && operation != "swapsidediagonal" && operation != "transposition")
            {
                Console.WriteLine("napiš možnou operaci");
                operation = Console.ReadLine();
            }
            switch (operation)
            {
                case "multiply":
                    int multiplyer;
                    Console.WriteLine("čím chceš násobit?");
                    while (!int.TryParse(Console.ReadLine(), out multiplyer))
                    {
                        Console.WriteLine("Zadej platné celé číslo");
                    }
                    Console.WriteLine("chceš násobit all, row nebo column?");
                    string option = Console.ReadLine();
                    while (option != "all" && option != "row" && option != "column")                //násobení řádku, sloupce nebo všeho
                    {
                        Console.WriteLine("Zadej možnou možnost");
                        option = Console.ReadLine();
                    }
                    if (option == "all")
                    {
                        MultiplyArray(my2DArray, multiplyer);
                        WriteArray(my2DArray);
                    }
                    else if (option == "row")
                    {
                        int row = 0;
                        Console.WriteLine("jaký řádek chceš násobit?");
                        row = NumberInRange(row, 0, my2DArray.GetLength(0));
                        MultiplyRow(my2DArray, multiplyer, row);
                        WriteArray(my2DArray);
                    }
                    else
                    {
                        int column = 0;
                        Console.WriteLine("jaký sloupec chceš násobit?");
                        column = NumberInRange(column, 0, my2DArray.GetLength(0));
                        MultiplyColumn(my2DArray, multiplyer, column);
                        WriteArray(my2DArray);
                    }
                    break;
                case "subtract":                                                                    //odčítání
                    Subtract(my2DArray, rows, columns);
                    WriteArray(my2DArray);
                    break;
                case "add":                                                                         //sčítání
                    Add(my2DArray, rows, columns);
                    WriteArray(my2DArray);
                    break;
                case "multiplywitharray":                                                           //násobení s maticí
                    int[,] ResultArray = new int[rows, columns];
                    MultiplyWithArray(my2DArray, rows, columns, ResultArray);
                    WriteArray(ResultArray);
                    break;
                case "sum":                                                                         //součet matice
                    int Sum = 0;
                    Sum = SumOfArray(my2DArray, Sum);
                    Console.WriteLine($"součet všech polí v matici je {Sum}");
                    break;
                case "max":                                                                         //maximální číslo v matici
                    int Max = int.MinValue;
                    Max = MaxOfArray(my2DArray, Max);
                    Console.WriteLine($"největší číslo v matici je {Max}");
                    break;
                case "min":                                                                          //minimální číslo v matici   
                    int Min = int.MaxValue;
                    Min = MinOfArray(my2DArray, Min);
                    Console.WriteLine($"nejmenší číslo v matici je {Min}");
                    break;
                case "moveelement":
                    MoveElement(my2DArray);
                    WriteArray(my2DArray);
                    break;
                case "moverow":
                    MoveRow(my2DArray);
                    WriteArray(my2DArray);
                    break;
                case "movecolumn":
                    MoveColumn(my2DArray);
                    WriteArray(my2DArray);
                    break;
                case "swapmaindiagonal":
                    SwapMainDiagonal(my2DArray, rows, columns);
                    WriteArray(my2DArray);
                    break;
                case "swapsidediagonal":
                    SwapSideDiagonal(my2DArray, rows, columns);
                    WriteArray(my2DArray);
                    break;
                case "transposition":
                    ResultArray = new int[columns, rows];
                    Transposition(my2DArray, ResultArray);
                    WriteArray(ResultArray);
                    break;
            }





            Console.ReadKey();
        }
    }
}
