package com.century21cn.userdemo.entity.wapper.request;

import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;

import javax.validation.Valid;
import javax.validation.constraints.NotBlank;

@ApiModel(value = "TRequest",description = "service泛型返回值包装类")
public class TRequest<TData> {

    @Valid
    @ApiModelProperty(value = "数据内容 ")
    private TData data;

    @ApiModelProperty(value = "区域编码 ", example = "B225")
    @NotBlank(message = "区域编码不能为空！")
    private String regionCode;

    public TData getData() {
        return data;
    }

    public void setData(TData data) {
        this.data = data;
    }

    public String getRegionCode() {
        return regionCode;
    }

    public void setRegionCode(String regionCode) {
        this.regionCode = regionCode;
    }
}
