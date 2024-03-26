using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Import this namespace

namespace Mission11_Aken.Models;

public partial class Book
{
    public int BookId { get; set; }

    [Required] // This makes the Title property required
    public string Title { get; set; } = null!;

    [Required] // This makes the Author property required
    public string Author { get; set; } = null!;

    [Required] // This makes the Publisher property required
    public string Publisher { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?:ISBN(?:-13)?:?\ )?(?=[0-9X]{10}$|(?=(?:[0-9]+[-\ ]){3})[-\ 0-9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)(?:97[89][-\ ]?)?[0-9]{1,5}[-\ ]?[0-9]+[-\ ]?[0-9]+[-\ ]?[0-9X]$")] // This regex is for ISBN-10 or ISBN-13 validation
    public string Isbn { get; set; } = null!;

    [Required] // This makes the Classification property required
    public string Classification { get; set; } = null!;

    [Required] // This makes the Category property required
    public string Category { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Page count must be greater than 0.")] // Ensure the page count is greater than 0
    public int PageCount { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")] // Ensure the price is greater than 0
    public double Price { get; set; }
}