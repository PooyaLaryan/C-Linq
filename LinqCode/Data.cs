using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode
{
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
}
