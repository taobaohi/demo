package com.century21cn.userdemo.entity.wapper.response;

import com.alibaba.fastjson.JSON;
import io.swagger.annotations.ApiModelProperty;


public class TPageResponse<TData> {
    @ApiModelProperty(value = "状态码 ")
    private Integer status;

    @ApiModelProperty(value = "提示信息 ")
    private String message;

    @ApiModelProperty(value = "具体内容 ")
    private TData data;

    @Override
    public String toString() {

        return JSON.toJSONString(data);
    }
}
