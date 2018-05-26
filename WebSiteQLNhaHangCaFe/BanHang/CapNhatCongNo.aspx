<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="CapNhatCongNo.aspx.cs" Inherits="BanHang.CapNhatCongNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2" Width="20%">
        <Items>
            <dx:LayoutItem Caption="" HorizontalAlign="Left">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxButton ID="ASPxFormLayout2_E2" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật Công Nợ Nhà Cung Cấp">
                            <Image IconID="mail_editcontact_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Left">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxButton ID="ASPxFormLayout2_E3" runat="server" PostBackUrl="ChiTietCongNo.aspx" Text="Chi Tiết Công Nợ">
                            <Image IconID="comments_editcomment_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            
        </Items>
    </dx:ASPxFormLayout>
    <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Danh sách công nợ đã cập nhật">
                <Items>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer11" runat="server">
                                <dx:ASPxGridView ID="gridNhaCungCap" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID">
                                    <SettingsEditing Mode="PopupEditForm">
                                    </SettingsEditing>
                                    <Settings AutoFilterCondition="Contains" ShowFilterRow="True" />
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
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsText CommandCancel="Hủy bỏ thao tác" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Lưu" ConfirmDelete="Bạn có chắc chắn muốn xóa không?. Thao tác này có thể xóa Hàng Hóa thuộc nhà cung cấp!." PopupEditFormCaption="Thông tin nhà cung cấp" Title="DANH SÁCH CÔNG NỢ NHÀ CUNG CẤP" SearchPanelEditorNullText="Nhập thông tin cần tìm...." />
                                    <EditFormLayoutProperties>
                                        <Items>
                                            <dx:GridViewColumnLayoutItem ColumnName="Nhà Cung Cấp" Name="TenNhaCungCap">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Điện Thoại" Name="DienThoai">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Fax" Name="Fax">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Email" Name="Email">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Địa Chỉ" Name="DiaChi">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Người Liên Hệ" Name="NguoiLienHe">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Mã số thuế" Name="MaSoThue">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Lĩnh Vực Kinh Doanh" Name="LinhVucKinhDoanh">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColumnName="Ghi chú" Name="GhiChu">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                                            </dx:EditModeCommandLayoutItem>
                                        </Items>
                                    </EditFormLayoutProperties>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Nhà Cung Cấp" FieldName="TenNhaCungCap" VisibleIndex="0">
                                            <PropertiesTextEdit>
                                                <ValidationSettings>
                                                    <RequiredField IsRequired="True" ErrorText="Không được bỏ trống" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Điện Thoại" FieldName="DienThoai" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Địa Chỉ" FieldName="DiaChi" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Người Liên Hệ" FieldName="NguoiLienHe" VisibleIndex="5">
                                           <%-- <PropertiesTextEdit>
                                                <ValidationSettings>
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </PropertiesTextEdit>--%>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Lĩnh Vực Kinh Doanh" FieldName="LinhVucKinhDoanh" VisibleIndex="7">
                                        </dx:GridViewDataTextColumn>
            
                                        <dx:GridViewDataTextColumn Caption="Ghi chú" FieldName="GhiChu" VisibleIndex="8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Công Nợ" FieldName="CongNo" VisibleIndex="10">
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
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
   <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="700px"
         Height="500px" FooterText="Thông tin chi tiết nhập kho"
        HeaderText="Thông tin cập nhật công nợ" ClientInstanceName="popup" EnableHierarchyRecreation="True">

       <ContentCollection>
<dx:PopupControlContentControl runat="server">
      <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="2" Width="100%">
        <Items>
            <dx:LayoutItem Caption="Chọn Nhà Cung Cấp" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                        <dx:ASPxComboBox ID="cmbNhaCungCap" runat="server" Width="100%" DataSourceID="sqlNhaCungCap" TextField="TenNhaCungCap" ValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="cmbNhaCungCap_SelectedIndexChanged">
                        </dx:ASPxComboBox>
                        <asp:SqlDataSource ID="sqlNhaCungCap" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT * FROM [CF_NhaCungCap] WHERE ([DaXoa] = @DaXoa)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Công Nợ Hiện Tại" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                        <dx:ASPxSpinEdit ID="txtNoHienTai" runat="server" Width="100%" DisplayFormatString="N0" Enabled="False">
                        </dx:ASPxSpinEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Hình Thức Thanh Toán" ColSpan="2" RowSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                        <dx:ASPxComboBox ID="cmbHinhThucThanhToan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbHinhThucThanhToan_SelectedIndexChanged" Width="100%" Enabled="False">
                            <Items>
                                <dx:ListEditItem Text="Công Nợ Giảm Dần" Value="0" />
                                <dx:ListEditItem Text="Theo Phiếu Nhập Kho" Value="1" />
                            </Items>
                        </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Chọn Mã Phiếu" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer4" runat="server">
                        <dx:ASPxComboBox ID="txtMaPhieu" runat="server" Width="100%" Enabled="False" ValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="txtMaPhieu_SelectedIndexChanged">
                             <Columns>
                                    <dx:ListBoxColumn Caption="Mã Phiếu" FieldName="SoDonHang" Width="120px" />
                                    <dx:ListBoxColumn Caption="Tổng Tiền " FieldName="TongTien" Width="100px" />
                                    <dx:ListBoxColumn Caption="Ngày lập phiếu" FieldName="NgayLap" Width="80px" />               
                                </Columns>
                        </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Số Tiền Thanh Toán" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer5" runat="server">
                        <dx:ASPxSpinEdit ID="txtTienThanhToan" runat="server" Width="100%" DisplayFormatString="N0" Enabled="False">
                        </dx:ASPxSpinEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Nhập Số Hóa Đơn" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                        <dx:ASPxTextBox ID="txtNhapSoHoaDon" runat="server" Width="100%" Enabled="False">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Nội Dung" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                        <dx:ASPxTextBox ID="txtNoiDung" runat="server" Width="100%">
                        </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Ngày Thanh Toán" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                        <dx:ASPxDateEdit ID="dateNgayThanhToan" runat="server" Width="100%" DisplayFormatString="dd/MM/yyyy" OnInit="dateNgayThanhToan_Init">
                        </dx:ASPxDateEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Right">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                        <dx:ASPxButton ID="btnCapNhatThanhToan" runat="server" Text="Cập Nhật" OnClick="btnCapNhatThanhToan_Click" >
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer10" runat="server">
                        <dx:ASPxButton ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click">
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
           </dx:PopupControlContentControl>
</ContentCollection>

    </dx:ASPxPopupControl>
</asp:Content>
