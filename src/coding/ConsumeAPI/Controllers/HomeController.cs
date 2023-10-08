using ConsumeAPI.Data;
using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsumeAPI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ConsumeApiDbContext _context;

    public HomeController(ILogger<HomeController> logger, ConsumeApiDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<SampleData> result = new List<SampleData>();
        try
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.npoint.io/db18c7b2d429ea9e3400"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<SampleData>>(apiResponse);
                }         
            }
            if (result != null && result.Count > 0)
            {
                var importantData = result.Select(resultData => new ImportantData
                {
                    Id = 0,
                    DeviceName = resultData.DeviceName,
                    Occupancy = resultData.Data.Occupancy,
                    Humidity = resultData.Data.Humidity,
                    Temperature = resultData.Data.Temperature
                    }).ToList();

                await _context.ImportantDatas.AddRangeAsync(importantData);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Important Data are successfully saved in Db!";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        finally
        {
            RedirectToAction("Error", "Home");
        }
        return result != null ? View(result) : RedirectToAction("Error", "Home") ;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}