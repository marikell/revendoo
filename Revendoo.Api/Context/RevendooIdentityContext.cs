using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Revendoo.Api.Context
{
    public class RevendooIdentityContext : IdentityDbContext
    {
        public RevendooIdentityContext(DbContextOptions<RevendooIdentityContext> options) : base(options) { }
    }
}
