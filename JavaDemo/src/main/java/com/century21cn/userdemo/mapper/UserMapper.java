package com.century21cn.userdemo.mapper;

import java.util.List;

public interface UserMapper {

    /**
     * 查询所有用户信息
     *
     * @return
     * @throws Exception
     */
    List<User> getUserAll() throws Exception;

    List<User> getUserByCondition(User user) throws Exception;

    /**
     * 根据用户id查询用户信息
     *
     * @param id
     * @return
     * @throws Exception
     */
    User getUserById(Integer id) throws Exception;

    /**
     * 新增用户
     *
     * @param user
     * @return
     * @throws Exception
     */
    void addUser(User user) throws Exception;

    /**
     * 修改用户
     *
     * @param user
     * @return
     * @throws Exception
     */
    void updateUserById(User user) throws Exception;

    /**
     * 根据用户id删除用户信息
     *
     * @param id
     * @throws Exception
     */
    void deleteUserById(Integer id) throws Exception;
}
