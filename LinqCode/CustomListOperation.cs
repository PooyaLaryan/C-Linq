using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode
{
    internal class CustomListOperation<T> : List<T> where T : IDto
    {
        public List<int> GetVendors()
        {
            return this.Select(x=>x.VendorId).ToList();
        }
        public List<string?> GetVendorParcelCodes(int vendorId)
        {
            return this.Where(x=>x.VendorId == vendorId).Select(x=>x.VendorParcelCode).ToList();
        }
    }

    internal interface IDto
    {
        public int VendorId { get; set; }
        public string? VendorParcelCode { get; set; }
    }

    public class FleetDto : IDto
    {
        public int VendorId { get; set; }
        public string? VendorParcelCode { get; set; }
    }



    public class TestCustomList
    {
        public void Run()
        {
            CustomListOperation<FleetDto> customListOperation = new()
            {
                new FleetDto { VendorId = 37, VendorParcelCode = "123458784"},
                new FleetDto { VendorId = 37, VendorParcelCode = "856485458"},
                new FleetDto { VendorId = 38, VendorParcelCode = "966342133"},
            };

            var vendor = customListOperation.GetVendors().First();
            var parcelCodes = customListOperation.GetVendorParcelCodes(vendor);
        }
    }
}
