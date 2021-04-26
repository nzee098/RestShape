using System;
using System.Collections.Generic;
using System.Text;

namespace RestShape.Model
{
    class BookingApiResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Metadata
        {
            public List<string> Service { get; set; }
            public int? CustomerQuantity { get; set; }
        }

        public class Root
        {
            public string createdBy { get; set; }
            public string _id { get; set; }
            public DateTime createdAt { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public string ResourceId { get; set; }
            public int DepartmentId { get; set; }
            public Metadata Metadata { get; set; }
            public string StatusCode { get; set; }
            public DateTime ApproveAt { get; set; }
            public string ApproveBy { get; set; }
            public string Note { get; set; }
            public string id { get; set; }
        }



    }
}
