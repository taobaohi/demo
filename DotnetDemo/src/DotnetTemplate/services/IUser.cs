using System.Collections.Generic;

namespace servicedemo.services
{
    using models.dto.comm;
    using models.dto.wapper;
    using models.dto.request;
    using models.dto.response;

    public interface IUser
    {
        ResponseT<long> Create(RequestT<UserAdd> userAdd);
        ResponseT<int> Edit(RequestT<UserUpdate> userUpdate);
        ResponseT<int> Delete(RequestT<UserDelete> userDelete);
        ResponseT<UserDetail> GetById(long id);
        PageResponseT<UserList> GetFilter(PageRequestT<UserFilter> userFilter);
    }
}
