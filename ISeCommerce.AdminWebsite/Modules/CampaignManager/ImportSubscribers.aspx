<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ImportSubscribers.aspx.cs" Inherits="ISeCommerce.AdminWebsite.Modules.CampaignManager.ImportSubscribers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="maincontainerfull">
        <div class="maincontent">
            <div style="float: left;">
                <span>Upload a comma separated list (.csv) of email addresses</span><br />
                <telerik:RadUpload
                runat="server"
                ID="ruImport"
                AllowedFileExtensions=".txt,.csv"
                InitialFileInputsCount="1"
                InputSize="1"
                ControlObjectsVisibility="None"
                MaxFileInputsCount="1"
                MaxFileSize="1002400">
                </telerik:RadUpload>
                <div>
                    <asp:Button
                    runat="server"
                    ID="btnImport"
                    Text="Import Subscribers"
                    Height="30px"
                    OnClick="ImportClicked" /><br /><br />
                    <telerik:RadProgressManager  
                    id="Radprogressmanager1" 
                    runat="server" />
                    <telerik:RadProgressArea 
                    id="RadProgressArea1" 
                    Skin="Windows7"
                    runat="server" />
                </div>
            </div>
            <div runat="server" id="divImportLabels" style="float: left; ">
                <div>
                    <span>
                        # Emails Ready For Import:
                    </span>
                    <span>
                        <idea:Label
                        runat="server"
                        ForeColor="Green"
                        ID="lblReadyForImport">
                        </idea:Label>
                    </span>
                </div>
                <div>
                    <span>
                        # Emails Imported:
                    </span>
                    <span>
                        <idea:Label
                        runat="server"
                        ForeColor="#0067B8"
                        ID="lblEmailsImported">
                        </idea:Label>
                    </span>
                </div>
                <div>
                    <span>
                        # Emails Skipped (Invalid or Duplicate):
                    </span>
                    <span>
                        <idea:Label
                        ForeColor="Red"
                        runat="server"
                        ID="lblEmailsSkipped">
                        </idea:Label>
                    </span>
                </div>
            </div>
            <div class="clear"></div>
            <div style="border-top: solid 1px #333333; margin-top: 15px;border-bottom: solid 1px #333333; margin-bottom: 15px;">
                <div style="float: right; width: 400px; margin-top: 65px;">
                    <asp:Button
                    runat="server"
                    Height="30px"
                    ID="btnAddTags"
                    Text="Add Tags To Imported Subscribers"
                    OnClick="AddTagsClicked" />
                </div>
                <div style="float: left;">
                    <h3>Select Subscriber Tags</h3>
                    <asp:DataList ID="dlTags" 
                    runat="server" 
                    RepeatColumns="4">
                        <ItemTemplate>
                            <div 
                            style="float: left; 
                            padding-right: 5px; 
                            margin-right: 20px;
                            padding-top: 5px; 
                            padding-bottom: 5px;">
                                <idea:CheckBox
                                runat="server"
                                AutoPostBack="true"
                                TextAlign="Left"
                                ID="cbTag"
                                tagid='<%# Eval("ID") %>'
                                Text='<%# Eval("Tag") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div><br /><br />
            <div class="clear"></div>
            <div runat="server"
            id="divAddTagsLabel">
                <br />
                <idea:Label
                runat="server"
                ID="lblMessage">
                </idea:Label>
            </div>
            </div>
        </div>
    </div>

</asp:Content>
