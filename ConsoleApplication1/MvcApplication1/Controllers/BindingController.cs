using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BindingController : Controller
    {
        //
        // GET: /Binding/

	    public County CurrentCounty
	    {
		    get { return Session["CurrentCounty"] == null ? County.GetOne() : (County) Session["CurrentCounty"]; }
		    set { Session["CurrentCounty"] = value; }
	    }
		public Animal CurrentAnimal
		{
			get { return Session["Animal"] == null ? Animal.GetOne() : (Animal)Session["Animal"]; }
			set { Session["Animal"] = value; }
		}

	    public ActionResult Index()
        {

			var county = CurrentCounty;

            return View(county);
        }

	    public ActionResult Edit()
	    {
		    var county = CurrentCounty;
		    CurrentCounty = county;

		    return View(county);
	    }

	    [HttpPost]
	    public ActionResult Edit(County county)
	    {
		    CurrentCounty = county;
		    return RedirectToAction("Index", "Binding");
	    }

	    public ActionResult EditAnimal()
	    {
		    var animal = CurrentAnimal;
		    CurrentAnimal = animal;

		    return View(animal);
	    }

	    [HttpPost]
	    public ActionResult EditAnimal(Animal animal)
	    {
		    CurrentAnimal = animal;

		    return View(animal);
	    }
    }
}
