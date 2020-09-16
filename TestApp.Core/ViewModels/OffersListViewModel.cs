using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestApp.Api.Helpers;
using TestApp.Core.Models;


namespace TestApp.Core.ViewModels
{
    public class OffersListViewModel : MvxViewModel
    {
        const string XmlUrl = "https://yastatic.net/market-export/_/partner/help/YML.xml";
        const string XmlEncodingName = "Windows-1251";

        readonly IMvxNavigationService _navigationService;
        MvxObservableCollection<Offer> _offers;


        public OffersListViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public MvxObservableCollection<Offer> Offers
        {
            get => _offers;
            private set
            {
                if (value == _offers)
                    return;

                if (_offers != null)
                {
                    foreach (var offer in _offers)
                        offer.Selected -= Offer_Selected;

                    _offers.CollectionChanged -= Offers_CollectionChanged;
                }

                _offers = value;

                if (_offers != null)
                {
                    foreach (var offer in _offers)
                        offer.Selected += Offer_Selected;

                    _offers.CollectionChanged += Offers_CollectionChanged;
                }

                RaisePropertyChanged();
            }
        }


        public override async Task Initialize()
        {
            var xmlString = await ApiHelper.GetDataAsStringAsync(XmlUrl, Encoding.GetEncoding(XmlEncodingName));
            if (string.IsNullOrWhiteSpace(xmlString))
                return;

            var parsedOffers = ParseXmlStringToOffersList(xmlString);
            Offers = parsedOffers != null ? new MvxObservableCollection<Offer>(parsedOffers) : new MvxObservableCollection<Offer>();
        }


        IEnumerable<Offer> ParseXmlStringToOffersList(string xmlString)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(Catalog));
                using (var stringReader = new StringReader(xmlString))
                {
                    var result = (Catalog)xmlSerializer.Deserialize(stringReader);
                    var offerNodes = (XmlNode[])result.Shop.OffersList[0];
                    return offerNodes.Select(o => new Offer(o.Attributes["id"].Value, o));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return null;
        }


        void Offers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    if (item is Offer offer)
                        offer.Selected -= Offer_Selected;
                }
            }

            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is Offer offer)
                        offer.Selected += Offer_Selected;
                }
            }
        }


        void Offer_Selected(object sender, EventArgs e)
        {
            try
            {
                var offer = (Offer)sender;
                var offerJson = JsonConvert.SerializeXmlNode(offer.RawData);
                _navigationService.Navigate<OfferDetailsViewModel, string>(offerJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}