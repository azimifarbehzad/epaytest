using System.Collections.Generic;
using TestServer;
using TestServer.Application.Common.Interfaces;
using TestServer.Domain.Entities;

public class CustomerService : ICustomerService
{
    private Customer[] temp = new Customer[0] { };


    public void AddCustomers(Customer customer)
    {
        var existCustomer = temp.FirstOrDefault(x => x.Id == customer.Id);
        if (existCustomer == null)
            InsertIntoArray(customer);

    }
    public Customer[] GetCustomers()
    {
        return temp;
    }
    private void InsertIntoArray(Customer customer)
    {
        lock (this)
        {

            int indexToInsert = 0;
            var length = temp.Length;

            if (length > 0)
                for (indexToInsert = 0; indexToInsert < temp.Length; indexToInsert++)
                {
                    var res = string.Compare(temp[indexToInsert].LastName, customer.LastName);
                    if (res > 0)
                    {
                        break;
                    }
                }

            Array.Resize(ref temp, temp.Length + 1); // increase array length by 1
            Array.Copy(temp, indexToInsert, temp, indexToInsert + 1, temp.Length - indexToInsert - 1); // shift elements right from the index
            temp[indexToInsert] = customer; // insert element at the index

        }

    }
}