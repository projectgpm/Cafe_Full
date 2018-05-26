<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="TheKho.aspx.cs" Inherits="BanHang.TheKho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Lịch sử kho">
                <Items>
                    <dx:LayoutItem Caption="">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                <dx:ASPxGridView ID="gridLichSuKho" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="ID">
                                  <Settings AutoFilterCondition="Contains" ShowFilterRow="True" />
                                <SettingsEditing Mode="PopupEditForm">
                                </SettingsEditing>
                                 <Settings ShowFilterRow="True" />
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
                                        <Image IconID="save_save_32x32office2013">
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
                                        <Image IconID="actions_cancel_16x16">
                                        </Image>
                                    </DeleteButton>
                                </SettingsCommandButton>
                                <SettingsPopup>
                                    <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="True" />
                                </SettingsPopup>
                                 <SettingsSearchPanel Visible="True" />
                                <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin danh mục combo" Title="DANH SÁCH LỊCH SỬ THAY ĐỔI GIÁ" EmptyDataRow="Danh sách trống." SearchPanelEditorNullText="Nhập thông tin cần tìm..." />
                                  <EditFormLayoutProperties ColCount="2">
                                  </EditFormLayoutProperties>
                                <Columns>
                                    <dx:GridViewDataSpinEditColumn Caption="Số lượng trước" VisibleIndex="5" FieldName="SLCu">
                                        <PropertiesSpinEdit DisplayFormatString="{0:#,#} đ" NumberFormat="Custom">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataTextColumn Caption="Mã Hàng" FieldName="MaHangHoa" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn Caption="Ngày Thay Đổi" FieldName="NgayThayDoi" VisibleIndex="8">
                                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                                        </PropertiesDateEdit>
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataSpinEditColumn Caption="Số lượng sau" FieldName="SLMoi" VisibleIndex="6">
                                        <PropertiesSpinEdit DisplayFormatString="{0:#,#} đ" NumberFormat="Custom">
                                        </PropertiesSpinEdit>
                                    </dx:GridViewDataSpinEditColumn>
                                    <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Đơn Vị Tính" FieldName="TenDonViTinh" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Người dùng" FieldName="TenNguoiDung" ShowInCustomizationForm="True" VisibleIndex="0">
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
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
</asp:Content>
