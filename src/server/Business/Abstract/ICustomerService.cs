using Core.Utilities.Results;
using Entities.Dtos.Customer;
using System;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Guid> Add(CustomerAddDto customer, Guid owner);
        IResult Update(CustomerUpdateDto customer, Guid owner);
        IResult Delete(CustomerDeleteDto customer, Guid owner);
    }
}