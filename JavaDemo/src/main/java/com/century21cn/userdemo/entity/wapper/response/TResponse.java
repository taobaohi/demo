package com.century21cn.userdemo.entity.wapper.response;

import com.alibaba.fastjson.JSON;
import io.swagger.annotations.ApiModelProperty;

public class TResponse<TData> {

    @ApiModelProperty(value = "状态码 ")
    private Integer status;

    @ApiModelProperty(value = "提示信息 ")
    private String message;

    @ApiModelProperty(value = "具体内容 ")
    private TData data;

    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public TData getData() {
        return data;
    }

    public void setData(TData data) {
        this.data = data;
    }

    @Override
    public String toString() {

        return JSON.toJSONString(data);
    }

}
