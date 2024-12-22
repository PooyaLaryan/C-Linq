using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode.FleetPreAssignmentState
{
    public record FlatFleetPreAssignmentStateDto
    {
        public int FleetId { get; set; }
        public int? DriverId { get; set; }
        public byte? VehicleTypeId { get; set; }
        public string? VehicleTypeTitle { get; set; }
        public long DispatchRequestId { get; set; }
        public byte DeliveryServiceProviderId { get; set; }
        public byte TodayDeliveredParcelCount { get; set; }
        public int ArrivalDurationTimeSeconds { get; set; }
        public int DistanceMeter { get; set; }
        public long DeliveryServiceProviderOrderId { get; set; }
        public int? ArrivalDelaySeconds { get; set; }
        public DeliveryServiceProviders? SelectedServiceProviderId { get; set; }
        public bool IsFleetAssigned { get; set; }
        public long ParcelReferenceCode { get; set; }
        public long CreateDatePersian { get; set; }
        public string CreateDatePersianStr { get; set; }
    }
}
