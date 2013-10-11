namespace FindBack.Core.Model
{
    public interface IItem
    {
        string Description { get; set; }
        string ItemName { get; set; }
        string Coordinates { get; set; }
    }
}
