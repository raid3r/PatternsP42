using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;

public interface IDatabase
{
    string GetData(string key);
}


public class Database: IDatabase
{
    public string GetData(string key)
    {
        Console.WriteLine($"Accessing database for key: {key}");
        Thread.Sleep(1000); // Simulate time-consuming database access 
        Console.WriteLine($"Data retrieved for key: {key}");
        return $"Data for key: {key} from the database.";
    }
}


public class TestDatabaseProxy: IDatabase
{
    public string GetData(string key)
    {
        Console.WriteLine($"TestDatabaseProxy: Simulating database access for key: {key}");
        return $"Test data for key: {key}.";
    }
}


public class DatabaseProxy: IDatabase
{
    private readonly Lazy<IDatabase> _database; // Action<IDatabase> ;
    private readonly Dictionary<string, string> _cache;
    public DatabaseProxy(Lazy<IDatabase> database)
    {
        _database = database;
        _cache = new Dictionary<string, string>();
    }
    public string GetData(string key)
    {
        if (_cache.ContainsKey(key))
        {
            Console.WriteLine($"Returning cached data for key: {key}");
            return _cache[key];
        }
        else
        {
            var data = _database.Value.GetData(key);
            _cache[key] = data; // Cache the result for future requests
            return data;
        }
    }
}


class LoggingDatabaseProxy: IDatabase
{
    private readonly IDatabase _database;
    public LoggingDatabaseProxy(IDatabase database)
    {
        _database = database;
    }
    public string GetData(string key)
    {
        Console.WriteLine($"LoggingDatabaseProxy: Requesting data for key: {key}");
        var data = _database.GetData(key);
        Console.WriteLine($"LoggingDatabaseProxy: Received data for key: {key}");
        return data;
    }
}

