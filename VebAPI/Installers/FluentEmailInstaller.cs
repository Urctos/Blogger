
using Application.Interfaces;
using Application.Services.Emails;
using FluentEmail.Core;

namespace WebAPI.Installers
{
    public class FluentEmailInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddFluentEmail(Configuration["FluentEmail:FromEmail"], Configuration["FluentEmail:FromName"])
                .AddSmtpSender(Configuration["FluentEmail:SmptSender:Host"],
                    int.Parse(Configuration["FluentEmail:SmptSender:Port"]),
                                Configuration["FluentEmail:SmptSender:Username"],
                                Configuration["FluentEmail:SmptSender:Password"]);

            services.AddScoped<IEmailSenderService, EmailSenderService>();   
        }
    }
}
