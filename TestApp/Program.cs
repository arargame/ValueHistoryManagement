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

            historyManager.HasChangedFor(to);
        }
    }
}
