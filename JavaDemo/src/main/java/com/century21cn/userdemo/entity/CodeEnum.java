package com.century21cn.userdemo.entity;

public enum CodeEnum {

    SUCCESS(200, "成功"),
    ERROR(500, "程序执行错误");

    private Integer statusCode;

    private String message;

    CodeEnum(Integer statusCode, String message) {
        this.statusCode = statusCode;
        this.message = message;
    }

    public Integer getStatusCode() {
        return statusCode;
    }

    public void setStatusCode(Integer statusCode) {
        this.statusCode = statusCode;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }
}
