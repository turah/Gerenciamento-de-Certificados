using MathNet.Numerics;
using SDTBusiness.Unity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using SDTDomainModel.Entities;
using SDTBusiness.Utils;
using SDTDomainModel.Enums;

namespace SDTBusiness.Registers
{
    public class ChartModuleBusinessFacade : BaseUnity
    {

        public static void CreateOutputChart(SeparatorEfficiencyCase c, CorrelationType correlation)
        {
            if (correlation == CorrelationType.IshiiKataoka)
            {
                c.HCDropCumulativeDistributionChart = DropCumulativeDistributionChartIshiiKataoka(c.HCDropletSizeInMeter);
                c.WaterDropCumulativeDistributionChart = DropCumulativeDistributionChartIshiiKataoka(c.WaterDropletSizeInMeter);

                c.HCDropletDensityDistributionChart = DropletDensityDistributionChartIshiiKataoka(c.HCDropletSizeInMeter);
                c.WaterDropletDensityDistributionChart = DropletDensityDistributionChartIshiiKataoka(c.WaterDropletSizeInMeter);
            }
            else
            {
                c.HCDropCumulativeDistributionChart = DropCumulativeDistributionChartTattersonDallmanHanratty(c.HCMaxInMeter, c.HCMedInMeter);
                c.WaterDropCumulativeDistributionChart = DropCumulativeDistributionChartTattersonDallmanHanratty(c.WaterMaxInMeter, c.WaterMedInMeter);

                c.HCDropletDensityDistributionChart = null;
                c.WaterDropletDensityDistributionChart = null;
            }
            
        }

        public static byte[] DropCumulativeDistributionChartTattersonDallmanHanratty(double? maxDropletSize, double? medtdh)
        {
            
            if (!CalculationModuleBusinessFacade.IsValidNumber(maxDropletSize) || !CalculationModuleBusinessFacade.IsValidNumber(medtdh))
                return null;

            Chart splineChart = GetSplineChart(ConstantsFile.DROPCUMULATIVEDISTRIBUTIONCHARTTITLE, ConstantsFile.DROPCUMULATIVEDISTRIBUTIONCHARTAXISX, ConstantsFile.DROPCUMULATIVEDISTRIBUTIONCHARTAXISY);
            splineChart.ChartAreas[0].AxisY.LabelStyle.Format = "0.0' x10³'";

            Series splineSeries = new Series();
            splineSeries.Color = Color.Red;

            for (int i = 1; i <= 50; i++)
            {
                var dropTemp = CalculationModuleBusinessFacade.GetDropTattersonDallmanHanratty(i, maxDropletSize.Value);
                splineSeries.Points.AddXY(Integrate.OnClosedInterval(x => CalculationModuleBusinessFacade.GetDensityfnTattersonDallmanHanratty(x, maxDropletSize.Value, medtdh.Value), 0, dropTemp), dropTemp / 1000);
            }

            splineSeries.ChartType = SeriesChartType.Spline;
            splineChart.Series.Add(splineSeries);

            MemoryStream ms = new MemoryStream();
            splineChart.SaveImage(ms, ChartImageFormat.Png);
            return ms.ToArray();

        }

        public static byte[] DropletDensityDistributionChartIshiiKataoka(double? maxDropletSize)
        {
            if (!CalculationModuleBusinessFacade.IsValidNumber(maxDropletSize))
                return null;

            Chart splineChart = GetSplineChart(ConstantsFile.DROPLETDENSITYDISTRIBUTIONCHARTTITLE, ConstantsFile.DROPLETDENSITYDISTRIBUTIONCHARTAXISX, ConstantsFile.DROPLETDENSITYDISTRIBUTIONCHARTAXISY);
            splineChart.ChartAreas[0].AxisX.LabelStyle.Format = "0.0' x10³'";

            Series splineSeries = new Series();
            splineSeries.Color = Color.Red;

            for (int i = 1; i <= 50; i++)
            {
                var dropTemp = CalculationModuleBusinessFacade.GetDropIshiiKataoka(i, maxDropletSize.Value);
                splineSeries.Points.AddXY(dropTemp / 1000, CalculationModuleBusinessFacade.GetDensityfnIshiiKataoka(dropTemp, maxDropletSize.Value));
            }
            
            splineSeries.ChartType = SeriesChartType.Spline;
            splineChart.Series.Add(splineSeries);

            MemoryStream ms = new MemoryStream();
            splineChart.SaveImage(ms, ChartImageFormat.Png);
            return ms.ToArray();
        }

        public static byte[] DropCumulativeDistributionChartIshiiKataoka(double? maxDropletSize)
        {
            if (!CalculationModuleBusinessFacade.IsValidNumber(maxDropletSize))
                return null;

            Chart splineChart = GetSplineChart(ConstantsFile.DROPCUMULATIVEDISTRIBUTIONCHARTTITLE, ConstantsFile.DROPCUMULATIVEDISTRIBUTIONCHARTAXISX, ConstantsFile.DROPCUMULATIVEDISTRIBUTIONCHARTAXISY);
            splineChart.ChartAreas[0].AxisY.LabelStyle.Format = "0.0' x10³'";

            Series splineSeries = new Series();
            splineSeries.Color = Color.Red;

            for (int i = 1; i <= 50; i++)
            {
                var dropTemp = CalculationModuleBusinessFacade.GetDropIshiiKataoka(i, maxDropletSize.Value);
                splineSeries.Points.AddXY(Integrate.OnClosedInterval(x => CalculationModuleBusinessFacade.GetDensityfnIshiiKataoka(x, maxDropletSize.Value), 0, dropTemp), dropTemp / 1000);
            }

            splineSeries.ChartType = SeriesChartType.Spline;
            splineChart.Series.Add(splineSeries);

            MemoryStream ms = new MemoryStream();
            splineChart.SaveImage(ms, ChartImageFormat.Png);
            return ms.ToArray();
        }

        private static System.Drawing.Font GetAxisTitleFont()
        {
            return new System.Drawing.Font(ConstantsFile.FAMILYNAMEUBUNTULIGHT, 10, System.Drawing.FontStyle.Bold);
        }

        private static System.Drawing.Font GetChartTitleFont()
        {
            return new System.Drawing.Font(ConstantsFile.FAMILYNAMEUBUNTULIGHT, 12, System.Drawing.FontStyle.Bold);
        }

        private static Chart GetSplineChart(string title, string axisX, string axisY)
        {
            ChartArea chartArea = new ChartArea();
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisY.IsMarginVisible = true;
            chartArea.AxisX.IsMarginVisible = true;
            chartArea.AxisX.Title = axisX;
            chartArea.AxisY.Title = axisY;
            chartArea.AxisX.TitleFont = GetAxisTitleFont();
            chartArea.AxisY.TitleFont = GetAxisTitleFont();
            chartArea.AxisX.LabelStyle.Format = "0.0";

            Chart splineChart = new Chart();
            splineChart.Titles.Add(GetTitle(title));
            splineChart.Width = 522;
            splineChart.Height = 300;
            splineChart.BackColor = Color.Transparent;
            splineChart.AntiAliasing = AntiAliasingStyles.Graphics;
            splineChart.ChartAreas.Add(chartArea);

            return splineChart;
        }

        private static Title GetTitle(string titleName)
        {
            Title title = new Title(titleName);
            title.Alignment = ContentAlignment.TopCenter;
            title.Font = GetChartTitleFont();

            return title;
        }


    }
}
