using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using GalleryStation.Models;
namespace GalleryStation.Controllers;
public class ShoppingController : Controller
{
    private GSContext _context;

    public ShoppingController(GSContext context)
    {
        _context = context;
    }

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    // [HttpGet("/cart")]
    // public IActionResult Cart()
    // {
    //     if (!loggedIn)
    //     {
    //         return RedirectToAction("Index", "User");
    //     }
    //     // ViewBag.Cart = _context.Arts.OrderByDescending( a=> a.ArtPiece)
    //     // .Include(a => a.Title).Include(a=>a.Price).ToList();
    //     return View("Cart");
    // }










}



