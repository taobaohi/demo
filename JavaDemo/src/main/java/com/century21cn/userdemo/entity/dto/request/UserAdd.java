package com.century21cn.userdemo.entity.dto.request;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;

@ApiModel(value = "UserAdd",description = "新增用户对象")
public class UserAdd {

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

    @ApiModelProperty(value = "用户姓名", dataType = "String",example = "李明")
    private String name;
    @ApiModelProperty(value = "性别", dataType = "String",example = "男")
    private String sex;
}
