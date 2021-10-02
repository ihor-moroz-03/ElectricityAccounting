using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityAccounting
{
    class QuarterReport
    {
        static string[,] _months;
        string[] _flatReports;

        static QuarterReport()
        {
            _months = new[,]
            {
                { "January", "February", "Match" },
                { "April", "May", "June" },
                { "July", "August", "September" },
                { "October", "November", "December"}
            };
        }

        public QuarterReport(uint quarter, params FlatRecord[] records)
        {
            GetReport(quarter, records);
        }

        public QuarterReport(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);
            uint quarter = uint.Parse(lines[0].Split(' ')[1]);

            var records = new FlatRecord[lines.Length - 1];
            for (int i = 0; i < records.Length; ++i)
            {
                FlatRecord.TryParse(lines[i + 1], out records[i]);
            }

            GetReport(quarter, records);
        }

        public QuarterReport() : this(0)
        {
        }

        public string this[int index] => _flatReports[index];

        public static string GetSingleFlatReport(uint quarter, FlatRecord rec) =>
            $"Flat #{rec.ID:d3}\n" +
            $"Owner: {rec.Owner}\n" +
            $"{_months[quarter - 1, 0]}: {rec[1] - rec[0]}kWh\n" +
            $"{_months[quarter - 1, 1]}: {rec[2] - rec[1]}kWh\n" +
            $"{_months[quarter - 1, 2]}: {rec[3] - rec[2]}kWh\n";

        void GetReport(uint quarter, FlatRecord[] records)
        {
            _flatReports = new string[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                _flatReports[i] = GetSingleFlatReport(quarter, records[i]);
            }
        }

        public override string ToString() => string.Join<string>('\n', _flatReports);
    }
}
