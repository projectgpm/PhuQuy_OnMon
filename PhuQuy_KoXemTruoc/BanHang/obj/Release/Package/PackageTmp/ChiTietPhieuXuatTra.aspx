﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietPhieuXuatTra.aspx.cs" Inherits="BanHang.ChiTietPhieuXuatTra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="gridChiTietPhieuXuatTra" KeyFieldName="ID">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
<Settings ShowTitlePanel="True" ShowFilterRow="True" ShowFooter="True"></Settings>

        <SettingsBehavior ConfirmDelete="True" />

        <SettingsCommandButton>
        <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

        <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            <NewButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_add_16x16" ToolTip="Thêm mới">
                </Image>
            </NewButton>
            <UpdateButton ButtonType="Image" RenderMode="Image">
                <Image IconID="save_save_32x32office2013" ToolTip="Lưu">
                </Image>
            </UpdateButton>
            <CancelButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_close_32x32" ToolTip="Hủy thao tác">
                </Image>
            </CancelButton>
            <EditButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_edit_16x16devav" ToolTip="Sửa">
                </Image>
            </EditButton>
            <DeleteButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>

        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>

                 <SettingsSearchPanel Visible="True" />

<SettingsText Title="THÔNG TIN CHI TIẾT PHIẾU XUẤT TRẢ" CommandDelete="Xóa" ConfirmDelete="Bạn chắc chắn muốn xóa?" CommandEdit="Sửa" EmptyDataRow="Danh sách hàng hóa trống" SearchPanelEditorNullText="Nhập thông tin cần tìm..."></SettingsText>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem Caption="Hàng Hóa" ColumnName="Hàng Hóa" Name="IDHangHoa">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem Caption="Số Lượng" ColumnName="Số Lượng" Name="SoLuong">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right" ColSpan="2">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
<Columns>
    <dx:GridViewDataComboBoxColumn FieldName="IDHangHoa" Caption="H&#224;ng H&#243;a" VisibleIndex="1" ReadOnly="True">
    <PropertiesComboBox DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID"></PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
    <dx:GridViewDataSpinEditColumn Caption="Số Lượng Trả" FieldName="SoLuong" VisibleIndex="4">
        <propertiesspinedit DisplayFormatString="N1" NumberFormat="Custom"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Tồn Kho" FieldName="TonKho" VisibleIndex="3" ReadOnly="True">
        <propertiesspinedit DisplayFormatString="N1" NumberFormat="Custom"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    
    <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" VisibleIndex="2">
        <PropertiesComboBox DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
        </PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
    
    <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="0">
    </dx:GridViewDataTextColumn>
    
    <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="GhiChu" VisibleIndex="7">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" VisibleIndex="6">
        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" VisibleIndex="5">
        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    
</Columns>

                 <TotalSummary>
                     <dx:ASPxSummaryItem DisplayFormat="Tổng mặt hàng : {0}" FieldName="MaHang" ShowInColumn="Hàng Hóa" SummaryType="Count" />
                     <dx:ASPxSummaryItem DisplayFormat="Tổng tiền: {0}" FieldName="ThanhTien" ShowInColumn="Thành Tiền" SummaryType="Sum" />
                 </TotalSummary>

<Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
  
</dx:ASPxGridView>
        <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
