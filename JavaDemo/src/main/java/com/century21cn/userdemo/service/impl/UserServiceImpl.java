package com.century21cn.userdemo.service.impl;

import com.century21cn.userdemo.entity.CodeEnum;
import com.century21cn.userdemo.entity.User;
import com.century21cn.userdemo.entity.Wapper.OutputT;
import com.century21cn.userdemo.mapper.UserMapper;
import com.century21cn.userdemo.service.UserService;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.List;

@Service
public class UserServiceImpl implements UserService {

    @Resource
    private UserMapper userMapper;

    @Override
    public OutputT<List<User>> getUserAll() throws Exception {
        var output = new OutputT<List<User>>();
        try {
            output.setMsg(CodeEnum.SUCCESS.getMessage());
            output.setCode(CodeEnum.SUCCESS);
            var data = userMapper.getUserAll();
            output.setData(data);
        } catch (Exception e) {
            output.setMsg(CodeEnum.SUCCESS.name());
            output.setCode(CodeEnum.SUCCESS);
        }
        return output;
    }

    @Override
    public OutputT<List<User>> getUserByCondition(User user) throws Exception {
        var output = new OutputT<List<User>>();
        try {
            output.setMsg(CodeEnum.SUCCESS.getMessage());
            output.setCode(CodeEnum.SUCCESS);
            var data = userMapper.getUserByCondition(user);
            output.setData(data);
        } catch (Exception ex) {
            output.setCode(CodeEnum.ERROR);
            output.setMsg(CodeEnum.ERROR.getMessage());
        }
        return output;
    }

    @Override
    public OutputT<User> getUserById(Integer id) throws Exception {
        var output = new OutputT<User>();
        try {
            output.setMsg(CodeEnum.SUCCESS.getMessage());
            output.setCode(CodeEnum.SUCCESS);
            output.setData(userMapper.getUserById(id));
        } catch (Exception ex) {
            output.setCode(CodeEnum.ERROR);
            output.setMsg(CodeEnum.ERROR.getMessage());
        }
        return output;
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
