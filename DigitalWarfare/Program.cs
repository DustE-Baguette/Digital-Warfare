namespace DigitalWarfare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int consoleWidth = 150;
            int consoleHeight = 32;

            // Set console tweaks in place
            try
            {
                Console.Title = "DIGITAL WARFARE";

                Console.SetWindowSize(consoleWidth, consoleHeight);
                Console.SetBufferSize(consoleWidth, consoleHeight);

                ConsoleTweaks.MoveWindowToCenter();
                ConsoleTweaks.DisableResize();
                Console.CursorVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MenuManager menuManager = new MenuManager();

            menuManager.CreateStates();
            menuManager.DisplayState();

            Console.ReadLine();
        }
    }
}