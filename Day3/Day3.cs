using System.Text.RegularExpressions;
using Helpers;

namespace AdventOfCode2024.Day3
{
    public class Day3
    {
        private FileHelpers fileHelpers = new FileHelpers();
        private string matchMullString = @"(mul\s*\(\s*\d+\s*,\s*\d+\s*\))|(d\s*o\s*\(\))|(d\s*o\s*n\s*'\s*t\s*\(\))";

        public void SolveProblem()
        {
            var input = GetInputString(fileHelpers.GetFileStream("Resources/day3_input.txt"));
            var fullMulList = new List<string>();
            foreach (var line in input)
            {
                var mulList = PrepareMulList(line);
                fullMulList.AddRange(mulList);
            }

            var total = MultiplyDoDont(fullMulList);

            LogResult("Day 3 part 2", total);
        }

        private int MultiplyDoDont(List<string> mulList)
        {
            bool pleaseDo = true;

            int total = 0;

            foreach (var value in mulList)
            {
                Match match = Regex.Match(value, matchMullString);
                if (match.Groups[1].Success && pleaseDo) total += MultiplyFromString(value);
                if (match.Groups[2].Success) pleaseDo = true;
                if (match.Groups[3].Success) pleaseDo = false;
            }
            return total;
        }

        private int MultiplyFromString(string input)
        {
            string pattern = @"mul\((\d+),(\d+)\)";

            Match match = Regex.Match(input, pattern);

            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);

            return num1 * num2;
        }

        private List<string> PrepareMulList(string input)
        {
            List<string> mulList = new List<string>();
            var matches = Regex.Matches(input, matchMullString);
            foreach (Match match in matches)
            {
                mulList.Add(match.Value);
            }

            return mulList;
        }

        private List<string> GetInputString(StreamReader fileStream)
        {
            List<string> inputStrings = [];
            string line;

            while ((line = fileStream.ReadLine()) != null)
            {
                inputStrings.Add(line);
            }
            
            return inputStrings;
        }

        private void LogResult(string label, int total)
        {
            System.Diagnostics.Debug.WriteLine($"{label}: {total}");
        }
    }
}