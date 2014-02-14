<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserDetailsView.ascx.cs" Inherits="ISeCommerce.AdminWebsite.Views.UserDetailsView" %>
<div style="margin-top: 10px; margin-bottom: 50px;">
    <h3>
        <idea:Label
        runat="server"
        ID="lblViewTitle" />
    </h3><br />
    <h6>
        Maybe some sort of instructions or examples....or something.
    </h6><br />				
    <div class="propertyContainer">
        <div>
            <span>
                Is Active?:
                <idea:CheckBox
                runat="server"
                ID="cbIsActive" />
            </span>
        </div>
        <div>
            <div>Username:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbUsername">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvCategory"
            InitialValue=""
            ErrorMessage="<br/>Please enter a username."
            ControlToValidate="tbUsername"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>First Name:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbFirstName">
            </idea:TextBox>
            <asp:RequiredFieldValidator
            runat="server"
            ID="rfvName"
            InitialValue=""
            ErrorMessage="<br/>Please enter first name."
            ControlToValidate="tbFirstName"
            Display="Dynamic">
                *
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <div>Last Name:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbLastName">
            </idea:TextBox>
        </div>
        <div>
            <div>Email:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbEmail">
            </idea:TextBox>
        </div>
        <div>
            <div>Password:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbPassword">
            </idea:TextBox>
        </div>
        <div>
            <div>Security Question:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbPasswordQuestion">
            </idea:TextBox>
        </div>
        <div>
            <div>Security Answer:</div>
            <idea:TextBox
            runat="server"
            Width="400px"
            ID="tbSecurityAnswer">
            </idea:TextBox>
        </div>
    </div>

    <div class="actionToolBar">
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbSave"
            OnClick="SaveClicked">
                Save 
            </idea:LinkButton>
        </span>&nbsp;
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbCancel"
            OnClick="CancelClicked">
                Cancel
            </idea:LinkButton>
        </span>&nbsp;
        <span>
            <idea:LinkButton
            runat="server"
            CssClass="simplebtn"
            ID="lbDelete"
            OnClick="DeleteClicked">
                Delete
            </idea:LinkButton>
        </span>
    </div>
</div>
