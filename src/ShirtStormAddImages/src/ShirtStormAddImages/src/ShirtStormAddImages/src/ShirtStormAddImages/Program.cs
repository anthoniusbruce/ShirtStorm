using System.Data;
using Microsoft.Data.SqlClient;

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShirtStorm;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

var connectionStringFollows = false;
var files = new List<string>();
foreach (string arg in args)
{
    if (arg == "--connectionstring")
    {
        connectionStringFollows |= true;
    }
    else if (connectionStringFollows)
    {
        connectionString = arg;
        connectionStringFollows = false;
    }
    else if (Path.Exists(arg))
    {
        var fullPath = Path.GetFullPath(arg);
        files.Add(fullPath);
        Console.WriteLine("...Exists!");
    }
    else
    {
        Console.WriteLine("...Does not exist!");
    }
}

if (files.Count == 0)
{
    Console.WriteLine("Nothing to do!");
    return;
}

foreach (var imageFile in files)
{

    string queryStmt = "INSERT INTO dbo.Images(ID, Bytes) VALUES(@ImageId, @Bytes); INSERT INTO dbo.Designs(Id, Title, ImageId, DisplayOnFrontPage, Description, ReleaseDate) VALUES(@DesignId, @Title, @ImageId, @DisplayOnFrontPage, @Description, @ReleaseDate)";

    using (SqlConnection con = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(queryStmt, con))
    {
        var imageId = Guid.NewGuid();
        SqlParameter param = cmd.Parameters.Add("@ImageId", SqlDbType.UniqueIdentifier);
        param.Value = imageId;
        var imageBytes = File.ReadAllBytes(imageFile);
        param = cmd.Parameters.Add("@Bytes", SqlDbType.VarBinary);
        param.Value = imageBytes;
        param = cmd.Parameters.Add("@DesignId", SqlDbType.UniqueIdentifier);
        param.Value = Guid.NewGuid();
        param = cmd.Parameters.Add("@Title", SqlDbType.NVarChar);
        param.Value = Path.GetFileNameWithoutExtension(imageFile);
        param = cmd.Parameters.Add("@DisplayOnFrontPage", SqlDbType.Bit);
        param.Value = 1;
        param = cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
        param.Value = string.Empty;
        var imageText = Path.ChangeExtension(imageFile, ".txt");
        if (Path.Exists(imageText))
            param.Value = File.ReadAllText(imageText);
        param = cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime2);
        param.Value = new DateTime(2024, 12, 31);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}
