using System;
using System.DirectoryServices;

class Test
{
    static void Main(string[] args)
    {
        // the name of the domain
        DirectoryEntry entry = new DirectoryEntry(@"LDAP://HOYA.LOCAL");
        entry.Username = @"hoya\sooksinchai";
        entry.Password = @"Petch@0526";
        Console.WriteLine("Name = " + entry.Name);
        Console.WriteLine("Path = " + entry.Path);
        Console.WriteLine("SchemaClassName = " + entry.SchemaClassName);
        Console.WriteLine("Properties:");
        Console.WriteLine("=====================================");

        foreach (string key in entry.Properties.PropertyNames)
        {
            try
            {
                Console.WriteLine("\t" + key + " = ");
                foreach (Object objCollection in entry.Properties[key])
                    Console.WriteLine("\t\t" + objCollection);
                Console.WriteLine("===================================");
            }
            catch
            {
            }
        }
        System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(entry);
        mySearcher.Filter = ("(objectClass=*)");
        Console.WriteLine("Active Directory Information");
        Console.WriteLine("=====================================");
        foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
        {
            try
            {
                Console.WriteLine(resEnt.GetDirectoryEntry().Name.ToString());
                Console.WriteLine(resEnt.GetDirectoryEntry().Path.ToString());
                Console.WriteLine(
                resEnt.GetDirectoryEntry().NativeGuid.ToString());
                Console.WriteLine("===================================");
            }
            catch
            {
            }
        }
    }
}