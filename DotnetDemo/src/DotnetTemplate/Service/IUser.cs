using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetDemo.Model;

namespace DotnetDemo.Service
{
    public interface IUser
    {
        Wapper.OutputT<int> Create(Model.User user);
        Wapper.OutputT<int> Edit(Model.User user);
        Wapper.OutputT<int> Delete(int id);
        Wapper.OutputT<Model.User> GetById(int id);
        Wapper.OutputT<IEnumerable<Model.User>> GetAll();
    }
}
