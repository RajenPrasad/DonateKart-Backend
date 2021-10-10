using DonateKartAssignment.DonateKartCampaignComponentInterface;
using DonateKartAssignment.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DonateKartAssignment.DonateKartCamapignComponent
{
    public class DonateKartCampaignManager : IDonateKartCampaignManager
    {
        private HttpClient httpClient;
        private string address;
        public DonateKartCampaignManager()
        {
            httpClient = new HttpClient();
            address = "https://testapi.donatekart.com/api/campaign";
        }

        public async Task<string> FetchCampaigns()
        {
            HttpResponseMessage response = await httpClient.GetAsync(address);
            var result = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<List<Campaign>>(result);
            var res = from p in resp
                      orderby p.TotalAmount descending
                      select new
                      {
                          Title = p.Title,
                          TotalAmount = p.TotalAmount,
                          BackersCount = p.BackersCount,
                          EndDate = p.EndDate
                      };
            return JsonConvert.SerializeObject(res.ToList());
        }

        public async Task<string> GetActiveCampaigns()
        {
            HttpResponseMessage response = await httpClient.GetAsync(address);
            var result = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<List<Campaign>>(result);
            var activeCampaign = from campaign in resp where campaign.EndDate >= DateTime.Now select campaign;
            var res = from campaign in activeCampaign where (DateTime.Now - campaign.Created).TotalDays <= 30 select campaign;
            return JsonConvert.SerializeObject(res.ToList());
        }

        public async Task<string> GetClosedCampaigns()
        {
            HttpResponseMessage response = await httpClient.GetAsync(address);
            var result = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<List<Campaign>>(result);
            var closeCampaigns = from campaign in resp where (campaign.EndDate < DateTime.Now || campaign.ProcuredAmount <= campaign.TotalAmount) select campaign;
            return JsonConvert.SerializeObject(closeCampaigns.ToList());
        }
    }
}
