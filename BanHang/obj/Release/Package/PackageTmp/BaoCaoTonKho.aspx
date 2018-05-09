<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="BaoCaoTonKho.aspx.cs" Inherits="BanHang.BaoCaoTonKho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
     <dx:ASPxButton ID="btnXuatFile" runat="server" Text="Xuất file excel" OnClick="btnXuatFile_Click">
        <Image IconID="export_exporttoxlsx_32x32">
        </Image>
        <Paddings PaddingLeft="20px" />
    </dx:ASPxButton>
      <dx:ASPxGridView ID="gridTonKhoBanDau" runat="server" AutoGenerateColumns="False" KeyFieldName="MAHANG" Width="100%" OnHtmlRowPrepared="gridTonKhoBanDau_HtmlRowPrepared" DataSourceID="sqlHangHoa" >
        <SettingsPager PageSize="200" Mode="EndlessPaging">
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
        <SettingsText Title="BÁO CÁO TỒN KHO" EmptyDataRow="Danh sách tồn kho rỗng" SearchPanelEditorNullText="Nhập thông tin cần tìm..." />
      
        <EditFormLayoutProperties ColCount="2">
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MAHANG" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn Caption="Số Lượng Tồn" FieldName="SOLUONGTON" VisibleIndex="2">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Đơn giá" FieldName="DONGIA" VisibleIndex="3">
                <PropertiesSpinEdit DisplayFormatString="N2" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataTextColumn Caption="Hàng Hóa" FieldName="TENHANGHOA" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn Caption="Thành tiền" FieldName="THANHTIEN" VisibleIndex="4">
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
    <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="psbaocaotonkho" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
</asp:Content>
