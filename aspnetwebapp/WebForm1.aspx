<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="aspnetwebapp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
        function ShowPopup() {

            alert(bootstrap.Tooltip.VERSION);
            alert($().jquery);

            //var myModal = new bootstrap.Modal(document.getElementById('myModal'), {
            //    keyboard: false
            //})
            //myModal.toggle();
            //myModal.show();

            //var modalToggle = document.getElementById('toggleMyModal'); // relatedTarget
            //myModal.show(modalToggle);


            //$(document).ready(function () {
            //    // executes when HTML-Document is loaded and DOM is ready
            //    $('#exampleModal').modal('toggle');
            //})

            $(function () {
                $('#exampleModal').modal('toggle');
            });

            $(document).ready(function () {
                $('#myTable').DataTable();
            });
        }
    </script>
    <script type="text/javascript">
        //$(window).on('load', function () {
        //    $('#exampleModal').modal('show');
        //});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="modal fade" id="myModal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Modal title</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>The modal body is where all the text, images, and links go.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
