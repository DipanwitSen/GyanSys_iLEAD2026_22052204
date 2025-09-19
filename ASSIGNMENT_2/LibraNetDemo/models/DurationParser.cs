using System;
using System.Text.RegularExpressions;

namespace LibraNetDemo.Models
{
    public static class DurationParser
    {
        private static readonly Regex Token = new Regex("(\\d+)\\s*(w|week|weeks|d|day|days|h|hour|hours|m|min|minute|minutes|s|sec|second|seconds)", RegexOptions.IgnoreCase);

        public static TimeSpan Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("empty duration");
            MatchCollection matches = Token.Matches(input);
            if (matches.Count == 0)
            {
                string s = input.Trim();
                if (int.TryParse(s, out int daysOnly))
                {
                    return TimeSpan.FromDays(daysOnly);
                }
                throw new FormatException("could not parse duration: " + input);
            }

            TimeSpan total = TimeSpan.Zero;
            foreach (Match m in matches)
            {
                int value = int.Parse(m.Groups[1].Value);
                string unit = m.Groups[2].Value.ToLower();
                switch (unit)
                {
                    case "w":
                    case "week":
                    case "weeks":
                        total = total.Add(TimeSpan.FromDays(value * 7));
                        break;
                    case "d":
                    case "day":
                    case "days":
                        total = total.Add(TimeSpan.FromDays(value));
                        break;
                    case "h":
                    case "hour":
                    case "hours":
                        total = total.Add(TimeSpan.FromHours(value));
                        break;
                    case "m":
                    case "min":
                    case "minute":
                    case "minutes":
                        total = total.Add(TimeSpan.FromMinutes(value));
                        break;
                    case "s":
                    case "sec":
                    case "second":
                    case "seconds":
                        total = total.Add(TimeSpan.FromSeconds(value));
                        break;
                    default:
                        throw new FormatException("unknown unit: " + unit);
                }
            }
            return total;
        }
    }
}
