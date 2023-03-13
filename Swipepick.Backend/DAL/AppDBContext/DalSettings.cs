using Microsoft.Extensions.Configuration;

public class DalSetting
{
    public string ConnectionString { get; private set; }

    public DalSetting(IConfiguration configuration)
    {
        ConnectionString = configuration.GetSection("Dal").GetValue<string>("TestConnection");
    }
}