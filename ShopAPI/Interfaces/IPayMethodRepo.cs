using ShopAPI.Models;

namespace ShopAPI.Interfaces
{
    public interface IPayMethodRepo
    {
        ICollection<PaymentMethod> GetPaymentMethods();
        PaymentMethod GetPaymentMethod(int id);
        bool PaymentMethodExists(int id);
        bool CreatePaymentMethod(PaymentMethod payMethod);
        bool UpdatePaymentMethod(PaymentMethod payMethod);
        bool DeletePaymentMethod(PaymentMethod payMethod);
        bool Save();
    }
}
