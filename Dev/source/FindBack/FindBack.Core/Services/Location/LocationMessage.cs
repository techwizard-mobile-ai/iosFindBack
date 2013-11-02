﻿namespace FindBack.Core.Services.Location
{
    using Cirrious.MvvmCross.Plugins.Messenger;

    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, double latitude, double longitude) : base(sender)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Longitude { get; private set; }

        public double Latitude { get; private set; }
    }
}