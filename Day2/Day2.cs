using Helpers;

namespace AdventOfCode2024.Day2
{
    public class Day2
    {
        private FileHelpers fileHelpers = new FileHelpers();
        
        public void FindAmountSafeReports()
        {
            int total = 0;

            var reports = GetReports(fileHelpers.GetFileStream("Resources/day2_input.txt"));

            foreach (var report in reports)
            {
                bool isSafe = GetReportSafetyLevel(report);

                if (isSafe) total += 1;
            }

            LogResult("Total safe reports: ", total);
        }

        private bool GetReportSafetyLevel(List<int> report)
        {
            if (IsValidReport(report))
                return true;

            for (int i = 0; i < report.Count; i++)
            {
                var modifiedReport = new List<int>(report);
                modifiedReport.RemoveAt(i); 

                if (IsValidReport(modifiedReport))
                    return true;
            }

            return false; 
        }

        private bool IsValidReport(List<int> report)
        {
            int lastLevel = report.First();
            bool isAscending = true;
            bool isDescending = true;

            foreach (var level in report.Skip(1))
            {
                if (Math.Abs(level - lastLevel) > 3 || Math.Abs(level - lastLevel) < 1)
                    return false;

                if (level > lastLevel)
                    isDescending = false; 
                else if (level < lastLevel)
                    isAscending = false;

                lastLevel = level;
            }

            return isAscending || isDescending;
        }
        
        private List<List<int>> GetReports(StreamReader fileStream)
        {
            var reports = new List<List<int>>();

            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                reports.Add(GetLevels(line));
            }

            return reports;
        }

        private List<int> GetLevels(string line)
        {
            List<int> levelsList = new List<int>();
            string[] levelsArray = line.Split(" ");
            
            foreach (var level in levelsArray)
            {
                levelsList.Add(Convert.ToInt32(level));
            }

            return levelsList;
        }

        private void LogResult(string label, int total)
        {
            System.Diagnostics.Debug.WriteLine($"{label}: {total}");
        }
    }
}