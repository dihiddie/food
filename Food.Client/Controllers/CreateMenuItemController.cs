using Food.Client.Controls;
using Food.Client.Interfaces;

namespace Food.Client.Controllers
{
    public class CreateMenuItemController : ICreateMenuItemController
    {
        public ITabbed CreateDashboardControl()
            => new Dashboard();

        public ITabbed CreateWeeklyMenuControl() => new WeeklyMenu();
    }
}
