using DonateKartAssignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateKartAssignment.DonateKartCampaignComponentInterface
{
    public interface IDonateKartCampaignManager
    {
        Task<string> FetchCampaigns();
        Task<string> GetActiveCampaigns();
        Task<string> GetClosedCampaigns();
    }
}
