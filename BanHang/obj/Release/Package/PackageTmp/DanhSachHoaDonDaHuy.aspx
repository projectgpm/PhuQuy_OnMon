<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DanhSachHoaDonDaHuy.aspx.cs" Inherits="BanHang.DanhSachHoaDonDaHuy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ID="gridDanhSach" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridDanhSach_RowDeleting">
         <SettingsDetail ShowDetailRow="True" />
         <Templates>
             <DetailRow>
                 <div style="padding-top:0px; padding-bottom: 14px;">
                    <dx:ASPxLabel ID="lblChiTietHang" runat="server" Text="Chi tiết hóa đơn" Font-Bold="True" ForeColor="#009933" Font-Italic="True" Font-Size="16px" Font-Underline="True">
                </dx:ASPxLabel>
                </div>
                <dx:ASPxGridView ID="gridChiTietNhapKho" runat="server" AutoGenerateColumns="False" DataSourceID="dsChiTietHoaDon" KeyFieldName="ID" Width="100%" OnBeforePerformDataSelect="gridChiTietNhapKho_BeforePerformDataSelect">
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <SettingsCommandButton>
                        <ShowAdaptiveDetailButton ButtonType="Image">
                        </ShowAdaptiveDetailButton>
                        <HideAdaptiveDetailButton ButtonType="Image">
                        </HideAdaptiveDetailButton>
                    </SettingsCommandButton>
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="TenHangHoa" VisibleIndex="0" Caption="Tên hàng hóa">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TenDonViTinh" VisibleIndex="1" Caption="ĐVT">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DoDay" VisibleIndex="2" Caption="Độ dày">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Thành tiền" FieldName="ThanhTien" VisibleIndex="6">
                            <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Giá bán" FieldName="GiaBan" VisibleIndex="5">
                            <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn Caption="Số lượng" FieldName="SoLuong" VisibleIndex="4">
                            <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>

                    <FormatConditions>
                        <dx:GridViewFormatConditionHighlight FieldName="TonKho" Expression="[TonKho] < 1" Format="LightRedFillWithDarkRedText" />
                            <dx:GridViewFormatConditionHighlight FieldName="TonKho" Expression="[TonKho] > 0" Format="GreenFillWithDarkGreenText" />
                        <dx:GridViewFormatConditionTopBottom FieldName="TonKho" Rule="TopItems" Threshold="15" Format="BoldText"  CellStyle-HorizontalAlign="Center">
    <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewFormatConditionTopBottom>
                    </FormatConditions>
                    <Styles>
                        <AlternatingRow Enabled="True">
                        </AlternatingRow>                    
                        <Header BackColor="White" Font-Bold="False" HorizontalAlign="Center">
                            <Border BorderStyle="Dashed" />
                        </Header>
                        <Cell>
                            <Border BorderStyle="Dashed" />
                        </Cell>
                    </Styles>
                    <Border BorderColor="Silver" BorderStyle="Solid" />
                    <Border BorderStyle="Solid" />
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="dsChiTietHoaDon" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" 
                    SelectCommand="SELECT GPM_ChiTietHoaDon.ID, GPM_ChiTietHoaDon.IDHoaDon, GPM_HangHoa.TenHangHoa, GPM_ChiTietHoaDon.ThanhTien, GPM_ChiTietHoaDon.GiaBan, GPM_ChiTietHoaDon.TenDonViTinh, GPM_ChiTietHoaDon.SoLuong, GPM_ChiTietHoaDon.DoDay FROM GPM_ChiTietHoaDon INNER JOIN GPM_HangHoa ON GPM_ChiTietHoaDon.IDHangHoa = GPM_HangHoa.ID WHERE GPM_ChiTietHoaDon.IDHoaDon = @IDHoaDon">
                     <SelectParameters>
                        <asp:SessionParameter Name="IDHoaDon" SessionField="IDHoaDon" Type="Int32" />
                    </SelectParameters>
                    
                </asp:SqlDataSource>
             </DetailRow>
         </Templates>
         <SettingsPager PageSize="50">
         </SettingsPager>
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings AutoFilterCondition="Contains" ShowFilterRow="True" ShowTitlePanel="True" />
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsCommandButton>
            <ShowAdaptiveDetailButton ButtonType="Image">
            </ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image">
            </HideAdaptiveDetailButton>
            <NewButton>
                <Image IconID="actions_add_16x16" ToolTip="Thêm">
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
            <EditButton>
                <Image IconID="actions_edit_16x16devav" ToolTip="Sửa">
                </Image>
            </EditButton>
            <DeleteButton Text="Hủy">
                <Image IconID="edit_delete_32x32" ToolTip="Hủy hóa đơn">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>
         <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False" />
        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>
        <SettingsSearchPanel Visible="True" />
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Xác nhận hủy Hóa Đơn !!" PopupEditFormCaption="Thông tin" Title="DANH SÁCH HÓA ĐƠN TRONG NGÀY HÔM NAY" EmptyDataRow="Không có dữ liệu hiển thị" SearchPanelEditorNullText="Nhập thông tin cần tìm..." />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="6" Name="chucnang">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Số" FieldName="MaHoaDon" VisibleIndex="0" ReadOnly="True">
                <PropertiesTextEdit>
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Ngày bán" FieldName="NgayBan" VisibleIndex="5">
                <propertiesdateedit displayformatstring="dd/MM/yyyy"></propertiesdateedit>
                <settings autofiltercondition="Contains" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn Caption="Tên khách hàng" FieldName="IDKhachHang" VisibleIndex="1">
                <PropertiesComboBox DataSourceID="dsKhachHang" TextField="TenKhachHang" ValueField="ID">
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tổng tiền" FieldName="TongTien" VisibleIndex="3">
                <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="N0" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Số lượng hàng" FieldName="SoLuongHang" VisibleIndex="2">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn Caption="Công nợ" FieldName="CongNoKhachHang" VisibleIndex="4">
                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
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
<asp:SqlDataSource ID="dsKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenKhachHang] FROM [GPM_KhachHang]"></asp:SqlDataSource>
</asp:Content>
