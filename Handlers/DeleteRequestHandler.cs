using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RegistrationService.Data;

namespace RegistrationService.Handlers
{
    public class DeleteRequestHandler : IRequestHandler<DeleteRequest, bool>
    {
        private readonly DataContext _context;

        public DeleteRequestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}