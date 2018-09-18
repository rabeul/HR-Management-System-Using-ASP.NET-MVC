<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="work_01.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <fieldset>
            <legend>
                <h1>Sign In</h1>
            </legend>
            <div class="form-group">
                <label class="control-label">Email :</label>
                <input type="text" class="form-control" />
            </div><br />
            <div class="form-group">
                <label class="control-label">Password :</label>
                <input type="password" class="form-control" />
                <button>Log In</button>
            </div><br />
            <div class="form-group">
                
             </div>
            <p>
                <label>New ? </label> <button>Register</button>
            </p>
        </fieldset>
    </form>
</body>
</html>
