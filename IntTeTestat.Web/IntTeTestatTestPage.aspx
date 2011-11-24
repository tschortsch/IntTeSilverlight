<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IntTeTestat</title>
    <link rel="stylesheet" type="text/css" href="./Resources/css/styles.css" /> 
    <script type="text/javascript" src="./Resources/js/Silverlight.js"></script>
    <script type="text/javascript" src="./Resources/js/general.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="height:100%">
    <table style="margin-left: auto; margin-right: auto;"> 
        <tr> 
           <td style="width: 400px; height: 400px;"> 
                <div id="silverlightControlHost">
                    <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		              <param name="source" value="ClientBin/IntTeTestat.xap"/>
		              <param name="onError" value="onSilverlightError" />
		              <param name="background" value="white" />
		              <param name="minRuntimeVersion" value="4.0.50826.0" />
		              <param name="autoUpgrade" value="true" />
		              <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50826.0" style="text-decoration:none">
 			              <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
		              </a>
	                </object><iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe>
                    </div>
             </td>
        </tr> 
    </table>


    </form>
</body>
</html>
