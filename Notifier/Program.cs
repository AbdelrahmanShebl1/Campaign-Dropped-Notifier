using Microsoft.Extensions.Options;
using Notifier;

//Get the running campaigns
    LBA_PortalContext Passed_Context =new LBA_PortalContext();
    CampaignsRepo campaignsRepo=new CampaignsRepo(Passed_Context);
    CampaignController CampaignController = new CampaignController(campaignsRepo);
    List<RunningCampaignsView> runningCampaigns = CampaignController.GetAllCampaigns();


//Get the running campaign and their last sent numbers
    Dictionary<String,int> campaign_last_sent_numbers=new Dictionary<String,int>();
    string pathOnly = "C:\\Users\\AShebl\\Desktop\\Campaign CSVs";
    FileStreamOptions FileSharingOptions = new FileStreamOptions() { Share = FileShare.ReadWrite };
    CampaignReader Reader = new CampaignReader(pathOnly, FileSharingOptions, runningCampaigns);
    campaign_last_sent_numbers = Reader.Campaigns_and_their_last_sent_number();


//Get the last logged campaigns and their last logged numbers
    Dictionary<String, int> campaign_last_Logged_numbers = new Dictionary<string, int>();
    string logged_campaigns_and_their_last_number_path = "C:\\Users\\AShebl\\Desktop\\Campaign Last Logged\\Logged_Campaign_and_last_sent_numbers.CSV";
    StreamReader sr = new StreamReader(logged_campaigns_and_their_last_number_path, FileSharingOptions);
    while(!sr.EndOfStream)
    {
        //iterate over each row in the csv file and convert it into a key value pair<string,int>
        string[] headers = sr.ReadLine().Split(',');
        campaign_last_Logged_numbers[headers[0]] = Convert.ToInt32(headers[1]);
    }
//Compare the last sent campaign number to the logged number 
    foreach (RunningCampaignsView campaign in runningCampaigns)
    {
        if (campaign_last_Logged_numbers.ContainsKey(campaign.cName))
        {
            if (campaign_last_sent_numbers[campaign.cName] == campaign_last_Logged_numbers[campaign.cName])
                Console.WriteLine("error , campaign "+campaign.cName+" hasn't sent any new messages for the past 15 minutes");
        }
    }

//write the active campaigns and their last logged numbers
   // File.Delete("C:\\Users\\AShebl\\Desktop\\Campaign Last Logged\\Logged_Campaign_and_last_sent_numbers.CSV");
    StreamWriter sw = new StreamWriter("C:\\Users\\AShebl\\Desktop\\Campaign Last Logged\\Logged_Campaign_and_last_sent_numbers.CSV");
    foreach (RunningCampaignsView campaign in runningCampaigns)
        {
            sw.WriteLine(campaign.cName + "," + campaign_last_sent_numbers[campaign.cName].ToString());
        }
    sw.Close();