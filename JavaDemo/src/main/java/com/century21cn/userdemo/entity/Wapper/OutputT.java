package com.century21cn.userdemo.entity.Wapper;

import com.alibaba.fastjson.JSON;
import com.century21cn.userdemo.entity.CodeEnum;

public class OutputT<TData>
{

    private CodeEnum code;
    private String msg;
    private TData data ;

    /**
     * 获取错误码
     * @return
     */
    public CodeEnum getCode() {
        return code;
    }

    /**
     * 设置错误码
     * @param code
     */
    public void setCode(CodeEnum code) {
        this.code = code;
    }

    /**
     * 获取错误信息
     * @return
     */
    public String getMsg() {
        return msg;
    }

    /**
     * 设置错误信息
     * @param msg 错误信息
     */
    public void setMsg(String msg) {
        this.msg = msg;
    }

    /**
     * 获取通用返回数据
     * @return
     */
    public TData getData() {
        return data;
    }

    /**
     * 设置通用返回数据
     * @param data
     */
    public void setData(TData data) {
        this.data = data;
    }

    @Override
    public String toString() {

        return JSON.toJSONString(data);
    }

}