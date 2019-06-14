using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Main
{
    [Serializable]
    public class Dish
    {
        
        [Display(Name ="Name")]
        public string dishName { get; set; }
        [Display(Name ="Dish Type")]
        public string dishType { get; set; }
        [Display(Name = "Dish Price")]
        public float dishPrice { get; set; }
        [Display(Name = "Dish Size")]
        public int dishSize { get; set; }
        [Display(Name = "Dish Description")]
        public string dishDescription { get; set; }
        [Display(Name = "Dish Image")]
        public string dishImage { get; set; }
        [Key]
        public int ID { get; set; }

    }
}
