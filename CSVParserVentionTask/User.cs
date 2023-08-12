using Microsoft.EntityFrameworkCore;

namespace CSVParserVentionTask;
[PrimaryKey("useridentifier")]
public class User
{
    [CsvHelper.Configuration.Attributes.Index(0)]
    public int useridentifier { get; set; }

    [CsvHelper.Configuration.Attributes.Index(1)]
    public string username { get; set; }

    [CsvHelper.Configuration.Attributes.Index(2)]
    public int age { get; set; }

    [CsvHelper.Configuration.Attributes.Index(3)]
    public string city { get; set; }

    [CsvHelper.Configuration.Attributes.Index(4)]
    public string phonenumber { get; set; }

    [CsvHelper.Configuration.Attributes.Index(5)]
    public string email { get; set; }
}