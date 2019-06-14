package com.century21cn.userdemo.service;

import com.century21cn.userdemo.entity.dto.request.UserAdd;
import com.century21cn.userdemo.entity.dto.request.UserUpdate;
import com.century21cn.userdemo.entity.dto.response.UserResponse;
import com.century21cn.userdemo.entity.wapper.response.TPageResponse;
import com.century21cn.userdemo.entity.wapper.response.TResponse;

import java.util.List;


public interface UserService {

    /**
     * 查询所有用户信息
     *
     * @return
     * @throws Exception
     */
    TPageResponse<List<UserResponse>> getUserAll() throws Exception;

    TPageResponse<List<UserResponse>> getUserByCondition(UserAdd user) throws Exception;

    /**
     * 根据用户id查询用户信息
     *
     * @param id
     * @return
     * @throws Exception
     */
    TResponse<UserResponse> getUserById(Integer id) throws Exception;

    /**
     * 新增用户
     *
     * @param user
     * @return
     */
    void addUser(UserAdd user) throws Exception;

    /**
     * 修改用户信息
     *
     * @param user
     * @return
     * @throws Exception
     */
    void updateUserById(UserUpdate user) throws Exception;

    /**
     * 根据用户id删除用户信息
     *
     * @param id
     * @throws Exception
     */
    void deleteUserById(Integer id) throws Exception;
}
