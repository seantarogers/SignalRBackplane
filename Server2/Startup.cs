namespace Server2
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin;
    using Microsoft.Owin.Cors;

    using Owin;

    [assembly: OwinStartup(typeof(Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/signalr",
                map =>
                    {
                        map.UseCors(CorsOptions.AllowAll);
                        var hubConfiguration = new HubConfiguration { EnableDetailedErrors = true };
                        map.RunSignalR(hubConfiguration);
                    });

            GlobalHost.DependencyResolver.UseSqlServer(@"Server=.\sqlserver2014;Database=SignalrBackplane;Trusted_Connection=true");            
            app.MapSignalR(new HubConfiguration());
        }
    } 
}