using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier
{
    public interface ICampaignsRepo
    {
        List<RunningCampaignsView> GetRunningCampaigns();
    }
}
