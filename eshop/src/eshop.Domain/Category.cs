﻿namespace eshop.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        public IList<Product> Products { get; set; }
    }
}
