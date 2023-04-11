using StackExchange.Redis;

public class CacheConnection
{
    private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
    {


        var options = new ConfigurationOptions
        {
            EndPoints = { { "127.0.0.1", 6379 } },
            ConnectTimeout = 10000,
            SyncTimeout = 10000,
            AbortOnConnectFail = false
        };

        return ConnectionMultiplexer.Connect(options);


    }, System.Threading.LazyThreadSafetyMode.PublicationOnly);

    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}

public class RedisConnectorHelper
{


    static RedisConnectorHelper()
    {
        var options = new ConfigurationOptions
        {
            EndPoints = { { "127.0.0.1", 6379 } },
            ConnectTimeout = 10000,
            SyncTimeout = 10000,
            AbortOnConnectFail = false
        };
        RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(options);
        });
    }

    private static Lazy<ConnectionMultiplexer> lazyConnection;

    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}
