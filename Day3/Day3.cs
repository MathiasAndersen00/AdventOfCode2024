using System.Text.RegularExpressions;
using Helpers;

namespace AdventOfCode2024.Day3
{
    public class Day3
    {
        private FileHelpers fileHelpers = new FileHelpers();
        private string matchMullString = @"^mul\(\d+,\d+\)$";

        public void SolveProblem()
        {
            var input = GetInputString(fileHelpers.GetFileStream("Resources/day3_input.txt"));
            var mulList = PrepareMulList(input);
        }
        private List<string> PrepareMulList(string input)
        {

            List<string> mulList = Regex.Matches(input, matchMullString)
                                        .Cast<Match>()
                                        .Select(m => m.Value)
                                        .ToList();

            return mulList;
        }

        private string GetInputString(StreamReader fileStream)
        {
            return fileStream.ReadToEnd();
        }
    }
}