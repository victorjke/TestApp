using MvvmCross.Base;
using MvvmCross.Commands;
using System;
using System.Xml;


namespace TestApp.Core.Models
{
    public class Offer
    {
        public Offer(string id, XmlNode rawData)
        {
            Id = id;
            RawData = rawData;
        }


        public string Id { get; }

        public XmlNode RawData { get; }


        public event EventHandler Selected;

        public IMvxCommand SelectCommand => new MvxCommand(() => Selected?.Raise(this));
    }
}