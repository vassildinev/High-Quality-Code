using log4net;
using log4net.Config;
using System;

namespace Log4Net
{
    public class Log4NetTest
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Log4NetTest));

        public static void Main()
        {
            XmlConfigurator.Configure();
            var someSpecialValue = 42;
            try {
                for (var i = 0; i < 50; i++)
                {
                    if (i == someSpecialValue)
                    {
                        throw new ArgumentException();
                    }

                    Log.Info(i + " jumping sheep named Pesho");
                }
            }

            catch
            {
                Log.Error("Oh, no. Something went horribly wrong...");
            }
        }
    }
}
