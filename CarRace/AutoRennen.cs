
public class AutoRennen
{
    // Entfernt Warm-up
    public static List<double> GetEffectiveLapTimes(List<double> lapTimes)
    {
        return lapTimes.Skip(1).ToList();
    }

    // Gesamtzeit berechnen
    public static double CalculateTotalTime(List<double> lapTimes)
    {
        return GetEffectiveLapTimes(lapTimes).Sum();
    }

    // Durchschnittszeit berechnen
    public static double CalculateAverageTime(List<double> lapTimes)
    {
        var effectiveTimes = GetEffectiveLapTimes(lapTimes);
        return effectiveTimes.Count > 0 ? effectiveTimes.Average() : 0;
    }

    public static void Main()
    {
        // Eingabe von Autos/Rundenzeit
        var autos = new Dictionary<string, List<double>>
        {
            { "Auto 1", new List<double> { 70.0, 68.5, 69.0, 67.5 } },
            { "Auto 2", new List<double> { 72.0, 71.0, 70.5, 70.0 } },
            { "Auto 3", new List<double> { 74.0, 73.5, 73.0 } }
        };

        Console.WriteLine("Autorennen-Auswertung: ");

        foreach (var entry in autos)
        {
            string name = entry.Key;
            var times = entry.Value;

            double total = CalculateTotalTime(times);
            double avg = CalculateAverageTime(times);

            Console.WriteLine($"{name}:");
            Console.WriteLine($"Gesamtzeit (ohne Warm-up): {total} Sekunden");
            Console.WriteLine($"Durchschnitt pro Runde: {avg:F2} Sekunden");
        }
    }
}
