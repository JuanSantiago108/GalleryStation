using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GalleryStation.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryStation.Controllers;

public class ArtController : Controller
{

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

    private GSContext _context;

    public ArtController(GSContext context) => _context = context;




    // [HttpGet("/allhobbys")]
    // public IActionResult AllHobbys()
    // {
    //     List<Hobby> allHobbys = _context.Hobbys
    //         .Include(hobby=> hobby.HobbyLikers)
    //         .ToList();
    //     return View("Allhobbys", allHobbys);
    // }

    // [HttpGet("/hobby/new")]

    // public IActionResult NewHobby()
    // {
    //     if(!loggedIn)
    //     {
    //         return RedirectToAction("AllHobbys", "User");
    //     }
    //     return View("AddHobby");
    // }

    // [HttpPost("/hobby/create")]
    // public IActionResult Create(Hobby newHobby)
    // {

    //     if(!loggedIn || uid == null)
    //     {
    //         return RedirectToAction("AllHobbys");
    //     }

    //     if(ModelState.IsValid == false){
    //         return NewHobby();
    //     }

    //     newHobby.UserId = (int)uid;

    //     _context.Hobbys.Add(newHobby);
    //     _context.SaveChanges();
    //     return RedirectToAction("ViewHobby", new {hobbyId=newHobby.HobbyId});
    // }

    // [HttpGet("/hobby/{hobbyId}")]
    // public IActionResult OneHobby(int hobbyId)
    // {
    //     if(!loggedIn || uid == null)
    //     {
    //         return RedirectToAction("Index", "User");
    //     }
    //     Hobby? oneHobby = _context.Hobbys
    //         .Include(hobby=> hobby.HobbyLikers)
    //             .ThenInclude(hl=>hl.Attendee)
    //         .FirstOrDefault(hobby => hobby.HobbyId == hobbyId);
        
    //     if(oneHobby == null)
    //     {
    //         return RedirectToAction("AllHobbys");
    //     }

    //     return View("ViewHobby", oneHobby);
    // }

    // [HttpPost("/hobbys/{hobbyId}/liker")]
    // public IActionResult Attend(int hobbyId)
    // {
    //     if(!loggedIn || uid == null)
    //     {
    //         return RedirectToAction("Index", "User");
    //     }

    //     UserHobbyLiker? currentLiker = _context.UserHobbyLiker.FirstOrDefault(UHL => UHL.UserId ==(int)uid && UHL.HobbyId == hobbyId);

    //     if(currentLiker !=null)
    //     {
    //         _context.Remove(currentLiker);
    //     }
    //     else
    //     {
    //         UserHobbyLiker newLiker = new UserHobbyLiker(){
    //         UserId = (int)uid,
    //         HobbyId = hobbyId
    //         };
    //     _context.UserHobbyLiker.Add(newLiker);
        
    //     }

        
    //     _context.SaveChanges();
    //     return RedirectToAction("AllHobbys");
    // }

}