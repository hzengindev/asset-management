using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Customer;
using System;
using System.Linq;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IProjectService _projectService;

        public CustomerManager(ICustomerDal customerDal, IProjectService productService)
        {
            _customerDal = customerDal;
            _projectService = productService;
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

        public IResult Delete(CustomerDeleteDto customer, Guid owner)
        {
            var _customer = _customerDal.Get(z => z.Id == customer.Id);
            if (_customer == null)
                return new ErrorResult("Customer definition not found");

            var deleteResultProject = DeleteProjectsByCustomer(customer.Id, owner);
            if (!deleteResultProject.Success)
                return new ErrorResult(deleteResultProject.Message, deleteResultProject.Code);

            _customerDal.Delete(_customer);

            return new SuccessResult();
        }

        private IResult DeleteProjectsByCustomer(Guid customerId, Guid owner)
        {
            var projects = _projectService.GetByCustomerId(customerId);
            
            if (!projects.Success)
                return new ErrorResult(projects.Message, projects.Code);

            if (projects.Data != null && projects.Data.Any())
                foreach (var item in projects.Data)
                    _projectService.Delete(new Entities.Dtos.Project.ProjectDeleteDto { Id = item.Id }, owner);

            return new SuccessResult();
        }

        public IResult Update(CustomerUpdateDto customer, Guid owner)
        {
            var _customer = _customerDal.Get(z => z.Id == customer.Id);
            if (_customer == null)
                return new ErrorResult("Customer definition not found");

            _customerDal.Update(new Entities.Concrete.Customer
            {
                CreatedBy = _customer.CreatedBy,
                CreatedOn = _customer.CreatedOn,
                Id = _customer.Id,
                ModifiedBy = owner,
                ModifiedOn = DateTime.Now,
                Name = customer.Name,
                StateCode = customer.StateType,
                StatusCode = customer.StatusType
            });

            return new SuccessResult();
        }
    }
}
