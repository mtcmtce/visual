<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login_log.aspx.cs"  Inherits="pages_panel_login_log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>ورود به صفحه کاربری</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
    <link href="../../panele/adminlte.css" rel="stylesheet" />
    <link href="../../panele/adminlte.min.css" rel="stylesheet" />
    
    <link href="../../panele/blue.css" rel="stylesheet" />
    <link href="../../panele/bootstrap-rtl.min.css" rel="stylesheet" />
    <link href="../../panele/custom-style.css" rel="stylesheet" />
    <link href="../../panele/persian-datepicker.min.css" rel="stylesheet" />
    <link href="../../cps/register2.css" rel="stylesheet" />
    <link href="../../cps/register.css" rel="stylesheet" />
</head>
<body class="hold-transition login-page" style="background-image: url(/images/ba.jpg);">
    <form id="form2" runat="server">
<div class="login-box">
  <div class="login-logo">
    <a href="#" class="fon cowit"><b style="color:white">مدیر سیستم</b></a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg fon">مدیر سیستم - اصلی</p>
      
        <div class="input-group mb-3">
    <asp:TextBox ID="TextBox1" runat="server" class="form-control fon cen" placeholder="کد ملی" MaxLength="10"></asp:TextBox>
          <div class="input-group-append">
            <span class="fa fa-code input-group-text"></span>
          </div>
        </div>
        <div class="input-group mb-3">
    <asp:TextBox ID="TextBox2" runat="server" class="form-control fon cen" placeholder="رمز عبور" MaxLength="15" TextMode="Password"></asp:TextBox>
          <div class="input-group-append">
            <span class="fa fa-lock input-group-text"></span>
          </div>
        </div>
        <div class="row">
          <!-- /.col -->
          <div class="col-4">
    <asp:Button ID="Button1" runat="server" Text="ورود" class="btn btn-primary btn-block btn-primary fon" OnClick="Button1_Click" />
          </div>
          <!-- /.col -->
        </div>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->

<!-- jQuery -->
        <script src="../../panele/jquery.min.js"></script>
        <script src="../../panele/icheck.min.js"></script>
        <script src="../../panele/icheck.js"></script>
        <script src="../../panele/bootstrap.bundle.min.js"></script>
<script>
    $(function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        })
    })
</script>
        </form>
</body>
</html>