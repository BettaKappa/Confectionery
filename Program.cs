using System.Net;
using static System.Console;
using static System.ConsoleKey;

namespace Cake_order
{
    internal class Program
    {
        static void Main()
        {
            Submenu submenu1 = new Submenu("Круг", 100);
            Submenu submenu2 = new Submenu("Квадрат", 200);
            Submenu submenu3 = new Submenu("Овал", 300);

            Submenu submenu4 = new Submenu("Оранжевый", 100);
            Submenu submenu5 = new Submenu("Зелёный", 300);
            Submenu submenu6 = new Submenu("Фиолетовый", 200);

            Menu form = new();
            form.Submenu = new List<Submenu>() { submenu1, submenu2, submenu3 };
            form.Name = "Форма";

            Menu color = new();
            color.Submenu = new List<Submenu>() { submenu4, submenu5, submenu6 };
            color.Name = "Цвет";

            List<Menu> menuList = new() { form, color };

            int position = 1;
            var key = ReadKey();
            while (key.Key != Enter)
            {

                Clear();

                foreach (Menu menuPoint in menuList)
                {
                    Console.WriteLine("   " + menuPoint.Name);
                }

                position = Arrow(key, position);
                key = ReadKey();
            }

            Clear();
            ShowAddMenu(menuList[position]);
            Main();

        }
        static void ShowAddMenu(Menu menuPoint)
        {
            foreach (Submenu submenuPoint in menuPoint.Submenu)
            {
                WriteLine(submenuPoint.Title + " - " + submenuPoint.Cost);
            }
        }

        static int Arrow(ConsoleKeyInfo key, int position)
        {
            switch (key.Key)
            {
                case UpArrow:
                    position--;
                    break;
                case DownArrow:
                    position++;
                    break;
                case Escape:
                    Environment.Exit(Environment.ExitCode);
                    break;
            }
            SetCursorPosition(0, position);
            WriteLine(" ► ");
            return position;
        }
    }
}


































// Кондитерская TORTILLA / ТортТорг / ТортЛи / Тортомон
// Заказ тортов на любой вкус и цвет*
// *ну почти
// Оформите ваш заказ:

