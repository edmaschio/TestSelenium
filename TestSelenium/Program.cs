using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

using OpenQA.Selenium.Support.UI;

namespace TestSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://consultacadastral.inss.gov.br/Esocial/pages/index.xhtml");

            IWebElement query = driver.FindElement(By.Id("indexForm1"));

            query.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("consulta qualificação"); });

            query = driver.FindElement(By.Id("formQualificacaoCadastral:nome"));
            query.SendKeys("Ederson Tadeu Maschio");

            query = driver.FindElement(By.Id("formQualificacaoCadastral:dataNascimento"));
            query.SendKeys("28101981");

            wait.Until((d) => { return d.Title.ToLower().StartsWith("consulta qualificação"); });
            query = driver.FindElement(By.Id("formQualificacaoCadastral:cpf"));
            query.SendKeys("22216791806");

            query = driver.FindElement(By.Id("formQualificacaoCadastral:nis"));
            query.SendKeys("12714688162");

            query.Submit();



            Console.WriteLine("O título da página é: " + driver.Title);


            //driver.Quit();

            Console.ReadKey();
        }
    }
}



