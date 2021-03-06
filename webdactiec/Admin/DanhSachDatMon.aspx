﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAD.master" AutoEventWireup="true" CodeFile="DanhSachDatMon.aspx.cs" Inherits="Admin_DanhSachDatMon" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
        }
        .auto-style4 {
            width: 204px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div id="CTDT" runat="server" visible="true">
 
       
        <table align="center" class="auto-style2">
        <tr>
            <td align="center"><h3>Danh Sách Đặt Tiệc</h3></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GrvDanhSachDatMon" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GrvDanhSachDatMon_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="IdDatMon" HeaderText="Mã đặt món" />
                        <asp:BoundField DataField="Hoten" HeaderText="Tên khách hàng" />
                        <asp:BoundField DataField="Dienthoai" HeaderText="Tên khách hàng" />
                        <asp:BoundField DataField="NgayToChuc" HeaderText="Ngày tổ chức"  DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ThoiGianToChuc" HeaderText="Thời gian tổ chức" />
                        <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                        <asp:BoundField DataField="Tenmon" HeaderText="Tên món"  />
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                        <asp:BoundField DataField="ThanhTien" HeaderText="Thành tiền" />
                         <asp:TemplateField HeaderText="Cập Nhật">
                            <ItemTemplate>
                                <a href="QL_DatMon.aspx?id=<%#Eval("IdDatMon") %>">Chọn</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
      
    </table>
        
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

