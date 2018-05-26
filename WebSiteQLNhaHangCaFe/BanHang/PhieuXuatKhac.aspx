<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="PhieuXuatKhac.aspx.cs" Inherits="BanHang.PhieuXuatKhac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="3" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Thông Tin Phiếu Xuất" ColCount="3" ColSpan="3" RowSpan="3">
                <Items>
                    <dx:LayoutItem Caption="Người Lập Phiếu">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                <dx:ASPxTextBox ID="txtNguoiLapPhieu" runat="server" Enabled="False" Width="100%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ngày Lập Phiếu">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                <dx:ASPxDateEdit ID="cmbNgayLapPhieu" Width="100%" runat="server" DateOnError="Today" DisplayFormatString="dd/MM/yyyy" OnInit="cmbNgayLapPhieu_Init">
                                </dx:ASPxDateEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Lý Do Xuất">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                                <dx:ASPxComboBox ID="cmbLyDoXuat" Width="100%" runat="server" DataSourceID="SqlLyDoXuat" TextField="TenTrangThai" ValueField="ID">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlLyDoXuat" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenTrangThai] FROM [CF_TrangThaiPhieuXuatKhac]"></asp:SqlDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Chi Nhánh Lập">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxComboBox ID="cmbChiNhanh" runat="server"  Width="100%" DataSourceID="SqlChiNhanh" Enabled="False" TextField="TenChiNhanh" ValueField="ID">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="SqlChiNhanh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenChiNhanh] FROM [CF_ChiNhanh]"></asp:SqlDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Ghi Chú" ColSpan="2">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxTextBox ID="txtGhiChu" runat="server" Width="100%">
                                </dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup Caption="Thông Tin Nguyên Liệu" ColCount="3" ColSpan="3" RowSpan="3">
                <Items>
                    <dx:LayoutItem Caption="Nguyên Liệu" ColSpan="2">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                            <dx:ASPxComboBox ID="cmbHangHoa" runat="server" 
                                AutoPostBack="True" OnSelectedIndexChanged="cmbHangHoa_SelectedIndexChanged" 
                                DropDownWidth="750px" DropDownStyle="DropDownList"   TextFormatString="{0} - {1}"
                                EnableCallbackMode="true" Width="100%" 
                                OnItemsRequestedByFilterCondition="cmbHangHoa_ItemsRequestedByFilterCondition"
                                OnItemRequestedByValue="cmbHangHoa_ItemRequestedByValue"
                                ValueField="ID"
                                NullText="Vui lòng chọn nguyên liệu.........."
                                >
                                <Columns>
                                    <dx:ListBoxColumn Caption="Mã Nguyên Liệu" FieldName="MaNguyenLieu" Width="70px" />
                                    <dx:ListBoxColumn Caption="Tên Nguyên Liệu" FieldName="TenNguyenLieu" Width="100%" />
                                    <dx:ListBoxColumn Caption="Giá Mua" FieldName="GiaMua" Width="100px" />   
                                    <dx:ListBoxColumn Caption="ĐVT" FieldName="TenDonViTinh" Width="100px" />          
                                </Columns>
                                 <DropDownButton Visible="False">
                                        </DropDownButton>
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="dsHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" ></asp:SqlDataSource>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                    <dx:LayoutItem Caption="Tồn Kho">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxSpinEdit ID="txtTonKho"  Width="100%" runat="server" Enabled="False">
                                </dx:ASPxSpinEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="ĐVT">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer10" runat="server">
                                <dx:ASPxComboBox ID="cmbDonViTinh" Width="100%" runat="server" DataSourceID="sqlDonViTinh" TextField="TenDonViTinh" ValueField="ID" Enabled="False">
                                </dx:ASPxComboBox>
                                <asp:SqlDataSource ID="sqlDonViTinh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [CF_DonViTinh]">
                                </asp:SqlDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Số Lượng">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                                <dx:ASPxSpinEdit ID="txtSoLuong" Width="100%" runat="server">
                                </dx:ASPxSpinEdit>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Left">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer13" runat="server">
                                <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click">
                                    <Image IconID="actions_add_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup ColSpan="3" Caption="Danh Sách Nguyên Liệu" ColCount="3">
                <Items>
                    <dx:LayoutItem Caption="" ColSpan="3">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer14" runat="server">
                                                
                                

                                <dx:ASPxGridView ID="gridDanhSachHangHoa" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridDanhSachHangHoa_RowDeleting">
                                 <SettingsEditing Mode="PopupEditForm">
                                 </SettingsEditing>
                                 <SettingsBehavior ConfirmDelete="True" />
                                 <SettingsCommandButton>
                                    <ShowAdaptiveDetailButton ButtonType="Image">
                                    </ShowAdaptiveDetailButton>
                                    <HideAdaptiveDetailButton ButtonType="Image">
                                    </HideAdaptiveDetailButton>
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
                                <SettingsText CommandBatchEditCancel="Hủy tất cả" CommandBatchEditUpdate="Lưu tất cả" Title="DANH SÁCH HÀNG HÓA GIÁ THEO CHI NHÁNH" ConfirmDelete="Bạn chắc chắn muốn xóa?" EmptyDataRow="Danh sách trống." />
                                <Columns>
                                    <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="7">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="Mã Nguyên Liệu" FieldName="MaNguyenLieu" ShowInCustomizationForm="True" VisibleIndex="0" ReadOnly="True">
                                    </dx:GridViewDataTextColumn>
<dx:GridViewDataSpinEditColumn FieldName="DonGia" ShowInCustomizationForm="True" Caption="Đơn Giá" VisibleIndex="5" ReadOnly="True">
<PropertiesSpinEdit DisplayFormatString="N0" NumberFormat="Custom"></PropertiesSpinEdit>
</dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataSpinEditColumn Caption="Số Lượng Xuất (g)" FieldName="SoLuongXuat" ShowInCustomizationForm="True" VisibleIndex="4">
<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="Tên Nguyên Liệu" FieldName="IDNguyenLieu" ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                        <PropertiesComboBox DataSourceID="SqlNguyenLieu" TextField="TenNguyenLieu" ValueField="ID">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" ShowInCustomizationForm="True" VisibleIndex="2" ReadOnly="True">
                                        <PropertiesComboBox DataSourceID="SqlDVT" TextField="TenDonViTinh" ValueField="ID">
                                        </PropertiesComboBox>
                                    </dx:GridViewDataComboBoxColumn>

                                    <dx:GridViewDataTextColumn Caption="Thành Tiền" FieldName="ThanhTien" ShowInCustomizationForm="True" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn Caption="Tồn Kho Hiện Tại" FieldName="TonKho" ShowInCustomizationForm="True" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>

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
                                                 <asp:SqlDataSource ID="SqlDVT" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT DISTINCT [ID], [TenDonViTinh] FROM [CF_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                    
                                </SelectParameters>
                            </asp:SqlDataSource>
                                                
                            <asp:SqlDataSource ID="SqlNguyenLieu" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNguyenLieu] FROM [CF_NguyenLieu] WHERE ([DaXoa] = @DaXoa)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Right" ColSpan="2">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer15" runat="server">
                                <dx:ASPxButton ID="btnThemPhieuXuatKhac" runat="server" Text="Lưu" OnClick="btnThemPhieuXuatKhac_Click">
                                    <Image IconID="save_saveto_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer16" runat="server">
                                <dx:ASPxButton ID="btnHuyPhieuXuatKhac" runat="server" Text="Hủy" OnClick="btnHuyPhieuXuatKhac_Click">
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
    <asp:HiddenField ID="IDPhieuXuatKhac_Temp" runat="server" />
</asp:Content>
