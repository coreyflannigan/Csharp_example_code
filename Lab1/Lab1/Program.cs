using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1 {
    class Program {
        /// <summary>
        /// I, Sean Flannigan, 000270501 certify that this material is my original work. No other person's work has been used without due acknowledgement.
        /// 
        /// 19-09-2019
        /// 
        /// Main class of the Lab1 program. Accepts a text file with up to 100 lines to be read line by line then error checked before passing the broken down line entry into
        /// an arry of Employee class objects to store the different values. Menu is drawn in console then user is prompted to select one of 5 sort options for the list of Employees.
        /// User input is error checked, with valid entries being passed into the sort method where the data is sorted with insertion sort based on which option entered.
        /// Array of sorted employees is displayed in console, and user is presented the menu again to either sort again or quit.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            // ****  PROGRAM CODE BEGINS HERE  ****

            Console.WindowHeight = Console.LargestWindowHeight - 55;
            Console.WindowWidth = Console.LargestWindowWidth - 154;

            // Variables initialized here, an empty Employee object array and two boolean flags.

            Employee[] list = new Employee[0];
            bool quitFlag = false;
            // ranOnceFlag used so that program initialization only shows the menu, but after sorting once successfully if the user enters an
            // invalid option the sorted data last seen will remain on the screen until a new valid selection is made.
            bool ranOnceFlag = false;

            // Read method is called in order to fill the Employee object array. Menu is then displayed to the user.
            list = Read(list);
            Menu();

            // While loop based on the boolean quit flag, allows users to make a sort method selection then displays the data until use quits.
            while (quitFlag is false) {
                int selection = 0;
                Console.Write("\nPlease make a selection: ");
                // Error handling if the user inputs something that cannot be parsed to int.
                try {
                    selection = int.Parse(Console.ReadLine());
                } catch (Exception) {
                    Console.Clear();
                    if (ranOnceFlag is true) {
                        Headings();
                        foreach (Employee e in list) {
                            Console.WriteLine(e);
                        }
                    }
                    Menu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nInvalid entry, please try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                // Int variable selection checked here to ensure it is within the 1-6 options before calling on the sorting method, errors out if not within 1-6.
                if (selection == 6) {
                    quitFlag = true;
                } else if (selection <= 0 || selection > 6) {
                    Console.Clear();
                    if (ranOnceFlag is true) {
                        Headings();
                        foreach (Employee e in list) {
                            Console.WriteLine(e);
                        }
                    }
                    Menu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nInvalid entry, please try again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else if (selection > 0 && selection < 6) {
                    Console.Clear();
                    list = InsertionSort(list, selection);
                    ranOnceFlag = true;
                    Headings();
                    foreach (Employee e in list) {
                        Console.WriteLine(e);
                    }
                    Menu();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Option {selection} selected.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        /// <summary>
        /// Sorting method using the Insertion Sort algorithm. Accepts an array of Employee objects as well as an int representing the
        /// sorting method requested. Method iterates over the array array.Length times advancing one index step at a time then compares
        /// each side by side object, working backwards from that point to the beginning of the array and swapping objects based on ascending
        /// or descending requirement, until array is iterated completely to the end.
        /// 
        /// Algorithm learned and sourced from:
        /// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-6.php
        /// </summary>
        /// <param name="unsortedList">The array of Employee objects to be sorted.</param>
        /// <param name="sortMethod">The int variable representing the user's choice of sorting method.</param>
        /// <returns>The array of Employee objects, now sorted.</returns>
        static Employee[] InsertionSort(Employee[] unsortedList, int sortMethod) {
            for (int i = 0; i < unsortedList.Length - 1; i++) {
                for (int j = i + 1; j > 0; j--) {
                    switch (sortMethod) {
                        case 1:
                            // Sort by Employee name, ascending
                            int charCount = 0;
                            while (unsortedList[j - 1].GetName()[charCount] == unsortedList[j].GetName()[charCount]) {
                                charCount += 1;
                            }
                            if ((unsortedList[j - 1].GetName())[charCount] > (unsortedList[j].GetName())[charCount]) {
                                Employee temp = unsortedList[j - 1];
                                unsortedList[j - 1] = unsortedList[j];
                                unsortedList[j] = temp;
                            }
                            break;
                        case 2:
                            // Sort by Employee number, ascending
                            if (unsortedList[j - 1].GetNumber() > unsortedList[j].GetNumber()) {
                                Employee temp = unsortedList[j - 1];
                                unsortedList[j - 1] = unsortedList[j];
                                unsortedList[j] = temp;
                            }
                            break;
                        case 3:
                            // Sort by Employee pay rate, descending
                            if (unsortedList[j - 1].GetRate() < unsortedList[j].GetRate()) {
                                Employee temp = unsortedList[j - 1];
                                unsortedList[j - 1] = unsortedList[j];
                                unsortedList[j] = temp;
                            }
                            break;
                        case 4:
                            // Sort by Employee hours worked, descending
                            if (unsortedList[j - 1].GetHours() < unsortedList[j].GetHours()) {
                                Employee temp = unsortedList[j - 1];
                                unsortedList[j - 1] = unsortedList[j];
                                unsortedList[j] = temp;
                            }
                            break;
                        case 5:
                            // Sort by Employee gross pay, descending
                            if (unsortedList[j - 1].GetGross() < unsortedList[j].GetGross()) {
                                Employee temp = unsortedList[j - 1];
                                unsortedList[j - 1] = unsortedList[j];
                                unsortedList[j] = temp;
                            }
                            break;
                    }
                }
            }
            return unsortedList;

        }


        /// <summary>
        /// Void method used to display the menu to the user via console WriteLine.
        /// </summary>
        static void Menu() {
            Console.WriteLine("\n1) Sort by Employee Name (ascending)");
            Console.WriteLine("2) Sort by Employee Number (ascending)");
            Console.WriteLine("3) Sort by Employee Pay Rate (descending)");
            Console.WriteLine("4) Sort by Employee Hours (descending)");
            Console.WriteLine("5) Sort by Employee Gross Pay (descending)");
            Console.WriteLine("6) Exit");
        }

        /// <summary>
        /// Void method used to display the headings for the Employee array via console WriteLine.
        /// </summary>
        static void Headings() {
            Console.WriteLine("Employee Name        -        Employee Number - Pay Rate - Hours Worked - Gross Pay");
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Read method for the main class utilizing FileStream and StreamReader. Accepts an empty initialized Employee object
        /// array in order to fill it with data. FileStream used to open a provided textfile, then StreamReader iterates through
        /// the file to count how many lines are inside. If line count is over 100, an error is shown to the user and the empty
        /// array is returned. Else, StreamReader will iterate over the file line by line, splitting up the entries based on ','s
        /// and after a series of error handlings will pass the data on by creating a new Employee object and placing it in the array.
        /// </summary>
        /// <param name="emptyList">An empty initialized Employee object array.</param>
        /// <returns>The Employee object array, either filled with data or empty based on file size.</returns>
        static Employee[] Read(Employee[] emptyList) {
            FileStream file = new FileStream("employees.txt", FileMode.Open, FileAccess.Read);
            StreamReader data = new StreamReader(file);
            string line;

            int lineCount = 0;
            while ((data.ReadLine()) != null) {
                lineCount += 1;
            }


            data.BaseStream.Position = 0;
            data.DiscardBufferedData();

            if (lineCount > 100) {
                Console.WriteLine("Too many records in the file provided.");
            }
            else {
                emptyList = new Employee[lineCount];
                int listCount = 0;
                while ((line = data.ReadLine()) != null) {
                    string[] splitLine = line.Split(',');
                    int tempNumber;
                    decimal tempRate;
                    double tempHours;
                    try {
                        tempNumber = int.Parse(splitLine[1]);
                    } catch (Exception) {
                        tempNumber = 000000;
                    }
                    try {
                        tempRate = decimal.Parse(splitLine[2]);
                    } catch (Exception) {
                        tempRate = 0000;
                    }
                    try {
                        tempHours = double.Parse(splitLine[3]);
                    } catch (Exception) {
                        tempHours = 0000;
                    }
                    emptyList[listCount] = new Employee(splitLine[0], tempNumber, tempRate, tempHours);
                    listCount += 1;
                }
            }

            data.Close();
            file.Close();
            return emptyList;
        }
    }
}
