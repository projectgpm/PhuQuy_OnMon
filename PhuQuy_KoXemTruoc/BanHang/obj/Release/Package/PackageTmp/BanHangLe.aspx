﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BanHangLe.aspx.cs" Inherits="BanHang.BanHangLe1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HỆ THỐNG BÁN HÀNG</title>    
    <style>
        @font-face
        {
            font-family: "digital-7";
            src: url('Fonts/digital-7.ttf');
        }        
        .pnl-content
        {
            font-size: 14px;
            padding: 10px;
            text-align: center;
            white-space: normal;
        }            
        .Separator
        {
            height: 10px;
        }
        .canhphai {
            float:right;
            margin-top:-7%;
        }           
    </style>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             chitietbuilInLai.SetContentUrl("ChiTietHoaDonDaIn.aspx?IDHoaDon=" + key);
             chitietbuilInLai.ShowAtElement();
         }
    </script>
    <script type="text/javascript">
        function UpdateGridHeight() {
            sampleGrid.SetHeight(0);

            var containerHeight = ASPxClientUtils.GetDocumentClientHeight();            
            if (document.body.scrollHeight > containerHeight)
                containerHeight = document.body.scrollHeight;
            //sampleGrid.SetHeight(containerHeight - tabSoHoaDon.GetHeight() - topPanel.GetHeight());
            sampleGrid.SetHeight(topPanel.GetHeight() - tabSoHoaDon.GetHeight() - PanelBarcode.GetHeight() - 10);
            //console.log('containerHeight = ' + containerHeight);
            //console.log('tabSoHoaDon.GetHeight() = ' + tabSoHoaDon.GetHeight());
            //console.log('topPanel.GetHeight() = ' + topPanel.GetHeight());
            //console.log(containerHeight - tabSoHoaDon.GetHeight() - topPanel.GetHeight());
        }
        
    </script>
