using TextDeleterInBulk;

string Basefilepath = Environment.CurrentDirectory;
string CarrierString = Path.Combine(Basefilepath, @"Files\CarrierString.CSV");
string MemShipPackCustomField = Path.Combine(Basefilepath, @"Files\CustomField.CSV");

ParseCSV parse = new();
parse.Run(MemShipPackCustomField);