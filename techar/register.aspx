<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="techar_register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
  <meta charset="utf-8" />
    	<meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

    <title>سیستم ثبت نام</title>
    <script src="../js/jquery.min.js"></script>
    <script src="../boot/js/bootstrap.min.js"></script>
    <link href="../boot/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../cps/register2.css" rel="stylesheet" />
    <link href="../cps/register.css" rel="stylesheet" />
    <script src="../js/JsFarsiCalendar.js"></script>
    <link href="../css/calendar.css" rel="stylesheet" />
    <script>

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return true;

            return false;
        }
    </script>

  <script type = "text/javascript">
      function functionx(evt) {
          if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {

              return false;
          }
      }
     </script>
</head>

<body>
    <form id="form1" runat="server">


   <div class="container register">
                <div class="row">
                    <div class="col-md-3 register-left">
                        <h3 style="font-family:'B Yekan'">خوش آمدید</h3>
                        <p style="font-family:'B Yekan'">آموزگار محترم</p>
                        
                        <!-- Button Hide -->
                        <asp:Button ID="Button1" CssClass="btn-warning fon wit"  runat="server" Text="ویرایش اطلاعات" />
                        
                    </div>
                    <div class="col-md-9 register-right">
                        <ul class="nav nav-tabs nav-justified" id="myTab" role="tablist">
                            <li class="nav-item">
                              
                            </li>
                            <li class="nav-item">
                              
                            </li>
                        </ul>
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <h3 class="register-heading" style="font-family:'B Yekan'">فرم ثبت نام</h3>
                                <div class="row register-form" style="font-family:'B Yekan';text-align:center">

                                                 <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox4" runat="server" class="form-control ali" onkeypress="return isNumberKey(event)"  placeholder="نام و نام خانوادگی" MaxLength="40" TabIndex="1"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                           <asp:TextBox ID="TextBox3" runat="server" class="form-control ali"  onkeypress="return functionx(event)" placeholder="کد ملی" MaxLength="10" TabIndex="3"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <input  name="AnotherDate2" class="form-control ali" placeholder="تاریخ" MaxLength="10" TabIndex="6" onclick="displayDatePicker('AnotherDate2');">
                                        </div>
                             <div class="form-group">
                                 <asp:TextBox ID="TextBox8" runat="server" class="form-control ali" onkeypress="return isNumberKey(event)" placeholder="نام پدر" MaxLength="30" TabIndex="5"></asp:TextBox>
                                            
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                    <div class="form-group">
                                              <asp:TextBox ID="TextBox7" runat="server" class="form-control ali" onkeypress="return functionx(event)" placeholder="سابقه کار به ماه" MaxLength="30" TabIndex="0"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                                <asp:TextBox ID="TextBox6" runat="server" class="form-control ali" onkeypress="return functionx(event)"  placeholder="تلفن همراه" MaxLength="11" TabIndex="2"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="شماره وارد شده معتبر نمی باشد" ForeColor="Red" ValidationExpression="(^(09|9)[1][1-9]\d{7}$)|(^(09|9)[3][12456]\d{7}$)"></asp:RegularExpressionValidator>
                                        </div>

                                      <div class="form-group">
                                             <asp:DropDownList ID="DropDownList2" runat="server" TabIndex="4" class="form-control ali">
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
                                        </div>
                                    
                                        <div class="form-group">
                                              <asp:TextBox ID="TextBox5" Visible="false" runat="server" class="form-control ali" Enabled="false" placeholder="رمز عبور" TextMode="Password" MaxLength="15" TabIndex="8"></asp:TextBox>
                                        </div>
                                        <asp:Button ID="Button2" runat="server" Text="ثبت نام" class="btnRegister" Font-Names="B Yekan" TabIndex="10" OnClick="Button1_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            


        </form>
</body>
    
</html>