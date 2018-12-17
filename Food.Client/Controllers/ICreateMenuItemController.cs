using Food.Client.Interfaces;

namespace Food.Client.Controllers
{
    public interface ICreateMenuItemController
    {
        ITabbed CreateDashboardControl();

        ITabbed CreateWeeklyMenuControl();
    }
}
