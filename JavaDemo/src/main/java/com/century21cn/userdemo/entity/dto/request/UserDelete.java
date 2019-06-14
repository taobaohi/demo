package com.century21cn.userdemo.entity.dto.request;

import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;

import java.util.List;

@ApiModel(value = "UserDelete", description = "用户删除对象")
public class UserDelete {

    @ApiModelProperty(value = "用户id集合", dataType = "List", example = "[1,2]")
    private List<Long> userIds;

    public List<Long> getUserIds() {
        return userIds;
    }

    public void setUserIds(List<Long> userIds) {
        this.userIds = userIds;
    }
}
