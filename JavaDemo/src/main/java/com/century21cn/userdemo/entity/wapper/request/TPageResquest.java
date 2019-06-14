package com.century21cn.userdemo.entity.wapper.request;

import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;

import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import javax.validation.constraints.NotBlank;
import java.util.List;

@ApiModel(value = "TPageResquest", description = "service分页泛型请求值包装类")
public class TPageResquest<TData> {

    public List<TData> getData() {
        return data;
    }

    public void setData(List<TData> data) {
        this.data = data;
    }

    public Integer getPageNumber() {
        return pageNumber;
    }

    public void setPageNumber(Integer pageNumber) {
        this.pageNumber = pageNumber;
    }

    public Integer getPageSize() {
        return pageSize;
    }

    public void setPageSize(Integer pageSize) {
        this.pageSize = pageSize;
    }

    public String getRegionCode() {
        return regionCode;
    }

    public void setRegionCode(String regionCode) {
        this.regionCode = regionCode;
    }

    @ApiModelProperty(value = "数据")
    private List<TData> data;

    @ApiModelProperty(value = "当前页码 ",example = "1")
    @Min(value = 0, message = "当前页码必须大于等于零")
    private Integer pageNumber;

    @ApiModelProperty(value = "每页显示记录数 ",  example = "10")
    @Min(value = 1, message = "每页显示记录数必须大于等于1")
    @Max(value = 100, message = "每页显示记录数必须小于等于100")
    private Integer pageSize;

    @ApiModelProperty(value = "区域编码 ", example = "B225")
    @NotBlank(message = "区域编码不能为空！")
    private String regionCode;

}
