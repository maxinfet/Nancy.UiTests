using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using RemoteAutomation.Models;

namespace RemoteAutomation.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["HomeView.cshtml"];
            Get["/home"] = _ => View["HomeView.cshtml"];
            Post["/add"] = _ => Add();

            
        }

        public Negotiator Add()
        {
            var model = this.Bind<HomeModel>();

            var calculator = new Calculator.Calculator();

            calculator.ClickButton(model.X);
            calculator.ButtonAdd.Click();

            calculator.ClickButton(model.Y);
            calculator.ButtonEquals.Click();

            return View["HomeView.cshtml"];
        }
    }
}
