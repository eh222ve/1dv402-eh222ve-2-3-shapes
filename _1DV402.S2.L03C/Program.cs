using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1DV402.S2.L03C;
using ExtensionMethods;
using _1DV402.S2.L03C.Properties;

namespace _1DV402.S2.L03C
{
    class Program
    {
        static void Main(string[] args)
        {
            MyExtensions.PrettyConsole("Geometric Shapes");

            while (true)
            {
                ViewMenu();

                ConsoleKeyInfo menuChoice = Console.ReadKey();
                Console.Clear();

                ShapeType shapeToCreate = ShapeType.Undefined;

                switch (menuChoice.KeyChar.ToString()) //För att ta hand om NumPad och "vanlig" siffra
                {
                    case "0":
                        return;
                    case "1":
                        shapeToCreate = ShapeType.Rectangle;
                        break;
                    case "2":
                        shapeToCreate = ShapeType.Circle;
                        break;
                    case "3":
                        shapeToCreate = ShapeType.Ellipse;
                        break;
                    case "4":
                        shapeToCreate = ShapeType.Cuboid;
                        break;
                    case "5":
                        shapeToCreate = ShapeType.Cylinder;
                        break;
                    case "6":
                        shapeToCreate = ShapeType.Sphere;
                        break;
                    case "7":
                        ViewShapes(Randomize2DShapes());
                        break;
                    case "8":
                        ViewShapes(Randomize3DShapes());
                        break;
                    default:
                        ViewMenuErrorMessage();
                        break;
                }

                if (shapeToCreate != ShapeType.Undefined)
                {
                    ViewShapeDetail(CreateShape(shapeToCreate));
                }

                ContinueToMenu(Strings.Continue_Prompt);
            }
        }

        //Skapar geometrisk form tillsammans med user input
        private static Shape CreateShape(ShapeType shapeType){
            Shape obj;

            MyExtensions.ChangeColor(ConsoleColor.DarkCyan, ConsoleColor.White);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(shapeType.AsText().CenterAlignString("|", 40));
            Console.WriteLine("----------------------------------------\n");
            MyExtensions.ChangeColor();

            double[] shapeProperties = ReadDimensions(shapeType);

            switch (shapeType)
            {
                case ShapeType.Circle:
                    obj = new Ellipse(shapeProperties[0]);
                    break;
                case ShapeType.Ellipse:
                    obj = new Ellipse(shapeProperties[0], shapeProperties[1]);
                    break;
                case ShapeType.Rectangle:
                    obj = new Rectangle(shapeProperties[0], shapeProperties[1]);
                    break;
                case ShapeType.Cuboid:
                    obj = new Cuboid(shapeProperties[0], shapeProperties[1], shapeProperties[1]);
                    break;
                case ShapeType.Cylinder:
                    obj = new Cylinder(shapeProperties[0], shapeProperties[1], shapeProperties[1]);
                    break;
                case ShapeType.Sphere:
                    obj = new Sphere(shapeProperties[0]);
                    break;
                default:
                    throw new ApplicationException();
            }

            return obj;
        }

        //Random 5-20 former
        private static Shape2D[] Randomize2DShapes() {
            Random random = new Random();

            int numberOfShapes = random.Next(5, 20);

            Shape2D[] objects = new Shape2D[numberOfShapes];

            for (int i = 0; i < numberOfShapes; i++)
            {
                int objectType = random.Next(1, 4);

                Shape2D obj;

                switch (objectType)
                    {
                        case 1:
                            obj = new Rectangle(random.Next(5, 100), random.Next(5, 100));
                            break;
                        case 2:
                            obj = new Ellipse(random.Next(5, 100));
                            break;
                        case 3:
                            obj = new Ellipse(random.Next(5, 100), random.Next(5, 100));
                            break;
                        default:
                            throw new ArgumentException();
                    }
                objects[i] = obj;
            }

            return objects;
        }

        //Random 5-20 former
        private static Shape3D[] Randomize3DShapes()
        {
            Random random = new Random();

            int numberOfShapes = random.Next(5, 20);

            Shape3D[] objects = new Shape3D[numberOfShapes];

            for (int i = 0; i < numberOfShapes; i++)
            {
                int objectType = random.Next(1, 4);

                Shape3D obj;
                
                switch (objectType)
                {
                    case 1:
                        obj = new Cuboid(random.Next(5, 100), random.Next(5, 100), random.Next(5, 100));
                        break;
                    case 2:
                        obj = new Cylinder(random.Next(5, 100), random.Next(5, 100), random.Next(5, 100));
                        break;
                    case 3:
                        obj = new Sphere(random.Next(5, 100));
                        break;
                    default:
                        throw new ArgumentException();
                }
                objects[i] = obj;
            }

            return objects;
        }

