using System.ComponentModel;

namespace LinqCode.FleetPreAssignmentState
{
    public record FleetPreAssignmentStateListReturnDto
    {
        public DeliveryServiceProviders? SelectedServiceProviderId { get; set; }
        public long ParcelReferenceCode { get; set; }
        public List<ServiceProviderPerformanceDto> ServiceProvidersPerformance { get; set; }
    }

    public record ServiceProviderPerformanceDto
    {
        public byte DeliveryServiceProviderId { get; set; }
        public string? DeliveryServiceProviderOrderId { get; set; }
        public List<ServiceProviderPerformanceDetailDto> ServiceProviderPerformance { get; set; }
    }

    public record ServiceProviderPerformanceDetailDto
    {
        public string CreateDatePersian { get; set; }
        public bool IsFleetAssigned { get; set; }
        public List<ItemDto> Items { get; set; }
    };

    public record ItemDto
    {
        public long FleetId { get; set; }
        public int? DriverId { get; set; }
        public int FleetStatusId { get; set; }
        public long DispatchRequestId { get; set; }
        public int TodayDeliveredParcelCount { get; set; }
        public int ArrivalDurationTimeSeconds { get; set; }
        public long CreateDatePersian { get; set; }
    };


    public enum DeliveryServiceProviders : byte
    {
        None = 0,

        [Description("زپ")]
        ZapExpress = 1,

        [Description("الوپیک")]
        AloPeyk = 2,

        [Description("میاره")]
        Miare = 3,

        [Description("تپسی")]
        Tapsi = 4,
    }

}
