using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace KitchenSink.Tests {
    class WebDriverFactory {
        private static readonly Uri RemoteWebDriverUri = new Uri("http://127.0.0.1:4444/wd/hub");

        public static IWebDriver Create(string browser) {
            DesiredCapabilities capabilities;
            IWebDriver driver = null;

            switch (browser) {
                case "chrome":
                    capabilities = DesiredCapabilities.Chrome();
                    driver = new RemoteWebDriver(RemoteWebDriverUri, capabilities, WebDriverTimeout);
                    break;
                case "internet explorer":
                    InternetExplorerOptions options = new InternetExplorerOptions();
                    options.IgnoreZoomLevel = true;
                    capabilities = (DesiredCapabilities)options.ToCapabilities();
                    driver = new RemoteWebDriver(RemoteWebDriverUri, capabilities, WebDriverTimeout);
                    break;
                case "edge":
                    capabilities = DesiredCapabilities.Edge();

                    int counter = 0;

                    // This is required due to Edge throwing Unable to create new remote session.
                    // When trying to establish multiple sessions at a time.
                    while (driver == null || counter > 10) {
                        try {
                            driver = new RemoteWebDriver(RemoteWebDriverUri, capabilities, WebDriverTimeout);
                        } catch (InvalidOperationException) {
                            System.Threading.Thread.CurrentThread.Join(1000);
                        }
                    }
                    break;
                default:
                    capabilities = DesiredCapabilities.Firefox();
                    driver = new RemoteWebDriver(RemoteWebDriverUri, capabilities, WebDriverTimeout);
                    break;
            }

            return driver;
        }

        private static TimeSpan WebDriverTimeout
        {
            get
            {
                return TimeSpan.FromSeconds(30);
            }
        }
    }
}
