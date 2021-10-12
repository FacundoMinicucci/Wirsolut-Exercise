using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WirsolutExercise.Core.DTOs;
using WirsolutExercise.Core.Interfaces.IServices;

namespace WirsolutExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IClientsService clientsService, ILogger<ClientsController> logger)
        {
            _clientsService = clientsService;
            _logger = logger;
        }            

        // Http Get Index
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                ViewData["CurrentFilter"] = searchString;

                var clients = await _clientsService.GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    clients = await _clientsService.GetAll(searchString);
                }                               

                return View(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // Http Get Add
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        // Http Post Add
        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([FromForm] ClientsAddDTO newClient)
        {
            try
            {
                if (ModelState.IsValid) await _clientsService.Add(newClient);

                TempData["message"] = "Client has been successfully created!";

                return RedirectToAction("Index");            
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }            
        }

        // Http Get Delete
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var client = await _clientsService.GetById(id);

            if (client == null) return NotFound();

            return View(client);
        }

        // Http Post Delete
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var client = await _clientsService.GetById(id);

                if (client == null) return NotFound();

                await _clientsService.Delete(id);

                TempData["message"] = "The client was successfully deleted!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // Http Get Edit
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var client = await _clientsService.GetById(id);

            if (client == null) return NotFound();

            return View(client);
        }              

        // Http Post Edit
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ClientsUpdateDTO clientsDTO)
        {
            try
            {               
                if (ModelState.IsValid)
                {
                    await _clientsService.Update(clientsDTO);

                    TempData["message"] = "The client was successfully updated!";
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}

