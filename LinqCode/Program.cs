using Bogus;
using LinqCode;
using LinqCode.FleetPreAssignmentState;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Person = LinqCode.Person;

SimpleTestClass simpleTestClass = new SimpleTestClass();
simpleTestClass.Run1();
simpleTestClass.Run2();
simpleTestClass.TestNullInList();
simpleTestClass.UsingSelectMany();
simpleTestClass.DoIfAllDataNotNullOrWhiteSpace();

TestCustomList testCustomList = new TestCustomList();
testCustomList.Run();
await testCustomList.Run2();
testCustomList.RetrievingCurrentVendorParcelCodesAsync();

List<int> randomList = new List<int>();
for (int i = 1; i <= 10; i++)
{
    randomList.Add(Random.Shared.Next(0, 5));
}

#region Init Data
List<Person> people1 = new List<Person>
{
    new Person{ Id = 1 , Name = "A", StandardId = 1, LastName = "AA", BirthDay = DateTime.Now.AddYears(-10)},
    new Person{ Id = 2 , Name = "B", StandardId = 1, LastName = "BB", BirthDay = DateTime.Now.AddYears(-15)},
    new Person{ Id = 3 , Name = "C", StandardId = 2, LastName = "CC", BirthDay = DateTime.Now.AddYears(-5)},
    new Person{ Id = 4 , Name = "D", StandardId = 1, LastName = "DD", BirthDay = DateTime.Now.AddYears(-3)},
    new Person{ Id = 5 , Name = "E", StandardId = 2, LastName = "EE", BirthDay = DateTime.Now.AddYears(-4)},
    new Person{ Id = 6 , Name = "F", LastName = "FF", BirthDay = DateTime.Now.AddYears(-7)},
    new Person{ Id = 7 , Name = "G", LastName = "GG", BirthDay = DateTime.Now.AddYears(-6)},
    new Person{ Id = 8 , Name = "H", StandardId = 3, LastName = "HH", BirthDay = DateTime.Now.AddYears(-5)},
};
IList<Bullet> bullets = new List<Bullet>
{
    new Bullet{ Title = "Title1"},
    new Bullet{ Title = "Title2"},
    new Bullet{ Title = "Title3"},
};
List<Loan> loans = new List<Loan>
{
    new Loan{ Dong = 20, Number = 4, Amount = 200, Bullets = bullets},
    new Loan{ Dong = 50, Number = 4, Amount = 500, Bullets = bullets},
    new Loan{ Dong = 100, Number = 4, Amount = 1000, Bullets = bullets},
    new Loan{ Dong = 150, Number = 4, Amount = 1500, Bullets = bullets},
    new Loan{ Dong = 200, Number = 9, Amount = 2000, Bullets = bullets},
    new Loan{ Dong = 250, Number = 9, Amount = 2500, Bullets = bullets},
    new Loan{ Dong = 300, Number = 9, Amount = 3000, Bullets = bullets},
    new Loan{ Dong = 500, Number = 9, Amount = 5000, Bullets = bullets},
    new Loan{ Dong = 1000, Number = 12, Amount = 10000, Bullets = bullets},
    new Loan{ Dong = 2000, Number = 12, Amount = 20000, Bullets = bullets},
    new Loan{ Dong = 3000, Number = 12, Amount = 30000, Bullets = bullets},
    new Loan{ Dong = 4000, Number = 12, Amount = 40000, Bullets = bullets},
};
List<int> ids = new List<int> { 1, 5, 6, 7 };
List<Person> people2 = new List<Person>
{
    new Person{ Id = 1 , Name = "A"},
    new Person{ Id = 2 , Name = "B"},
    new Person{ Id = 3 , Name = "C"},
};

