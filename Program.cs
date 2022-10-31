using static System.Console;
using static System.ConsoleKey;
using WindowsInput;
using WindowsInput.Native;

namespace Cake_order
{
    internal class Program
    {
        private static void Main()
        {
            WriteLine("Кондитерская ПотомПридумаю" + "\n" +
                      "Торты на любой вкус и цвет*" + "\n" + "\n" + "\n" +
                      "Нажмите ПРОБЕЛ для перехода к форме заказа" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" +
                      "*ну почти на любой");
            
            while (true)
            {
                Submenu form1 = new("Квадрат", 200);
                Submenu form2 = new("Куб", 300);
                Submenu form3 = new("Тессеракт", 400);
                Submenu form4 = new("Пентеракт", 500);

                Submenu amount1 = new("Три", 100);
                Submenu amuont2 = new("Два", 200);
                Submenu amount3 = new("Один", 300);

                Submenu size1 = new("Большой торт", 300);
                Submenu size2 = new("Торт поменьше", 200);
                Submenu size3 = new("Жестб какой маленький", 100);

                Submenu taste1 = new("Вкусно", 100);
                Submenu taste2 = new("Ну норм", 200);
                Submenu taste3 = new("Не оч", 300);

                Submenu glaze1 = new("С глазурью", 100);
                Submenu glaze2 = new("Без глазури", 200);

                Submenu decor1 = new("Обойдёшься", 300);


                Menu form = new("Форма", new List<Submenu>() { form1, form2, form3, form4 });
                Menu amount = new("Количество коржей", new List<Submenu>() { amount1, amuont2, amount3 });
                Menu size = new("Размер", new List<Submenu>() { size1, size2, size3 });
                Menu taste = new("Вкус", new List<Submenu>() { taste1, taste2, taste3 });
                Menu glaze = new("Глазурь", new List<Submenu>() { glaze1, glaze2 });
                Menu decor = new("Декор", new List<Submenu>() { decor1 });

                List<Menu> menuList = new() { form, size, taste, amount, glaze, decor };

                ShowMenu(menuList);

            }
        }
        
        private static void ShowMenu(List<Menu> menuList)
        {
            int position = 0;
            var key = ReadKey();
            while (key.Key != Enter)
            {
                Clear();

                foreach (Menu menuPoint in menuList)
                {
                    Console.WriteLine("   " + menuPoint.Name);
                }

                position = Arrow(key, position, menuList);
                key = ReadKey();
            }

            Clear();
            ImitateSpasebarPress();
            ShowAddMenu(menuList[position], menuList);
        }

        static void ShowAddMenu(Menu menuPoint, List<Menu> menuList)
        {
            int position = 0;
            var key = ReadKey();
            while (key.Key != Enter)
            {
                Clear();

                foreach (Submenu submenuPoint in menuPoint.Submenu)
                {
                    WriteLine("   " + submenuPoint.Title + " - " + submenuPoint.Cost);
                }

                position = Arrow(key, position, menuList);
                key = ReadKey();
            }
            Clear();
            ImitateSpasebarPress();
        }

        static int Arrow(ConsoleKeyInfo key, int position, List<Menu> menuList)
        {
            switch (key.Key)
            {
                case UpArrow:
                    position--;
                    break;
                case DownArrow:
                    position++;
                    break;
                case LeftArrow:
                    ShowMenu(menuList);
                    break;
                case Escape:
                    Clear();
                    WriteLine("Вы вышли из формы заказа");
                    Environment.Exit(Environment.ExitCode);
                    break;
            }
            SetCursorPosition(0, position);
            WriteLine(" ► ");
            return position;
        }

        static void ImitateSpasebarPress()
        {
            InputSimulator spacebar = new();
            spacebar.Keyboard.KeyPress(VirtualKeyCode.SPACE);
        }

    }
}