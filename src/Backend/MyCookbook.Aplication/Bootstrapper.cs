using Microsoft.Extensions.DependencyInjection;
using MyCookbook.Aplication.UseCases.Users.Register;
using Microsoft.Extensions.Configuration;
using MyCookbook.Aplication.Services.Cryptography;
using MyCookbook.Aplication.Services.Token;

namespace MyCookbook.Aplication
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddPasswordEncryptor(services, configuration);
            AddTokenJwt(services, configuration);
            AddRegisterUserUseCase(services);
        }

        public static void AddRegisterUserUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        public static void AddPasswordEncryptor(IServiceCollection services, IConfiguration configuration)
        {
            var getConnectionString = configuration.GetRequiredSection("Confugurations:AdditionalPasswordKey");
            services.AddScoped(opition => new PasswordEncryptor(getConnectionString.Value ?? ""));
        }

        public static void AddTokenJwt(IServiceCollection services, IConfiguration configuration)
        {
            var getTokenSecurityKey = configuration.GetRequiredSection("Confugurations:TokenSecurityKey");
            var getTokenLifetimeInMinutes = configuration.GetRequiredSection("Confugurations:TokenLifetimeInMinutes");

            services.AddScoped(opition => new TokenController(tokenLifetimeInMinutes: Double.Parse(getTokenLifetimeInMinutes.Value ?? "1"), securityKey: getTokenSecurityKey.Value!));
        }
    }
}
