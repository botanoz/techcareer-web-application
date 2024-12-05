﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TechCareer.Service.Abstracts;
using TechCareer.Service.Concretes;
using Core.Security.Entities;
using TechCareer.Models.Dtos.Event;
using TechCareer.Models.Dtos.Category;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool includeDeleted = false)
        {
            var events = await _eventService.GetListAsync(withDeleted: includeDeleted);
            return Ok(events);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var eventDto = await _eventService.FindEventAsync(new EventRequestDto { Id = id });

            if (eventDto == null)
                return NotFound(new { Message = "Event not found." });

            return Ok(eventDto);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EventAddRequestDto eventAddRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AddedEvent = await _eventService.AddAsync(eventAddRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = AddedEvent.Id }, AddedEvent);
        }

    
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EventUpdateRequestDto eventUpdateRequestDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var UpdatedEvent = await _eventService.UpdateAsync(eventUpdateRequestDto);
                return Ok(UpdatedEvent);
            }
            catch (ApplicationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, [FromQuery] bool permanent = false)
        {
            try
            {
                // _eventService.DeleteAsync kullanıyoruz, çünkü etkinlik işlemi yapıyoruz
                var deletedEvent = await _eventService.DeleteAsync(
                    new EventRequestDto { Id = id }, permanent);

                return Ok(deletedEvent);
            }
            catch (ApplicationException ex)
            {
                // Hata durumunda NotFound dönüyoruz
                return NotFound(new { Message = ex.Message });
            }
        }



        [HttpGet("paginate")]
        public async Task<IActionResult> GetPaginated(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool includeDeleted = false)
        {
            var result = await _eventService.GetPaginateAsync(
                index: pageIndex,
                size: pageSize,
                withDeleted: includeDeleted);

            return Ok(result);
        }
    }
}

