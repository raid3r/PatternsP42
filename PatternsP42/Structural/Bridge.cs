using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Structural;

public class Data
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public interface IDataFileWriter
{
    void WriteToFile(string filePath, Data data);
}

public class JsonDataFileWriter : IDataFileWriter
{
    public void WriteToFile(string filePath, Data data)
    {
        Console.WriteLine($"Writing data to JSON file: {filePath}");
        // Here you would implement the actual JSON serialization and file writing logic.
    }
}


public class XmlHelper {
    public void CommonMethod()
    {

    }
}


public class XmlDataFileReaderWriter : IDataFileWriter
{
    public void WriteToFile(string filePath, Data data)
    {
        Console.WriteLine($"Writing data to XML file: {filePath}");
        // Here you would implement the actual XML serialization and file writing logic.
        var helper = new XmlHelper();
        helper.CommonMethod();
    }

}

public class XmlDataFileReader : IDataFileReader
{
    public Data? ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading data from XML file: {filePath}");
        var helper = new XmlHelper();
        helper.CommonMethod();
        // Here you would implement the actual XML deserialization and file reading logic.
        return new Data { Title = "Sample Title", Content = "Sample Content" };
    }
}


public interface IDataFileReader
{
    Data? ReadFromFile(string filePath);
}

public class JsonDataFileReader : IDataFileReader
{
    public Data? ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading data from JSON file: {filePath}");
        // Here you would implement the actual JSON deserialization and file reading logic.
        return new Data { Title = "Sample Title", Content = "Sample Content" };
    }
}


class FileManager
{
    public FileManager(IDataFileReader reader, IDataFileWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    private IDataFileReader _reader;
    private IDataFileWriter _writer;

    public void SetReader(IDataFileReader reader)
    {
        _reader = reader;
    }

    public void SetWriter(IDataFileWriter writer)
    {
        _writer = writer;
    }

    public void SaveData(string filePath, Data data)
    {
        _writer.WriteToFile(filePath, data);
    }

    public Data? LoadData(string filePath)
    {
        return _reader.ReadFromFile(filePath);
    }

}



