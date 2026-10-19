using IF133.Tugas1.Api.Data;
using IF133.Tugas1.Api.DTOs;
using IF133.Tugas1.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IF133.Tugas1.Api.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _db.Products.AsNoTracking().OrderBy(p => p.Id).ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(ProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Nama barang tidak boleh kosong atau spasi.");
            return ValidationProblem(ModelState);
        }

        var product = new Product
        {
            Name = request.Name.Trim(),
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Nama barang tidak boleh kosong atau spasi.");
            return ValidationProblem(ModelState);
        }

        var product = await _db.Products.FindAsync(id);
        if (product is null) return NotFound();

        product.Name = request.Name.Trim();
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product is null) return NotFound();

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
