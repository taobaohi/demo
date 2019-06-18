using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetdemo.model;

namespace dotnetdemo.Service
{
    public interface IUser
    {
        Wapper.OutputT<int> Create(model.User user);
        Wapper.OutputT<int> Edit(model.User user);
        Wapper.OutputT<int> Delete(int id);
        Wapper.OutputT<model.User> GetById(int id);
        Wapper.OutputT<IEnumerable<model.User>> GetAll();
    }
}
