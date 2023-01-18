using Ex_exceptions;
using System.Reflection;


Student fulano = new Student();
Console.WriteLine("Exibindo propriedades");
DisplayPublicProperties(fulano);

Console.WriteLine();
Console.WriteLine("Criando uma instância");
CreateInstance();

static void DisplayPublicProperties(object obj)
{
    Type t = obj.GetType();
    var propriedades = t.GetProperties();
    foreach (PropertyInfo property in propriedades)
    {
        Console.WriteLine(property.Name);
    }
}

static void CreateInstance()
{
    Type t = typeof(Student);
    object obj = Activator.CreateInstance(t);
    PropertyInfo nameProp = t.GetProperty("Name");
    nameProp.SetValue(obj, "Fulano");
    PropertyInfo universityProp = t.GetProperty("University");
    universityProp.SetValue(obj, "faculdade XYZ");
    PropertyInfo rollNumberProp = t.GetProperty("RollNumber");
    rollNumberProp.SetValue(obj, 12345);
    MethodInfo displayMethod = t.GetMethod("DisplayInfo");
    displayMethod.Invoke(obj, null);
}
