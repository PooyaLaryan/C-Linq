using Bogus;
using Newtonsoft.Json;

namespace LinqCode;

public class SimpleTestClass
{
    public void Run1()
    {
        SampleClass sampleClass = new SampleClass();

        byte? test = (byte?)sampleClass.FleetEventType;
    }

    public void Run2()
    {
        SampleClass simpleClass = new SampleClass
        {
            StartDateTime = DateTime.Now,
            CustomDate = DateTime.Now.ToString("yyyyMMdd hh:mm:ss"),
        };

        string json = JsonConvert.SerializeObject(simpleClass);
    }
    public void TestNullInList()
    {
        List<Loan> loanList = new List<Loan>()
        {
            new Loan{ Amount = 0 , Dong = 0, Number = 0, Bullets = null},
            new Loan{ Amount = 0 , Dong = 0, Number = 0, Bullets = new List<Bullet> { new Bullet { Title = "Hello"}, new Bullet { Title = "Bye" } } },
        };

        loanList.ForEach(loan =>
        {
            var bullets = loan.Bullets?.Select(x => x.Title).ToList();
        });
    }

    public void DoIfAllDataNotNullOrWhiteSpace()
    {
        List<string> strings = Enumerable.Range(0, Random.Shared.Next(3, 10)).Select(_ => new Faker().Random.Word().ToString()).ToList();
        List<string> strings1 = Enumerable.Range(3, 10).Select(_ => string.Empty).ToList();

        var bool1 = strings.Any(x => !string.IsNullOrWhiteSpace(x));
        var bool2 = strings1.Any(x => !string.IsNullOrWhiteSpace(x));
    }

    public void UsingSelectMany()
    {
        var loans1 = Generate();
        var data1 = loans1.SelectMany(x => x.Bullets).Select(x => x.Title).ToList();

        var loans2 = Generate(false);
        var data2 = loans1.SelectMany(x => x.Bullets).Select(x => x.Title).ToList();
    }

    private List<Loan> Generate(bool withBullets = true)
    {
        List<Loan> loanList = new List<Loan>();

        int loanCount = Random.Shared.Next(20);
        for (int i = 0; i < loanCount; i++)
        {
            List<Bullet> bullets = new List<Bullet>();
            int bulletCount = Random.Shared.Next(10);

            if (withBullets)
            {
                for (int j = 0; j < bulletCount; j++)
                {
                    bullets.Add(new Bullet { Title = new Faker().Random.Word() });
                }
            }

            loanList.Add(new Loan
            {
                Amount = Random.Shared.Next(10, 100),
                Dong = Random.Shared.Next(5, 30),
                Number = Random.Shared.Next(1000, 1000000),
                Bullets = bullets
            });
        }

        return loanList;
    }
}
