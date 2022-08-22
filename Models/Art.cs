#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GalleryStation.Models;


public class Art
{
    [Key]
    public int ArtId  {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Title")]
    public string Title {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Description")]
    public string Description {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Price")]
    public double Price {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Category")]
    public string Category {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [Display(Name = "Art Dimensions")]
    public string ArtDimensions {get; set;}

    [Required(ErrorMessage = "is required")]
    [DataType(DataType.Html)]
    [Display(Name = "Art Piece")]
    public string ArtPiece {get; set;}

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int UserId { get; set; }

    public User? Creator { get; set; }






}