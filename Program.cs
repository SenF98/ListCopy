// See https://aka.ms/new-console-template for more information
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;

Console.WriteLine("Hello, World!");

DataClass dc1 = new DataClass("0.1", 1);
DataClass dc2 = new DataClass("0.2", 2);
List<DataClass> dataClasses = new List<DataClass> { dc1, dc2 };
List<DataClass> dataClasses2 = new List<DataClass>();
foreach(DataClass dc in dataClasses)
{
    dataClasses2.Add(Clone<DataClass>(dc));
}
dataClasses.ForEach(i => Console.WriteLine(i));
dataClasses2.ForEach(i => Console.WriteLine(i));
dataClasses2[1].value = 3;
dataClasses2.ForEach(i => Console.WriteLine(i));
dataClasses.ForEach(i => Console.WriteLine(i));


static T Clone<T>(T RealObject)
{
    using (Stream objectStream = new MemoryStream())
    {
        IFormatter formatter = new BinaryFormatter();
        formatter.Serialize(objectStream, RealObject);
        objectStream.Seek(0, SeekOrigin.Begin);
        return (T)formatter.Deserialize(objectStream);
    }
}

[Serializable]
class DataClass
{
    public string offset { get; set; }
    public int value { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Offset:" + offset);
        sb.Append("Value:" + value );
        string rs = sb.ToString();
        return rs;
    }
    public DataClass(string offset,int value)
    {
        this.value = value;
        this.offset = offset;
    }
}



