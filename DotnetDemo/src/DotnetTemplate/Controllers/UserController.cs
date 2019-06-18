using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetdemo.model;
using Microsoft.AspNetCore.Mvc;

namespace dotnetdemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Service.IUser _user;
        public UserController(Service.IUser user)
        {
            _user = user;
        }

        // GET api/values
        [HttpGet]
        public Wapper.OutputT<IEnumerable<model.User>> Get()
        {
            return _user.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Wapper.OutputT<model.User> Get(int id)
        {
            return  _user.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public Wapper.OutputT<int> Create([FromBody] model.User user)
        {
            return _user.Create(user);
        }

        // PUT api/values/5
        [HttpPut]
        public Wapper.OutputT<int> Edit([FromBody] model.User user)
        {
            return _user.Edit(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Wapper.OutputT<int> Delete(int id)        
        {
            return _user.Delete(id);
        }
    }
}
