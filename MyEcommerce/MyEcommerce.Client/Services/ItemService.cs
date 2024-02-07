using FormModules.Data;

namespace MyEcommerce.Client.Services
{
    public class ItemService : IItemService
    {
        public async Task<List<Item>?> GetData()
        {
            await Task.Delay(500);

            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new Item
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToList());
        }
    }
}
