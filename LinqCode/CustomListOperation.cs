using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode
{
    public class CustomListOperation<T> : List<T> where T : IDto
    {
        public CustomListOperation(){}
        public CustomListOperation(IEnumerable<T> collection) : base(collection) { }

        private IDictionary<int, SendToVendor> CandidateVendor => new Dictionary<int, SendToVendor>()
        {
            { (int)SendToVendor.Okala, SendToVendor.Okala },
            { (int)SendToVendor.TapsiFood, SendToVendor.TapsiFood },
            { (int)SendToVendor.TapsiPharmacy, SendToVendor.TapsiPharmacy }
        };

        public IEnumerable<SendToVendor> SendToVendors
        {
            get
            {
                List<SendToVendor> sendToVendors = new List<SendToVendor>();

                foreach (var vendor in GetVendors())
                {
                    if (CandidateVendor.ContainsKey(vendor))
                    {
                        yield return CandidateVendor[vendor];
                    }
                }
            }
        }

        public Task<IEnumerable<SendToVendor>> SendToVendorsAsync()
        {
            return Task.FromResult(SendToVendors);
        }

        public List<int> GetVendors()
        {
            return this.Select(x => x.VendorId).Distinct().ToList();
        }
        public List<string?> GetVendorParcelCodes(int vendorId)
        {
            return this.Where(x => x.VendorId == vendorId).Select(x => x.VendorParcelCode).ToList();
        }

        public void RemoveParcelCode(string parcelCode)
        {
            this.RemoveAll(x => x.VendorParcelCode == parcelCode);
        }
    }

    public interface IDto
    {
        public int VendorId { get; set; }
        public string? VendorParcelCode { get; set; }
    }

    public class FleetDto : IDto
    {
        public int VendorId { get; set; }
        public string? VendorParcelCode { get; set; }
    }

    public class TestModel
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
            customListOperation.RemoveParcelCode(parcelCodes[1]);
        }

        public async Task Run2()
        {
            CustomListOperation<FleetDto> customListOperation = new()
            {
                new FleetDto { VendorId = 37, VendorParcelCode = "123458784"},
                new FleetDto { VendorId = 37, VendorParcelCode = "856485458"},
                new FleetDto { VendorId = 41, VendorParcelCode = "966342133"},
            };

            foreach (var item in await customListOperation.SendToVendorsAsync())
            {
                Console.WriteLine(item);
            }
        }


        public CustomListOperation<FleetDto> RetrievingCurrentVendorParcelCodesAsync()
        {
            List<TestModel> my = new List<TestModel>()
            {
                new TestModel(){ VendorId = 37, VendorParcelCode = "Test1"},
                new TestModel(){ VendorId = 37, VendorParcelCode = "Test2"},
                new TestModel(){ VendorId = 144, VendorParcelCode = "Test3"},
            };

            var fleetDtos = new CustomListOperation<FleetDto>(my.Select(x => new FleetDto
            {
                VendorParcelCode = x.VendorParcelCode,
                VendorId = x.VendorId,
            }).ToList());

            return fleetDtos;
        } 
    }
}
