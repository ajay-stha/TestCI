using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace MyCLIWpfApp.Tests;

public class WpfTest
{
    protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
    static string _ProjectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName ?? "";
#if RELEASE
    string _PathToTheDemo = _ProjectDirectory + @"\bin\Release\net8.0-windows\MyCLIWpfApp.Wpf.exe";
#else
    string _PathToTheDemo = _ProjectDirectory + @"\bin\Debug\net8.0-windows\MyCLIWpfApp.Wpf.exe";
#endif
    private WindowsDriver<WindowsElement>? _DesktopSession;

    [OneTimeSetUp]
    public void Setup()
    {
        if (_DesktopSession == null)
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(capabilityName: "app", capabilityValue: _PathToTheDemo);
            appiumOptions.AddAdditionalCapability(capabilityName: "deviceName", capabilityValue: "WindowsPC");
            appiumOptions.AddAdditionalCapability(capabilityName: "platformName", capabilityValue: "Windows");

            try
            {
                Console.WriteLine("Trying to Launch App");
                _DesktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
            }
            catch
            {
                Console.WriteLine("Failed to attach to app session (expected).");
            }
        }
    }

    [TestCase]
    public void AddNameToTextBox()
    {
        if (_DesktopSession != null)
        {
            var txtName = _DesktopSession.FindElementByAccessibilityId("txtName");
            txtName.Clear();
            txtName.SendKeys("aJ");
            _DesktopSession.FindElementByAccessibilityId("sayHelloButton").Click();
            var txtResult = _DesktopSession.FindElementByAccessibilityId("txtResult");
            Assert.That(txtResult.Text, Is.EqualTo($"Hello {txtName.Text}"));
        }
        else
        {
            Assert.Fail("Desktop session is null. Test cannot be executed.");
        }
    }

    [OneTimeTearDown]
    public void Cleanup()
    {
        if (_DesktopSession != null)
        {
            _DesktopSession.Close();
            _DesktopSession.Quit();
        }
    }
}
