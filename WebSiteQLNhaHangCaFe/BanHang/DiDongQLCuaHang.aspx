<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiDongQLCuaHang.aspx.cs" Inherits="BanHang.DiDongQLCuaHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
            <Items>
                <dx:LayoutItem Caption="">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton ID="btnLamMoi" runat="server" OnClick="btnLamMoi_Click" Text="Làm mới dữ liệu">
                                <Image IconID="actions_reset2_16x16">
                                </Image>
                            </dx:ASPxButton>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutGroup Caption="Hiện tại">
                    <Items>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="girdHienTai" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <SettingsPager Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsCommandButton>
                                            <ShowAdaptiveDetailButton ButtonType="Image">
                                            </ShowAdaptiveDetailButton>
                                            <HideAdaptiveDetailButton ButtonType="Image">
                                            </HideAdaptiveDetailButton>
                                        </SettingsCommandButton>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Thống kê" FieldName="ThongKe" ShowInCustomizationForm="True" VisibleIndex="0">
                                                <CellStyle Wrap="False">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nội dung" FieldName="NoiDung" ShowInCustomizationForm="True" VisibleIndex="1">
                                                <CellStyle Wrap="False">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Thống kê">
                    <Items>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxGridView ID="girdThongKe" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <SettingsPager Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsCommandButton>
                                            <ShowAdaptiveDetailButton ButtonType="Image">
                                            </ShowAdaptiveDetailButton>
                                            <HideAdaptiveDetailButton ButtonType="Image">
                                            </HideAdaptiveDetailButton>
                                        </SettingsCommandButton>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Thống kê" FieldName="ThongKe" ShowInCustomizationForm="True" VisibleIndex="0">
                                                <CellStyle Wrap="False">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nội dung" FieldName="NoiDung" ShowInCustomizationForm="True" VisibleIndex="1">
                                                <CellStyle Wrap="False">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
                <dx:LayoutGroup Caption="Tùy chọn">
                    <Items>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxDateEdit ID="txtNgayBD" runat="server" DisplayFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxDateEdit ID="txtNgayKT" runat="server" DisplayFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="btnXem" runat="server" OnClick="btnXem_Click" Text="Lịch sử doanh thu">
                                        <Image IconID="data_database_16x16">
                                        </Image>
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                        <dx:ASPxGridView ID="girdTuyChon" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <SettingsPager Mode="ShowAllRecords">
                                        </SettingsPager>
                                        <SettingsCommandButton>
                                            <ShowAdaptiveDetailButton ButtonType="Image">
                                            </ShowAdaptiveDetailButton>
                                            <HideAdaptiveDetailButton ButtonType="Image">
                                            </HideAdaptiveDetailButton>
                                        </SettingsCommandButton>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Thống kê" FieldName="ThongKe" ShowInCustomizationForm="True" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Nội dung" FieldName="NoiDung" ShowInCustomizationForm="True" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
            <SettingsItems HorizontalAlign="Center" />
        </dx:ASPxFormLayout>
    
    </div>
    </form>
</body>
</html>
