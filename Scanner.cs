namespace CsMatchScanner;

using Contexts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Scanner
{
    public ScannerContext Context { get; } = new();
    public IWebDriver Driver { get; }

    public Scanner()
    {
        Driver = new ChromeDriver();

        Driver.Navigate().GoToUrl(Context.ResultsUrl);
    }

    public void Run()
    {
    }
}