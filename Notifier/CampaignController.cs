using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier
{
    public class CampaignController
    {
        private ICampaignsRepo campaignsRepo;
        public CampaignController(ICampaignsRepo passed_Camps_Repo)
        {
            campaignsRepo = passed_Camps_Repo;
        }
        public List<RunningCampaignsView> GetAllCampaigns()
        {
            return(campaignsRepo.GetRunningCampaigns());

        }
    }
}
