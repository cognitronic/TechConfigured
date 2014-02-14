<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="NewCampaign.aspx.cs" Inherits="ISeCommerce.AdminWebsite.Modules.CampaignManager.NewCampaign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <telerik:RadScriptBlock runat="server" ID="rsbTemplate">
        <script type="text/javascript">
            function openRadWindow(id)
            {

                var oWnd = radopen("CampaignViewer.aspx?cid=" + id, "rwViewCampaign");
                oWnd.center();
            }

            function OnClientLoad(editor, args)
            {
                var style = editor.get_contentArea().style;
                style.backgroundImage = "none";
                style.backgroundColor = "white";
                style.color = "black";
            }

        </script>
    </telerik:RadScriptBlock>
    <div class="maincontainerfull" style="border-bottom: solid 1px #dddddd;">
        <div class="maincontent" id="divSubscribers" runat="server" style="margin-bottom: 10px;">
            <div style="float: left; margin-right: 5px;">
                <h3>Select Tags For Campaign</h3>
                <asp:DataList ID="dlTags" 
                runat="server" 
                Width="900px" 
                RepeatColumns="4">
                    <ItemTemplate>
                        <div 
                        style="float: left; 
                        width: 225px; 
                        padding-right: 5px; 
                        padding-top: 5px; 
                        padding-bottom: 5px;">
                            <idea:CheckBox
                            runat="server"
                            AutoPostBack="true"
                            TextAlign="Left"
                            OnCheckedChanged="TagCheckChanged"
                            ID="cbTag"
                            tagid='<%# Eval("ID") %>'
                            Text='<%# Eval("Tag") %>' />
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="margin-top: 10px;">
                <idea:LinkButton
                runat="server"
                ID="lbRecipients">
                </idea:LinkButton>
            </div>
        </div>
    </div>
    <div class="maincontainerfull" id="divBody" runat="server">
        <div class="maincontent">
            <div>
                <div><b>Campaign Name:<span style="font-size: 10px; color: #ff0000;">* Must Be Unique!</span></b></div>
                <idea:TextBox
                runat="server"
                ID="tbTemplateName"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvTemplateName"
                InitialValue=""
                Display="Dynamic"
                ErrorMessage="<br />Please name this template."
                ControlToValidate="tbTemplateName">
                </asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 10px;">
                <div><b>Description:</b></div>
                <idea:TextBox
                runat="server"
                ID="tbDescription"
                TextMode="MultiLine"
                Height="40px"
                Width="600px">
                </idea:TextBox>
            </div>
            <div style="margin-top: 10px;">
                <div><b>Subject of Message:</b></div>
                <idea:TextBox
                runat="server"
                ID="tbSubject"
                Width="600px">
                </idea:TextBox>
                <asp:RequiredFieldValidator
                runat="server"
                ID="rfvSubject"
                InitialValue=""
                Display="Dynamic"
                ErrorMessage="<br />Please enter the subject of the message to be sent."
                ControlToValidate="tbSubject">
                </asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 10px;">
                <div><b>HTML Body of Message:</b></div>
                <telerik:RadEditor
                ID="reCampaignContent"
                Width="100%"
                EnableEmbeddedScripts="true"
                Height="600px"
                OnClientLoad="OnClientLoad"
                ContentFilters="None"
                Skin="Windows7" 
                runat="server">
                    <Content>
                    </Content>
                </telerik:RadEditor>
            </div>
            <br />
            <div runat="server" id="divSentMessages">
                <idea:Label
                runat="server"
                ForeColor="Green"
                ID="lblSentMessage"
                Text="Campaign Sent!!!">
                </idea:Label>
                <br />
            </div>
            <div>
                <span>
                    <asp:Button
                    runat="server"
                    Height="30px"
                    ID="btnSend"
                    ToolTip="Send Campaign."
                    Text="Send Campaign"
                    
                    OnClick="SendClicked" />
                </span>
            </div>
            <br /><br />
        </div>
    </div>

</asp:Content>
