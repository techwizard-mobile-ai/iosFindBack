namespace FindBack.Core.Services.DataStore
{
    using System;

    using Cirrious.MvvmCross.Plugins.Sqlite;

    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public DateTime ItemCreated { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Id: {0}, ItemName: {1}, Description: {2}, Lat: {3}, Long: {4}, Item created: {5}",
                Id,
                ItemName,
                Description,
                Latitude,
                Longitude,
                ItemCreated);
        }
    }
}