package com.century21cn.userdemo.entity.wapper;

public class OutputPageInfo {

    public int getCurrentPage() {
        return currentPage;
    }

    public void setCurrentPage(int currentPage) {
        this.currentPage = currentPage;
    }

    public int getPageSize() {
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }

    public int getTotalPages() {
        return totalPages;
    }

    public void setTotalPages(int totalPages) {
        this.totalPages = totalPages;
    }

    public int getTotalRows() {
        return totalRows;
    }

    public void setTotalRows(int totalRows) {
        this.totalRows = totalRows;
    }

    /// <summary>
    /// 当前页数
    /// </summary>
    private int currentPage;

    /// <summary>
    /// 每页条数
    /// </summary>
    private int pageSize;

    /// <summary>
    /// 总页数
    /// </summary>
    private int totalPages;

    /// <summary>
    /// 总记录数
    /// </summary>
    private int totalRows;

}
