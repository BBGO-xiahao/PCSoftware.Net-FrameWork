using XG.Comm.Core;

namespace XG.Com.Comm
{
    /// <summary>
    /// ServiceExtension
    /// </summary>
    public static class ServiceExtension
    {
        #region ITcpService

        /// <inheritdoc cref="IService.Start"/>
        public static TService Start<TService>(this TService service, params IPHost[] iPHosts) where TService : ITcpService
        {
            service.Setup(new TouchSocketConfig()
                .SetListenIPHosts(iPHosts));
            service.Start();
            return service;
        }

        #endregion ITcpService

        #region Udp

        /// <inheritdoc cref="IService.Start"/>
        public static TService Start<TService>(this TService service, IPHost iPHost) where TService : IUdpSession
        {
            service.Setup(new TouchSocketConfig()
                .SetBindIPHost(iPHost));
            service.Start();
            return service;
        }

        #endregion Udp
    }
}