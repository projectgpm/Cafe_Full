<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="QuanLyHangHoa.aspx.cs" Inherits="BanHang.QuanLyHangHoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
      <script type="text/javascript">
          preventEndEdit_LostFocus_onBarCode = false;
          var listBarCode = [];
          function onBarCode_KeyDown(s, e) {
              var keyCode = ASPxClientUtils.GetKeyCode(e.htmlEvent);
              if (keyCode === ASPx.Key.Esc) {
                  txtBarCode.SetText('');
                  preventEndEdit_LostFocus_onBarCode = true;
              }
              if (keyCode === ASPx.Key.Tab || keyCode === ASPx.Key.Enter) {
                  listBarCode.push(txtBarCode.GetText());
                  tkbListBarCode.AddToken(txtBarCode.GetText());
                  txtBarCode.SetText('');
                  preventEndEdit_LostFocus_onBarCode = true;
              }
          }
          function onBarCode_LostFocus(s, e) {
              if (!preventEndEdit_LostFocus_onBarCode) {
                  tkbListBarCode.AddToken(txtBarCode.GetText());
                  txtBarCode.SetText('');
              }
              preventEndEdit_LostFocus_onBarCode = false;
          }
</script>
    <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="100%" DefaultButton="ASPxButton1">
        <PanelCollection>
        <dx:PanelContent ID="PanelContent2" runat="server">
            <dx:ASPxFormLayout ID="formlayout" runat="server" Width="100%">
                <Items>
                    <dx:LayoutItem Caption="" HorizontalAlign="Left">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer runat="server">
                                <dx:ASPxButton ID="btnThem" runat="server" PostBackUrl="ThemHangHoa.aspx" Text="Thêm Hàng Hóa - Nguyên Liệu" Visible="False">
                                    <Image IconID="actions_add_32x32">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutGroup Caption="Quản lý hàng hóa">
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxGridView ID="gridHangHoa" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridHangHoa_RowDeleting" OnRowInserting="gridHangHoa_RowInserting" OnRowUpdating="gridHangHoa_RowUpdating" OnInitNewRow="gridHangHoa_InitNewRow">
                                            <Templates>
                                                <EditForm>
                                                    <div style="padding: 4px 3px 4px">
                                                        <dx:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors"
                                                            runat="server">
                                                        </dx:ASPxGridViewTemplateReplacement>                    
                                                    </div>
                                                    <div style="padding: 4px 3px 4px">

                                                        <br />
                                                    </div>
                                                    <div style="text-align: right; padding: 2px">
                                                        <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                                                            runat="server">
                                                        </dx:ASPxGridViewTemplateReplacement>
                                                        <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                                                            runat="server">
                                                        </dx:ASPxGridViewTemplateReplacement>
                                                    </div>
                                                </EditForm>
                                                <DetailRow>
                                                    <dx:ASPxGridView ID="gridBarCode" runat="server" AutoGenerateColumns="False" 
                                                        KeyFieldName="ID" oninit="gridBarCode_Init" 
                                                        Width="100%" onrowdeleting="gridBarCode_RowDeleting" 
                                                        onrowinserting="gridBarCode_RowInserting" 
                                                        onrowupdating="gridBarCode_RowUpdating">
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
                                                        <SettingsEditing Mode="PopupEditForm">
                                                         </SettingsEditing>
                                                        <SettingsPopup>
                                                            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
                                                        </SettingsPopup>
                                                         <SettingsBehavior ConfirmDelete="True" />
                                                        <EditFormLayoutProperties>
                                                            <Items>
                                                                <dx:GridViewColumnLayoutItem ColumnName="Tên Nguyên Liệu">
                                                                </dx:GridViewColumnLayoutItem>
                                                                <dx:GridViewColumnLayoutItem ColumnName="Trọng Lượng(g)">
                                                                </dx:GridViewColumnLayoutItem>

                                      
                                                                <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                                                                </dx:EditModeCommandLayoutItem>
                                                            </Items>
                                                        </EditFormLayoutProperties>
                                                        <Columns>

                                                            <dx:GridViewDataComboBoxColumn Caption="Tên Nguyên Liệu" FieldName="IDNguyenLieu" VisibleIndex="1" >
                                                                <PropertiesComboBox DataSourceID="sqlNguyenLieu" TextField="TenNguyenLieu" ValueField="ID">
                                                                    <ValidationSettings SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>
                                                            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" 
                                                                ShowNewButtonInHeader="True" VisibleIndex="5">
                                                            </dx:GridViewCommandColumn>
                                   
                                                             <dx:GridViewDataTextColumn Caption="Trọng Lượng(g)" FieldName="TrongLuong" 
                                                                VisibleIndex="2">
                                                                 <PropertiesTextEdit>
                                                                        <ValidationSettings SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                 </PropertiesTextEdit>
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Mã Nguyên Liệu" FieldName="MaNguyenLieu" 
                                                                VisibleIndex="0" ReadOnly="true">
                                                            </dx:GridViewDataTextColumn>

                                                           <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" VisibleIndex="3">
                                                                <PropertiesComboBox DataSourceID="SqlDVT" TextField="TenDonViTinh" ValueField="ID">
                                                                    <ValidationSettings SetFocusOnError="True">
                                                                        <RequiredField IsRequired="True" />
                                                                    </ValidationSettings>
                                                                </PropertiesComboBox>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataTextColumn Caption="Nhà Cung Cấp" FieldName="NhaCungCap" 
                                                                VisibleIndex="4">
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
                                                </DetailRow>
                                            </Templates>
                                            <SettingsEditing Mode="PopupEditForm">
                                            </SettingsEditing>
                                            <Settings ShowFilterRow="True" />
                                            <SettingsBehavior ConfirmDelete="True" />
                                            <SettingsCommandButton>
                                                <ShowAdaptiveDetailButton ButtonType="Image">
                                                </ShowAdaptiveDetailButton>
                                                <HideAdaptiveDetailButton ButtonType="Image">
                                                </HideAdaptiveDetailButton>
                                                <NewButton>
                                                    <Image IconID="actions_add_16x16" ToolTip="Thêm mới">
                                                    </Image>
                                                </NewButton>
                                                <UpdateButton Text="Lưu">
                                                    <Image IconID="save_save_32x32office2013" ToolTip="Lưu">
                                                    </Image>
                                                </UpdateButton>
                                                <CancelButton Text="Hủy">
                                                    <Image IconID="actions_close_32x32" ToolTip="Hủy thao tác">
                                                    </Image>
                                                </CancelButton>
                                                <EditButton>
                                                    <Image IconID="actions_edit_16x16devav" ToolTip="Sửa">
                                                    </Image>
                                                </EditButton>
                                                <DeleteButton>
                                                    <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                                                    </Image>
                                                </DeleteButton>
                                            </SettingsCommandButton>
                                            <SettingsPopup>
                                                <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
                                            </SettingsPopup>
                                            <SettingsSearchPanel Visible="True" />
                                            <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin hàng hóa" Title="DANH SÁCH HÀNG HÓA" EmptyDataRow="Danh sách trống." SearchPanelEditorNullText="Nhập thông tin cần tìm..." />
                                            <EditFormLayoutProperties>
                                                <Items>
                                                    <dx:GridViewColumnLayoutItem ColumnName="Mã Hàng Hóa">
                                                    </dx:GridViewColumnLayoutItem>
                                                    <dx:GridViewColumnLayoutItem ColumnName="Tên Hàng Hóa">
                                                    </dx:GridViewColumnLayoutItem>
                                                    <dx:GridViewColumnLayoutItem ColumnName="Giá Bán">
                                                    </dx:GridViewColumnLayoutItem>
                                                    <dx:GridViewColumnLayoutItem ColumnName="ĐVT">
                                                    </dx:GridViewColumnLayoutItem>
                                                    <dx:GridViewColumnLayoutItem ColumnName="Nhóm Hàng">
                                                    </dx:GridViewColumnLayoutItem>
                                                    <dx:GridViewColumnLayoutItem ColumnName="Ghi Chú">
                                                    </dx:GridViewColumnLayoutItem>
                                                    <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                                                    </dx:EditModeCommandLayoutItem>
                                                </Items>
                                            </EditFormLayoutProperties>
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="13" Name="iconaction" ShowNewButtonInHeader="True">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn Caption="Mã Hàng Hóa" FieldName="MaHangHoa" ShowInCustomizationForm="True" VisibleIndex="0" ReadOnly="True">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings SetFocusOnError="True">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Tên Hàng Hóa" FieldName="TenHangHoa" VisibleIndex="1">
                                                    <PropertiesTextEdit>
                                                        <ValidationSettings SetFocusOnError="True">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="GhiChu" VisibleIndex="6">
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataSpinEditColumn Caption="Giá Bán" FieldName="GiaBan" VisibleIndex="2">
                                                    <PropertiesSpinEdit DisplayFormatString="N0" DisplayFormatInEditMode="True" NumberFormat="Custom">
                                                        <ValidationSettings SetFocusOnError="True">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesSpinEdit>
                                                    <Settings AutoFilterCondition="Contains" />
                                                </dx:GridViewDataSpinEditColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" VisibleIndex="3">
                                                    <PropertiesComboBox DataSourceID="SqlDVT" TextField="TenDonViTinh" ValueField="ID">
                                                        <ValidationSettings SetFocusOnError="True">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesComboBox>
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="Nhóm Hàng" FieldName="IDNhomHang" VisibleIndex="4">
                                                    <PropertiesComboBox DataSourceID="SqlNhomHang" TextField="TenNhom" ValueField="ID">
                                                        <ValidationSettings SetFocusOnError="True">
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
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
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server"  Text="(*) Ghi chú: phiên bản miễn phí sẽ không quản ký được tồn kho hàng hóa. Vui lòng nâng cấp lên bản PRO để quản lý tồn kho." Font-Italic="True" Font-Bold="True" ForeColor="#FF3300"></dx:ASPxLabel>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            
            <asp:SqlDataSource ID="SqlNhomHang" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNhom], [DaXoa], [IDChiNhanh] FROM [CF_NhomHangHoa] WHERE (([DaXoa] = @DaXoa) AND ([IDChiNhanh] = @IDChiNhanh))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                    <asp:SessionParameter Name="IDChiNhanh" SessionField="IDChiNhanh" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDVT" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh], [IDChiNhanh] FROM [CF_DonViTinh] WHERE (([DaXoa] = @DaXoa) AND ([IDChiNhanh] = @IDChiNhanh))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
                    <asp:SessionParameter Name="IDChiNhanh" SessionField="IDChiNhanh" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
    
    
    </asp:Content>
