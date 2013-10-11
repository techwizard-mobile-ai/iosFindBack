namespace FindBack.Core.Services
{
    using System.Collections.ObjectModel;

    using FindBack.Core.Model;

    public class ItemProvider : IItemProvider
    {
        public ObservableCollection<Item> GetItems()
        {
            return new ObservableCollection<Item>
                       {
                           new Item
                               {
                                   Coordinates = "47.063762;8.311063",
                                   Description = "Bike at work.",
                                   ItemName = "CityBike Speedy"
                               },
                            new Item
                               {
                                   Coordinates = "47.030233;8.277813",
                                   Description = "Bike at Pilatus cable car station.",
                                   ItemName = "MountainBike Rocky"
                               },
                       };
        }
    }
}