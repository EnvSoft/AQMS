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
    public partial class AQIReport : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private int maxIAQI;
        private int countPrimary;        //首要污染物项数 
        private List<string> listPrimary;//首要污染物列表
        private List<float> listO38;     //O3的8小时滑动平均浓度列表
        private List<float> listSO224;   //SO2的24小时平均浓度列表
        private List<float> listPM1024;  //PM10的24小时滑动平均浓度列表
        private List<float> listPM2524;  //PM2.5的24小时滑动平均浓度列表

        public AQIReport(int type)
        {            
            InitializeComponent();
            SqlConn();

            maxIAQI = 0;
            countPrimary = 0;
            listPrimary = new List<string>();
            listO38 = new List<float>();
            listSO224 = new List<float>();
            listPM1024 = new List<float>();
            listPM2524 = new List<float>();

            if (type == 1)
            {

            }
            else if (type == 2)
            {

            }
        }

        private void AQIReport_Load(object sender, EventArgs e)
        {

        }

        private void btnAQITimeReport_Click(object sender, EventArgs e)
        {
            gbTime.Caption = "时间：" + Convert.ToDateTime(dateBegin.Text.Replace('/', '-')).ToLongDateString() + timeBegin.Text.Substring(0, timeBegin.Text.IndexOf(':')) + "时 至 " + Convert.ToDateTime(dateEnd.Text.Replace('/', '-')).ToLongDateString() + timeEnd.Text.Substring(0, timeEnd.Text.IndexOf(':')) + "时";

            DataTable dtSrc = new DataTable();
            if (SqlExec(ref dtSrc, 1) == false) { return; }

            DataTable dtDest = new DataTable();
            for (int i = 0; i < bgvAQITimeReport.Columns.Count; i++)
            {
                dtDest.Columns.Add(bgvAQITimeReport.Columns[i].FieldName, typeof(string));
            }

            int[] arrCount1 = { 0, 0, 0, 0, 0, 0 };
            float[] arrData1 = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };

            int countSO224 = 0;
            int countO38 = 0;
            int countPM1024 = 0;
            int countPM2524 = 0;

            float dataSO224 = 0.0f;
            float dataO38 = 0.0f;
            float dataPM1024 = 0.0f;
            float dataPM2524 = 0.0f;

            DateTime dtBegin = Convert.ToDateTime((dateBegin.Text.Trim() + " " + timeBegin.Text.Trim().Substring(0, timeBegin.Text.Trim().IndexOf(':')) + ":00:00").Replace('/', '-'));
            DateTime dtEnd = Convert.ToDateTime((dateEnd.Text.Trim() + " " + timeEnd.Text.Trim().Substring(0, timeEnd.Text.Trim().IndexOf(':')) + ":00:00").Replace('/', '-'));

            while (dtBegin <= dtEnd)
            {
                for (int i = 0; i < dtSrc.Rows.Count; i++)
                {
                    if (int.Parse(dtSrc.Rows[i][3].ToString().Trim()) == 0)
                    {
                        DateTime dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));

                        if (dtSrc.Rows[i][1].ToString().Trim() == "SO2")
                        {
                            if ((dtBegin - dt).Hours >= 0 && (dtBegin - dt).Hours < 24)
                            {
                                dataSO224 += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                countSO224 += 1;
                            }
                        }
                        else if (dtSrc.Rows[i][1].ToString().Trim() == "O3")
                        {
                            if ((dtBegin - dt).Hours >= 0 && (dtBegin - dt).Hours < 24)
                            {
                                dataO38 += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                countO38 += 1;
                            }
                        }
                        else if (dtSrc.Rows[i][1].ToString().Trim() == "PM10")
                        {
                            if ((dtBegin - dt).Hours >= 0 && (dtBegin - dt).Hours < 24)
                            {
                                dataPM1024 += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                countPM1024 += 1;
                            }
                        }
                        else if (dtSrc.Rows[i][1].ToString().Trim() == "PM2.5")
                        {
                            if ((dtBegin - dt).Hours >= 0 && (dtBegin - dt).Hours < 24)
                            {
                                dataPM2524 += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                countPM2524 += 1;
                            }
                        }
                    }
                }

                if (countSO224 != 0)
                    listSO224.Add(dataSO224 /= countSO224);
                else
                    listSO224.Add(0.0f);

                if (countO38 != 0)
                    listO38.Add(dataO38 /= countO38);
                else
                    listO38.Add(0.0f);

                if (countPM1024 != 0)
                    listPM1024.Add(dataPM1024 /= countPM1024);
                else
                    listPM1024.Add(0.0f);

                if (countPM2524 != 0)
                    listPM2524.Add(dataPM2524 /= countPM2524);
                else
                    listPM2524.Add(0.0f);

                countSO224 = 0;
                countO38 = 0;
                countPM1024 = 0;
                countPM2524 = 0;

                dataSO224 = 0.0f;
                dataO38 = 0.0f;
                dataPM1024 = 0.0f;
                dataPM2524 = 0.0f;

                dtBegin = dtBegin.AddHours(1);
            }

            dtBegin = Convert.ToDateTime((dateBegin.Text.Trim() + " " + timeBegin.Text.Trim().Substring(0, timeBegin.Text.Trim().IndexOf(':')) + ":00:00").Replace('/', '-'));
            int j = 0;

            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                DateTime dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));

                if (dt >= dtBegin)
                {
                    if (int.Parse(dtSrc.Rows[i][3].ToString().Trim()) == 0)
                    {
                        switch (dtSrc.Rows[i][1].ToString().Trim())
                        {
                            case "SO2":
                                arrData1[0] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount1[0] += 1;
                                break;
                            case "NO2":
                                arrData1[1] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount1[1] += 1;
                                break;
                            case "PM10":
                                arrData1[2] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount1[2] += 1;
                                break;
                            case "CO":
                                arrData1[3] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount1[3] += 1;
                                break;
                            case "O3":
                                arrData1[4] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount1[4] += 1;
                                break;
                            case "PM2.5":
                                arrData1[5] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount1[5] += 1;
                                break;
                            default:
                                break;
                        }
                    }

                    if ((i + 1 < dtSrc.Rows.Count && dtSrc.Rows[i][0].ToString().Trim().Substring(0, dtSrc.Rows[i][0].ToString().Trim().IndexOf(':')) != dtSrc.Rows[i + 1][0].ToString().Trim().Substring(0, dtSrc.Rows[i + 1][0].ToString().Trim().IndexOf(':'))) || (i + 1 == dtSrc.Rows.Count))
                    {
                        SetTimeNA(ref dtDest, ref j, ref dtBegin, dt);//NA标识缺测指标的浓度、分指数
                        dtDest.Rows.Add(1);
                        dtDest.Rows[j]["时间"] = dt.ToLongDateString().ToString() + dt.Hour + "时";

                        maxIAQI = 0;
                        countPrimary = 1;
                        listPrimary.Add("");

                        //浓度、分指数
                        SetCpIAQI(ref dtDest, j, arrCount1[0] == 0, arrData1[0] / arrCount1[0], "SO2_1");
                        SetCpIAQI(ref dtDest, j, arrCount1[1] == 0, arrData1[1] / arrCount1[1], "NO2_1");
                        SetCpIAQI(ref dtDest, j, arrCount1[2] == 0, arrData1[2] / arrCount1[2], "PM10_1");
                        SetCpIAQI(ref dtDest, j, arrCount1[3] == 0, arrData1[3] / arrCount1[3], "CO_1");
                        SetCpIAQI(ref dtDest, j, arrCount1[4] == 0, arrData1[4] / arrCount1[4], "O3_1");
                        SetCpIAQI(ref dtDest, j, arrCount1[5] == 0, arrData1[5] / arrCount1[5], "PM2.5_1");
                        SetCpIAQI(ref dtDest, j, !(listPM1024[j] > 0.0f), listPM1024[j], "PM10_24");
                        SetCpIAQI(ref dtDest, j, !(listPM2524[j] > 0.0f), listPM2524[j], "PM2.5_24");
                        SetCpIAQI(ref dtDest, j, !(listO38[j] > 0.0f), listO38[j], "O3_8");

                        dtDest.Rows[j]["AQI"] = maxIAQI == 0 ? "" : maxIAQI.ToString();//空气质量指数(AQI)
                        SetClassColour(ref dtDest, j);//首要污染物和空气质量指数的级别、类别、颜色

                        for (int k = 0; k < 6; k++)
                        {
                            arrData1[k] = 0.0f;
                            arrCount1[k] = 0;
                        }
                        dtBegin = dtBegin.AddHours(1);
                        j++;
                    }
                }
            }

            SetTimeNA(ref dtDest, ref j, ref dtBegin, dtEnd);//NA标识缺测指标的浓度、分指数
            gridControl.MainView = bgvAQITimeReport;
            gridControl.DataSource = dtDest;

            listPrimary.Clear();
            listO38.Clear();
            listSO224.Clear();
            listPM1024.Clear();
            listPM2524.Clear();
        }

        private void btnAQIDayReport_Click(object sender, EventArgs e)
        {
            gbDay.Caption = "时间：" + Convert.ToDateTime(dateBegin.Text.Replace('/', '-')).ToLongDateString() + " 至 " + Convert.ToDateTime(dateEnd.Text.Replace('/', '-')).ToLongDateString();

            DataTable dtSrc = new DataTable();
            if (SqlExec(ref dtSrc, 2) == false) { return; }

            DataTable dtDest = new DataTable();
            for (int i = 0; i < bgvAQIDayReport.Columns.Count; i++)
            {
                dtDest.Columns.Add(bgvAQIDayReport.Columns[i].FieldName, typeof(string));
            }

            int[] arrCount24 = { 0, 0, 0, 0, 0 };
            int[] arrCountO31 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] arrCountO38 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            float[] arrData24 = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            float[] arrDataO31 = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
            float[] arrDataO38 = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };

            DateTime dtBegin = Convert.ToDateTime((dateBegin.Text.Trim() + " 00:00:00").Replace('/', '-'));
            DateTime dtEnd = Convert.ToDateTime((dateEnd.Text.Trim() + " 00:00:00").Replace('/', '-'));

            while (dtBegin <= dtEnd)
            {
                float max = 0.0f;

                for (int m = 0; m < 24; m++)
                {
                    for (int n = 0; n < dtSrc.Rows.Count; n++)
                    {
                        if (dtSrc.Rows[n][1].ToString().Trim() == "O3" && int.Parse(dtSrc.Rows[n][3].ToString().Trim()) == 0)
                        {
                            DateTime dt = Convert.ToDateTime(dtSrc.Rows[n][0].ToString().Trim().Replace('/', '-'));

                            if ((dtBegin.AddHours(m) - dt).Hours < 8 && (dtBegin.AddHours(m) - dt).Hours >= 0)
                            {
                                arrDataO38[m] += float.Parse(dtSrc.Rows[n][4].ToString().Trim());
                                arrCountO38[m] += 1;
                            }
                        }
                    }

                    if (arrCountO38[m] != 0)
                    {
                        arrDataO38[m] /= arrCountO38[m];
                        max = max > arrDataO38[m] ? max : arrDataO38[m];
                    }
                    arrCountO38[m] = 0;
                    arrDataO38[m] = 0.0f;
                }

                dtBegin = dtBegin.AddDays(1);
                listO38.Add(max);
                max = 0.0f;
            }

            dtBegin = Convert.ToDateTime((dateBegin.Text.Trim() + " 00:00:00").Replace('/', '-'));
            int j = 0;

            for (int i = 0; i < dtSrc.Rows.Count; i++)
            {
                DateTime dt = Convert.ToDateTime(dtSrc.Rows[i][0].ToString().Trim().Replace('/', '-'));

                if (dt >= Convert.ToDateTime((dateBegin.Text.Trim() + " 00:00:00").Replace('/', '-')))
                {
                    if (int.Parse(dtSrc.Rows[i][3].ToString().Trim()) == 0)
                    {
                        if (dtSrc.Rows[i][1].ToString().Trim() == "O3")
                        {
                            arrDataO31[dt.Hour] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                            arrCountO31[dt.Hour] += 1;
                        }

                        switch (dtSrc.Rows[i][1].ToString().Trim())
                        {
                            case "SO2":
                                arrData24[0] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount24[0] += 1;
                                break;
                            case "NO2":
                                arrData24[1] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount24[1] += 1;
                                break;
                            case "PM10":
                                arrData24[2] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount24[2] += 1;
                                break;
                            case "CO":
                                arrData24[3] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount24[3] += 1;
                                break;
                            case "PM2.5":
                                arrData24[4] += float.Parse(dtSrc.Rows[i][4].ToString().Trim());
                                arrCount24[4] += 1;
                                break;
                            default:
                                break;
                        }
                    }

                    if ((i + 1 < dtSrc.Rows.Count && dtSrc.Rows[i][0].ToString().Trim().Substring(0, dtSrc.Rows[i][0].ToString().Trim().IndexOf(' ')) != dtSrc.Rows[i + 1][0].ToString().Trim().Substring(0, dtSrc.Rows[i + 1][0].ToString().Trim().IndexOf(' '))) || (i + 1 == dtSrc.Rows.Count))
                    {
                        float maxO31 = 0.0f;
                        for (int k = 0; k < 24; k++)
                        {
                            if (arrCountO31[k] != 0)
                            {
                                arrDataO31[k] /= arrCountO31[k];
                                maxO31 = maxO31 > arrDataO31[k] ? maxO31 : arrDataO31[k];
                            }
                            arrCountO31[k] = 0;
                            arrDataO31[k] = 0.0f;
                        }

                        SetDayNA(ref dtDest, ref j, ref dtBegin, dt);//NA标识缺测指标的浓度、分指数
                        dtDest.Rows.Add(1);
                        dtDest.Rows[j]["时间"] = dt.ToLongDateString().ToString();

                        maxIAQI = 0;
                        countPrimary = 1;
                        listPrimary.Add("");

                        //浓度、分指数
                        SetCpIAQI(ref dtDest, j, arrCount24[0] == 0, arrData24[0] / arrCount24[0], "SO2_24");
                        SetCpIAQI(ref dtDest, j, arrCount24[1] == 0, arrData24[1] / arrCount24[1], "NO2_24");
                        SetCpIAQI(ref dtDest, j, arrCount24[2] == 0, arrData24[2] / arrCount24[2], "PM10_24");
                        SetCpIAQI(ref dtDest, j, arrCount24[3] == 0, arrData24[3] / arrCount24[3], "CO_24");
                        SetCpIAQI(ref dtDest, j, arrCount24[4] == 0, arrData24[4] / arrCount24[4], "PM2.5_24");
                        SetCpIAQI(ref dtDest, j, !(maxO31 > 0.0f), maxO31, "O3_1");
                        SetCpIAQI(ref dtDest, j, !(listO38[j] > 0.0f), listO38[j], "O3_8");

                        dtDest.Rows[j]["AQI"] = maxIAQI == 0 ? "" : maxIAQI.ToString();//空气质量指数(AQI)
                        SetClassColour(ref dtDest, j);//首要污染物和空气质量指数的级别、类别、颜色

                        for (int k = 0; k < 5; k++)
                        {
                            arrData24[k] = 0.0f;
                            arrCount24[k] = 0;
                        }
                        dtBegin = dtBegin.AddDays(1);
                        j++;
                    }
                }
            }

            SetDayNA(ref dtDest, ref j, ref dtBegin, dtEnd);//NA标识缺测指标的浓度、分指数
            gridControl.MainView = bgvAQIDayReport;
            gridControl.DataSource = dtDest;

            listPrimary.Clear();
            listO38.Clear();
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

        private bool SqlExec(ref DataTable dt, int flag)
        {
            try
            {
                if (dateBegin.Text.Trim() == "")
                {
                    MessageBox.Show("请输入起始日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dateEnd.Text.Trim() == "")
                {
                    MessageBox.Show("请输入终止日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                string strBegin = "";
                string strEnd = "";
                if (flag == 1)
                {
                    strBegin = Convert.ToDateTime((dateBegin.Text.Trim() + " " + timeBegin.Text.Trim().Substring(0, timeBegin.Text.Trim().IndexOf(':')) + ":00:00").Replace('/', '-')).AddHours(-23).ToString("yyyy/MM/dd HH:mm:ss");
                    strEnd = dateEnd.Text.Trim() + " " + timeEnd.Text.Trim().Substring(0, timeEnd.Text.Trim().IndexOf(':')) + ":59:59";
                }
                else
                {
                    strBegin = Convert.ToDateTime((dateBegin.Text.Trim() + " 17:00:00").Replace('/', '-')).AddDays(-1).ToString("yyyy/MM/dd HH:mm:ss");
                    strEnd = dateEnd.Text.Trim() + " 23:59:59";
                }

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM AirData WHERE RecordTime BETWEEN '" + strBegin + "' AND '" + strEnd + "'";
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

        #region 污染物浓度限值、空气质量分指数
        private int CalculateIAQI(float Cp, string str)
        {
            int IAQIhi = 0;
            int IAQIlo = 0;
            int BPhi = 0;
            int BPlo = 0;

            switch (str)
            {
                case "SO2_24":
                    SO2_24Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "SO2_1":
                    SO2_1Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "NO2_24":
                    NO2_24Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "NO2_1":
                    NO2_1Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "CO_24":
                    CO_24Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "CO_1":
                    CO_1Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "O3_1":
                    O3_1Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "O3_8":
                    O3_8Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "PM10_24":
                    PM10_24Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                case "PM2.5_24":
                    PM25_24Limit(ref BPlo, ref BPhi, ref IAQIlo, ref IAQIhi, Cp);
                    break;
                default:
                    break;
            }

            return Convert.ToInt32(Math.Round((IAQIhi - IAQIlo) * (Cp - BPlo) / (BPhi - BPlo) + IAQIlo));
        }

        private void SO2_24Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 50)
            {
                BPlo = 0;
                BPhi = 50;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 50 && Cp <= 150)
            {
                BPlo = 50;
                BPhi = 150;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 150 && Cp <= 475)
            {
                BPlo = 150;
                BPhi = 475;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 475 && Cp <= 800)
            {
                BPlo = 475;
                BPhi = 800;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 800 && Cp <= 1600)
            {
                BPlo = 800;
                BPhi = 1600;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 1600 && Cp <= 2100)
            {
                BPlo = 1600;
                BPhi = 2100;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 2100 && Cp <= 2620)
            {
                BPlo = 2100;
                BPhi = 2620;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 2620;
                BPhi = 10000;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void SO2_1Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 150)
            {
                BPlo = 0;
                BPhi = 150;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 150 && Cp <= 500)
            {
                BPlo = 150;
                BPhi = 500;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 500 && Cp <= 650)
            {
                BPlo = 500;
                BPhi = 650;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 650 && Cp <= 800)
            {
                BPlo = 650;
                BPhi = 800;
                IAQIlo = 150;
                IAQIhi = 200;
            }
        }

        private void NO2_24Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 40)
            {
                BPlo = 0;
                BPhi = 40;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 40 && Cp <= 80)
            {
                BPlo = 40;
                BPhi = 80;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 80 && Cp <= 180)
            {
                BPlo = 80;
                BPhi = 180;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 180 && Cp <= 280)
            {
                BPlo = 180;
                BPhi = 280;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 280 && Cp <= 565)
            {
                BPlo = 280;
                BPhi = 565;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 565 && Cp <= 750)
            {
                BPlo = 565;
                BPhi = 750;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 750 && Cp <= 940)
            {
                BPlo = 750;
                BPhi = 940;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 940;
                BPhi = 4000;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void NO2_1Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 100)
            {
                BPlo = 0;
                BPhi = 100;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 100 && Cp <= 200)
            {
                BPlo = 100;
                BPhi = 200;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 200 && Cp <= 700)
            {
                BPlo = 200;
                BPhi = 700;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 700 && Cp <= 1200)
            {
                BPlo = 700;
                BPhi = 1200;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 1200 && Cp <= 2340)
            {
                BPlo = 1200;
                BPhi = 2340;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 2340 && Cp <= 3090)
            {
                BPlo = 2340;
                BPhi = 3090;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 3090 && Cp <= 3840)
            {
                BPlo = 3090;
                BPhi = 3840;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 3840;
                BPhi = 15000;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void PM10_24Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 50)
            {
                BPlo = 0;
                BPhi = 50;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 50 && Cp <= 150)
            {
                BPlo = 50;
                BPhi = 150;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 150 && Cp <= 250)
            {
                BPlo = 150;
                BPhi = 250;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 250 && Cp <= 350)
            {
                BPlo = 250;
                BPhi = 350;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 350 && Cp <= 420)
            {
                BPlo = 350;
                BPhi = 420;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 420 && Cp <= 500)
            {
                BPlo = 420;
                BPhi = 500;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 500 && Cp <= 600)
            {
                BPlo = 500;
                BPhi = 600;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 600;
                BPhi = 2500;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void CO_24Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 2)
            {
                BPlo = 0;
                BPhi = 2;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 2 && Cp <= 4)
            {
                BPlo = 2;
                BPhi = 4;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 4 && Cp <= 14)
            {
                BPlo = 4;
                BPhi = 14;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 14 && Cp <= 24)
            {
                BPlo = 14;
                BPhi = 24;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 24 && Cp <= 36)
            {
                BPlo = 24;
                BPhi = 36;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 36 && Cp <= 48)
            {
                BPlo = 36;
                BPhi = 48;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 48 && Cp <= 60)
            {
                BPlo = 48;
                BPhi = 60;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 60;
                BPhi = 250;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void CO_1Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 5)
            {
                BPlo = 0;
                BPhi = 5;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 5 && Cp <= 10)
            {
                BPlo = 5;
                BPhi = 10;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 10 && Cp <= 35)
            {
                BPlo = 10;
                BPhi = 35;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 35 && Cp <= 60)
            {
                BPlo = 35;
                BPhi = 60;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 60 && Cp <= 90)
            {
                BPlo = 60;
                BPhi = 90;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 90 && Cp <= 120)
            {
                BPlo = 90;
                BPhi = 120;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 120 && Cp <= 150)
            {
                BPlo = 120;
                BPhi = 150;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 150;
                BPhi = 600;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void O3_1Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 160)
            {
                BPlo = 0;
                BPhi = 160;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 160 && Cp <= 200)
            {
                BPlo = 160;
                BPhi = 200;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 200 && Cp <= 300)
            {
                BPlo = 200;
                BPhi = 300;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 300 && Cp <= 400)
            {
                BPlo = 300;
                BPhi = 400;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 400 && Cp <= 800)
            {
                BPlo = 400;
                BPhi = 800;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 800 && Cp <= 1000)
            {
                BPlo = 800;
                BPhi = 1000;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 1000 && Cp <= 1200)
            {
                BPlo = 1000;
                BPhi = 1200;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 1200;
                BPhi = 5000;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }

        private void O3_8Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 100)
            {
                BPlo = 0;
                BPhi = 100;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 100 && Cp <= 160)
            {
                BPlo = 100;
                BPhi = 160;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 160 && Cp <= 215)
            {
                BPlo = 160;
                BPhi = 215;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 215 && Cp <= 265)
            {
                BPlo = 215;
                BPhi = 265;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 265 && Cp <= 800)
            {
                BPlo = 265;
                BPhi = 800;
                IAQIlo = 200;
                IAQIhi = 300;
            }
        }

        private void PM25_24Limit(ref int BPlo, ref int BPhi, ref int IAQIlo, ref int IAQIhi, float Cp)
        {
            if (Cp > 0 && Cp <= 35)
            {
                BPlo = 0;
                BPhi = 35;
                IAQIlo = 0;
                IAQIhi = 50;
            }
            else if (Cp > 35 && Cp <= 75)
            {
                BPlo = 35;
                BPhi = 75;
                IAQIlo = 50;
                IAQIhi = 100;
            }
            else if (Cp > 75 && Cp <= 115)
            {
                BPlo = 75;
                BPhi = 115;
                IAQIlo = 100;
                IAQIhi = 150;
            }
            else if (Cp > 115 && Cp <= 150)
            {
                BPlo = 115;
                BPhi = 150;
                IAQIlo = 150;
                IAQIhi = 200;
            }
            else if (Cp > 150 && Cp <= 250)
            {
                BPlo = 150;
                BPhi = 250;
                IAQIlo = 200;
                IAQIhi = 300;
            }
            else if (Cp > 250 && Cp <= 350)
            {
                BPlo = 250;
                BPhi = 350;
                IAQIlo = 300;
                IAQIhi = 400;
            }
            else if (Cp > 350 && Cp <= 500)
            {
                BPlo = 350;
                BPhi = 500;
                IAQIlo = 400;
                IAQIhi = 500;
            }
            else
            {
                BPlo = 500;
                BPhi = 2000;
                IAQIlo = 500;
                IAQIhi = 2000;
            }
        }
        #endregion

        //浓度、分指数
        private void SetCpIAQI(ref DataTable dtDest, int j, bool flag, float Cp, string str)
        {
            if (flag)
            {
                dtDest.Rows[j]["" + str + "浓度"] = "NA";
                if (str != "PM10_1" && str != "PM2.5_1")
                {
                    dtDest.Rows[j]["" + str + "分指数"] = "NA";
                }
            }
            else
            {
                dtDest.Rows[j]["" + str + "浓度"] = Cp.ToString("F1");
                if (str != "PM10_1" && str != "PM2.5_1")
                {
                    int IAQI = 0;

                    if (str == "SO2_1" && Cp > 800 && listSO224[j] > 0.0f)
                    {
                        IAQI = CalculateIAQI(listSO224[j], "SO2_24");
                    }
                    else
                    {
                        IAQI = CalculateIAQI(Cp, str);
                    }

                    bool flagTemp = true;
                    if (str == "O3_8" && Cp > 800)
                    {
                        foreach (string s in listPrimary)
                        {
                            if (s == "O3")
                            {
                                flagTemp = false;
                            }
                        }
                        dtDest.Rows[j]["" + str + "分指数"] = dtDest.Rows[j]["O3_1分指数"];
                    }
                    else
                    {
                        dtDest.Rows[j]["" + str + "分指数"] = IAQI.ToString();
                    }

                    if (flagTemp)
                    {
                        if (IAQI == maxIAQI)
                        {
                            listPrimary.Add(str.Substring(0, str.IndexOf('_')));
                            countPrimary++;
                        }
                        if (IAQI > maxIAQI)
                        {
                            maxIAQI = IAQI;
                            listPrimary.Add(str.Substring(0, str.IndexOf('_')));

                            while (countPrimary >= 1)
                            {
                                listPrimary.RemoveAt(0);
                                countPrimary--;
                            }
                            countPrimary = 1;
                        }
                    }
                }
            }
        }

        //首要污染物和空气质量指数的级别、类别、颜色
        private void SetClassColour(ref DataTable dtDest, int j)
        {
            if (maxIAQI >= 0 && maxIAQI <= 50)
            {
                dtDest.Rows[j]["级别"] = "一级";
                dtDest.Rows[j]["类别"] = "优";
                dtDest.Rows[j]["颜色"] = "绿色";
            }
            else if (maxIAQI > 50)
            {
                string str = "";
                foreach (string s in listPrimary)
                {
                    str = str + s + " ";
                }
                dtDest.Rows[j]["首要污染物"] = str;

                if (maxIAQI >= 51 && maxIAQI <= 100)
                {
                    dtDest.Rows[j]["级别"] = "二级";
                    dtDest.Rows[j]["类别"] = "良";
                    dtDest.Rows[j]["颜色"] = "黄色";
                }
                else if (maxIAQI >= 101 && maxIAQI <= 150)
                {
                    dtDest.Rows[j]["级别"] = "三级";
                    dtDest.Rows[j]["类别"] = "轻度污染";
                    dtDest.Rows[j]["颜色"] = "橙色";
                }
                else if (maxIAQI >= 151 && maxIAQI <= 200)
                {
                    dtDest.Rows[j]["级别"] = "四级";
                    dtDest.Rows[j]["类别"] = "中度污染";
                    dtDest.Rows[j]["颜色"] = "红色";
                }
                else if (maxIAQI >= 201 && maxIAQI <= 300)
                {
                    dtDest.Rows[j]["级别"] = "五级";
                    dtDest.Rows[j]["类别"] = "重度污染";
                    dtDest.Rows[j]["颜色"] = "紫色";
                }
                else if (maxIAQI >= 301)
                {
                    dtDest.Rows[j]["级别"] = "六级";
                    dtDest.Rows[j]["类别"] = "严重污染";
                    dtDest.Rows[j]["颜色"] = "褐红色";
                }
            }
        }

        //NA标识缺测指标的浓度、分指数
        private void SetTimeNA(ref DataTable dtDest, ref int j, ref DateTime dtBegin, DateTime dt)
        {
            while ((dtBegin.Date < dt.Date) || (dtBegin.Date == dt.Date && (dtBegin.Hour < dt.Hour || dtBegin.Hour == Convert.ToDateTime((dateEnd.Text.Trim() + " " + timeEnd.Text.Trim()).Replace('/', '-')).Hour)))
            {
                dtDest.Rows.Add(1);
                dtDest.Rows[j]["时间"] = dtBegin.ToLongDateString().ToString() + dtBegin.Hour + "时";
                dtDest.Rows[j]["SO2_1浓度"] = "NA";
                dtDest.Rows[j]["SO2_1分指数"] = "NA";
                dtDest.Rows[j]["NO2_1浓度"] = "NA";
                dtDest.Rows[j]["NO2_1分指数"] = "NA";
                dtDest.Rows[j]["PM10_1浓度"] = "NA";
                dtDest.Rows[j]["PM10_24浓度"] = "NA";
                dtDest.Rows[j]["PM10_24分指数"] = "NA";
                dtDest.Rows[j]["CO_1浓度"] = "NA";
                dtDest.Rows[j]["CO_1分指数"] = "NA";
                dtDest.Rows[j]["O3_1浓度"] = "NA";
                dtDest.Rows[j]["O3_1分指数"] = "NA";
                dtDest.Rows[j]["O3_8浓度"] = "NA";
                dtDest.Rows[j]["O3_8分指数"] = "NA";
                dtDest.Rows[j]["PM2.5_1浓度"] = "NA";
                dtDest.Rows[j]["PM2.5_24浓度"] = "NA";
                dtDest.Rows[j]["PM2.5_24分指数"] = "NA";

                if (listO38[j] > 0.0f)
                {
                    dtDest.Rows[j]["O3_8浓度"] = listO38[j].ToString("F1");
                    if (listO38[j] > 800)
                    {
                        dtDest.Rows[j]["O3_8分指数"] = dtDest.Rows[j]["O3_1分指数"];
                    }
                    else
                    {
                        int IAQI = CalculateIAQI(listO38[j], "O3_8");
                        dtDest.Rows[j]["O3_8分指数"] = IAQI.ToString();
                    }
                }
                else
                {
                    dtDest.Rows[j]["O3_8浓度"] = "NA";
                    dtDest.Rows[j]["O3_8分指数"] = "NA";
                }

                if (listPM1024[j] > 0.0f)
                {
                    int IAQI = CalculateIAQI(listPM1024[j], "PM10_24");
                    dtDest.Rows[j]["PM10_24浓度"] = listPM1024[j].ToString("F1");
                    dtDest.Rows[j]["PM10_24分指数"] = IAQI.ToString();
                }
                else
                {
                    dtDest.Rows[j]["PM10_24浓度"] = "NA";
                    dtDest.Rows[j]["PM10_24分指数"] = "NA";
                }

                if (listPM2524[j] > 0.0f)
                {
                    int IAQI = CalculateIAQI(listPM2524[j], "PM2.5_24");
                    dtDest.Rows[j]["PM2.5_24浓度"] = listPM2524[j].ToString("F1");
                    dtDest.Rows[j]["PM2.5_24分指数"] = IAQI.ToString();
                }
                else
                {
                    dtDest.Rows[j]["PM2.5_24浓度"] = "NA";
                    dtDest.Rows[j]["PM2.5_24分指数"] = "NA";
                }

                dtBegin = dtBegin.AddHours(1);
                j++;
            }
        }

        //NA标识缺测指标的浓度、分指数
        private void SetDayNA(ref DataTable dtDest, ref int j, ref DateTime dtBegin, DateTime dt)
        {
            while (dtBegin.Date < dt.Date || dtBegin.Date == Convert.ToDateTime((dateEnd.Text.Trim()).Replace('/', '-')))
            {
                dtDest.Rows.Add(1);
                dtDest.Rows[j]["时间"] = dtBegin.ToLongDateString().ToString();
                dtDest.Rows[j]["SO2_24浓度"] = "NA";
                dtDest.Rows[j]["SO2_24分指数"] = "NA";
                dtDest.Rows[j]["NO2_24浓度"] = "NA";
                dtDest.Rows[j]["NO2_24分指数"] = "NA";
                dtDest.Rows[j]["PM10_24浓度"] = "NA";
                dtDest.Rows[j]["PM10_24分指数"] = "NA";
                dtDest.Rows[j]["CO_24浓度"] = "NA";
                dtDest.Rows[j]["CO_24分指数"] = "NA";
                dtDest.Rows[j]["O3_1浓度"] = "NA";
                dtDest.Rows[j]["O3_1分指数"] = "NA";
                dtDest.Rows[j]["PM2.5_24浓度"] = "NA";
                dtDest.Rows[j]["PM2.5_24分指数"] = "NA";

                if (listO38[j] > 0.0f)
                {
                    dtDest.Rows[j]["O3_8浓度"] = listO38[j].ToString("F1");
                    if (listO38[j] > 800)
                    {
                        dtDest.Rows[j]["O3_8分指数"] = dtDest.Rows[j]["O3_1分指数"];
                    }
                    else
                    {
                        int IAQI = CalculateIAQI(listO38[j], "O3_8");
                        dtDest.Rows[j]["O3_8分指数"] = IAQI.ToString();
                    }
                }
                else
                {
                    dtDest.Rows[j]["O3_8浓度"] = "NA";
                    dtDest.Rows[j]["O3_8分指数"] = "NA";
                }

                dtBegin = dtBegin.AddDays(1);
                j++;
            }
        }

        private static AQIReport ARForm;

        public static AQIReport GetForm(int type)
        {
            if (ARForm == null || ARForm.IsDisposed)
            {
                ARForm = new AQIReport(type);
            }
            return ARForm;
        }
    }
}
