using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueHistoryManagement
{
    public class ValueHistoryRecord
    {
        public Guid Id { get; set; }

        public DateTime RecordDate { get; set; }

        public Type Type { get; set; }

        public object Value { get; set; }

        public string PropertyName { get; set; }

        public string RecorderInfo { get; set; }

        public ValueHistoryRecord(string propertyName, object value, string recorderInfo = null)
        {
            Id = Guid.NewGuid();

            RecordDate = DateTime.Now;

            Type = value.GetType();

            Value = value;

            PropertyName = propertyName;

            RecorderInfo = recorderInfo;
        }

        public T GetAs<T>()
        {
            try
            {

                //var valueHistoryRecord = new ValueHistoryRecord(testObject.Name);

                //var myMethod = valueHistoryRecord.GetType()
                //             .GetMethods()
                //             .Where(m => m.Name == "GetAs")
                //             .FirstOrDefault();

                //myMethod = myMethod.MakeGenericMethod(t);


                //var z = myMethod.Invoke(valueHistoryRecord, null);

                return (T)Value;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
        }
    }

}
