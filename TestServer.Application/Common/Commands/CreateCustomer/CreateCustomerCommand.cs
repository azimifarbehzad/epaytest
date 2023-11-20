using System;
using AutoMapper;
using MediatR;
using TestServer.Application.Common.Interfaces;
using TestServer.Domain.Entities;

namespace TestServer.Application.Common.Commands.CreateCustomer
{

    public record CreateCustomerCommand : IRequest<int>
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CreateCustomerCommand, Customer>();
            }
        }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;


        public CreateTodoItemCommandHandler(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            _service.AddCustomers(customer);

            return customer.Id;
        }
    }
}

