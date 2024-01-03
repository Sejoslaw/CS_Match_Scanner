namespace CsMatchScanner;

using CsMatchScanner.Contexts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Scanner
{
    public ScannerContext Context { get; } = new ScannerContext();
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