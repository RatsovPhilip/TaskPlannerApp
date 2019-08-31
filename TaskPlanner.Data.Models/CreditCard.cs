﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPlanner.Data.Models
{
    public class CreditCard
    {
        public CreditCard()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Number { get; set; }

        public string CardOwenrName { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CVV { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
