<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="GDEProjectOnlineCertificate.Pages.Account.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>
  .alert {
    display: block;
  }
</style>

	<script type="text/javascript">
        function ShowErrorMessage() {
            $('#btnErrorModal').click();
		}

		function RedirectToProfile() {
            window.location.href = "/Pages/Profile/Profile.aspx";
        }
    </script>
	<br />
	<br />
	<br />
	<br />
 	<div class="dashboard-wrapper">
		<div class="dashboard-ecommerce">
			<div class="container-fluid dashboard-content ">
				<div class="ecommerce-widget">
					<div class="row">
						<div class="col-xl-8 col-lg-12 col-md-12 col-sm-12 col-12">
							<div class="card">
								<h5 class="card-header">Registration</h5>
								<div class="card-body">
									<div class="alert alert-danger col-12" id="divError" runat="server" visible="false">
										<span runat="server" id="spError"></span>
									</div>
									<div class="form-group">
										Id Number/Passport&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-contr">
                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                        <asp:ListItem>Id Number</asp:ListItem>
                                        <asp:ListItem>Passport</asp:ListItem>
                                        </asp:DropDownList>
										</div>
									<div class="form-group">
										Id Number
							<asp:TextBox ID="txtIDNumber" runat="server" CssClass="form-control" placeholder="ID/PassportNumber" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtIdNumber" CssClass="text-danger" ErrorMessage="The ID/PassportNumber field is required." />
									</div>
									<div class="form-group">
										First Name
							<asp:TextBox ID="txtFName" runat="server" CssClass="form-control" placeholder="First Name" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtFName" CssClass="text-danger" ErrorMessage="Last Name field is required." />
									</div>
									<div class="form-group">
										Last Name
							<asp:TextBox ID="txtLName" runat="server" CssClass="form-control" placeholder="Last Name" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtLName" CssClass="text-danger" ErrorMessage="Last Name field is required." />
									</div>
									<div class="form-group">
										Cell Number
							<asp:TextBox ID="txtCell" runat="server" CssClass="form-control" placeholder="Cell Number" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCell" CssClass="text-danger" ErrorMessage="Cell Number field is required." />
									</div>
									<div class="form-group">
										Email Adrress
							<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="Email field is required." />
									</div>
									<div class="form-group">
										Password
							
										<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="The password field is required." />
									</div>
										<div class="form-group">
										Confirm Password
							
										<asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
										<asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword" CssClass="text-danger" ErrorMessage="Comform password field is required." />
									</div>
									<asp:Button ID="btnCreateAcc" OnClick="btnCreate_Click" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Create Account"></asp:Button>
								</div>
                                <asp:Label ID="lblMessage" runat="server" Text="" BackColor="#CC3300"></asp:Label>
								<hr />
								<div class="card-body">
									<div class="form-group mb-0">
										Already have an account?<a href="Login.aspx">Login</a>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
	<!-- Button Confirm Delete modal -->
	<button type="button" class="btn btn-primary" id="btnErrorModal" hidden="hidden" data-toggle="modal" data-target="#ErrorModal">
	</button>
	<!--Start Of Error Modal -->
	<div class="modal fade" id="ErrorModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header alert-danger">
					<h5 class="modal-title" id="errorMessageHeader" runat="server"></h5>
				</div>
				<div class="modal-body">
					<div class="form-row">
						<span id="spErorrMessage" runat="server"></span>
					</div>
					<br />
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-secondary" onclick="RedirectToProfile()">Ok</button>

					<%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Ok</button>--%>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
