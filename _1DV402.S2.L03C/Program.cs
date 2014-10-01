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
                try
                {
                    int menuChoice = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (menuChoice)
                    {
                        case 0:
                            return;
                        case 1:
                            ViewShapeDetail(CreateShape(ShapeType.Rectangle));
                            break;
                        case 2:
                            ViewShapeDetail(CreateShape(ShapeType.Circle));
                            break;
                        case 3:
                            ViewShapeDetail(CreateShape(ShapeType.Ellipse));
                            break;
                        case 4:
                            ViewShapeDetail(CreateShape(ShapeType.Cuboid));
                            break;
                        case 5:
                            ViewShapeDetail(CreateShape(ShapeType.Cylinder));
                            break;
                        case 6:
                            ViewShapeDetail(CreateShape(ShapeType.Sphere));
                            break;
                        case 7:
                            ViewShapes(Randomize2DShapes());
                            break;
                        case 8:
                            ViewShapes(Randomize3DShapes());
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
                catch
                {
                    MyExtensions.ChangeColor(ConsoleColor.Red, ConsoleColor.White);
                    Console.WriteLine("Something went wrong");
                    MyExtensions.ChangeColor();
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static Shape CreateShape(ShapeType shapeType){
            string header;
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
                    header = Strings.Shape_Circle;
                    obj = new Ellipse(shapeProperties[0]);
                    break;
                case ShapeType.Ellipse:
                    header = Strings.Shape_Ellipse;
                    obj = new Ellipse(shapeProperties[0], shapeProperties[1]);
                    break;
                case ShapeType.Rectangle:
                    header = Strings.Shape_Rectangle;
                    obj = new Rectangle(shapeProperties[0], shapeProperties[1]);
                    break;
                case ShapeType.Cuboid:
                    header = Strings.Shape_Cuboid;
                    obj = new Cuboid(shapeProperties[0], shapeProperties[1], shapeProperties[1]);
                    break;
                case ShapeType.Cylinder:
                    header = Strings.Shape_Cylinder;
                    obj = new Cylinder(shapeProperties[0], shapeProperties[1], shapeProperties[1]);
                    break;
                case ShapeType.Sphere:
                    header = Strings.Shape_Sphere;
                    obj = new Sphere(shapeProperties[0]);
                    break;
                default:
                    throw new ApplicationException();
            }

            return obj;
        }

        private static Shape2D[] Randomize2DShapes() {
            throw new NotImplementedException();
        }

        private static Shape3D[] Randomize3DShapes()
        {
            throw new NotImplementedException();
        }

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

        private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues = 1) {
            double[] output = new double[numberOfValues];
            
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
            }
            catch {
                Console.WriteLine("unexpected Error");
            }

            return output;
        }

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

        private static void ViewMenuErrorMessage() { 
        
        }

        private static void ViewShapeDetail(Shape shape) {
            Console.WriteLine(shape.ToString());
        }

        private static void ViewShapes(Shape[] shapes) {
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine(shapes[i].ToString("R"));    
            }
        }



    }
   
}
