using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueHistoryManagement
{
    public class ValueHistorySetting
    {
        public Type Type { get; set; }

        public string PropertyName { get; private set; }

        public int Amount { get; private set; }

        public Func<object,object,bool> ControlActionWhetherValueIsNew { get; set; }

        public ValueHistorySetting(string propertyName,int amount = 2, Func<object,object, bool> action = null)
        {
            PropertyName = propertyName;

            Update(amount, action);
        }

        public ValueHistorySetting Update(int amount, Func<object, object, bool> action = null)
        {
            Amount = amount < 2 ? 2 : amount;

            ControlActionWhetherValueIsNew = action ??
                new Func<object, object, bool>((previousValue, currentValue) =>
                {
                    return !previousValue.Equals(currentValue);
                });

            return this;
        }
    }
}
