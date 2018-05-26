<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="KiemKho.aspx.cs" Inherits="BanHang.KiemKho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    &nbsp;<dx:ASPxFormLayout ID="FormLayout1" runat="server" ColCount="4" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Thông tin phiếu kiểm kho" ColCount="4" ColSpan="4">
                <Items>
                    <dx:LayoutItem Caption="Người Điều Chỉnh">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtNguoiLapPhieu" runat="server" Width="100%" Enabled="False">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ngày Điều Chỉnh">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxDateEdit ID="txtNgayLapPhieu" runat="server" OnInit="txtNgayLapPhieu_Init" DisplayFormatString="dd/MM/yyyy">
                                </dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Chi Nhánh">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="txtChiNhanh" runat="server" Enabled="False" DataSourceID="SqlChiNhanh" TextField="TenChiNhanh" ValueField="ID">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlChiNhanh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenChiNhanh] FROM [CF_ChiNhanh]"></asp:SqlDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Trạng Thái">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server" Width="100%">
                                <dx:ASPxTextBox ID="FormLayout1_E2" runat="server" Enabled="False" Text="Phiếu tạm">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ghi Chú" ColSpan="4">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtGhiChu" runat="server" Width="100%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup Caption="Thông Tin Nguyên Liệu" ColCount="4" ColSpan="4">
                <Items>
                   <dx:LayoutItem Caption="Nguyên Liệu" ColSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                            <dx:ASPxComboBox ID="cmbHangHoa" runat="server" 
                                AutoPostBack="True" OnSelectedIndexChanged="cmbHangHoa_SelectedIndexChanged" 
                                DropDownWidth="750px" DropDownStyle="DropDownList"   TextFormatString="{0} - {1}"
                                EnableCallbackMode="true" Width="80%" 
                                OnItemsRequestedByFilterCondition="cmbHangHoa_ItemsRequestedByFilterCondition"
                                OnItemRequestedByValue="cmbHangHoa_ItemRequestedByValue"
                                ValueField="ID"
                                NullText="Vui lòng chọn nguyên liệu.........."
                                >
                                <Columns>
                                    <dx:ListBoxColumn Caption="Mã Nguyên Liệu" FieldName="MaNguyenLieu" Width="70px" />
                                    <dx:ListBoxColumn Caption="Tên Nguyên Liệu" FieldName="TenNguyenLieu" Width="100%" />
                                   
                                    <dx:ListBoxColumn Caption="ĐVT" FieldName="TenDonViTinh" Width="100px" />          
                                </Columns>
                               
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="dsHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" ></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
             <dx:LayoutGroup ColSpan="4" Caption="Danh Sách Nguyên Liệu" ColCount="4">
                <Items>
                    <dx:LayoutItem Caption="" ColSpan="4">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer14" runat="server">
                                                
                                <dx:ASPxGridView ID="gridDanhSachHangHoa_Temp" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" OnRowDeleting="gridDanhSachHangHoa_Temp_RowDeleting" Width="100%" OnRowUpdating="gridDanhSachHangHoa_Temp_RowUpdating">
                                    <SettingsEditing Mode="Batch">
                                    </SettingsEditing>
                                    <SettingsBehavior ProcessSelectionChangedOnServer="True" ConfirmDelete="True" />
                                    <SettingsCommandButton>
                                        <ShowAdaptiveDetailButton ButtonType="Image">
                                        </ShowAdaptiveDetailButton>
                                        <HideAdaptiveDetailButton ButtonType="Image">
                                        </HideAdaptiveDetailButton>
                                        <DeleteButton ButtonType="Image" RenderMode="Image">
                                            <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                                            </Image>
                                        </DeleteButton>
                                    </SettingsCommandButton>
                                    <SettingsText CommandDelete="Xóa" ConfirmDelete="Bạn có chắc chắn muốn xóa hàng hóa khỏi phiếu kiểm này không??" CommandBatchEditCancel="Hủy thay đổi" CommandBatchEditUpdate="Lưu tất cả" EmptyDataRow="Danh sách trống." />
                                    <Columns>
                                        <dx:GridViewDataComboBoxColumn Caption="Tên Nguyên Liệu" FieldName="IDNguyenLieu" ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                            <PropertiesComboBox DataSourceID="SqlNguyenLieu" TextField="TenNguyenLieu" ValueField="ID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="6">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Tồn Kho" FieldName="TonKho" ShowInCustomizationForm="True" VisibleIndex="3" ReadOnly="True">
<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Chênh Lệch" FieldName="ChenhLech" ShowInCustomizationForm="True" VisibleIndex="5" ReadOnly="True">
<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Thực Tế" FieldName="ThucTe" ShowInCustomizationForm="True" VisibleIndex="4">
<PropertiesSpinEdit DisplayFormatString="g" MinValue="0"></PropertiesSpinEdit>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataTextColumn Caption="Mã Nguyên Liệu" FieldName="MaNguyenLieu" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2">
                                            <PropertiesComboBox DataSourceID="SqlDVT" TextField="TenDonViTinh" ValueField="ID">
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
                                                
                                <asp:SqlDataSource ID="SqlDVT" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [CF_DonViTinh]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlNguyenLieu" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNguyenLieu] FROM [CF_NguyenLieu]"></asp:SqlDataSource>
                                                
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Right" ColSpan="2">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer15" runat="server">
                                <dx:ASPxButton ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click">
                                    <Image IconID="save_saveto_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" ColSpan="2">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer16" runat="server">
                                <dx:ASPxButton ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click">
                                    <Image IconID="save_saveandclose_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <asp:HiddenField ID="IDPhieuKiemKho_Temp" runat="server" />
</asp:Content>
