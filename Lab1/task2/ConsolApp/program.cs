using System;
using System.Linq;
using System.Reflection;
using DeviceLibrary;

class Program
{
    static void Main()
    {
        // Loading an assembly with the required namespace
        Assembly libraryAssembly = typeof(Tablet).Assembly;

        Console.WriteLine("Classes in library TablesLibrary:\n");

        var types = libraryAssembly.GetTypes()
                    .Where(t => t.IsClass && t.Namespace == "TablesLibrary");

        foreach (var type in types)
        {
            Console.WriteLine($"Class: {type.Name}");

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                string access = prop.GetMethod.IsPublic ? "Public" : "Private";
                Console.WriteLine($"  - {access} property: {prop.Name} ({prop.PropertyType.Name})");
            }

            Console.WriteLine();
        }
    }
}
