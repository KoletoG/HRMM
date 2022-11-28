using HRMM.Data;
using HRMM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRMM.Controllers
{
    public class HomeController : Controller
    {
        public UserDataModel asd = new UserDataModel();
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        DateTime current = DateTime.Now;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost]
        public IActionResult ClientAdd(ClientDataModel c)
        {
            BuildViewBag();
            c.Id = Guid.NewGuid().ToString();
            _context.Clients.Add(c);
            _context.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public IActionResult RoomAdd(RoomDataModel c)
        {
            BuildViewBag();
            c.Id = Guid.NewGuid().ToString();
            c.Free = true;
            _context.Rooms.Add(c);
            _context.SaveChanges();
            return View("Privacy");
        }
        public IActionResult ReservationAdd(ReservationDataModel c)
        {
            BuildViewBag();
            c.Id = Guid.NewGuid().ToString();
            string name = this.User.Identity.Name;
            UserDataModel af = new UserDataModel();
            TimeSpan staytime = c.EndDate - c.StartDate;
            for (int i = 0; i <= _context.Users.Count(); i++)
            {
                if (ViewBag.Users[i].UserName == name)
                {
                    af = ViewBag.Users[i];
                    break;
                }
            }
            RoomDataModel ar = new RoomDataModel();
            for (int i = 0; i < _context.Rooms.Count(); i++)
            {
                if (ViewBag.Rooms[i].Number == c.RoomR.Number)
                {
                    ar = ViewBag.Rooms[i];
                    ViewBag.Rooms[i].Free = false;
                    break;

                }
            }
                foreach (ClientDataModel at in ViewBag.Clients)
                {
                    if (at.Id == c.ClientsR.Id)
                    {
                    c.ClientsR = at;
                    }
                }
            double price = 0;
                if(c.ClientsR.Elder==true)
            {
                price += ar.PriceE;
            }
            else
            {
                price += ar.PriceY;
            }
                if(c.Breakfast==true)
            {
                price += 25;
            }
                if(c.AllInclusive==true)
            {
                price += 100;
            }
            price *= staytime.Days;
            c.FinalPrice = price;
                c.RoomR = ar;
                c.UserR = af;
            ViewBag.Reserv = c;
            _context.Reservations.Add(c);
            _context.SaveChanges();
            ViewBag.Last = 1;
            return View("Reservation");
        }
       
       public IActionResult Employees()
        {
            BuildViewBag();
            return View();
        }
        public void BuildViewBag()
        {
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Clients = _context.Clients.ToList();
            ViewBag.Rooms = _context.Rooms.Where(x=>x.Free==true).ToList();
            ViewBag.Reservations = _context.Reservations.ToList();
            ViewBag.Rooms1 = _context.Rooms.ToList();
           
        }
        public IActionResult Empl(UserDataModel u)
        {
            BuildViewBag();
            ViewData["name"] = u.UserName;
            return View("Empl");
        }
        public IActionResult Modify(UserDataModel u)
        {
            BuildViewBag();
            UserDataModel b = _context.Users.Where(x=>x.UserName==u.UserName).FirstOrDefault();
            b.EGN = u.EGN;
            b.Email = u.Email;
            b.EndDate = u.EndDate;
            b.Active = u.Active;
            b.LastName = u.LastName;
            b.FirstName = u.FirstName;
            b.TelNumber = u.TelNumber;
            b.MiddleName = u.MiddleName;
            b.UserName = u.UserName;
            _context.Users.Update(b);
            _context.SaveChanges();
            return View("Index");
        }
        public IActionResult Send(UserDataModel u)
        {
            UserDataModel b = _context.Users.Where(x => x.UserName == u.UserName).FirstOrDefault();
            asd = b;

            return RedirectToAction("Empl",asd);
        }
            public IActionResult Index()
        {
            BuildViewBag();
            foreach(ReservationDataModel c in ViewBag.Reservations)
            {
                if(current>c.EndDate)
                {
                    c.RoomR.Free = true;
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            BuildViewBag();
            return View();
        }
        public IActionResult Reservation()
        {
            BuildViewBag();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            BuildViewBag();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
