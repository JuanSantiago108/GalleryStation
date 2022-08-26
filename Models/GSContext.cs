#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace GalleryStation.Models;


public class GSContext : DbContext
{
    public GSContext(DbContextOptions options) : base(options){}

    public DbSet<User> Users {get; set;}
    public DbSet<Art> Arts {get; set;}

    public DbSet<Art> ArtOwner {get; set;}

    public DbSet<ShoppingCart> CartItems {get; set;}

}