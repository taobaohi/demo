package com.century21cn.userdemo.entity.Wapper;

import com.alibaba.fastjson.JSON;
import com.century21cn.userdemo.entity.CodeEnum;

import java.util.List;

public class OutputPageT<TData>
{
    private CodeEnum code;
    private String msg;
    private List<TData> dataList;
    private OutputPageInfo pageData;

    /**
     * 返回代码
     * @return
     */
    public CodeEnum getCode() {
        return code;
    }

    /**
     * 返回代码
     * @param code
     */
    public void setCode(CodeEnum code) {
        this.code = code;
    }

    /**
     * 返回消息
     * @return
     */
    public String getMsg() {
        return msg;
    }
    /**
     * 返回消息
     * @param msg
     */
    public void setMsg(String msg) {
        this.msg = msg;
    }

    /**
     * 通用返回数据
     * @return
     */
    public List<TData> getDataList() {
        return dataList;
    }
    /**
     * 通用返回数据
     * @param dataList
     */
    public void setDataList(List<TData> dataList) {
        this.dataList = dataList;
    }

    /**
     * 分页数据
     * @return
     */
    public OutputPageInfo getPageData() {
        return pageData;
    }

    /**
     * 分页数据
     * @param pageData
     */
    public void setPageData(OutputPageInfo pageData) {
        this.pageData = pageData;
    }

}
