using Raven.Client.Documents;

namespace Service.Infra.Shared
{
    public abstract class RavenContext
    {
        public IDocumentStore DocumentStore { get; private set; }
        public RavenContext()
        {
            DocumentStore = new DocumentStore { Urls = new[] { "http://localhost:9010" }, Database = "UserApiDocs" }.Initialize();
        }
    }
}
