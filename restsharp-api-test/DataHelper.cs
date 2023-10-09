using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using restsharp_api_test.model;

namespace restsharp_api_test
{
    internal class DataHelper
    {
        public static Phone getPhoneData() {
            Phone phone = new Phone();
            phone.Name = "Apple 26";
            Data data = new Data();
            data.Year = 2023;
            data.Price = 100;
            data.CpuModel = "Intel Core 9";
            data.HardDiskSize = "1 TB";
            phone.Data = data;
            return phone; }
    }
}