        //Avgör hur många värden som ska läsas in för olika former
        private static double[] ReadDimensions(ShapeType shapeType) {
            
            string prompt;
            int numberOfValues;

            switch (shapeType) { 
                case ShapeType.Circle:
                    prompt = "Ange radie: ";
                    numberOfValues = 1;
                    break;
                case ShapeType.Ellipse:
                    prompt = "Ange vradie, hradie: ";
                    numberOfValues = 2;
                    break;
                case ShapeType.Rectangle:
                    prompt = "Ange längd, bredd: ";
                    numberOfValues = 2;
                    break;
                case ShapeType.Cuboid:
                    prompt = "Ange längd, bredd, höjd: ";
                    numberOfValues = 3;
                    break;
                case ShapeType.Cylinder:
                    prompt = "Ange vradie, hradie, höjd: ";
                    numberOfValues = 3;
                    break;
                case ShapeType.Sphere:
                    prompt = "Ange radie: ";
                    numberOfValues = 1;
                    break;
                default:
                    throw new ApplicationException();
            }

            double[] output = ReadDoublesGreaterThanZero(prompt, numberOfValues);
            
            return output;
        }

        //Efterfrågar userinput och splittar sträng med " ".
        private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues = 1) {
            double[] output = new double[numberOfValues];
            while (true)
            {
                Console.Write(" {0}", prompt);
                try
                {
                    string stringInput = Console.ReadLine();
                    string[] arrayInput = stringInput.Split(' ');

                    if (arrayInput.Length != numberOfValues)
                    {
                        throw new ArgumentException();
                    }

                    for (int i = 0; i < numberOfValues; i++)
                    {
                        output[i] = double.Parse(arrayInput[i]);
                        if (output[i] <= 0) {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                    break;
                }
                catch
                {
                    ViewMenuErrorMessage();
                }
            }
            return output;
        }

        //Visar huvudmeny
        private static void ViewMenu() {
            MyExtensions.ChangeColor(ConsoleColor.DarkCyan, ConsoleColor.White);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                 Meny                 |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("----------------------------------------");
            MyExtensions.ChangeColor();
            Console.WriteLine();
            Console.WriteLine(" 0. {0}", Strings.Menu_Exit);
            Console.WriteLine(" 1. {0}", Strings.Shape_Rectangle);
            Console.WriteLine(" 2. {0}", Strings.Shape_Circle);
            Console.WriteLine(" 3. {0}", Strings.Shape_Ellipse);
            Console.WriteLine(" 4. {0}", Strings.Shape_Cuboid);
            Console.WriteLine(" 5. {0}", Strings.Shape_Cylinder);
            Console.WriteLine(" 6. {0}", Strings.Shape_Sphere);
            Console.WriteLine(" 7. {0}", Strings.Menu_Random2D);
            Console.WriteLine(" 8. {0}", Strings.Menu_Random3D);
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" {0} [0-8]", Strings.Menu_Enter_Prompt);
            Console.WriteLine();

        }
        
        //Efterfrågar knapptryck
        private static void ContinueToMenu(string prompt) {
            MyExtensions.ChangeColor(ConsoleColor.Blue, ConsoleColor.White);
            Console.CursorVisible = false;
            Console.Write("\n{0} ", prompt.CenterAlignString("", Console.WindowWidth));
            MyExtensions.ChangeColor();
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();
        }
        
        //Visar felmeddelande från menyn
        private static void ViewMenuErrorMessage() {
            MyExtensions.ChangeColor(ConsoleColor.Red, ConsoleColor.White);
            Console.WriteLine(Strings.Error_Message);
            MyExtensions.ChangeColor();
        }

        //Visar upp detaljer för ett objekt
        private static void ViewShapeDetail(Shape shape) {
            Console.WriteLine(shape.ToString());
        }

        //Visar upp tabell med detaljer för minst 1 objekt
        private static void ViewShapes(Shape[] shapes) {

            MyExtensions.ChangeColor(ConsoleColor.DarkCyan, ConsoleColor.White);

            if (shapes[0].IsShape3d)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("|  {0, -9}{1, 10:F0}{2, 10:F0}{3, 10:F0}{4, 13:F0}{5, 7:F0}{6, 15:F0} |",
                    Strings.Shape,
                    Strings.Length,
                    Strings.Width,
                    Strings.Height,
                    Strings.MantelArea,
                    Strings.Volume,
                    Strings.TotalSurfaceArea_Short);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            else {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("|  {0, -9}{1, 10:F0}{2, 10:F0}{3, 10:F0}{4, 10:F0} |",
                    Strings.Shape,
                    Strings.Length,
                    Strings.Width, 
                    Strings.Area, 
                    Strings.Perimeter);
                Console.WriteLine("------------------------------------------------------");
            }
            MyExtensions.ChangeColor();

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("{0, 2}. {1}", i+1, shapes[i].ToString("R"));    
            }
        }

    }
   
}
