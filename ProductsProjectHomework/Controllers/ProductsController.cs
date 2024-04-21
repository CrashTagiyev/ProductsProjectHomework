using Microsoft.AspNetCore.Mvc;
using ProductsProjectHomework.Models;
using System.Diagnostics;

public class ProductsController : Controller
{
	private readonly ProductDbContext _context;

	public ProductsController(ProductDbContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		List<Product> products = _context.products.ToList();
		return View(products);
	}
	[HttpPost]
	public IActionResult Create(Product newProduct)
	{
		_context.products.Add(newProduct);
		_context.SaveChanges();
		return RedirectToAction("Index");
	}
	[HttpPost]
	public IActionResult Delete(int id)
	{
		var product = _context.products.Find(id);
		if (product == null)
		{
			return NotFound();
		}

		_context.products.Remove(product);
		_context.SaveChanges();

		return RedirectToAction(nameof(Index));
	}



	[HttpPost]
	public IActionResult Update(Product updatedProduct)
	{
		var existingProduct = _context.products.Find(updatedProduct.Id);
		if (existingProduct == null)
		{
			return NotFound(); // Product not found
		}
		existingProduct.Name = updatedProduct.Name;
		existingProduct.Description = updatedProduct.Description;
		existingProduct.Price = updatedProduct.Price;

		_context.products.Update(existingProduct);
		_context.SaveChanges();
		ViewBag.SelectedProductId = null; // Reset selected product ID after update
		return RedirectToAction(nameof(Index));
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
