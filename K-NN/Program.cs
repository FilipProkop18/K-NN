class Program
{
    static void Main(string[] args)
    {
        // Trénovací data
        List<Tuple<double, double, string>> trainingData = new List<Tuple<double, double, string>>()
        {
            Tuple.Create(1.0, 2.0, "ClassA"),
            Tuple.Create(2.0, 3.0, "ClassA"),
            Tuple.Create(3.0, 4.0, "ClassB"),
            Tuple.Create(4.0, 5.0, "ClassB")
        };

        // Nový vstupní bod, který chceme klasifikovat
        Tuple<double, double> inputPoint = Tuple.Create(2.5, 4.0);

        // Počet nejbližších sousedů, které budeme brát v úvahu
        int k = 3;

        // Výpočet vzdálenosti od vstupního bodu ke všem bodům v trénovacích datech
        List<Tuple<double, string>> distances = new List<Tuple<double, string>>();
        foreach (var point in trainingData)
        {
            double distance = Math.Sqrt(Math.Pow(point.Item1 - inputPoint.Item1, 2) + Math.Pow(point.Item2 - inputPoint.Item2, 2));
            distances.Add(Tuple.Create(distance, point.Item3));
        }

        // Seřazení bodů v trénovacích datech podle vzdálenosti
        distances.Sort();

        // Výběr k nejbližších sousedů
        List<string> neighbors = new List<string>();
        for (int i = 0; i < k; i++)
        {
            neighbors.Add(distances[i].Item2);
        }

        // Určení třídy nového bodu na základě tříd nejbližších sousedů
        string predictedClass = neighbors.GroupBy(x => x)
                                          .OrderByDescending(g => g.Count())
                                          .First()
                                          .Key;

        // Výpis predikované třídy
        Console.WriteLine("Predikovaná třída pro vstupní bod ({0}, {1}) je {2}", inputPoint.Item1, inputPoint.Item2, predictedClass);
    }
}