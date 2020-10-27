<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login_tec.aspx.cs" Inherits="techar_login_tec" %>

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
    <link href="../panele/adminlte.css" rel="stylesheet" />
    <link href="../panele/adminlte.min.css" rel="stylesheet" />
    <link href="../panele/blue.css" rel="stylesheet" />
    <link href="../panele/bootstrap-rtl.min.css" rel="stylesheet" />
    <link href="../panele/custom-style.css" rel="stylesheet" />
    <link href="../panele/persian-datepicker.min.css" rel="stylesheet" />
</head>
<body class="hold-transition login-page">
    <form id="form2" runat="server">
<div class="login-box">
  <div class="login-logo">
    <a href="../../index2.html"><b>پنل کاربری آموزگاران</b></a>
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body login-card-body">
      <p class="login-box-msg">فرم زیر را تکمیل کنید و ورود بزنید</p>
      
        <div class="input-group mb-3">
    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="کد ملی" MaxLength="10"></asp:TextBox>
          <div class="input-group-append">
            <span class="fa fa-code input-group-text"></span>
          </div>
        </div>
        <div class="input-group mb-3">
    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="رمز عبور" MaxLength="15" TextMode="Password"></asp:TextBox>
          <div class="input-group-append">
            <span class="fa fa-lock input-group-text"></span>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="checkbox icheck">
              <label>
                <input type="checkbox"> یاد آوری من
              </label>
            </div>
          </div>
          <!-- /.col -->
          <div class="col-4">
    <asp:Button ID="Button1" runat="server" Text="ورود" class="btn btn-primary btn-block btn-flat" OnClick="btn_Click" />
          </div>
          <!-- /.col -->
        </div>
      

      <div class="social-auth-links text-center mb-3">
        <p>یا</p>
        <a href="register.aspx" class="btn btn-block btn-primary">
          <i class="mr-2"></i> ثبت نام
        </a>
        <a href="#" class="btn btn-block btn-danger">
          <i class="fa fa-google-plus mr-2"></i> ورود با اکانت گوگل
        </a>
      </div>
      <!-- /.social-auth-links -->

      <p class="mb-1">
        <a href="#">رمز عبورم را فراموش کرده ام.</a>
      </p>
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->

<!-- jQuery -->
        <script src="../panele/jquery.min.js"></script>
        <script src="../panele/icheck.min.js"></script>
        <script src="../panele/icheck.js"></script>
        <script src="../panele/bootstrap.bundle.min.js"></script>
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