using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AQMSUI
{
    public partial class DataReport : Form
    {
        private bool flag = false;
        private string strBtn = "";
        private SqlConnection con;
        private SqlCommand cmd;

        public DataReport()
        {
            InitializeComponent();
        }

        private static DataReport DRForm;

        public static DataReport GetForm()
        {
            if (DRForm == null || DRForm.IsDisposed)
            {
                DRForm = new DataReport();
            }
            return DRForm;
        }

        private void DataReport_Load(object sender, EventArgs e)
        {
            SqlConn();
            btnRealtimeData_Click(sender, e);
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                flag = true;
                btnUnit.Text = "单位：ug/m3";

                colSO2.Caption = "SO2 (ug/m3)";
                colNOx.Caption = "NOx (ug/m3)";
                colNO.Caption = "NO (ug/m3)";
                colNO2.Caption = "NO2 (ug/m3)";
                colO3.Caption = "O3 (ug/m3)";
                colPM25.Caption = "PM2.5 (ug/m3)";
                colPM10.Caption = "PM10 (ug/m3)";
                colTSP.Caption = "TSP (ug/m3)";

                colSO2O.Caption = "SO2 (ug/m3)";
                colNOxO.Caption = "NOx (ug/m3)";
                colNOO.Caption = "NO (ug/m3)";
                colNO2O.Caption = "NO2 (ug/m3)";
                colO3O.Caption = "O3 (ug/m3)";
                colPM25O.Caption = "PM2.5 (ug/m3)";
                colPM10O.Caption = "PM10 (ug/m3)";
                colTSPO.Caption = "TSP (ug/m3)";
            }
            else
            {
                flag = false;
                btnUnit.Text = "单位：mg/m3";

                colSO2.Caption = "SO2 (mg/m3)";
                colNOx.Caption = "NOx (mg/m3)";
                colNO.Caption = "NO (mg/m3)";
                colNO2.Caption = "NO2 (mg/m3)";
                colO3.Caption = "O3 (mg/m3)";
                colPM25.Caption = "PM2.5 (mg/m3)";
                colPM10.Caption = "PM10 (mg/m3)";
                colTSP.Caption = "TSP (mg/m3)";

                colSO2O.Caption = "SO2 (mg/m3)";
                colNOxO.Caption = "NOx (mg/m3)";
                colNOO.Caption = "NO (mg/m3)";
                colNO2O.Caption = "NO2 (mg/m3)";
                colO3O.Caption = "O3 (mg/m3)";
                colPM25O.Caption = "PM2.5 (mg/m3)";
                colPM10O.Caption = "PM10 (mg/m3)";
                colTSPO.Caption = "TSP (mg/m3)";
            }

            switch (strBtn)
            {
                case "btnRealtimeData":
                    btnRealtimeData_Click(sender, e);
                    break;
                case "btnHourAverage":
                    btnHourAverage_Click(sender, e);
                    break;
                case "btnDayAverage":
                    btnDayAverage_Click(sender, e);
                    break;
                case "btnDayReport":
                    btnDayReport_Click(sender, e);
                    break;
                case "btnMonthReport":
                    btnMonthReport_Click(sender, e);
                    break;
                case "btnYearReport":
                    btnYearReport_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void btnRealtimeData_Click(object sender, EventArgs e)
        {
            DataTable dtSrc = new DataTable();
            if (SqlExec(out dtSrc) == false)
            {
                return;
            }

            DataTable dtDest = new DataTable();
            if (btnStatus.Text == "隐藏状态")
            {
                for (int i = 0; i < gvTimeReport.Columns.Count; i++)
                {
                    dtDest.Columns.Add(gvTimeReport.Columns[i].FieldName, typeof(string));
                }
            }
            else
            {
                for (int i = 0; i < gvOtherReport.Columns.Count; i++)
                {
                    dtDest.Columns.Add(gvOtherReport.Columns[i].FieldName, typeof(string));
                }
            }

            dtDest.Rows.Add(1);
            DateTime dt = Convert.ToDateTime(dtSrc.Rows[0][0].ToString().Trim().Replace('/', '-'));
            dtDest.Rows[0]["时间"] = dt.ToLongDateString().ToString() + " " + dt.ToLongTimeString().ToString();

            int j = 0;
            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                if ((i != 0) && (String.Equals(dtSrc.Rows[i][0].ToString().Trim(), dtSrc.Rows[i - 1][0].ToString().Trim()) == false))
                {
                    j++;
                    dtDest.Rows.Add(1);
                    dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));
                    dtDest.Rows[j]["时间"] = dt.ToLongDateString().ToString() + " " + dt.ToLongTimeString().ToString();
                }

                float value;
                if (btnUnit.Text == "单位：ug/m3")
                {
                    value = 1000 * float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                }
                else
                {
                    value = float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                }

                switch (dtSrc.Rows[i][1].ToString().Trim())
                {
                    case "SO2":
                        dtDest.Rows[j]["SO2"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["SO2S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "NOx":
                        dtDest.Rows[j]["NOx"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["NOxS"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "NO":
                        dtDest.Rows[j]["NO"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["NOS"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "NO2":
                        dtDest.Rows[j]["NO2"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["NO2S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "CO":
                        dtDest.Rows[j]["CO"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["COS"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "O3":
                        dtDest.Rows[j]["O3"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["O3S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "PM2.5":
                        dtDest.Rows[j]["PM2.5"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["PM2.5S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "PM10":
                        dtDest.Rows[j]["PM10"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["PM10S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "TSP":
                        dtDest.Rows[j]["TSP"] = value.ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["TSPS"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "温度":
                        dtDest.Rows[j]["温度"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["温度S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "湿度":
                        dtDest.Rows[j]["湿度"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["湿度S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "气压":
                        dtDest.Rows[j]["气压"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["气压S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "风速":
                        dtDest.Rows[j]["风速"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["风速S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "风向":
                        dtDest.Rows[j]["风向"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["风向S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    case "能见度":
                        dtDest.Rows[j]["能见度"] = float.Parse(dtSrc.Rows[i][4].ToString().Trim()).ToString("F3");
                        if (btnStatus.Text == "隐藏状态")
                            dtDest.Rows[j]["能见度S"] = GetState(int.Parse(dtSrc.Rows[i][3].ToString().Trim()));
                        break;
                    default:
                        break;
                }
            }

            if (btnStatus.Text == "隐藏状态")
            {
                gridControl.MainView = gvTimeReport;
            }
            else
            {
                gridControl.MainView = gvOtherReport;
            }
            gridControl.DataSource = dtDest;
            strBtn = "btnRealtimeData";
        }

        private void btnHourAverage_Click(object sender, EventArgs e)
        {
            GetAverage(":");
            strBtn = "btnHourAverage";
        }

        private void btnDayAverage_Click(object sender, EventArgs e)
        {
            GetAverage(" ");
            strBtn = "btnDayAverage";
        }

        private void btnDayReport_Click(object sender, EventArgs e)
        {
            if (dateBegin.Text.Trim() == "" || dateEnd.Text.Trim() == "")
            {
                MessageBox.Show("请输入起止时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TimeSpan ts = DateTime.Parse(dateEnd.Text.Trim().Replace('/', '-')) - DateTime.Parse(dateBegin.Text.Trim().Replace('/', '-'));
            if (ts.Days != 1)
            {
                MessageBox.Show("请查询某一天的日报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtSrc = new DataTable();
            if (SqlExec(out dtSrc) == false)
            {
                return;
            }

            DataTable dtDest = new DataTable();
            for (int i = 0; i < gvOtherReport.Columns.Count; i++)
            {
                dtDest.Columns.Add(gvOtherReport.Columns[i].FieldName, typeof(string));
            }

            float[] arrData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] arrCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            string strDate = Convert.ToDateTime(dtSrc.Rows[0][0].ToString().Trim().Replace('/', '-')).ToLongDateString().ToString();
            int j = 0;

            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                GetData(dtSrc, i, ref arrCount, ref arrData);

                if ((i + 1 < dtSrc.Rows.Count && String.Equals(dtSrc.Rows[i][0].ToString().Trim().Substring(0, dtSrc.Rows[i][0].ToString().Trim().IndexOf(":")), dtSrc.Rows[i + 1][0].ToString().Trim().Substring(0, dtSrc.Rows[i + 1][0].ToString().Trim().IndexOf(":"))) == false) || (i + 1 == dtSrc.Rows.Count))
                {
                    DateTime dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));
                    strDate = dt.ToLongDateString().ToString();

                    for (; j < dt.Hour; j++)
                    {
                        dtDest.Rows.Add(1);
                        dtDest.Rows[j]["时间"] = strDate + " " + j.ToString() + "时";
                        GetNA(ref dtDest, j);
                    }

                    dtDest.Rows.Add(1);
                    dtDest.Rows[j]["时间"] = strDate + " " + j.ToString() + "时";

                    UnitSwitch(ref dtDest, j, arrCount, arrData);
                    j++;

                    for (int k = 0; k < 15; k++)
                    {
                        arrData[k] = 0;
                        arrCount[k] = 0;
                    }
                }
            }

            for (; j < 24; j++)
            {
                dtDest.Rows.Add(1);
                dtDest.Rows[j]["时间"] = strDate + " " + j.ToString() + "时";
                GetNA(ref dtDest, j);
            }

            gridControl.MainView = gvOtherReport;
            gridControl.DataSource = dtDest;
            strBtn = "btnDayReport";
        }

        private void btnMonthReport_Click(object sender, EventArgs e)
        {
            if (dateBegin.Text.Trim() == "" || dateEnd.Text.Trim() == "")
            {
                MessageBox.Show("请输入起止时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TimeSpan ts = DateTime.Parse(dateEnd.Text.Trim().Replace('/', '-')) - DateTime.Parse(dateBegin.Text.Trim().Replace('/', '-'));
            if (ts.Days > 31)
            {
                MessageBox.Show("请查询某一个月的月报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtSrc = new DataTable();
            if (SqlExec(out dtSrc) == false)
            {
                return;
            }

            DataTable dtDest = new DataTable();
            for (int i = 0; i < gvOtherReport.Columns.Count; i++)
            {
                dtDest.Columns.Add(gvOtherReport.Columns[i].FieldName, typeof(string));
            }

            float[] arrData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] arrCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            DateTime dt = Convert.ToDateTime(dtSrc.Rows[0][0].ToString().Trim().Replace('/', '-'));
            int days = new DateTime(dt.Year, dt.Month, 1).AddMonths(1).AddDays(-1).Day;
            string strDate = dt.ToLongDateString();

            int j = 0;
            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                GetData(dtSrc, i, ref arrCount, ref arrData);

                if ((i + 1 < dtSrc.Rows.Count && String.Equals(dtSrc.Rows[i][0].ToString().Trim().Substring(0, dtSrc.Rows[i][0].ToString().Trim().IndexOf(" ")), dtSrc.Rows[i + 1][0].ToString().Trim().Substring(0, dtSrc.Rows[i + 1][0].ToString().Trim().IndexOf(" "))) == false) || (i + 1 == dtSrc.Rows.Count))
                {
                    dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));
                    strDate = dt.ToLongDateString();

                    for (; j < dt.Day; j++)
                    {
                        dtDest.Rows.Add(1);
                        dtDest.Rows[j]["时间"] = strDate.Substring(0, strDate.IndexOf("月") + 1) + j.ToString() + "日";
                        GetNA(ref dtDest, j);
                    }

                    dtDest.Rows.Add(1);
                    dtDest.Rows[j]["时间"] = strDate.Substring(0, strDate.IndexOf("月") + 1) + j.ToString() + "日";

                    UnitSwitch(ref dtDest, j, arrCount, arrData);
                    j++;

                    for (int k = 0; k < 15; k++)
                    {
                        arrData[k] = 0;
                        arrCount[k] = 0;
                    }
                }
            }

            for (; j <= days; j++)
            {
                dtDest.Rows.Add(1);
                dtDest.Rows[j]["时间"] = strDate.Substring(0, strDate.IndexOf("月") + 1) + j.ToString() + "日";
                GetNA(ref dtDest, j);
            }

            gridControl.MainView = gvOtherReport;
            gridControl.DataSource = dtDest;
            strBtn = "btnMonthReport";
        }

        private void btnYearReport_Click(object sender, EventArgs e)
        {
            if (dateBegin.Text.Trim() == "" || dateEnd.Text.Trim() == "")
            {
                MessageBox.Show("请输入起止时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TimeSpan ts = DateTime.Parse(dateEnd.Text.Trim().Replace('/', '-')) - DateTime.Parse(dateBegin.Text.Trim().Replace('/', '-'));
            if (ts.Days > 366)
            {
                MessageBox.Show("请查询某一年的年报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtSrc = new DataTable();
            if (SqlExec(out dtSrc) == false)
            {
                return;
            }

            DataTable dtDest = new DataTable();
            for (int i = 0; i < gvOtherReport.Columns.Count; i++)
            {
                dtDest.Columns.Add(gvOtherReport.Columns[i].FieldName, typeof(string));
            }

            float[] arrData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] arrCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int j = 1;
            DateTime dt = Convert.ToDateTime(dtSrc.Rows[0][0].ToString().Trim());
            string year = dt.Year.ToString();

            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                GetData(dtSrc, i, ref arrCount, ref arrData);

                if ((i + 1 < dtSrc.Rows.Count && String.Equals(dtSrc.Rows[i][0].ToString().Trim().Substring(0, 7), dtSrc.Rows[i + 1][0].ToString().Trim().Substring(0, 7)) == false) || (i + 1 == dtSrc.Rows.Count))
                {
                    dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim());

                    for (; j < dt.Month; j++)
                    {
                        dtDest.Rows.Add(1);
                        dtDest.Rows[j - 1]["时间"] = year + "年" + j.ToString() + "月";
                        GetNA(ref dtDest, j - 1);
                    }

                    dtDest.Rows.Add(1);
                    dtDest.Rows[j - 1]["时间"] = year + "年" + j.ToString() + "月";

                    UnitSwitch(ref dtDest, j - 1, arrCount, arrData);
                    j++;

                    for (int k = 0; k < 15; k++)
                    {
                        arrData[k] = 0;
                        arrCount[k] = 0;
                    }
                }
            }

            for (; j <= 12; j++)
            {
                dtDest.Rows.Add(1);
                dtDest.Rows[j - 1]["时间"] = year + "年" + j.ToString() + "月";
                GetNA(ref dtDest, j - 1);
            }

            gridControl.MainView = gvOtherReport;
            gridControl.DataSource = dtDest;
            strBtn = "btnYearReport";
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (strBtn == "btnRealtimeData")
            {
                if (btnStatus.Text == "显示状态")
                {
                    btnStatus.Text = "隐藏状态";
                }
                else
                {
                    btnStatus.Text = "显示状态";
                }

                btnRealtimeData_Click(sender, e);
            }
        }

        private void btnReportExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gridControl.ExportToXls(saveFileDialog.FileName, options);
            }
        }

        private void SqlConn()
        {
            try
            {
                con = new SqlConnection("Data Source=IDEAPAD;Initial Catalog=AQMS;Integrated Security=True");
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
            }
            catch
            {
                MessageBox.Show("服务器连接失败，请重新连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool SqlExec(out DataTable dt)
        {
            try
            {
                string strSelect = "SELECT * FROM AirData";
                string strBegin = dateBegin.Text.Trim() + " " + timeBegin.Text.Trim();
                string strEnd = dateEnd.Text.Trim() + " " + timeEnd.Text.Trim();

                if (dateBegin.Text.Trim() != "" && dateEnd.Text.Trim() == "")
                {
                    strSelect = strSelect + " WHERE RecordTime > '" + strBegin + "'";
                }
                else if (dateBegin.Text.Trim() == "" && dateEnd.Text.Trim() != "")
                {
                    strSelect = strSelect + " WHERE RecordTime < '" + strEnd + "'";
                }
                else if (dateBegin.Text.Trim() != "" && dateEnd.Text.Trim() != "")
                {
                    strSelect = strSelect + " WHERE RecordTime BETWEEN '" + strBegin + "' AND '" + strEnd + "'";
                }

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = strSelect;
                da.SelectCommand = cmd;
                da.Fill(ds, "AirData");
                dt = ds.Tables["AirData"];
                cmd.ExecuteNonQuery();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("当前起止时间段没有数据，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                dt = null;
                MessageBox.Show("服务器连接已断开，请重新连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private string GetState(int flagValue)
        {
            if (flagValue == 0)
            {
                return "";     // 正常值
            }
            else if (flagValue == 1)
            {
                return "SE";   // 串口错误
            }
            else if (flagValue == 2)
            {
                return "CE";    // 连接错误
            }
            else if (flagValue == 3)
            {
                return "CZ";   // 零点校准
            }
            else if (flagValue == 4)
            {
                return "CS";   // 跨度校准
            }
            else if (flagValue == 5)
            {
                return "EZ";    // 零点检查
            }
            else if (flagValue == 6)
            {
                return "ES";    // 跨度检查
            }
            else if (flagValue == 7)
            {
                return "DE";    // 数据异常
            }
            else if (flagValue == 8)
            {
                return "EM";   // 多点检查
            }
            else if (flagValue == 9)
            {
                return "EP";    // 精密度检查
            }
            else if (flagValue == 10)
            {
                return "EE";    // 示值误差检查
            }
            else if (flagValue == 11)
            {
                return "V";    // 维护
            }
            else
            {
                return "NULL"; // 无数据
            }
        }

        private void GetNA(ref DataTable dtDest, int j)
        {
            dtDest.Rows[j]["SO2"] = "NA";
            dtDest.Rows[j]["NOx"] = "NA";
            dtDest.Rows[j]["NO"] = "NA";
            dtDest.Rows[j]["NO2"] = "NA";
            dtDest.Rows[j]["CO"] = "NA";
            dtDest.Rows[j]["O3"] = "NA";
            dtDest.Rows[j]["PM2.5"] = "NA";
            dtDest.Rows[j]["PM10"] = "NA";
            dtDest.Rows[j]["TSP"] = "NA";
            dtDest.Rows[j]["温度"] = "NA";
            dtDest.Rows[j]["湿度"] = "NA";
            dtDest.Rows[j]["气压"] = "NA";
            dtDest.Rows[j]["风速"] = "NA";
            dtDest.Rows[j]["风向"] = "NA";
            dtDest.Rows[j]["能见度"] = "NA";
        }

        private void GetData(DataTable dtSrc, int i, ref int[] arrCount, ref float[] arrData)
        {
            if (int.Parse(dtSrc.Rows[i][3].ToString().Trim()) == 0)
            {
                switch (dtSrc.Rows[i][1].ToString().Trim())
                {
                    case "SO2":
                        arrData[0] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[0] += 1;
                        break;
                    case "NOx":
                        arrData[1] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[1] += 1;
                        break;
                    case "NO":
                        arrData[2] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[2] += 1;
                        break;
                    case "NO2":
                        arrData[3] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[3] += 1;
                        break;
                    case "CO":
                        arrData[4] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[4] += 1;
                        break;
                    case "O3":
                        arrData[5] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[5] += 1;
                        break;
                    case "PM2.5":
                        arrData[6] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[6] += 1;
                        break;
                    case "PM10":
                        arrData[7] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[7] += 1;
                        break;
                    case "TSP":
                        arrData[8] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[8] += 1;
                        break;
                    case "温度":
                        arrData[9] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[9] += 1;
                        break;
                    case "湿度":
                        arrData[10] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[10] += 1;
                        break;
                    case "气压":
                        arrData[11] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[11] += 1;
                        break;
                    case "风速":
                        arrData[12] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[12] += 1;
                        break;
                    case "风向":
                        arrData[13] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[13] += 1;
                        break;
                    case "能见度":
                        arrData[14] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                        arrCount[14] += 1;
                        break;
                    default:
                        break;
                }
            }
        }

        private void GetAverage(string strIndex)
        {
            DataTable dtSrc = new DataTable();
            if (SqlExec(out dtSrc) == false)
            {
                return;
            }

            DataTable dtDest = new DataTable();
            for (int i = 0; i < gvOtherReport.Columns.Count; i++)
            {
                dtDest.Columns.Add(gvOtherReport.Columns[i].FieldName, typeof(string));
            }

            float[] arrData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] arrCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int j = 0;
            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                GetData(dtSrc, i, ref arrCount, ref arrData);

                if ((i + 1 < dtSrc.Rows.Count && String.Equals(dtSrc.Rows[i][0].ToString().Trim().Substring(0, dtSrc.Rows[i][0].ToString().Trim().IndexOf(strIndex)), dtSrc.Rows[i + 1][0].ToString().Trim().Substring(0, dtSrc.Rows[i + 1][0].ToString().Trim().IndexOf(strIndex))) == false) || (i + 1 == dtSrc.Rows.Count))
                {
                    dtDest.Rows.Add(1);
                    DateTime dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));
                    if (strIndex == ":")
                    {
                        dtDest.Rows[j]["时间"] = dt.ToLongDateString().ToString() + " " + dt.Hour.ToString() + "时";
                    }
                    else if (strIndex == " ")
                    {
                        dtDest.Rows[j]["时间"] = dt.ToLongDateString().ToString();
                    }

                    UnitSwitch(ref dtDest, j, arrCount, arrData);
                    j++;

                    for (int k = 0; k < 15; k++)
                    {
                        arrData[k] = 0;
                        arrCount[k] = 0;
                    }
                }
            }

            gridControl.MainView = gvOtherReport;
            gridControl.DataSource = dtDest;
        }

        private void UnitSwitch(ref DataTable dtDest, int j, int[] arrCount, float[] arrData)
        {
            if (btnUnit.Text == "单位：ug/m3")
            {
                dtDest.Rows[j]["SO2"] = arrCount[0] == 0 ? "NA" : (1000 * arrData[0] / arrCount[0]).ToString("F3");
                dtDest.Rows[j]["NOx"] = arrCount[1] == 0 ? "NA" : (1000 * arrData[1] / arrCount[1]).ToString("F3");
                dtDest.Rows[j]["NO"] = arrCount[2] == 0 ? "NA" : (1000 * arrData[2] / arrCount[2]).ToString("F3");
                dtDest.Rows[j]["NO2"] = arrCount[3] == 0 ? "NA" : (1000 * arrData[3] / arrCount[3]).ToString("F3");
                dtDest.Rows[j]["O3"] = arrCount[5] == 0 ? "NA" : (1000 * arrData[5] / arrCount[5]).ToString("F3");
                dtDest.Rows[j]["PM2.5"] = arrCount[6] == 0 ? "NA" : (1000 * arrData[6] / arrCount[6]).ToString("F3");
                dtDest.Rows[j]["PM10"] = arrCount[7] == 0 ? "NA" : (1000 * arrData[7] / arrCount[7]).ToString("F3");
                dtDest.Rows[j]["TSP"] = arrCount[8] == 0 ? "NA" : (1000 * arrData[8] / arrCount[8]).ToString("F3");
            }
            else
            {
                dtDest.Rows[j]["SO2"] = arrCount[0] == 0 ? "NA" : (arrData[0] / arrCount[0]).ToString("F3");
                dtDest.Rows[j]["NOx"] = arrCount[1] == 0 ? "NA" : (arrData[1] / arrCount[1]).ToString("F3");
                dtDest.Rows[j]["NO"] = arrCount[2] == 0 ? "NA" : (arrData[2] / arrCount[2]).ToString("F3");
                dtDest.Rows[j]["NO2"] = arrCount[3] == 0 ? "NA" : (arrData[3] / arrCount[3]).ToString("F3");
                dtDest.Rows[j]["O3"] = arrCount[5] == 0 ? "NA" : (arrData[5] / arrCount[5]).ToString("F3");
                dtDest.Rows[j]["PM2.5"] = arrCount[6] == 0 ? "NA" : (arrData[6] / arrCount[6]).ToString("F3");
                dtDest.Rows[j]["PM10"] = arrCount[7] == 0 ? "NA" : (arrData[7] / arrCount[7]).ToString("F3");
                dtDest.Rows[j]["TSP"] = arrCount[8] == 0 ? "NA" : (arrData[8] / arrCount[8]).ToString("F3");
            }

            dtDest.Rows[j]["CO"] = arrCount[4] == 0 ? "NA" : (arrData[4] / arrCount[4]).ToString("F3");
            dtDest.Rows[j]["温度"] = arrCount[9] == 0 ? "NA" : (arrData[9] / arrCount[9]).ToString("F3");
            dtDest.Rows[j]["湿度"] = arrCount[10] == 0 ? "NA" : (arrData[10] / arrCount[10]).ToString("F3");
            dtDest.Rows[j]["气压"] = arrCount[11] == 0 ? "NA" : (arrData[11] / arrCount[11]).ToString("F3");
            dtDest.Rows[j]["风速"] = arrCount[12] == 0 ? "NA" : (arrData[12] / arrCount[12]).ToString("F3");
            dtDest.Rows[j]["风向"] = arrCount[13] == 0 ? "NA" : (arrData[13] / arrCount[13]).ToString("F3");
            dtDest.Rows[j]["能见度"] = arrCount[14] == 0 ? "NA" : (arrData[14] / arrCount[14]).ToString("F3");
        }
    }
}
