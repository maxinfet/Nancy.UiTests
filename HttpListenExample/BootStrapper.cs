using Nancy;
using Nancy.Conventions;

namespace HttpListenExample
{
    public class BootStrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(
                    StaticContentConventionBuilder.AddDirectory("/", "Views")
                );
        }
    }
}
