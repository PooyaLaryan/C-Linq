using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode.FleetPreAssignmentState
{
    public class DeliveryServiceProviderRequestMapper
    {
        public byte DeliveryServiceProviderId {  get; set; }
        public long DispatchRequestId { get; set; }
        public bool IsActive { get; set; }
        public long CreateDate { get; set; }
        public string? DeliveryServiceProviderOrderId { get; set; }
    }
}
