using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using BUKEP.Student.Calculator.Data;

namespace BUKEP.Student.WebFormsCalculator
{
    public class Global : HttpApplication
    {
        private readonly static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        private CalculationResultRepository repository = new CalculationResultRepository(connectionString);

        void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            repository.ClearCalculationResults();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}