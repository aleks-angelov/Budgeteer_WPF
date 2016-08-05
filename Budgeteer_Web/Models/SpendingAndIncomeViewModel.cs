﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Budgeteer_Web.Models
{
    public class SpendingAndIncomeViewModel
    {
        public SpendingAndIncomeViewModel(bool isSpending)
        {
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                Users = new List<SelectListItem>();
                foreach (ApplicationUser user in context.Users.OrderBy(u => u.Name))
                    Users.Add(new SelectListItem { Text = user.Name, Value = user.Name });

                Categories = new List<SelectListItem>();
                foreach (Category cat in context.Categories.Where(c => c.IsDebit == isSpending).OrderBy(c => c.Name))
                    Categories.Add(new SelectListItem { Text = cat.Name, Value = cat.Name });
            }
        }

        [Required]
        public string PersonName { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateUntil { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<SelectListItem> Users { get; }
        public List<SelectListItem> Categories { get; }
    }
}