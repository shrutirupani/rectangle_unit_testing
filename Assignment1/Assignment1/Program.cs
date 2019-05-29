using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        public static int ValidateMenuSelection()
        {
            string userInput = "";
            bool validMenuSelect = false;

            while (validMenuSelect == false)
            {
                Console.WriteLine("1 = Get Rectangle Length");
                Console.WriteLine("2 = Change Rectangle Length");
                Console.WriteLine("3 = Get Rectangle Width");
                Console.WriteLine("4 = Change Rectangle Width");
                Console.WriteLine("5 = Get Rectangle Perimeter");
                Console.WriteLine("6 = Get Rectangle Area");
                Console.WriteLine("7 = Exit\n");

                Console.WriteLine("Please select an option, by entering a number:\n");
                userInput = Console.ReadLine();

                if (userInput != "1" &&
                    userInput != "2" &&
                    userInput != "3" &&
                    userInput != "4" &&
                    userInput != "5" &&
                    userInput != "6" &&
                    userInput != "7")
                {
                    Console.WriteLine("That's not a valid menu option, please try again:\n");
                }
                else
                {
                    validMenuSelect = true;
                }
            }

            Console.WriteLine();
            return int.Parse(userInput);
        }

        public static int ValidateUserInput(string rectSide)
        {
            int number = 1;
            bool isValid = false;

            while (isValid == false)
            {
                Console.WriteLine($"Please enter the {rectSide} of your rectangle:");
                string userInput = Console.ReadLine();
                Console.WriteLine();

                bool result = int.TryParse(userInput, out number);

                if (result == false)
                {
                    Console.WriteLine("That's not a valid input please, please try again.\n");
                }
                else if (number < 0)
                {
                    Console.WriteLine("Number cannot be less than 0, please try again.\n");
                }
                else
                {
                    isValid = true;
                    Console.WriteLine($"The {rectSide} of your rectangle is now {number}.\n");
                }
            }

            return number;
        }
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            bool validRectSelect = false;
            string recSelection;
            int selection;

            while (validRectSelect == false)
            {
                Console.WriteLine("1 = Create default (1 unit * 1 unit) Rectangle\n");
                Console.WriteLine("2 = Create custom Rectangle\n");
                Console.WriteLine("Choose a menu item to begin:");
                recSelection = Console.ReadLine();
                Console.WriteLine();

                if (recSelection != "1" && recSelection != "2")
                {
                    Console.WriteLine("That's not a valid selection, please try again.\n");
                }
                else if (int.Parse(recSelection) == 1)
                {
                    validRectSelect = true;
                   int length = 1;
                   int width = 1;

                    Console.WriteLine($"Your default rectangle is {length} and {width}.\n");
                    Rectangle customRec = new Rectangle(length, width);
                    rectangle = customRec;

                }
                else if (int.Parse(recSelection) == 2)
                {
                    validRectSelect = true;

                    int length;
                    int width;

                    length = ValidateUserInput("length");
                    width = ValidateUserInput("width");

                    Console.WriteLine($"Your custom numbers are {length} and {width}.\n");
                    Rectangle customRec = new Rectangle(length, width);
                    rectangle = customRec;
                }
            }


            selection = ValidateMenuSelection();

            while (selection != 7)
            {
                int result;

                switch (selection)
                {
                    case 1:
                        Console.WriteLine($"Rectangle Length: {rectangle.GetLength()}\n");
                        break;
                    case 2:
                        result = ValidateUserInput("Length");
                        rectangle.SetLength(result);
                        break;
                    case 3:
                        Console.WriteLine($"Rectangle Width: {rectangle.GetWidth()}\n");
                        break;
                    case 4:
                        result = ValidateUserInput("Width");
                        rectangle.SetWidth(result);
                        break;
                    case 5:
                        Console.WriteLine($"The perimeter of {rectangle.GetLength()} and {rectangle.GetWidth()} is: {rectangle.GetPerimeter()}\n");
                        break;
                    case 6:
                        Console.WriteLine($"The area of {rectangle.GetLength()} and {rectangle.GetWidth()} is: {rectangle.GetArea()}\n");
                        break;
                    default:
                        break;
                }

                selection = ValidateMenuSelection();

            }

        
    }
    }
}
