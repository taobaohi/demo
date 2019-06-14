package com.century21cn.userdemo.entity.wapper;

public class InputPageInfo
{

    /**
     * 当前页数
     * @return
     */
    public Integer getCurrentPage() {
        return currentPage;
    }

    /**
     * 当前页数
     * @param currentPage
     */
    public void setCurrentPage(Integer currentPage) {
        this.currentPage = currentPage;
    }

    /**
     * 每页条数
     * @return
     */
    public Integer getPageSize() {
        return pageSize;
    }

    /**
     * 每页条数
     * @param pageSize
     */
    public void setPageSize(Integer pageSize) {
        this.pageSize = pageSize;
    }


     // [Range(1, 9999, ErrorMessage = "当前页数为1-999的整数")]
    private Integer currentPage;


    // [Range(1, 100, ErrorMessage = "每页显示条数为1-100的整数")]
    private Integer pageSize;
}