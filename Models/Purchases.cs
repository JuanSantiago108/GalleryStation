#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace GalleryStation.Models;


public class Purchase{

    [Key]
    public int PurchaseId { get; set; }
    public int Quantity { get; set; }

    public DateTime CreateAt {get; set;} = DateTime.Now;

    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public int UserId {get; set;}
    public User? Buyer {get; set;}

    public int ArtId {get; set;}

    public Art? ArtPiece {get; set;}






}