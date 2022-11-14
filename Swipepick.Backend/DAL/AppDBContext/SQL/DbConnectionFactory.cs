using System.Data;

public class DbConnectionFactory
{
    private readonly DalSetting _dalSetting;

    private IDbConnection _dbConnection;

    public DbConnectionFactory(DalSetting dalSetting)
    {
        _dalSetting = dalSetting;
    }
}
