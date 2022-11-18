using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace TextDeleterInBulk
{

    public class ParsedText
    {
        public string? CarrierString { get; set; }
    }
    internal class ParseCSV
    {
        private readonly List<string> strings = new List<string>();

        #region Main
        public void Run(string file)
        {
            CsvConfiguration config = CreateConfig();
            Parse(file, config);
            WriteToFile(strings);
        }
        #endregion



        #region Helpers
        private static CsvConfiguration CreateConfig()
        {
            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            return config;
        }

        /*Gets a record of everything given in a file seperated by , : and ; */
        private void Parse(string file, CsvConfiguration config)
        {
            char[] delimiter = { ',', ':' ,';'};
            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<ParsedText>().ToList();

            foreach(ParsedText text in records)
            {
                CutStrings(text.CarrierString, delimiter);
                Console.WriteLine(text.CarrierString);
            }
        }

        /* the actual Splitter */
        private void CutStrings(string text, char[] delimiter)
        {
            List<string> textSplit = text.Split(delimiter).ToList();

            for (int i = 0; i < textSplit.Count; i++)
            {
                if(textSplit.Count > 2)
                {
                    strings.Add(textSplit[2]);
                }
                
                break;
            }
        }

        private static async void WriteToFile(List<string> strings)
        {
            await File.WriteAllLinesAsync("C:\\Users\\Colby\\Documents\\Projects\\TextDeleterInBulk\\CarrierStrings.txt", strings);
        }

        #endregion
    }
}
