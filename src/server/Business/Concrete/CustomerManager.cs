using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Customer;
using System;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<Guid> Add(CustomerAddDto customer, Guid owner)
        {
            var customerId = Guid.NewGuid();
            _customerDal.Add(new Entities.Concrete.Customer
            {
                Id = customerId,
                Name = customer.Name,
                CreatedBy = owner,
                ModifiedBy = owner,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                StateCode = Entities.Concrete.CustomerStateTypes.Active,
                StatusCode = Entities.Concrete.CustomerStatusTypes.Active
            });

            return new SuccessDataResult<Guid>(customerId);
        }
    }
}
