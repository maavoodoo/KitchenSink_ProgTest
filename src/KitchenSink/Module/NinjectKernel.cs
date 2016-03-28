using Ninject;

namespace KitchenSink.Module
{
    public class NinjectKernel
    {
        private StandardKernel standardKernel;
        private static NinjectKernel m_Instance = null;
        private static readonly object m_Sync = new object();

        private NinjectKernel() { }

        public static NinjectKernel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_Sync)
                    {
                        if (m_Instance == null)
                            m_Instance = new NinjectKernel();
                    }
                }
                return m_Instance;
            }
        }

        public void RegisterModules()
        {
            if(standardKernel == null)
            {
                standardKernel = new StandardKernel();

                standardKernel.Bind<IConsoleModule>().To<ConsoleModule>();
            }
        }

        public T GetModule<T>()
        {
            return standardKernel.Get<T>();
        }
    }
}
