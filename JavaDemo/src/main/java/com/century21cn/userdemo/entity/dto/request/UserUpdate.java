package com.century21cn.userdemo.entity.dto.request;

import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;

@ApiModel(value = "UserUpdate", description = "用户修改对象")
public class UserUpdate {
    @ApiModelProperty(value = "用户id", example = "1")
    private Integer userid;
    @ApiModelProperty(value = "用户姓名", example = "李明")
    private String name;
    @ApiModelProperty(value = "性别", example = "男")
    private String sex;

    public Integer getUserid() {
        return userid;
    }

    public void setUserid(Integer userid) {
        this.userid = userid;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSex() {
        return sex;
    }

    public void setSex(String sex) {
        this.sex = sex;
    }
}
