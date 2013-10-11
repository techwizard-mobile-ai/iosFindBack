namespace FindBack.Core.Model
{
    public class Item : IItem
    {
        public string Description { get; set; }
        public string ItemName { get; set; }
        public string Coordinates { get; set; }
    }
}