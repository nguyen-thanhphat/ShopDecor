using ShopAPI.Interfaces;
using ShopAPI.Models;

namespace ShopAPI.Repository
{
    public class PayMethodRepo : IPayMethodRepo
    {
        private ShopDBContext _context;
        public PayMethodRepo(ShopDBContext context)
        {
            _context = context;
        }

        public bool CreatePaymentMethod(PaymentMethod payMethod)
        {
            _context.Add(payMethod);
            return Save();
        }

        public bool DeletePaymentMethod(PaymentMethod payMethod)
        {
            _context.Remove(payMethod);
            return Save();
        }

        public PaymentMethod GetPaymentMethod(int id)
        {
            return _context.PaymentMethods.Where(e => e.IdPayMethod == id).FirstOrDefault();
        }

        public ICollection<PaymentMethod> GetPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public bool PaymentMethodExists(int id)
        {
            return _context.PaymentMethods.Any(c => c.IdPayMethod == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePaymentMethod(PaymentMethod payMethod)
        {
            _context.Update(payMethod);
            return Save();
        }
    }
}
