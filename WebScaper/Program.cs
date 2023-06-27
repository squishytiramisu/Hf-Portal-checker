

using OpenQA.Selenium;
using System.Media;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V112.Runtime;
using OpenQA.Selenium.DevTools.V114.HeadlessExperimental;
using WebScaper;

//using OpenQA.Selenium.Firefox;


namespace WebShit
{

    public class WebStuff
    {

        public static string URL = "https://hf.mit.bme.hu/hallgato/vimiac02";

        public static string PATH_TO_LOGIN = "//*[@id=\"login-container-2\"]/p[3]/a";

        public static string POINTS_IER = "https://hf.mit.bme.hu/hallgato/vimiac02";

       
        public static string VIZSGA1 = "/html/body/div[4]/table/tbody/tr[21]/td[6]/span";

        //Sztem ez a 3. vizsga lol
        public static string VIZSGA3 = "/html/body/div[4]/table/tbody/tr[25]/td[6]/span";





        static void Main(string[] args)
        {

            //SoundPlayer soundPlayer = new SoundPlayer("helo.wav");
            //soundPlayer.PlaySync();


            while (true)
            {
                if (checkIerEredmeny())
                {
                    //soundPlayer.PlaySync();
                    Console.WriteLine("IER eredmenyek");
                    break;
                }else {
                    // 5 Percenként
                    Thread.Sleep(1000*60*5);
                }
            }


        }



        public static bool checkIerEredmeny()
        {


            var chromeOptions = new ChromeOptions();
           
            
            // TODO ajanlom hogy kapcsold be, de azert elsore nezd meg hogy bejelentkezett e
            // chromeOptions.AddArguments("headless");

            Console.WriteLine("Starting a new check for IER eredmenyek at " + DateTime.Now.ToString("h:mm:ss tt"));
            var driver = new ChromeDriver(chromeOptions);

            try
            {

                driver.Navigate().GoToUrl(URL);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);

                IWebElement EDULogin = driver.FindElement(By.XPath(PATH_TO_LOGIN));
                EDULogin.Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);

                // TODO: cimtar izéd
                TwoFaktorLogin twoFaktorLogin = new TwoFaktorLogin(driver);
                if (!twoFaktorLogin.Login())
                {
                    driver.Quit();
                    return false;
                }


                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);

                driver.Navigate().GoToUrl(POINTS_IER);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);

                string ierPontok = driver.FindElement(By.XPath(VIZSGA3)).Text;

                Console.WriteLine(ierPontok);
                Console.WriteLine("Ier Pontok megnezve");

                //TODO BEVAN IRVA
                if (!ierPontok.Equals(""))
                {
                    SendSms.sendSMS("+36209474777", $"IER pontok: {ierPontok}");
                    return true;
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                driver.Quit();
            }


            return false;
        }



    }
}