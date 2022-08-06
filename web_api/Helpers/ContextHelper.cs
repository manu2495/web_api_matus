using Microsoft.EntityFrameworkCore;
using web_api.Context;

namespace web_api.Helpers
{
    public class ContextHelper
    {
        public static MainContext BuildMainContext(IConfiguration Configuration)
        {
            var options = new DbContextOptionsBuilder<MainContext>()
                .UseNpgsql(Configuration.GetConnectionString("DB"))
                .Options;

            return new MainContext(options);
        }
    }
}
