#pragma warning disable CS8618 

using System.ComponentModel.DataAnnotations;

namespace GalleryStation.Models;

public class OrderHasItem 
{
    [Key]
    public int OrderHasItemId { get; set; }

    public int ArtId {get; set;}
    public Art? PurchasedArt {get; set;}

    public int UserId {get; set;}

    public User? Purchaser {get; set;}

    // public List<ShoppingCart>

}