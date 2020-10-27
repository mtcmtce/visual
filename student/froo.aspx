<%@ Page Language="C#" AutoEventWireup="true" CodeFile="froo.aspx.cs" Inherits="student_froo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>فروشگاه من </title>
</head>
<body>
    <form id="form1" runat="server">
 
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
                        <asp:Label ID="Label1"  ForeColor="#0066ff" runat="server" CommandArgument='<%# Eval("Id") %>'  Text='<%#Eval("onvan") %>'>'></asp:Label>
                             &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbl"  ForeColor="#0066ff" runat="server"  CommandArgument='<%# Eval("Id") %>'  Text='<%#Eval("descs") %>'>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <img src='<%# Eval("img").ToString().Replace("\\", "/") %>' runat="server" style="width:50px;height:50px"/>
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

    </form>
</body>
</html>
