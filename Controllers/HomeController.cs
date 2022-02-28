using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TAL_TEST.Models;

namespace TAL_TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PremiumPolicy premiumPolicy = new PremiumPolicy
            {
                DOB = DateTime.Now.AddDays(-500),
                OccupationList = GetOccupationList(),
                OccupationRatingList = GetOccupationRatingList()
            };
            return View(premiumPolicy);
        }

        [HttpPost]
        public IActionResult Index(PremiumPolicy premiumPolicy)
        {
            premiumPolicy.OccupationList = GetOccupationList();
            premiumPolicy.OccupationRatingList = GetOccupationRatingList();
            premiumPolicy.DeathPremium = GetDeathPremium(premiumPolicy.DeathSumInsured, premiumPolicy.Age, premiumPolicy.Occupation);
            return View(premiumPolicy);
        }

        [HttpGet]
        public decimal GetDeathPremium(int deathSumInsured, int age, string occupation)
        {
            // Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12

            var deathpremium = 0.0m;
            var occupationratingfactor = GetOccupationRatingList().Where(or => or.Rating == occupation).FirstOrDefault().Factor;
            deathpremium = (deathSumInsured * occupationratingfactor * age) / 1000 * 12;

            return deathpremium;
        }

        #region Fixed List return by methods

        private List<OccupationList> GetOccupationList()
        {
            List<OccupationList> listoccupation = new List<OccupationList>();

            OccupationList occupation = new OccupationList
            {
                Occupation = "Cleaner",
                Rating = "Light Manual"
            };

            listoccupation.Add(occupation);

            occupation = new OccupationList
            {
                Occupation = "Doctor",
                Rating = "Professional"
            };

            listoccupation.Add(occupation);

            occupation = new OccupationList
            {
                Occupation = "Author",
                Rating = "White Collar"
            };

            listoccupation.Add(occupation);

            occupation = new OccupationList
            {
                Occupation = "Farmer",
                Rating = "Heavy Manual"
            };

            listoccupation.Add(occupation);

            occupation = new OccupationList
            {
                Occupation = "Mechanic",
                Rating = "Heavy Manual"
            };

            listoccupation.Add(occupation);

            occupation = new OccupationList
            {
                Occupation = "Florist",
                Rating = "Light Manual"
            };

            listoccupation.Add(occupation);

            return listoccupation;
        }

        private List<OccupationRatingList> GetOccupationRatingList()
        {
            List<OccupationRatingList> listOccupationRating = new List<OccupationRatingList>();

            OccupationRatingList occupationRating = new OccupationRatingList
            {
                Factor = 1.0m,
                Rating = "Professional"
            };

            listOccupationRating.Add(occupationRating);

            occupationRating = new OccupationRatingList
            {
                Factor = 1.25m,
                Rating = "White Collar"
            };

            listOccupationRating.Add(occupationRating);

            occupationRating = new OccupationRatingList
            {
                Factor = 1.50m,
                Rating = "Light Manual"
            };

            listOccupationRating.Add(occupationRating);

            occupationRating = new OccupationRatingList
            {
                Factor = 1.75m,
                Rating = "Heavy Manual"
            };

            listOccupationRating.Add(occupationRating);

            return listOccupationRating;
        }

        #endregion
    }
}
