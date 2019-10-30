using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace ScheduleService
{
    partial class ScheduleService : ServiceBase
    {

        #region Declarations
        string StatusDate;
        string LastWeekStatus;
        Timer tmr = new Timer();

        DataTable dtmktgdata = new DataTable();
        DataTable dtItems = new DataTable();
        DataRow drItems;

        DataTable dtSMSData = new DataTable();
        DataTable dtItemsSMS = new DataTable();
        DataRow drItemsSMS;
        bool mailFlag = false;
        string C_Emailid = "";//EncryptDecryptCL.Decrypt("UoqRTj4o8a/wzcp4+MCz2Tk7rCKCqNOQNSNN3idj9/EClLIt8FFKUqQhI2UsPlzN").ToString(); //rz
        string C_EmailCC = string.Empty; //  Encryptor.Decrypt("usweXnjEuLrzifgFut092evP5iAxRPea2KcxI3/qSYgo9IYl0bLdEXVTE6P0PvnjnmaqVe6XvkdMED26rKPaWg==").ToString(); //kvb
        #endregion

        #region Events
        public ScheduleService()
        {
            InitializeComponent();

            var sad = Tools.ConvertListToDataTable("");
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        } 
        #endregion


    }
}
