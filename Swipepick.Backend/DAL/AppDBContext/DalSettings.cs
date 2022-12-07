using Microsoft.Extensions.Configuration;

public class DalSetting
{
    public string ConnectionString { get; }

    public DalSetting(IConfiguration configuration)
    {
        ConnectionString = configuration.GetSection("Dal").GetValue<string>("ConnectionString");
    }
}