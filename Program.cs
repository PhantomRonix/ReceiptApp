// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.IO;
using System.Linq.Expressions;

//main program begins here
class Program
{
    static string filePathLocations = @"locations.txt";
    static string filePathProducts = @"products.txt";

    static List<Product> productsList = new List<Product>();
    static List<Location> locationsList = new List<Location>();

    static void Main()
    {
        int userInput;
        bool programActive = true;
        while (programActive)
        {
            Console.Write("========\n1 = Add new product\n2 = Add new location\n3 = view records\n\n0 = save and exit\n========\nEnter a choice\n");
            try { userInput = Convert.ToInt16(Console.ReadLine()); }
            catch (Exception a)
            {
                Console.Clear();
                Console.WriteLine("Enter a valid number\nEnter to continue");
                Console.ReadLine();
                Console.Clear();
                continue;
            }
            //add reciept data
            switch (userInput)
            {
                //exit+save program branch
                case 0:
                    //save products
                    //init string array, large as the product list
                    //init counter integer, to position where to save export data in the array
                    string[] saveProductArray = new string[productsList.Count];
                    int i = 0;
                    foreach (Product productInList in productsList)
                    {
                        //write the exportdata to the array,then add to counter
                        saveProductArray[i] = productInList.exportSaveData();
                        i++;
                    }
                    writeToFile(saveProductArray, filePathProducts);

                    string[] saveLocationArray = new string[locationsList.Count];
                    i = 0;
                    foreach (Location locationInList in locationsList)
                    {
                        saveLocationArray[i] = locationInList.exportSaveData();
                        i++;
                    }

                    programActive = false;
                    break;

                //create new product branch
                case 1:
                    //console "wipes" after every navigation
                    //need to add loopability to add multiple products at once
                    Console.Clear();
                    Product newProduct = createNewProduct();
                    productsList.Add(newProduct);
                    Console.Clear();
                    continue;

                //create new location branch
                case 2:
                    Console.Clear();
                    Location newLocation = createNewLocation();
                    locationsList.Add(newLocation);
                    Console.Clear();
                    continue;

                //view records branch
                case 3:
                    Console.Clear();
                    continue;

                //you fucked up branch
                default:
                    Console.Clear();
                    continue;
            }
        }
        Environment.Exit(0);
    }

    //main program ends here

    //functions
    //main file-handling funcs

    //func responsible for writing to file
    //parse in an array of all products
    //each individual member of the array should be generated using
    //product.exportSaveData method
    static void writeToFile(string[] productList, string filepath)
    {
        //init the string that is written to file
        string fileWrite = "";
        //for each member of the array, add to output string, then add newline
        foreach (string product in productList) { fileWrite += product + "\n"; }
        //uhh idk if I need the last new line char, so i'll comment this for now
        //fileWrite = fileWrite.Remove(0, fileWrite.Length - 1);
        File.WriteAllText(filePathProducts, fileWrite);
    }

    //loads products from text file into a list of string arrays
    //each term of the list is a new product
    //each term of the inside arrays is a detail of the product
    static List<string[]> loadProductFromFile()
    {
        //init output, then grab the raw string from the file
        List<string[]> output = new List<string[]>();
        string productTextFile = File.ReadAllText(filePathProducts, Encoding.UTF8);
        //splits the raw text into array, split by each new line
        string[] productLinesArray = productTextFile.Split("\n");
        //for each line, separate it by "," then add the resultant array to output
        foreach (string line in productLinesArray)
        {
            string[] linesSplit = line.Split(",");
            output.Add(linesSplit);
        }
        return output;
    }

    //Branch functions
    //asks relevant questions and creates new product entry
    static Product createNewProduct()
    {
        //change this later for actual id code system
        int newID = 0;
        string volumeMessage = "";

        Console.WriteLine("Enter the product name");
        string newProductName = Console.ReadLine();

        Console.WriteLine("Enter the product brand");
        string newBrandName = Console.ReadLine();

        Console.WriteLine("How is the product measured?\n1=Weight\n2=Volume\n3=Amount");
        int newVolumeType = Convert.ToInt16(Console.ReadLine());
        switch (newVolumeType)
        {
            case 1:
                volumeMessage = "Enter the weight of the product in grams";
                break;
            case 2:
                volumeMessage = "Enter the volume of the product in mililitres";
                break;
            case 3:
                volumeMessage = "Enter the amount of product";
                break;
            default:
                //do something
                break;

        }
        Console.WriteLine(volumeMessage);
        float newVolume = Convert.ToSingle(Console.ReadLine());

        Product a = new Product(newID, newProductName, newBrandName, newVolumeType, newVolume);
        return a;
    }

    static Location createNewLocation()
    {
        Console.WriteLine("Enter the location name");
        string newLocationName = Console.ReadLine();

        Console.WriteLine("Enter the retailer\n1 = ASDA\n2 = Tesco\n3 = Sainsbury\n4 = Morrisons\n5 = Lidl\n6 = Aldi\n7 = Other");
        int newLocationRetailer = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("What sort of store is it?\n1 = Convenience Store\n2 = Medium-Sized\n3 = Supermarket");
        int newStoreType = Convert.ToInt16(Console.ReadLine());

        Location a = new Location(newLocationName, newStoreType, newLocationRetailer);
        return a;
    }
}