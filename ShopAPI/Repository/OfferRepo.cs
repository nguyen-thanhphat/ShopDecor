using ShopAPI.Interfaces;
using ShopAPI.Models;

namespace ShopAPI.Repository
{
    public class OfferRepo : IOfferRepo
    {
        private ShopDBContext _context;
        public OfferRepo(ShopDBContext context)
        {
            _context = context;
        }

        public bool CreateOffer(Offer offer)
        {
            _context.Add(offer);
            return Save();
        }

        public bool DeleteOffer(Offer offer)
        {
            _context.Remove(offer);
            return Save();
        }

        public Offer GetOffer(int id)
        {
            return _context.Offers.Where(e => e.IdOffer == id).FirstOrDefault();
        }

        public ICollection<Offer> GetOffers()
        {
            return _context.Offers.ToList();
        }


        public bool OfferExists(int id)
        {
            return _context.Offers.Any(c => c.IdOffer == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOffer(Offer offer)
        {
            _context.Update(offer);
            return Save();
        }
    }
}
