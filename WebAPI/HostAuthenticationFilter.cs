using System.Web.Http.Filters;

namespace WebAPI
{
    internal class HostAuthenticationFilter : IFilter
    {
        private object authenticationType;

        public HostAuthenticationFilter(object authenticationType)
        {
            this.authenticationType = authenticationType;
        }

        public bool AllowMultiple => throw new System.NotImplementedException();
    }
}