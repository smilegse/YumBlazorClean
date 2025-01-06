﻿using System.ComponentModel.DataAnnotations.Schema;
using YumBlazorClean.Domain.Entities;

namespace YumBalzorClean.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Count { get; set; }


    }
}
