<%@ Page Language="C#" AutoEventWireup="true" CodeFile="online.aspx.cs" Inherits="pages_panel_online" %>

<!DOCTYPE html>
<html>
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>آزمون</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../panel2/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../panel2/adminlte.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="../../panel2/blue.css">
     
  <!-- Morris chart -->
  <link rel="stylesheet" href="../../panel2/morris.css">
  <!-- jvectormap -->
  <link rel="stylesheet" href="../../panel2/jquery-jvectormap-1.2.2.css">
  <!-- Date Picker -->
  <link rel="stylesheet" href="../../panel2/datepicker3.css">
  <!-- Daterange picker -->
  <link rel="stylesheet" href="../../panel2/daterangepicker-bs3.css">
  <!-- bootstrap wysihtml5 - text editor -->
  <link rel="stylesheet" href="../../panel2/bootstrap3-wysihtml5.min.css">
  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
  <!-- bootstrap rtl -->
  <link rel="stylesheet" href="../../panel2/bootstrap-rtl.min.css">
  <!-- template rtl version -->
  <link rel="stylesheet" href="../../panel2/custom-style.css">
    <link href="../../cps/register2.css" rel="stylesheet" />
    <script src="../../js/JsFarsiCalendar.js"></script>
    <link href="../../css/calendar.css" rel="stylesheet" />
</head>
<body class="hold-transition sidebar-mini">
    <form id="form2" runat="server">
<div class="wrapper">

  <!-- Navbar -->
  <nav class="main-header navbar navbar-expand bg-white navbar-light border-bottom">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#"><i class="fa fa-bars"></i></a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="paneladmin.aspx" class="nav-link">خانه</a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="#" class="nav-link">جستجو</a>
      </li>
    </ul>

    <!-- SEARCH FORM -->
   
      <div class="input-group input-group-sm">
          <asp:TextBox ID="TextBox1" class="form-control form-control-navbar fon cen" runat="server" placeholder="جستجو بر اساس کد آزمون یا نام آزمون"></asp:TextBox>
          &nbsp;
        <div class="input-group-append">
            <asp:Button ID="Button1" class="btn btn-primary active" OnClick="Button1_Click1"  runat="server" Text="جستجو"/>
        </div>
      </div>
  
      
    <!-- Right navbar links -->
    <ul class="navbar-nav mr-auto">

      <li class="nav-item">
        <a class="nav-link" data-widget="control-sidebar" data-slide="true" href="#"><i
                class="fa fa-th-large"></i></a>
      </li>
    </ul>
  </nav>
  <!-- /.navbar -->

  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <a href="#" class="brand-link">

      <span class="brand-text font-weight-light">مدیر سیستم</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar" style="direction: ltr">
      <div style="direction: rtl">
        <!-- Sidebar user panel (optional) -->
        <div class="user-panel mt-3 pb-3 mb-3 d-flex">
          <div class="info">
            <a href="#" class="d-block">آزمون</a>
          </div>
        </div>

        <!-- Sidebar Menu -->
        <nav class="mt-2">
          <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
            <!-- Add icons to the links using the .nav-icon class
                 with font-awesome or any other icon font library -->
            <li class="nav-item has-treeview menu-open">
              <a href="#" class="nav-link active">
                <i class="nav-icon fa fa-dashboard"></i>
                <p>
                  آزمون آنلاین
                  <i class="right fa fa-angle-left"></i>
                </p>
              </a>
              <ul class="nav nav-treeview">
                <li class="nav-item">
                  <a href="#" class="nav-link">
                    <i class="fa fa-circle-o nav-icon"></i>
                    <p>ثبت آزمون</p>
                  </a>
                </li>
              </ul>
            </li>
        </nav>
        <!-- /.sidebar-menu -->
      </div>
    </div>
    <!-- /.sidebar -->
  </aside>
</div>
        
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark fon">مدیریت آزمون</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-left">
              
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>