</head>
<body>
    <form id="formBanHangLe" runat="server">    
    
    <dx:ASPxPanel ID="topPanel" ClientInstanceName="topPanel" runat="server" Width="65%" FixedPosition="WindowLeft">
        <PanelCollection>
            <dx:PanelContent ID="TopPanelContent" runat="server" SupportsDisabledAttribute="True">
                <dx:ASPxPanel ID="PanelBarcode" ClientInstanceName="PanelBarcode" runat="server" Width="100%" DefaultButton="btnInsertHang">
                <PanelCollection>
                <dx:PanelContent ID="PanelConTentBarcode" runat="server">
                    <div class="pnl-content"> 
                                     
                        <table width="95%">
                            <tr>
                                <td width="55%">
                                    <asp:Button ID="btnInsertHang" runat="server" OnClick="btnInsertHang_Click" Style="display: none"/>                                                                     
                                    <dx:ASPxComboBox ID="txtBarcode" runat="server" ValueType="System.String" 
                                        DropDownWidth="600" DropDownStyle="DropDown" 
                                        ValueField="ID" 
                                        NullText="Nhập mã hàng hoặc tên hàng hóa......." Width="100%" TextFormatString="{1}"
                                        EnableCallbackMode="true" CallbackPageSize="10" 
                                        OnItemsRequestedByFilterCondition="txtBarcode_ItemsRequestedByFilterCondition"
                                        OnItemRequestedByValue="txtBarcode_ItemRequestedByValue" 
                                        >                                    
                                        <Columns>
                                            <dx:ListBoxColumn FieldName="MaHang" Width="80px" Caption="Mã Hàng" />
                                            <dx:ListBoxColumn FieldName="TenHangHoa" Width="250px" Caption="Tên Hàng Hóa"/>
                                            <dx:ListBoxColumn FieldName="TenDonViTinh" Width="100px" Caption="Đơn Vị Tính"/>
                                        </Columns>
                                        <DropDownButton Visible="False">
                                        </DropDownButton>
                                    </dx:ASPxComboBox>
                                    
                                    <asp:SqlDataSource ID="dsHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" >                                       
                                    </asp:SqlDataSource>
                                    &nbsp; &nbsp
                                     &nbsp; &nbsp
                                </td>
                                <td  width="10%">
                                    &nbsp; &nbsp
                                     &nbsp; &nbsp
                                    <dx:ASPxComboBox ID="cmbChonGia" runat="server" Font-Bold="True" Caption="Bảng giá " ValueType="System.String" DataSourceID="SqlBangGia" SelectedIndex="1" TextField="TenBangGia" ValueField="ID">
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="SqlBangGia" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenBangGia] FROM [GPM_BangGia] WHERE ([DaXoa] = @DaXoa)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    &nbsp;&nbsp;
                                </td>
                                <td  width="15%">
                                    &nbsp; &nbsp
                                    <dx:ASPxCheckBox ID="ckBanLe" runat="server" Font-Bold="True" Text="Bán lẻ"></dx:ASPxCheckBox>
                                    &nbsp;
                                </td>
                                <td width="10%">                            
                                    <dx:ASPxSpinEdit ID="txtSoLuong" ClientInstanceName="txtSoLuong" runat="server" Caption="Số lượng" TabIndex="0"
                                        Font-Bold="True" Number="1" Width="100px" NumberType="Integer">                                    
                                    </dx:ASPxSpinEdit>
                                    
                                </td> 
                            </tr>
                        </table>          
                    </div>
                </dx:PanelContent>
                </PanelCollection>
                </dx:ASPxPanel>
                <dx:ASPxPanel ID="PanelGridHangHoa" ClientInstanceName="PanelGridHangHoa"  runat="server" Width="96%" DefaultButton="btnUpdateGridHang">
                    <Paddings Padding="0px" />
                    <PanelCollection>
                    <dx:PanelContent ID="PanelContentGridHangHoa" runat="server">
                    <table width="100%">
                        <tr>
                            <td width="40px" align="center">
                                <dx:ASPxButton ID="btnUpdateGridHang" ClientInstanceName="btnUpdateGridHang" 
                                    runat="server" ClientVisible="False" 
                                    OnClick="btnUpdateGridHang_Click">                                        
                                </dx:ASPxButton>                                    
                                <dx:ASPxButton ID="btnThemHoaDon" runat="server" RenderMode="Link" 
                                    OnClick="btnThemHoaDon_Click" >
                                    <Image IconID="actions_add_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxTabControl ID="tabControlSoHoaDon" runat="server" ClientInstanceName="tabSoHoaDon" 
                                    EnableTabScrolling="True" TabAlign="Justify" Width="100%"                                         
                                        AutoPostBack="True" 
                                    OnActiveTabChanged="tabControlSoHoaDon_ActiveTabChanged">
                                    <ActiveTabStyle Font-Bold="True" ForeColor="Blue">
                                    </ActiveTabStyle>
                                </dx:ASPxTabControl>
                            </td>
                            <td width="40px" align="center">
                                <dx:ASPxButton ID="btnHuyHoaDon" runat="server" OnClick="btnHuyHoaDon_Click" 
                                    RenderMode="Link">
                                    <Image IconID="actions_close_32x32" ToolTip="Xóa hóa đơn đang tính">
                                    </Image>
                                </dx:ASPxButton>
                            </td>     
                        </tr>                            
                    </table>
                    <dx:ASPxGridView runat="server" Width="100%" ID="gridChiTietHoaDon" 
                        ClientInstanceName="sampleGrid" KeyFieldName="STT"
                        AutoGenerateColumns="False"                      
                        EnableCallBacks="False" >
                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" ShowFooter="True" />
                        <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>                        
                        </SettingsCommandButton>
                        <SettingsText EmptyDataRow="Không có hàng đang thanh toán" />
                        <columns>
                            <dx:GridViewDataTextColumn Caption="STT" FieldName="STT" VisibleIndex="0" 
                                AdaptivePriority="1" Name="STT" Width="50px" >                                    
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mã hàng"  FieldName="MaHang" VisibleIndex="1" AdaptivePriority="1" Width="120px" Visible="False">                                    
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Tên hàng" FieldName="TenHang" VisibleIndex="2" Width="150px">                                    
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="ĐVT" FieldName="DonViTinh" VisibleIndex="3" 
                                AdaptivePriority="1" Width="60px">                                    
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" VisibleIndex="7" Width="80px">
                            <PropertiesSpinEdit DisplayFormatString="g" NumberFormat="Custom"></PropertiesSpinEdit>
                                <DataItemTemplate>
                                    <dx:ASPxSpinEdit ID="txtSoLuongChange" runat="server" Width="100%" 
                                        NumberType="float" Value='<%# Eval("SoLuong") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataButtonEditColumn Caption="Xóa" ShowInCustomizationForm="True" Width="50px" 
                                VisibleIndex="11">
                                <DataItemTemplate>
                                    <dx:ASPxButton ID="BtnXoaHang" runat="server" CommandName="XoaHang"
                                        CommandArgument='<%# Eval("STT") %>' 
                                        onclick="BtnXoaHang_Click" RenderMode="Link">
                                        <Image IconID="actions_cancel_32x32">
                                        </Image>
                                    </dx:ASPxButton>
                                </DataItemTemplate>
                                <CellStyle HorizontalAlign="Center">
                                </CellStyle>
                            </dx:GridViewDataButtonEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Thành tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" UnboundType="Decimal" VisibleIndex="10" Width="100px">
                                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="TK" FieldName="TonKho" ShowInCustomizationForm="True" VisibleIndex="6" Width="40px">
                                <PropertiesSpinEdit DisplayFormatString="N1" NumberFormat="Custom" Width="50px">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" ShowInCustomizationForm="True" VisibleIndex="8" FieldName="DonGia" Width="120px" Name="dongia1">
<PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom"></PropertiesSpinEdit>
                                <DataItemTemplate>
                                    <dx:ASPxSpinEdit ID="txtDonGia" runat="server" Width="100%"  DisplayFormatString="N0"
                                        NumberType="Integer" Value='<%# Eval("DonGia") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" Name="dongia2" ShowInCustomizationForm="True" VisibleIndex="9" Width="120px">
                                <PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Độ Dầy" FieldName="DoDay" Name="doday2" ShowInCustomizationForm="True" VisibleIndex="5" Width="80px">
                                <PropertiesSpinEdit DisplayFormatString="N1" NumberFormat="Custom"></PropertiesSpinEdit>
                                <DataItemTemplate>
                                    <dx:ASPxSpinEdit ID="txtDoDay" runat="server" Width="100%" 
                                        NumberType="float" Value='<%# Eval("DoDay") %>' />
                                </DataItemTemplate>
                            </dx:GridViewDataSpinEditColumn>
                            <dx:GridViewDataSpinEditColumn Caption="Độ Dầy" FieldName="DoDay" Name="doday1" ShowInCustomizationForm="True" VisibleIndex="4" Width="60px">
                                <PropertiesSpinEdit DisplayFormatString="N1" NumberFormat="Custom">
                                </PropertiesSpinEdit>
                            </dx:GridViewDataSpinEditColumn>
                        </columns>                                                  
                        <settingspager pagesize="50" numericbuttoncount="6" Mode="ShowAllRecords" />
                        <TotalSummary>
                            <dx:ASPxSummaryItem DisplayFormat="Tổng tiền: {0:N0}" FieldName="ThanhTien" ShowInColumn="Thành tiền" SummaryType="Sum" />
                            <dx:ASPxSummaryItem DisplayFormat="{0} hàng hóa" FieldName="MaHang" ShowInColumn="Mã hàng" SummaryType="Count" />
                            <dx:ASPxSummaryItem DisplayFormat="Tổng số lượng: {0}" FieldName="SoLuong" ShowInColumn="SoLuong" SummaryType="Sum" />
                        </TotalSummary>      
                        <Styles>
                            <Header Font-Bold="True" HorizontalAlign="Center">
                            </Header>
                            <AlternatingRow Enabled="True">
                            </AlternatingRow>
                            <Footer Font-Bold="True" ForeColor="#0000CC" HorizontalAlign="Right">
                            </Footer>
                        </Styles>
                    </dx:ASPxGridView> 
                </dx:PanelContent>
            </PanelCollection>
            </dx:ASPxPanel>
            </dx:PanelContent>
        </PanelCollection>

    </dx:ASPxPanel><dx:ASPxPanel id="RightPanel" runat="server" fixedposition="WindowRight" Width="35%">
        <PanelCollection>
            <dx:PanelContent ID="PanelContent2" runat="server" SupportsDisabledAttribute="True">
                <div class="pnl-content" style="width: 100%;">
                    <table width="100%">
                        <tr>                            
                            <td align="left" width="50%">                                
                                <dx:ASPxButton ID="btnNhanVien" runat="server" Text="Nhân viên A" 
                                    RenderMode="Link">
                                    <Image IconID="businessobjects_bodetails_32x32">
                                    </Image>
                                </dx:ASPxButton>                                
                            </td>
                            <td align="right" width="50%">
                                 <dx:ASPxButton ID="ASPxButton2" runat="server" OnClick="ASPxButton1_Click" RenderMode="Link" Text="Thêm Khách Hàng">
                                     <Image IconID="actions_newemployee_32x32devav" ToolTip="Thêm khách hàng">
                                     </Image>
                                 </dx:ASPxButton>
                                <dx:ASPxButton ID="btnThoat" runat="server"
                                    RenderMode="Link" Text="Thoát" PostBackUrl="DangXuat.aspx">
                                    <Image IconID="edit_delete_32x32">
                                    </Image>
                                </dx:ASPxButton> 
                            </td>
                        </tr>
                    </table>
                    <div class="Separator">                
                    </div>
                    <table width="100%">                        
                        <tr>
                            <td width="85%">
                                <dx:ASPxComboBox ID="ccbKhachHang" runat="server" ValueType="System.String" 
                                    NullText="Nhập sdt hoặc tên khách hàng trong danh sách." Width="100%" 
                                    DropDownWidth="550px" TextFormatString="{0}" OnItemRequestedByValue="ccbKhachHang_ItemRequestedByValue" OnItemsRequestedByFilterCondition="ccbKhachHang_ItemsRequestedByFilterCondition" AutoPostBack="True" OnSelectedIndexChanged="ccbKhachHang_SelectedIndexChanged"  >
                                     <Columns>
                                        <dx:ListBoxColumn FieldName="TenKhachHang" Width="100%"  Caption="Tên khách hàng"/>
                                         <dx:ListBoxColumn FieldName="DienThoai" Width="100px" Caption="Số điện thoại" />    
                                        <dx:ListBoxColumn FieldName="DiaChi" Width="100px" Caption="Địa chỉ" />
                                                                            
                                    </Columns>
                                </dx:ASPxComboBox>
                                 <asp:SqlDataSource ID="sqlKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" >                                       
                                    </asp:SqlDataSource>
                            </td>
                            <td width="15%" align="right">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <div class="Separator">                
                    </div>
                    <div id="divTabThanhToan">                    
                    <dx:ASPxPageControl ID="pageControlThanhToan" runat="server" Width="100%" 
                        ActiveTabIndex="0">
                        <TabPages>
                            <dx:TabPage Text="Hóa đơn">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl1" runat="server">                                        
                                        <dx:ASPxFormLayout ID="formLayoutThanhToan" runat="server" Width="100%" 
                                            ClientInstanceName="formLayoutThanhToan">
                                            <Items>
                                                <dx:LayoutItem Caption="Số lượng hàng" FieldName="SoLuongHang" Visible="False">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                                            <dx:ASPxTextBox ID="txtSoLuongHang" runat="server" ReadOnly="True" 
                                                            Font-Names="digital-7" Font-Bold="True" Font-Size="40pt" 
                                                                HorizontalAlign="Right" DisplayFormatString="N0">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="TỔNG TIỀN" FieldName="TongTien" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                                            <dx:ASPxTextBox ID="txtTongTien" runat="server" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="40pt" 
                                                                HorizontalAlign="Right" DisplayFormatString="N0" Width="100%">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="GIẢM GIÁ" FieldName="GiamGia" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                                            <dx:ASPxTextBox ID="txtGiamGia" runat="server" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="40pt" 
                                                                HorizontalAlign="Right" DisplayFormatString="N0" Width="100%">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="KHÁCH CẦN TRẢ" FieldName="KhachCanTra" 
                                                    VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                                            <dx:ASPxTextBox ID="txtKhachCanTra" runat="server" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="40pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0" 
                                                                ForeColor="Red">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="KHÁCH THANH TOÁN" VerticalAlign="Middle" FieldName="KhachThanhToan">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                                                            <dx:ASPxTextBox ID="txtKhachThanhToan" runat="server" NullText="0"
                                                                OnTextChanged="txtKhachThanhToan_TextChanged" AutoPostBack="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="40pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="TIỀN TRẢ LẠI" VerticalAlign="Middle">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                                            <dx:ASPxTextBox ID="txtTienThua" runat="server" NullText="0" ReadOnly="True" 
                                                                Font-Names="digital-7" Font-Bold="True" Font-Size="40pt" 
                                                                HorizontalAlign="Right" Width="100%" DisplayFormatString="N0" 
                                                                ForeColor="#0000CC">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                    <CaptionStyle Font-Bold="True">
                                                    </CaptionStyle>
                                                </dx:LayoutItem>
                                            </Items>
                                            <Paddings Padding="0px" />
                                        </dx:ASPxFormLayout>  
                                        <dx:ASPxButton ID="btnThanhToan" runat="server" Text="THANH TOÁN" 
                                            EnableTheming="False" Font-Bold="True" Font-Names="Courier New" 
                                            Font-Size="25pt" Height="50px" BackColor="#33CCFF" Native="True" 
                                            OnClick="btnThanhToan_Click">                                    
                                        </dx:ASPxButton>                                      
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="In Lại Hóa Đơn">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl2" runat="server">
                                        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
                                            <Items>
                                                <dx:LayoutGroup Caption="Tìm kiếm" ColCount="2">
                                                    <Items>
                                                        <dx:LayoutItem Caption="Tìm Kiếm">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer11" runat="server">
                                                                    <dx:ASPxTextBox ID="txtTimKiem" runat="server" Width="100%">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer12" runat="server">
                                                                    <dx:ASPxButton ID="btnTimKiem" runat="server" OnClick="btnTimKiem_Click" Text="Tìm">
                                                                        <Image IconID="zoom_zoom_32x32">
                                                                        </Image>
                                                                    </dx:ASPxButton>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:ASPxFormLayout>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                        <ContentStyle>
                            <Paddings Padding="2px" />
                        </ContentStyle>
                    </dx:ASPxPageControl>
                    </div>
                    <div class="Separator">                
                    </div>                 
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
    
    
    <script type="text/javascript">
        // <![CDATA[
        ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function (s, e) {
            UpdateGridHeight();
        });
        ASPxClientControl.GetControlCollection().BrowserWindowResized.AddHandler(function (s, e) {
            UpdateGridHeight();
        });
        // ]]> 
    </script>   
    
    
    <dx:ASPxPopupControl ID="popupThemKhachHang" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="600px"
         Height="300px"
        HeaderText="Thêm khách hàng" ClientInstanceName="popupThemKhachHang" CloseAction="CloseButton">
         <ContentCollection>
    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2" Width="100%">
        <Items>
            <dx:LayoutItem Caption="Nhóm Khách Hàng(*)" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                        <dx:ASPxComboBox ID="cmbNhomKhachHang" runat="server" DataSourceID="sqkNhomKhachHang" TextField="TenNhomKhachHang" ValueField="ID" Width="100%" SelectedIndex="0">
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="sqkNhomKhachHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhomKhachHang] FROM [GPM_NhomKhachHang] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Tên Khách Hàng(*)" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                        <dx:ASPxTextBox ID="txtTenKhachHang" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Số Điện Thoại" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                        <dx:ASPxTextBox ID="txtSoDienThoai" runat="server" Width =" 100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Địa Chỉ" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer10" runat="server">
                        <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Right">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer16" runat="server">
                        <dx:ASPxButton ID="btnThemKhachHang" runat="server" OnClick="btnThemKhachHang_Click" Text="Thêm">
                            <Image IconID="save_saveto_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer17" runat="server">
                        <dx:ASPxButton ID="btnHuyKhachHang" runat="server" OnClick="btnHuyKhachHang_Click" Text="Hủy">
                            <Image IconID="save_saveandclose_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
  </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
        
        <dx:ASPxPopupControl ID="chitietbuilInLai" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" ClientInstanceName="chitietbuilInLai" PopupVerticalAlign="WindowCenter"  Width="1000px" Height="600px" HeaderText="Chi tiết hóa đơn">
        </dx:ASPxPopupControl>
        <iframe name="PrintingFrame" style="display: block; width:0px; height:0px;"></iframe>
    </form>    
    </body>
</html>
