using Bogus;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode.FleetPreAssignmentState
{
    public class FleetPreAssignmentStateQuery
    {
        private readonly IList<FlatFleetPreAssignmentStateDto> flatFleetPreAssignmentStateDtos;
        private readonly List<long> dispatchRequestIds = new List<long>();
        DateTime date = DateTime.Now;
        
        public FleetPreAssignmentStateQuery()
        {
            for (int i = 0; i < 5; i++)
            {
                dispatchRequestIds.Add(Random.Shared.Next(1000000, 9999999));
            }

            flatFleetPreAssignmentStateDtos = new List<FlatFleetPreAssignmentStateDto>();
            for (int i = 0; i <= 500; i++)
            {
                var randomDate = date.AddDays(Random.Shared.Next(-2, 1)).AddHours(Random.Shared.Next(-5, 6)).AddMinutes(Random.Shared.Next(-20, 21)).AddSeconds(Random.Shared.Next(-50, 50));

                flatFleetPreAssignmentStateDtos.Add(new FlatFleetPreAssignmentStateDto()
                {
                    ArrivalDelaySeconds = Random.Shared.Next(1000, 9999),
                    FleetId = Random.Shared.Next(100000, 999999),
                    ArrivalDurationTimeSeconds = Random.Shared.Next(1000, 9999),
                    CreateDatePersian = randomDate.ToPersianDateTimeLongNumeric(),
                    CreateDatePersianStr = randomDate.ToPersianDateTimeLongNumeric().ToString().Substring(0, 12),
                    DeliveryServiceProviderId = (byte)Random.Shared.Next(1, 5),
                    DeliveryServiceProviderOrderId = Random.Shared.Next(1, 5),
                    DispatchRequestId = dispatchRequestIds[Random.Shared.Next(0, dispatchRequestIds.Count)],
                    DistanceMeter = Random.Shared.Next(500, 900),
                    DriverId = Random.Shared.Next(100, 999),
                    IsFleetAssigned = true,
                    ParcelReferenceCode = Random.Shared.Next(100000000, 999999999),
                    SelectedServiceProviderId = (DeliveryServiceProviders)Random.Shared.Next(0, 6),
                    TodayDeliveredParcelCount = (byte)Random.Shared.Next(0, 6),
                    VehicleTypeId = (byte)Random.Shared.Next(0, 6),
                    VehicleTypeTitle = new Faker().Random.String2(20),
                });
            }
        }

        public void Run()
        {
            var dispatchRequestIds = flatFleetPreAssignmentStateDtos
                .GroupBy(x => x.DispatchRequestId)
                .Distinct()
                .Select(x => new { DispatchRequestId = x.Key, Count = x.Count() })
                .MaxBy(x=>x.Count);

            var fleetPreassignmentDispatchRequest = flatFleetPreAssignmentStateDtos
                .Where(x => x.DispatchRequestId == dispatchRequestIds.DispatchRequestId)
                .ToList();

            var result = FleetPreAssignmentMapper(dispatchRequestIds.DispatchRequestId, fleetPreassignmentDispatchRequest, true);
        }

        private IEnumerable<DeliveryServiceProviderRequestMapper> DeliveryServiceProviderRequestMapper
        {
            get
            {
                var randomDate = date.AddDays(Random.Shared.Next(-2, 1)).AddHours(Random.Shared.Next(-5, 6)).AddMinutes(Random.Shared.Next(-20, 21)).AddSeconds(Random.Shared.Next(-50, 50));

                return Enumerable.Range(0, 200).Select(x => new DeliveryServiceProviderRequestMapper
                {
                    DispatchRequestId = dispatchRequestIds[Random.Shared.Next(0, dispatchRequestIds.Count)],
                    CreateDate = randomDate.ToPersianDateTimeLongNumeric(),
                    DeliveryServiceProviderId = (byte)Random.Shared.Next(0, 6),
                    DeliveryServiceProviderOrderId = Random.Shared.Next(1000000,9999999).ToString(),
                });  
            }
        }

        private FleetPreAssignmentStateListReturnDto FleetPreAssignmentMapper(long dispatchRequestId, IEnumerable<FlatFleetPreAssignmentStateDto> fullInfoFleetPreAssignmentStates, bool isFleetAssigned)
        {
            return new()
            {
                ParcelReferenceCode = fullInfoFleetPreAssignmentStates.First().ParcelReferenceCode,

                SelectedServiceProviderId = fullInfoFleetPreAssignmentStates.First().SelectedServiceProviderId,

                ServiceProvidersPerformance = fullInfoFleetPreAssignmentStates
                    .GroupBy(deliveryServiceProviderIdGroup => deliveryServiceProviderIdGroup.DeliveryServiceProviderId)
                    .OrderBy(deliveryServiceProviderIdGroup => deliveryServiceProviderIdGroup.Key)
                    .Select(deliveryServiceProviderIdGroup => new ServiceProviderPerformanceDto
                    {
                        DeliveryServiceProviderId = deliveryServiceProviderIdGroup.Key,

                        DeliveryServiceProviderOrderId = DeliveryServiceProviderRequestMapper
                                                                .Where(x => x.DeliveryServiceProviderId == deliveryServiceProviderIdGroup.Key && x.DispatchRequestId == dispatchRequestId && x.IsActive == true)
                                                                .OrderByDescending(o => o.CreateDate)
                                                                .FirstOrDefault()
                                                                ?.DeliveryServiceProviderOrderId ?? null,

                        ServiceProviderPerformance = deliveryServiceProviderIdGroup
                                                                .GroupBy(createDatePersianStrGroup => createDatePersianStrGroup.CreateDatePersianStr)
                                                                .Select(createDatePersianStrGroup => new ServiceProviderPerformanceDetailDto
                                                                {
                                                                    CreateDatePersian = createDatePersianStrGroup.Key,
                                                                    IsFleetAssigned = isFleetAssigned,
                                                                    Items = createDatePersianStrGroup.Select(item => new ItemDto
                                                                    {
                                                                        FleetId = item.FleetId,
                                                                        DriverId = item.DriverId,
                                                                        DispatchRequestId = item.DispatchRequestId,
                                                                        TodayDeliveredParcelCount = item.TodayDeliveredParcelCount,
                                                                        ArrivalDurationTimeSeconds = item.ArrivalDurationTimeSeconds,
                                                                        CreateDatePersian = item.CreateDatePersian,
                                                                    })
                                                                    .OrderByDescending(x => x.CreateDatePersian)
                                                                    .ToList()
                                                                })
                                                                .OrderByDescending(x => x.CreateDatePersian)
                                                                .ToList()

                    })
                    .ToList()
            };
        }
    }
}
