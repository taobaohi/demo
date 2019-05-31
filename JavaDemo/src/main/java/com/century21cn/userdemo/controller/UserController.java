package com.century21cn.userdemo.controller;

import com.century21cn.userdemo.entity.User;
import com.century21cn.userdemo.entity.Wapper.OutputT;
import com.century21cn.userdemo.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

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

    @PostMapping("getUserByCondition")
    public OutputT<List<User>> getUserByCondition(@RequestBody User user) throws Exception {
        return userService.getUserByCondition(user);
    }

    @GetMapping("getUserById")
    public OutputT<User> getUserById(Integer id) throws Exception {
        return userService.getUserById(id);
    }

    @PostMapping("addUser")
    public void addUser(@RequestBody User user) throws Exception {
        userService.addUser(user);
    }

    @PostMapping("updateUserById")
    public void updateUserById(@RequestBody User user) throws Exception {
        userService.updateUserById(user);
    }

    @GetMapping("deleteUserById")
    public void deleteUserById(Integer id) throws Exception {
        userService.deleteUserById(id);
    }
}
