<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="aspnetwebapp.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="images/imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label class="badge rounded-pill bg-success" ID="Label1" runat="server" Text="Your status"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col-md-4">
                                <label>State</label>
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="Select" Value="select" />
                                    <asp:ListItem Text="--England--" Value="--England--" />
                                    <asp:ListItem Text="Avon" Value="Avon" />
                                    <asp:ListItem Text="Bedfordshire" Value="Bedfordshire" />
                                    <asp:ListItem Text="Berkshire" Value="Berkshire" />
                                    <asp:ListItem Text="Bristol" Value="Bristol" />
                                    <asp:ListItem Text="Buckinghamshire" Value="Buckinghamshire" />
                                    <asp:ListItem Text="Cambridgeshire" Value="Cambridgeshire" />
                                    <asp:ListItem Text="Cheshire" Value="Cheshire" />
                                    <asp:ListItem Text="Cleveland" Value="Cleveland" />
                                    <asp:ListItem Text="Cornwall" Value="Cornwall" />
                                    <asp:ListItem Text="Cumbria" Value="Cumbria" />
                                    <asp:ListItem Text="Derbyshire" Value="Derbyshire" />
                                    <asp:ListItem Text="Devon" Value="Devon" />
                                    <asp:ListItem Text="Dorset" Value="Dorset" />
                                    <asp:ListItem Text="Durham" Value="Durham" />
                                    <asp:ListItem Text="East Riding of Yorkshire" Value="East Riding of Yorkshire" />
                                    <asp:ListItem Text="East Sussex" Value="East Sussex" />
                                    <asp:ListItem Text="Essex" Value="Essex" />
                                    <asp:ListItem Text="Gloucestershire" Value="Gloucestershire" />
                                    <asp:ListItem Text="Greater Manchester" Value="Greater Manchester" />
                                    <asp:ListItem Text="Hampshire" Value="Hampshire" />
                                    <asp:ListItem Text="Herefordshire" Value="Herefordshire" />
                                    <asp:ListItem Text="Hertfordshire" Value="Hertfordshire" />
                                    <asp:ListItem Text="Humberside" Value="Humberside" />
                                    <asp:ListItem Text="Isle of Wight" Value="Isle of Wight" />
                                    <asp:ListItem Text="Isles of Scilly" Value="Isles of Scilly" />
                                    <asp:ListItem Text="Kent" Value="Kent" />
                                    <asp:ListItem Text="Lancashire" Value="Lancashire" />
                                    <asp:ListItem Text="Leicestershire" Value="Leicestershire" />
                                    <asp:ListItem Text="Lincolnshire" Value="Lincolnshire" />
                                    <asp:ListItem Text="London" Value="London" />
                                    <asp:ListItem Text="Merseyside" Value="Merseyside" />
                                    <asp:ListItem Text="Middlesex" Value="Middlesex" />
                                    <asp:ListItem Text="Norfolk" Value="Norfolk" />
                                    <asp:ListItem Text="North Yorkshire" Value="North Yorkshire" />
                                    <asp:ListItem Text="Northamptonshire" Value="Northamptonshire" />
                                    <asp:ListItem Text="Northumberland" Value="Northumberland" />
                                    <asp:ListItem Text="Nottinghamshire" Value="Nottinghamshire" />
                                    <asp:ListItem Text="Oxfordshire" Value="Oxfordshire" />
                                    <asp:ListItem Text="Rutland" Value="Rutland" />
                                    <asp:ListItem Text="Shropshire" Value="Shropshire" />
                                    <asp:ListItem Text="Somerset" Value="Somerset" />
                                    <asp:ListItem Text="South Yorkshire" Value="South Yorkshire" />
                                    <asp:ListItem Text="Staffordshire" Value="Staffordshire" />
                                    <asp:ListItem Text="Suffolk" Value="Suffolk" />
                                    <asp:ListItem Text="Surrey" Value="Surrey" />
                                    <asp:ListItem Text="Tyne and Wear" Value="Tyne and Wear" />
                                    <asp:ListItem Text="Warwickshire" Value="Warwickshire" />
                                    <asp:ListItem Text="West Midlands" Value="West Midlands" />
                                    <asp:ListItem Text="West Sussex" Value="West Sussex" />
                                    <asp:ListItem Text="West Yorkshire" Value="West Yorkshire" />
                                    <asp:ListItem Text="Wiltshire" Value="Wiltshire" />
                                    <asp:ListItem Text="Worcestershire" Value="Worcestershire" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>PostCode</label>
                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="PostCode"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <label>Full Address</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <center>
                                    <span class="badge rounded-pill bg-primary">Login Credentials</span>
                                </center>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="**********" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <label>New Password</label>
                                <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <div class="d-grid gap-2">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="home.aspx"><< Back to Home</a><br>
                <br>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="images/imgs/books1.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    <asp:Label class="badge rounded-pill bg-info" ID="Label2" runat="server" Text="your books info"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
