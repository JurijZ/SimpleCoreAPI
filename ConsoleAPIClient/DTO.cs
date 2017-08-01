using System.Runtime.Serialization;
using System;
using System.Globalization;

namespace ConsoleAPIClient
{
    [DataContract(Name="dto")]
    public class DTO
    {
        //API response
        //{"id":1,"name":"test2","originPostCode":"201","rating":3}

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "originPostCode")]
        public string OriginPostCode { get; set; }
        
        [DataMember(Name= "rating")]
        public int Rating { get; set; }
        
        //[DataMember(Name="pushed_at")]
        //private string JsonDate { get; set; }
        
        //[IgnoreDataMember]
        //public DateTime LastPush
        //{
        //    get
        //    {
        //        return DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        //    }
        //}
    }
}