List<Item> items = new List<Item>
{
    new Item{ Id = 1, Name = "TV" , Amount = 12000000},
    new Item{ Id = 2, Name = "Mobile Apple" , Amount = 400000000},
    new Item{ Id = 3, Name = "Mobile Android" , Amount = 1255142},
    new Item{ Id = 4, Name = "PS5" , Amount = 20000000},
};
List<ItemPerson> itemsPeople = new List<ItemPerson>
{
    new ItemPerson{ ItemId = 1, PersonId = 1},
    new ItemPerson{ ItemId = 1, PersonId = 2},
    new ItemPerson{ ItemId = 3, PersonId = 1},
    new ItemPerson{ ItemId = 3, PersonId = 7},
    new ItemPerson{ ItemId = 4, PersonId = 5},
};
List<Standard> standards = new List<Standard>
{
   new Standard{ Id = 1 , Name = "Standard 1"},
   new Standard{ Id = 2 , Name = "Standard 2"}
};
var intList1 = Enumerable.Range(1, 20).Select(x => Random.Shared.Next(10, 99)).ToList();
var intList2 = Enumerable.Range(1, 20).Select(x => Random.Shared.Next(10, 99)).ToList();
List<string> collection1 = new List<string> { "One", "Two", "Three", "Four", "Five", "Six" };
List<string> collection2 = new List<string> { "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
List<string> farsiNum = new List<string> {
"٠","١","٢","٣","٤","٥","٦","٧","٨","٩",
"۰","۱","۲","۳","۴","۵","۶","۷","۸","۹",
" "
};
List<string> englishNum = new List<string> {
"0","1","2","3","4","5","6","7","8","9",
};
List<int> ints = Enumerable.Range(1, 320).Select(x => Random.Shared.Next(1, 100000)).ToList();
List<GroupSumClass> groupSumClasses = new List<GroupSumClass> {
    new GroupSumClass{ Code = 1 , Price = 20000},
    new GroupSumClass{ Code = 1 , Price = 20000},
    new GroupSumClass{ Code = 2 , Price = 20000},
    new GroupSumClass{ Code = 2 , Price = 20000},
    new GroupSumClass{ Code = 1 , Price = 20000},
};
object[] dataForOftype = { "Hello", 123, 12.5, true, DateTime.Now };
var name = new[] { "Ali", "Reza", "Pouya" };
var age = new[] { 12, 23, 44 };


#endregion

#region Diff
var diffList = people1.Diff(people2, (x, y) =>
{
    return x.Id == y.Id;
}).ToList();
#endregion

#region Self Join 

int id = new GeographicRegions().GetGeographicRegionId("فارس", "اردکان");

#endregion

#region Join 3 List and Leftjoin 
var joinList = itemsPeople
    .Join(people1, x => x.PersonId, y => y.Id, (x, y) => new { ItemId = x.ItemId, PersonName = y.Name })
    .Join(items, x => x.ItemId, y => y.Id, (x, y) => new { ItemName = y.Name, ItemAmount = y.Amount, PersonName = x.PersonName })
    .OrderBy(x => x.PersonName)
    .ToList();

var join3 = itemsPeople
    .Join(people1, x => x.PersonId, y => y.Id, (x, y) => new { itemP = x, people = y })
    .Join(items, x => x.itemP.ItemId, y => y.Id, (x, y) => new { ItemName = y.Name, ItemAmount = y.Amount, PersonName = x.people.Name })
    .OrderBy(x => x.PersonName)
    .ToList();

var leftJoin = people1
    .GroupJoin(itemsPeople, p => p.Id, i => i.PersonId, (x, y) => new { people = x, itemP = y })
    .SelectMany(x => x.itemP.DefaultIfEmpty(), (x, y) => new { pid = x.people.Id, name = x.people.Name, itemid = y?.ItemId })
    .ToList();

//not good
var leftjoin4 = people1.GroupJoin(
    itemsPeople,
    p => p.Id,
    i => i.PersonId,
    (p, i) => new { person = p, items = i.DefaultIfEmpty() })
    //.Select(x=> new { pName = x.person.Name, pId = x.person.Id, itemId = x.items.})
    .ToList();


//rigth join
var leftJoin2 = itemsPeople
    .GroupJoin(people1, p => p.PersonId, i => i.Id, (x, y) => new { itemP = x, people = y })
    .SelectMany(x => x.people.DefaultIfEmpty(), (x, y) => new { pid = x.itemP.ItemId, pName = y.Name, pId = y.Id })
    .ToList();

var leftjoin3 = people1
    .SelectMany(x =>
           itemsPeople.Where(y => y.PersonId == x.Id).DefaultIfEmpty(),
           (x, y) => new { pName = x.Name, PId = x.Id, itemId = y?.ItemId })
    .ToList();
#endregion

#region GroupJoin
var groupJoin = standards.GroupJoin(people1,
    standard => standard.Id,
    person => person.StandardId,
    (standard, persongroup) =>
    new { people = persongroup, standardName = standard.Name }).ToList();

groupJoin.ForEach(item =>
{
    Console.WriteLine(item.standardName);
    item.people.ToList().ForEach(p =>
    {
        Console.WriteLine(p.Name);
    });
});
#endregion

#region GroupBy|ToLookup|Having


Console.Clear();
var groupSum = groupSumClasses
    .GroupBy(x => x.Code)
    .Select(g => new GroupSumClass { Code = g.Key, Price = g.Sum(y => y.Price) })
    .ToList();


Console.Clear();
//Having
var having = people1.GroupBy(x => x.StandardId)
    .Where(g => g.Count() > 1)
    .Select(x => new { GroupId = x.Key, value = x.Select(y => y) })
    .ToList();

having.ForEach(item =>
{
    Console.WriteLine($"{item.GroupId}:");
    item.value.ToList().ForEach(v =>
    {
        Console.WriteLine(v.Name);
    });
});

Console.Clear();
// get min loan per group
var loanGroup = loans.GroupBy(x => x.Number)
    .Select(x => new { GroupId = x.Key, value = x.Select(y => y) })
    .Select(x => new Loan
    {
        Dong = x.value.Min(y => y.Dong),
        Number = x.GroupId,
        Amount = x.value.Where(y => y.Dong == x.value.Min(t => t.Dong)).Select(x => x.Amount).FirstOrDefault(),
        Bullets = x.value.Where(y => y.Dong == x.value.Min(t => t.Dong)).Select(x => x.Bullets).FirstOrDefault(),
    });

var groupBy = people1.GroupBy(x => x.StandardId)
    .Select(x => new { GroupId = x.Key, value = x.Select(y => y) })
    .ToList();

groupBy.ForEach(item =>
{
    Console.WriteLine($"{item.GroupId}:");
    item.value.ToList().ForEach(v =>
    {
        Console.WriteLine(v.Name);
    });
});

Console.Clear();
var toLookup = people1.ToLookup(x => x.StandardId)
    .Select(x => new { GroupId = x.Key, value = x.Select(y => y) })
    .ToList();

toLookup.ForEach(item =>
{
    Console.WriteLine($"{item.GroupId}:");
    item.value.ToList().ForEach(v =>
    {
        Console.WriteLine(v.Name);
    });
});

#endregion

#region Single
Console.Clear();
var c = intList1.Count(x => x < 50);
var lessThan20 = intList1.FirstOrDefault(x => x < 20);
#endregion

#region SequenceEqual|Concat|Except|Intersect|Union|Skip|SkipWhile|Take|TakeWhile
bool isEuqal1 = intList1.SequenceEqual(intList2);
bool isEuqal2 = intList1.SequenceEqual(intList1);

Console.Clear();
var concatList = collection1.Concat(collection2).ToList();
concatList.ForEach(x => Console.WriteLine(x));

Console.Clear();
var diff = people1.Except(people2, new Compare()).ToList();
diff.ForEach(x => Console.WriteLine(x.Name));

Console.Clear();
var intersect = people1.Intersect(people2, new Compare()).ToList();
intersect.ForEach(x => Console.WriteLine(x.Name));

Console.Clear();
var union = collection1.Union(collection2).ToList();
union.ForEach(x => Console.WriteLine(x));

Console.Clear();
var unionPerson = people1.Union(people2, new Compare()).ToList();
unionPerson.ForEach(x => Console.WriteLine(x.Name));

Console.Clear();
var skipList = collection1.Skip(2).ToList();
skipList.ForEach(x => Console.WriteLine(x));

Console.Clear();
var skipWhile = collection1.SkipWhile(x => x.Length < 4).ToList();
skipWhile.ForEach(x => Console.WriteLine(x));

Console.Clear();
var skipWhile2 = collection1.SkipWhile((s, i) => s.Length > i).ToList();
skipWhile2.ForEach(x => Console.WriteLine(x));


Console.Clear();
var take = collection1.Take(2).ToList();
take.ForEach(x => Console.WriteLine(x));

Console.Clear();
var p1 = people1.Take(1..4).ToList();
take.ForEach(x => Console.WriteLine(x));

Console.Clear();
var take1 = collection1.TakeWhile(x => x.Length == 3).ToList();
p1.ForEach(x => Console.WriteLine(x));

Console.Clear();
var take2 = collection1.TakeWhile((x, i) => x.Length > i).ToList();
take2.ForEach(x => Console.WriteLine(x));
#endregion

#region ConvertAll|GetRange|Take|Insert|InsertRange
List<PersonDto> PersonDtos = people1
    .ConvertAll<PersonDto>(x =>
    {
        return new PersonDto
        {
            FullName = $"{x.Name} {x.LastName}",
            Old = (int)(DateTime.Now.Year - x.BirthDay.Year)
        };
    });

var ps = people1.GetRange(2, 5).ToList();
var ps2 = people1.Take(3);
collection1.Insert(0, "Ziro");
collection2.InsertRange(0, new List<string> { "Hello", "Bay" });
#endregion

#region Encoding|UTF8
Console.Clear();
farsiNum.ForEach(x =>
    Console.WriteLine(Encoding.UTF8.GetBytes(x)[0])
);
farsiNum.ForEach(x => Console.WriteLine((int)Convert.ToChar(x)));
englishNum.ForEach(x => Console.WriteLine((int)Convert.ToChar(x)));
#endregion

#region Chunk
Console.Clear();
var listOfList = ints.Chunk(100).ToList();
Console.WriteLine(listOfList.Count());
#endregion

#region sql -> IN()
var pList = people1.Where(x => ids.Contains(x.Id)).ToList();
#endregion

#region OfType
Console.Clear();
var output = dataForOftype.OfType<string>().ToList();
output.ForEach(x => Console.WriteLine(x));
#endregion

#region selectMany
Console.Clear();
var selecrmanyOutput = loans.SelectMany(x => x.Bullets).Select(x => x.Title).ToList();
selecrmanyOutput.ForEach(x => Console.WriteLine(x));


var loans2 = Enumerable.Range(1, 3).Select(_ => new Loan
{
    Amount = Random.Shared.Next(0, 100),
    Dong = Random.Shared.Next(0, 100),
    Number = Random.Shared.Next(0, 100),
    Bullets = Enumerable.Range(1, Random.Shared.Next(2, 4)).Select(_ => new Bullet
    {
        Title = new Faker().Random.Word(),
    }).ToList(),
}).ToList();

var loans2Result = loans2.SelectMany(x => x.Bullets, (x, y) => new
{
    Amount = x.Amount,
    Dong = x.Dong,
    Number = x.Number,
    Title = y.Title,
});


var loan3 = new Loan
{
    Amount = new Faker().Random.Int(),
    Dong = new Faker().Random.Int(),
    Number = new Faker().Random.Int(),
    Bullets = new Faker().Make(3, () => new Bullet { Title = new Faker().Random.Word() })
};

#endregion

#region Zip
Console.Clear();
var zipOurput = name.Zip(age, (name, age) => (name, age)).ToList();
zipOurput.ForEach(x => Console.WriteLine($"Name :{x.name} - Age : {x.age} {Environment.NewLine}"));
#endregion

#region DistinctBy
Console.Clear();
var distinctByOutput = itemsPeople.DistinctBy(x => x.ItemId).ToList();
distinctByOutput.ForEach(x => Console.WriteLine(x.ItemId));

Console.Clear();
var distinctOutput = itemsPeople.Distinct().ToList();
distinctOutput.ForEach(x => Console.WriteLine(x.ItemId));

#endregion

Mobile("+989376363535");

#region Concatenate list items with commas except the last one
var JoinListWithComaExcetLast = string.Join(",", Enumerable
    .Range(1, 3)
    .Select(_ => $"{new Random().Next(1000)}")
    .ToList());
Console.WriteLine(JoinListWithComaExcetLast);
#endregion


//Left Join 
var leftJoinPeople = from people in people1
                     join item in itemsPeople on people.Id equals item.PersonId into gg
                     from subgroup in gg.DefaultIfEmpty()
                     select new
                     {
                         a = people.Name,
                         b = subgroup?.ItemId ?? null,
                     };



#region Any
var driverLocation1 = new DriverLocation
{
    Shipments = new List<Shipment> { new Shipment { Id = 1 }, new Shipment { Id = 2 }, new Shipment { Id = 15 } }
};

var driverLocation2 = new DriverLocation
{
    Shipments = null
};

bool has14Id1 = driverLocation1.Shipments.Any(x => x.Id == 15);
bool has14Id2 = driverLocation2.Shipments?.Any(x => x.Id == 15) ?? false;


#endregion


#region Exists
//The 𝐄𝐱𝐢𝐬𝐭𝐬() 𝐦𝐞𝐭𝐡𝐨𝐝 𝐢𝐬 specifically 𝐝𝐞𝐬𝐢𝐠𝐧𝐞𝐝 𝐟𝐨𝐫 𝐋𝐢𝐬𝐭 𝐜𝐨𝐥𝐥𝐞𝐜𝐭𝐢𝐨𝐧𝐬, It serves a narrower purpose. So, Exists() is an instance method which functions very similar to Any.
//Performance - wise Any seems to be slower. When using List collections, Exists() offers better performance. 𝐘𝐨𝐮 𝐬𝐡𝐨𝐮𝐥𝐝 𝐩𝐫𝐞𝐟𝐞𝐫 𝐄𝐱𝐢𝐬𝐭𝐬() 𝐢𝐧𝐬𝐭𝐞𝐚𝐝 𝐨𝐟 𝐀𝐧𝐲() to see if at least one item in a collection meets a specified condition.
var existsResult = driverLocation1.Shipments.ToList().Exists(x => x.VendorId == 15);

#endregion


IList<FleetMetrics> metrics = new List<FleetMetrics>();
for (int i = 0; i < 1000; i++)
{
    metrics.Add(new FleetMetrics
    {
        FleetId = Random.Shared.Next(1, 10),
        Type = (FleetEventType)Random.Shared.Next(1, 4),
        CreateDate = DateTime.Now.AddDays(Random.Shared.Next(1, 3))
    });
};
var fleetEventType = FleetEventType.None;

var fleetEvents = metrics
    .Where(x => fleetEventType == FleetEventType.None ? true : x.Type == fleetEventType)
    .GroupBy(g => g.FleetId)
    .Select(group => new FleetEvent
    {
        FleetId = group.Key,
        Details = group.GroupBy(x => x.Type)
        .Select(typeGroup => new FleetEventDetail
        {
            FleetEventType = typeGroup.Key,
            Count = typeGroup.Count()
        }).ToList()
    }).ToList();


List<DriverLocation> locations = new List<DriverLocation>();
for (int i = 0; i < 10; i++)
{
    int vendor = 0;
    
    //do
    //{
    //    vendor = Enum.GetValues<Vendors>().Cast<int>().ToList()[Random.Shared.Next(0, 7)];
    //} while (vendor == (int)Vendors.Okala || vendor == (int)Vendors.oFood);

    vendor = Enum.GetValues<Vendors>().Cast<int>().ToList()[Random.Shared.Next(0, 7)];

    locations.Add(new DriverLocation
    {
        Shipments = new List<Shipment> {
            new Shipment {
                Id = new Faker().Random.Int(100000,9999999),
                VendorId = vendor
            }
        }.ToList()
    });
}

List<DriverLocation> locations2 = new List<DriverLocation>();
for (int i = 0; i < 10; i++)
{
    locations2.Add(new DriverLocation
    {
        Shipments = null
    });
}

var location = locations[0];

SendToVendorDto sendToVendorDto = new SendToVendorDto
{
    Vendors = location.Shipments?.Select(x => x.VendorId).Distinct().ToList(),
    Vendor = location.Shipments?.Any(x => x.VendorId == (int)Vendors.Okala) ?? false ? SendToVendor.Okala : default,
};

var shareVendor1 = sendToVendorDto.ShareVendor;

SendToVendorDto sendToVendor2 = new SendToVendorDto
{
    Vendors = locations.Where(x => x.Shipments != null && x.Shipments.Any()).SelectMany(x => x.Shipments).Select(x => x.VendorId).Distinct().ToList(),
    Vendor = locations.Where(x => x.Shipments?.Any(a => a.VendorId == (int)Vendors.Okala) ?? false).Select(x => SendToVendor.Okala).FirstOrDefault(),
};

var shareVendor2 = sendToVendor2.ShareVendor;

SendToVendorDto sendToVendor3 = new SendToVendorDto
{
    Vendors = locations2.Where(x => x.Shipments != null && x.Shipments.Any()).SelectMany(x => x.Shipments).Select(x => x.VendorId).Distinct().ToList(),
    Vendor = locations2.Where(x => x.Shipments?.Any(a => a.VendorId == (int)Vendors.Okala) ?? false).Select(x => SendToVendor.Okala).FirstOrDefault(),
};

var shareVendor3 = sendToVendor3.ShareVendor;

FleetPreAssignmentStateQuery fleetPreAssignmentStateQuery = new();
fleetPreAssignmentStateQuery.Run();

Console.ReadKey();

#region Methods
string Mobile(string mobileNumber)
{
    if (mobileNumber.Length < 10)
    {
        throw new Exception();
    }
    string number = $"+98{mobileNumber.Substring(mobileNumber.Length - 10)}";
    return number;
}

class Compare : IEqualityComparer<Person>
{
    public bool Equals(Person? x, Person? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode([DisallowNull] Person obj)
    {
        //Important
        return obj.Id.GetHashCode();
    }
}
#endregion
