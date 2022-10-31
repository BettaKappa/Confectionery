namespace Cake_order
{
    internal class Menu
    {
        public string Name;
        public List<Submenu> Submenu;

        public Menu (string name, List<Submenu> list)
        {
            Name = name;
            Submenu = list;
        }
    }
}
