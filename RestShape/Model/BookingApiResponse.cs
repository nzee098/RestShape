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
            public int CustomerQuantity { get; set; }
        }

        public class CreatedByInfo
        {
            public string _id { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }

        public class List
        {
            public string _id { get; set; }
            public DateTime createdAt { get; set; }
            public string createdBy { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string ResourceId { get; set; }
            public string DepartmentId { get; set; }
            public Metadata Metadata { get; set; }
            public string StatusCode { get; set; }
            public string Note { get; set; }
            public string Resource { get; set; }
            public string Name { get; set; }
            public int Size { get; set; }
            public string id { get; set; }
            public CreatedByInfo createdByInfo { get; set; }
        }

        public class Root
        {
            public List<List> list { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int totalPages { get; set; }
            public int page { get; set; }
            public int pagingCounter { get; set; }
            public bool hasPrevPage { get; set; }
            public bool hasNextPage { get; set; }
            public object prevPage { get; set; }
            public object nextPage { get; set; }
        }


    }
}
