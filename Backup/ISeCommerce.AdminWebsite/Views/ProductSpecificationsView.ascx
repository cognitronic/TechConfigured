<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSpecificationsView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.ProductSpecificationsView" %>
<div style="margin-top: 10px; margin-bottom: 50px;">
    <h4>
        <idea:Label
        runat="server"
        ID="lblViewTitle" />
    </h4><br />
    <telerik:RadGrid
    runat="server"
    ID="rgList"
    AllowPaging="True"
    AutoGenerateColumns="false"
    AllowSorting="True" 
    Width="100%"
    GridLines="None" 
    ShowStatusBar="true"
    OnNeedDataSource="NeedDataSource"
    OnItemCommand="ItemCommand"
    OnItemDataBound="ItemDataBound"
    ShowFooter="true"
    EnableEmbeddedSkins="true"
    Skin="Default">
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <MasterTableView 
        DataKeyNames="ID"
        CommandItemDisplay="Top"
        ItemStyle-VerticalAlign="Top"
        AlternatingItemStyle-VerticalAlign="Top"
        EnableNoRecordsTemplate="true"
        NoMasterRecordsText="No specifications found.">
            <Columns>
                <telerik:GridTemplateColumn 
                DataField="ID" 
                HeaderText="ID" 
                SortExpression="ID"
                UniqueName="ID">
                    <ItemTemplate>
                        <%# Eval("ID")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="DisplayOnPublicSite" 
                HeaderText="Display On Public Site" 
                SortExpression="DisplayOnPublicSite"
                UniqueName="DisplayOnPublicSite">
                    <ItemTemplate>
                        <%# Eval("DisplayOnPublicSite")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:CheckBox
                        runat="server"
                        ID="cbDisplayOnPublicSite"
                        Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("DisplayOnPublicSite")) %>' />
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="SpecificationValue.SpecificationProperty.Name" 
                HeaderText="Property"
                HeaderStyle-Width="100px" 
                SortExpression="SpecificationValue.SpecificationProperty.Name"
                UniqueName="SpecificationValue.SpecificationProperty.Name">
                    <ItemTemplate>
                        <%# Eval("SpecificationValue.SpecificationProperty.Name")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:ProductCategorySpecificationsDDL
                        runat="server"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="SpecificationSelectedIndexChanged"
                        ID="ddlSpecificationProperties">
                        </idea:ProductCategorySpecificationsDDL>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn
                DataField="SpecificationValue.Value" 
                HeaderText="Value" 
                HeaderStyle-Width="350px" 
                SortExpression="SpecificationValue.Value"
                UniqueName="SpecificationValue.Value">
                    <ItemTemplate>
                        <%# Eval("SpecificationValue.Value")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:ProductSpecificationValuesDDL
                        runat="server"
                        ID="ddlValues">
                        </idea:ProductSpecificationValuesDDL>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn
                HeaderStyle-Width="75px">
                    <ItemTemplate>
                        <div class="actionContainer">
                            <span>
                                <idea:LinkButton
                                runat="server"
                                ID="lbEdit"
                                CssClass="blueLink"
                                CommandName="Edit"
                                itemname='<%# Eval("ProductCategorySpecificationPropertyValueID") %>'
                                itemid='<%# Eval("id").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ImageAlign="AbsMiddle"
                                    ToolTip="Edit Specification"
                                    ImageUrl="~/Images/pencil.png" />
                                    Edit
                                </idea:LinkButton>&nbsp;
                            </span>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <PagerStyle Mode="NextPrevAndNumeric" 
            AlwaysVisible="false" 
            Position="Bottom" />
        </MasterTableView>
    </telerik:RadGrid>  
</div>
<div class="clear"></div>