
public class ReisePlaner
{
    // Ziel hinzufügen Funktion
    public static List<string> AddDestination(List<string> route, string destination)
    {
        var newRoute = new List<string>(route)
        {
            destination
        };
        return newRoute;
    }

    // Ziel ändern Funktion
    public static List<string> UpdateDestination(List<string> route, string oldDestination, string newDestination)
    {
        return route.Select(dest => dest.Equals(oldDestination, StringComparison.OrdinalIgnoreCase)
            ? newDestination
            : dest).ToList();
    }

    public static void Main()
    {
        var route = new List<string>();
        string input;

        Console.WriteLine("Reiseplaner - Zielorte eingeben");
        Console.WriteLine("Geben Sie '-' ein, um die Eingabe zu beenden.\n");

        // Eingabe
        do
        {
            Console.Write("Geben Sie ein Reiseziel ein: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && input.ToLower() != "-")
            {
                route = AddDestination(route, input);
            }
        } while (input.ToLower() != "-");

        Console.WriteLine("\nAktuelle Route:");
        Console.WriteLine(string.Join(" -> ", route));

        // Ziel ändern
        Console.Write("Möchten Sie ein Ziel ändern? (y/n): ");
        string change = Console.ReadLine();

        if (change.ToLower() == "y")
        {
            Console.Write("Welches Ziel möchten Sie ändern? ");
            string oldDestination = Console.ReadLine();
            Console.Write("Geben Sie das neue Ziel ein: ");
            string newDestination = Console.ReadLine();

            route = UpdateDestination(route, oldDestination, newDestination);

            Console.WriteLine("Aktualisierte Route:");
            Console.WriteLine(string.Join(" -> ", route));
        }

        Console.WriteLine("\nIhre geplante Reise ist fertig!");
    }
}
