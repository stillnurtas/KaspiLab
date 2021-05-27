using AdventureWorks.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace AdventureWorks.Host
{
    class Program
    {
        private static Dictionary<Type, ServiceHost> services = new Dictionary<Type, ServiceHost>();

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                using (var service = new Service())
                {
                    ServiceBase.Run(service);
                }
            }
            else
            {
                Start(args);
                Console.WriteLine("Press any key to stop");
                Console.ReadKey(true);
                Stop();
            }
        }

        static void Start(string[] args)
        {
            RegisterHost(typeof(ProductService));
            RegisterHost(typeof(AuthService));
            RegisterHost(typeof(BasketService));
        }

        static void Stop()
        {
            var keys = services.Keys.ToList();
            foreach(var key in keys)
            {
                UnRegisterHost(key);
            }
        }

        static void RegisterHost(Type t)
        {
            if (!services.ContainsKey(t))
            {
                var host = new ServiceHost(t);
                services.Add(t, host);
                host.Open();
            }
        }

        static void UnRegisterHost(Type t)
        {
            services[t].Close();
            services[t] = null;
        }

        #region override servicebase
        public class Service : ServiceBase
        {
            public Service()
            {
                this.ServiceName = "WCF";
            }
            protected override void OnStart(string[] args)
            {
                Program.Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
        #endregion
    }
}
