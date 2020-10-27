<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html dir="rtl">
<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=Edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="keywords" content="">
	<meta name="description" content="">
	<!-- SITE TITLE -->
	<title>اندیشه جهانی</title>

	<!-- STYLESHEETS -->
	<link rel="stylesheet" href="css/bootstrap.min.css">
	<link rel="stylesheet" href="css/font-awesome.min.css">
	<link rel="stylesheet" href="css/templatemo-style.css">
	<link href='//fonts.googleapis.com/css?family=Raleway:400,300,600,700' rel='stylesheet' type='text/css'>
<!-- 

Ultra Profile

https://templatemo.com/tm-464-ultra-profile

-->
</head>
<body data-spy="scroll" data-target="#rock-navigation">
    <form id="form1" runat="server">
	<!-- START NAVIGATION -->
	<div class="navbar navbar-default bs-dos-nav navbar-fixed-top success" role="navigation">
		<div class="container">

			<div class="navbar-header">
				<button class="navbar-toggle" data-toggle="collapse" data-target="#rock-navigation">
					<span class="icon icon-bar"></span>
					<span class="icon icon-bar"></span>
					<span class="icon icon-bar"></span>
				</button>
				<a href="#" class="navbar-brand" style="font-family:'B Yekan';color:#0094ff">اندیشه جهانی</a>
			</div>
			<nav class="collapse navbar-collapse" id="rock-navigation">
				<ul class="nav navbar-nav navbar-right main-navigation text-uppercase" style="font-family:'B Yekan'">
					<li><a href="#" class="smoothScroll">درباره ما</a></li>
					<li><a href="#" class="smoothScroll">مشاوره</a></li>
                    <li><a href="#" class="smoothScroll">استعداد یابی</a></li>
                    <li><a href="#" class="smoothScroll">مسابقات علمی</a></li>
					<li><a href="#" class="smoothScroll">فروشگاه</a></li>
                    <li><a href="pages/panel/login_cons.aspx" class="smoothScroll">سامانه مشاورین</a></li>
					<li><a href="student/login_student.aspx" class="smoothScroll">سامانه دانش آموزی</a></li>
					<li><a href="#" class="smoothScroll">خانه</a></li>
				</ul>
			</nav>

		</div>
	</div>
	<!-- END NAVIGATION -->

	<!-- START HOME -->
	<section id="home" class="templatemo-home">
		<div class="container">
			<div class="row">
				<div class="col-md-2 col-sm-1"></div>
				<div class="col-md-8 col-sm-10" style="font-family:'B Yekan'">
					<h5 class="tm-home-title"><strong>فردایی بهتر = بااندیشه ای برتر</strong></h5>
					<h2 class="tm-home-subtitle">سازندگی-پویایی-خلاقیت</h2>
					<p>ما با شما هستیم برای آینده ای بهتر</p>
					<a href="student/register.aspx" class="btn btn-default smoothScroll tm-view-more-btn" style="border-radius:5px">ثبت نام دانش آموز</a>
				</div>
				<div class="col-md-2 col-sm-1"></div>
			</div>
		</div>
	</section>
	<!-- END HOME -->

	<!-- START work -->
	<section id="work" class="tm-padding-top-bottom-100">
		<div class="container" style="font-family:'B Yekan'">
			<div class="row">
				<div class="col-md-offset-1 col-md-11">
					<h5 class="title">خبرها</h5>						
				</div>
	    <asp:Repeater ID="Repeater4" runat="server">
                <ItemTemplate>
                    <div style="width:100%">
                        <br />
                        <asp:LinkButton ID="Label1"  ForeColor="#0066ff" runat="server" OnClick="Label1_Click"  CommandArgument='<%# Eval("Id") %>'  Text='<%#Eval("onvan") %>'>'></asp:LinkButton>
                             &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbl"  ForeColor="#0066ff" runat="server"  CommandArgument='<%# Eval("Id") %>'  Text='<%#Eval("dat") %>'>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
                <br />
            <div style="overflow: hidden;">
                <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                    
                    <ItemTemplate>
                        <asp:LinkButton ID="btnPage"
                            Style="padding: 8px; margin: 2px; background: #007acc; border: solid 1px blue; font: 8px;"
                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                            runat="server" ForeColor="White" Font-Bold="true" CssClass="fon" CausesValidation="false"><%# Container.DataItem %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>


			</div>
		</div>
	</section>
	<!-- END work -->

	<!-- START PORTFOLIO -->
	<section id="portfolio" class="tm-portfolio">
		<div class="container" style="font-family:'B Yekan'">
			<div class="row">
				<div class="col-md-12 wow bounce">
					<div class="title">
						<h2 class="tm-portfolio-title">عکسهای شما</h2>
					</div>

					<!-- START ISO SECTION -->
					<div class="iso-section">
						<ul class="filter-wrapper clearfix">
						</ul>
						<div class="iso-box-section">
							<div class="iso-box-wrapper col4-iso-box">
								<div class="iso-box html photoshop wordpress mobile col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/1.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
										<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box html wordpress mobile col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/2.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
												<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box wordpress col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/3.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
                                          	<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box html mobile col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/4.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
												<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box wordpress col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/5.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
										<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box html photoshop col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/6.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
										<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box photoshop col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/7.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
									<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
								<div class="iso-box wordpress col-md-3 col-sm-3 col-xs-12">
									<div class="portfolio-thumb">
										<img src="images/8.jpg" class="fluid-img" alt="portfolio img">
										<div class="portfolio-overlay">
											<h3 class="portfolio-item-title"></h3>
											<p></p>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- END PORTFOLIO -->

	<!-- START ABOUT -->
	<section id="about" class="tm-about">
		<div class="container" style="font-family:'B Yekan'">
			<div class="row">
				<div class="col-md-offset-6 col-md-6 col-sm-offset-6 col-sm-7">
					<div class="title">
						<h2>درباره ما</h2>
						<h1 class="tm-red-text">اندیشه جهانی</h1>
					</div>
					<p>اندیشه جهانی</p>
                    <p>اندیشه جهانی</p>
					
				</div>
			</div>
		</div>
	</section>
	<!-- END ABOUT -->

	<!-- START SOCIAL -->
	<section id="social" class="tm-social">
		<div class="container" style="font-family:'B Yekan'">
			<div class="row">
				<div class="col-md-4 col-sm-4 wow rotateInUpLeft" data-wow-delay="0.3s">
					<div class="media facebook">
						<a href="#">
							<div class="media-object pull-left">
								<i class="fa fa-bell"></i>
							</div>
							<div class="media-body">
								<h4 class="media-heading tm-social-title">تازهای خبری</h4>
								<h3>برگزاری مسابقات علمی</h3>
							</div>
						</a>
					</div>
				</div>
				<div class="col-md-4 col-sm-4 wow rotateInUpLeft" data-wow-delay="0.6s">
					<div class="media twitter">
						<a href="#">
							<div class="media-object pull-left">
								<i class="fa fa-calculator"></i>
							</div>
							<div class="media-body">
								<h4 class="media-heading tm-social-title">هوش برتر</h4>
								<h3>هوش برتر</h3>
							</div>
						</a>
					</div>
				</div>
				<div class="col-md-4 col-sm-4 wow rotateInUpLeft" data-wow-delay="0.9s">
					<div class="media pinterest">
						<a href="#">
							<div class="media-object pull-left">
								<i class="fa fa-pinterest"></i>
							</div>
							<div class="media-body">
								<h4 class="media-heading tm-social-title">مسابقه</h4>
								<h3>سودوکو</h3>
							</div>
						</a>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- END SOCIAL -->

	<!-- START CONTACT -->
	<section id="contact" class="tm-contact">
		<div class="container" style="font-family:'B Yekan'">
			<div class="row">
				<div class="col-md-12">					
					<h2 class="title">ارتباط با ما</h2>
					<hr>					
				</div>
				<div class="col-md-1 col-sm-1"></div>
				<div class="col-md-10 col-sm-10">
						<div class="col-md-6 col-sm-6">
							<input class="form-control" type="text" placeholder="نام و نا خانوادگی">
						</div>
						<div class="col-md-6 col-sm-6">
							<input class="form-control" type="email" placeholder="ایمیل">
						</div>
						<div class="col-md-12 col-sm-12">
							<input class="form-control" type="text" placeholder="موضوع">
							<textarea class="form-control" placeholder="شرح موضوع" rows="6"></textarea>
						</div>
						<div class="col-md-offset-2 col-md-8 col-sm-offset-2 col-sm-8">
							<input class="form-control" type="submit" value="ثبت">
						</div>
				</div>
				<div class="col-md-1 col-sm-1"></div>
				<div class="col-md-12 col-sm-12">
					<p>اندیشه جهانی</p>
				</div>
			</div>
		</div>
	</section>
	<!-- END CONTACT -->
	<script src="js/jquery.js"></script>
	<script src="js/bootstrap.min.js"></script>
	<script src="js/smoothscroll.js"></script>
	<script src="js/jquery.nav.js"></script>
	<script src="js/isotope.js"></script>
	<script src="js/imagesloaded.min.js"></script>
	<script src="js/custom.js"></script>
        </form>
    <a referrerpolicy="origin" target="_blank" href="https://trustseal.enamad.ir/?id=162122&amp;Code=sdPqON47AArE61RkZ669"><img referrerpolicy="origin" src="https://Trustseal.eNamad.ir/logo.aspx?id=162122&amp;Code=sdPqON47AArE61RkZ669" alt="" style="cursor:pointer" id="sdPqON47AArE61RkZ669"></a>
</body>
</html>