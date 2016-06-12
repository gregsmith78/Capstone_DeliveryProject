using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneDeliveryService.Models;
using System.Threading.Tasks;
using Locu.VenueDetails;
using Locu.VenueSearch;

namespace CapstoneDeliveryService.Controllers
{
    public class LocuController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private string key = "66c0c88b771eeaa231e3ae6e46991c124a98db87";
        // GET: Locu
        public async Task<ActionResult> Index()
        {
           // List<string> venIds = new List<string>() { "edfdce7e53f0559a6ce2", "b3570911431e238a017f" };
           // var request2 = new VenueDetailsRequest("66c0c88b771eeaa231e3ae6e46991c124a98db87", venIds);
            VenueCategory ct = VenueCategory.Restaurant;
            List<VenueCategory> st = new List<VenueCategory>() { VenueCategory.Restaurant };
            var request = new VenueSearchRequest("66c0c88b771eeaa231e3ae6e46991c124a98db87");
            request.Locality = "Milwaukee";
            request.Region = "WI";
            request.Categories = st;
            request.HasMenu = true;

            List<VenueSearchResponseObject> results;
            var client = new VenueSearchClient();
           // var client2 = new VenueDetailsClient();
            var result = await client.SendAsync(request);
           // var result2 = await client2.SendAsync(request2);
            //var venueIds = new List<string>();
            //venueIds.Add("id1");
            //venueIds.Add("id2");
           // var request1 = new VenueDetailsRequest("66c0c88b771eeaa231e3ae6e46991c124a98db87", venueIds);

            results = result.Venues.ToList();
            int counter = 1;
            int counter2 = 1;

            foreach(VenueSearchResponseObject x in results)
            {
                Restaurant rest = new Restaurant();
                rest.Name = x.Name;
                rest.LocuVenueId = x.Id;
                rest.AddressCity = x.Locality;
                rest.AddressState = x.Region;
                rest.AddressStreet = x.StreeAddress;
                rest.PhoneNumber = x.Phone;
                rest.AddressZip = x.PostalCode;
                rest.Id = counter;

                db.Restaurants.Add(rest);
                counter++;


            }

            VenueDetailsClient vdc = new VenueDetailsClient();

            foreach (Restaurant y in db.Restaurants)
            {
                List<MenuContent> mcs = new List<MenuContent>();
                List<string> venIds = new List<string>();
                venIds.Add(y.LocuVenueId);
                VenueDetailsRequest vdr = new VenueDetailsRequest(key, venIds);
                var result2 = await vdc.SendAsync(vdr);
               // List<VenueDetailResponseObject> results2 =
               foreach(VenueDetailsResponse response in result2 )
               {
                   List<VenueDetailResponseObject>vdrsp = response.Venues.ToList();
                   List<Menu> ml = vdrsp[0].Menus;
                   foreach(Menu m in ml)
                   {
                        List<MenuSection> sl = m.Sections;
                        foreach(MenuSection ms in sl)
                        {
                            List<MenuSubsection> mss = ms.Subsections;
                            foreach(MenuSubsection sb in mss)
                            {
                                List<MenuContent> mc = sb.Contents;
                                foreach(MenuContent mt in mc)
                                {
                                    MenuItem mi = new MenuItem();
                                    //char[] price = mt.Price.ToCharArray();
                                    //for(int i= 0; i < price.Length; i++)
                                    //{
                                    //if (price[i] == '$')
                                    //{
                                    //        price[i] = ' ';
                                
                                    //}
                           
                                    //}
                                    //string sPrice = price.ToString();

                                    mi.RestaurantId = y.Id;
                                   // mi.Price = decimal.Parse(sPrice.ToString());
                                    mi.Name = mt.Name;
                                    mi.Description = mt.Description;
                                    mi.Id = counter2;
                                    db.MenuItems.Add(mi);
                                    counter2++;
                              
                                }
                            }
                        }
                   
                   }
               
               }
               
            }

            db.SaveChanges();


            return View();
        }
        public ActionResult Delete()
        {
            db.Restaurants.RemoveRange(db.Restaurants.ToList());
            db.MenuItems.RemoveRange(db.MenuItems.ToList());
            db.SaveChanges();

            return View();
        }

    }
  }
