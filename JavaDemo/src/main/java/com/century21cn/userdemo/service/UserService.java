package com.century21cn.userdemo.service;

import com.century21cn.userdemo.entity.User;

import java.util.List;
import  com.century21cn.userdemo.entity.Wapper.OutputT;


public interface UserService {

    /**
     * 查询所有用户信息
     *
     * @return
     * @throws Exception
     */
    OutputT<List<User>> getUserAll() throws Exception;

    OutputT<List<User>> getUserByCondition(User user) throws Exception;

    /**
     * 根据用户id查询用户信息
     *
     * @param id
     * @return
     * @throws Exception
     */
    OutputT<User> getUserById(Integer id) throws Exception;

    /**
     * 新增用户
     *
     * @param user
     * @return
     */
    void addUser(User user) throws Exception;

    /**
     * 修改用户信息
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
