using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using System.Text.RegularExpressions;

namespace RemoteAutomation.Calculator
{
    public class Calculator
    {
        private readonly Application _application;
        private readonly AutomationElement _mainWindow;
        private readonly UIA3Automation _automation;

        public Button Button0 => FindElement("num0Button").AsButton();
        public Button Button1 => FindElement("num1Button").AsButton();
        public Button Button2 => FindElement("num2Button").AsButton();
        public Button Button3 => FindElement("num3Button").AsButton();
        public Button Button4 => FindElement("num4Button").AsButton();
        public Button Button5 => FindElement("num5Button").AsButton();
        public Button Button6 => FindElement("num6Button").AsButton();
        public Button Button7 => FindElement("num7Button").AsButton();
        public Button Button8 => FindElement("num8Button").AsButton();
        public Button Button9 => FindElement("num9Button").AsButton();
        public Button ButtonAdd => FindElement("plusButton").AsButton();
        public Button ButtonEquals => FindElement("equalButton").AsButton();

        public string Result
        {
            get
            {
                var resultElement = FindElement("CalculatorResults");
                var value = resultElement.Current.Name;
                return Regex.Replace(value, "[^0-9]", "");
            }
        }

        public Calculator()
        {
            _application = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            _automation = new UIA3Automation();
            _mainWindow = _application.GetMainWindow(_automation);

            // Switch to default mode
            Keyboard.PressVirtualKeyCode(VirtualKeyShort.ALT);
            Keyboard.TypeVirtualKeyCode(VirtualKeyShort.KEY_1);
            Keyboard.ReleaseVirtualKeyCode(VirtualKeyShort.ALT);
            Helpers.WaitUntilInputIsProcessed();
            _application.WaitWhileBusy();
        }

        public void ClickButton(int value)
        {
            foreach(var digit in value.ToString())
            {
                if (digit == '1')
                    Button1.Click();
                if (digit == '2')
                    Button2.Click();
                if (digit == '3')
                    Button3.Click();
                if (digit == '4')
                    Button4.Click();
                if (digit == '5')
                    Button5.Click();
                if (digit == '6')
                    Button6.Click();
                if (digit == '7')
                    Button7.Click();
                if (digit == '8')
                    Button8.Click();
                if (digit == '9')
                    Button9.Click();
                if (digit == '0')
                    Button0.Click();
            }
        }

        private AutomationElement FindElement(string text)
        {
            var element = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId(text));
            return element;
        }
    }
}
