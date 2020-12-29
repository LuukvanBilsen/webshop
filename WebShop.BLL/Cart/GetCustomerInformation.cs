using WebShop.DAL.Interfaces;
using WebShop.Models;


namespace WebShop.BLL.Cart
{
    [Service]
    public class GetCustomerInformation
    {
        private readonly ISessionManager session;

        public GetCustomerInformation(ISessionManager session)
        {
            this.session = session;
        }

        public CustomerInfo DoCustomerInfo()
        {
            var ConvertedCustomerInfo = session.GetCustomerInfo();

            if (ConvertedCustomerInfo == null)
            {
                return null;
            }
                
            return new CustomerInfo
            {
                FirstName = ConvertedCustomerInfo.FirstName,
                LastName = ConvertedCustomerInfo.LastName,
                Email = ConvertedCustomerInfo.Email,
                PhoneNumber = ConvertedCustomerInfo.PhoneNumber,
                Address = ConvertedCustomerInfo.Address,
                City = ConvertedCustomerInfo.City,
                PostCode = ConvertedCustomerInfo.PostCode
            };
        }
    }
}
