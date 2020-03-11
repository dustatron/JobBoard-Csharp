using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using JobBoard.Models;

namespace JobBoard.Controllers
{
  public class JobsController : Controller
  {
    //index
    [HttpGet("/jobs")]
    public ActionResult JobsIndex()
    {
      List<Jobs> showList = Jobs.Board;
      return View(showList);
    }

    //New
    [HttpGet("/jobs/new")]
    public ActionResult New()
    {

      return View();
    }

    //Create
    [HttpPost("/jobs/create")]
    public ActionResult Create(string title, string description, string contact)
    {
      Jobs place = new Jobs(title, description, contact);
      return RedirectToAction("JobsIndex");
    }

    //Show
    [HttpGet("/jobs/{id}")]
    public ActionResult Show(int id)
    {
      Jobs place = Jobs.Find(id);
      return View(place);
    }

    //Edit form
    [HttpGet("/jobs/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Jobs place = Jobs.Find(id);
      return View(place);
    }

    //Update
    [HttpPost("/jobs/{id}")]
    public ActionResult Update(int id, string title, string description, string contact)
    {
      Jobs.UpdatePlace(id, title, description, contact);
      return RedirectToAction("JobsIndex");
    }

    //Destroy
    [HttpPost("/jobs/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Jobs.DeletePlace(id);
      return View();
    }
  }

}