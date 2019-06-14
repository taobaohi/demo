package com.century21cn.userdemo.service.impl;

import com.century21cn.userdemo.enums.CommEnum;
import com.century21cn.userdemo.entity.wapper.OutputT;
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
            output.setMsg(CommEnum.SUCCESS.getName());
            output.setCode(CommEnum.SUCCESS.getId());
            var data = userMapper.getUserAll();
            output.setData(data);
        } catch (Exception e) {
            output.setMsg(CommEnum.ERROR.name());
            output.setCode(CommEnum.ERROR.getId());
        }
        return output;
    }

    @Override
    public OutputT<List<User>> getUserByCondition(User user) throws Exception {
        var output = new OutputT<List<User>>();
        try {
            output.setMsg(CommEnum.SUCCESS.getName());
            output.setCode(CommEnum.SUCCESS.getId());
            var data = userMapper.getUserByCondition(user);
            output.setData(data);
        } catch (Exception ex) {
            output.setCode(CommEnum.ERROR.getId());
            output.setMsg(CommEnum.ERROR.getName());
        }
        return output;
    }



    @Override
    public OutputT<User> getUserById(Integer id) throws Exception {
        // throws Exception:指明我不想处理这个异常，请帮我把它抛给上一级
        var output = new OutputT<User>();
        try {
            output.setMsg(CommEnum.SUCCESS.getName());
            output.setCode(CommEnum.SUCCESS.getId());
            output.setData(userMapper.getUserById(id));
        } catch (Exception ex) {
            output.setCode(CommEnum.ERROR.getId());
            output.setMsg(CommEnum.ERROR.getName());
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
