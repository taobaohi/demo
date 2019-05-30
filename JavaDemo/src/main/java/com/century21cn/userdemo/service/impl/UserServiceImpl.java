package com.century21cn.userdemo.service.impl;

import com.century21cn.userdemo.entity.User;
import com.century21cn.userdemo.mapper.UserMapper;
import com.century21cn.userdemo.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImpl implements UserService {

    @Autowired
    private UserMapper userMapper;

    @Override
    public List<User> getUserAll() throws Exception {

        return userMapper. getUserAll();
    }

    @Override
    public List<User> getUserByCondition(User user) throws Exception {
        return userMapper.getUserByCondition(user);
    }

    @Override
    public User getUserById(Integer id) throws Exception {
        return userMapper.getUserById(id);
    }

    @Override
    public void addUser(User user) throws Exception {
        userMapper.addUser(user);
    }

    @Override
    public void updateUserById(User user) throws Exception {
        userMapper.updateUserById(user);
    }

    @Override
    public void deleteUserById(Integer id) throws Exception {
        userMapper.deleteUserById(id);
    }
}
