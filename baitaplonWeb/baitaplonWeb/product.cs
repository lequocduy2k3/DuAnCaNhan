using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baitaplonWeb
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public product(int id, string name, string description, double price, string image1, string image2, string image3)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Image1 = image1;
            Image2 = image2;
            Image3 = image3;
        }
    }

}