#pragma warning disable CS8618 

using System.ComponentModel.DataAnnotations;

namespace GalleryStation.Models;

public class ShoppingCart
{

    [Key]
    public int CartId {get; set;}

    public int Quantity {get; set;} = 1;

    public DateTime CreatedAt {get; set;} = DateTime.Now;

    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public int ArtId {get; set;}
    public Art? PurchasedArt {get; set;}

    public int UserId {get; set;}

    public User? Purchaser {get; set;}
}