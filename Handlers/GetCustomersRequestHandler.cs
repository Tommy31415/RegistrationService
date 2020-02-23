using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RegistrationService.Controllers;
using RegistrationService.Data;
using RegistrationService.Models;

namespace RegistrationService.Handlers
{
    public class GetCustomersRequestHandler : IRequestHandler<GetCustomersRequest, Customer[]>
    {
        private readonly DataContext _context;

        public GetCustomersRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer[]> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
        {
            return await _context.Customers.ToArrayAsync(cancellationToken);
        }
    }
}
