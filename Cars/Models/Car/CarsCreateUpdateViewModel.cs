﻿namespace Cars.Models.Car
{
    public class CarsCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Power { get; set; }
        public string Fuel { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public enum FuelType
    {
        Petrol,
        Diesel,
        Hybrid,
        Electric
    }
}
