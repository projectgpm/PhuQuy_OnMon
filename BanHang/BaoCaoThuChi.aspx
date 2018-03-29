<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="BaoCaoThuChi.aspx.cs" Inherits="BanHang.BaoCaoThuChi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Thông tin báo cáo" ColCount="4" HorizontalAlign="Center">
                <Items>
                    <dx:LayoutItem Caption="Ngày BĐ">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                <dx:ASPxDateEdit ID="dateNgayBD" runat="server" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                </dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ngày KT">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                <dx:ASPxDateEdit ID="dateNgayKT" runat="server" Width="100%" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                </dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                                <dx:ASPxButton ID="btnXemBaoCao" runat="server" Text="Xem báo cáo" Width="100%" OnClick="btnXemBaoCao_Click">
                                    <Image IconID="layout_list_32x32devav">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnXuatExcel" runat="server" OnClick="btnXuatExcel_Click" Text="Xuất file Excel" Width="100%">
                                    <Image IconID="export_exporttoxlsx_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
                <SettingsItemCaptions HorizontalAlign="Center" />
                <SettingsItems HorizontalAlign="Center" />
            </dx:LayoutGroup>
        </Items>
        <SettingsItemCaptions HorizontalAlign="Center" />
        <SettingsItemHelpTexts HorizontalAlign="Center" />
        <SettingsItems HorizontalAlign="Center" />
    </dx:ASPxFormLayout>
      <dx:ASPxGridView ID="gridDanhSach" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%">
          <SettingsPager Mode="ShowAllRecords" Visible="False">
          </SettingsPager>
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings AutoFilterCondition="Contains" ShowFilterRow="True" />
      
        
<SettingsCommandButton>
<ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

<HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
</SettingsCommandButton>
      
        
        <Columns>
            <dx:GridViewDataTextColumn Caption="Người nộp/nhận" FieldName="NguoiNop" VisibleIndex="2" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Nội dung" FieldName="NoiDung" VisibleIndex="3" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Ngày lập" FieldName="NgayLap" ShowInCustomizationForm="True" VisibleIndex="0">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn Caption="Ngày lưu" FieldName="NgayLuu" ShowInCustomizationForm="True" VisibleIndex="9">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn Caption="Người lập" FieldName="IDNguoiLap" ShowInCustomizationForm="True" VisibleIndex="1">
                <PropertiesComboBox DataSourceID="SqlNguoiLap" TextField="TenNguoiDung" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Dư đầu" FieldName="DuDau" ShowInCustomizationForm="True" VisibleIndex="4">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Số tiền" FieldName="SoTien" ShowInCustomizationForm="True" VisibleIndex="5">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Dư cuối" FieldName="DuCuoi" ShowInCustomizationForm="True" VisibleIndex="6">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Loại phiếu" FieldName="IDLoaiThuChi" ShowInCustomizationForm="True" VisibleIndex="7">
                <PropertiesComboBox DataSourceID="SqlLoaiPhieu" TextField="TrangThai" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Tên phiếu" FieldName="TenPhieu" ShowInCustomizationForm="True" VisibleIndex="8">
                <PropertiesComboBox>
                    <Items>
                        <dx:ListEditItem Text="Phiếu thu" Value="0" />
                        <dx:ListEditItem Text="Phiếu chi" Value="1" />
                    </Items>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
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
    <asp:SqlDataSource ID="SqlLoaiPhieu" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [GPM_TrangThaiChi]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlNguoiLap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNguoiDung] FROM [GPM_NguoiDung]"></asp:SqlDataSource>
</asp:Content>
