using System.Collections.Generic;

namespace Demo.Models
{
    public class EditItemViewModel
    {
        public string Name { get; set; }

        public List<EditItemModifier> ItemModifiers { get; set; }
    }

    public class StoreModifier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static StoreModifier[] GetAll() =>
            new[]
            {
                new StoreModifier { Id = 1, Name = "Soy Milk" },
                new StoreModifier { Id = 2, Name = "Extra Espresso" },
            };
    }

    public class EditItemModifier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        public decimal? AdditionalCost { get; set; }
    }
}
