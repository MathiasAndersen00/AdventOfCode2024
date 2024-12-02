using Helpers;

namespace AdventOfCode2024.Day1
{
    public class Day1
    {
        private FileHelpers fileHelpers = new FileHelpers();

        public void FindTotalDistance()
        {
            var (list1, list2) = PrepareLists("Resources/day1_input.txt");

            int total = list1
                .Zip(list2, (a, b) => Math.Abs(a - b))
                .Sum(); 

            LogResult("Total distance", total);
        }

        public void FindTotalOccurrences()
        {
            var (list1, list2) = PrepareLists("Resources/day1_input.txt");

            int total = list1
                .Sum(value => findOccurrences(value, list2) * value); 

            LogResult("Total occurrences", total);
        }

        private (List<int>, List<int>) PrepareLists(string filePath)
        {
            var valuePairList = GetValuePairList(fileHelpers.GetFileStream(filePath));

            var list1 = valuePairList.Select(pair => pair.Item1).OrderDescending().ToList();
            var list2 = valuePairList.Select(pair => pair.Item2).OrderDescending().ToList();

            return (list1, list2);
        }

        private List<Tuple<int, int>> GetValuePairList(StreamReader fileStream)
        {
            var valuePairList = new List<Tuple<int, int>>();

            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                valuePairList.Add(GetValuePair(line));
            }

            return valuePairList;
        }

        private Tuple<int, int> GetValuePair(string line)
        {
            string[] numbers = line.Split("   ");
            return new Tuple<int, int>(Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]));
        }

        private int findOccurrences(int value, List<int> comparisonList)
        {
            return comparisonList.Count(c => c == value);
        }

        private void LogResult(string label, int total)
        {
            System.Diagnostics.Debug.WriteLine($"{label}: {total}");
        }
    }
}
