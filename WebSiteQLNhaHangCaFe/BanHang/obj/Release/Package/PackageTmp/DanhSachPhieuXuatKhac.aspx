<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="DanhSachPhieuXuatKhac.aspx.cs" Inherits="BanHang.DanhSachPhieuXuatKhac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
         <%--popup chi tiet don hang--%>
     <script type="text/javascript">
         function OnMoreInfoClick(element, key) {
             popup.SetContentUrl("ChiTietPhieuXuatKhac.aspx?IDPhieuXuatKhac=" + key);
             popup.ShowAtElement();
             // alert(key);
         }

    </script>
    <br />
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutItem Caption="" HorizontalAlign="Left">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
    <dx:ASPxButton ID="btnThemPhieuXuatKhac" runat="server" Text="Thêm phiếu xuất khác" HorizontalAlign="Right" VerticalAlign="Middle" PostBackUrl="PhieuXuatKhac.aspx">
        <Image IconID="actions_add_32x32">
        </Image>
       
    </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
           
            <dx:LayoutGroup Caption="Danh sách phiếu xuất khác">
                <Items>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxGridView ID="gridPhieuXuatKhac" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID">
                                    <SettingsPager Mode="ShowAllRecords">
                                    </SettingsPager>
                                    <Settings ShowFilterRow="True" />


                                    <SettingsBehavior ConfirmDelete="True" />
                                    <SettingsCommandButton>
                                        <ShowAdaptiveDetailButton ButtonType="Image">
                                        </ShowAdaptiveDetailButton>
                                        <HideAdaptiveDetailButton ButtonType="Image">
                                        </HideAdaptiveDetailButton>
                                        <DeleteButton ButtonType="Image" RenderMode="Image">
                                            <Image IconID="actions_cancel_16x16" ToolTip="Xóa đơn hàng">
                                            </Image>
                                        </DeleteButton>
                                    </SettingsCommandButton>
                                    <SettingsSearchPanel Visible="True" />
                                    <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" Title="DANH SÁCH PHIẾU XUẤT KHÁC" ConfirmDelete="Bạn chắc chắn muốn xóa?" EmptyDataRow="Danh sách trống." SearchPanelEditorNullText="Nhập thông tin cần tìm..."/>
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Ghi Chú" VisibleIndex="3" FieldName="GhiChu">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Người Lập" VisibleIndex="0" FieldName="IDNhanVien">
                                            <PropertiesComboBox DataSourceID="SqlNhanVien" TextField="TenNguoiDung" ValueField="ID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataDateColumn Caption="Ngày Lập" VisibleIndex="1" FieldName="NgayLapPhieu">
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                                            </PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" VisibleIndex="5" FieldName="NgayCapNhat">
                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                                            </PropertiesDateEdit>
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataButtonEditColumn Caption="Xem Chi Tiết" VisibleIndex="6">
                
                                            <DataItemTemplate>
                                                <a href="javascript:void(0);" onclick="OnMoreInfoClick(this, '<%# Container.KeyValue %>')">Xem </a>
                                            </DataItemTemplate>
                                        </dx:GridViewDataButtonEditColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Lý Do Xuất" FieldName="IDLyDoXuat" VisibleIndex="2">
                                            <PropertiesComboBox DataSourceID="SqlLyDoXuat" TextField="TenTrangThai" ValueField="ID">
                                            </PropertiesComboBox>
                                        </dx:GridViewDataComboBoxColumn>
                                        <dx:GridViewDataComboBoxColumn Caption="Chi Nhánh Lập" FieldName="IDChiNhanh" VisibleIndex="4">
                                            <PropertiesComboBox DataSourceID="SqlChNhanh" TextField="TenChiNhanh" ValueField="ID">
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
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
           
        </Items>
        </dx:ASPxFormLayout>
         <asp:SqlDataSource ID="SqlChNhanh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenChiNhanh] FROM [CF_ChiNhanh]"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlLyDoXuat" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenTrangThai] FROM [CF_TrangThaiPhieuXuatKhac]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlNhanVien" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNguoiDung] FROM [CF_NguoiDung] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    <%--popup chi tiet don hang--%>
     <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1100px"
         Height="600px" FooterText="Thông tin chi tiết đơn đặt hàng"
        HeaderText="Thông tin chi tiết phiếu xuất khác" ClientInstanceName="popup" EnableHierarchyRecreation="True" CloseAction="CloseButton">
    </dx:ASPxPopupControl>
</asp:Content>
