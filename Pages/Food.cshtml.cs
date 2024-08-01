using asp.net_razorPage.Entities;
using asp.net_razorPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.net_razorPage.Pages
{
    public class FoodModel : PageModel
    {
        private readonly IFoodService _foodService;

        public FoodModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public IList<Food> Foods { get; set; }

        [BindProperty]
        public Food Food { get; set; }
        public bool IsEditing { get; set; }
        public IActionResult OnPostAdd()
        {
            if (Food != null)
            {
                _foodService.AddAsync(Food);
            }
            return RedirectToPage();
        }
        public async Task OnGetAsync()
        {
            Foods = await _foodService.GetAllAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Console.WriteLine($"Attempting to delete item with ID: {id}");
            await _foodService.DeleteAsync(id);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostUpdateAsync(int id, Food updatedFood)
        {
            await _foodService.UpdateAsync(Food.Id, Food);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            Food = await _foodService.GetByIdAsync(id);
            if (Food == null)
            {
                return NotFound();
            }

            IsEditing = true;
            return Page();
        }
    }
}
