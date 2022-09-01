using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier
{
    public class CampaignReader
    {
        private string path;
        private FileStreamOptions options;
        private List<RunningCampaignsView> running_campaings;
        public CampaignReader(string passed_path, FileStreamOptions Passed_options, List<RunningCampaignsView> passed_runningCampaigns)
        {
            path = passed_path;
            options = Passed_options;
            running_campaings = passed_runningCampaigns;
        }

        public Dictionary<string,int> Campaigns_and_their_last_sent_number()
        {
            Dictionary<string,int> campaign_last_sent_numbers = new Dictionary<string,int>();
                foreach (RunningCampaignsView campaign in running_campaings)
                {
                try
                {
                    string fullPath = path + "\\" + campaign.cName + ".csv";
                    StreamReader sr = new StreamReader(fullPath, options);
                     sr.ReadLine();
                     string headers = sr.ReadLine().Split(',')[1];
                     campaign_last_sent_numbers[campaign.cName] = Convert.ToInt32(headers);
                }
                catch
                {
                    continue;
                }

                }
            return campaign_last_sent_numbers;
        }

    }
}
