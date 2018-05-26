<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="QuanLyCuaHang.aspx.cs" Inherits="BanHang.QuanLyCuaHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Thống kê bán hàng trong ngày">
                <Items>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                <dx:ASPxGridView ID="gridDanhSachBan" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%">
                                    <SettingsPager Visible="False">
                                    </SettingsPager>
                                    <SettingsEditing Mode="PopupEditForm">
                                    </SettingsEditing>
       
       
                            <SettingsCommandButton>
                            <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

                            <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
                            </SettingsCommandButton>

       
                                    <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin danh mục thuế" Title="DANH SÁCH LỊCH SỬ TRUY CẬP HỆ THỐNG" EmptyDataRow="Danh sách trống." SearchPanelEditorNullText="Nhập thông tin cần tìm..." />
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Bàn sử dụng" FieldName="SoBanSuDung" VisibleIndex="0">
                                            <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="{0:#,#} bàn">
                                            </PropertiesTextEdit>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Tổng tiền" FieldName="TongTien" ShowInCustomizationForm="True" VisibleIndex="3">
                                            <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="{0:N0} VNĐ" NumberFormat="Custom">
                                            </PropertiesSpinEdit>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Lợi nhuận" FieldName="LoiNhuan" ShowInCustomizationForm="True" VisibleIndex="5">
                                            <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="{0:N0} VNĐ" NumberFormat="Custom">
                                            </PropertiesSpinEdit>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataSpinEditColumn>
                                        <dx:GridViewDataSpinEditColumn Caption="Giảm giá" FieldName="GiamGia" ShowInCustomizationForm="True" VisibleIndex="4">
                                            <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="{0:N0} VNĐ" NumberFormat="Custom">
                                            </PropertiesSpinEdit>
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
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
</asp:Content>
