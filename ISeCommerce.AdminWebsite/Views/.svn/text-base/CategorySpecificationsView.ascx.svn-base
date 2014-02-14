<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorySpecificationsView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.CategorySpecificationsView" %>
<div style="margin-top: 10px;">
    <h4>
        Specifications
    </h4><br />
    <telerik:RadGrid
    runat="server"
    ID="rgSpecifications"
    AllowPaging="True"
    AutoGenerateColumns="false"
    AllowSorting="True" 
    Width="100%"
    GridLines="None" 
    ShowStatusBar="true"
    OnNeedDataSource="SpecificationsNeedDataSource"
    OnItemCommand="SpecificationsItemCommand"
    OnItemDataBound="SpecificationsItemDataBound"
    PageSize="20"
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
                DataField="CanFilterBy" 
                HeaderText="Can Use As A Filter"
                SortExpression="CanFilterBy"
                UniqueName="CanFilterBy">
                    <ItemTemplate>
                        <%# Eval("CanFilterBy")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:CheckBox
                        runat="server"
                        Checked='<%# IdeaSeed.Core.Utils.Utilities.FormatCheckBox(Eval("CanFilterBy"))%>'
                        ID="cbCanFilterBy" />
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn 
                DataField="Name" 
                HeaderText="Name"
                SortExpression="Name"
                UniqueName="Name">
                    <ItemTemplate>
                        <%# Eval("Name")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:TextBox
                        runat="server"
                        Text='<%# Eval("Name")%>'
                        ID="tbName" />
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
                                itemname='<%# Eval("Name") %>'
                                itemid='<%# Eval("ID").ToString() %>'>
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
            <ClientSettings 
            EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
    </telerik:RadGrid>  
</div>

<div style="margin-top: 10px;">
    <h4>
        Specification Values
    </h4><br />
    <telerik:RadGrid
    runat="server"
    ID="rgValues"
    AllowPaging="True"
    AutoGenerateColumns="false"
    AllowSorting="True" 
    Width="100%"
    GridLines="None" 
    ShowStatusBar="true"
    OnNeedDataSource="ValuesNeedDataSource"
    OnItemCommand="ValuesItemCommand"
    OnItemDataBound="ValuesItemDataBound"
    PageSize="20"
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
        NoMasterRecordsText="No values found for selected specification.">
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
                DataField="Value" 
                HeaderText="Value"
                SortExpression="Value"
                UniqueName="Value">
                    <ItemTemplate>
                        <%# Eval("Value")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <idea:TextBox
                        runat="server"
                        Height="100px"
                        Width="400px"
                        TextMode="MultiLine"
                        Text='<%# Eval("Value")%>'
                        ID="tbValue" />
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
                                itemname='<%# Eval("Value") %>'
                                itemid='<%# Eval("ID").ToString() %>'>
                                    <asp:Image
                                    runat="server"
                                    ID="imgEdit"
                                    ImageAlign="AbsMiddle"
                                    ToolTip="Edit Specification Value"
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
<br /><br />