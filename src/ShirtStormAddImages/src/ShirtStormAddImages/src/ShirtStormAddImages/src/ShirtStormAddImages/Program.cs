using Microsoft.Data.SqlClient;

var localConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShirtStorm;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
var files = new List<string>();
foreach (string arg in args)
{
    Console.Write(arg);
    if (Path.Exists(arg))
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

SqlConnection myConn = new SqlConnection(localConnectionString);
SqlCommand command = myConn.CreateCommand();

try
{
    myConn.Open();

    foreach (var imageFile in files)
    {
        command.CommandText =
        $@"
            BEGIN TRY
                BEGIN TRAN
                    SELECT NEWID();
                    DECLARE @imageid uniqueidentifier;
                    SET @imageid = NEWID();
                    INSERT INTO Images (Id, Bytes) SELECT @imageid, BulkColumn FROM Openrowset(Bulk '{imageFile}', Single_Blob) as img;
                    INSERT INTO Designs (Id, Title, ImageId, DisplayOnFrontPage, Description, ReleaseDate) VALUES (NEWID(), '{Path.GetFileNameWithoutExtension(imageFile)}', @imageid, 1, '', '12/31/2024 23:59:59.9999999');
                COMMIT TRAN
            END TRY
            BEGIN CATCH
                IF(@@TRANCOUNT > 0)
                    ROLLBACK TRAN;
                THROW;
            END CATCH";
        command.ExecuteNonQuery();
    }
}
catch (SqlException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    myConn.Close();
}
