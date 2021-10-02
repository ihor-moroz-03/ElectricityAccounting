using System;
using System.Text.RegularExpressions;

namespace ElectricityAccounting
{
    class FlatRecord
    {
        private uint[] _records;

        public FlatRecord(uint id, string owner, uint[] records)
        {
            (ID, Owner, _records) = (id, owner, records);
        }

        public FlatRecord() : this(0, "", new uint[4])
        {
        }

        public uint ID { get; private set; }
        public string Owner { get; private set; }
        public uint this[int index] => _records[index];

        public static bool TryParse(string s, out FlatRecord flat)
        {
            var match = Regex.Match(s, @"\[?(\d+)\]? (?:Owner: )?(\w+) (?:Records: )?(\d+) (\d+) (\d+) (\d+)");

            try
            {
                flat = new FlatRecord(
                    uint.Parse(match.Groups[1].Value),
                    match.Groups[2].Value,
                    new[] {
                         uint.Parse(match.Groups[3].Value),
                         uint.Parse(match.Groups[4].Value),
                         uint.Parse(match.Groups[5].Value),
                         uint.Parse(match.Groups[6].Value)
                    }
               );
            }
            catch (FormatException)
            {
                Console.WriteLine("Format of text seems to be wrong, check it and try again");
                flat = new FlatRecord();
            }

            return match.Success;
        }

        public override string ToString() =>
            $"[{ID:d3}] Owner: {Owner} Records: {_records[0]} {_records[1]} {_records[2]} {_records[3]}";
    }
}
