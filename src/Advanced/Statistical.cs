using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculatorApp.Statistical;

public class Statistical
{
    public double Result { get; private set; }
    public double Mean(IEnumerable<double> numbers) => numbers.Average();
    public double Median(IEnumerable<double> numbers)
    {
        var sorted = numbers.OrderBy(n => n).ToArray();
        int count = sorted.Length;
        return (count % 2 == 0) ? (sorted[count / 2 - 1] + sorted[count / 2]) / 2.0 : sorted[count / 2];
    }
    public List<double> Mode(IEnumerable<double> numbers)
    {
        var grouped = numbers.GroupBy(n => n).Select(g => new { Number = g.Key, Count = g.Count() }).ToList();
        int maxcount = grouped.Max(g => g.Count);
        return grouped.Where(g => g.Count == maxcount).Select(g => g.Number).ToList();
    }

    public double Variance(IEnumerable<double> numbers)
    {
        double mean = Mean(numbers);
        return numbers.Select(n => Math.Pow(n - mean, 2)).Average();
    }
    public double StandardDeviation(IEnumerable<double> numbers) => Math.Sqrt(Variance(numbers));
    public double Sum(IEnumerable<double> numbers) => numbers.Sum();
    public double Range(IEnumerable<double> numbers) => numbers.Max() - numbers.Min();
    public double Min(IEnumerable<double> numbers) => numbers.Min();
    public double Max(IEnumerable<double> numbers) => numbers.Max();
    public double Percentile(IEnumerable<double> numbers, double percentile)
    {
        var sorted = numbers.OrderBy(n => n).ToArray();
        double position = (sorted.Length - 1) * (percentile / 100.0);
        int lower = (int)Math.Floor(position);
        int upper = (int)Math.Ceiling(position);
        if (lower == upper)
            return sorted[lower];
        // p=x(n+1)/100
        return sorted[lower] + (sorted[upper] - sorted[lower]) * (position - lower);
    }

}