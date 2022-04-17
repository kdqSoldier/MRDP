using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;



namespace MRDP
{
    class excelways
    {
        //excel输出生成模块
        public void saveexcel(string path)
        {
            Application oApp = new Application(); ;
            _Workbook oWbook;
            _Worksheet oWSheet1;
            path = parameter.path + constant.pathname;
            oApp.Visible = true;
            oWbook = (_Workbook)(oApp.Workbooks.Add());
            for (int i = 0; i < parameter.dict_hz.Count; i++)
            {
                string point = parameter.dict_hz.ElementAt(i).Key;
                oWSheet1 = (_Worksheet)oWbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                oWSheet1.Name = point;
                headerone(oWSheet1, point);
                saveone(oWSheet1, point);
                headertwo(oWSheet1, point);
                savetwo(oWSheet1, point);
            }
            //oWbook.SaveAs(path);
            
        }
        public void headerone(_Worksheet _sheet, string point)
        {            
            //1
            Range range = _sheet.Range[_sheet.Cells[1, 1], _sheet.Cells[1, 14]];
            rangst(range, "全站仪外业观测手簿", 14);
            //
            range = _sheet.Range[_sheet.Cells[2, 1], _sheet.Cells[2, 2]];
            rangst(range, "观测日期：");
            //
            range = _sheet.Range[_sheet.Cells[2, 3], _sheet.Cells[2, 5]];
            rangst(range, parameter.list_header[parameter.dict_header[point]].data_year);
            //
            range = _sheet.Range[_sheet.Cells[2, 6], _sheet.Cells[2, 6]];
            rangst(range, "天气：");
            //
            range = _sheet.Range[_sheet.Cells[2, 7], _sheet.Cells[2, 8]];
            rangst(range, "");
            //
            range = _sheet.Range[_sheet.Cells[2, 9], _sheet.Cells[2, 9]];
            rangst(range, "成像：");
            //
            range = _sheet.Range[_sheet.Cells[2, 10], _sheet.Cells[2, 11]];
            rangst(range, "");
            //
            range = _sheet.Range[_sheet.Cells[2, 12], _sheet.Cells[2, 12]];
            rangst(range, "仪器：");
            //
            range = _sheet.Range[_sheet.Cells[2, 13], _sheet.Cells[2, 14]];
            rangst(range, parameter.list_header[parameter.dict_header[point]].other);

            //2
            range = _sheet.Range[_sheet.Cells[3, 1], _sheet.Cells[3, 2]];
            rangst(range, "测站点名：");
            //
            range = _sheet.Range[_sheet.Cells[3, 3], _sheet.Cells[3, 5]];
            rangst(range, parameter.list_header[parameter.dict_header[point]].point);
            //
            range = _sheet.Range[_sheet.Cells[3, 6], _sheet.Cells[3, 6]];
            rangst(range, "开始时间：");
            //
            range = _sheet.Range[_sheet.Cells[3, 7], _sheet.Cells[3, 8]];
            rangst(range, parameter.list_header[parameter.dict_header[point]].data_h);
            //
            range = _sheet.Range[_sheet.Cells[3, 9], _sheet.Cells[3, 9]];
            rangst(range, "结束时间：");
            //
            range = _sheet.Range[_sheet.Cells[3, 10], _sheet.Cells[3, 11]];
            rangst(range, parameter.list_header[parameter.dict_header[point]].data_h);
            //
            range = _sheet.Range[_sheet.Cells[3, 12], _sheet.Cells[3, 12]];
            rangst(range, "仪器高：");
            //
            range = _sheet.Range[_sheet.Cells[3, 13], _sheet.Cells[3, 14]];
            rangst(range, parameter.list_header[parameter.dict_header[point]].equipmentHi);
            //34
            //
            range = _sheet.Range[_sheet.Cells[4, 1], _sheet.Cells[5, 1]];
            rangst(range, "测回：");
            //  
            range = _sheet.Range[_sheet.Cells[4, 2], _sheet.Cells[5, 2]];
            rangst(range, "目标点名：");
            //  
            range = _sheet.Range[_sheet.Cells[4, 3], _sheet.Cells[5, 3]];
            rangst(range, "盘位：");
            //  
            //range = _sheet.Range[_sheet.Cells[4, 14], _sheet.Cells[5, 14]];
            //rangst(range, "备注：");

            for (int i = 0; i < constant.dat.Count(); i++)
            {
                range = _sheet.Range[_sheet.Cells[4, 4 + i], _sheet.Cells[4, 4 + i]];
                rangst(range, constant.dat[i], 10.5, false);
                range = _sheet.Range[_sheet.Cells[5, 4 + i], _sheet.Cells[5, 4 + i]];
                rangst(range, constant.dat_[i], 10.5, false);
            }
            range = _sheet.Range[_sheet.Cells[4, 14], _sheet.Cells[5, 14]];
            rangst(range, "备注：");
        }
        public void headertwo(_Worksheet _sheet, string point)
        {
            int guancezhi = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            int row = 5 + guancezhi * cehuishu * 2 + 2;
            //  

            //1
            Range range = _sheet.Range[_sheet.Cells[row, 1], _sheet.Cells[row, 14]];
            rangst(range, "统计结果", 14);
            //
            range = _sheet.Range[_sheet.Cells[row + 1, 1], _sheet.Cells[row + 2, 1]];
            rangst(range, "序号");
            range = _sheet.Range[_sheet.Cells[row + 1, 2], _sheet.Cells[row + 2, 3]];
            rangst(range, "目标点名");
            range = _sheet.Range[_sheet.Cells[row + 1, 4], _sheet.Cells[row + 1, 5]];
            rangst(range, "归零方向均值");
            range = _sheet.Range[_sheet.Cells[row + 2, 4], _sheet.Cells[row + 2, 5]];
            rangst(range, "(° ′ ″)");
            range = _sheet.Range[_sheet.Cells[row + 1, 6], _sheet.Cells[row + 1, 7]];
            rangst(range, "天顶角均值");
            range = _sheet.Range[_sheet.Cells[row + 2, 6], _sheet.Cells[row + 2, 7]];
            rangst(range, "(° ′ ″)");
            range = _sheet.Range[_sheet.Cells[row + 1, 8], _sheet.Cells[row + 1, 9]];
            rangst(range, "斜距均值");
            range = _sheet.Range[_sheet.Cells[row + 2, 8], _sheet.Cells[row + 2, 9]];
            rangst(range, "( m )");
            range = _sheet.Range[_sheet.Cells[row + 1, 10], _sheet.Cells[row + 1, 11]];
            rangst(range, "平距均值");
            range = _sheet.Range[_sheet.Cells[row + 2, 10], _sheet.Cells[row + 2, 11]];
            rangst(range, "( m )");
            range = _sheet.Range[_sheet.Cells[row + 1, 12], _sheet.Cells[row + 1, 12]];
            rangst(range, "高差");
            range = _sheet.Range[_sheet.Cells[row + 2, 12], _sheet.Cells[row + 2, 12]];
            rangst(range, "( m )");
            range = _sheet.Range[_sheet.Cells[row + 1, 13], _sheet.Cells[row + 1, 13]];
            rangst(range, "觇标高");
            range = _sheet.Range[_sheet.Cells[row + 2, 13], _sheet.Cells[row + 2, 13]];
            rangst(range, "( m )");
            range = _sheet.Range[_sheet.Cells[row + 1, 14], _sheet.Cells[row + 2, 14]];
            rangst(range, "备注");

        }
        public void saveone(_Worksheet _sheet, string point)
        {
            int guancezhi = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            int row = 6;

            //1
            int row_ = row;
            for (int i = 1; i <= cehuishu; i++)
            {
                Range range = _sheet.Range[_sheet.Cells[row_, 1], _sheet.Cells[row_+guancezhi*2-1, 1]];
                rangst(range, i.ToString());
                for (int j = 0; j < guancezhi; j++)
                {
                    range = _sheet.Range[_sheet.Cells[row_, 2], _sheet.Cells[row_ + 1, 2]];
                    rangst(range, parameter.list_hz[parameter.dict_hz[point]].data_hz[i - 1].point_[j]);

                    range = _sheet.Range[_sheet.Cells[row_, 3], _sheet.Cells[row_, 3]];
                    rangst(range, constant.datshow[0], 10.5, false);
                    range = _sheet.Range[_sheet.Cells[row_ + 1, 3], _sheet.Cells[row_ + 1, 3]];
                    rangst(range, constant.datshow[1], 10.5, false);

                    ////**************************
                    range = _sheet.Range[_sheet.Cells[row_, 4], _sheet.Cells[row_, 4]];
                    rangst(range, parameter.list_hz[parameter.dict_hz[point]].data_hz[i - 1].dat_l[j], 10.5, false);
                    range = _sheet.Range[_sheet.Cells[row_ + 1, 4], _sheet.Cells[row_ + 1, 4]];
                    rangst(range, parameter.list_hz[parameter.dict_hz[point]].data_hz[i - 1].dat_r[j], 10.5, false);

                    range = _sheet.Range[_sheet.Cells[row_, 5], _sheet.Cells[row_ + 1, 5]];
                    rangst(range, parameter.list_hzout[parameter.dict_hz[point]].list_dat[i - 1].dat_2c[j]);

                    range = _sheet.Range[_sheet.Cells[row_, 6], _sheet.Cells[row_ + 1, 6]];
                    rangst(range, parameter.list_hzout[parameter.dict_hz[point]].list_dat[i - 1].dat_Average[j]);

                    ////******************************
                    range = _sheet.Range[_sheet.Cells[row_, 7], _sheet.Cells[row_, 7]];
                    rangst(range, parameter.list_v[parameter.dict_v[point]].data_v[i - 1].dat_l[j], 10.5, false);
                    range = _sheet.Range[_sheet.Cells[row_ + 1, 7], _sheet.Cells[row_ + 1, 7]];
                    rangst(range, parameter.list_v[parameter.dict_v[point]].data_v[i - 1].dat_r[j], 10.5, false);

                    range = _sheet.Range[_sheet.Cells[row_, 8], _sheet.Cells[row_ + 1, 8]];
                    rangst(range, parameter.list_vout[parameter.dict_v[point]].list_dat[i - 1].dat_i[j]);

                    range = _sheet.Range[_sheet.Cells[row_, 9], _sheet.Cells[row_ + 1, 9]];
                    rangst(range, parameter.list_vout[parameter.dict_v[point]].list_dat[i - 1].dat_Zenith[j]);

                    ////**************************
                    range = _sheet.Range[_sheet.Cells[row_, 10], _sheet.Cells[row_, 10]];
                    rangst(range, parameter.list_dist[parameter.dict_dist[point]].data_dist[i - 1].dat_l[j], 10.5, false);
                    range = _sheet.Range[_sheet.Cells[row_ + 1, 10], _sheet.Cells[row_ + 1, 10]];
                    rangst(range, parameter.list_dist[parameter.dict_dist[point]].data_dist[i - 1].dat_r[j], 10.5, false);

                    range = _sheet.Range[_sheet.Cells[row_, 11], _sheet.Cells[row_ + 1, 11]];
                    rangst(range, parameter.list_distout[parameter.dict_dist[point]].list_dat[i - 1].dat_poor[j]);

                    range = _sheet.Range[_sheet.Cells[row_, 12], _sheet.Cells[row_ + 1, 12]];
                    rangst(range, parameter.list_distout[parameter.dict_dist[point]].list_dat[i - 1].dat_draw[j]);

                    range = _sheet.Range[_sheet.Cells[row_, 13], _sheet.Cells[row_ +1, 13]];
                    rangst(range, "0.0000");

                    row_++;
                    row_++;
                }
            }
            Range range1 = _sheet.Range[_sheet.Cells[row, 14], _sheet.Cells[row_-1, 14]];
            rangst(range1, "");
        }
        public void savetwo(_Worksheet _sheet, string point)
        {

            int guancezhi = int.Parse(parameter.list_header[parameter.dict_header[point]].surveysets);
            int cehuishu = int.Parse(parameter.list_header[parameter.dict_header[point]].period_Num);
            int row = 5 + guancezhi * cehuishu * 2 +1+ 4;
            for (int j = 0; j < guancezhi; j++)
            {
                double dat1 = 0, dat2 = 0, dat3 = 0, dat4 = 0, dat5 = 0;
                for (int i = 0; i < cehuishu; i++)
                {
                    dat1 += double.Parse(parameter.list_hzout[parameter.dict_hz[point]].list_dat[i].dat_Average[j]);
                    dat2 += double.Parse(parameter.list_vout[parameter.dict_v[point]].list_dat[i].dat_Zenith[j]);
                    dat3 += double.Parse(parameter.list_distout[parameter.dict_dist[point]].list_dat[i].dat_slant[j]);
                    dat4 += double.Parse(parameter.list_distout[parameter.dict_dist[point]].list_dat[i].dat_draw[j]);
                    dat5 += double.Parse(parameter.list_distout[parameter.dict_dist[point]].list_dat[i].dat_Elevation[j]);
                }


                Range range = _sheet.Range[_sheet.Cells[row + j, 1], _sheet.Cells[row + j, 1]];
                rangst(range, j.ToString(), 10.5, false);

                range = _sheet.Range[_sheet.Cells[row + j, 2], _sheet.Cells[row + j, 3]];
                rangst(range, parameter.list_hz[parameter.dict_hz[point]].data_hz[j].point_[j]);

                range = _sheet.Range[_sheet.Cells[row + j, 4], _sheet.Cells[row + j, 5]];
                rangst(range, (dat1 / cehuishu).ToString());

                range = _sheet.Range[_sheet.Cells[row + j, 6], _sheet.Cells[row + j, 7]];
                rangst(range, (dat2 / cehuishu).ToString());

                range = _sheet.Range[_sheet.Cells[row + j, 8], _sheet.Cells[row + j, 9]];
                rangst(range, (dat3 / cehuishu).ToString());

                range = _sheet.Range[_sheet.Cells[row + j, 10], _sheet.Cells[row + j, 11]];
                rangst(range, (dat4 / cehuishu).ToString());

                range = _sheet.Range[_sheet.Cells[row + j, 12], _sheet.Cells[row + j, 12]];
                rangst(range, (dat5 / cehuishu).ToString(), 10.5, false);

                range = _sheet.Range[_sheet.Cells[row + j, 13], _sheet.Cells[row + j, 13]];
                rangst(range, "0.0000", 10.5, false);
            }
            Range range1 = _sheet.Range[_sheet.Cells[row, 14], _sheet.Cells[row +guancezhi-1, 14]];
            rangst(range1, "考虑球气差");
        }
        public void rangst(Range range, string text, double size = 10.5, bool mar = true)
        {
            range.Font.Size = size;
            range.ColumnWidth = 10;
            range.RowHeight = 15;
            if (size != 10.5)
            {
                range.Font.Bold = true;
            }
            range.MergeCells = true;
            range.Value = text;
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = XlVAlign.xlVAlignCenter;
            if (mar)
            {
                range.Merge();
            }
            range.Borders.LineStyle = 1;
            range.Font.Size = size;
            range.ColumnWidth = 10;
            range.RowHeight = 15;
        }
    }
}
