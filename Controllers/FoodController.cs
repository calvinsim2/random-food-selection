using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RandomFoodSelection.Dto;
using RandomFoodSelection.Interfaces.Services;
using RandomFoodSelection.Model;

namespace RandomFoodSelection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IValidator<FoodDto> _foodDtoValidator;
        private readonly IMapper _mapper;

        public FoodController(IFoodService foodService,
                              IValidator<FoodDto> foodDtoValidator,
                              IMapper mapper)
        {
            _foodService = foodService;
            _foodDtoValidator = foodDtoValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var foods = await _foodService.GetAllFoodAsync();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodByIdAsync(string id)
        {
            var food = await _foodService.GetFoodByIdAsync(Guid.Parse(id));
            if (food is null)
            {
                return NotFound(id);
            }
            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodAsync([FromBody] FoodDto foodDto)
        {
            await _foodDtoValidator.ValidateAsync(foodDto, options => options.ThrowOnFailures());
            var food = _mapper.Map<Food>(foodDto);
            await _foodService.AddFoodAsync(food);
            return Ok(foodDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateExistingFoodAsync([FromBody] Food food)
        {
            await _foodService.UpdateFoodAsync(food);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistingFoodAsync(string id)
        {
            await _foodService.DeleteFoodAsync(Guid.Parse(id));
            return Ok();
        }
    }
}
