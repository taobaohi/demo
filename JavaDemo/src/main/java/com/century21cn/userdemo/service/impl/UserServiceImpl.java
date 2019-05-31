package com.century21cn.userdemo.service.impl;

import com.century21cn.userdemo.entity.MsgEnum;
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
            output.setMsg(MsgEnum.SUCCESS.getName());
            output.setCode(MsgEnum.SUCCESS.getId());
            var data = userMapper.getUserAll();
            output.setData(data);
        } catch (Exception e) {
            output.setMsg(MsgEnum.SUCCESS.name());
            output.setCode(MsgEnum.SUCCESS.getId());
        }
        return output;
    }

    @Override
    public OutputT<List<User>> getUserByCondition(User user) throws Exception {
        var output = new OutputT<List<User>>();
        try {
            output.setMsg(MsgEnum.SUCCESS.getName());
            output.setCode(MsgEnum.SUCCESS.getId());
            var data = userMapper.getUserByCondition(user);
            output.setData(data);
        } catch (Exception ex) {
            output.setCode(MsgEnum.ERROR.getId());
            output.setMsg(MsgEnum.ERROR.getName());
        }
        return output;
    }

    @Override
    public OutputT<User> getUserById(Integer id) throws Exception {
        var output = new OutputT<User>();
        try {
            output.setMsg(MsgEnum.SUCCESS.getName());
            output.setCode(MsgEnum.SUCCESS.getId());
            output.setData(userMapper.getUserById(id));
        } catch (Exception ex) {
            output.setCode(MsgEnum.ERROR.getId());
            output.setMsg(MsgEnum.ERROR.getName());
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
