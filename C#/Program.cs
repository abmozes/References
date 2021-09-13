using System;
using System.IO;

namespace MortalityDatabaseParser
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Type the name of the input txt, or 'exit' to quit.");
                while (true)
                {
                    string name = Console.ReadLine();
                    if (name == "exit") { Environment.Exit(0); }

                    StreamReader sr = new StreamReader(@"..\..\..\..\" + name + ".txt");
                    sr.ReadLine(); // the first line is thrown away immediately, because we need new names

                    // I'd preset the size of output and separator, instead of asking every time
                    int numberOfAges = 111;
                    //int numberOfYears = 69;
                    Console.Write("First year: ");
                    int firstYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Last year: ");
                    int lastYear = Convert.ToInt32(Console.ReadLine());
                    int numberOfYears = lastYear - firstYear + 1;
                    numberOfAges++;
                    numberOfYears++;
                    char separator = '\t';

                    // creating arrays for output tables
                    string[,] tableF = new string[numberOfAges, numberOfYears];
                    string[,] tableM = new string[numberOfAges, numberOfYears];
                    string[,] tableT = new string[numberOfAges, numberOfYears];
                    tableF[0, 0] = "Age";
                    tableM[0, 0] = "Age";
                    tableT[0, 0] = "Age";
                    for (int i = 1; i < numberOfAges; i++)
                    {
                        tableF[i, 0] = (i - 1).ToString();
                        tableM[i, 0] = (i - 1).ToString();
                        tableT[i, 0] = (i - 1).ToString();
                    }

                    // reading initialisation
                    string year = "";
                    int col = 0;
                    int row = 0;

                    // reading till we find the end
                    for (int k = 0; k < (numberOfAges - 1) * (numberOfYears - 1); k++)
                    {
                        string[] line = sr.ReadLine().Split();
                        int sourceCol = 0;
                        
                        for (int i = 0; i < line.Length; i++) // one line in the source -> one cell in each table
                        {
                            if (line[i] != "")
                            {
                                if (sourceCol == 0) // the 0th is the year, checked if new (I didn't make a counter of 111 lines)
                                {
                                    if (year != line[i])
                                    {
                                        year = line[i];
                                        col++;
                                        tableF[0, col] = year;
                                        tableM[0, col] = year;
                                        tableT[0, col] = year;
                                        row = 1;
                                    }
                                    sourceCol++;
                                }
                                else if (sourceCol == 1) // 1st - age, thrown away, since already written
                                {
                                    sourceCol++;
                                }
                                else if (sourceCol == 2) //  2nd - female data
                                {
                                    tableF[row, col] = line[i];
                                    sourceCol++;
                                }
                                else if (sourceCol == 3) // 3rd - male data
                                {
                                    tableM[row, col] = line[i];
                                    sourceCol++;
                                }
                                else if (sourceCol == 4) // 4th - total data
                                {
                                    tableT[row, col] = line[i];
                                    sourceCol++;
                                    Console.WriteLine("Year " + year + " age " + (row - 1).ToString() + " has been read.");
                                    row++;
                                }
                                else if (sourceCol > 4) // if there is more in one line of the source, that's a problem
                                {
                                    Console.Write("Error");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                    sr.Close();

                    // creating the output
                    Console.WriteLine("Creating output files...");
                    StreamWriter swF = new StreamWriter(@"..\..\..\..\" + name + "_table_F.txt");
                    for (int i = 0; i < numberOfAges; i++)
                    {
                        for (int j = 0; j < numberOfYears; j++)
                        {
                            swF.Write(tableF[i, j]);
                            swF.Write(separator);
                        }
                        swF.Write('\n');
                    }
                    swF.Close();
                    Console.WriteLine(name + "_table_F.txt has been created.");

                    StreamWriter swM = new StreamWriter(@"..\..\..\..\" + name + "_table_M.txt");
                    for (int i = 0; i < numberOfAges; i++)
                    {
                        for (int j = 0; j < numberOfYears; j++)
                        {
                            swM.Write(tableM[i, j]);
                            swM.Write(separator);
                        }
                        swM.Write('\n');
                    }
                    swM.Close();
                    Console.WriteLine(name + "_table_M.txt has been created.");

                    StreamWriter swT = new StreamWriter(@"..\..\..\..\" + name + "_table_T.txt");
                    for (int i = 0; i < numberOfAges; i++)
                    {
                        for (int j = 0; j < numberOfYears; j++)
                        {
                            swT.Write(tableT[i, j]);
                            swT.Write(separator);
                        }
                        swT.Write('\n');
                    }
                    swT.Close();
                    Console.WriteLine(name + "_table_T.txt has been created.");

                    Console.WriteLine('\n' + "Type in the name of the next txt or 'exit' to close.");
                }
            }
            catch (Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(e.Message);
                throw;
            }
        }
    }
}
