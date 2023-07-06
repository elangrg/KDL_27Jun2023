﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using WebAPICustomFormatters.Models;

namespace WebAPICustomFormatters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private static readonly ConcurrentDictionary<string, Contact> _contacts =
           new ConcurrentDictionary<string, Contact>();

        public ContactsController()
        {
            if (_contacts.Count == 0)
                Add(new Contact { FirstName = "Ganesh", LastName = "Mahesh" });
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contacts.Values;
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(string id)
        {
            if (!_contacts.TryGetValue(id, out var contact))
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {


            Add(contact);

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!_contacts.ContainsKey(id))
            {
                return NotFound();
            }

            _contacts.TryRemove(id, out _);

            return NoContent();
        }

        private void Add(Contact contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            _contacts[contact.Id] = contact;
        }
    }
}
