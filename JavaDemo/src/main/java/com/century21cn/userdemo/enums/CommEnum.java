package com.century21cn.userdemo.enums;

public enum CommEnum {

    SUCCESS(200, "成功"),
    ERROR(500, "程序执行错误");

    private int id;
    private String name;

    CommEnum(int id, String msg) {
        this.id = id;
        this.name = msg;
    }
    /**
     * 获取消息id
     *
     * @return
     */
    public int getId() {
        return id;
    }
    /**
     * 获取消息
     *
     * @return
     */
    public String getName() {
        return name;
    }
}
