using System;
using System.Threading.Tasks;
using EnsureThat;
using Petify.Common.Exceptions;
using Petify.Domain;
using Petify.Infrastructure.DataModel.Context;

namespace Petify.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetifyContext _context;

        public UnitOfWork(PetifyContext context)
        {
            EnsureArg.IsNotNull(context, nameof(context));

            _context = context;
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex.InnerException);
            }
        }
    }
}
