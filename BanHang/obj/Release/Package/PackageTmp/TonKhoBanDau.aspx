﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="TonKhoBanDau.aspx.cs" Inherits="BanHang.TonKhoBanDau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxButton ID="btnXuatFile" runat="server" Text="Xuất file excel" OnClick="btnXuatFile_Click">
        <Image IconID="export_exporttoxlsx_32x32">
        </Image>
        <Paddings PaddingLeft="20px" />
    </dx:ASPxButton>
    <dx:ASPxGridView ID="gridTonKhoBanDau" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnHtmlRowPrepared="gridTonKhoBanDau_HtmlRowPrepared" >
        <SettingsPager PageSize="50" Mode="EndlessPaging">
        </SettingsPager>
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowTitlePanel="True" VerticalScrollableHeight="600" />
        <SettingsBehavior ConfirmDelete="True" />

        <SettingsCommandButton>
            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            <DeleteButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_cancel_16x16">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>

        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>
      
        <SettingsSearchPanel Visible="True" />
        <SettingsText Title="DANH SÁCH HÀNG HÓA TỒN KHO" EmptyDataRow="Danh sách tồn kho rỗng" SearchPanelEditorNullText="Nhập thông tin cần tìm..." />
      
        <EditFormLayoutProperties ColCount="2">
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHang" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Hàng Hóa" FieldName="IDHangHoa" VisibleIndex="1">
                <PropertiesComboBox DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" FieldName="NgayCapNhat" VisibleIndex="5">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinhSi" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="SqlDonViTinh" TextField="TenDonViTinh" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Số Lượng Tồn" FieldName="SoLuongCon" VisibleIndex="3">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tồn Kho Nhỏ Nhất" FieldName="TonKhoNhoNhat" VisibleIndex="4">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
        </Columns>
        <FormatConditions>
           <dx:GridViewFormatConditionHighlight FieldName="SoLuongCon" Expression="[SoLuongCon] < 6" Format="LightRedFillWithDarkRedText" />
            <dx:GridViewFormatConditionHighlight FieldName="SoLuongCon" Expression="[SoLuongCon] > 6" Format="GreenFillWithDarkGreenText" />
            
        </FormatConditions>
        <Styles>
            <Header Font-Bold="True" HorizontalAlign="Center">
            </Header>
            <AlternatingRow Enabled="True">
            </AlternatingRow>
            <TitlePanel Font-Bold="True" HorizontalAlign="Left">
            </TitlePanel>
        </Styles>
    </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="printf" runat="server"></dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [GPM_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
