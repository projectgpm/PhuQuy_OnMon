﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietBangGia.aspx.cs" Inherits="BanHang.ChiTietBangGia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="gridChiTietPhieuKiemKho" KeyFieldName="ID" OnRowUpdating="gridChiTietPhieuKiemKho_RowUpdating">
                 <SettingsPager Mode="ShowAllRecords">
                 </SettingsPager>
        <SettingsEditing Mode="Batch">
        </SettingsEditing>
<Settings ShowTitlePanel="True" ShowFilterRow="True"></Settings>

        <SettingsBehavior ConfirmDelete="True" />

        <SettingsCommandButton>
        <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

        <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            <NewButton>
                <Image IconID="actions_add_16x16" ToolTip="Thêm mới">
                </Image>
            </NewButton>
            <UpdateButton Text="Lưu lại">
                <Image IconID="save_save_32x32office2013" ToolTip="Lưu">
                </Image>
            </UpdateButton>
            <CancelButton Text="Hủy thao tác">
                <Image IconID="actions_close_32x32" ToolTip="Hủy thao tác">
                </Image>
            </CancelButton>
            <EditButton>
                <Image IconID="actions_edit_16x16devav" ToolTip="Sửa">
                </Image>
            </EditButton>
            <DeleteButton>
                <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>

        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>

                 <SettingsSearchPanel Visible="True" />

<SettingsText Title="THÔNG TIN CHI TIẾT BẢNG GIÁ" CommandDelete="Xóa" ConfirmDelete="Bạn chắc chắn muốn xóa?" CommandEdit="Sửa" SearchPanelEditorNullText="Nhập thông tin cần tìm..."></SettingsText>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="Mã Hàng">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Hàng Hóa">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ĐVT">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Tồn Kho">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="Thực Tế">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
<Columns>
    <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" VisibleIndex="2" ReadOnly="true" Name="TenHangHoa" FieldName="TenHangHoa">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="Mã Hàng" VisibleIndex="1" ReadOnly="True" FieldName="MaHang">
    </dx:GridViewDataTextColumn>
    
    <dx:GridViewDataTextColumn Caption="ĐVT Sỉ" VisibleIndex="3" ReadOnly="true" FieldName="TenDonViTinhSi">
    </dx:GridViewDataTextColumn>
    
    <dx:GridViewDataSpinEditColumn Caption="Giáp Bán Sỉ" VisibleIndex="6" FieldName="GiaBanSi">
        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
            <ValidationSettings SetFocusOnError="True">
                <RequiredField IsRequired="True" />
            </ValidationSettings>
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    
    <dx:GridViewDataSpinEditColumn Caption="Giá Hệ Thống" ReadOnly="True" VisibleIndex="5" FieldName="GiaHeThong">
        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    
    <dx:GridViewDataSpinEditColumn Caption="Giá Bán Lẻ" FieldName="GiaBanLe" VisibleIndex="7">
        <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
            <ValidationSettings SetFocusOnError="True">
                <RequiredField IsRequired="True" />
            </ValidationSettings>
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    
    <dx:GridViewDataTextColumn Caption="ĐVT Lẻ" FieldName="TenDonViTinhLe" ReadOnly="True" VisibleIndex="4">
    </dx:GridViewDataTextColumn>
    
</Columns>

<Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
  
</dx:ASPxGridView>
    </div>
    </form>
</body>
</html>
