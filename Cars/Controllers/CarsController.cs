﻿using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Cars.Data;
using Cars.Models.Car;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        private readonly ICarsServices _carsServices;

        public CarsController(CarsContext context, ICarsServices carsServices)
        {
            _context = context;
            _carsServices = carsServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars.Select(x => new CarsIndexViewModel
            {
                Id = x.Id,
                Make = x.Make,
                Model = x.Model,
                Year = x.Year,
                Fuel = x.Fuel,


            });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Year = vm.Year,
                Color = vm.Color,
                Power = vm.Power,
                Fuel = vm.Fuel,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };
            var result = await _carsServices.Create(dto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarsDetailsViewModel();
            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.Power = car.Power;
            vm.Fuel = car.Fuel;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {

                return NotFound();
            }
            var vm = new CarsCreateUpdateViewModel();
            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.Power = car.Power;
            vm.Fuel = car.Fuel;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarsCreateUpdateViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest();
            }
            var dto = new CarsDto()
            {
                Id = vm.Id,
                Make = vm.Make,
                Model = vm.Model,
                Color = vm.Color,
                Year = vm.Year,
                Power = vm.Power,
                Fuel = vm.Fuel,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,

            };
            var result = await _carsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarsDeleteViewModel();

            vm.Id = car.Id;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Fuel = car.Fuel;
            vm.Power = car.Power;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid Id)
        {
            var id = await _carsServices.Delete(Id);

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
