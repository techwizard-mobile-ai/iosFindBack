namespace FindBack.Core.Model
{
    using Cirrious.MvvmCross.Plugins.Sqlite;

    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Id: {0}, ItemName: {1}, Description: {2}, Coordinates: {3}",
                Id,
                ItemName,
                Description,
                Coordinates);
        }
    }
}