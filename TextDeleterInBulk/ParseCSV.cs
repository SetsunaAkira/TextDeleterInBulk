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

        private bool HasNewProduct = false;

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
            char[] delimiter = { ',', ':', ';', '=' };
            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<ParsedText>().ToList();

            //CarrierStrings
            foreach(ParsedText text in records)
            {
                CutStrings(text.CarrierString, delimiter);
                Console.WriteLine(text.CarrierString);
            }

            /*
             //CustomField1
             * foreach(ParsedText text in records)
            {
                CutStrings(text.CarrierString, delimiter);
                Console.WriteLine(text.CarrierString);
                if(HasNewProduct == false)
                {
                    strings.Add("N");
                }
            }
            */
        }

        /* the actual Splitter */
        private void CutStrings(string text, char[] delimiter)
        {
            List<string> textSplit = text.Split(delimiter).ToList();

            //CarrierString
        
            if(textSplit.Count > 2)
            {
                strings.Add(textSplit[2]);
             }
                
        
            /*
             //CustomField1
             * foreach (string contents in textSplit)
            {
               if(contents == "595" || contents == "594" || contents == "591" || contents == "590" || contents == "589")
                {
                    strings.Add("Y");
                    HasNewProduct = true;
                    break;
                }
               else HasNewProduct = false;
            }
             */
        }

        private static async void WriteToFile(List<string> strings)
        {
            await File.WriteAllLinesAsync("C:\\Users\\Colby\\Documents\\Projects\\Completed Projects\\TextDeleterInBulk\\Files\\CarrierStringMemPacks.txt", strings);
        }

        #endregion
    }
}
