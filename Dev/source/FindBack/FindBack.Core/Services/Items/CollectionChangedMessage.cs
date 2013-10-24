namespace FindBack.Core.Services.Items
{
    using Cirrious.MvvmCross.Plugins.Messenger;

    public class CollectionChangedMessage : MvxMessage
    {
        public CollectionChangedMessage(object sender) : base(sender)
        {
        }
    }
}