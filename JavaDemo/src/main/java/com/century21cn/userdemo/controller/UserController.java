package com.century21cn.userdemo.controller;

import com.century21cn.userdemo.entity.wapper.OutputT;
import com.century21cn.userdemo.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.List;

import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;

@Api(tags="用户API")
@RestController
public class UserController {

    @Autowired
    private UserService userService;

    @GetMapping("getUserAll")
//    @PostMapping
//    @RequestMapping(method = HttpMethod.)
    public OutputT<List<User>> getUserAll() throws Exception {
        return userService.getUserAll();
    }
    @ApiOperation(value = "根据条件筛选用户", notes = "根据条件筛选用户")
    @PostMapping("getUserByCondition")
    public OutputT<List<User>> getUserByCondition(@RequestBody User user) throws Exception {
        return userService.getUserByCondition(user);
    }

    @ApiOperation(value="根据用户id获取用户",notes="根据用户id获取用户")
    @GetMapping("getUserById")
    public OutputT<User> getUserById(Integer id) throws Exception {
        return userService.getUserById(id);
    }

    @ApiOperation(value="添加用户",notes="添加用户")
    @PostMapping("addUser")
    public void addUser(@RequestBody User user) throws Exception {
        userService.addUser(user);
    }

    @ApiOperation(value="更新用户信息",notes = "更新用户信息")
    @PostMapping("updateUserById")
    public void updateUserById(@RequestBody User user) throws Exception {
        userService.updateUserById(user);
    }

    @ApiOperation(value = "根据id删除用户",tags = {"id","user"})
    @GetMapping("deleteUserById")
    public void deleteUserById(Integer id) throws Exception {
        userService.deleteUserById(id);
    }
}
