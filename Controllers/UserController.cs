using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GalleryStation.Models;
using Microsoft.AspNetCore.Identity;

namespace GalleryStation.Controllers;


public class UserController : Controller
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

    public UserController(GSContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {

        return View("Index");
    }

    [HttpGet("/register")]
    public IActionResult ToRegister()
    {
        return View("Register");
    }


    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (_context.Users.Any(user => user.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "is taken");
            return View("Register");
        }
        if (ModelState.IsValid)
        {
            PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
            newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UUID", newUser.UserId);
            return View("Index");
        }
        return View("Register");
    }

    [HttpGet("/login")]
    public IActionResult ToLogin()
    {
        if (loggedIn)
        {
            return RedirectToAction("Index");
        }
        return View("Login");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return ToLogin();
        }

        User? dbUser = _context.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            ModelState.AddModelError("LoginUsername", "not found");
            return ToLogin();
        }

        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashBrowns.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "is not correct");
            return ToLogin();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        return RedirectToAction("Index");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}