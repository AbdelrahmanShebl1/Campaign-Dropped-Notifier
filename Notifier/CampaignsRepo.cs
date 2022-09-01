using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier
{
    public class CampaignsRepo: ICampaignsRepo
    {
        private LBA_PortalContext portalContext;
        public CampaignsRepo(LBA_PortalContext Passed_context)
        {
            portalContext = Passed_context;
        }
        public List<RunningCampaignsView> GetRunningCampaigns()
        {
            List<RunningCampaignsView> list_of_running_campaigns = new List<RunningCampaignsView>();
            list_of_running_campaigns = portalContext.RunningCampaignsViews.ToList();
            return list_of_running_campaigns;
        }
    }
}
