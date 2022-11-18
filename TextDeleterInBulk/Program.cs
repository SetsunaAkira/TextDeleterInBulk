using TextDeleterInBulk;

string Basefilepath = Environment.CurrentDirectory;
string CarrierString = Path.Combine(Basefilepath, @"Files\CarrierString.CSV");
string MemShipPackCustomField = Path.Combine(Basefilepath, @"Files\CustomField.CSV");
string MemShipCarrierString = Path.Combine(Basefilepath, @"Files\CarrierStringMemPacks.CSV");
string MemShipCustomFieldEmRuby = Path.Combine(Basefilepath, @"Files\EmeraldRubyMempacks.CSV");
string MemShipCarrierStringEmRuby = Path.Combine(Basefilepath, @"Files\EmRubyCarrierString.CSV");

ParseCSV parse = new();
parse.Run(MemShipCarrierStringEmRuby);