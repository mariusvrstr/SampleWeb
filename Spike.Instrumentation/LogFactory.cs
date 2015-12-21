namespace Spike.Instrumentation
{
    using System;

    public static class LogFactory
    {
        public static Logging Create(string module = null)
        {
            return new Logging(module);
        }

        public static T CreateSpecialized<T>(string module = null) where T : Logging
        {
            try
            {
                var type = typeof (T);

                if (module == null)
                {
                    return Activator.CreateInstance(type) as T;
                }
                return Activator.CreateInstance(type, module) as T;
            }
            catch {return null; }
        }
    }
}
