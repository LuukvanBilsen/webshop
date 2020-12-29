using WebShop.DAL.Interfaces;
using WebShop.Models;

namespace WebShop.BLL.Cart
{
    [Service]
    public class AddCustomerInfo
    {
        private ISessionManager session;

        public AddCustomerInfo(ISessionManager session)
        {
            this.session = session;
        }

        public void DoAddCustomerInfo(CustomerInfo info)
        {
            session.AddCustomerInformation(new CustomerInfo
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                Email = info.Email,
                PhoneNumber = info.PhoneNumber,
                Address = info.Address,
                City = info.City,
                PostCode = info.PostCode
            });
        }
    }
}
