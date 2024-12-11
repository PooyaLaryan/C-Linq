using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode;

internal record Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public int StandardId { get; set; }
}

internal record Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; } = 0;
}

internal record ItemPerson
{
    public int PersonId { get; set; }
    public int ItemId { get; set; }
}

internal record Standard
{
    public int Id { get; set; }
    public string Name { get; set; }
}

internal record PersonDto
{
    public string FullName { get; set; }
    public int Old { get; set; }
}

internal record Loan
{
    public Loan()
    {
        Bullets = new List<Bullet>();
    }
    public int Dong { get; set; }
    public int Number { get; set; }
    public decimal Amount { get; set; }
    public IList<Bullet> Bullets { get; set; }
}

internal record Bullet {
    public string Title { get; set; }
}

public class GeographicRegion
{
    public int GeographicRegionId { get; set; }
    public int ParentGeographicRegionId { get; set; }
    public int GeographicRegionTypeId { get; set; }
    public string Name { get; set; }
}

public class GroupSumClass
{
    public int Code { get; set; }
    public decimal Price { get; set; }
}


class DriverLocation
{
    public IList<Shipment>? Shipments { get; set; }
}

class Shipment
{
    public int Id { get; set; }
    public int VendorId {  get; set; }
}


public enum SendToVendor : int
{
    None = 0,
    Okala = 1
}
class SendToVendorDto
{
    public SendToVendor Vendor { get; set; } = SendToVendor.None;
}

public enum Vendors : int
{
    Okala = 37,
    OK24 = 38,
    OMarket = 39,
    OfoghTel = 40,
    oFood = 41,
    Pizzaro = 498,
    TapsiGrocerry = 726,
}

public enum FleetEventType : byte
{
    None = 0,
    Delivery = 1,
    UnsuccessfulDelivery = 2,
    UnsuccessfulPickup = 3,
}
class FleetEvent
{
    public int FleetId { get; set; }
    public IEnumerable<FleetEventDetail> Details { get; set; }
}

class FleetEventDetail
{
    public int Count { get; set; }
    public FleetEventType FleetEventType { get; set; }
}

class FleetMetrics
{
    public int FleetId { get; set; }
    public FleetEventType Type { get; set; }
    public DateTime CreateDate { get; set; }
}
