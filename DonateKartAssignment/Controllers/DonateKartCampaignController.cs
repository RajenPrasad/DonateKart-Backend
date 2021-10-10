using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateKartAssignment.DonateKartCampaignComponentInterface;
using DonateKartAssignment.Model;
using Microsoft.AspNetCore.Mvc;

namespace DonateKartAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DonateKartCampaignController : Controller
    {
        private IDonateKartCampaignManager _donateKartCamapaignManager;
        public DonateKartCampaignController(IDonateKartCampaignManager donateKartCamapaignManager)
        {
            _donateKartCamapaignManager = donateKartCamapaignManager;
        }
        
        [HttpGet]
        public async Task<string> FetchCampaigns()
        {
            try
            {
                return await _donateKartCamapaignManager.FetchCampaigns();
            }
            catch (Exception exp)
            {
                return "Some Exception Occured!";
            }
        }

        [HttpGet]
        public async Task<string> GetActiveCampaigns()
        {
            try
            {
                return await _donateKartCamapaignManager.GetActiveCampaigns();
            }
            catch (Exception exp)
            {
                return "Some Exception Occured!";
            }
        }

        [HttpGet]
        public async Task<string> GetClosedCampaigns()
        {
            try
            {
                return await _donateKartCamapaignManager.GetClosedCampaigns();
            }
            catch (Exception exp)
            {
                return "Some Exception Occured!";
            }
        }
    }
}