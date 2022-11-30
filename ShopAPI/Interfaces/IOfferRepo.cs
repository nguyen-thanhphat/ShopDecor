using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IOfferRepo
    {
        ICollection<Offer> GetOffers();
        Offer GetOffer(int id);
        bool OfferExists(int id);
        bool CreateOffer(Offer offer);
        bool UpdateOffer(Offer offer);
        bool DeleteOffer(Offer offer);
        bool Save();
    }
}
