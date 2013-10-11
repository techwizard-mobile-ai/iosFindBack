namespace FindBack.Core.Services
{
    using System.Collections.Generic;

    using FindBack.Core.Model;

    public interface IItemProvider
    {
        IItem[] GetItems();
    }
}