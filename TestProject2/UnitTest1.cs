using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TestProject2
{
    //durga
    public class Tests
    {
        IWebDriver driver;

        [Test]
        public void Test1()
        {
            string dt = DateTime.Now.ToString("ddMMyyyyhhmmss");
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("C:\\Users\\rajar\\OneDrive\\Pictures\\Screenshots\\Screenshots" + dt + ".Png", ScreenshotImageFormat.Png);

            Thread.Sleep(1000);
            driver.Quit();

        }

        [Test]
        public void MultipleWindowsTest2()
        {
            string dt = DateTime.Now.ToString("ddmmyyyyhhmmss");

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.salesforce.com/in/");
            driver.Manage().Window.Maximize();

            string parentwindow = driver.CurrentWindowHandle;

            IWebElement contact = driver.FindElement(By.XPath("//a[contains(text() , 'Contact')]"));
            contact.Click();

            var windows = driver.WindowHandles;
            foreach (string window in windows)
            {
                if (!window.Equals(parentwindow))
                {
                    driver.SwitchTo().Window(window);
                }

            }


            IWebElement firstName_TextBox = driver.FindElement(By.XPath("//input[@name = 'UserFirstName']"));
            firstName_TextBox.SendKeys("Durga");


            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("C:\\Users\\rajar\\OneDrive\\Pictures\\Screenshots\\Screenshots" + dt + ".Png", ScreenshotImageFormat.Png);

            driver.Quit();
        }

        [Test]
        public void ScrollPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.salesforce.com/in/");
            driver.Manage().Window.Maximize();

            IWebElement e = driver.FindElement(By.XPath("//a[contains(text() , 'Contact')]"));
            IJavaScriptExecutor jSE = ((IJavaScriptExecutor)driver);
            jSE.ExecuteScript("arguments[0].scrollIntoView(true);", e);
            Thread.Sleep(3000);
            e.Click();
            driver.Quit();
        }

        [Test]
        public void scrollPage2()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

            IWebElement business_Link = driver.FindElement(By.XPath("//a[text() ='Business']"));
            business_Link.Click();

            IWebElement read_Text = driver.FindElement(By.XPath("//div/h5[text() ='Easy']"));


            //IJavaScriptExecutor jS = ((IJavaScriptExecutor)driver);
            //jS.ExecuteScript("arguments[0].scrollIntoView(true);", read_Text);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,5000)", read_Text);

            Thread.Sleep(3000);
            //driver.Quit();

        }

        [Test]
        public void DragAndDropTextInTextBox()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();

            IWebElement sign_In = driver.FindElement(By.XPath("//a[text() = 'Sign in']"));
            sign_In.Click();

            IWebElement signIn_Text = driver.FindElement(By.XPath("//span[text() = 'Sign in']"));
            string text = signIn_Text.Text;

            IWebElement email_TextBox = driver.FindElement(By.XPath("//input[@name = 'identifier']"));

            Actions act = new Actions(driver);
            act.DoubleClick(signIn_Text).KeyDown(Keys.Control).SendKeys("c").Click(email_TextBox).KeyDown(Keys.Control).SendKeys("v").Build().Perform();
            driver.Quit();
        }

       public static void MAIN(string[] args)
        {
           int num = IsPalandromeNum(121);
          
            Console.WriteLine(num +"is palandrome number");
        }

        public static int IsPalandromeNum(int n)
        {
            int result = 0;
            if (n > 0)
            {
                int rem = n % 10;
                result = result + rem;
                n = n / 10;
            }
            return result;
            

    
            
        }
    



    }
}