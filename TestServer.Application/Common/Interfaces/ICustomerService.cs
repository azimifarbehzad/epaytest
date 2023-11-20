using System;
using TestServer.Domain.Entities;
namespace TestServer.Application.Common.Interfaces
{
	public interface ICustomerService
	{
        void AddCustomers(Customer customer);

        Customer[] GetCustomers();
        
    }
}