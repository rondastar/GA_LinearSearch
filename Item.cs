using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GA_LinearSearch
{
    // Items in a grocery store
    public class Item

    {

        public string Name { get; set; }

        public string Department { get; set; }

        public string Aisle { get; set; }



        public Item(string name, string department, string aisle)

        {

            Name = name;

            Department = department;

            Aisle = aisle;

        }

    }
}
