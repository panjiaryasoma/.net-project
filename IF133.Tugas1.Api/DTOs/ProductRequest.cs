using System.ComponentModel.DataAnnotations;

namespace IF133.Tugas1.Api.DTOs;

public sealed class ProductRequest
{
    [Required(ErrorMessage = "Nama barang wajib diisi.")]
    [StringLength(120, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(typeof(decimal), "0", "999999999.99", ErrorMessage = "Harga harus >= 0.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stok harus >= 0.")]
    public int Stock { get; set; }
}
