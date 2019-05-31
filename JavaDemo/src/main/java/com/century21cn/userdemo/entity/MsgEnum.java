package com.century21cn.userdemo.entity;

public enum MsgEnum {

    SUCCESS(200, "成功"),
    ERROR(500, "程序执行错误");

    private int id;
    private String name;

    MsgEnum(int id, String msg) {
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
