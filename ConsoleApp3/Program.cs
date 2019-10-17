using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Language1 lan1 = new Language1();
            Console.WriteLine(lan1.changeLang["CHT"]["lblRegister"]);
            Console.WriteLine(lan1.changeLang["CHS"]["lblRegister"]);

            var x1 = lan1.changeLang["CHT"]["lblRegister"];

            Language lan = new Language();

            Language.lang lang = new Language.lang();
            var y = lang.GetType().GetProperty("CHT").GetValue(lan.changeLang["lblRegister"]);
            Console.WriteLine(y);
        }
    }

    internal class Language1
    {
        public Dictionary<string, Dictionary<string, string>> changeLang;

        public Language1()
        {
            string chtJson = @"{
                'lblRegister':'訪客登記',
                'lblReserve':'預約登記'
            }";
            string chsJson = @"{
                'lblRegister':'訪客登記XX',
                'lblReserve':'預約登記'
            }";

            var cht = JsonConvert.DeserializeObject<Dictionary<string, string>>(chtJson);
            var chs = JsonConvert.DeserializeObject<Dictionary<string, string>>(chsJson);

            var data = cht.Where(a => a.Key == "");
            changeLang = new Dictionary<string, Dictionary<string, string>>()
            {
                {"CHT", cht},
                {"CHS", chs},
                {"ENG",cht },
            };
        }
    }

    public class Language
    {
        public Dictionary<string, lang> changeLang = new Dictionary<string, lang>()
        {
            //MasterPage
            {"lblRegister",new lang() {CHT="訪客登記",ENG="Register",CHS="访客登记" }},
            {"lblReserve",new lang() {CHT="預約登記",ENG="Reserve",CHS="预约登记" }},
            {"lblQueryRecord",new lang() {CHT="查詢紀錄",ENG="Record",CHS="查询纪录" }},
            {"lblSetting",new lang() {CHT="設定",ENG="Setting",CHS="设定" }},
            //Register
            {"btnCreateRegister",new lang() {CHT="建立新登記",ENG="Create Register",CHS="建立新登记" }},
            {"btnScanQRCode",new lang() {CHT="掃碼離開",ENG="Scan QRCode",CHS="扫码离开" }},
            {"btnQuery",new lang() {CHT="查詢",ENG="Query",CHS="查询" }},
            {"lblGuestNo",new lang() {CHT="登記證號",ENG="Guest No",CHS="登记证号" }},
            {"lblVisitor",new lang() {CHT="參訪人",ENG="Visitor",CHS="参访人" }},
            {"lblInterviewee",new lang() {CHT="受訪人",ENG="Interviewee",CHS="受访人" }},
            {"lblVisitorCompany",new lang() {CHT="參訪者公司",ENG="Visitor Company",CHS="参访者公司" }},
            {"lblVisitorCount",new lang() {CHT="參訪人數",ENG="Visitor Count",CHS="参访人数" }},
            {"lblStartTime",new lang() {CHT="拜訪時間",ENG="Start Time",CHS="拜访时间" }},
            {"lblEndTime",new lang() {CHT="離開時間",ENG="End Time",CHS="离开时间" }},
            {"lblPhone",new lang() {CHT="電話",ENG="Phone",CHS="电话" }},
            {"lblMail",new lang() {CHT="信箱",ENG="Mail",CHS="信箱" }},
            {"lblCustID",new lang() {CHT="代碼",ENG="Cust ID",CHS="代码" }},
            {"lblSite",new lang() {CHT="據點",ENG="Site",CHS="据点" }},
            {"lblDocumentType",new lang() {CHT="證件種類",ENG="Document Type",CHS="证件种类" }},
            {"lblRemark",new lang() {CHT="備註",ENG="Remark",CHS="备注" }},
            {"lblDocumentPosition",new lang() {CHT="證件放置位置",ENG="Document Position",CHS="证件放置位置" }},
            {"btnRegister",new lang() {CHT="登記",ENG="Register",CHS="登记" }},
            {"btnRegister_1",new lang() {CHT="儲存",ENG="Submit",CHS="储存" }},
            {"btnClose",new lang() {CHT="結案",ENG="Close",CHS="结案" }},
            {"btnPrint",new lang() {CHT="列印",ENG="Print",CHS="列印" }},
            {"lblQueryFail_1",new lang() {CHT="請輸入查詢條件",ENG="Input GuestNo",CHS="请输入查询条件" }},
            {"lblQueryFail_2",new lang() {CHT="訪客證號最少請輸入7碼!(ex:GUESTXX)",ENG="GuestNo At Least 7 (ex:GUESTXX)",CHS="访客证号最少请输入7码!(ex:GUESTXX)" }},
            {"lblQueryFail_3",new lang() {CHT="查無資料!",ENG="Not found!",CHS="查无资料!" }},
            {"lblErrmsg_1",new lang() {CHT="儲存成功!",ENG="Submit Successful!",CHS="储存成功!" }},
            {"lblErrmsg_2",new lang() {CHT="儲存成功! 預約單已結案!",ENG="Submit Successful! Reserve Close!",CHS="储存成功! 预约单已结案!" }},
            {"lblErrmsg_3",new lang() {CHT="結案成功!",ENG="Close Successful!",CHS="结案成功!" }},
            //Reserve
            {"btnCreateReserve",new lang() {CHT="建立新預約",ENG="Create Reserve",CHS="建立新预约" }},
            {"lblGuestNo_1",new lang() {CHT="預約證號",ENG="Guest No",CHS="预约证号" }},
            {"lblStartTime_1",new lang() {CHT="預計拜訪時間",ENG="Estimate Start Time",CHS="预计拜访时间" }},
            {"lblEndTime_1",new lang() {CHT="預計離開時間",ENG="Estimate End Time",CHS="预计离开时间" }},
            {"btnReserve",new lang() {CHT="預約",ENG="Reserve",CHS="预约" }},
            {"btnReserve_1",new lang() {CHT="儲存",ENG="Submit",CHS="储存" }},
            {"btnReserveToRegister",new lang() {CHT="預約轉登記",ENG="To Register",CHS="预约转登记" }},
            //QueryRecord
            {"lblQueryRecordTitle",new lang() {CHT="訪客紀錄",ENG="Visitor Record",CHS="访客纪录" }},
            {"lblGuestNo_2",new lang() {CHT="訪客證號",ENG="Guest No",CHS="访客证号" }},
            {"btnExport",new lang() {CHT="匯出",ENG="Export",CHS="汇出" }},
            {"lblQueryResults_1",new lang() {CHT="請輸入正確日期!",ENG="Wrong Date Format!",CHS="請輸入正確日期!" }},
            {"CheckBoxReserve",new lang() {CHT="預約資料",ENG="Reserve Data",CHS="预约资料" }},
            {"CheckBoxRegister",new lang() {CHT="登記資料",ENG="Register Data",CHS="登记资料" }},
            {"CheckBoxActiveY",new lang() {CHT="已結案",ENG="Closed",CHS="已结案" }},
            {"CheckBoxActiveN",new lang() {CHT="未結案",ENG="Unclosed",CHS="未结案" }},

            //Datatable Column Name
            {"GuestNo",new lang() {CHT="證號",ENG="GuestNo",CHS="证号" }},
            {"Action",new lang() {CHT="單別",ENG="Action",CHS="单别" }},
            {"SourceGuestNo",new lang() {CHT="來源單號",ENG="SourceGuestNo",CHS="来源单号" }},
            {"Visitor",new lang() {CHT="參訪人",ENG="Visitor",CHS="参访人" }},
            {"Interviewee",new lang() {CHT="受訪人",ENG="Interviewee",CHS="受访人" }},
            {"VisitorCompany",new lang() {CHT="參訪者公司",ENG="Visitor Company",CHS="参访者公司" }},
            {"VisitorCount",new lang() {CHT="參訪人數",ENG="Visitor Count",CHS="参访人数" }},
            {"StartTime",new lang() {CHT="拜訪時間",ENG="StartTime",CHS="拜访时间" }},
            {"EndTime",new lang() {CHT="離開時間",ENG="EndTime",CHS="离开时间" }},
            {"Phone",new lang() {CHT="電話",ENG="Phone",CHS="电话" }},
            {"Mail",new lang() {CHT="信箱",ENG="Mail",CHS="信箱" }},
            {"CustId",new lang() {CHT="代碼",ENG="Cust ID",CHS="代码" }},
            {"Site",new lang() {CHT="據點",ENG="Site",CHS="据点" }},
            {"DocumentType",new lang() {CHT="證件種類",ENG="DocumentType",CHS="证件种类" }},
            {"Remark",new lang() {CHT="備註",ENG="Remark",CHS="备注" }},
            {"DocumentPosition",new lang() {CHT="證件放置位置",ENG="DocumentPosition",CHS="证件放置位置" }},
            {"Photo",new lang() {CHT="照片路徑",ENG="PhotoPath",CHS="照片路径" }},
            {"Active",new lang() {CHT="已結案",ENG="Active",CHS="已结案" }},
        };

        public class lang
        {
            public string CHT { get; set; }
            public string CHS { get; set; }
            public string ENG { get; set; }
        };
    }
}