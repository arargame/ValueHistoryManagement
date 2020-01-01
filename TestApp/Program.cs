using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueHistoryManagement;

namespace TestApp
{
    public class TestObject
    {
        public float f;

        public string Name { get; set; }

        public Guid Id { get; set; }

        public int x
        {
            get
            {
                return 10;
            }
        }

        public List<string> list = new List<string>();

        public TestObject(string name = "testObject")
        {
            Name = name;

            Id = Guid.NewGuid();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var date1 = DateTime.Now;
            var date2 = DateTime.Now.AddYears(-1);
            var date3 = DateTime.Now.AddYears(-2);
            var date4 = DateTime.Now.AddYears(-3);
            var date5 = DateTime.Now.AddYears(-5);

            var dateList = new List<DateTime>() { date1, date2, date3, date4,date5 };

            for (int i = 0; i < dateList.Count; i++)
            {
                Console.WriteLine("{0:yyyy-MM-dd HH:mm:ss.fff}",dateList[i]);
            }

            dateList.Sort();
            Console.WriteLine();

            var list = dateList.OrderByDescending(dt=>dt.Year).OrderByDescending(dt => dt.Millisecond).ThenByDescending(dt => dt.Ticks).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine( list[i].Year +" "+list[i].Millisecond + " " + list[i].Ticks + " "+ list[i].AddTicks(1).Ticks);
            }

            TestObject to = new TestObject();
            var historyManager = new ValueHistoryManager();


            //historyManager.AddSetting(new ValueHistorySetting("Name", 2, 
            //    (previousValue,currentValue) =>
            //  {
            //      return !previousValue.Equals(currentValue);
            //  }));

            //historyManager.HasChangedFor(new ValueHistorySetting("Id",10));

            historyManager.AddSettings(to);

            historyManager.HasChangedFor(to);
            //historyManager.HasChangedFor(new ValueHistoryRecord("Name",to.Name));

            historyManager.Update();

            to.Name = "Koray";

            historyManager.HasChangedFor(to);
            //historyManager.HasChangedFor(new ValueHistoryRecord("Name", to.Name));

            historyManager.Update();

            to.Name = "Lebron";

            
            historyManager.HasChangedFor(to);
            //historyManager.HasChangedFor(new ValueHistoryRecord("Name", to.Name));

            historyManager.Update();
            to.Name = "Shaq";


            historyManager.HasChangedFor(to);

            historyManager.Update();

            historyManager.HasChangedFor(to);


            var records = historyManager.GetRecordsByPropertyName("Name");
        }
    }
}
