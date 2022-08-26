using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using GalleryStation.Models;

namespace GalleryStation.Controllers;

public class ArtController : Controller
{

    private GSContext _context;
    private readonly IWebHostEnvironment _webHost;

    public ArtController(IWebHostEnvironment webHost, GSContext context)
    {
        _webHost = webHost;
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

    [HttpGet("/art/new")]
    public IActionResult NewArtwork()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        return View("AddArtwork");
    }

    [HttpPost("/art/create")]
    public IActionResult Create(Art newArt)
    {

        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid == false)
        {
            return NewArtwork();
        }

        newArt.UserId = (int)uid;
        _context.Arts.Add(newArt);
        _context.SaveChanges();
        return RedirectToAction("Index", "User");
    }

    [HttpPost("art/save")]
    public async Task<IActionResult> Save(Art newart, IFormFile imgfile)
    {
        var saveimg = Path.Combine(_webHost.WebRootPath, "img", imgfile.FileName);
        string imgext = Path.GetExtension(imgfile.FileName);
        if (imgext == ".jpg" || imgext == ".png")
        {
            using (var uploading = new FileStream(saveimg, FileMode.Create))
            {
                await imgfile.CopyToAsync(uploading);
                ViewData["Message"] = imgfile;
                newart.ArtPiece = imgfile.FileName;
                newart.UserId = (int)uid;
                _context.Arts.Add(newart);
                _context.SaveChanges();
                return RedirectToAction("Index", "User");
            }
        }
        else
        {
            ViewData["Message"] = "Only Images that are allowed are .jpn and .png";
        }
        return RedirectToAction("Index", "User");
    }

    [HttpGet("/art/{artId}")]
    public IActionResult OneArt(int artId)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Login", "User");
        }
        Art? oneArt = _context.Arts
            .Include(art => art.Creator)
            .FirstOrDefault(art => art.ArtId == artId);

        if (oneArt == null)
        {
            return RedirectToAction("Index");
        }

        return View("ArtInfo", oneArt);
    }

    [HttpPost("/art/{deletedArtId}/delete")]
    public IActionResult Delete(int deletedArtId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Login");
        }

        Art? artToBeDeleted = _context.Arts.FirstOrDefault(art => art.ArtId == deletedArtId);
        if(artToBeDeleted != null)
        {
            _context.Arts.Remove(artToBeDeleted);
            _context.SaveChanges();
        }
        return RedirectToAction("Index", "User");
    }




    [HttpGet("/shopping/cart")]
    public IActionResult Cart()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }

        List<ShoppingCart> cartList = _context.CartItems.Include( a=> a.PurchasedArt).Where( a=> a.UserId == HttpContext.Session.GetInt32("UUID")).ToList();

        ViewBag.Cart = cartList;

        return View("Cart");
    }

    [HttpPost("art/{artToBeBought}/buy")]
    public IActionResult AddToCart(int artToBeBought)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        ShoppingCart newItem = new ShoppingCart()
        {
            UserId = (int)uid,
            ArtId = artToBeBought
        };
        
        // newItem.UserId = (int)uid;
        // newItem.ArtId = artToBeBought;
        _context.CartItems.Add(newItem);
        _context.SaveChanges();
        return RedirectToAction("Cart", newItem);
    }


}