<section class="content">
     
          <div class="input-group input-group-sm">
          <asp:TextBox ID="TextBox2" class ="form-control btn-group ali fon rdx" placeholder="کد آزمون" runat="server"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;
          <asp:TextBox ID="TextBox3" class ="form-control btn-group ali fon rdx" placeholder="نام آزمون" runat="server"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;
           <asp:TextBox ID="TextBox4" class ="form-control btn-group ali fon rdx" placeholder="تعداد سوالات آزمون" runat="server"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;
              <input  name="AnotherDate2" class="form-control btn-group ali fon rdx"  placeholder="تاریخ ثبت" MaxLength="10"  onclick="displayDatePicker('AnotherDate2');">
               &nbsp;&nbsp;&nbsp;
              
              </div>
          <br />
              <div class="input-group input-group-sm">
                                <asp:DropDownList ID="DropDownList3" runat="server" TabIndex="4" class="form-control ali fon">
                                                      <asp:ListItem Enabled="true" Text="انتخاب پایه تحصیلی" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="پایه پیش دبستانی" Value="پیش دبستانی"></asp:ListItem>
                                                        <asp:ListItem Text="پایه اول" Value="اول"></asp:ListItem>
                                                         <asp:ListItem Text="پایه دوم" Value="دوم"></asp:ListItem>
                                                         <asp:ListItem Text="پایه سوم" Value="سوم"></asp:ListItem>
                                                         <asp:ListItem Text="پایه چهارم" Value="چهارم"></asp:ListItem>
                                                         <asp:ListItem Text="پایه پنجم" Value="پنجم"></asp:ListItem>
                                                 <asp:ListItem Text="پایه ششم" Value="ششم"></asp:ListItem>
                                                 <asp:ListItem Text="پایه هفتم" Value="هفتم"></asp:ListItem>
                                                 <asp:ListItem Text="پایه هشتم" Value="هشتم"></asp:ListItem>
                                                 <asp:ListItem Text="پایه نهم" Value="نهم"></asp:ListItem>
                                                 <asp:ListItem Text="پایه دهم" Value="دهم"></asp:ListItem>
                                                 <asp:ListItem Text="یازدهم" Value="یازده"></asp:ListItem>
                                                 <asp:ListItem Text="پایه دوازدهم" Value="دوازده"></asp:ListItem>
                                                </asp:DropDownList>
                                           &nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="DropDownList1" runat="server" TabIndex="4" class="form-control ali fon">
                                                      <asp:ListItem Enabled="true" Text="نوع آزمون" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="چهارگزینه" Value="چهارگزینه"></asp:ListItem>
                                                        <asp:ListItem Text="تشریحی" Value="تشریحی"></asp:ListItem>
                                                         <asp:ListItem Text="هوش" Value="هوش"></asp:ListItem>
                                                </asp:DropDownList>
               &nbsp;&nbsp;&nbsp;
           <asp:TextBox ID="TextBox7" class ="form-control btn-group ali fon rdx" placeholder="مدت زمان آزمون" runat="server"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;
           <asp:TextBox ID="TextBox5" class ="form-control btn-group ali fon rdx" placeholder="حداقل نمره قبولی" runat="server"></asp:TextBox>   
              </div>
        <br />
    <div class="input-group input-group-sm">
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" class="btn btn-success fon"  Text="ثبت آزمون" />
        <//div>
        <hr style="width:100%;border-top: 1px solid #808080;"/>
  
  <asp:GridView ID="GridView3" runat="server"
    CssClass="table table-hover table-striped fon w1"  GridLines="None" 
    AutoGenerateColumns="False">
                <Columns>
                    
        <asp:BoundField DataField="code" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="کد آزمون">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle ></ItemStyle>
                    </asp:BoundField>
        <asp:BoundField DataField="name_az" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="نام آزمون" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    </asp:BoundField>

  <asp:BoundField DataField="tad" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="تعداد سوالات" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>

        <asp:BoundField DataField="dat" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="تاریخ ثبت" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>

    <asp:BoundField DataField="pay_az" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="پایه تحصیلی" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>


   <asp:BoundField DataField="typ_az" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="نوع آزمون" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>

   <asp:BoundField DataField="tim_az" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="مدت زمان" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>

     <asp:BoundField DataField="typ" ItemStyle-CssClass="a12" HeaderStyle-HorizontalAlign="Center" HeaderText="وضعیت" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>

     <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  HeaderText="مجوز">
                <ItemTemplate>
                    <asp:LinkButton ID="updateun" OnClick="update_un" runat="server" CommandArgument='<%# Eval("Id") %>'>صدور مجوز</asp:LinkButton>
                </ItemTemplate>
       
           </asp:TemplateField>

       <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  HeaderText="لغو مجوز">
                <ItemTemplate>
                    <asp:LinkButton ID="updateune" OnClick="updateun_Click" runat="server" CommandArgument='<%# Eval("Id") %>'>لغو مجوز</asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateField>

      <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Red">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdelete" OnClick="lnkdelete_Click"  runat="server"  CssClass="fon" ForeColor="Red"  CommandArgument='<%# Eval("Id") %>'>حذف</asp:LinkButton>
                </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" ForeColor="Red"></HeaderStyle>
       
           </asp:TemplateField>

   <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Red">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdeletery" OnClick="lnkdeletery_Click"  runat="server" ForeColor="YellowGreen"  CssClass="fon" CommandArgument='<%# Eval("code") + "," + Eval("typ_az") %>'>ثبت سوالات آزمون</asp:LinkButton>
                </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" ForeColor="Red"></HeaderStyle>
       
           </asp:TemplateField>

    <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Red">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdeleteryT" OnClick="lnkdeleteryT_Click"   runat="server" ForeColor="#0000ff"  CssClass="fon" CommandArgument='<%# Eval("code") + "," + Eval("typ_az") + "," + Eval("pay_az")+ "," + Eval("name_az")%>'>نتیجه آزمون</asp:LinkButton>
                </ItemTemplate>
<HeaderStyle HorizontalAlign="Center" ForeColor="Red"></HeaderStyle>
       
           </asp:TemplateField>


         </Columns>

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:GridView>

    </section>
</div>
        
  <aside class="control-sidebar control-sidebar-dark">
    <!-- Control sidebar content goes here -->
  </aside>

<!-- jQuery -->
<script src="../../panel2/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
    $.widget.bridge('uibutton', $.ui.button)
</script>
<!-- Bootstrap 4 -->
<script src="../../panel2/bootstrap.bundle.min.js"></script>
<!-- Morris.js charts -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
<script src="../../panel2/morris.min.js"></script>
<!-- Sparkline -->
<script src="../../panel2/jquery-jvectormap-1.2.2.min.js"></script>
<!-- jvectormap -->
<script src="../../panel2/jquery-jvectormap-1.2.2.min.js"></script>
<script src="../../panel2/jquery-jvectormap-world-mill-en.js"></script>
<!-- jQuery Knob Chart -->
<script src="../../panel2/jquery.knob.js"></script>
<!-- daterangepicker -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.2/moment.min.js"></script>
<script src="../../panel2/daterangepicker.js"></script>
<!-- datepicker -->
<script src="../../panel2/bootstrap-datepicker.js"></script>
<!-- Bootstrap WYSIHTML5 -->
<script src="../../panel2/bootstrap3-wysihtml5.all.min.js"></script>
<!-- Slimscroll -->
<script src="../../panel2/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="../../panel2/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="../../panel2/adminlte.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="../../dist/js/pages/dashboard.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../../panel2/demo.js"></script>
        </form>
</body>
</html>