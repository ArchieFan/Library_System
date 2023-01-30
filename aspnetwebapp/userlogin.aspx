<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="aspnetwebapp.userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row p-3">
                            <div class="col">
                                <div class="row mb-3">
                                    <label for="TextBox1" class="col-sm-3 col-form-label">Member ID</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <label for="TextBox2" class="col-sm-3 col-form-label">Password</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="d-grid gap-3">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                    <a class="btn btn-primary btn-block btn-lg" href="usersignup.aspx" role="button">Sign Up</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="home.aspx"><< Back to Home</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>
