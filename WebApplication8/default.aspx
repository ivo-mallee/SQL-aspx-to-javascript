<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication8._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TESTING</title>
    <script
    src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js">
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width:1000px; height:1000px;">
			<canvas id="CHART" width="800" height="450"></canvas>
            	<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegiConnectionString %>" SelectCommand="SELECT [Counter], [DATA], [Date] FROM [DATA]"></asp:SqlDataSource>
            </div>
        </div>
    <script>
		var DATAeurope = <%=this.EUROPE%>;
		var DATAamerica = <%=this.AMERICA%>;
		var DATES = <%=this.DATES%>;
		var CHART = new Chart(document.getElementById("CHART"), {
			type: 'line',
			data: {
				labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
				datasets: [{
					data: [86, 114, 106, 106, 107, 111, 133, 221, 783, 2478],
					label: "EU",
					borderColor: "#0000f0",
					fill: false
				},
				{
					data: [282, 350, 411, 502, 635, 809, 947, 1402, 3700, 5267],
					label: "USA",
					borderColor: "#ff0000",
					fill: false
				}],
			},

			options: {
				title: {
					display: true,
					text: 'database Data'
				}
			}
		});

		CHART.data.datasets[0].data = DATAeurope;
		CHART.data.datasets[1].data = DATAamerica;
		CHART.data.labels = DATES;
		console.log(CHART.data.labels);
		CHART.update();
	</script>

		<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </form>
    
</body>
</html>
