using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Models
{
    public sealed class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }

       // public Category Category { get; set; } // bunu kaldıralım ilki singl hatatsı yemeyelim enntityframework izin vermez yoksa 
    }

    public sealed class Category // bunu dosya olarak eklemek isttersek sağ yapıp quick actions tan move type to dan yapabilirsin 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
