using static System.Formats.Asn1.AsnWriter;

// Ronda Rutherford
// January 10, 2024

namespace GA_LinearSearch
{
    internal class Program
    {

        // Declare the global arrays
        static string[] storeDirectory;
        static string[] storeCategories;
        static Store[] stores;

        static string[] allItems;
        static string[] departments;
        static Item[] items;

        static void Main(string[] args)
        {
            PreloadItems(); // Homework Assignment
            Preload(); // Example
            
            // Homework Assignment
            Console.WriteLine("Contains");
            Console.WriteLine(ContainsItem(allItems, "Bread").ToString()); // True
            Console.WriteLine(ContainsItem(allItems, "Croissants").ToString()); // False

            Console.WriteLine("Department By Index");
            Console.WriteLine(StoreByCategory(departments, "Bakery").ToString()); // 1
            Console.WriteLine(StoreByCategory(departments, "Electronics").ToString()); // -1

            Console.WriteLine("Number of items in a department");
            Console.WriteLine(NumberItemsInDepartment(departments, "Bakery").Count); // 2
            Console.WriteLine(NumberItemsInDepartment(departments, "Electronics").Count); // 0

            Console.WriteLine("All items in an aisle");
            List<Item> itemResults = AllItemsInAisle(items, "3");
            Console.WriteLine(itemResults.Count); // 2
            foreach (Item item in itemResults) { Console.WriteLine($"{item.Name} - {item.Aisle}"); }
            Console.WriteLine(AllItemsInAisle(items, "9").Count); // 0

            //// Examples
            //Console.WriteLine("Contains");
            //Console.WriteLine(ContainsStore(storeDirectory, "Aqua Adventures").ToString()); // True
            //Console.WriteLine(ContainsStore(storeDirectory, "Box Lunch").ToString()); // False

            //Console.WriteLine("Store By Index");
            //Console.WriteLine(StoreByCategory(storeCategories, "Entertainment").ToString()); // 1
            //Console.WriteLine(StoreByCategory(storeCategories, "Food").ToString()); // -1

            //Console.WriteLine("All stores of a category");
            //Console.WriteLine(AllStoresOfACategory(storeCategories, "Café & Bakery").Count); // 2
            //Console.WriteLine(AllStoresOfACategory(storeCategories, "Food").Count); // 0

            //Console.WriteLine("All stores on a floor");
            //List<Store> storeResults = AllStoresOnLevel(stores, "A");
            //Console.WriteLine(storeResults.Count); // 4
            //foreach (Store store in storeResults) { Console.WriteLine($"{store.Name} - {store.StoreLocation}"); }
            //Console.WriteLine(AllStoresOnLevel(stores, "E").Count); // 0
        }

        public static bool ContainsItem(string[] itemList, string searchKey)
        {
            foreach (string item in itemList)
            {
                if (item == searchKey)
                {
                    return true;
                }
            }
            return false;
        }

        public static int ItemByIndex(string[] itemList, string searchKey)
        {
            for (int i = 0; i < itemList.Length; i++)
            {
                if (itemList[i] == searchKey)
                {
                    return i;
                }
            }
            return -1; // Return -1 if not found
        }

        public static List<int> NumberItemsInDepartment(string[] departmentList, string searchKey)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < departmentList.Length; i++)
            {
                if (departmentList[i] == searchKey)
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        public static List<Item> AllItemsInAisle(Item[] itemList, string searchKey)
        {
            List<Item> itemsInAisle = new List<Item>();
            foreach (Item item in itemList)
            {
                if (item.Aisle[0].ToString() == searchKey)
                {
                    itemsInAisle.Add(item);
                }
            }
            return itemsInAisle;
        }
        static void PreloadItems()
        {
            // Preload sample items in a grocery store, with their department and aisle
            items = new Item[]
            {
            new Item("Apples", "Produce", "3"),
            new Item("Bananas", "Produce", "3"),
            new Item("Bread", "Bakery", "1"),
            new Item("Bagels", "Bakery", "1"),
            new Item("Milk", "Dairy", "2"),
            new Item("Cheese", "Dairy", "2"),
            new Item("Cereal", "Breakfast", "4"),
            new Item("Coffee", "Beverages", "5"),
            new Item("Pasta", "Dry Goods", "6"),
            new Item("Chicken", "Meat", "7"),
            new Item("Toilet Paper", "Household", "8")
            };

            // Populate arrays of departments and items
            //departments = items.Select(item => item.Department).Distinct().ToArray(); // Distinct departments
            departments = items.Select(item => item.Department).ToArray(); // Every instance of all departments, with repeats
            allItems = items.Select(item => item.Name).ToArray();

            //// Print the departments and items arrays
            //Console.WriteLine("Departments:");
            //foreach (string department in departments)
            //{
            //    Console.WriteLine(department);
            //}

            //Console.WriteLine("\nAll Items:");
            //foreach (string item in allItems)
            //{
            //    Console.WriteLine(item);
            //}
        }
        public static bool ContainsStore(string[] storeList, string searchKey)
        {
            foreach (string store in storeList)
            {
                if (store == searchKey)
                {
                    return true;
                }
            }
            return false;
        }

        public static int StoreByCategory(string[] storeList, string searchKey)
        {
            for (int i = 0; i < storeList.Length; i++)
            {
                if (storeList[i] == searchKey)
                {
                    return i;
                }
            }
            return -1; // Return -1 if not found
        }

        public static List<int> AllStoresOfACategory(string[] storeList, string searchKey)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < storeList.Length; i++)
            {
                if (storeCategories[i] == searchKey)
                {
                    indices.Add(i);
                }
            }
            return indices;
        }

        public static List<Store> AllStoresOnLevel(Store[] storeList, string searchKey)
        {
            List<Store> storesInCategory = new List<Store>();
            foreach (Store store in storeList)
            {
                if (store.StoreLocation[0].ToString() == searchKey)
                {
                    storesInCategory.Add(store);
                }
            }
            return storesInCategory;
        }


        static void Preload()
        {
            storeDirectory = new string[]
            {
            "Aqua Adventures",
            "Pixel Playhouse",
            "Brew & Bean",
            "Vintage Visions",
            "Garden Gateway",
            "Melody Makers",
            "Spice Spectrum",
            "Tech Trends",
            "Cozy Corner",
            "Frosty Delights"
            };

            storeCategories = new string[]
            {
            "Sports & Recreation",      // Aqua Adventures
            "Entertainment",            // Pixel Playhouse
            "Café & Bakery",            // Brew & Bean
            "Clothing & Accessories",   // Vintage Visions
            "Home & Garden",            // Garden Gateway
            "Entertainment",            // Melody Makers
            "Food & Groceries",         // Spice Spectrum
            "Electronics",              // Tech Trends
            "Home & Garden",            // Cozy Corner
            "Café & Bakery"             // Frosty Delights
            };

            stores = new Store[]
            {
            new Store("Aqua Adventures", "Sports & Recreation", "A21"),
            new Store("Pixel Playhouse", "Entertainment", "B7"),
            new Store("Brew & Bean", "Café & Bakery", "C36"),
            new Store("Vintage Visions", "Clothing & Accessories", "A9"),
            new Store("Garden Gateway", "Home & Garden", "B42"),
            new Store("Melody Makers", "Entertainment", "C15"),
            new Store("Spice Spectrum", "Food & Groceries", "A3"),
            new Store("Tech Trends", "Electronics", "B28"),
            new Store("Cozy Corner", "Home & Garden", "C12"),
            new Store("Frosty Delights", "Café & Bakery", "A31")
            };

        } // End Preload




    }
}
