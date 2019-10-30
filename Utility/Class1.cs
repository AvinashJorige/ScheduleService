 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class Class1
    {
        #region
        private void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int SchID = 0;
            string Schflg = "";
            int flgL = 0;
            try
            {
                DataTable dtgetSchedules = getSchedules();
                foreach (DataRow drgetSchedules in dtgetSchedules.Rows)
                {
                    int i_ScheduleId = Convert.ToInt32(drgetSchedules["ScheduleId"]);
                    int i_ScheduleTId = 0;
                    switch (i_ScheduleId)
                    {
                        case 1:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Employee Creation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            EmpCreation();
                            WriteLog(0, "Employee Creation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            SendMail(C_Emailid, "Employee Creation Schedule has executed successfully", "Employee Creation Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 2:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Employee Updation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            EmpUpdation();
                            WriteLog(0, "Employee Updation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            WriteLog(0, "Marketing Employee Customer Creation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            custcreation();
                            WriteLog(0, "Marketing Employee Customer Creation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            SendMail(C_Emailid, "Employee Updation Schedule has executed successfully", "Employee Updation Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 3:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Asset Installation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            AssetInstallation();
                            WriteLog(0, "Asset Installation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            //SendMail(C_Emailid, "Asset Installation Schedule has executed successfully", "Asset Installation Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 4:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Weekly Attendance Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            WeeklyAttendanceMail();
                            WriteLog(0, "Weekly Attendance Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            //SendMail(C_Emailid, "Weekly Attendance Mail Schedule has executed successfully", "Weekly Attendance Mail Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 5:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Approvals List Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            ApprovalsList();
                            try
                            {
                                PRAAlertMailer();
                            }
                            catch { }
                            WriteLog(0, "Approvals List Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            //SendMail(C_Emailid, "Daily Approval(s) / Pending list Mail Schedule has executed successfully", "Daily Approval(s) / Pending list Mail Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 6:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Errors Report Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            ErrorsReport();
                            WriteLog(0, "Errors Report Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 7:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Automatic Attendance Updation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            AutomaticAttendanceUpdation();
                            WriteLog(0, "Automatic Attendance Updation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            //SendMail(C_Emailid, "Automatic Attendance Updation Mail Schedule has executed successfully", "Automatic Attendance Updation Mail Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 8:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Application Mails Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            ApplicationMails();
                            WriteLog(0, "Application Mails Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            SendMail(C_Emailid, "Application Mail Schedule has executed successfully", "Application Mail Schedule has executed successfully", "0", "0", "0");
                            break;
                        case 9:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "SendSMS Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            SendSMS();
                            WriteLog(0, "SendSMS Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 10:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "sendSalesSMS Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            sendSalesSMS();
                            WriteLog(0, "sendSalesSMS Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            SendMail(C_Emailid, "Daily sales SMS Schedule has been executed successfully", "Daily sales SMS Schedule has been executed successfully", "0", "0", "");
                            break;
                        case 11:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "SendSTNSMS Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            SendSTNSMS();
                            WriteLog(0, "SendSTNSMS Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            //SendMail(C_Emailid, "Daily sales STN Schedule has been executed successfully", "Daily sales STN Schedule has been executed successfully", "0", "0", "0");
                            break;
                        case 12:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Send SMS Report Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            //System.Threading.Thread.Sleep(120000);//Delay of 120 Sec.
                            GetSentSMS();
                            WriteLog(0, "Send SMS Report Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            //SendMail(C_Emailid, "Daily sales SMS Schedule has been executed successfully", "Daily sales SMS Schedule has been executed successfully", "0", "0", "");
                            break;
                        case 13:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "AutoAttUpdBasedonShftChngs Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            AutoAttUpdBasedonShiftChanges();
                            WriteLog(0, "AutoAttUpdBasedonShftChngs Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 14:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "AutomaticShiftUpdate Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            AutomaticShiftUpdate();
                            WriteLog(0, "AutomaticShiftUpdate Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 15:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Stability Test Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            StabilityTest();
                            WriteLog(0, "Stability Test Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 16:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "QA Validation/Calibration Test Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            TrackerUpload();
                            WriteLog(0, "QA Validation/Calibration Test Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 17:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Send Helpdesk Escalation Mails Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            SendHelpDeskTicketMail();
                            WriteLog(0, "Send Helpdesk Escalation Mails Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            //SendMail(C_Emailid, "Helpdesk Escalation Mails has been sent successfully", "Helpdesk Escalation Mails has been sent successfully", "0", "0", "0");
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 18:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Prod. Dash. Data Upload Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            getPPDBData();
                            WriteLog(0, "Prod. Dash. Data Upload Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            WriteLog(0, "Send Legal compliance Reminder Mail Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            LegalCompRemMail();
                            WriteLog(0, "Send Legal compliance Reminder Mail Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            //SendMail(C_Emailid, "LEGAL COMPLIANCE REMINDER MAIL", "LC Mail Executed successfully.", "0", "0", "0");
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;

                        case 19:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Send Retest Mails Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            Retestmaterialalertmaildetails();
                            WriteLog(0, "Send Retest Mails Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            //SendMail(C_Emailid, "Retest Mails has been sent successfully", "Retest Mails has been sent successfully", "0", "0", "0");
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 20:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "E-Commerce and Promotional LR Updation Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            OnlineTransUpd(1);
                            WriteLog(0, "Order To Invoice Strated." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            OrdertoInvoiceProcess();

                            WriteLog(0, "Order To Invoice Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            WriteLog(0, "Promo/Samples details updation Strated." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            PromoDetailsUpdatation();
                            WriteLog(0, "Promo/Samples details updation Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            try
                            {
                                LRDet();
                            }
                            catch { }
                            WriteLog(0, "E-Commerce and Promotional LR Updation Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            //SendMail(C_Emailid, "Starvac LR Updation", "Starvac LR Updation executed successfully.", "0", "0", "0");
                            WriteLog(0, "Messenger secret PIN no SMS Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            GetInvoice();
                            WriteLog(0, "Messenger secret PIN no SMS Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 21:
                            if (1 == 1)
                            {
                                i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                                WriteLog(0, "BO Sales Data Schedule Start." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                try
                                {
                                    GetProductwiseBudget("PB"); //For Budget 
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(0, "--------------BO Sales Data PB. :-" + ex.Message + "--**--" + ex.Source);
                                }
                                try
                                {
                                    GetProductwiseBudget("SS"); // For Sales
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(0, "--------------BO Sales Data SS :-" + ex.Message + "--**--" + ex.Source);
                                }
                                try
                                {
                                    GetProductwiseBudget("PY"); // For payroll
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(0, "--------------BO Sales Data PY :-" + ex.Message + "--**--" + ex.Source);
                                }
                                try
                                {
                                    GetProductwiseBudget("PS"); // For Sales
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(0, "--------------BO Sales Data PS :-" + ex.Message + "--**--" + ex.Source);
                                }
                                try
                                {
                                    GetOutstanding();
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(0, "--------------BO Sales Data Get O/S :-" + ex.Message + "--**--" + ex.Source);
                                }
                                try
                                {
                                    WriteLog(0, "----------------------------BO Sales Data HQ Schedule Start." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                    GetProductwiseBudget("HQ"); // For HQ wise Sales
                                    WriteLog(0, "----------------------------BO Sales Data HQ Schedule End." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(0, "--------------BO HQ wise Sales :-" + ex.Message + "--**--" + ex.Source);
                                }
                                WriteLog(0, "BO Sales Data Schedule Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                //SendMail(C_Emailid, "BO Sales Data Schedule", "BO Sales Data Schedule executed successfully.", "0", "0", "0");
                                i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            }
                            break;
                        case 22:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Send Promotional Material LR SMS Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            SendPromoSMS();
                            WriteLog(0, "Send Promotional Material LR SMS Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            //SendMail(C_Emailid, "Promotional Material LR SMS", "Promotional Material LR SMS executed successfully.", "0", "0", "0");
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 23:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "AS Customer Creation from SAP to AS.com DB Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            ASUpdateCustomer(); //Daily Once
                            WriteLog(0, "AS Customer Creation from SAP to AS.com DB Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            flgL = 3;
                            for (int i = 2; i <= flgL; i++)
                            {
                                WriteLog(0, "Update Empmaster from IIlHome to AS.com DB Started._" + i.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                UpdateEmpsfromNewIILhometoAS(i);
                                WriteLog(0, "Update Empmaster from IIlHome to AS.com DB Ended._" + i.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                //SendMail(C_Emailid, "Promotional Material LR SMS", "Promotional Material LR SMS executed successfully.", "0", "0", "0");
                            }
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 24:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            flgL = 3;
                            for (int i = 2; i <= flgL; i++)
                            {
                                WriteLog(0, "Send AS LR Updation Started._" + i.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                OnlineTransUpd(i);
                                WriteLog(0, "Send AS LR Updation Ended._" + i.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                //SendMail(C_Emailid, "Starvac LR Updation", "Starvac LR Updation executed successfully.", "0", "0", "0");
                            }
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 25:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            flgL = 3;
                            for (int i = 2; i <= flgL; i++)
                            {
                                WriteLog(0, "Update SMS from AS to Newiilhome Started._" + i.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                UpdateASDataForMailsANDemps(i);
                                WriteLog(0, "Update SMS from AS to Newiilhome Ended._" + i.ToString() + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            }
                            //SendMail(C_Emailid, "Starvac LR Updation", "Starvac LR Updation executed successfully.", "0", "0", "0");
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 26:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Update opening balance and availability of products Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            GetOPBal();
                            WriteLog(0, "Update opening balance and availability of products Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 27:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "GRN STN Update in BO DB Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            GetGRNStnData();
                            WriteLog(0, "GRN STN Update in BO DB Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 28:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Sending QA Document Review Reminder Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            QADocumentReviewReminder();
                            WriteLog(0, "Sending QA Document Review Reminder Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 29:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "Engineering Helpdesk - send reminder mail Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            EnggHlpDskMailAlert();
                            WriteLog(0, "Engineering Helpdesk - send reminder mail Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 30:
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "I"); SchID = i_ScheduleTId; Schflg = "I";
                            WriteLog(0, "AMC Review reminder mail Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            AMCReviewReminder();
                            WriteLog(0, "AMC Review reminder mail Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            i_ScheduleTId = setScheduleStatus(i_ScheduleId, i_ScheduleTId, "U"); SchID = i_ScheduleTId; Schflg = "U";
                            break;
                        case 31:
                            WriteLog(0, "PRA details get Updated started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            GetPraDet();
                            WriteLog(0, "PRA details get Updated Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            WriteLog(0, "License Management Mails sending." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            LMSLicenseExpiryMail();
                            WriteLog(0, "License Management Mails sent." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                SendMail(C_Emailid, "OOPS! An error in the Schedule ID" + SchID.ToString() + "at " + Schflg, "Exception :" + ex.Message + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), "0", "0", "0");
            }
        }
#endregion

        #region Functions


        private DataTable getSchedules()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsgetSchedules = new DataSet();
            try
            {
                mycommand = new SqlCommand("Usp_Service_getSchedules", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter mygetSchedulesAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                mygetSchedulesAdapter.Fill(dsgetSchedules, "getSchedules");
                mycommand.Connection.Close();
                return dsgetSchedules.Tables[0];
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Get Schedules---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return null;
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        private void WriteLog(int i_error, string s_message)
        {
            StreamWriter sw = null;
            try
            {
                if (i_error == 1)
                {
                    SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                    SqlCommand mycommand = new SqlCommand();
                    mycommand = new SqlCommand("Usp_Service_setErrorLog", mycon);
                    mycommand.Parameters.Add(new SqlParameter("@ErrMessage", s_message));
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.Connection.Open();
                    mycommand.ExecuteNonQuery();
                    mycommand.Connection.Close();
                }
                sw = new StreamWriter(ConfigurationSettings.AppSettings["LogPath"] + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                sw.WriteLine("----------------------------------------------------------------------------------------------------");
                sw.WriteLine("----------------------------------------------------------------------------------------------------");
                sw.WriteLine(s_message);
                sw.WriteLine("----------------------------------------------------------------------------------------------------");
                sw.WriteLine("----------------------------------------------------------------------------------------------------");
            }
            catch { }
            finally
            {
                sw.Close();
            }
        }
        private int setScheduleStatus(int i_ScheduleId, int i_ScheduleTId, string s_Flg)
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            try
            {
                mycommand = new SqlCommand("Usp_Service_setExecuteSchedule", mycon);
                mycommand.Parameters.Add(new SqlParameter("@ScheduleId", i_ScheduleId));
                mycommand.Parameters.Add(new SqlParameter("@ScheduleTId", i_ScheduleTId));
                mycommand.Parameters.Add(new SqlParameter("@Flg", s_Flg));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.Connection.Open();
                int i_Id = Convert.ToInt32(mycommand.ExecuteScalar());
                mycommand.Connection.Close();
                return i_Id;
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Set Schedules---" + i_ScheduleId + "---" + s_Flg + "---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return 0;
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void EmpCreation()
        {
            try
            {
                WriteLog(0, "SAPEmpCreation Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                SAPEmpreation();
                WriteLog(0, "SAPEmpCreation Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                WriteLog(0, "SAPCostCenterUpdation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                SAPCostCenterUpdation();
                WriteLog(0, "SAPCostCenterUpdation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                WriteLog(0, "SAPEmpCostCentre Updation Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                SAPCostCenterUpdationEmployeeWise();
                WriteLog(0, "SAPEmpCostCentre Updation Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                WriteLog(0, "Fill Item Master Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                FillItemMaster();
                WriteLog(0, "Fill Item Master Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                WriteLog(0, "SAPPlantUpdation Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                SAPPlantUpdation();
                WriteLog(0, "SAPPlantUpdation Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                try
                {
                    WriteLog(0, "MktgTrnConfMail Started." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    MktgTrnConfMail(); //Trainees Falling due for confirmation
                    WriteLog(0, "MktgTrnConfMail Ended." + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    WriteLog(0, "SendingMailToTraineeForDocuments Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    SendingMailToTraineeForDocuments(); //Mktg Employees Doc Return Mail
                    WriteLog(0, "SendingMailToTraineeForDocuments Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    WriteLog(0, "SendingMailToTraineeForConfirm Started" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    SendingMailToTraineeForConfirm(); //Trainee Confirmation mail
                    WriteLog(0, "SendingMailToTraineeForConfirm Ended" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }
                catch { }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void EmpUpdation()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                SqlCommand mycommand = new SqlCommand();
                SqlCommand mycommand1 = new SqlCommand();
                DataSet ds = new DataSet();
                DataSet dsEmpUpdation = new DataSet();
                string strEmpNo = "";                                                       // For holding Empno
                string strPdate = "";                                                       //Date To be passed to RFC (today's date)
                string strempstatus = "";                                                   //SAP EmpStatus
                string strempstat = "";                                                     //for updating legacy table
                string LeavingDate = "";                                                    //For Resignation Date
                string strempgrade = "";                                                    //for Emp grade
                string strempdept = "";                                                     //For Emp Department
                string stremptype = "";                                                     //Employee type --trainee or not
                string strdateofConfirmation = "";                                          //Date of confirmation
                string strpersarea = "";                                                    //Emp Personal Area
                string strperssubarea = "";                                                 //Emp Personal Subarea           
                string strsaploc = "";                                                      //Emp SapLocation
                string strempdesig = "";                                                    //Sap Emp Deaignation
                string strPdate1 = "";                                                      //
                string strempsclcode = "";                                                  // scalecode of emp
                int ismktg = 0;                                                             //Mktg employee
                double strEmpBasic = 0;
                mycommand = new SqlCommand("USP_EmpUpdation_getAllEmps", mycon);            //Getting all emps (rsigned,hold and active)
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "getAllEmps");
                mycommand.Connection.Close();
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "Itdev#13";
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)                                 //If emps exists , Process Starts 
                    {
                        strPdate = ds.Tables["getAllEmps"].Rows[0]["Cyear"].ToString() + ds.Tables["getAllEmps"].Rows[0]["Cmon"].ToString() + ds.Tables["getAllEmps"].Rows[0]["Cday"].ToString();
                        strPdate1 = ds.Tables["getAllEmps"].Rows[0]["Cyear1"].ToString() + ds.Tables["getAllEmps"].Rows[0]["Cmon1"].ToString() + ds.Tables["getAllEmps"].Rows[0]["Cday1"].ToString();

                        SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                        List<string> input = new List<string>();
                        input.Add(strPdate);
                        input.Add(strPdate1);
                        XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                        XmlNode xmlException = null;
                        //RFC call
                        XmlElement xDocTable = (XmlElement)s.R3EmpUpdation(xDoc, out xmlException);
                        List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                        //If Call Success
                        if (SAPError[0] == "1000")
                        {
                            dsEmpUpdation = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                            //In SAP if data exists
                            if (dsEmpUpdation.Tables[0].Rows.Count > 0)
                            {
                                //ForEach Row of SAP Data
                                foreach (DataRow dr in dsEmpUpdation.Tables[0].Rows)
                                {
                                    strEmpNo = dr["Empno"].ToString().Substring(2, 6);
                                    strempstatus = dr["EmpStatus"].ToString();
                                    DataRow[] drs = ds.Tables[0].Select(" Empid ='" + strEmpNo + "'");      //as we have brought whole data at a time mapping sapempno with legacy
                                    if (drs.Length > 0)
                                    {
                                        if (dr["LockedStatus"].ToString() == "X") //Added by Raveesh on 12-11-2015
                                        {
                                            strempstat = "0";
                                        }

                                        else if (Convert.ToInt32(strempstatus) == 3)            //3 means in SAP Emp Active
                                        {
                                            strempstat = "1";                                //1 means in Legacy Emp is active
                                        }
                                        else if (Convert.ToInt32(strempstatus) == 1)       //1 means in SAP Emp is Hold
                                        {
                                            strempstat = "2";                                //2 means in Legacy Emp is hold
                                        }
                                        else if (Convert.ToInt32(strempstatus) == 0)       //0 means in SAP Emp is resigned
                                        {
                                            strempstat = "0";                                //0 means in Legacy Emp is Resigned                                     
                                        }
                                        else if (Convert.ToInt32(strempstatus) == 2)       //2 means in SAP Emp is Retired
                                        {
                                            strempstat = "0";                                //0 means in Legacy Emp is Retried                                     
                                        }

                                        if (strempstat == "0")
                                        {
                                            //if (drs[0][4].ToString() != null && drs[0][4].ToString() != "")  //As resigned getting resigned date , if already exists in Legacy ,same being updated else from SAP
                                            //{
                                            //    if (Convert.ToString(drs[0][14]) == "L" && dr["Releavingdate"].ToString() != null && dr["Releavingdate"].ToString() != "")
                                            //        LeavingDate = dr["Releavingdate"].ToString().Substring(0, 4) + "-" + dr["Releavingdate"].ToString().Substring(5, 2) + "-" + dr["Releavingdate"].ToString().Substring(8, 2);
                                            //    else
                                            //        LeavingDate = drs[0][4].ToString().Substring(6, 4) + "-" + drs[0][4].ToString().Substring(3, 2) + "-" + drs[0][4].ToString().Substring(0, 2);
                                            //}
                                            //else
                                            //{
                                            //    //LeavingDate = dr["Releavingdate"].ToString().Substring(6, 4) + "-" + dr["Releavingdate"].ToString().Substring(3, 2) + "-" + dr["Releavingdate"].ToString().Substring(0, 1);
                                            if (dr["Releavingdate"].ToString() != null && dr["Releavingdate"].ToString() != "" && dr["LockedStatus"].ToString() != "X")
                                            {
                                                LeavingDate = dr["Releavingdate"].ToString().Substring(0, 4) + "-" + dr["Releavingdate"].ToString().Substring(5, 2) + "-" + dr["Releavingdate"].ToString().Substring(8, 2);
                                            }
                                            //Added by raveesh to update the Locked date if Locked status = "X" Date: 28-04-2016
                                            else if (dr["LockedDate"].ToString() != null && dr["LockedDate"].ToString() != "" && dr["LockedStatus"].ToString() == "X")
                                            {
                                                LeavingDate = dr["LockedDate"].ToString().Substring(0, 4) + "-" + dr["LockedDate"].ToString().Substring(5, 2) + "-" + dr["LockedDate"].ToString().Substring(8, 2);
                                            }
                                        }
                                        else
                                        {
                                            //if (Convert.ToString(drs[0][14]) == "L")
                                            //{
                                            //    LeavingDate = dr["Releavingdate"].ToString().Substring(0, 4) + "-" + dr["Releavingdate"].ToString().Substring(5, 2) + "-" + dr["Releavingdate"].ToString().Substring(8, 2);
                                            //    strempstat = "0";
                                            //}
                                            //else
                                            LeavingDate = null;
                                        }

                                        if (strempstat == "")
                                        {
                                            strempstat = strempstatus;
                                        }

                                        if (dr["Grade"].ToString() == "O1" || dr["Grade"].ToString() == "O2" || dr["Grade"].ToString() == "A1" || dr["Grade"].ToString() == "A2" || dr["Grade"].ToString() == "A3" || dr["Grade"].ToString() == "E1" || dr["Grade"].ToString() == "E2" || dr["Grade"].ToString() == "E3")
                                        {
                                            stremptype = "FT-OFF";
                                        }
                                        else if (dr["Grade"].ToString().Substring(0, 1) == "T")
                                        {
                                            stremptype = "TRAINE";
                                        }
                                        else
                                        {
                                            stremptype = "FT-MGR";
                                        }

                                        // if (stremptype.ToString().Trim().ToUpper() != drs[0][1].ToString().Trim().ToUpper())
                                        // {

                                        if (drs[0][2].ToString().Trim() == "" || drs[0][2].ToString().Trim() == null)      //Checcking whether Confirmation Date exists or not in legacy
                                        {
                                            List<string> input1 = new List<string>();
                                            input1.Add("PA0000");
                                            input1.Add("MASSN EQ 'I3'  AND PERNR EQ '" + strEmpNo + "'");
                                            input1.Add("BEGDA|PERNR");
                                            XmlDocument xDoc1 = XMLSerializerBL.Serialize(input1, XMLSerializerBL.InputType.List);
                                            XmlNode xmlException1 = null;
                                            //Calling Table for getting Confirmation Date
                                            XmlElement xDocTable1 = (XmlElement)s.GetTableData(xDoc1, out xmlException1);
                                            List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlException1.OuterXml, XMLSerializerBL.OutputType.List);

                                            if (SAPError1[0] == "1000")
                                            {
                                                DataTable dt1 = (DataTable)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataTable);

                                                if (dt1.Rows.Count > 0)
                                                {
                                                    //strdateofConfirmation = dt1.Rows[0]["DateofConfirmation"].ToString().Substring(6, 4) + "-" + dt1.Rows[0]["DateofConfirmation"].ToString().Substring(3, 2) + "-" + dt1.Rows[0]["DateofConfirmation"].ToString().Substring(0, 1);
                                                    strdateofConfirmation = dt1.Rows[0]["DateofConfirmation"].ToString().Substring(0, 4) + "-" + dt1.Rows[0]["DateofConfirmation"].ToString().Substring(4, 2) + "-" + dt1.Rows[0]["DateofConfirmation"].ToString().Substring(6, 2);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            strdateofConfirmation = drs[0][2].ToString().Substring(6, 4) + "-" + drs[0][2].ToString().Substring(3, 2) + "-" + drs[0][2].ToString().Substring(0, 2);  //drs[0][2].ToString();
                                        }
                                        // }//(stremptype.ToString().Trim().ToUpper() != drs[1].ToString().Trim().ToUpper())
                                        //else
                                        //{
                                        //    if (drs[0][2].ToString().Trim() != "" && drs[0][2].ToString().Trim() != null)
                                        //    {
                                        //        strdateofConfirmation = drs[0][2].ToString().Substring(6, 4) + "-" + drs[0][2].ToString().Substring(3, 2) + "-" + drs[0][2].ToString().Substring(0, 2);  //drs[0][2].ToString();
                                        //    }
                                        //}

                                        strpersarea = dr["EmpPerArea"].ToString();
                                        strperssubarea = dr["EmpPerSubArea"].ToString();
                                        strempgrade = dr["Grade"].ToString();
                                        strempdept = dr["dept"].ToString();

                                        //For customer creation of mktg emp keerthi on 25/01/2012
                                        if (drs[0]["ismktg"].ToString() == "False")
                                        {
                                            ismktg = 0;
                                        }
                                        else
                                        {
                                            ismktg = 1;
                                        }
                                        //end of  customer creation of mktg emp keerthi on 25/01/2012

                                        //if ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC"))
                                        //{
                                        //    strsaploc = "102";
                                        //}

                                        // Added by Santhoshi for location changes code.
                                        if ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC") && (dr["EmpPerSubArea"].ToString() == "AHAP" || dr["EmpPerSubArea"].ToString() == "AHDE"))
                                        {
                                            strsaploc = "101";
                                        }
                                        else if ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() != "IG" || dr["EmpPayArea"].ToString() != "IC"))
                                        {
                                            strsaploc = dr["EmpPerSubArea"].ToString();
                                        }
                                        else if ((dr["EmpPerArea"].ToString() == "4000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC"))
                                        {
                                            strsaploc = "101";
                                        }
                                        else if ((dr["EmpPerArea"].ToString() == "4000") && (dr["EmpPayArea"].ToString() != "IG" || dr["EmpPayArea"].ToString() != "IC"))
                                        {
                                            strsaploc = dr["EmpPerSubArea"].ToString();
                                        }
                                        else if (dr["EmpPerArea"].ToString() == "5000" && dr["EmpPerSubArea"].ToString() == "IGAP")
                                        {
                                            strsaploc = "101";
                                        }
                                        else if (dr["EmpPerArea"].ToString() == "7000")
                                        {
                                            strsaploc = "104";
                                        }
                                        else if (dr["EmpPerArea"].ToString() == "5000" && dr["EmpPerSubArea"].ToString() != "IGAP")
                                        {
                                            strsaploc = dr["EmpPerSubArea"].ToString();
                                        }
                                        else if ((dr["EmpPerArea"].ToString() == "1100") && (dr["EmpPayArea"].ToString() == "IO"))
                                        {
                                            strsaploc = "103";
                                        }
                                        else if (dr["EmpPerArea"].ToString() == "1000")
                                        {
                                            if (dr["EmpPerSubArea"].ToString() == "1003" && dr["EmpPayArea"].ToString() == "IL")
                                            {
                                                strsaploc = dr["EmpPerSubArea"].ToString();
                                            }
                                            else
                                            {
                                                if (ds.Tables[1].Rows.Count > 0)
                                                {
                                                    DataRow[] drs1 = ds.Tables[1].Select(" sapperarea = '" + strpersarea.Trim() + "' and (sapsubarea = '" + strperssubarea.Trim() + "' or sapsubarea = '" + dr["EmpPayArea"].ToString().Trim() + "')");      //as we have brough whole data at aa time mapping sapempno with legacy
                                                    if (drs1.Length > 0)
                                                    {
                                                        strsaploc = drs1[0][1].ToString(); //Locationcode
                                                    }
                                                    else //Added by Raveesh on 29/10/2015
                                                    {
                                                        strsaploc = strperssubarea.Trim();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            DataRow[] drs1 = ds.Tables[1].Select(" sapperarea ='" + strpersarea.Trim() + "' and (sapsubarea = '" + strperssubarea.Trim() + "' or sapsubarea = '" + dr["EmpPayArea"].ToString().Trim() + "')");      //as we have brough whole data at aa time mapping sapempno with legacy
                                            if (drs1.Length > 0)
                                            {
                                                strsaploc = drs1[0][1].ToString(); //Locationcode
                                            }
                                            else //Added by Raveesh on 29/10/2015
                                            {
                                                strsaploc = strperssubarea.Trim();
                                            }
                                        }

                                        if (strEmpNo == "002507")
                                        {
                                            strsaploc = "102";
                                        }

                                        if (dr["Grade"].ToString().ToUpper() == "O1" || dr["Grade"].ToString().ToUpper() == "O2")
                                        {
                                            strempdesig = "7";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "A1" || dr["Grade"].ToString().ToUpper() == "A2" || dr["Grade"].ToString().ToUpper() == "A3")
                                        {
                                            strempdesig = "8";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "E1" || dr["Grade"].ToString().ToUpper() == "E2" || dr["Grade"].ToString().ToUpper() == "E3")
                                        {
                                            strempdesig = "6";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "M1" || dr["Grade"].ToString().ToUpper() == "M2" || dr["Grade"].ToString().ToUpper() == "M3" || dr["Grade"].ToString().ToUpper() == "M4")
                                        {
                                            strempdesig = "5";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "G1" || dr["Grade"].ToString().ToUpper() == "G2" || dr["Grade"].ToString().ToUpper() == "CG")
                                        {
                                            strempdesig = "4";
                                        }
                                        else if (dr["Grade"].ToString().Trim().Substring(0, 1).ToUpper() == "T")
                                        {
                                            strempdesig = "17";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "RR")
                                        {
                                            if (strEmpNo == "001780")
                                            {
                                                strempdesig = "2";
                                            }
                                            else if (strEmpNo == "003183")
                                            {
                                                strempdesig = "6";
                                            }
                                            else
                                            {
                                                strempdesig = "5";
                                            }
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "TEC")
                                        {
                                            strempdesig = "10";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "MD")
                                        {
                                            strempdesig = "1";
                                        }
                                        else if (dr["Grade"].ToString().ToUpper() == "DM")
                                        {
                                            strempdesig = "69";
                                        }

                                        // for officer designation its hardcoded as 119 when desigcode=2597 ...needto look into this.code has to be written
                                        //not required checked the emps with designations 2597 , 4 emps are there all are resigned

                                        if (ds.Tables[2].Rows.Count > 0)
                                        {
                                            DataRow[] drs2 = ds.Tables[2].Select("GradeId ='" + strempgrade.Trim() + "'");      //as we have brought whole data at aa time mapping sapempno with legacy
                                            if (drs2.Length > 0)
                                            {
                                                strempsclcode = drs2[0][1].ToString(); //sclcode
                                            }
                                        }
                                        if (strEmpNo == "003183")
                                        {
                                            strempsclcode = "28";
                                            strempgrade = "E2";
                                        }

                                        if (strEmpNo == "002207")
                                        {
                                            strempsclcode = "29";
                                            strempgrade = "G2";
                                        }

                                        if (strEmpNo == "003646")
                                        {
                                            strempgrade = "M1";
                                        }

                                        if (strEmpNo == "002917")
                                        {
                                            strempdept = "00001033";
                                        }

                                        if (strempdesig.Trim() == "")
                                        {
                                            strempdesig = drs[0][8].ToString();
                                        }
                                        if (strempgrade.Trim() == "")
                                        {
                                            strempgrade = drs[0][9].ToString();
                                        }
                                        if (strempsclcode.Trim() == "")
                                        {
                                            strempsclcode = drs[0][10].ToString();
                                        }
                                        if (strempdept.Trim() == "")
                                        {
                                            strempdept = drs[0][11].ToString();
                                        }
                                        if (strsaploc.Trim() == "")
                                        {
                                            strsaploc = drs[0][12].ToString();
                                        }

                                        if (ds.Tables[3].Rows.Count > 0)
                                        {
                                            DataRow[] drs3 = ds.Tables[3].Select("empno='" + strEmpNo.Trim() + "'");      //as we have brought whole data at aa time mapping sapempno with legacy
                                            if (drs3.Length > 0)
                                            {
                                                strsaploc = drs3[0][1].ToString(); //locationcode
                                            }
                                        }
                                        //iilfast employee location code
                                        if (drs[0][13].ToString().ToUpper() == "TRUE")
                                        {
                                            strsaploc = dr["EmpPerSubArea"].ToString(); //locationcode
                                        }
                                        strEmpBasic = Convert.ToDouble(dr["EmpBasic"].ToString());

                                        strempdesig = strempdesig.Trim();
                                        strempdept = strempdept.Trim().Substring(4, 4);

                                        string strESI = "0";
                                        string strSex = "";
                                        string strTitle = "";
                                        string strFather = "";
                                        string strMaritalStatus = "";
                                        string strDob = "";
                                        string strEmpName = "";
                                        string strAddress1 = "";
                                        string strAddress2 = "";
                                        string strAddress3 = "";
                                        string strPostal = "";

                                        if (Convert.ToString(dr["ESI"]) == "ES")
                                        {
                                            strESI = "1";
                                        }
                                        if (dsEmpUpdation.Tables[1].Rows.Count > 0)
                                        {
                                            DataRow[] drEmpCreationUpd = dsEmpUpdation.Tables[1].Select("EmpNo ='" + Convert.ToString(dr["Empno"]) + "'");
                                            if (drEmpCreationUpd.Length > 0)
                                            {
                                                //Employee Sex 
                                                if (Convert.ToInt32(drEmpCreationUpd[0]["Empsex"].ToString()) == 1)
                                                {
                                                    strSex = "M";
                                                    strTitle = "Mr.";
                                                }
                                                else
                                                {
                                                    strSex = "F";
                                                    strTitle = "Miss";
                                                }

                                                try
                                                {
                                                    //Employee Father Name from another RFC(from Table)
                                                    List<string> input1 = new List<string>();
                                                    input1.Add("PA0021");
                                                    input1.Add("PERNR EQ " + dr["EmpNo"].ToString());
                                                    input1.Add("SUBTY|FANAM");
                                                    XmlDocument xDoc1 = XMLSerializerBL.Serialize(input1, XMLSerializerBL.InputType.List);
                                                    XmlNode xmlException1 = null;
                                                    XmlElement xDocTable1 = (XmlElement)s.GetTableData(xDoc1, out xmlException1);
                                                    List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlException1.OuterXml, XMLSerializerBL.OutputType.List);

                                                    if (SAPError1[0] == "1000")
                                                    {
                                                        DataTable dt1 = (DataTable)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                                        if (dt1.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow dr1 in dt1.Rows)
                                                            {
                                                                if (Convert.ToInt32(dr1["SubType"].ToString()) == 11)
                                                                {
                                                                    strFather = dr1["FatherName"].ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Employee Father Name from another RFC(from Table)---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                }
                                                //Employee Marital Status
                                                if (drEmpCreationUpd[0]["Marstatus"].ToString() == "1")
                                                {
                                                    strMaritalStatus = "M";
                                                }
                                                else
                                                {
                                                    strMaritalStatus = "N";
                                                }

                                                //Date of Birth
                                                string strTempDbMon = drEmpCreationUpd[0]["Dateofbirth"].ToString().Substring(5, 2);
                                                string strTempDbDay = drEmpCreationUpd[0]["Dateofbirth"].ToString().Substring(8, 2);
                                                if (strTempDbMon.Length == 1)
                                                {
                                                    strTempDbMon = "0" + strTempDbMon;
                                                }
                                                if (strTempDbDay.Length == 1)
                                                {
                                                    strTempDbDay = "0" + strTempDbDay;
                                                }

                                                strDob = drEmpCreationUpd[0]["Dateofbirth"].ToString().Substring(0, 4) + "-" + strTempDbMon + "-" + strTempDbDay;
                                                //AddressDetails
                                                strEmpName = drEmpCreationUpd[0]["Empname"].ToString().Replace("'", "");
                                                strAddress1 = drEmpCreationUpd[0]["Address1"].ToString().Replace("'", "");
                                                strAddress2 = drEmpCreationUpd[0]["Address2"].ToString().Replace("'", "");
                                                strAddress3 = drEmpCreationUpd[0]["Address3"].ToString().Replace("'", "");
                                                strPostal = drEmpCreationUpd[0]["Postal"].ToString().Replace("'", "");

                                            }
                                        }
                                        //if (strEmpNo == "003253")
                                        //{
                                        //    string abc = "123";
                                        //}
                                        while (strempdesig.Length < 8)
                                            strempdesig = "0" + strempdesig;
                                        //added try catch -- kept this to identify error converting varchar to datetime
                                        try
                                        {
                                            mycommand1 = new SqlCommand("USP_EMPLOYEEMASTER_TRANSACTIONS", mycon);       //For updating master tables     
                                            mycommand1.CommandType = CommandType.StoredProcedure;
                                            mycommand1.CommandTimeout = 100000;
                                            mycommand1.Parameters.Add(new SqlParameter("@flag", 'U'));      //As updating sending flag as U
                                            mycommand1.Parameters.Add(new SqlParameter("@EmpId", strEmpNo));
                                            //if (strdateofConfirmation != null && strdateofConfirmation != "")
                                            //{
                                            //mycommand1.Parameters.Add(new SqlParameter("@ConfirmedDate", strdateofConfirmation));
                                            //}
                                            mycommand1.Parameters.Add(new SqlParameter("@ConfirmedDate", strdateofConfirmation));
                                            mycommand1.Parameters.Add(new SqlParameter("@LeavingDate", LeavingDate));
                                            //if (LeavingDate != null && LeavingDate != "")
                                            //{
                                            //    mycommand1.Parameters.Add(new SqlParameter("@LeavingDate", LeavingDate));
                                            //}
                                            mycommand1.Parameters.Add(new SqlParameter("@Emptype", stremptype));
                                            mycommand1.Parameters.Add(new SqlParameter("@status", strempstat));
                                            mycommand1.Parameters.Add(new SqlParameter("@DeptId", strempdept));
                                            mycommand1.Parameters.Add(new SqlParameter("@DesigId", strempdesig));
                                            mycommand1.Parameters.Add(new SqlParameter("@GradeId", strempgrade));
                                            mycommand1.Parameters.Add(new SqlParameter("@locationcode", strsaploc));
                                            mycommand1.Parameters.Add(new SqlParameter("@scl_code", strempsclcode));
                                            mycommand1.Parameters.Add(new SqlParameter("@Empbasic", strEmpBasic));
                                            mycommand1.Parameters.Add(new SqlParameter("@ESI_NO", strESI));
                                            mycommand1.Parameters.Add(new SqlParameter("@Gender", strSex));
                                            mycommand1.Parameters.Add(new SqlParameter("@Title", strTitle));
                                            mycommand1.Parameters.Add(new SqlParameter("@FatherName", strFather));
                                            mycommand1.Parameters.Add(new SqlParameter("@Married", strMaritalStatus));
                                            mycommand1.Parameters.Add(new SqlParameter("@BirthDate", strDob));
                                            mycommand1.Parameters.Add(new SqlParameter("@FirstName", strEmpName));
                                            mycommand1.Parameters.Add(new SqlParameter("@add1", strAddress1));
                                            mycommand1.Parameters.Add(new SqlParameter("@add2", strAddress2));
                                            mycommand1.Parameters.Add(new SqlParameter("@add3", strAddress3));
                                            mycommand1.Parameters.Add(new SqlParameter("@PIN", strPostal));
                                            mycommand1.Connection.Open();
                                            mycommand1.ExecuteNonQuery();
                                            mycon.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            WriteLog(0, "Exception :" + ex.Message + "---SAPEmpUpdation---USP_EMPLOYEEMASTER_TRANSACTIONS---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                        }
                                        finally
                                        {
                                            if (mycommand1.Connection.State == ConnectionState.Open)
                                                mycommand1.Connection.Close();
                                        } //added try catch -- kept this to identify error converting varchar to datetime


                                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        //  Temporarily saving to find out the location issue (for 1st day it is HO and next day it is changing to other loc)
                                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        try
                                        {
                                            mycommand = new SqlCommand("USP_EMPLOYEEMASTER_TempSave", mycon);
                                            mycommand.CommandType = CommandType.StoredProcedure;
                                            mycommand.CommandTimeout = 100000;
                                            mycommand.Parameters.Add(new SqlParameter("@EmpId", strEmpNo));
                                            mycommand.Parameters.Add(new SqlParameter("@EmpPerArea", dr["EmpPerArea"].ToString().Replace("'", "").Trim()));
                                            mycommand.Parameters.Add(new SqlParameter("@EmpPayArea", dr["EmpPayArea"].ToString().Replace("'", "").Trim()));
                                            mycommand.Parameters.Add(new SqlParameter("@EmpSaploc", dr["EmpPerSubArea"].ToString().Replace("'", "").Trim()));
                                            mycommand.Parameters.Add(new SqlParameter("@locationcode", strsaploc));
                                            mycommand.Parameters.Add(new SqlParameter("@Flg", "EU"));
                                            mycommand.Connection.Open();
                                            mycommand.ExecuteNonQuery();
                                        }
                                        catch (Exception ex)
                                        {
                                            WriteLog(1, "Exception :" + ex.Message + "---SAPEmpUpdation---USP_EMPLOYEEMASTER_TempSave---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                        }
                                        finally
                                        {
                                            if (mycommand.Connection.State == ConnectionState.Open)
                                                mycommand.Connection.Close();
                                        }
                                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        //  Temporarily saving to find out the location issue (for 1st day it is HO and next day it is changing to other loc)
                                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        //For customer creation of mktg emp keerthi on 25/01/2012
                                        //checking if mktg employee created as customer or not
                                        if (ismktg == 1 && Convert.ToInt32(strEmpNo.Substring(2, 1).ToString()) >= 0)     //checking if mktg emp or not
                                        {
                                            string EFlag = "";
                                            List<string> input1 = new List<string>();
                                            input1.Add("KNA1");
                                            string strcust;
                                            strcust = strEmpNo;
                                            DataView dv = new DataView(ds.Tables[5]);
                                            dv.RowFilter = "EmpId='" + strcust + "'";
                                            if (dv.ToTable().Rows.Count > 0)
                                            {
                                                strcust = "09" + strcust.Substring(2, 4);
                                                EFlag = "9";
                                            }
                                            while (strcust.Length < 10)
                                                strcust = "0" + strcust;
                                            input1.Add("KUNNR EQ '" + strcust + "'");
                                            input1.Add("KUNNR|NAME1|TELF2");
                                            XmlDocument xDoc1 = XMLSerializerBL.Serialize(input1, XMLSerializerBL.InputType.List);
                                            XmlNode xmlException1 = null;
                                            //Calling Table for getting Confirmation Date
                                            XmlElement xDocTable1 = (XmlElement)s.GetTableData(xDoc1, out xmlException1);
                                            List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlException1.OuterXml, XMLSerializerBL.OutputType.List);

                                            if (SAPError1[0] == "1000")
                                            {
                                                DataTable dt1 = (DataTable)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataTable);

                                                if (dt1.Rows.Count > 0)
                                                {
                                                }
                                                else
                                                {
                                                    //if (ViewState["mktgdata"] != null)
                                                    if (dtmktgdata.Columns.Count > 0)
                                                    {
                                                        //dtItems = (DataTable)ViewState["mktgdata"];
                                                        dtItems = dtmktgdata;
                                                    }
                                                    else
                                                    {
                                                        dtItems = Filldtcols();
                                                        //ViewState["mktgdata"] = dtItems;
                                                        dtmktgdata = dtItems;
                                                    }
                                                    DataRow[] drs4 = ds.Tables[4].Select(" empid ='" + strEmpNo.Trim() + "'");      //as we have brough whole data at aa time mapping sapempno with legacy

                                                    if (drs4.Length > 0)
                                                    {
                                                        string strsegcode = drs4[0]["Segcode"].ToString();
                                                        while (strsegcode.Length < 3)
                                                            strsegcode = "0" + strsegcode;
                                                        while (strEmpNo.Length < 10)
                                                            strEmpNo = "0" + strEmpNo;
                                                        drItems = dtItems.NewRow();
                                                        drItems["EmpId"] = strEmpNo;
                                                        drItems["DisChannel"] = "10";
                                                        drItems["Division"] = drs4[0]["DivCode"].ToString();   //Segment Division
                                                        drItems["SalesOffice"] = drs4[0]["SalesOffice"].ToString();                   //9000 As told by satya to hardcode
                                                        drItems["SalesGroup"] = strsegcode;  //segment
                                                        drItems["CustGroup"] = drs4[0]["CustomerGroup"].ToString();  //Customer Group
                                                        drItems["Title"] = drs4[0]["Title"].ToString();
                                                        drItems["EFlag"] = EFlag;
                                                        dtItems.Rows.Add(drItems);
                                                        //ViewState["mktgdata"] = dtItems;
                                                        dtmktgdata = dtItems;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    ismktg = 0;
                                    strEmpNo = "";
                                    strPdate = "";
                                    strempstatus = "";
                                    strempstat = "";
                                    LeavingDate = "";
                                    strempgrade = "";
                                    strempdept = "";
                                    stremptype = "";
                                    strdateofConfirmation = "";
                                    strpersarea = "";
                                    strperssubarea = "";
                                    strsaploc = "";
                                    strempdesig = "";
                                    strempsclcode = "";
                                }
                            }
                        }
                    }
                }

                //For customer creation of mktg emp keerthi on 25/01/2012
                if (dtmktgdata != null)
                {
                    dtItems = (DataTable)dtmktgdata;
                    dtItems.TableName = "EmpDetails";
                }

                if (dtItems != null && dtItems.Rows.Count > 0)
                {
                    //SAP customer creation ...
                    SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);

                    XmlDocument xDoc2 = XMLSerializerBL.Serialize(dtItems, XMLSerializerBL.InputType.DataTable);
                    XmlNode xmlException2 = null;
                    XmlElement xDocTable2 = null;
                    xDocTable2 = (XmlElement)s.SetMktgEmpAsCustomer(xDoc2, Dest, out xmlException2);
                    List<string> SAPError2 = (List<string>)XMLSerializerBL.Deserialize(xmlException2.OuterXml, XMLSerializerBL.OutputType.List);
                    if (SAPError2[0] == "1000")
                    {
                    }
                }

                SAPService ASCon = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceAS"]);

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //                              Updating Status as zero for locked employees                                //
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (dsEmpUpdation != null && dsEmpUpdation.Tables.Count > 0 && dsEmpUpdation.Tables[0].Rows.Count > 0)
                {
                    dsEmpUpdation.Tables[0].TableName = "TblEmpId";
                    dsEmpUpdation.Tables[0].Columns.Remove("EmpStatus");
                    dsEmpUpdation.Tables[0].Columns.Remove("Releavingdate");
                    dsEmpUpdation.Tables[0].Columns.Remove("Grade");
                    dsEmpUpdation.Tables[0].Columns.Remove("Dept");
                    dsEmpUpdation.Tables[0].Columns.Remove("EmpPerArea");
                    dsEmpUpdation.Tables[0].Columns.Remove("EmpPerSubArea");
                    dsEmpUpdation.Tables[0].Columns.Remove("EmpPayArea");
                    dsEmpUpdation.Tables[0].Columns.Remove("EmpBasic");
                    dsEmpUpdation.Tables[0].Columns.Remove("ESI");

                    dsEmpUpdation.Tables[1].TableName = "TblEmpId1";
                    dsEmpUpdation.Tables[1].Columns.Remove("Marstatus");
                    dsEmpUpdation.Tables[1].Columns.Remove("Empsex");
                    dsEmpUpdation.Tables[1].Columns.Remove("Dateofbirth");
                    dsEmpUpdation.Tables[1].Columns.Remove("Empname");
                    dsEmpUpdation.Tables[1].Columns.Remove("Address1");
                    dsEmpUpdation.Tables[1].Columns.Remove("Address2");
                    dsEmpUpdation.Tables[1].Columns.Remove("Address3");
                    dsEmpUpdation.Tables[1].Columns.Remove("Postal");

                    try
                    {

                        mycommand = new SqlCommand("USP_EMPLOYEEMASTER_LOCKSTATUS", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        if (dsEmpUpdation.Tables[0].Rows.Count > 0)
                        {
                            StringWriter sbEmpId = new StringWriter();
                            dsEmpUpdation.Tables[0].WriteXml(sbEmpId);
                            mycommand.Parameters.Add("@EmpId", SqlDbType.Xml);
                            mycommand.Parameters["@EmpId"].Value = sbEmpId.ToString();
                        }
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                        mycommand.Connection.Close();

                        if (dsEmpUpdation.Tables[1].Rows.Count > 0)
                        {
                            StringWriter sbEmpId1 = new StringWriter();
                            dsEmpUpdation.Tables[1].WriteXml(sbEmpId1);
                            mycommand.Parameters.Add("@EmpId", SqlDbType.Xml);
                            mycommand.Parameters["@EmpId"].Value = sbEmpId1.ToString();
                        }
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                        mycommand.Connection.Close();


                    }

                    catch (Exception ex)
                    {
                        WriteLog(1, "Exception :" + ex.Message + "---EmpUpdation--Employee Lock Status---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    }
                    finally
                    {
                        mycommand.Connection.Close();
                    }
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //                       End of Updating Status as zero for locked employees                                //
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpUpdation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        public void custcreation()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                SqlCommand mycommand1 = new SqlCommand();
                DataSet ds = new DataSet();
                DataSet dsEmpUpdation = new DataSet();
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "Itdev#13";
                string strEmpNo = "";                                                       // For holding Empno
                //string strPdate = "";                                                       //Date To be passed to RFC (today's date)
                //string strempstatus = "";                                                   //SAP EmpStatus
                //string strempstat = "";                                                     //for updating legacy table
                //string LeavingDate = "";                                                    //For Resignation Date
                //string strempgrade = "";                                                    //for Emp grade
                //string strempdept = "";                                                     //For Emp Department
                //string stremptype = "";                                                     //Employee type --trainee or not
                //string strdateofConfirmation = "";                                          //Date of confirmation
                //string strpersarea = "";                                                    //Emp Personal Area
                //string strperssubarea = "";                                                 //Emp Personal Subarea           
                //string strsaploc = "";                                                      //Emp SapLocation
                //string strempdesig = "";                                                    //Sap Emp Deaignation
                //string strPdate1 = "";                                                      //
                //string strempsclcode = "";                                                  // scalecode of emp
                //int ismktg = 0;                                                             //Mktg employee
                //double strEmpBasic = 0;
                mycommand = new SqlCommand("USP_EmpUpdation_getAllEmps", mycon);            //Getting all emps (rsigned,hold and active)
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "getAllEmps");
                mycommand.Connection.Close();
                if (ds != null && ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        strEmpNo = ds.Tables[0].Rows[i]["EmpId"].ToString();
                        if (ds.Tables[0].Rows[i]["ismktg"].ToString() == "True" && Convert.ToInt32(strEmpNo.Substring(2, 1).ToString()) >= 0)
                        {
                            string EFlag = "";
                            List<string> input1 = new List<string>();
                            input1.Add("KNA1");
                            string strcust;
                            strcust = strEmpNo;
                            DataView dv = new DataView(ds.Tables[5]);
                            dv.RowFilter = "EmpId='" + strcust + "'";
                            if (dv.ToTable().Rows.Count > 0)
                            {
                                strcust = "09" + strcust.Substring(2, 4);
                                EFlag = "9";
                            }
                            while (strcust.Length < 10)
                                strcust = "0" + strcust;
                            input1.Add("KUNNR EQ '" + strcust + "'");
                            input1.Add("KUNNR|NAME1|TELF2");
                            XmlDocument xDoc1 = XMLSerializerBL.Serialize(input1, XMLSerializerBL.InputType.List);
                            XmlNode xmlException1 = null;
                            //Calling Table for getting Confirmation Date

                            XmlElement xDocTable1 = (XmlElement)s.GetTableData(xDoc1, out xmlException1);
                            List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlException1.OuterXml, XMLSerializerBL.OutputType.List);

                            if (SAPError1[0] == "1000")
                            {
                                DataTable dt1 = (DataTable)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataTable);

                                if (dt1.Rows.Count > 0)
                                {
                                }
                                else
                                {
                                    //if (ViewState["mktgdata"] != null)
                                    if (dtmktgdata.Columns.Count > 0)
                                    {
                                        //dtItems = (DataTable)ViewState["mktgdata"];
                                        dtItems = dtmktgdata;
                                    }
                                    else
                                    {
                                        dtItems = Filldtcols();
                                        //ViewState["mktgdata"] = dtItems;
                                        dtmktgdata = dtItems;
                                    }
                                    DataRow[] drs4 = ds.Tables[4].Select(" empid ='" + strEmpNo.Trim() + "'");      //as we have brough whole data at aa time mapping sapempno with legacy

                                    if (drs4.Length > 0)
                                    {
                                        string strsegcode = drs4[0]["Segcode"].ToString();
                                        while (strsegcode.Length < 3)
                                            strsegcode = "0" + strsegcode;
                                        while (strEmpNo.Length < 10)
                                            strEmpNo = "0" + strEmpNo;
                                        drItems = dtItems.NewRow();
                                        drItems["EmpId"] = strEmpNo;
                                        drItems["DisChannel"] = "10";
                                        drItems["Division"] = drs4[0]["DivCode"].ToString();   //Segment Division
                                        drItems["SalesOffice"] = drs4[0]["SalesOffice"].ToString();                   //9000 As told by satya to hardcode
                                        drItems["SalesGroup"] = strsegcode;  //segment
                                        drItems["CustGroup"] = drs4[0]["CustomerGroup"].ToString();  //Customer Group
                                        drItems["Title"] = drs4[0]["Title"].ToString();
                                        drItems["EFlag"] = EFlag;
                                        dtItems.Rows.Add(drItems);
                                        //ViewState["mktgdata"] = dtItems;
                                        dtmktgdata = dtItems;
                                    }
                                }
                            }
                        }
                    }
                }

                //For customer creation of mktg emp keerthi on 25/01/2012
                if (dtmktgdata != null)
                {
                    dtItems = (DataTable)dtmktgdata;
                    dtItems.TableName = "EmpDetails";
                }

                if (dtItems != null && dtItems.Rows.Count > 0)
                {
                    //SAP customer creation ...

                    XmlDocument xDoc2 = XMLSerializerBL.Serialize(dtItems, XMLSerializerBL.InputType.DataTable);
                    XmlNode xmlException2 = null;
                    XmlElement xDocTable2 = null;
                    xDocTable2 = (XmlElement)s.SetMktgEmpAsCustomer(xDoc2, Dest, out xmlException2);
                    List<string> SAPError2 = (List<string>)XMLSerializerBL.Deserialize(xmlException2.OuterXml, XMLSerializerBL.OutputType.List);
                    if (SAPError2[0] == "1000")
                    {
                    }
                }


            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "--" + "---Customer Creation Mktg Employee---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void ApprovalsList()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;
            string repOff = "";
            try
            {
                mycommand = new SqlCommand("USP_Employee_GetAllRepOff", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myRepOff = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myRepOff.Fill(ds, "GetReportingOfficers");
                mycommand.Connection.Close();

                foreach (DataRow dr in ds.Tables["GetReportingOfficers"].Rows)
                {
                    i = i + 1;
                    if (ds.Tables.Count > 1)
                        ds.Tables[1].Clear();
                    if (ds.Tables.Count > 2)
                        ds.Tables[2].Clear();
                    if (ds.Tables.Count > 3)
                        ds.Tables[3].Clear();
                    //if (ds != null)
                    //{
                    //    foreach (DataTable dt in ds.Tables)
                    //    {
                    //        dt.Clear();
                    //    }
                    //}
                    StringBuilder sb = new StringBuilder();
                    repOff = dr["EmpId"].ToString();

                    try
                    {
                        mycommand = new SqlCommand("USP_Schedule_Approvals_Pending", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        mycommand.Parameters.Add(new SqlParameter("@EmpId", dr["EmpId"].ToString()));
                        mycommand.Parameters.Add(new SqlParameter("@PendingDays", "10"));
                        //mycommand.Parameters.Add(new SqlParameter("@EmpId", "001280"));
                        SqlDataAdapter myAdapter1 = new SqlDataAdapter(mycommand);
                        myAdapter1 = new SqlDataAdapter(mycommand);
                        mycommand.CommandTimeout = 20000;
                        mycommand.Connection.Open();
                        myAdapter1.Fill(ds, "ApprovalsPending");
                        mycommand.Connection.Close();
                    }
                    catch (Exception)
                    {
                        //ds = null;
                    }
                    try
                    {
                        mycommand = new SqlCommand("USP_Schedule_Approvals_Done", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        mycommand.Parameters.Add(new SqlParameter("@EmpId", dr["EmpId"].ToString()));
                        SqlDataAdapter myAdapter2 = new SqlDataAdapter(mycommand);
                        mycommand.CommandTimeout = 20000;
                        mycommand.Connection.Open();
                        myAdapter2.Fill(ds, "ApprovalsDone");
                        mycommand.Connection.Close();
                    }
                    catch (Exception)
                    {
                        //ds = null;
                    }
                    if (ds != null && ds.Tables.Count > 1)
                    {
                        if ((ds.Tables["ApprovalsPending"].Rows.Count >= 0) || (ds.Tables["ApprovalsDone"].Rows.Count >= 0) || (ds.Tables["ApprovalsPending1"].Rows.Count >= 0))
                        {
                            int flg = 0;
                            funHeader(sb, ds, i);
                            if (ds.Tables["ApprovalsDone"].Rows.Count > 0)
                            {
                                flg = 1;
                                sb.Append("<table border='1'>");
                                sb.Append("<tr>");
                                sb.Append("<td><center><b>Approvals list</b></center></td>");
                                sb.Append("</tr>");
                                sb.Append("<tr>");
                                sb.Append("<td>");
                                funApprDet(sb, ds, i);
                                sb.Append("</td>");
                                sb.Append("</tr>");
                                sb.Append("</table>");
                                sb.Append("<br><br>");
                            }
                            sb.AppendLine();
                            sb.AppendLine();
                            if (ds.Tables["ApprovalsPending"].Rows.Count > 0)
                            {
                                flg = 1;
                                sb.Append("<table border=1><tr><td><center><b>Approvals Pending</b></center></td></tr><tr><td>");
                                funApprPenDet(sb, ds, i);
                                sb.Append("</td></tr></table>");
                            }
                            if (flg == 1)
                            {
                                string fname = ConfigurationSettings.AppSettings["AppListAttach"] + repOff.ToString() + ".html";
                                if (File.Exists(fname))
                                    File.Delete(fname);
                                using (StreamWriter w = new StreamWriter(fname, true))
                                { w.WriteLine(sb.ToString()); }

                                SendMail(dr["Email"].ToString(), "Today's Approvals & Pending Approval List", "Please find attached the List of Approvals done / pending at your level.<br /><br />" + sb.ToString(), fname, "0", "0");
                                sb.Replace(sb.ToString(), "");
                                //SendMail("kvkumar@indimmune.com", "Today's Approvals & Pending Approval List", "<br>This is an automated E-mail <br> Please Don't reply to the mail.", fname, "0", "0");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "--" + repOff + "---ApprovalsList---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void WeeklyAttendanceMail()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlDataAdapter da = new SqlDataAdapter("USP_WeeklyAttendMailStatus_GetStatus", mycon);
                DataSet ds = new DataSet();
                da.Fill(ds);
                string status = "";

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        status = ds.Tables[0].Rows[0]["flag"].ToString();

                        StatusDate = ds.Tables[0].Rows[0]["statusdate"].ToString();
                        LastWeekStatus = ds.Tables[0].Rows[0]["lastweekstatus"].ToString();//change here

                        //ViewState["StatusDate"] = ds.Tables[0].Rows[0]["statusdate"].ToString();
                        //ViewState["LastWeekStatus"] = ds.Tables[0].Rows[0]["lastweekstatus"].ToString();//change here
                    }
                }
                if (status == "1") // Mail will go of the selected week
                {
                    sendWeeklyMail();
                    MakeMailEnable();
                }
                else if (status == "2") //Mail will not go in the current week
                {
                    MakeMailEnable();
                }
                else if (status == "3") // Mail will not go untill unless Send mail option is selected.
                {
                    WriteLog(0, "Mail will not go untill unless Send mail option is selected---WeeklyAttendanceMail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---WeeklyAttendanceMail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void ErrorsReport()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsErrorsReport = new DataSet();
            StringBuilder sb_ErrMessage = new StringBuilder();

            try
            {
                mycommand = new SqlCommand("Usp_Service_getErrorsLog", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter mygetSchedulesAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                mygetSchedulesAdapter.Fill(dsErrorsReport, "ErrorsReport");

                if (dsErrorsReport.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsErrorsReport.Tables[0].Rows)
                    {
                        sb_ErrMessage.Append(dr[0] + "<br><br>");
                    }
                    SendMail(C_Emailid, "Error Report of the Schedules", sb_ErrMessage.ToString(), "0", "0", "0");
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Errors Report---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void AssetInstallation()
        {
            try
            {
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                List<string> input = new List<string>();
                input.Add("");  //Can remove first parameter "not using"                
                XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                s.Timeout = System.Threading.Timeout.Infinite;
                XmlElement xDocTable = (XmlElement)s.GetAssetDataFromSAP(xDoc, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPError[0] == "1000")
                {
                    DataTable data = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    if (data.Rows.Count > 0)
                    {
                        SqlConnection con = null;
                        try
                        {
                            StringWriter swData = new StringWriter();
                            data.WriteXml(swData);
                            con = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand cmd = new SqlCommand("USP_AssetCert_SyncData", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.AddWithValue("@Data", swData.ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            WriteLog(1, "Exception :" + ex.Message + "---AssetInstallation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                        }
                        finally
                        {
                            if (con.State == ConnectionState.Open)
                                con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---AssetInstallation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void ApplicationMails()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
            SqlCommand mycommand = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                mycommand = new SqlCommand("USP_Schedule_getApplicationMails", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myApplicationMails = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myApplicationMails.Fill(ds, "ApplicationMails");
                mycommand.Connection.Close();

                foreach (DataRow drApplicationMails in ds.Tables["ApplicationMails"].Rows)
                {
                    SendMail(drApplicationMails["Email"].ToString(), drApplicationMails["Subject"].ToString(), drApplicationMails["Body"].ToString(), "0", "0", "0");

                    mycommand = new SqlCommand("USP_Schedule_setApplicationMails", mycon);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.Parameters.Add(new SqlParameter("@TemplateId", drApplicationMails["TemplateId"].ToString()));
                    mycommand.CommandTimeout = 800;
                    mycommand.Connection.Open();
                    mycommand.ExecuteNonQuery();
                    mycommand.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Application Mails---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        private void SendSMS()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                DataSet ds = new DataSet();
                //int i = 0;
                mycommand = new SqlCommand("USP_GETSMStobeSent_T", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Flag", 'V'));
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myRepOff = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myRepOff.Fill(ds, "GetSMStobesent");
                mycommand.Connection.Close();

                lcgsmSMS.GSMSMS objSMS = new lcgsmSMS.GSMSMS();
                string strLicName;
                string strLicKey;
                string strLicType;
                strLicName = "Niranjan Bakre";
                strLicKey = "11742148431";
                strLicType = "PROFESSIONAL-DEVELOPER";
                objSMS.License(ref strLicName, ref strLicKey, ref strLicType);
                if (objSMS.IsLicensed)
                {
                    objSMS.COMPort = "COM1";
                    objSMS.BaudRate = 9600;
                    bool bl1 = false;
                    bool bl2 = false;
                    while (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow dr in ds.Tables["GetSMStobesent"].Rows)
                            {
                                objSMS.SendMessage(dr["Message"].ToString(), dr["tono"].ToString(), ref bl1, ref bl2);

                                if (dtSMSData.Columns.Count > 0)
                                {
                                    dtItemsSMS = dtSMSData;
                                }
                                else
                                {
                                    dtItemsSMS = FilldtcolsSMS();
                                    dtSMSData = dtItemsSMS;
                                }
                                drItemsSMS = dtItemsSMS.NewRow();
                                drItemsSMS["SMSID"] = dr["SMSID"].ToString();

                                if (objSMS.ErrorNo != 0)
                                {
                                    Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                                    drItemsSMS["ErrorMsg"] = r.Replace(objSMS.ErrorDescription.ToString(), String.Empty);
                                }
                                dtItemsSMS.Rows.Add(drItemsSMS);
                            }

                            dtItemsSMS.TableName = "SMSDetails";
                            StringWriter SWSMS = new StringWriter();
                            dtItemsSMS.WriteXml(SWSMS);
                            mycommand = new SqlCommand("USP_GETSMStobeSent_T", mycon);
                            mycommand.Parameters.Add(new SqlParameter("@Flag", 'U'));
                            mycommand.Parameters.Add("@SMSDetailsTable", SqlDbType.Xml);
                            mycommand.Parameters["@SMSDetailsTable"].Value = SWSMS.ToString();
                            mycommand.CommandType = CommandType.StoredProcedure;
                            SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            mycommand.Connection.Close();
                            ds.Clear();
                            dtItemsSMS.Clear();
                            dtItemsSMS.Columns.Clear();
                            dtSMSData = null;
                            myAdapter.Fill(ds, "GetSMStobesent");
                            mycommand.Connection.Close();
                        }

                        else
                        {
                            mycommand = new SqlCommand("USP_GETSMStobeSent_T", mycon);
                            mycommand.Parameters.Add(new SqlParameter("@Flag", 'V'));
                            mycommand.CommandType = CommandType.StoredProcedure;
                            myRepOff = new SqlDataAdapter(mycommand);
                            mycommand.Connection.Open();
                            ds.Clear();
                            dtItemsSMS.Clear();
                            dtItemsSMS.Columns.Clear();
                            dtSMSData = null;
                            myRepOff.Fill(ds, "GetSMStobesent");
                            mycommand.Connection.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---SendSMS---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void AutomaticAttendanceUpdation()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
            SqlCommand mycommand = new SqlCommand("USP_ARS_AutomaticAttendanceUpdation", mycon);
            try
            {
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                mycommand.Connection.Open();
                mycommand.ExecuteNonQuery();
                mycommand.Connection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Auto Attendance Upd---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        //keerhti for auto updation of attendance based on shift change ... when ever HR changes the shifts or HOD approves the shift changes, 
        //this should trigger so that attendance will be updated automatically 
        private void AutoAttUpdBasedonShiftChanges()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
            SqlCommand mycommand = new SqlCommand("USP_ARS_AutoAttenOnSftChanges", mycon);
            try
            {
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                mycommand.Connection.Open();
                mycommand.ExecuteNonQuery();
                mycommand.Connection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Auto Attendance onsft Chnages---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void sendSalesSMS()
        {
            try
            {
                DataSet dsAppSMS = new DataSet();
                DataTable dtAppSMS = new DataTable();
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                mycommand = new SqlCommand("USP_GetDatesRequiredforSMS_T", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myadapterGlobal = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myadapterGlobal.Fill(dsAppSMS, "Getdates");
                mycommand.Connection.Close();

                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                s.Timeout = 99999999;
                List<string> input = new List<string>();

                input.Add(dsAppSMS.Tables[0].Rows[0]["Monthstartday"].ToString()); //Pass startdate of the month
                input.Add(dsAppSMS.Tables[0].Rows[0]["Today"].ToString());         //Pass today's date
                input.Add(dsAppSMS.Tables[0].Rows[0]["FyrStartDate"].ToString()); //Pass startdate of the month
                input.Add(dsAppSMS.Tables[0].Rows[0]["FyrEndDate"].ToString());         //Pass today's date

                // input.Add("20110401");
                // input.Add("20111030");
                // input.Add("20110401");
                //  input.Add("20111030");

                //Call RFC For Sales Details
                XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                XmlElement xDocTable = (XmlElement)s.GetSalesDashboard(xDoc, out xmlException);

                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                //if call is success
                if (SAPError[0] == "1000")
                {
                    DataSet ds1 = new DataSet();
                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);

                    //if sales details exists
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //get empno and segments mapped
                        int dday = (int)System.DateTime.Now.Day;
                        int sday = 23; //this should be same as sap method day
                        mycommand = new SqlCommand("USP_GetEmpSegmentsandPhonenos", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter myadapter = new SqlDataAdapter(mycommand);
                        mycommand.Connection.Open();
                        myadapter.Fill(ds1, "GetDetails");
                        mycommand.Connection.Close();
                        //if emps with segments mapped exists then  
                        if (ds1 != null && ds1.Tables.Count > 0)
                        {
                            DataColumn dc;
                            dc = new DataColumn("SegCode");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("Message");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("Sale");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("Coll");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("outstd");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("YrSales");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("YrColl");
                            dtAppSMS.Columns.Add(dc);
                            dc = new DataColumn("DivCode");
                            dtAppSMS.Columns.Add(dc);

                            //loop for formating message to be sent for each segment
                            foreach (DataRow dr1 in ds1.Tables[0].Rows)
                            {
                                string segcode = dr1["SegCode"].ToString();
                                while (segcode.ToString().Trim().Length < 3)
                                {
                                    segcode = "0" + segcode;
                                }
                                //checking if sales data exists for each segment
                                DataRow[] drs = dt.Select("segment ='" + segcode + "' ");

                                //if exits,get sale,colection and outstanding
                                if (drs.Length > 0)
                                {
                                    decimal Sale = Convert.ToDecimal(drs[0]["Sales"].ToString()) / 100000;
                                    decimal coll = Convert.ToDecimal(drs[0]["Collection"].ToString()) / 100000;
                                    decimal outst = Convert.ToDecimal(drs[0]["OutStanding"].ToString()) / 100000;
                                    decimal Ysale = Convert.ToDecimal(drs[0]["YearlySales"].ToString()) / 100000;
                                    decimal Ycoll = Convert.ToDecimal(drs[0]["YearlyCollection"].ToString()) / 100000;

                                    //also get divcode and segment name to format message to send
                                    DataRow[] drs1 = ds1.Tables[1].Select("segcode ='" + dr1["SegCode"].ToString() + "' ");

                                    if (drs1.Length > 0)
                                    {
                                        if (Sale != 0 || coll != 0 || outst != 0)
                                        {
                                            string msg = "";
                                            if (dday < sday)
                                            {
                                                msg = drs1[0]["Segname2"].ToString() + " " + Math.Abs((Math.Round(Sale, 2))).ToString() + "; " + Math.Abs(Math.Round(coll, 2)).ToString() + "; " + Math.Abs(Math.Round(outst, 2)).ToString();
                                            }
                                            else
                                            {
                                                msg = drs1[0]["Segname2"].ToString() + " " + Math.Abs((Math.Round(Sale, 2))).ToString();
                                            }
                                            //  string msg = drs1[0]["Segname2"].ToString() + " " + Math.Abs((Math.Round(Sale, 2))).ToString() + "; " + Math.Abs(Math.Round(coll, 2)).ToString() + "; " + Math.Abs(Math.Round(outst, 2)).ToString();
                                            DataRow drItems = dtAppSMS.NewRow();
                                            drItems["SegCode"] = drs1[0]["Segcode"].ToString();
                                            drItems["Message"] = msg;
                                            drItems["Sale"] = Sale;
                                            drItems["coll"] = coll;
                                            drItems["outstd"] = outst;
                                            drItems["YrSales"] = Ysale;
                                            drItems["YrColl"] = Ycoll;
                                            drItems["DivCode"] = drs1[0]["DivCode"].ToString();
                                            dtAppSMS.Rows.Add(drItems);
                                        }
                                    }
                                }
                            }

                            //if emps with segments mapped exists then  
                            if (ds1 != null && ds1.Tables.Count > 1)
                            {
                                string empid = "";
                                string message = "";
                                int flag = 0;
                                string divname = "";
                                int divcode = 0;
                                decimal ysale = 0;
                                decimal ycoll = 0;
                                decimal youtsd = 0;
                                string tono = "";
                                DataRow drfinal;
                                DataTable dtfinal = new DataTable();
                                DataColumn dc2;
                                dc2 = new DataColumn("EmpId");
                                dtfinal.Columns.Add(dc2);
                                dc2 = new DataColumn("Message");
                                dtfinal.Columns.Add(dc2);
                                dc2 = new DataColumn("Tono");
                                dtfinal.Columns.Add(dc2);
                                dc2 = new DataColumn("Dateofmsg");
                                dtfinal.Columns.Add(dc2);
                                //loop each emp with segments, if employee is mapped for more than 1 segment, take the sum of the segemnts sale,outsating and collections
                                DataTable dtk = new DataTable();
                                dtk = ds1.Tables[1];
                                DataView view = new DataView(dtk);
                                DataTable distinctValues = view.ToTable(true, "EmpId");
                                foreach (DataRow dr3 in distinctValues.Rows)
                                {
                                    DataRow[] drs5 = ds1.Tables[1].Select("EmpId ='" + dr3["EmpId"].ToString() + "' ");
                                    DataTable dtk1 = drs5.CopyToDataTable();
                                    dtk1.DefaultView.Sort = "divcode,segcode";
                                    foreach (DataRow dr1 in dtk1.Rows)
                                    {
                                        if (divcode.ToString() != "0" && divcode.ToString() != dr1["DivCode"].ToString())
                                        {
                                            if (empid.ToString() != "" && message.ToString() != "")
                                            {
                                                if (flag > 0)
                                                {
                                                    DataRow[] drs2 = dtAppSMS.Select("Divcode ='" + divcode + "' ");
                                                    if (drs2.Length > 0)
                                                    {
                                                        for (int k = 0; k < drs2.Length; k++)
                                                        {
                                                            DataRow[] drs3 = ds1.Tables[1].Select("empid ='" + empid + "' and divcode ='" + divcode + "' and segcode = '" + drs2[k]["SegCode"].ToString() + "' ");
                                                            if (drs3.Length > 0)
                                                            {
                                                                ysale = ysale + Math.Abs(Convert.ToDecimal(drs2[k]["Sale"].ToString()));
                                                                ycoll = ycoll + Math.Abs(Convert.ToDecimal(drs2[k]["coll"].ToString()));
                                                                youtsd = youtsd + Math.Abs(Convert.ToDecimal(drs2[k]["outstd"].ToString()));
                                                            }
                                                        }
                                                        ysale = Math.Round(ysale, 2);
                                                        ycoll = Math.Round(ycoll, 2);
                                                        youtsd = Math.Round(youtsd, 2);
                                                    }
                                                    // message = divname.ToString() + " S; C; O Rs(L) " + message + " Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                    if (dtk1.Rows.Count > 10)
                                                    {
                                                        if (divname == "EE")
                                                        {
                                                            if (dday < sday)
                                                            {
                                                                message = divname.ToString() + " S; C; O Rs(L) Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                            }
                                                            else
                                                            {
                                                                message = divname.ToString() + " S Rs(L) Tot " + ysale;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (dday < sday)
                                                            {
                                                                message = divname.ToString() + " S; C; O Rs(L) " + message + " Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                            }
                                                            else
                                                            {
                                                                message = divname.ToString() + " S Rs(L) " + message + " Tot " + ysale;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (dday < sday)
                                                        {
                                                            message = divname.ToString() + " S; C; O Rs(L) " + message + " Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                        }
                                                        else
                                                        {
                                                            message = divname.ToString() + " S Rs(L) " + message + " Tot " + ysale;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (dday < sday)
                                                    {
                                                        message = divname.ToString() + " S; C; O Rs(L) " + message;
                                                    }
                                                    else
                                                    {
                                                        message = divname.ToString() + " S Rs(L) " + message;
                                                    }
                                                }
                                                drfinal = dtfinal.NewRow();
                                                drfinal["EmpId"] = empid.ToString();
                                                drfinal["Message"] = message.ToString();
                                                drfinal["Tono"] = tono.ToString();
                                                drfinal["Dateofmsg"] = null;
                                                dtfinal.Rows.Add(drfinal);
                                                message = "";
                                                tono = "";
                                                divcode = 0;
                                                flag = 0;
                                                ysale = 0;
                                                ycoll = 0;
                                                youtsd = 0;
                                            }
                                        }
                                        empid = dr1["EmpId"].ToString();
                                        DataRow[] drs1 = dtAppSMS.Select("segcode ='" + dr1["SegCode"].ToString() + "' ");
                                        if (drs1.Length > 0)
                                        {
                                            tono = dr1["Tono"].ToString();
                                            divname = dr1["Divname"].ToString();
                                            divcode = Convert.ToInt16(dr1["Divcode"].ToString());
                                            if (message.ToString() == "")
                                            {
                                                message = drs1[0]["Message"].ToString();
                                            }
                                            else
                                            {
                                                flag = 1;
                                                message = message + " " + drs1[0]["Message"].ToString();
                                            }
                                        }
                                    }

                                    if ((dtk1.Rows.Count == 1) || (message != null && message != ""))
                                    {
                                        if (empid.ToString() != "" && message.ToString() != "")
                                        {
                                            if (flag > 0)
                                            {
                                                DataRow[] drs2 = dtAppSMS.Select("Divcode ='" + divcode + "' ");
                                                if (drs2.Length > 0)
                                                {
                                                    for (int k = 0; k < drs2.Length; k++)
                                                    {
                                                        DataRow[] drs3 = ds1.Tables[1].Select("empid ='" + empid + "' and divcode ='" + divcode + "' and segcode = '" + drs2[k]["SegCode"].ToString() + "' ");
                                                        if (drs3.Length > 0)
                                                        {
                                                            ysale = ysale + Math.Abs(Convert.ToDecimal(drs2[k]["Sale"].ToString()));
                                                            ycoll = ycoll + Math.Abs(Convert.ToDecimal(drs2[k]["coll"].ToString()));
                                                            youtsd = youtsd + Math.Abs(Convert.ToDecimal(drs2[k]["outstd"].ToString()));
                                                        }
                                                    }
                                                    ysale = Math.Round(ysale, 2);
                                                    ycoll = Math.Round(ycoll, 2);
                                                    youtsd = Math.Round(youtsd, 2);
                                                }

                                                //  message = divname.ToString() + " S; C; O Rs(L) " + message + " Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                if (dtk1.Rows.Count > 10)
                                                {
                                                    if (divname == "EE")
                                                    {
                                                        if (dday < sday)
                                                        {
                                                            message = divname.ToString() + " S; C; O Rs(L) Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                        }
                                                        else
                                                        {
                                                            message = divname.ToString() + " S Rs(L) Tot " + ysale;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (dday < sday)
                                                        {
                                                            message = divname.ToString() + " S; C; O Rs(L) " + message + " Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                        }
                                                        else
                                                        {
                                                            message = divname.ToString() + " S Rs(L) " + message + " Tot " + ysale;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (dday < sday)
                                                    {
                                                        message = divname.ToString() + " S; C; O Rs(L) " + message + " Tot " + ysale + " ; " + ycoll + " ; " + youtsd;
                                                    }
                                                    else
                                                    {
                                                        message = divname.ToString() + " S Rs(L) " + message + " Tot " + ysale;
                                                    }
                                                }
                                            }
                                            else
                                            {

                                                if (dday < sday)
                                                {
                                                    message = divname.ToString() + " S; C; O Rs(L) " + message;
                                                }
                                                else
                                                {
                                                    message = divname.ToString() + " S Rs(L) " + message;
                                                }
                                            }
                                            drfinal = dtfinal.NewRow();
                                            drfinal["EmpId"] = empid.ToString();
                                            drfinal["Message"] = message.ToString();
                                            drfinal["Tono"] = tono.ToString();
                                            drfinal["Dateofmsg"] = null;
                                            dtfinal.Rows.Add(drfinal);
                                            message = "";
                                            tono = "";
                                            divcode = 0;
                                            flag = 0;
                                            ysale = 0;
                                            ycoll = 0;
                                            youtsd = 0;
                                        }
                                    }
                                }
                                //if dtfinal !="" send to DB to insert in sms information table
                                if (dtfinal.Rows.Count > 0)
                                {
                                    dtfinal.TableName = "SMSDetails";
                                    StringWriter SWSMS = new StringWriter();
                                    dtfinal.WriteXml(SWSMS);
                                    mycommand = new SqlCommand("USP_GETSMStobeSent_T", mycon);
                                    mycommand.Parameters.Add("@SMSDetailsTable", SqlDbType.Xml);
                                    mycommand.Parameters["@SMSDetailsTable"].Value = SWSMS.ToString();
                                    mycommand.Parameters.Add(new SqlParameter("@Flag", "I"));
                                    mycommand.Parameters.Add(new SqlParameter("@CreatedBy", "ADMIN"));
                                    mycommand.Parameters.Add(new SqlParameter("@SMSApptypeId", 2));
                                    mycommand.CommandType = CommandType.StoredProcedure;
                                    mycommand.CommandTimeout = 800;
                                    SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);

                                    mycommand.Connection.Open();
                                    mycommand.ExecuteNonQuery();
                                    mycommand.Connection.Close();
                                    message = "";
                                    tono = "";
                                    divcode = 0;
                                    flag = 0;
                                    ysale = 0;
                                    ycoll = 0;
                                    youtsd = 0;
                                    empid = "";
                                }
                            }
                        }
                    }
                }
                else
                {
                    WriteLog(1, "Exception :---SAPSTN SMS---" + SAPError[1] + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "Sending Sales SMS" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void GetSentSMS()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                DataSet ds = new DataSet();
                StringBuilder strSMSSumm = new StringBuilder();
                mycommand = new SqlCommand("USP_GET_SMSSentReport", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 800;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "GETSMSSENT");
                mycommand.Connection.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int SMS1, SMS2, SMS3, SMS4, SMST;
                        SMS1 = 0;
                        SMST = SMS4 = SMS3 = SMS2 = SMS1;
                        strSMSSumm.Append("<b>Application wise Summary for the SMS sent during last 24 hours.</b><br><br>");
                        strSMSSumm.Append("<Table border='1'><tr bgcolor='#0080FF'><th align='left'><font color='#FFFFFF'>SMS Type</font></th>");
                        strSMSSumm.Append("<th align='left'><font color='#FFFFFF'>Successful</font></th><th align='left'><font color='#FFFFFF'>Error Occurred</font></th>");
                        strSMSSumm.Append("<th align='left'><font color='#FFFFFF'>Rejected</font></th><th align='left'><font color='#FFFFFF'>Time Out</font></th><th align='left'><font color='#FFFFFF'>Total</font></th></tr>");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            strSMSSumm.Append("<tr>");
                            strSMSSumm.Append("<td align='left'>" + Convert.ToString(dr["SMSType"]) + "</td>");
                            SMS1 = SMS1 + Convert.ToInt32(dr["Successful"].ToString());
                            strSMSSumm.Append("<td align='right'>" + Convert.ToString(dr["Successful"]) + "</td>");
                            SMS2 = SMS2 + Convert.ToInt32(dr["ErrorOccured"].ToString());
                            strSMSSumm.Append("<td align='right'>" + Convert.ToString(dr["ErrorOccured"]) + "</td>");
                            SMS3 = SMS3 + Convert.ToInt32(dr["Rejected"].ToString());
                            strSMSSumm.Append("<td align='right'>" + Convert.ToString(dr["Rejected"]) + "</td>");
                            SMS4 = SMS4 + Convert.ToInt32(dr["TimedOut"].ToString());
                            strSMSSumm.Append("<td align='right'>" + Convert.ToString(dr["TimedOut"]) + "</td>");
                            SMST = Convert.ToInt32(dr["Successful"].ToString()) + Convert.ToInt32(dr["ErrorOccured"].ToString()) + Convert.ToInt32(dr["Rejected"].ToString()) + Convert.ToInt32(dr["TimedOut"].ToString());
                            strSMSSumm.Append("<td align='right'>" + Convert.ToString(SMST) + "</td>");
                            strSMSSumm.Append("</tr>");
                        }
                        strSMSSumm.Append("<tr><td></td>");
                        strSMSSumm.Append("<th align='right'>" + SMS1.ToString() + "</th><th align='right'>" + SMS2.ToString() + "</th>");
                        strSMSSumm.Append("<th align='right'>" + SMS3.ToString() + "</th><th align='right'>" + SMS4.ToString() + "</th>");
                        SMST = SMS1 + SMS2 + SMS3 + SMS4;
                        strSMSSumm.Append("<th align='right'>" + SMST.ToString() + "</th>");
                        strSMSSumm.Append("</tr>");
                        strSMSSumm.Append("</Table>");
                        if ((SMS1 == 0 && SMST > 0) || (SMS1 < SMST - SMS1))
                        {
                            SendMail(C_Emailid, "Error in SMS Program.", strSMSSumm.ToString(), "0", "0", C_EmailCC);
                        }
                        else
                        {
                            SendMail(C_Emailid, "Summary of SMS sent during last 24 hours", strSMSSumm.ToString(), "0", "0", C_EmailCC);
                        }
                    }
                    else
                    {
                        strSMSSumm.Append("No SMS Sent during last 24 hours.<br>Please check the system.");
                        SendMail(C_Emailid, "No SMS Generated. Please check the Schedules.", strSMSSumm.ToString(), "0", "0", C_EmailCC);
                    }


                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Get SMS Sent---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void SendSTNSMS()
        {
            try
            {
                DataSet dsAppSMS = new DataSet();
                DataTable dtAppSMS = new DataTable();

                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                mycommand = new SqlCommand("USP_GetDatesRequiredforSMS_T", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myadapterGlobal = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myadapterGlobal.Fill(dsAppSMS, "Getdates");
                mycommand.Connection.Close();

                DataTable dtcust = new DataTable();
                DataTable dtfinal = new DataTable();
                DataSet dsDocs = new DataSet();
                DataColumn dc2;
                dc2 = new DataColumn("EmpId");
                dtfinal.Columns.Add(dc2);
                dc2 = new DataColumn("Message");
                dtfinal.Columns.Add(dc2);
                dc2 = new DataColumn("Tono");
                dtfinal.Columns.Add(dc2);
                dc2 = new DataColumn("Dateofmsg");
                dtfinal.Columns.Add(dc2);
                int flag = 0;
                string tolocation = "";
                string message = "";
                string tono = "";
                string docno = "";
                string custno = "";
                DataTable dtdocs = new DataTable();
                dc2 = new DataColumn("Docno");
                dtdocs.Columns.Add(dc2);

                //Gets STN's from SAP
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);

                List<string> input = new List<string>();
                input.Add(dsAppSMS.Tables[0].Rows[0]["Yesterday"].ToString());
                input.Add(dsAppSMS.Tables[0].Rows[0]["Yesterday"].ToString());

                // input.Add("20120627");
                // input.Add("20120627");

                XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                XmlElement xDocTable = (XmlElement)s.GetSTNDetails(xDoc, out xmlException);

                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                if (SAPError[0] == "1000")
                {
                    //if STN's Exists
                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    if (dt.Rows.Count > 0)
                    {
                        List<string> input1 = new List<string>();
                        mycommand = new SqlCommand("USP_STNDocs", mycon);
                        mycommand.Parameters.Add(new SqlParameter("@Flag", 'V'));
                        mycommand.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                        myAdapter = new SqlDataAdapter(mycommand);
                        mycommand.Connection.Open();
                        myAdapter.Fill(dsDocs, "GetSTNDocs");
                        mycommand.Connection.Close();
                        DataView dv = dt.DefaultView;
                        DataTable dt1 = new DataTable();
                        dv.RowFilter = string.Format("substring(Materialgroup,3,1) ='B'");
                        dt1 = dv.ToTable();
                        dt.Clear();
                        if (dt1.Rows.Count > 0)
                        {
                            dt = dt1.Copy();
                        }

                        dt1.Clear();

                        if (dsDocs != null && dsDocs.Tables.Count > 0)
                        {
                            if (dsDocs.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow d in dt.Rows)
                                {
                                    DataRow[] drsdoc = dsDocs.Tables[0].Select("Documentno ='" + d["STNDocumentNo"].ToString() + "' ");
                                    if (drsdoc.Length > 0)
                                    {
                                    }
                                    else
                                    {
                                        dt1.ImportRow(d);
                                    }
                                }
                            }
                        }

                        if (dt1.Rows.Count > 0)
                        {
                            dt.Clear();
                            dt = dt1.Copy();
                        }
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (flag <= 0)
                            {
                                DataColumn dc;
                                dc = new DataColumn("Customer");
                                dtcust.Columns.Add(dc);
                                dc = new DataColumn("Tono");
                                dtcust.Columns.Add(dc);

                                input1.Add("KNA1");
                                input1.Add("TELF2 NE ''");
                                input1.Add("KUNNR|NAME1|TELF2");

                                XmlDocument xDoc1 = XMLSerializerBL.Serialize(input1, XMLSerializerBL.InputType.List);
                                XmlNode xmlException1 = null;
                                XmlElement xDocTable1 = (XmlElement)s.GetTableData(xDoc1, out xmlException1);
                                List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlException1.OuterXml, XMLSerializerBL.OutputType.List);
                                if (SAPError1[0] == "1000")
                                {
                                    dtcust = (DataTable)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                }
                                else
                                {
                                    WriteLog(1, SAPError1[1] + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                }
                                flag = 1;
                            }

                            if (dtcust != null && dtcust.Rows.Count > 0)
                            {
                                if (tolocation.ToString() != dr1["Tolocation"].ToString())
                                {
                                    if (tolocation.ToString() != "")
                                    {
                                        custno = tolocation;
                                        while (custno.ToString().Length < 10)
                                            custno = "0" + custno;

                                        DataRow[] drs1 = dtcust.Select("Customer ='" + custno.ToString() + "' ");
                                        if (drs1.Length > 0)
                                        {
                                            tono = drs1[0]["Phoneno"].ToString();
                                            DataRow drfinal = dtfinal.NewRow();
                                            drfinal["EmpId"] = "";
                                            drfinal["Message"] = message.ToString();
                                            drfinal["Tono"] = tono.ToString();
                                            drfinal["Dateofmsg"] = null;
                                            dtfinal.Rows.Add(drfinal);
                                        }
                                    }
                                    message = "";
                                    tono = "";
                                    tolocation = dr1["Tolocation"].ToString();
                                }
                                if (message == "")
                                {
                                    docno = dr1["STNDocumentNo"].ToString();
                                    message = "STN No:" + dr1["STNDocumentNo"].ToString() + " ;F Loc:" + dr1["FromLocation"].ToString() + ";No Cases:" + dr1["NoofCases"].ToString() + ";LRNo:" + dr1["LRNumber"].ToString() + ";LRdate:" + dr1["LRDate"].ToString() + ";TName:" + dr1["VehicleNo"].ToString();
                                    DataRow drdoc = dtdocs.NewRow();
                                    drdoc["Docno"] = docno.ToString();
                                    dtdocs.Rows.Add(drdoc);

                                }
                                else
                                {
                                    if (docno.ToString() != dr1["STNDocumentNo"].ToString())
                                    {
                                        message = message + " / " + "STN No:" + dr1["STNDocumentNo"].ToString() + " ;F Loc:" + dr1["FromLocation"].ToString() + ";No Cases:" + dr1["NoofCases"].ToString() + ";LRNo:" + dr1["LRNumber"].ToString() + ";LRdate:" + dr1["LRDate"].ToString() + ";TName:" + dr1["VehicleNo"].ToString();
                                        docno = dr1["STNDocumentNo"].ToString();
                                        DataRow drdoc = dtdocs.NewRow();
                                        drdoc["Docno"] = docno.ToString();
                                        dtdocs.Rows.Add(drdoc);
                                    }
                                }
                            }
                        }

                        if (tolocation.ToString() != "")
                        {
                            custno = tolocation;
                            while (custno.ToString().Length < 10)
                                custno = "0" + custno;

                            DataRow[] drs1 = dtcust.Select("Customer ='" + custno.ToString() + "' ");
                            if (drs1.Length > 0)
                            {
                                tono = drs1[0]["Phoneno"].ToString();
                                DataRow drfinal = dtfinal.NewRow();
                                drfinal["EmpId"] = "";
                                drfinal["Message"] = message.ToString();
                                drfinal["Tono"] = tono.ToString();
                                drfinal["Dateofmsg"] = null;
                                dtfinal.Rows.Add(drfinal);
                            }
                        }
                        message = "";
                        tono = "";
                        tolocation = "";

                        //if dtfinal !="" send to DB to insert in sms information table
                        if (dtfinal.Rows.Count > 0)
                        {
                            dtfinal.TableName = "SMSDetails";
                            StringWriter SWSMS = new StringWriter();
                            dtfinal.WriteXml(SWSMS);
                            mycommand = new SqlCommand("USP_GETSMStobeSent_T", mycon);
                            mycommand.Parameters.Add("@SMSDetailsTable", SqlDbType.Xml);
                            mycommand.Parameters["@SMSDetailsTable"].Value = SWSMS.ToString();
                            mycommand.Parameters.Add(new SqlParameter("@Flag", "I"));
                            mycommand.Parameters.Add(new SqlParameter("@CreatedBy", "ADMIN"));
                            mycommand.Parameters.Add(new SqlParameter("@SMSApptypeId", 1));
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            mycommand.Connection.Close();
                            message = "";
                        }
                        if (dtdocs.Rows.Count > 0)
                        {
                            dtdocs.TableName = "STNDocuments";
                            StringWriter SWSTNDOCS = new StringWriter();
                            dtdocs.WriteXml(SWSTNDOCS);
                            mycommand = new SqlCommand("USP_STNDocs", mycon);
                            mycommand.Parameters.Add("@STNDetailsTable", SqlDbType.Xml);
                            mycommand.Parameters["@STNDetailsTable"].Value = SWSTNDOCS.ToString();
                            mycommand.Parameters.Add(new SqlParameter("@Flag", "I"));
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            mycommand.Connection.Close();
                        }

                    }

                }
                else
                {
                    WriteLog(1, "Exception :---SAPSTN SMS---" + SAPError[1] + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }

            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Sending STN SMS---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void AutomaticShiftUpdate()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                mycommand = new SqlCommand("USP_ARS_ShiftGeneration", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "Roster");

            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---AutomaticShiftUpdate---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        private void StabilityTest()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsStabilityTest = new DataSet();
            try
            {
                mycommand = new SqlCommand("Usp_QC_TestStability_Mail", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dsStabilityTest, "StabilityTest");

                if (dsStabilityTest.Tables.Count > 2)
                {
                    if ((dsStabilityTest.Tables[0].Rows.Count > 0) && (dsStabilityTest.Tables[1].Rows.Count > 0)) //mail ids & plants
                    {
                        foreach (DataRow drPlant in dsStabilityTest.Tables[0].Rows)
                        {
                            DataRow[] drMailId = dsStabilityTest.Tables[1].Select("Plant = '" + Convert.ToString(drPlant["Plant"]) + "'");
                            if (drMailId.Length > 0)
                            {
                                DataRow[] drDailyPlnt = dsStabilityTest.Tables[2].Select("Plant = '" + Convert.ToString(drPlant["Plant"]) + "'");
                                DataRow[] drTwoDayPlnt = dsStabilityTest.Tables[3].Select("Plant = '" + Convert.ToString(drPlant["Plant"]) + "'");

                                StringBuilder sbMailId = new StringBuilder();
                                StringBuilder sbDaily = new StringBuilder();
                                StringBuilder sbTwoDayPlnt = new StringBuilder();
                                StringBuilder sbWeeklPlnt = new StringBuilder();
                                int flg = 0;

                                if (drDailyPlnt.Length > 0)
                                {
                                    flg = 1;
                                    sbDaily.Append("The following Stability Test(s) are due for today:<br>");
                                    sbDaily.Append("<table border = '1' cellspacing='0' cellpadding='2' width='100%'>");
                                    sbDaily.Append("<tr bgcolor='#507CD1'>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Product             </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Batch No            </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Mfg. Date           </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Exp. Date           </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Zero Day            </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Remarks             </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Frequency Month     </td>");
                                    sbDaily.Append("<td align='left' valign='bottom'>Stability Test Date </td>");
                                    sbDaily.Append("</tr>");
                                    foreach (DataRow drDaily in drDailyPlnt)
                                    {
                                        sbDaily.Append("<tr>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["ItemDesc"]) + "       </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["Batch"]) + "          </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["MfgDate"]) + "        </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["ExpDate"]) + "        </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["InitiationDate"]) + " </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["Remarks"]) + "        </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["frequencyMon"]) + "   </td>");
                                        sbDaily.Append("<td align='left' valign='top'>" + Convert.ToString(drDaily["StabTestDate"]) + "   </td>");
                                        sbDaily.Append("</tr>");
                                    }
                                    sbDaily.Append("</table><br>");
                                }
                                if (drTwoDayPlnt.Length > 0)
                                {
                                    flg = 1;
                                    sbTwoDayPlnt.Append("Stability Test(s) reminder one day in advance:<br>");
                                    //sbTwoDayPlnt.Append("<tr bgcolor=#507CD1><td>Item</td><td>Batch</td><td>Manufacture Date</td><td>Expiry Date</td><td>Zero Day</td><td>Remarks</td><td>Frequency Month</td><td>Stability Test Date</td></tr>");
                                    sbTwoDayPlnt.Append("<table border = '1' cellspacing = '1' cellpadding = '2' width='100%'>");
                                    sbTwoDayPlnt.Append("<tr bgcolor='#507CD1'>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Product</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Batch No</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Mfg. Date</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Exp. Date</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Zero Day</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Remarks</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Frequency Month</td>");
                                    sbTwoDayPlnt.Append("<td align='left' valign='bottom'>Stability Test Date</td>");
                                    sbTwoDayPlnt.Append("</tr>");
                                    foreach (DataRow drTwoDaysbf in drTwoDayPlnt)
                                    {
                                        sbTwoDayPlnt.Append("<tr>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["ItemDesc"]) + "       </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["Batch"]) + "          </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["MfgDate"]) + "        </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["ExpDate"]) + "        </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["InitiationDate"]) + " </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["Remarks"]) + "        </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["frequencyMon"]) + "   </td>");
                                        sbTwoDayPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drTwoDaysbf["StabTestDate"]) + "   </td>");
                                        sbTwoDayPlnt.Append("</tr>");
                                    }
                                    sbTwoDayPlnt.Append("</table><br>");
                                }
                                if (dsStabilityTest.Tables.Count > 4) //for weekly mail (as we are pulling it as 5th table
                                {
                                    DataRow[] drWeeklPlnt = dsStabilityTest.Tables[4].Select("Plant = '" + Convert.ToString(drPlant["Plant"]) + "'");
                                    if (drWeeklPlnt.Length > 0)
                                    {
                                        flg = 1;
                                        sbWeeklPlnt.Append("Stability Test(s) Schedule for the week.<br>");
                                        //sbWeeklPlnt.Append("<tr bgcolor=#507CD1><td>Item</td><td>Batch</td><td>Manufacture Date</td><td>Expiry Date</td><td>Frequency Month</td><td>Zero Day</td><td>Remarks</td><td>Stability Test Date</td></tr>");
                                        sbWeeklPlnt.Append("<table border = '1' cellspacing = '1' cellpadding = '2' width='100%'>");
                                        sbWeeklPlnt.Append("<tr bgcolor='#507CD1'>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Product</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Batch No</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Mfg. Date</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Exp. Date</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Zero Day</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Remarks</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Frequency Month</td>");
                                        sbWeeklPlnt.Append("<td align='left' valign='bottom'>Stability Test Date</td>");
                                        sbWeeklPlnt.Append("</tr>");
                                        foreach (DataRow drWeekly in drWeeklPlnt)
                                        {
                                            sbWeeklPlnt.Append("<tr>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["ItemDesc"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["Batch"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["MfgDate"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["ExpDate"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["InitiationDate"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["Remarks"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["frequencyMon"]) + "</td>");
                                            sbWeeklPlnt.Append("<td align='left' valign='top'>" + Convert.ToString(drWeekly["StabTestDate"]) + "</td>");
                                            sbWeeklPlnt.Append("</tr>");
                                        }
                                        sbWeeklPlnt.Append("</table>");
                                    }
                                }
                                if (flg == 1)
                                {
                                    foreach (DataRow drMail in drMailId)
                                    {
                                        sbMailId.Append(Convert.ToString(drMail["MailId"]) + ";");
                                    }
                                    SendMail(sbMailId.ToString(), "Stability Test Reminder", "Dear Sir/Madam,<br><br>Greetings!!<br><br>" + Convert.ToString(sbDaily) + "<br><br>" + Convert.ToString(sbTwoDayPlnt) + "<br><br>" + Convert.ToString(sbWeeklPlnt), "0", "0", "0");
                                }
                            }   //mail ids not available for the looping plant
                        }   //looping plant
                    }  //mail ids or plants are not maintained
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---StabilityTest---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void TrackerUpload()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dstracker = new DataSet();
            try
            {
                mycommand = new SqlCommand("usp_trackerupload_mail", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dstracker, "Tracker Upload Test");
                if (dstracker == null) { }
                else if (dstracker.Tables[0].Rows.Count > 0) //mail ids & blocks
                {
                    DataView dv = new DataView(dstracker.Tables[0]);
                    if (dv.ToTable(true, "empid").Rows.Count > 0)
                    {
                        foreach (DataRow drinstr in dv.ToTable(true, "empid").Rows)
                        {
                            DataView dv1 = new DataView(dstracker.Tables[0]);
                            dv1.RowFilter = "empid='" + drinstr["empid"].ToString() + "'";
                            if (dv1.ToTable().Rows.Count > 0)
                            {
                                StringBuilder sbMailId = new StringBuilder();
                                StringBuilder sbDaily = new StringBuilder();

                                sbDaily.Append("Tracker Upload Test Weekly Schedule <br><br><table border='1' style='background-color=#EFF3FB' BorderWidth='1px'>");
                                sbDaily.Append("<tr style='background-color=#507CD1'><td>Tracker Type</td><td>Block</td><td>Instrumentid</td><td>Test Date</td><td>Frequency(in months)</td></tr>");
                                foreach (DataRow drDaily in dv1.ToTable().Rows)
                                {
                                    sbDaily.Append("<tr><td>" + Convert.ToString(drDaily["TrackerType"]) + "</td>");
                                    sbDaily.Append("<td>" + Convert.ToString(drDaily["Block"]) + "</td>");
                                    sbDaily.Append("<td>" + Convert.ToString(drDaily["Instrumentid"]) + "</td>");
                                    sbDaily.Append("<td>" + Convert.ToString(drDaily["FreqDate"]) + "</td>");
                                    sbDaily.Append("<td>" + Convert.ToString(drDaily["Frequency"]) + "</td></tr>");
                                }
                                sbDaily.Append("</table>");

                                if (dv1.ToTable(true, "email").Rows[0]["email"].ToString() != "")
                                {
                                    //sbMailId.Append(Convert.ToString(drMail["MailId"]) + ";");
                                    SendMail(dv1.ToTable(true, "email").Rows[0]["email"].ToString(), "Tracker Upload Test", "Dear Sir/Madam, <br><br> " + Convert.ToString(sbDaily), "0", "0", "0");
                                }

                            }
                        }   //looping plant
                    }
                }  //mail ids or blocks are not maintained


            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Tracker Upload---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        public void SAPCostCenterUpdationEmployeeWise()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsStabilityTest = new DataSet();
            try
            {
                SAPService Con = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceURL"]);

                List<string> inputCC = new List<string>();
                inputCC.Add("COAS");
                inputCC.Add("AUART EQ '2000'");
                inputCC.Add("AUFNR|KOSTV");
                XmlDocument xDocLocStat = XMLSerializerBL.Serialize(inputCC, XMLSerializerBL.InputType.List);
                XmlNode xmlExceptionLocStat = null;
                XmlElement xDocTableLocStat = (XmlElement)Con.GetTableData(xDocLocStat, out xmlExceptionLocStat);
                List<string> SAPErrorLocStat = (List<string>)XMLSerializerBL.Deserialize(xmlExceptionLocStat.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPErrorLocStat[0] == "1000")
                {
                    DataTable dtfinal = new DataTable("CostCenterUpdationEmployee");
                    DataRow drfinal = dtfinal.NewRow();
                    dtfinal.Columns.Add("Empid");
                    dtfinal.Columns.Add("CostCenter");
                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTableLocStat.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            drfinal = dtfinal.NewRow();
                            //if (dr["Empid"].ToString() != "NOT TO USE" || dr["Costcenter"].ToString() != "NOT TO USE") //Commented by Raveesh on 27/10/2015
                            if (dr["IntOrdNo"].ToString() != "NOT TO USE" || dr["IntOrdName"].ToString() != "NOT TO USE")
                            {
                                string EmpidS = dr[0].ToString().Trim();
                                string TempCostCenter = dr[1].ToString().Trim();
                                drfinal["Empid"] = EmpidS.Substring(((EmpidS.Length) - 6), 6);
                                if (TempCostCenter != string.Empty)
                                {
                                    drfinal["CostCenter"] = TempCostCenter.Substring(((TempCostCenter.Length) - 8), 8);
                                }
                                dtfinal.Rows.Add(drfinal);
                            }
                        }
                        if (dtfinal != null && dtfinal.Rows.Count > 0)
                        {
                            StringWriter SWFinal = new StringWriter();
                            dtfinal.WriteXml(SWFinal);
                            string CCXML = SWFinal.ToString();
                            mycommand = new SqlCommand("Usp_UpdateCostCenters_schedules", mycon);
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Parameters.Add(new SqlParameter("@XmlSchedules", SqlDbType.Xml));
                            mycommand.Parameters["@XmlSchedules"].Value = CCXML.ToString();
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            mycommand.Connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnlineTransUpd(int ConFlg)
        {
            try
            {
                SqlConnection ConIILEcom = null;
                SAPService s = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceURL"]);
                if (ConFlg == 1)
                {
                    ConIILEcom = new SqlConnection(ConfigurationSettings.AppSettings["connectionIILEcom"]);
                }
                else if (ConFlg == 2)
                {
                    ConIILEcom = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
                }
                else if (ConFlg == 3)
                {
                    ConIILEcom = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"]);
                }


                SqlCommand mycommand = new SqlCommand();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                mycommand = new SqlCommand("USP_Ecom_InvoiceLRUpdation", ConIILEcom);
                mycommand.Parameters.Add(new SqlParameter("@Flag", "V"));
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds);
                mycommand.Connection.Close();

                DataSet obj = new DataSet();
                DataTable dt1 = new DataTable();

                obj.Tables.Add(ds.Tables[0].Copy());
                obj.Tables.Add(ds.Tables[1].Copy());
                XmlDocument xDoc = XMLSerializerBL.Serialize(obj, XMLSerializerBL.InputType.DataSet);

                s.Timeout = 999999999;
                // XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                XmlElement xDocTable = (XmlElement)s.GetInvoiceandLRDetails(xDoc, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPError[0] == "1000")
                {

                    ds = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            mycommand = new SqlCommand("USP_Ecom_InvoiceLRUpdation", ConIILEcom);
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Parameters.Add(new SqlParameter("@Flag", "S"));
                            if (ds.Tables["Documents"].Rows.Count > 0)
                            {
                                StringWriter sbInvoice = new StringWriter();
                                ds.Tables["Documents"].WriteXml(sbInvoice);
                                mycommand.Parameters.Add("@Invoice", SqlDbType.Xml);
                                mycommand.Parameters["@Invoice"].Value = sbInvoice.ToString();
                            }
                            else
                            {
                                mycommand.Parameters.Add("@Invoice", SqlDbType.Xml);
                                mycommand.Parameters["@Invoice"].Value = null;
                            }

                            if (ds.Tables.Count > 1 && ds.Tables["LRNO"].Rows.Count > 0)
                            {
                                StringWriter sbLR = new StringWriter();
                                ds.Tables["LRNO"].WriteXml(sbLR);
                                mycommand.Parameters.Add("@LRUpdation", SqlDbType.Xml);
                                mycommand.Parameters["@LRUpdation"].Value = sbLR.ToString();
                            }
                            else
                            {
                                mycommand.Parameters.Add("@LRUpdation", SqlDbType.Xml);
                                mycommand.Parameters["@LRUpdation"].Value = null;
                            }
                            if (ds.Tables.Count > 2 && ds.Tables["STOCK"].Rows.Count > 0)
                            {
                                StringWriter sbstock = new StringWriter();
                                ds.Tables["STOCK"].WriteXml(sbstock);
                                mycommand.Parameters.Add("@STOCK", SqlDbType.Xml);
                                mycommand.Parameters["@STOCK"].Value = sbstock.ToString();
                            }
                            else
                            {
                                mycommand.Parameters.Add("@STOCK", SqlDbType.Xml);
                                mycommand.Parameters["@STOCK"].Value = null;
                            }

                            if (ds.Tables.Count > 3 && ds.Tables["Delivery"].Rows.Count > 0)
                            {
                                StringWriter sbdelivery = new StringWriter();
                                ds.Tables["Delivery"].WriteXml(sbdelivery);
                                mycommand.Parameters.Add("@Delivery", SqlDbType.Xml);
                                mycommand.Parameters["@Delivery"].Value = sbdelivery.ToString();
                            }
                            else
                            {
                                mycommand.Parameters.Add("@Delivery", SqlDbType.Xml);
                                mycommand.Parameters["@Delivery"].Value = null;
                            }

                            if (ds.Tables.Count > 4 && ds.Tables["Invoice"].Rows.Count > 0)
                            {
                                ds.Tables["Invoice"].Columns.Remove("matdesc");
                                StringWriter sbinvoicedet = new StringWriter();
                                ds.Tables["Invoice"].WriteXml(sbinvoicedet);
                                mycommand.Parameters.Add("@Invdetails", SqlDbType.Xml);
                                mycommand.Parameters["@Invdetails"].Value = sbinvoicedet.ToString();
                            }
                            else
                            {
                                mycommand.Parameters.Add("@Invdetails", SqlDbType.Xml);
                                mycommand.Parameters["@Invdetails"].Value = null;
                            }


                            if (ds.Tables.Count > 5 && ds.Tables["Salesorder"].Rows.Count > 0)
                            {
                                ds.Tables["Salesorder"].Columns.Remove("matdesc");
                                StringWriter sbsorddet = new StringWriter();
                                ds.Tables["Salesorder"].WriteXml(sbsorddet);
                                mycommand.Parameters.Add("@SOrderdetails", SqlDbType.Xml);
                                mycommand.Parameters["@SOrderdetails"].Value = sbsorddet.ToString();
                            }
                            else
                            {
                                mycommand.Parameters.Add("@SOrderdetails", SqlDbType.Xml);
                                mycommand.Parameters["@SOrderdetails"].Value = null;
                            }
                            mycommand.Connection.Open();
                            mycommand.CommandTimeout = 8000;
                            mycommand.ExecuteNonQuery();
                        }
                    }
                }

                Sendimpropertransactionalert(ConFlg);//every 30 min
                sendmailonfailedtransaction(ConFlg);

                if (
                        (ConFlg == 1 && DateTime.Now.Hour == 16 && DateTime.Now.Minute <= 30) //16:00 to 16:30 -- AH ECom
                    ||
                        (ConFlg == 2 && DateTime.Now.Hour == 11 && DateTime.Now.Minute >= 30) //11:31 to 11:59 -- AS
                    ||
                        (ConFlg == 3 && DateTime.Now.Hour == 12 && DateTime.Now.Minute <= 30) //12:00 to 13:30 -- AC
                   )
                {
                    WriteLog(0, "OnlineTransUpdSub Executed with Flag " + ConFlg.ToString() + "at Date and Time: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    OnlineTransUpdSub(ConFlg);
                }
            }
            catch (Exception ex)
            {
                //lblMsg.Text += "<b>" + ex.Message + ". Please send screenshot to IT Department</b><br><br>";
                //throw ex;
                WriteLog(1, "Exception :" + ex.Message + " :--: " + ex.InnerException + "---tmr_Elapsed---" + "Falg = " + ConFlg.ToString());
            }
        }

        public void OnlineTransUpdSub(int ConFlg)
        {
            Senddelayedlrtransactionalert(ConFlg); //Once a day (11:00 to 12:00)
            Senddelayeddeliveryupdationalert(ConFlg);//Once a day (11:00 to 12:00)
            sendratedifferencealert(ConFlg);//Once a day (11:00 to 12:00)
        }

        public void sendratedifferencealert(int ConFlg)
        {
            //SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
            SqlConnection mycon = null;
            string MsgSub = null;
            if (ConFlg == 1)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
                MsgSub = "AH E-Commerce: ";
            }
            else if (ConFlg == 2)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionAS"].ToString());
                MsgSub = "HBI AS E-Commerce: ";
            }
            else if (ConFlg == 3)
            {
                mycon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"].ToString());
                MsgSub = "HBI AC E-Commerce: ";
            }
            SqlCommand mysqlcommand = new SqlCommand();
            DataSet dsdata = new DataSet();
            mysqlcommand = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
            mysqlcommand.Parameters.Add(new SqlParameter("@Flag", "R"));
            mysqlcommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mysqlcommand);
            mysqlcommand.Connection.Open();
            myAdapter.Fill(dsdata, "getdata");
            mysqlcommand.Connection.Close();

            if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
            {
                StringBuilder strNBodyText = new StringBuilder();
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsdata.Tables[0].Rows)
                    {
                        strNBodyText.Append(dr["Body"].ToString());
                    }
                }
                MsgSub = MsgSub + "Transactions with Amount Difference";
                SendMailEComm(dsdata.Tables[1].Rows[0]["to"].ToString(), MsgSub, strNBodyText.ToString(), "0", "0", dsdata.Tables[1].Rows[0]["CC"].ToString());
            }
        }

        public void Sendimpropertransactionalert(int ConFlg)
        {
            SqlConnection mycon = null;
            string MsgSub = null;
            if (ConFlg == 1)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
                MsgSub = "AH E-Commerce: Incomplete transactions.";
            }
            else if (ConFlg == 2)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionAS"].ToString());
                MsgSub = "HH AS E-Commerce: Incomplete transactions.";
            }
            else if (ConFlg == 3)
            {
                mycon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"].ToString());
                MsgSub = "HBI AC E-Commerce: Incomplete transactions.";
            }
            SqlCommand mysqlcommand = new SqlCommand();
            DataSet dsdata = new DataSet();
            mysqlcommand = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
            mysqlcommand.Parameters.Add(new SqlParameter("@Flag", "I"));
            mysqlcommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mysqlcommand);
            mysqlcommand.Connection.Open();
            myAdapter.Fill(dsdata, "getdata");
            mysqlcommand.Connection.Close();

            if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
            {
                StringBuilder strNBodyText = new StringBuilder();
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsdata.Tables[0].Rows)
                    {
                        strNBodyText.Append(dr["Body"].ToString());
                    }
                }
                SendMailEComm(dsdata.Tables[1].Rows[0]["to"].ToString(), MsgSub, strNBodyText.ToString(), "0", "0", dsdata.Tables[1].Rows[0]["CC"].ToString());
            }

            try
            {
                //Code written by raveesh for getting Amount mismatch Alert.
                mysqlcommand = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
                mysqlcommand.Parameters.Add(new SqlParameter("@Flag", "T"));
                mysqlcommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myAdapter1 = new SqlDataAdapter(mysqlcommand);
                mysqlcommand.Connection.Open();
                myAdapter1.Fill(dsdata, "getdata");
                mysqlcommand.Connection.Close();

                if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
                {
                    if (dsdata.Tables[1].Rows.Count > 0)
                    {
                        SendMailEComm(dsdata.Tables[1].Rows[0]["to"].ToString(), dsdata.Tables[1].Rows[0]["Subject"].ToString(), dsdata.Tables[1].Rows[0]["Body"].ToString(), "0", "0", dsdata.Tables[1].Rows[0]["CC"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, ex.Message + " -- E Commerce Amount Mismatch -- ");
            }
        }

        public void Senddelayedlrtransactionalert(int ConFlg)
        {
            //SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
            SqlConnection mycon = null;
            string MsgSub = null;
            if (ConFlg == 1)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
                MsgSub = "AH E-Commerce: ";
            }
            else if (ConFlg == 2)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionAS"].ToString());
                MsgSub = "HH AS E-Commerce: ";
            }
            else if (ConFlg == 3)
            {
                mycon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"].ToString());
                MsgSub = "HBI AC E-Commerce: ";
            }
            MsgSub = MsgSub + "Incomplete LR Update transactions.";

            SqlCommand mysqlcommand = new SqlCommand();
            DataSet dsdata = new DataSet();
            mysqlcommand = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
            mysqlcommand.Parameters.Add(new SqlParameter("@Flag", "CF"));
            mysqlcommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mysqlcommand);
            mysqlcommand.Connection.Open();
            myAdapter.Fill(dsdata, "getdata");
            mysqlcommand.Connection.Close();

            if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsdata.Tables[0].Rows.Count; i++)
                {
                    SqlCommand mysqlcommand1 = new SqlCommand();
                    DataSet dsdata1 = new DataSet();
                    mysqlcommand1 = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
                    mysqlcommand1.Parameters.Add(new SqlParameter("@Flag", "L"));
                    mysqlcommand1.Parameters.Add(new SqlParameter("@CFLoc", dsdata.Tables[0].Rows[i]["PlantCode"].ToString().Trim()));
                    mysqlcommand1.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter1 = new SqlDataAdapter(mysqlcommand1);
                    mysqlcommand1.Connection.Open();
                    myAdapter1.Fill(dsdata1, "getdatacf");
                    mysqlcommand1.Connection.Close();

                    StringBuilder strNBodyText = new StringBuilder();
                    if (dsdata1 != null && dsdata1.Tables.Count > 0 && dsdata1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsdata1.Tables[0].Rows)
                        {
                            strNBodyText.Append(dr["Body"].ToString());
                        }

                        SendMailEComm(dsdata1.Tables[1].Rows[0]["to"].ToString(), MsgSub, strNBodyText.ToString(), "0", "0", dsdata1.Tables[1].Rows[0]["CC"].ToString());
                    }
                }
            }
        }

        public void Senddelayeddeliveryupdationalert(int ConFlg)
        {
            //SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
            SqlConnection mycon = null;
            string MsgSub = null;
            if (ConFlg == 1)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
                MsgSub = "AH E-Commerce: ";
            }
            else if (ConFlg == 2)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionAS"].ToString());
                MsgSub = "HH AS E-Commerce: ";
            }
            else if (ConFlg == 3)
            {
                mycon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"].ToString());
                MsgSub = "HBI AC E-Commerce: ";
            }
            MsgSub = MsgSub + "Incomplete delivery Update transactions.";
            SqlCommand mysqlcommand = new SqlCommand();
            DataSet dsdata = new DataSet();
            mysqlcommand = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
            mysqlcommand.Parameters.Add(new SqlParameter("@Flag", "CF"));
            mysqlcommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mysqlcommand);
            mysqlcommand.Connection.Open();
            myAdapter.Fill(dsdata, "getdata");
            mysqlcommand.Connection.Close();

            if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsdata.Tables[0].Rows.Count; i++)
                {
                    SqlCommand mysqlcommand1 = new SqlCommand();
                    DataSet dsdata1 = new DataSet();
                    mysqlcommand1 = new SqlCommand("Usp_impropertransaction_maildetails", mycon);
                    mysqlcommand1.Parameters.Add(new SqlParameter("@Flag", "D"));
                    mysqlcommand1.Parameters.Add(new SqlParameter("@CFLoc", dsdata.Tables[0].Rows[i]["PlantCode"].ToString().Trim()));
                    mysqlcommand1.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter1 = new SqlDataAdapter(mysqlcommand1);
                    mysqlcommand1.Connection.Open();
                    myAdapter1.Fill(dsdata1, "getdatacf");
                    mysqlcommand1.Connection.Close();

                    StringBuilder strNBodyText = new StringBuilder();
                    if (dsdata1 != null && dsdata1.Tables.Count > 0 && dsdata1.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsdata1.Tables[0].Rows)
                        {
                            strNBodyText.Append(dr["Body"].ToString());
                        }

                        SendMailEComm(dsdata1.Tables[1].Rows[0]["to"].ToString(), MsgSub, strNBodyText.ToString(), "0", "0", dsdata1.Tables[1].Rows[0]["CC"].ToString());
                    }
                }
            }
        }

        public void sendmailonfailedtransaction(int ConFlg)
        {
            //SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
            SqlConnection mycon = null;
            string MsgSub = null;
            if (ConFlg == 1)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionIILEcom"].ToString());
                MsgSub = "AH E-Commerce: ";
            }
            else if (ConFlg == 2)
            {
                mycon = new SqlConnection(ConfigurationManager.AppSettings["connectionAS"].ToString());
                MsgSub = "HH AS E-Commerce: ";
            }
            else if (ConFlg == 3)
            {
                mycon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"].ToString());
                MsgSub = "HBI AC E-Commerce: ";
            }

            SqlCommand mysqlcommand = new SqlCommand();
            DataSet dsdata = new DataSet();
            DataSet dsdata1 = new DataSet();
            mysqlcommand = new SqlCommand("USP_FailedTransactions", mycon);
            mysqlcommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mysqlcommand);
            mysqlcommand.Connection.Open();
            myAdapter.Fill(dsdata, "getdata");
            mysqlcommand.Connection.Close();

            if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsdata.Tables[0].Rows.Count; i++) //dsdata.Tables[0].Rows.Count
                {
                    mysqlcommand = new SqlCommand("Usp_Customer_FailedMailDetails", mycon);
                    mysqlcommand.Parameters.Add(new SqlParameter("@UserId", dsdata.Tables[0].Rows[i]["UserId"].ToString()));
                    mysqlcommand.Parameters.Add(new SqlParameter("@OrderId", dsdata.Tables[0].Rows[i]["orderhedid"].ToString()));
                    mysqlcommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter1 = new SqlDataAdapter(mysqlcommand);
                    mysqlcommand.Connection.Open();
                    myAdapter1.Fill(dsdata1, "getdata1");
                    mysqlcommand.Connection.Close();
                    if (dsdata1 != null && dsdata1.Tables.Count > 0 && dsdata1.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder strNBodyText = new StringBuilder();
                        foreach (DataRow dr in dsdata1.Tables[0].Rows)
                        {
                            strNBodyText.Append(dr["Body"].ToString());
                        }
                        MsgSub = MsgSub + dsdata.Tables[0].Rows[i]["Subject"].ToString();
                        SendMailEComm(dsdata.Tables[0].Rows[i]["Emailid"].ToString(), MsgSub, strNBodyText.ToString(), "0", "0", "0");
                        //new clsCommon().SendMail(new MailBE(dsdata.Tables[0].Rows[i]["Emailid"].ToString(), dsdata.Tables[0].Rows[i]["Subject"].ToString(), strNBodyText.ToString(), true, "", "", "", ""));
                        strNBodyText.Remove(0, strNBodyText.Length);
                        dsdata1.Clear();
                    }
                }
            }
        }

        private void SendPromoSMS()
        {
            try
            {
                System.Data.DataRow objHdrdr = default(System.Data.DataRow);
                System.Data.DataTable objDT = default(System.Data.DataTable);
                int i;
                DataSet dsAppSMS = new DataSet();
                DataTable dtAppSMS = new DataTable();
                DataTable dtInv = new DataTable();
                DataSet dsInv = new DataSet();
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                mycommand = new SqlCommand("USP_GetDatesRequiredforSMS_T", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myadapterGlobal = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myadapterGlobal.Fill(dsAppSMS, "Getdates");

                mycommand = new SqlCommand("USP_Promo_InvDetails", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Flag", "V"));
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myadapterGlobal1 = new SqlDataAdapter(mycommand);

                myadapterGlobal1.Fill(dsInv, "GetInvDet");

                mycommand.Connection.Close();
                i = 0;
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);

                List<string> input = new List<string>();
                input.Add(dsAppSMS.Tables[0].Rows[0]["Today"].ToString());
                //input.Add("20131218");
                //input.Add("20131218");

                XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                XmlElement xDocTable = (XmlElement)s.GetPromoInvoiceDetails(xDoc, out xmlException);

                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                if (SAPError[0] == "1000")
                {

                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);

                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    DataTable dt1 = new DataTable();
                    if (dt.Rows.Count > 0)
                    {
                        if (dsInv.Tables[0].Rows.Count > 0)
                        {
                            dtInv = dsInv.Tables[0];
                            DataView di = new DataView(dt);
                            di.RowFilter = "LRNo not in ( '" + dsInv.Tables[0].Rows[0]["lrno"].ToString() + "')";
                            dt = di.ToTable();
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dt3.Columns.Add("LRNO", typeof(string));
                            dt3.Columns.Add("LRDate", typeof(string));
                            dt3.Columns.Add("TransporterName", typeof(string));
                            dt3.Columns.Add("Telephone", typeof(string));
                            dt3.Columns.Add("Customer", typeof(string));
                            dt1 = dt.Copy();
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            DataView dv = new DataView(dt1);
                            dt1 = dv.ToTable(true, "LRNo", "Customer");
                            DataView dv1 = new DataView(dt2);
                            if (dv.ToTable().Rows.Count > 0)
                            {
                                foreach (DataRow drow in dt1.Rows)
                                {
                                    StringBuilder sbMailId = new StringBuilder();
                                    StringBuilder sbMail = new StringBuilder();
                                    i = 0;

                                    dt2 = dt.Copy();
                                    dv1.RowFilter = "LRNo ='" + drow["LRNo"].ToString() + "'";
                                    dv1.RowFilter = "Customer= '" + drow["Customer"].ToString() + "'";
                                    dt2 = dv1.ToTable();
                                    if (dt2.Rows.Count > 0)
                                    {
                                        string str = "ksravani@indimmune.com";
                                        sbMailId.Append("<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' >");
                                        //sbMailId.Append("<tr bgcolor='#00BFFF'><td>Invoice No</td><td>LR No </td><td>LR Date</td><td>Transporter Name</td></tr>");
                                        sbMailId.Append("<tr bgcolor='#00BFFF'><td nowrap='nowrap'>LR No </td><td nowrap='nowrap'>LR Date</td><td nowrap='nowrap'>Transporter Name</td></tr>");
                                        //sbMailId.Append("<tr><td nowrap='nowrap'>" + Convert.ToString(dt2.Rows[0]["InvoiceNO"]) + "</td>");
                                        sbMailId.Append("<tr><td  nowrap='nowrap'>" + Convert.ToString(dt2.Rows[0]["LRNo"].ToString().Trim()) + "</td>");
                                        sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(dt2.Rows[0]["LRDate"].ToString().Trim()) + "</td>");
                                        sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(dt2.Rows[0]["TransporterName"].ToString().Trim()) + "</td></tr>");
                                        //sbMailId.Append("<tr><td nowrap='nowrap' >DCNO </td><td nowrap='nowrap' >" + Convert.ToString(dt2.Rows[0]["Dcno"]) + "</td></tr>");  
                                        sbMailId.Append("</table> ");
                                        sbMailId.Append("<br />");
                                        if (dt2.Rows[0]["LRNo"].ToString() != "")
                                        {
                                            objHdrdr = dt3.NewRow();
                                            objHdrdr["LRNO"] = dt2.Rows[0]["LRNo"].ToString();
                                            objHdrdr["LRDate"] = dt2.Rows[0]["LRDate"].ToString(); ;
                                            objHdrdr["TransporterName"] = dt2.Rows[0]["TransporterName"].ToString();
                                            objHdrdr["Telephone"] = dt2.Rows[0]["TelephoneNO"].ToString();
                                            objHdrdr["Customer"] = dt2.Rows[0]["Customer"].ToString();
                                            dt3.Rows.Add(objHdrdr);

                                            mycommand = new SqlCommand("USP_Promo_InvDetails", mycon);

                                            mycommand.Parameters.Add(new SqlParameter("@Flag", "I"));
                                            mycommand.Parameters.Add(new SqlParameter("@Lrno", dt2.Rows[0]["LRNo"].ToString()));
                                            mycommand.CommandType = CommandType.StoredProcedure;
                                            SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                                            mycommand.Connection.Open();
                                            mycommand.ExecuteNonQuery();
                                            mycommand.Connection.Close();

                                        }
                                        if (dt3.Rows.Count > 0)
                                        {
                                            objHdrdr = null;
                                            objDT = null;
                                            objDT = new DataTable("SMSDetails");
                                            objDT.Columns.Add("EmpId", typeof(string));
                                            objDT.Columns.Add("Message", typeof(string));
                                            objDT.Columns.Add("Tono", typeof(string));
                                            objDT.Columns.Add("DateofMsg", typeof(string));
                                            foreach (DataRow dp in dt3.Rows)
                                            {
                                                objHdrdr = objDT.NewRow();
                                                objHdrdr["EmpId"] = dp["Customer"].ToString().Substring(4, 6);
                                                objHdrdr["Message"] = "Promo/Physician Samples dispatched to your address  vide LR No:" + dp["LRNO"] + ";Dt:" + dp["LRDate"] + ";Transporter:" + dp["TransporterName"];

                                                objHdrdr["Tono"] = dp["Telephone"];
                                                objHdrdr["DateofMsg"] = DateTime.Now;
                                                objDT.Rows.Add(objHdrdr);
                                            }
                                            StringWriter SWSMS = new StringWriter();
                                            objDT.WriteXml(SWSMS);
                                            mycommand = new SqlCommand("USP_GETSMStobeSent_T", mycon);
                                            mycommand.Parameters.Add("@SMSDetailsTable", SqlDbType.Xml);
                                            mycommand.Parameters["@SMSDetailsTable"].Value = SWSMS.ToString();
                                            mycommand.Parameters.Add(new SqlParameter("@Flag", "I"));
                                            mycommand.Parameters.Add(new SqlParameter("@CreatedBy", "ADMIN"));
                                            mycommand.Parameters.Add(new SqlParameter("@SMSApptypeId", 7));
                                            mycommand.CommandType = CommandType.StoredProcedure;
                                            SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                                            mycommand.Connection.Open();
                                            mycommand.ExecuteNonQuery();
                                            mycommand.Connection.Close();
                                        }

                                        dt2 = dv1.ToTable(true, "InvoiceNO", "customer");
                                        DataTable dt4 = new DataTable();
                                        foreach (DataRow dr in dt2.Rows)
                                        {
                                            dt4 = dt.Copy();
                                            dv1.RowFilter = "InvoiceNO= '" + dr["InvoiceNO"].ToString() + "'";

                                            dt4 = dv1.ToTable();
                                            //sbMailId.Append("Promotional Order Header Details <br>");
                                            //string str = Convert.ToString(dt2.Rows[0]["Customer"]).Substring(4, 6) + "@indimmune.com";
                                            //sbMailId.Append("<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='100%'><tr><th  valign='bottom' align='centre'><font color='#000000' colspan ='4' face='Arial'><b>Promotional Items</b></font></th></tr>");
                                            sbMailId.Append("<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' >");
                                            if (dt4.Rows[0]["DocType"].ToString() == "ZF10")
                                            {
                                                sbMailId.Append("<tr><td > Phy.Sample</td><td nowrap='nowrap' align = 'right' >DC No :</td><td nowrap='nowrap'colspan = '2'>" + Convert.ToString(dt4.Rows[0]["Dcno"]) + "</td></tr>");
                                                sbMailId.Append("<tr bgcolor='#00BFFF'><td align ='center'>SNo</td><td  nowrap='nowrap'>Material Desc</td><td  width='5' nowrap='nowrap'>Quantity</td><td  nowrap='nowrap'>Batch</td></tr>");
                                            }
                                            else if (dt4.Rows[0]["DocType"].ToString() == "ZF9")
                                            {
                                                sbMailId.Append("<tr><td> Promo Items</td><td nowrap='nowrap'align = 'right' > DC No : </td><td nowrap='nowrap'>" + Convert.ToString(dt4.Rows[0]["Dcno"]) + "</td></tr>");
                                                sbMailId.Append("<tr bgcolor='#00BFFF'><td align ='center'>SNo</td><td  nowrap='nowrap'>Material Desc</td><td width='5' nowrap='nowrap'>Quantity</td></tr>");
                                            }
                                            //sbMailId.Append("<tr bgcolor='#00BFFF'><td>Sno</td><td>Material</td><td>Material Desc</td><td>Quantity</td></tr>");

                                            if (dt4.Rows[0]["DocType"].ToString() == "ZF10")
                                            {
                                                i = 0;
                                                foreach (DataRow drinstr in dt4.Rows)
                                                {
                                                    i = i + 1;
                                                    sbMailId.Append("<tr><td align ='center' nowrap='nowrap'>" + i + "</td>");
                                                    //sbMailId.Append("<td nowrap='nowrap'>" + Convert.ToString(drinstr["Material"]) + "</td>");
                                                    sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(drinstr["MaterialDesc"].ToString().Trim()) + "</td>");
                                                    sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(drinstr["Quantity"].ToString().Trim()) + "</td>");
                                                    sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(drinstr["Batch"].ToString().Trim()) + "</td></tr>");
                                                }
                                            }
                                            else if (dt4.Rows[0]["DocType"].ToString() == "ZF9")
                                            {
                                                i = 0;
                                                foreach (DataRow drinstr in dt4.Rows)
                                                {
                                                    i = i + 1;
                                                    sbMailId.Append("<tr><td align ='center' nowrap='nowrap'>" + i + "</td>");
                                                    //sbMailId.Append("<td nowrap='nowrap'>" + Convert.ToString(drinstr["Material"]) + "</td>");
                                                    sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(drinstr["MaterialDesc"].ToString().Trim()) + "</td>");
                                                    sbMailId.Append("<td  nowrap='nowrap'>" + Convert.ToString(drinstr["Quantity"].ToString().Trim()) + "</td></tr>");
                                                }
                                            }
                                            sbMailId.Append("</table> ");
                                        }
                                        SendMail(str, "Promo items/Phy Samples dispatched", "Dear    " + Convert.ToString(dt4.Rows[0]["CustomerName"]) + ", <br><br>As per below details, Promo items/Physician samples have been dispatched to your address<br><br>" + Convert.ToString(sbMailId) + "<br><br>This email was generated automatically. Please do NOT reply .<br> <br> Best Regards, <br> Promo/Phy Samples Hub<br>CDC, Hyderabad", "0", "0", "0");
                                        dt4.Clear();
                                        dt3.Clear();
                                        dt2.Clear();
                                    }
                                }
                                dt1.Clear();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Promo---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }


        }

        private void getPPDBData()
        {
            try
            {
                DataSet dsppdb = new DataSet();
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                mycommand = new SqlCommand("USP_PPDB_Data", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Flag", 1));
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myadapterGlobal = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myadapterGlobal.Fill(dsppdb, "getyear");
                mycommand.Connection.Close();

                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                s.Timeout = 99999999;
                List<string> input = new List<string>();


                input.Add(dsppdb.Tables[0].Rows[0]["fromyear"].ToString()); //Pass startdate of the month
                input.Add(dsppdb.Tables[0].Rows[0]["toyear"].ToString());         //Pass today's date             

                //Call RFC For Sales Details
                XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                XmlElement xDocTable = (XmlElement)s.GetPPDBdata(xDoc, out xmlException);

                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                //if call is success
                if (SAPError[0] == "1000")
                {
                    DataSet ds1 = new DataSet();
                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);

                    //if sales details exists
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                            dr1["prdesc"] = r.Replace(dr1["prdesc"].ToString(), String.Empty);
                            dt.AcceptChanges();
                        }

                        dt.TableName = "PPDB";
                        StringWriter SWSMS = new StringWriter();
                        dt.WriteXml(SWSMS);
                        mycommand = new SqlCommand("USP_PPDB_Data", mycon);
                        mycommand.Parameters.Add("@PPDBData", SqlDbType.Xml);
                        mycommand.Parameters["@PPDBData"].Value = SWSMS.ToString();
                        mycommand.Parameters.Add(new SqlParameter("@Flag", 2));
                        mycommand.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                        mycommand.Connection.Close();
                    }
                }
                else
                {
                    WriteLog(1, "Exception :---PROD DASHBOARD---" + SAPError[1] + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }

            }
            catch (Exception ex)
            {
                //WriteLog(1, "Exception :" + ex.Message + "Sending Sales SMS" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }


        private void LegalCompRemMail()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsLegalMail = new DataSet();
            try
            {
                int flg = 0;
                mycommand = new SqlCommand("Usp_LegalComp_RemMail", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dsLegalMail, "Reminder Mail");
                mycommand.Connection.Close();
                if (dsLegalMail.Tables.Count > 0)
                {
                    if (dsLegalMail.Tables[0].Rows.Count > 0)
                    {
                        //DataView dv = new DataView(dsLegalMail.Tables[0]);
                        //dsmonthlytemp.Tables.Add(ds.Tables[3].Copy());
                        int i = 0;
                        foreach (DataRow drinstr in dsLegalMail.Tables[0].Rows)
                        {

                            flg = 0;
                            StringBuilder sbDet = new StringBuilder();
                            StringBuilder sbDue = new StringBuilder();
                            StringBuilder sbMailId = new StringBuilder();
                            if (dsLegalMail.Tables[1].Rows.Count > 0)
                            {
                                DataView dv1 = new DataView(dsLegalMail.Tables[1]);
                                dv1.RowFilter = "createdby='" + drinstr["empid"].ToString() + "'";
                                if (dv1.ToTable().Rows.Count > 0)
                                {

                                    flg = 1;
                                    sbDet.Append("<br><br>The following Compliances are falling due in the next 7 days, which were reported as Partially / Non Compliance in previous month(s).<br>");
                                    sbDet.Append("Employee: " + Convert.ToString(dsLegalMail.Tables[3].Rows[i]["employee"]).Trim() + "<br>");
                                    i++;
                                    sbDet.Append("<table border = '1' bgcolor = '#EFF3FB' align = 'left'>");
                                    sbDet.Append("<tr bgcolor='#EFF3F3'><th align='Left'>Department</th><th align='Left'>Month</th><th align='Left'>Act</th><th align='Left'>Guiding Section</th><th align='Left'>Activity</th><th align='Left'>Form No</th><th align='Left'>Periodicity</th><th align='Left'>Submitted Date</th><th align='Left'>Compliance Status</th><th align='Left'>Due Date</th></tr>");
                                    foreach (DataRow drfinal in dv1.ToTable().Rows)
                                    {
                                        sbDet.Append("<tr>");
                                        //sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["employee"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Department"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Monthyr"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Act"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Activity"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["GuidingSection"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["FormNo"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Frequency"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Submitteddate"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["ComplianceStatus"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Duedate"]).Trim() + "</td>");
                                        sbDet.Append("</tr>");
                                    }
                                    sbDet.Append("</table>");
                                }
                            }
                            if (dsLegalMail.Tables.Count == 3)
                            {
                                if (dsLegalMail.Tables[2].Rows.Count > 0)
                                {
                                    DataView dv1 = new DataView(dsLegalMail.Tables[2]);
                                    dv1.RowFilter = "empid='" + drinstr["empid"].ToString() + "'";
                                    if (dv1.ToTable().Rows.Count > 0)
                                    {
                                        flg = 1;

                                        foreach (DataRow drfinal in dv1.ToTable().Rows)
                                        {
                                            sbDue.Append("<br><br>The following Legal Compliances are to be submitted with the Target compliance date<br><table border = '1' bgcolor='#EFF3FB'>");
                                            sbDue.Append("<tr bgcolor='#507CD1'><td>Employee</td><td>Department</td><td>Month</td><td>Act</td><td>Guiding Section</td><td>Activity</td><td>Form No</td><td>Periodicity</td><td>Tentative Duedate</td><td>Target Compliance Date</td></tr>");
                                            sbDue.Append("<tr>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["firstname"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Department"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Monthyr"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Act"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Activity"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["GuidingSection"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["FormNo"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Frequency"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["tentativeduefromdate"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["cutoffdate"]) + "</td>");
                                            sbDue.Append("</tr>");
                                        }
                                        sbDue.Append("</table>");
                                    }
                                }
                            }

                            if (flg == 1)
                            {
                                //sbMailId.Append(Convert.ToString(dsLegalMail.Tables[0].Rows[0]["empid"].ToString()) + ";");
                                //sbMailId.Append(Convert.ToString(dsLegalMail.Tables[0].Rows[0]["empid"].ToString()));
                                sbMailId.Append(Convert.ToString(dsLegalMail.Tables[0].Rows[0]["Legalemail"].ToString()));
                                SendMail(sbMailId.ToString(), "Gentle Reminder For Legal Compliance Reporting", "Dear Sir/Madam, " + Convert.ToString(sbDet) + Convert.ToString(sbDue), "0", "0", C_Emailid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Legal Compliance---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void LegalCompRemMail1()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsLegalMail = new DataSet();
            try
            {
                int flg = 0;
                mycommand = new SqlCommand("Usp_LegalComp_RemMail", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dsLegalMail, "Reminder Mail");
                mycommand.Connection.Close();
                if (dsLegalMail.Tables.Count > 0)
                {
                    if (dsLegalMail.Tables[0].Rows.Count > 0)
                    {

                        //DataView dv = new DataView(dsLegalMail.Tables[0]);
                        //dsmonthlytemp.Tables.Add(ds.Tables[3].Copy());
                        foreach (DataRow drinstr in dsLegalMail.Tables[0].Rows)
                        {
                            flg = 0;
                            StringBuilder sbDet = new StringBuilder();
                            StringBuilder sbDue = new StringBuilder();
                            StringBuilder sbMailId = new StringBuilder();
                            if (dsLegalMail.Tables[1].Rows.Count > 0)
                            {
                                DataView dv1 = new DataView(dsLegalMail.Tables[1]);
                                dv1.RowFilter = "createdby='" + drinstr["empid"].ToString() + "'";
                                if (dv1.ToTable().Rows.Count > 0)
                                {
                                    flg = 1;
                                    sbDet.Append("<br><br>The following Compliances are falling due in the next 7 days, which were reported as Non/Partially Compliance in previous month.<br><table>");
                                    sbDet.Append("<tr><td>Employee</td><td>Department</td><td>Month</td><td>Act</td><td>Guiding Section</td><td>Activity</td><td>Form No</td><td>Periodicity</td><td>Submitted Date</td><td>Compliance Status</td><td>Due Date</td></tr>");
                                    foreach (DataRow drfinal in dv1.ToTable().Rows)
                                    {
                                        sbDet.Append("<tr>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["employee"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Department"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Monthyr"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Act"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["GuidingSection"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Activity"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["FormNo"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Frequency"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Submitteddate"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["ComplianceStatus"]).Trim() + "</td>");
                                        sbDet.Append("<td align='Left'>" + Convert.ToString(drfinal["Duedate"]).Trim() + "</td>");
                                        sbDet.Append("</tr>");
                                    }
                                    sbDet.Append("</table>");
                                }
                            }
                            if (dsLegalMail.Tables.Count == 3)
                            {
                                if (dsLegalMail.Tables[2].Rows.Count > 0)
                                {
                                    DataView dv1 = new DataView(dsLegalMail.Tables[2]);
                                    dv1.RowFilter = "empid='" + drinstr["empid"].ToString() + "'";
                                    if (dv1.ToTable().Rows.Count > 0)
                                    {
                                        flg = 1;
                                        sbDue.Append("<br><br>The following Legal Compliances are to be submitted with the Target compliance date<br><table border = '1' bgcolor='#EFF3FB'>");
                                        sbDue.Append("<tr bgcolor='#507CD1'><td>Employee</td><td>Department</td><td>Month</td><td>Act</td><td>Guiding Section</td><td>Activity</td><td>Form No</td><td>Periodicity</td><td>Tentative Duedate</td><td>Target Compliance Date</td></tr>");
                                        foreach (DataRow drfinal in dv1.ToTable().Rows)
                                        {
                                            sbDue.Append("<tr>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["firstname"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Department"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Monthyr"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Act"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["GuidingSection"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Activity"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["FormNo"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["Frequency"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["tentativeduefromdate"]) + "</td>");
                                            sbDue.Append("<td>" + Convert.ToString(drfinal["cutoffdate"]) + "</td>");
                                            sbDue.Append("</tr>");
                                        }
                                        sbDue.Append("</table>");
                                    }
                                }
                            }

                            if (flg == 1)
                            {
                                sbMailId.Append(Convert.ToString(dsLegalMail.Tables[0].Rows[0]["email"].ToString()) + ";");
                                sbMailId.Append(Convert.ToString(dsLegalMail.Tables[0].Rows[0]["Legalemail"].ToString()));
                                SendMail(sbMailId.ToString(), "Gentle Reminder For Legal Compliance Reporting", "Dear Sir/Madam, " + Convert.ToString(sbDet) + Convert.ToString(sbDue), "0", "0", C_Emailid);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Legal Compliance---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void ASUpdateCustomer()
        {
            SqlConnection myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            SAPService ASCon = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceAS"]);
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            SqlCommand mycommand1 = new SqlCommand();
            List<string> ASinput = new List<string>();
            ASinput.Add("20080701");
            ASinput.Add("103");
            XmlDocument ASxDoc = XMLSerializerBL.Serialize(ASinput, XMLSerializerBL.InputType.List);
            XmlNode ASxmlException = null;
            XmlElement ASxDocTable = (XmlElement)ASCon.getASUserCreation(ASxDoc, out ASxmlException);
            List<string> ASSAPError = (List<string>)XMLSerializerBL.Deserialize(ASxmlException.OuterXml, XMLSerializerBL.OutputType.List);

            if (ASSAPError[0] == "1000")
            {
                DataTable dtAS = (DataTable)XMLSerializerBL.Deserialize(ASxDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
                if (dtAS.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow drAS in dtAS.Rows)
                    {
                        try
                        {
                            mycommand = new SqlCommand("Usp_AS_UserCreation_Transactions", myAScon);
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Parameters.Add(new SqlParameter("@LocId", Convert.ToString(drAS["CustomerNo"])));
                            mycommand.Parameters.Add(new SqlParameter("@LocDesc", Convert.ToString(drAS["LocDesc"].ToString().Trim())));
                            mycommand.Parameters.Add(new SqlParameter("@Address1", Convert.ToString(drAS["Address2"].ToString().Trim()) + ", " + Convert.ToString(drAS["Address3"].ToString().Trim())));
                            mycommand.Parameters.Add(new SqlParameter("@Address2", Convert.ToString(Convert.ToString(drAS["Address1"]))));
                            mycommand.Parameters.Add(new SqlParameter("@PinCode", Convert.ToString(drAS["PostalCode"])));
                            mycommand.Parameters.Add(new SqlParameter("@LandLine", Convert.ToString(drAS["TelePhone1"])));
                            mycommand.Parameters.Add(new SqlParameter("@Mobile", Convert.ToString(drAS["TelePhone2"])));
                            mycommand.Parameters.Add(new SqlParameter("@Fax", Convert.ToString(drAS["FaxNo"])));
                            mycommand.Parameters.Add(new SqlParameter("@ContactPerson", Convert.ToString(drAS["Name"])));
                            mycommand.Parameters.Add(new SqlParameter("@Sales_tax_no", Convert.ToString(drAS["LocalSalesTaxNo"])));
                            mycommand.Parameters.Add(new SqlParameter("@Central_tax_no", Convert.ToString(drAS["CntrlSalesTaxNo"])));
                            mycommand.Parameters.Add(new SqlParameter("@Drug_L_No1", Convert.ToString(drAS["DrugLic1"])));
                            mycommand.Parameters.Add(new SqlParameter("@Drug_L_No2", Convert.ToString(drAS["DrugLic2"])));
                            mycommand.Parameters.Add(new SqlParameter("@VatApplicable", "1"));
                            mycommand.Parameters.Add(new SqlParameter("@CandFLocation", Convert.ToString(drAS["SalesOffice"])));
                            mycommand.Parameters.Add(new SqlParameter("@Password", "mCgsDNkgtH7FlxI8KwsBK1h1QJp3XstffWtLkI78WtY="));//pass@123
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            i++;
                            //Response.Write(i.ToString() + "; ");
                        }
                        catch (Exception ex)
                        {
                            WriteLog(1, "Exception :" + ex.Message + " :--: " + ex.InnerException + "---ASUpdateCustomer---");
                        }
                        finally
                        {
                            mycommand.Connection.Close();
                        }
                    }
                    if (i > 0)
                    {
                        WriteLog(1, "<br>AS Code executed in 120.138.9.18. " + i.ToString() + " Customers inserted.-----" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    }
                    if (dtAS.Rows.Count > 0)
                    {
                        dtAS.TableName = "ASData";
                        StringWriter sbEmpId = new StringWriter();
                        dtAS.WriteXml(sbEmpId);
                        mycommand1 = new SqlCommand("USP_F_AS_PositinCodes", mycon);
                        mycommand1.CommandType = CommandType.StoredProcedure;
                        mycommand1.CommandTimeout = 100000;
                        mycommand1.Parameters.Add("@ASId", SqlDbType.Xml);
                        mycommand1.Parameters["@ASId"].Value = sbEmpId.ToString();
                        mycommand1.Connection.Open();
                        mycommand1.ExecuteNonQuery();
                        mycommand1.Connection.Close();
                        WriteLog(1, "AS Position Codes inserted in 192.168.2.1");
                    }
                }
            }
        }

        public void UpdateEmpsfromNewIILhometoAS(int ConFlg)
        {
            SqlConnection myAScon;
            if (ConFlg == 2)
            {
                myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            }
            else if (ConFlg == 3)
            {
                myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"]);
            }
            else
            {
                myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            }

            //SqlConnection myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            //SAPService ASCon = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceAS"]);
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            SqlCommand mycommand1 = new SqlCommand();
            DataSet dsdata = new DataSet();
            DataSet dsdata1 = new DataSet();
            mycommand1 = new SqlCommand("USP_GetEMPDatafromNewIILHOME", mycon);
            mycommand1.CommandType = CommandType.StoredProcedure;
            mycommand1.CommandTimeout = 100000;
            SqlDataAdapter myAdapter1 = new SqlDataAdapter(mycommand1);
            mycommand1.Connection.Open();
            myAdapter1.Fill(dsdata, "getdata");
            mycommand1.Connection.Close();
            StringWriter sbEmpId = new StringWriter();
            StringWriter sbLvl = new StringWriter();
            StringWriter sbPos = new StringWriter();
            dsdata.DataSetName = "NewDataSet";
            if ((dsdata != null) && (dsdata.Tables[0].Rows.Count > 0))
            {
                DataTable dtAS = dsdata.Tables[0];
                dtAS.TableName = "EMPData";
                dtAS.WriteXml(sbEmpId);
            }
            if ((dsdata != null) && (dsdata.Tables[1].Rows.Count > 0))
            {
                DataTable dtAS = dsdata.Tables[1];
                dtAS.TableName = "LvlData";
                dtAS.WriteXml(sbLvl);
            }
            if ((dsdata != null) && (dsdata.Tables[2].Rows.Count > 0))
            {
                DataTable dtAS = dsdata.Tables[2];
                dtAS.TableName = "PosData";
                dtAS.WriteXml(sbPos);
            }

            if (sbEmpId != null)
            {
                mycommand = new SqlCommand("USP_SetEMPDatafromNewIILHOME", myAScon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.Parameters.Add("@EmpData", SqlDbType.Xml);
                mycommand.Parameters["@EmpData"].Value = sbEmpId.ToString();
                mycommand.Parameters.Add("@LvlData", SqlDbType.Xml);
                mycommand.Parameters["@LvlData"].Value = sbLvl.ToString();
                mycommand.Parameters.Add("@PosData", SqlDbType.Xml);
                mycommand.Parameters["@PosData"].Value = sbPos.ToString();

                mycommand.Connection.Open();
                mycommand.ExecuteNonQuery();
                mycommand.Connection.Close();
            }
        }

        public void UpdateASDataForMailsANDemps(int ConFlg)
        {
            SqlConnection myAScon;
            if (ConFlg == 2)
            {
                myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            }
            else if (ConFlg == 3)
            {
                myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAC"]);
            }
            else
            {
                myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            }
            //SqlConnection myAScon = new SqlConnection(ConfigurationSettings.AppSettings["connectionAS"]);
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            SqlCommand mycommand1 = new SqlCommand();
            DataSet dsdata = new DataSet();
            DataSet dsdata1 = new DataSet();
            mycommand = new SqlCommand("USP_GetSMSDataTOIILHOME", myAScon);
            mycommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
            mycommand.Connection.Open();
            myAdapter.Fill(dsdata, "getdata");
            mycommand.Connection.Close();
            StringWriter sbEmpId = new StringWriter();
            if ((dsdata != null) && (dsdata.Tables[0].Rows.Count > 0))
            {
                DataTable dtAS = dsdata.Tables[0];
                dtAS.TableName = "SMSData";
                dtAS.WriteXml(sbEmpId);
            }
            if (sbEmpId != null)
            {
                mycommand1 = new SqlCommand("USP_SetSMSDataAS", mycon);
                mycommand1.CommandType = CommandType.StoredProcedure;
                mycommand1.CommandTimeout = 100000;
                mycommand1.Parameters.Add("@ASId", SqlDbType.Xml);
                mycommand1.Parameters["@ASId"].Value = sbEmpId.ToString();
                SqlDataAdapter myAdapter1 = new SqlDataAdapter(mycommand1);
                mycommand1.Connection.Open();
                myAdapter1.Fill(dsdata1, "getdata");
                mycommand1.Connection.Close();
            }

            StringWriter sbEmpId1 = new StringWriter();
            if ((dsdata1 != null) && (dsdata1.Tables[0].Rows.Count > 0))
            {
                DataTable dtAS1 = dsdata1.Tables[0];
                dtAS1.TableName = "SMSData";
                dtAS1.WriteXml(sbEmpId1);
            }
            if (sbEmpId1 != null)
            {
                mycommand = new SqlCommand("USP_SetSMSDataTOIILHOME", myAScon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.Parameters.Add("@ASId", SqlDbType.Xml);
                mycommand.Parameters["@ASId"].Value = sbEmpId1.ToString();
                mycommand.Connection.Open();
                mycommand.ExecuteNonQuery();
                mycommand.Connection.Close();
            }

        }

        private void GetOPBal()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SAPService s = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceURL"]);
                List<string> input = new List<string>();
                SqlCommand mycommand = new SqlCommand();
                mycommand = new SqlCommand("USP_GetFGStock", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Flag", "G"));
                mycommand.Parameters.Add("@Dataxml", SqlDbType.Xml);
                // mycommand.Parameters["@SMSDetailsTable"].Value = SWSMS.ToString();

                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myadapterGlobal = new SqlDataAdapter(mycommand);
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                DataSet dsdata = new DataSet();
                mycommand.Connection.Open();
                myadapterGlobal.Fill(dsdata, "Getdata");
                mycommand.Connection.Close();
                if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
                {
                    input.Add(dsdata.Tables[0].Rows[0]["monyear"].ToString());
                    XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                    XmlNode xmlException = null;
                    XmlElement xDocTable = (XmlElement)s.GetOpeningbal(xDoc, out xmlException);
                    List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                    if (SAPError[0] == "1000")
                    {
                        DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
                        dt.TableName = "Availability";
                        StringWriter SWSMS = new StringWriter();
                        dt.Columns.Remove("MATDESC");
                        dt.Columns.Remove("PLNTDESC");
                        dt.Columns.Remove("SEGDESC");
                        dt.WriteXml(SWSMS);
                        mycommand = new SqlCommand("USP_GetFGStock", mycon);
                        mycommand.Parameters.Add("@Dataxml", SqlDbType.Xml);
                        mycommand.Parameters["@Dataxml"].Value = SWSMS.ToString();
                        mycommand.Parameters.Add(new SqlParameter("@Flag", "I"));
                        mycommand.CommandType = CommandType.StoredProcedure;
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                        mycommand.Connection.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---opening balance and availability of products---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        public void GetGRNStnData()
        {
            try
            {
                DataTable dtGRN = GetGRNStnData1("GRN");
                DataTable dt = new DataTable();
                dt.Columns.Add("FromLocation", typeof(string));
                dt.Columns.Add("FromLocationName", typeof(string));
                dt.Columns.Add("ToLocation", typeof(string));
                dt.Columns.Add("ToLocationName", typeof(string));
                dt.Columns.Add("MaterialCode", typeof(string));
                dt.Columns.Add("MaterilaDescriiption", typeof(string));
                dt.Columns.Add("Batch", typeof(string));
                dt.Columns.Add("LOB", typeof(string));
                dt.Columns.Add("Quantity", typeof(decimal));
                dt.Columns.Add("UOM", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                dt.Columns.Add("TOTVale", typeof(decimal));
                dt.Columns.Add("GRNNO", typeof(string));
                dt.Columns.Add("GRNDate", typeof(string));
                dt.Columns.Add("STONO", typeof(string));
                dt.Columns.Add("Indicator", typeof(string));
                dt.Columns.Add("Type", typeof(string));

                foreach (DataRow dtrow in dtGRN.Rows)
                {
                    DataRow insrow = dt.NewRow();
                    insrow["FromLocation"] = dtrow["VSTEL"];
                    insrow["FromLocationName"] = dtrow["NAME1"];
                    insrow["ToLocation"] = dtrow["WERKS"];
                    insrow["ToLocationName"] = dtrow["RWERKS"];
                    insrow["MaterialCode"] = dtrow["MATNR"];
                    insrow["MaterilaDescriiption"] = dtrow["MAKTX"];
                    insrow["Batch"] = dtrow["CHARG"];
                    insrow["LOB"] = dtrow["LGORT"];
                    insrow["Quantity"] = dtrow["MENGE"];
                    insrow["UOM"] = dtrow["MEINS"];
                    insrow["Price"] = dtrow["NETPR"];
                    insrow["TOTVale"] = dtrow["TOT"];
                    insrow["GRNNO"] = dtrow["MBLNR"];
                    insrow["GRNDate"] = dtrow["BUDAT"];
                    insrow["STONO"] = dtrow["EBELN"];
                    insrow["Indicator"] = dtrow["INDIC"];
                    insrow["Type"] = dtrow["Type"];
                    dt.Rows.Add(insrow);
                }
                DataTable dtSTN = GetGRNStnData1("STN");
                foreach (DataRow dtrow in dtSTN.Rows)
                {
                    DataRow insrow = dt.NewRow();
                    insrow["FromLocation"] = dtrow["SWERKS"];
                    insrow["FromLocationName"] = dtrow["SNAME"];
                    insrow["ToLocation"] = dtrow["RWERKS"];
                    insrow["ToLocationName"] = dtrow["RNAME"];
                    insrow["MaterialCode"] = dtrow["MATNR"];
                    insrow["MaterilaDescriiption"] = dtrow["MAKTX"];
                    insrow["Batch"] = dtrow["CHARG"];
                    insrow["LOB"] = dtrow["LGORT"];
                    insrow["Quantity"] = dtrow["LFIMG"];
                    insrow["UOM"] = dtrow["GEWEI"];
                    insrow["Price"] = dtrow["NETPR"];
                    insrow["TOTVale"] = dtrow["NETWR"];
                    insrow["GRNNO"] = dtrow["VBELN"];
                    insrow["GRNDate"] = dtrow["BLDAT"];
                    insrow["STONO"] = dtrow["VGBEL"];
                    insrow["Indicator"] = dtrow["INDIC"];
                    insrow["Type"] = dtrow["Type"];
                    dt.Rows.Add(insrow);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    //dsoutput.Tables["Payroll"].DefaultView.Sort = "EmpId,MonYear";
                    SqlConnection mycon = new SqlConnection((ConfigurationSettings.AppSettings["TestCon"].ToString()));
                    SqlConnection mycon1 = new SqlConnection((ConfigurationSettings.AppSettings["connection"].ToString()));
                    SqlCommand mycommand = new SqlCommand();
                    SqlCommand mycommand1 = new SqlCommand();
                    //DataTable dtoutput1 = new DataTable();
                    //dtoutput1 = dsoutput.Tables["HQSale"].DefaultView.ToTable();  //.DefaultView.ToTable( /*distinct*/ true);
                    dt.TableName = "GRNSTNData";
                    mycommand = new SqlCommand("USP_SetGRN_STN_Data", mycon);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    StringWriter sbppayroll = new StringWriter();
                    DataSet ds = new DataSet();
                    ds.DataSetName = "NewDataSet";
                    ds.Tables.Add(dt);
                    //dt.DataSet.DataSetName = "NewDataSet";
                    ds.WriteXml(sbppayroll);
                    //sbppayroll.ToString().Replace("DocumentElement", "NewDataSet");
                    mycommand.Parameters.Add("@GrnStnXml", SqlDbType.Xml);
                    mycommand.Parameters["@GrnStnXml"].Value = sbppayroll.ToString();
                    mycommand.CommandTimeout = 1000;
                    mycommand.Connection.Open();
                    mycommand.ExecuteNonQuery();
                    mycommand.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        public DataTable GetGRNStnData1(string stnType)
        {
            try
            {
                string FrmDate, Todate;
                FrmDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + "01";
                Todate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                List<string> input = new List<string>();
                input.Add(FrmDate);
                input.Add(Todate);
                input.Add(stnType);
                XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                s.Timeout = System.Threading.Timeout.Infinite;
                XmlElement xDocTable = (XmlElement)s.GetGRNSTNData(xDoc, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                //If Call Success
                //DataSet dsoutput = new DataSet() ;
                if (SAPError[0] == "1000")
                {
                    DataTable dsoutput = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);

                    //dsoutput = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                    return dsoutput;
                }
                return null;

            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                //throw ex;
            }
            return null;
        }

        private void QADocumentReviewReminder()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet QAReminderMail = new DataSet();
            try
            {
                string Table;
                mycommand = new SqlCommand("Usp_QA_DocumentReviewRemainder_Scheduler", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(QAReminderMail, "ReminderMail");
                mycommand.Connection.Close();
                if (QAReminderMail != null && QAReminderMail.Tables.Count > 1)
                {
                    if (QAReminderMail.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in QAReminderMail.Tables[1].Rows)
                        {
                            DataRow[] Body = QAReminderMail.Tables[0].Select("DataItem='" + row["DataItem"].ToString() + "'");
                            Table = "<center><table border='0' style='font-size:small'><tr><td align='left'>The Following Documents are pending for Review:</td></tr><tr><td align='left'><Table border='1' style='font-size:small'><tr><td align='center'>Type</td><td align='center'>Document Title</td><td align='center'>Document No</td><td align='center'>Rev. No</td><td align='center'>Effective Date</td><td align='center'>Review Date</td><td align='center'>No of Days Left</td></tr>";
                            if (QAReminderMail.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < Body.Length; i++)
                                {
                                    Table += Body[i]["Row"].ToString();
                                }
                                Table += "</Table></td></tr></table></center>";
                                SendMail(row["Email"].ToString(), "Document Review Reminder", Table, "0", "0", "p.vikramaditya@indimmune.com");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---QA Review Reminder---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        //Mail reminder to be sent only for those tickets which are raised through SMS.
        private void EnggHlpDskMailAlert()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsHlpdsk = new DataSet();
            try
            {
                mycommand = new SqlCommand("USP_F_HelpDesk_Eng_SMS", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dsHlpdsk, "Helpdesk");
                mycommand.Connection.Close();
                //int flg = 0;
                //for (int i = 0; i < dsHlpdsk.Tables.Count; i++)
                //{
                //    if (dsHlpdsk.Tables[i + 1].Rows.Count > 0)
                //    {
                //        if (dsHlpdsk.Tables[i + 2].Rows.Count > 0)
                //        {
                //            //sendEmail("Hi " + dsUser.Tables[1].Rows[0][1].ToString() + " ,<br><br> A Ticket is allocated to you.<br><table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='500px'><tr bgcolor = '#00BFFF'><th colspan='2' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>Helpdesk Ticket Details</b></font></th></tr><tr><td align='left' valign='top'><b>Ticket No</b></td><td align='left' valign='top'>" + dsUser.Tables[0].Rows[0][0].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Date and Time</b></td><td align='left' valign='top'>" + DateTime.Now.ToString() + "</td></tr></table><br>Please click on the link http://iilhome.indimmune.com/calllogging/PendingSupTicketArea.aspx to view details<br> <br> Regards<br>Helpdesk", dsUser.Tables[1].Rows[0][0].ToString());
                //            SendEnggHlpDskMail("Dear " + dsHlpdsk.Tables[i + 2].Rows[0][1].ToString() + ",<br><br>A Ticket is allocated to you.<br><table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='500px'><tr bgcolor = '#00BFFF'><th colspan='2' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>Helpdesk Ticket Details</b></font></th></tr><tr><td align='left' valign='top'><b>Ticket No</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][0].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Requestor</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i + 1].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Date and Time</b></td><td align='left' valign='top'>" + DateTime.Now.ToString() + "</td></tr><tr><td align='left' valign='top'><b>Issue</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Priority</b></td><td align='left' valign='top'>Medium</td></tr><tr><td align='left' valign='top'><b>Contact Person</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i + 2].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Status</b></td><td align='left' valign='top'>Open</td></tr></table><br>To Know more Click on the <a href='http://iilhome.indimmune.com/calllogging/PendingSupTicketArea.aspx' target='_Blank'>HelpDesk</a> link on your IILHome Main page.<br> <br> Regards<br>Helpdesk", dsHlpdsk.Tables[i + 1].Rows[0][0].ToString());
                //        }
                //        //sendEmail("Dear Sir / Madam  <br><br> Thank you for contacting our support team. A support ticket has now been opened for your request. You will be notified when a response is made by email. The details of your ticket are shown below. <br> <br> Ticket No: " + strComplaintNo + " <br> <br> Subject:  " + txtSubject.Text + "<br> Priority: " + ddlPriority.SelectedItem.Value.ToString() + " <br> Status: Open <br> <br> You can view the ticket at any time at http://iilhome.indimmune.com/CallLogging/CallLoggingReport.aspx <br> <br> You can view your General FAQs & Video Tutorials at http://iilhome.indimmune.com/InfoPolicies/ <br> <br>  Your email has been submitted to our Web Based Helpdesk & a member of our Web Response Team will view and reply accordingly, outlining possible guidance and solutions to your problem, question or query. Please be aware, at time our Web Response Team experience high volumes of tickets, which all require an equal amount of attention, therefore yours is held in a queue and will be answered as soon as possible. <br> <br>Important! Please note that any replies to this ticket should take place only at IIL home. Please do not reply this email <br><br> We would appreciate if you could keep one issue to each ticket ID so we can respond to you as quickly as possible. While sending a new ticket please be as accurate as possible providing full information to allow our Web Response Team to give you a efficient solution. Always include your, Contact details, Telephone extension number, and  any other relevant information you feel is needed. <br> <br> Regards<br> IT::Support Team", email1);
                //        if (dsHlpdsk.Tables[i + 3].Rows.Count > 0)
                //        {
                //            SendEnggHlpDskMail("Dear " + dsHlpdsk.Tables[i + 1].Rows[0][1].ToString() + ",<br><br>Greetings!!<br><br>We acknowledge your helpdesk request.<br><table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='500px'><tr bgcolor = '#00BFFF'><th colspan='2' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>Helpdesk Ticket Details</b></font></th></tr><tr><td align='left' valign='top'><b>Ticket No</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][0].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Date and Time</b></td><td align='left' valign='top'>" + DateTime.Now.ToString() + "</td></tr><tr><td align='left' valign='top'><b>Issue</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Priority</b></td><td align='left' valign='top'>Medium</td></tr><tr><td align='left' valign='top'><b>Contact Person</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i + 2].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Status</b></td><td align='left' valign='top'>Open</td></tr></table><br>To Know more Click on Helpdesk menu on your Home page<br> <br> Regards<br>Helpdesk", dsHlpdsk.Tables[i + 1].Rows[0][0].ToString());
                //        }
                //        i = i + 3;
                //    }
                //}
                for (int i = 0; i < dsHlpdsk.Tables.Count; i++)
                {
                    if (dsHlpdsk.Tables[i + 1].Rows.Count > 0)
                    {
                        if (dsHlpdsk.Tables[i + 1].Rows.Count > 0)
                        {
                            //sendEmail("Hi " + dsUser.Tables[1].Rows[0][1].ToString() + " ,<br><br> A Ticket is allocated to you.<br><table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='500px'><tr bgcolor = '#00BFFF'><th colspan='2' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>Helpdesk Ticket Details</b></font></th></tr><tr><td align='left' valign='top'><b>Ticket No</b></td><td align='left' valign='top'>" + dsUser.Tables[0].Rows[0][0].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Date and Time</b></td><td align='left' valign='top'>" + DateTime.Now.ToString() + "</td></tr></table><br>Please click on the link http://iilhome.indimmune.com/calllogging/PendingSupTicketArea.aspx to view details<br> <br> Regards<br>Helpdesk", dsUser.Tables[1].Rows[0][0].ToString());
                            SendEnggHlpDskMail("Dear " + dsHlpdsk.Tables[i + 1].Rows[0][1].ToString() + ",<br><br>A Ticket is allocated to you.<br><table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='500px'><tr bgcolor = '#00BFFF'><th colspan='2' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>Helpdesk Ticket Details</b></font></th></tr><tr><td align='left' valign='top'><b>Ticket No</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][0].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Requestor</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i + 2].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Date and Time</b></td><td align='left' valign='top'>" + DateTime.Now.ToString() + "</td></tr><tr><td align='left' valign='top'><b>Issue</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Priority</b></td><td align='left' valign='top'>Medium</td></tr><tr><td align='left' valign='top'><b>Contact Person</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i + 2].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Status</b></td><td align='left' valign='top'>Open</td></tr></table><br>To Know more Click on the <a href='http://iilhome.indimmune.com/calllogging/PendingSupTicketArea.aspx' target='_Blank'>HelpDesk</a> link on your IILHome Main page.<br> <br> Regards<br>Helpdesk", dsHlpdsk.Tables[i + 1].Rows[0][0].ToString());
                        }
                        //sendEmail("Dear Sir / Madam  <br><br> Thank you for contacting our support team. A support ticket has now been opened for your request. You will be notified when a response is made by email. The details of your ticket are shown below. <br> <br> Ticket No: " + strComplaintNo + " <br> <br> Subject:  " + txtSubject.Text + "<br> Priority: " + ddlPriority.SelectedItem.Value.ToString() + " <br> Status: Open <br> <br> You can view the ticket at any time at http://iilhome.indimmune.com/CallLogging/CallLoggingReport.aspx <br> <br> You can view your General FAQs & Video Tutorials at http://iilhome.indimmune.com/InfoPolicies/ <br> <br>  Your email has been submitted to our Web Based Helpdesk & a member of our Web Response Team will view and reply accordingly, outlining possible guidance and solutions to your problem, question or query. Please be aware, at time our Web Response Team experience high volumes of tickets, which all require an equal amount of attention, therefore yours is held in a queue and will be answered as soon as possible. <br> <br>Important! Please note that any replies to this ticket should take place only at IIL home. Please do not reply this email <br><br> We would appreciate if you could keep one issue to each ticket ID so we can respond to you as quickly as possible. While sending a new ticket please be as accurate as possible providing full information to allow our Web Response Team to give you a efficient solution. Always include your, Contact details, Telephone extension number, and  any other relevant information you feel is needed. <br> <br> Regards<br> IT::Support Team", email1);
                        if (dsHlpdsk.Tables[i + 2].Rows.Count > 0)
                        {
                            SendEnggHlpDskMail("Dear " + dsHlpdsk.Tables[i + 2].Rows[0][1].ToString() + ",<br><br>Greetings!!<br><br>We acknowledge your helpdesk request.<br><table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='500px'><tr bgcolor = '#00BFFF'><th colspan='2' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>Helpdesk Ticket Details</b></font></th></tr><tr><td align='left' valign='top'><b>Ticket No</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][0].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Date and Time</b></td><td align='left' valign='top'>" + DateTime.Now.ToString() + "</td></tr><tr><td align='left' valign='top'><b>Issue</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Priority</b></td><td align='left' valign='top'>Medium</td></tr><tr><td align='left' valign='top'><b>Contact Person</b></td><td align='left' valign='top'>" + dsHlpdsk.Tables[i + 1].Rows[0][1].ToString() + "</td></tr><tr><td align='left' valign='top'><b>Status</b></td><td align='left' valign='top'>Open</td></tr></table><br>To Know more Click on Helpdesk menu on your Home page<br> <br> Regards<br>Helpdesk", dsHlpdsk.Tables[i + 1].Rows[0][0].ToString());
                        }
                        i = i + 3;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Helpdesk ticket mail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        /// <summary>
        /// update PRA details automatically from SAP
        /// </summary>
        private void GetPraDet()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet ds = new DataSet();
            DataSet dtSAPUserDetails = new DataSet();

            try
            {
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "Itdev#13";
                mycommand = new SqlCommand("USP_PRA_GetDet", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Flag", "1"));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dtSAPUserDetails, "GetAutDet");
                mycommand.Connection.Close();



                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                s.Timeout = 999999999;
                XmlDocument xDoc1 = XMLSerializerBL.Serialize(dtSAPUserDetails, XMLSerializerBL.InputType.DataSet);
                XmlNode xmlException = null;
                XmlElement xDocTable1 = null;

                xDocTable1 = (XmlElement)s.GetPRADet(xDoc1, Dest, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                DataTable dtreturn = new DataTable();

                DataSet dsReturn = new DataSet();
                if (SAPError[0] == "1000")
                {

                    dsReturn = (DataSet)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataSet);
                    DataTable dtDB = dsReturn.Tables[0].Copy();

                    dtDB.TableName = "Mytable";
                    string xmls;
                    using (StringWriter sw = new StringWriter())
                    {
                        dtDB.WriteXml(sw);
                        xmls = sw.ToString();
                    }
                    //To Send Error Det
                    mycommand = new SqlCommand("USP_PRA_GetDet", mycon);
                    mycommand.Parameters.Add(new SqlParameter("@Flag", "2"));
                    mycommand.Parameters.Add(new SqlParameter("@UpdPRADtl", xmls));
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.CommandTimeout = 20000;
                    myAdapter = new SqlDataAdapter(mycommand);
                    mycommand.Connection.Open();
                    myAdapter.Fill(ds, "GetDet");
                    mycommand.Connection.Close();

                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---OrderToInvoice---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        // sending AMC reminders
        private void AMCReviewReminder()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet AMC = new DataSet();
            try
            {
                string Table;
                mycommand = new SqlCommand("Usp_AMC_AMCRemainder_Scheduler", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(AMC, "ReminderMail");
                mycommand.Connection.Close();
                string desc = null;
                int count = 0;
                if (AMC != null && AMC.Tables.Count > 0 && AMC.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in AMC.Tables[0].Rows)
                    {
                        desc = row["Type"].ToString();
                        Table = "<center><table border='0' style='font-size:small'><tr><td align='left'>The Following " + desc + " are pending for Review:</td></tr><tr><td align='left'><Table border='1' style='font-size:small'><tr><td align='Left'>Type</td><td align='center'>Title</td><td align='center'>Indent No</td><td align='center'>PO No</td><td align='center'>Vendor</td><td align='center'>Vendor Code</td><td align='center'>Start Date</td><td align='center'>End Date</td><td align='center'>No of Days Left</td></tr>";
                        Table += row["Row"].ToString();
                        Table += "</Table></td></tr></table></center>";
                        SendMail(row["To"].ToString(), desc + " Review Reminder", Table, "0", "0", row["CC"] + ",muralimohan@indimmune.com");
                    }
                }
                if ((1 == 2) && AMC != null && AMC.Tables.Count > 1)
                {
                    if (AMC.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in AMC.Tables[1].Rows)
                        {
                            DataRow[] SubRow = AMC.Tables[2].Select("Empid='" + row["DataItem"].ToString() + "'");
                            count = SubRow.Length;
                            if (count == 1)
                            {
                                desc = SubRow[0]["Type"].ToString();
                            }
                            else if (count == 2)
                            {
                                desc = SubRow[0]["Type"].ToString() + " & " + SubRow[1]["Type"].ToString();
                            }
                            else if (count > 2)
                            {
                                for (int j = 0; j < SubRow.Length; j++)
                                {
                                    if (j < count - 1)
                                    {
                                        desc += SubRow[j]["Type"].ToString() + " and ";
                                    }
                                    else
                                    {
                                        desc += SubRow[j]["Type"].ToString() + ",";
                                    }
                                }
                            }
                            else
                            {
                                desc = "Reminder";
                            }
                            desc = desc.TrimEnd(',');
                            DataRow[] Body = AMC.Tables[0].Select("DataItem='" + row["DataItem"].ToString() + "'");
                            Table = "<center><table border='0' style='font-size:small'><tr><td align='left'>The Following " + desc + " are pending for Review:</td></tr><tr><td align='left'><Table border='1' style='font-size:small'><tr><td align='Left'>Type</td><td align='center'>Title</td><td align='center'>Indent No</td><td align='center'>PO No</td><td align='center'>Vendor</td><td align='center'>Vendor Code</td><td align='center'>Start Date</td><td align='center'>End Date</td><td align='center'>No of Days Left</td></tr>";
                            if (AMC.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < Body.Length; i++)
                                {
                                    Table += Body[i]["Row"].ToString();
                                }
                                Table += "</Table></td></tr></table></center>";
                                SendMail(row["Email"].ToString(), desc + " Review Reminder", Table, "0", "0", "p.vikramaditya@indimmune.com");
                            }
                            count = 0;
                            desc = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---AMC Review Reminder---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        // sending PRA ALert Mails 
        private void PRAAlertMailer()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet PRA = new DataSet();
            try
            {
                mycommand = new SqlCommand("USP_PRA_InitiateReportPage", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(PRA, "PRAReminder");
                mycommand.Connection.Close();

                if (PRA != null && PRA.Tables.Count > 1)
                {
                    if (PRA.Tables[0].Rows.Count > 0)
                    {
                        SendMail(PRA.Tables[0].Rows[0]["TOMail"].ToString().Trim(), PRA.Tables[0].Rows[0]["MailSubject"].ToString().Trim(), PRA.Tables[0].Rows[0]["MailBody"].ToString().Trim(), "0", "0", PRA.Tables[0].Rows[0]["CCMail"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---PRA Alert Mailer---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        public static string Decrypt(string cipherText)
        {
            try
            {
                string _Phrase = "IIL"; //Be careful storing this in code unless it’s secured and not distributed
                byte[] _Salt = new byte[] { 0x45, 0xF1, 0x61, 0x6e, 0x20, 0x00, 0x65, 0x64, 0x76, 0x65, 0x64, 0x03, 0x76 };
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_Phrase, _Salt);
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            catch
            {
                return cipherText;
            }
        }
        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = null;
            try
            {
                Rijndael alg = Rijndael.Create();
                alg.Key = Key;
                alg.IV = IV;
                cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.FlushFinalBlock();
                return ms.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.Close();
            }
        }

        //Promo samples  Background Process. Order to Invoice. -- By Supraja 29.01.2016
        private void OrdertoInvoiceProcess()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet ds = new DataSet();
            DataSet dtSAPUserDetails = new DataSet();

            try
            {
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "Itdev#13";
                mycommand = new SqlCommand("USP_Common_GetSAPUserDetails", mycon);
                mycommand.Parameters.Add(new SqlParameter("@EmpId", "PIHUB"));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dtSAPUserDetails, "GetAutDet");
                mycommand.Connection.Close();
                if (dtSAPUserDetails.Tables[0].Rows.Count > 0)
                {
                    string strUserId = Convert.ToString(dtSAPUserDetails.Tables[0].Rows[0]["UserId"]);
                    string strPassWord = Decrypt(Convert.ToString(dtSAPUserDetails.Tables[0].Rows[0]["Password"]));

                    List<string> liSAPUserDetails = new List<string>();
                    liSAPUserDetails.Add("PRD_000");
                    liSAPUserDetails.Add((strUserId == null || strUserId == "") ? "0" : strUserId);
                    liSAPUserDetails.Add((strPassWord == null || strPassWord == "") ? "0" : strPassWord);
                    Dest = liSAPUserDetails.ToArray();
                }
                //string Table;
                mycommand = new SqlCommand("USP_Promo_SaveInvoiceDet", mycon);
                mycommand.Parameters.Add(new SqlParameter("@FLAG", "2"));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "GetDet");
                mycommand.Connection.Close();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtAllocID = ds.Tables[1];
                    DataTable dttemp = ds.Tables[0];
                    int LoopCnt = ds.Tables[1].Rows.Count;
                    for (int i = 0; i < dtAllocID.Rows.Count; i++)
                    {
                        string AllocID = dtAllocID.Rows[i][0].ToString();
                        string AllocDt = dtAllocID.Rows[i][1].ToString();
                        DataView dv = new DataView(dttemp);
                        dv.RowFilter = "AllocationID='" + AllocID + "'";

                        DataTable dtFilter = dv.ToTable();

                        if (dttemp.Rows.Count > 0)
                        {
                            DataTable dt = dtFilter;
                            DataTable dtStatus = new DataTable();
                            dtStatus.Columns.Add("STATUS", typeof(string));
                            dtStatus.Columns.Add("allocationid", typeof(string));
                            dtStatus.Columns.Add("allocationDt", typeof(string));
                            dtStatus.Rows.Add("2", AllocID, AllocDt);

                            DataTable dtCopy = dt.Copy();
                            //DataView dv = new DataView(dtCopy);
                            //dv.RowFilter = "CUSTOMER='000648'";
                            //dtCopy = dv.ToTable();
                            dtCopy.TableName = "IT_CUST";
                            DataSet dsap = new DataSet();
                            dsap.Tables.Add(dtCopy);
                            dsap.Tables.Add(dtStatus);

                            SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                            s.Timeout = 999999999;
                            XmlDocument xDoc1 = XMLSerializerBL.Serialize(dsap, XMLSerializerBL.InputType.DataSet);
                            XmlNode xmlException = null;
                            XmlElement xDocTable1 = null;

                            xDocTable1 = (XmlElement)s.GetOrderToInvoice(xDoc1, Dest, out xmlException);
                            List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                            DataTable dtreturn = new DataTable();

                            DataSet dsReturn = new DataSet();
                            if (SAPError[0] == "1000")
                            {

                                dsReturn = (DataSet)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataSet);
                                DataTable dtDB = dsReturn.Tables[0].Copy();

                                dtDB.TableName = "Mytable";
                                string xmls;
                                using (StringWriter sw = new StringWriter())
                                {
                                    dtDB.WriteXml(sw);
                                    xmls = sw.ToString();
                                }
                                //To Send Error Det
                                DataView dvError = new DataView(dsReturn.Tables[1]);
                                dvError.RowFilter = "Type='E'";
                                DataTable dtError = dvError.ToTable();
                                string xmls2;
                                using (StringWriter sw = new StringWriter())
                                {
                                    dtError.WriteXml(sw);
                                    xmls2 = sw.ToString();
                                }
                                mycommand = new SqlCommand("USP_AllocationToFO", mycon);
                                mycommand.Parameters.Add(new SqlParameter("@FLAG", "12"));
                                mycommand.Parameters.Add(new SqlParameter("@AllocationID", AllocID));
                                mycommand.Parameters.Add(new SqlParameter("@XMLHead", xmls));
                                mycommand.Parameters.Add(new SqlParameter("@XMLNewItem", xmls2));
                                mycommand.Parameters.Add(new SqlParameter("@EmpID", "PIHUB"));
                                mycommand.CommandType = CommandType.StoredProcedure;
                                mycommand.CommandTimeout = 20000;
                                myAdapter = new SqlDataAdapter(mycommand);
                                mycommand.Connection.Open();
                                myAdapter.Fill(ds, "GetDet");
                                mycommand.Connection.Close();

                                //to make status as 0
                                dt.TableName = "Mytable";
                                using (StringWriter sw = new StringWriter())
                                {
                                    dt.WriteXml(sw);
                                    xmls = sw.ToString();
                                }

                                mycommand = new SqlCommand("USP_Promo_SaveInvoiceDet", mycon);
                                mycommand.Parameters.Add(new SqlParameter("@FLAG", "3"));
                                mycommand.Parameters.Add(new SqlParameter("@XML", xmls));
                                mycommand.Parameters.Add(new SqlParameter("@AllocID", AllocID)); // Added by Supraja on 29-04-16
                                mycommand.CommandType = CommandType.StoredProcedure;
                                mycommand.CommandTimeout = 20000;
                                myAdapter = new SqlDataAdapter(mycommand);
                                mycommand.Connection.Open();
                                myAdapter.Fill(ds, "GetDet");
                                mycommand.Connection.Close();
                                // To get Email id'd for sending mails 
                                dt.TableName = "Mytable";
                                using (StringWriter sw = new StringWriter())
                                {
                                    dt.WriteXml(sw);
                                    xmls = sw.ToString();
                                }

                                DataSet dsemail = new DataSet();
                                mycommand = new SqlCommand("USP_AllocationToFOMail", mycon);
                                mycommand.Parameters.Add(new SqlParameter("@FLAG", "12"));
                                mycommand.Parameters.Add(new SqlParameter("@XMLHead", xmls));
                                mycommand.Parameters.Add(new SqlParameter("@AllocationID", AllocID));
                                mycommand.Parameters.Add(new SqlParameter("@EmpID", "PIHUB"));
                                mycommand.CommandType = CommandType.StoredProcedure;
                                mycommand.CommandTimeout = 20000;
                                myAdapter = new SqlDataAdapter(mycommand);
                                mycommand.Connection.Open();
                                myAdapter.Fill(dsemail, "GetDet");
                                mycommand.Connection.Close();
                                if (dsemail.Tables[4].Rows.Count > 0)
                                {
                                    string Mail = dsemail.Tables[4].Rows[0][0].ToString();
                                    //SendPromoConfirm(AllocID, Mail); // commented by Supraja 26-04-16
                                }
                                SendPromoDetMail(dsemail.Tables[0], dsemail, Convert.ToInt32(AllocID));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---OrderToInvoice---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        protected void PromoDetailsUpdatation()
        {

            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            SqlDataAdapter myAdapter;
            DataSet dslr = new DataSet();
            DataSet ds = new DataSet();
            try
            {
                mycommand = new SqlCommand("USP_Promo_TaxDetails", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Falg", "1"));

                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dslr, "ds");
                mycommand.Connection.Close();
                //string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "itdev#13";
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "iildev"; Dest[2] = "p@$$@dev";
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                s.Timeout = 999999999;
                DataSet obj = new DataSet();
                DataTable dt1 = new DataTable();

                XmlDocument xDoc = XMLSerializerBL.Serialize(dslr, XMLSerializerBL.InputType.DataSet);
                // XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                //XmlElement xDocTable = (XmlElement)s.GetInvoiceDet(xDoc,Dest,out xmlException);
                XmlElement xDocTable = (XmlElement)s.PromoPrintDet(xDoc, Dest, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                if (SAPError[0] == "1000")
                {
                    ds = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);

                    string xmls1 = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtDeT = ds.Tables[0].Copy();
                        StringWriter sbLR = new StringWriter();
                        dtDeT.TableName = "Invoice";
                        using (StringWriter sw = new StringWriter())
                        {
                            dtDeT.WriteXml(sw);
                            xmls1 = sw.ToString();
                        }
                    }
                    DataSet dtresult = new DataSet();
                    mycommand = new SqlCommand("USP_Promo_TaxDetails", mycon);
                    mycommand.Parameters.Add(new SqlParameter("@Falg", "2"));
                    mycommand.Parameters.Add(new SqlParameter("@XMLData", xmls1));
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.CommandTimeout = 20000;
                    myAdapter = new SqlDataAdapter(mycommand);
                    mycommand.Connection.Open();
                    myAdapter.Fill(dtresult, "ds");
                    mycommand.Connection.Close();

                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---OrderToInvoice---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }

        }





        protected void SendPromoConfirm(string allocid, string Mail)
        {

            string message = " <br><br>Dear Sir / Madam," + "<br><br>Proforma Invoice has been processed for the allocation ID : " + allocid + "<br><br>";
            message = message + "Please click on the link https://www.iilfast.com to view details.";
            //message = message+"AllocationID " + AllocationID + "<br><br>";
            //message = message + "<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='800px'><tr bgcolor = '#00BFFF'><th colspan='40' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial' size='2'><b>Your materials are process successfully.please check it once.</b></font></th></tr>";
            message = message + "</table><br><br>";
            sendPromoMail(message, Mail);
        }
        private void sendPromoMail(string message, string email)
        {
            MailMessage mmsg = new MailMessage();
            mmsg.From = "iilwebadmin@indimmune.com";
            mmsg.To = email;
            mmsg.Subject = "Allocation Process";
            mmsg.Body = message;
            mmsg.BodyFormat = MailFormat.Html;
            SmtpMail.SmtpServer = ConfigurationManager.AppSettings["MailServer"].ToString();
            if (mmsg.To != "" && (mmsg.Subject != "" || mmsg.Body != ""))
            {
                SmtpMail.Send(mmsg);
            }
        }
        protected void SendPromoDetMail(DataTable dt, DataSet ds, int AllocationID)
        {
            DataTable dtPro = ds.Tables[3];

            string message = "Dear Sir / Madam," + "<br><br>Proforma Invoice has been processed for the allocation ID : " + AllocationID + "<br><br>";
            //message = message+"AllocationID " + AllocationID + "<br><br>";
            message = message + "<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='800px'><tr bgcolor = '#00BFFF'><th colspan='40' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial' size='2'><b>Allocation Process Details</b></font></th></tr>";
            message = message + "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                message = message + " <td align='left' valign='top'><font size='2'>" + dt.Columns[i].ColumnName + "</font></td>";
            }
            message = message + "</tr>";
            int k = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                message = message + "<tr>";
                string empid = dt.Rows[i][1].ToString();
                empid = empid.Substring(0, empid.IndexOf("-"));//UNCOMMENT   

                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    string color = "r";
                    string colsname = dt.Columns[j].ColumnName;
                    DataView dv = new DataView(dtPro);
                    if (colsname.Contains("-"))
                    {
                        color = "r";
                        colsname = colsname.Substring(0, colsname.IndexOf("-"));//UNCOMMENT                        
                        dv.RowFilter = "Material='" + colsname + "' and EmpId='" + empid + "'";
                        if (dv.ToTable().Rows.Count > 0)
                        {
                            color = "b";
                        }
                    }


                    if (j == 0)
                    {
                        message = message + "<td align='left' valign='top' width='5px'><font size='2'>" + dt.Rows[i][j].ToString() + "</font></td>";
                    }
                    else if (j == 1)
                    {
                        message = message + "<td align='left' valign='top'><font size='2'>" + dt.Rows[i][j].ToString() + "</font></td>";
                    }
                    else
                    {
                        if (colsname == "Invoice No" || colsname == "Order No")
                        {
                            message = message + "<td align='right' valign='top'><font size='2'>" + dt.Rows[i][j].ToString() + "</font></td>";
                        }
                        else if (color == "r")
                        {
                            message = message + "<td align='right' valign='top'><font size='2' color='red'>" + dt.Rows[i][j].ToString() + "</font></td>";
                            k++;
                        }
                        else if (color == "b")
                            message = message + "<td align='right' valign='top'><font size='2'>" + dt.Rows[i][j].ToString() + "</font></td>";
                    }
                }
                message = message + "</tr>";
            }
            message = message + "</table><br><br>";
            if (k != 0)
            {
                message = message + "Note :Red indicates unprocessed materials";
            }
            string Email = "";
            string ccemail = "";
            if (ds.Tables[1].Rows.Count > 0)
            {
                Email = ds.Tables[1].Rows[0][0].ToString();
            }
            if (ds.Tables.Count > 3)
            {
                //ccemail = ds.Tables[4].Rows[0][0].ToString();
                if (ds.Tables[2].Rows.Count > 0 && ds.Tables[4].Rows.Count > 0)
                {
                    ccemail = ds.Tables[2].Rows[0][1].ToString() + "," + ds.Tables[4].Rows[0][0].ToString();
                }
            }
            WriteLog(1, "Message :" + message + "---Email :---" + Email + "---cc :---" + ccemail + "---Execution Time---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            sendPromoDataEmail(message, Email, ccemail);

        }
        private void sendPromoDataEmail(string message, string email, string ccemail)
        {
            MailMessage mmsg = new MailMessage();
            mmsg.From = "iilwebadmin@indimmune.com";
            mmsg.To = email;
            mmsg.Subject = "Promotional Sample Order to Invoice";
            mmsg.Body = message;
            mmsg.Cc = ccemail;
            mmsg.BodyFormat = MailFormat.Html;
            SmtpMail.SmtpServer = ConfigurationManager.AppSettings["MailServer"].ToString();
            if (mmsg.To != "" && (mmsg.Subject != "" || mmsg.Body != ""))
            {
                SmtpMail.Send(mmsg);
            }
        }

        protected void LRDet()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dslr = new DataSet();
            DataSet dsUser = new DataSet();
            try
            {
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "Itdev#13";
                string Table;
                mycommand = new SqlCommand("USP_Promo_LRDet", mycon);
                mycommand.Parameters.Add(new SqlParameter("@FLAG", "1"));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dslr, "GetDet");
                mycommand.Connection.Close();
                SAPService s = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceURL"]);
                DataSet obj = new DataSet();
                DataTable dt1 = new DataTable();
                obj.Tables.Add(dslr.Tables[0].Copy());
                obj.Tables.Add(dslr.Tables[1].Copy());
                XmlDocument xDoc = XMLSerializerBL.Serialize(obj, XMLSerializerBL.InputType.DataSet);
                // XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                XmlElement xDocTable = (XmlElement)s.GetInvoiceandLRDetails(xDoc, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                if (SAPError[0] == "1000")
                {
                    dsUser = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                    string xmls1 = "";
                    if (dsUser.Tables["Delivery"].Rows.Count > 0)
                    {
                        DataTable dtDel = dsUser.Tables["Delivery"].Copy();
                        StringWriter sbLR = new StringWriter();
                        //ds.Tables["Delivery"].WriteXml(sbLR);
                        dtDel.TableName = "Delivery";

                        using (StringWriter sw = new StringWriter())
                        {
                            dtDel.WriteXml(sw);
                            xmls1 = sw.ToString();
                        }
                    }
                    string xmls = "";
                    if (dsUser.Tables["LRNO"].Rows.Count > 0)
                    {
                        DataTable dtLRNo = dsUser.Tables["LRNO"].Copy();
                        if (dsUser.Tables.Count > 0 && dsUser.Tables["LRNO"].Rows.Count > 0)
                        {
                            StringWriter sbLR = new StringWriter();
                            // ds.Tables["LRNO"].WriteXml(sbLR);
                            dtLRNo.TableName = "LRNO";

                            using (StringWriter sw = new StringWriter())
                            {
                                dtLRNo.WriteXml(sw);
                                xmls = sw.ToString();
                            }
                        }
                    }

                    mycommand = new SqlCommand("USP_Promo_LRDet", mycon);
                    mycommand.Parameters.Add(new SqlParameter("@FLAG", "2"));
                    mycommand.Parameters.Add(new SqlParameter("@LRUpdation", xmls));
                    mycommand.Parameters.Add(new SqlParameter("@Delivery", xmls1));
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.CommandTimeout = 20000;
                    myAdapter = new SqlDataAdapter(mycommand);
                    mycommand.Connection.Open();
                    myAdapter.Fill(dslr, "GetDet");
                    mycommand.Connection.Close();
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsUser.Tables[2].Rows.Count; i++)
                        {
                            int allocID = Convert.ToInt32(dsUser.Tables[2].Rows[i][0].ToString());
                            DataView dv = new DataView(dsUser.Tables[0]);
                            DataView dv1 = new DataView(dsUser.Tables[1]);
                            dv.RowFilter = "AllocationID='" + allocID + "'";
                            //dv1.RowFilter = "AllocationID='" + allocID + "'";
                            SendMailPromoLRD(dv.ToTable(), dv1.ToTable(), allocID, dsUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Promo Module---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }

        }
        protected void SendMailPromoLRD(DataTable dt, DataTable dtEmp, int AllocationID, DataSet ds)
        {
            DataTable dte = ds.Tables[3];
            string message = "Dear Sir / Madam,<br><br>";
            message = message + " Promo/Samples Materials has been shifted.<br>";
            message = message + " Allocation ID: " + AllocationID;
            message = message + "<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='800px'><tr bgcolor = '#00BFFF'><th colspan='40' valign='bottom' align='centre'><font color = '#FFFFFF' face='Arial'><b>LR Details</b></font></th></tr>";
            message = message + "<tr>";
            message = message + " <td align='left' valign='top'><font size='2'>Employee</font> </td><td align='left' valign='top'><font size='2'>Material</font> </td><td align='left' valign='top'><font size='2'>InvoiceNo</font></td><td align='left' valign='top'><font size='2'>LRNo</font></td><td align='left' valign='top'><font size='2'>LR Date</font></td><td align='left' valign='top'><font size='2'>Delivery Date</font></td>";
            message = message + "</tr>";
            for (int i = 0; i < dte.Rows.Count; i++)
            {
                message = message + "<tr> <td align='left' valign='top'><font size='2'>" + dte.Rows[i][1].ToString() + "</font></td><td align='left' valign='top'><font size='2'>" + dte.Rows[i][2].ToString() + "</font></td><td align='left' valign='top'><font size='2'>" + dte.Rows[i][3].ToString() + "</font></td><td align='left' valign='top'><font size='2'>" + dte.Rows[i][4].ToString() + "</font></td><td align='left' valign='top'><font size='2'>" + dte.Rows[i][5].ToString() + "</font></td><td align='left' valign='top'><font size='2'>" + dte.Rows[i][6].ToString() + "</font></td></tr>";
            }
            message = message + "</table>";
            //<tr><td a
            string Email = dt.Rows[0][1].ToString();
            string ccmail = dtEmp.Rows[0][0].ToString();
            sendEmailforPromoLR(message, Email, ccmail);

        }
        private void sendEmailforPromoLR(string message, string email, string ccmail)
        {
            MailMessage mmsg = new MailMessage();
            mmsg.From = "iilwebadmin@indimmune.com";
            mmsg.To = email;
            mmsg.Subject = "LR Details";
            mmsg.Body = message;
            mmsg.Cc = ccmail;
            mmsg.BodyFormat = MailFormat.Html;
            SmtpMail.SmtpServer = ConfigurationManager.AppSettings["MailServer"].ToString();
            if (mmsg.To != "" && (mmsg.Subject != "" || mmsg.Body != ""))
            {
                SmtpMail.Send(mmsg);
            }
        }

        /// <summary>
        /// Created By Hari
        /// Created Date 27th June 2019
        /// Created For LMS License Expiry Mails Auto sent
        /// </summary>
        private void LMSLicenseExpiryMail()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsLMSMail = new DataSet();
            try
            {
                mycommand = new SqlCommand("USP_LM_AutoMailsNew", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter mygetSchedulesAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                mygetSchedulesAdapter.Fill(dsLMSMail, "LMSLicenseExpiryReport");
                string message = string.Empty, LCNo = string.Empty, ExpiryDt = string.Empty, IssueDt = string.Empty, LicenseType = string.Empty;
                if (dsLMSMail != null && dsLMSMail.Tables.Count > 0 && dsLMSMail.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsLMSMail.Tables[0].Rows.Count; i++)
                    {
                        IssueDt = dsLMSMail.Tables[0].Rows[i]["IssueDt"].ToString();
                        LicenseType = dsLMSMail.Tables[0].Rows[i]["LicenseTypeName"].ToString();
                        LCNo = dsLMSMail.Tables[0].Rows[i]["LCNo"].ToString();
                        ExpiryDt = dsLMSMail.Tables[0].Rows[i]["ExpDt"].ToString();
                        //message = "Dear Sir / Madam," + "<br><br>License No'" + LCNo + "' will be expired on '" + ExpiryDt + "'.<br><br>";
                        message = "Dear Sir / Madam," + "<br><br>" + LicenseType + " <b>:" + LCNo + "</b> dated <b>" + IssueDt + "</b> will be expired on <b>" + ExpiryDt + "</b>. Please renew the same within due date and send us the same for our records.<br><br>";
                        //message = message + "Please click on the link http://iilhome.indimmune.com/Login.aspx for more details.";
                        SendMail(dsLMSMail.Tables[0].Rows[i]["CFAMailId"].ToString(), "License Management Intimation ", message, "0", "0", dsLMSMail.Tables[0].Rows[i]["CFACCMailId"].ToString());
                        if (mailFlag)
                        {
                            SqlConnection myconn = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                            SqlCommand mycommandd = new SqlCommand();
                            mycommandd = new SqlCommand("USP_LM_SETGETMailCount", myconn);
                            SqlDataAdapter myAdapter = new SqlDataAdapter();
                            DataSet dsMailCount = new DataSet();
                            try
                            {
                                mycommandd.Parameters.Add(new SqlParameter("@LCNo", LCNo));
                                mycommandd.Parameters.Add(new SqlParameter("@flag", "u"));
                                mycommandd.CommandType = CommandType.StoredProcedure;
                                mycommandd.CommandTimeout = 20000;
                                myAdapter = new SqlDataAdapter(mycommand);
                                mycommandd.Connection.Open();
                                myAdapter.Fill(dsMailCount);
                                mycommandd.Connection.Close();
                            }
                            catch (Exception ex)
                            {
                                WriteLog(1, "Exception :" + ex.Message + "---Errors Report---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            }
                            finally
                            {
                                if (mycommandd.Connection.State == ConnectionState.Open)
                                    mycommandd.Connection.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Errors Report---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }


        #endregion

        #region SubFunctions
        private void SAPEmpCreation()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                SqlCommand mycommand = new SqlCommand();
                SqlCommand mycommand1 = new SqlCommand();
                DataSet ds = new DataSet();
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                string strEmpNo = "";
                string strSex = "";
                string strTitle = "";
                string strFather = "";
                string strEmpType = "";
                string strMaritalStatus = "";
                string strDob = "";
                string strDoj = "";
                string strQuarters = "";
                string strBankMode = "";
                string strEmpName = "";
                string strAddress1 = "";
                string strAddress2 = "";
                string strAddress3 = "";
                string strPostal = null;
                string strEmpLocation = "";
                string strDesig = "";
                string strGrade = "";
                string strScale = "";
                string strDepartment = "";
                string strDoc = "";

                try
                {
                    //Getting maximum Employee Number from legacy
                    mycommand = new SqlCommand("USP_EmpCreation_getMaxEmpId", mycon);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                    mycommand.Connection.Open();
                    myAdapter.Fill(ds, "getMaxEmpId");
                }
                catch (Exception ex)
                {
                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Getting maximum Employee Number from legacy---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }
                finally
                {
                    if (mycommand.Connection.State == ConnectionState.Open)
                        mycommand.Connection.Close();
                }

                try
                {
                    if (ds.Tables["getMaxEmpId"].Rows.Count > 0)
                    {
                        try
                        {
                            //Passing Maximum Employee Number to SAP RFC and Retrieving Details of the Employee                            
                            List<string> input = new List<string>();
                            input.Add(ds.Tables["getMaxEmpId"].Rows[0]["EmpCount"].ToString());
                            //input.Add("4014");
                            XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                            XmlNode xmlException = null;
                            XmlElement xDocTable = (XmlElement)s.R3EmpCreation(xDoc, out xmlException);
                            List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);

                            if (SAPError[0] == "1000")
                            {
                                DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                if (dt.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        //Employee Number
                                        strEmpNo = dr["Empno"].ToString().Substring(2, 6);

                                        try
                                        {
                                            //Checking whether Employee already exists in the legacy
                                            mycommand = new SqlCommand("USP_EmpCreation_chkEmpExists", mycon);
                                            mycommand.CommandType = CommandType.StoredProcedure;
                                            mycommand.Parameters.Add(new SqlParameter("@EmpId", strEmpNo));
                                            SqlDataAdapter myAdapter1 = new SqlDataAdapter(mycommand);
                                            mycommand.Connection.Open();
                                            myAdapter1.Fill(ds, "chkEmpExists");
                                        }
                                        catch (Exception ex)
                                        {
                                            WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Checking whether Employee already exists in the legacy---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                        }
                                        finally
                                        {
                                            if (mycommand.Connection.State == ConnectionState.Open)
                                                mycommand.Connection.Close();
                                        }

                                        if (ds.Tables["chkEmpExists"].Rows.Count <= 0)
                                        {
                                            //Employee Sex
                                            if (Convert.ToInt32(dr["Empsex"].ToString()) == 1)
                                            {
                                                strSex = "M";
                                                strTitle = "Mr.";
                                            }
                                            else
                                            {
                                                strSex = "F";
                                                strTitle = "Miss";
                                            }

                                            try
                                            {
                                                //Employee Father Name from another RFC(from Table)
                                                List<string> input1 = new List<string>();
                                                input1.Add("PA0021");
                                                input1.Add("PERNR EQ " + dr["EmpNo"].ToString());
                                                input1.Add("SUBTY|FANAM");
                                                XmlDocument xDoc1 = XMLSerializerBL.Serialize(input1, XMLSerializerBL.InputType.List);
                                                XmlNode xmlException1 = null;
                                                XmlElement xDocTable1 = (XmlElement)s.GetTableData(xDoc1, out xmlException1);
                                                List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlException1.OuterXml, XMLSerializerBL.OutputType.List);

                                                if (SAPError1[0] == "1000")
                                                {
                                                    DataTable dt1 = (DataTable)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                                    if (dt1.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow dr1 in dt1.Rows)
                                                        {
                                                            if (Convert.ToInt32(dr1["SubType"].ToString()) == 11)
                                                            {
                                                                strFather = dr1["FatherName"].ToString();
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //no details found in sap
                                                    }
                                                }
                                                else
                                                {
                                                    //sap failure Message
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Employee Father Name from another RFC(from Table)---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                            }

                                            //Employee Type based on Designation
                                            if (Convert.ToInt32(dr["Designation"].ToString()) == 0)
                                            {
                                                if (dr["Grade"].ToString() == "O1" || dr["Grade"].ToString() == "O2" || dr["Grade"].ToString() == "A1" || dr["Grade"].ToString() == "A2" || dr["Grade"].ToString() == "A3" || dr["Grade"].ToString() == "E1" || dr["Grade"].ToString() == "E2" || dr["Grade"].ToString() == "E3")
                                                {
                                                    strEmpType = "FT-OFF";
                                                }
                                                else if (dr["Grade"].ToString().Substring(0, 1).ToUpper() == "T")
                                                {
                                                    strEmpType = "TRAINE";
                                                }
                                                else
                                                {
                                                    strEmpType = "FT-MGR";
                                                }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    //Checking whether Employee already exists in the legacy
                                                    mycommand = new SqlCommand("USP_EmpCreation_getEmpTypeBasedonDesig", mycon);
                                                    mycommand.CommandType = CommandType.StoredProcedure;
                                                    mycommand.Parameters.Add(new SqlParameter("@SAPDesig", dr["Designation"].ToString()));
                                                    SqlDataAdapter myAdapter2 = new SqlDataAdapter(mycommand);
                                                    mycommand.Connection.Open();
                                                    myAdapter2.Fill(ds, "getEmpTypeBasedonDesig");
                                                }
                                                catch (Exception ex)
                                                {
                                                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Checking whether Employee already exists in the legacy---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                }
                                                finally
                                                {
                                                    if (mycommand.Connection.State == ConnectionState.Open)
                                                        mycommand.Connection.Close();
                                                }

                                                if (ds.Tables["getEmpTypeBasedonDesig"].Rows.Count > 0)
                                                {
                                                    strEmpType = ds.Tables["getEmpTypeBasedonDesig"].Rows[0]["sapdesc"].ToString();
                                                }
                                                else
                                                {
                                                    if (dr["Grade"].ToString() == "O1" || dr["Grade"].ToString() == "O2" || dr["Grade"].ToString() == "A1" || dr["Grade"].ToString() == "A2" || dr["Grade"].ToString() == "A3" || dr["Grade"].ToString() == "E1" || dr["Grade"].ToString() == "E2" || dr["Grade"].ToString() == "E3")
                                                    {
                                                        strEmpType = "FT-OFF";
                                                    }
                                                    else if (dr["Grade"].ToString().Substring(0, 1).ToUpper() == "T")
                                                    {
                                                        strEmpType = "TRAINE";
                                                    }
                                                    else
                                                    {
                                                        strEmpType = "FT-MGR";
                                                    }
                                                }
                                            }

                                            //Employee Marital Status
                                            if (dr["Marstatus"].ToString() == "1")
                                            {
                                                strMaritalStatus = "M";
                                            }
                                            else
                                            {
                                                strMaritalStatus = "N";
                                            }

                                            //Date of Birth
                                            string strTempDbMon = dr["Dateofbirth"].ToString().Substring(5, 2);
                                            string strTempDbDay = dr["Dateofbirth"].ToString().Substring(8, 2);
                                            if (strTempDbMon.Length == 1)
                                            {
                                                strTempDbMon = "0" + strTempDbMon;
                                            }
                                            if (strTempDbDay.Length == 1)
                                            {
                                                strTempDbDay = "0" + strTempDbDay;
                                            }

                                            strDob = dr["Dateofbirth"].ToString().Substring(0, 4) + "-" + strTempDbMon + "-" + strTempDbDay;

                                            //Date of Joining
                                            string strTempDjMon = dr["Dateofjoining"].ToString().Substring(5, 2);
                                            string strTempDjDay = dr["Dateofjoining"].ToString().Substring(8, 2);
                                            if (strTempDjMon.Length == 1)
                                            {
                                                strTempDjMon = "0" + strTempDjMon;
                                            }
                                            if (strTempDjDay.Length == 1)
                                            {
                                                strTempDjDay = "0" + strTempDjDay;
                                            }
                                            strDoj = dr["Dateofjoining"].ToString().Substring(0, 4) + "-" + strTempDjMon + "-" + strTempDjDay;

                                            //Date of Confimation
                                            if (dr["empsubgroup"].ToString().ToUpper() == "T")
                                            {
                                                strDoc = "";
                                            }
                                            else
                                            {
                                                strDoc = strDoj;
                                            }
                                            //Employee Quarters
                                            if (dr["EmpQuarters"].ToString().ToUpper() == "X")
                                            {
                                                strQuarters = "1";
                                            }
                                            else
                                            {
                                                strQuarters = "0";
                                            }

                                            try
                                            {
                                                //Employee Bank Mode from another RFC(from Table)
                                                List<string> input2 = new List<string>();
                                                input2.Add("PA0009");
                                                input2.Add("PERNR EQ " + dr["EmpNo"].ToString());
                                                input2.Add("BANKL");
                                                XmlDocument xDoc2 = XMLSerializerBL.Serialize(input2, XMLSerializerBL.InputType.List);
                                                XmlNode xmlException2 = null;
                                                XmlElement xDocTable2 = (XmlElement)s.GetTableData(xDoc2, out xmlException2);
                                                List<string> SAPError2 = (List<string>)XMLSerializerBL.Deserialize(xmlException2.OuterXml, XMLSerializerBL.OutputType.List);

                                                if (SAPError2[0] == "1000")
                                                {
                                                    DataTable dt2 = (DataTable)XMLSerializerBL.Deserialize(xDocTable2.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                                    if (dt2.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow dr2 in dt2.Rows)
                                                        {
                                                            if (dr2["Bankmode"].ToString().ToUpper() == "CHEQUE")
                                                            {
                                                                strBankMode = "CHQ";
                                                            }
                                                            else if (dr2["Bankmode"].ToString().ToUpper() == "DD")
                                                            {
                                                                strBankMode = "DD";
                                                            }
                                                            else
                                                            {
                                                                strBankMode = "BANK";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //no details found in sap
                                                    }
                                                }
                                                else
                                                {
                                                    //sap failure Message
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Employee Bank Mode from another RFC(from Table)---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                            }
                                            //AddressDetails
                                            strEmpName = dr["Empname"].ToString().Replace("'", "");
                                            strAddress1 = dr["Address1"].ToString().Replace("'", "");
                                            strAddress2 = dr["Address2"].ToString().Replace("'", "");
                                            strAddress3 = dr["Address3"].ToString().Replace("'", "");
                                            strPostal = dr["Postal"].ToString().Replace("'", "");

                                            //Employee Location
                                            if ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC"))
                                            {
                                                strEmpLocation = "102";
                                            }
                                            else if ((dr["EmpPerArea"].ToString() == "3000") && (dr["EmpPayArea"].ToString() != "IG" || dr["EmpPayArea"].ToString() != "IC"))
                                            {
                                                strEmpLocation = dr["EmpSaploc"].ToString().Replace("'", ""); //dr["EmpPerSubArea"].ToString();
                                            }
                                            else if ((dr["EmpPerArea"].ToString() == "4000") && (dr["EmpPayArea"].ToString() == "IG" || dr["EmpPayArea"].ToString() == "IC"))
                                            {
                                                strEmpLocation = "101";
                                            }
                                            else if ((dr["EmpPerArea"].ToString() == "4000") && (dr["EmpPayArea"].ToString() != "IG" || dr["EmpPayArea"].ToString() != "IC"))
                                            {
                                                strEmpLocation = dr["EmpSaploc"].ToString().Replace("'", ""); //dr["EmpPerSubArea"].ToString();
                                            }
                                            else if (dr["EmpPerArea"].ToString() == "5000" && dr["EmpSaploc"].ToString() == "IGAP") //dr["EmpPerSubArea"].ToString();
                                            {
                                                strEmpLocation = "101";
                                            }
                                            else if (dr["EmpPerArea"].ToString() == "7000")
                                            {
                                                strEmpLocation = "104";
                                            }
                                            else if (dr["EmpPerArea"].ToString() == "5000" && dr["EmpSaploc"].ToString() != "IGAP") //dr["EmpPerSubArea"].ToString();
                                            {
                                                strEmpLocation = dr["EmpSaploc"].ToString(); //dr["EmpPerSubArea"].ToString();
                                            }
                                            else if ((dr["EmpPerArea"].ToString() == "1100") && (dr["EmpPayArea"].ToString() == "IO"))
                                            {
                                                strEmpLocation = "103";
                                            }
                                            //if ((dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "3000" || dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "1011") && (dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() == "IG" || dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() == "IC"))
                                            //    strEmpLocation = "102";
                                            //else if ((dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "3000") && (dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() != "IG" || dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() != "IC"))
                                            //    strEmpLocation = dr["EmpSaploc"].ToString().Replace("'", "");
                                            //else if ((dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "4000") && (dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() == "IG" || dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() == "IC"))
                                            //    strEmpLocation = "101";
                                            //else if ((dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "5000") && (dr["EmpSaploc"].ToString().Replace("'", "").Trim().ToUpper() == "IGAP"))
                                            //    strEmpLocation = "101";
                                            ////else if ((dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "4000") && (dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() != "IG" || dr["EmpPayArea"].ToString().Replace("'", "").Trim().ToUpper() != "IC"))
                                            ////    strEmpLocation = dr["EmpSaploc"].ToString().Replace("'", "");
                                            //else if ((dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "7000")) // for rajkot
                                            //    strEmpLocation = "104";
                                            else if (dr["EmpPerArea"].ToString().Replace("'", "").Trim().ToUpper() == "1000")
                                            {
                                                //added this if from empupdation.else part(is existing) not added from empupdation
                                                if (dr["EmpSaploc"].ToString() == "1003" && dr["EmpPayArea"].ToString() == "IL")
                                                {
                                                    strEmpLocation = dr["EmpSaploc"].ToString();
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        mycommand = new SqlCommand("USP_EmpCreation_getSAPPerArea", mycon);
                                                        mycommand.CommandType = CommandType.StoredProcedure;
                                                        mycommand.Parameters.Add(new SqlParameter("@SapPerArea", dr["EmpPerArea"].ToString()));
                                                        mycommand.Parameters.Add(new SqlParameter("@SapSubArea", dr["EmpPerSubArea"].ToString()));
                                                        SqlDataAdapter myAdapter3 = new SqlDataAdapter(mycommand);
                                                        mycommand.Connection.Open();
                                                        myAdapter3.Fill(ds, "getSAPPerArea");
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---USP_EmpCreation_getSAPPerArea---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                    }
                                                    finally
                                                    {
                                                        if (mycommand.Connection.State == ConnectionState.Open)
                                                            mycommand.Connection.Close();
                                                    }
                                                    if (ds.Tables["getSAPPerArea"].Rows.Count > 0)
                                                        strEmpLocation = ds.Tables["getSAPPerArea"].Rows[0]["Loc_Code"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    mycommand = new SqlCommand("USP_EmpCreation_getSAPPerArea", mycon);
                                                    mycommand.CommandType = CommandType.StoredProcedure;
                                                    mycommand.Parameters.Add(new SqlParameter("@SapPerArea", dr["EmpPerArea"].ToString()));
                                                    mycommand.Parameters.Add(new SqlParameter("@SapSubArea", dr["EmpPayArea"].ToString()));
                                                    SqlDataAdapter myAdapter4 = new SqlDataAdapter(mycommand);
                                                    mycommand.Connection.Open();
                                                    myAdapter4.Fill(ds, "getSAPPerArea");
                                                }
                                                catch (Exception ex)
                                                {
                                                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---USP_EmpCreation_getSAPPerArea---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                }
                                                finally
                                                {
                                                    if (mycommand.Connection.State == ConnectionState.Open)
                                                        mycommand.Connection.Close();
                                                }
                                                if (ds.Tables["getSAPPerArea"].Rows.Count > 0)
                                                    strEmpLocation = ds.Tables["getSAPPerArea"].Rows[0]["Loc_Code"].ToString();
                                            }

                                            strDesig = dr["Designation"].ToString().Replace("'", "");
                                            strDepartment = dr["Dept"].ToString().Replace("'", "").Substring(4, 4);
                                            strGrade = dr["Grade"].ToString().Replace("'", "");

                                            try
                                            {
                                                mycommand = new SqlCommand("USP_EmpCreation_getScaleCode", mycon);
                                                mycommand.CommandType = CommandType.StoredProcedure;
                                                mycommand.Parameters.Add(new SqlParameter("@GradeCode", strGrade));
                                                SqlDataAdapter myAdapter5 = new SqlDataAdapter(mycommand);
                                                mycommand.Connection.Open();
                                                myAdapter5.Fill(ds, "getScaleCode");
                                            }
                                            catch (Exception ex)
                                            {
                                                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---USP_EmpCreation_getScaleCode---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                            }
                                            finally
                                            {
                                                if (mycommand.Connection.State == ConnectionState.Open)
                                                    mycommand.Connection.Close();
                                            }
                                            if (ds.Tables["getScaleCode"].Rows.Count > 0)
                                                strScale = ds.Tables["getScaleCode"].Rows[0]["Scl_Code"].ToString();

                                            try
                                            {
                                                mycommand = new SqlCommand("USP_EMPLOYEEMASTER_TRANSACTIONS", mycon);
                                                mycommand.CommandType = CommandType.StoredProcedure;
                                                mycommand.Parameters.Add(new SqlParameter("@flag", "I"));
                                                mycommand.Parameters.Add(new SqlParameter("@EmpId", strEmpNo));
                                                mycommand.Parameters.Add(new SqlParameter("@Title", strTitle));
                                                mycommand.Parameters.Add(new SqlParameter("@FirstName", strEmpName));
                                                mycommand.Parameters.Add(new SqlParameter("@FatherName", strFather));
                                                mycommand.Parameters.Add(new SqlParameter("@BirthDate", strDob));
                                                mycommand.Parameters.Add(new SqlParameter("@JoinDate", strDoj));
                                                mycommand.Parameters.Add(new SqlParameter("@ConfirmedDate", strDoc));
                                                mycommand.Parameters.Add(new SqlParameter("@add1", strAddress1));
                                                mycommand.Parameters.Add(new SqlParameter("@add2", strAddress2));
                                                mycommand.Parameters.Add(new SqlParameter("@add3", strAddress3));
                                                mycommand.Parameters.Add(new SqlParameter("@PIN", strPostal));
                                                mycommand.Parameters.Add(new SqlParameter("@Married", strMaritalStatus));
                                                mycommand.Parameters.Add(new SqlParameter("@Gender", strSex));
                                                mycommand.Parameters.Add(new SqlParameter("@Emptype", strEmpType));
                                                mycommand.Parameters.Add(new SqlParameter("@DeptId", strDepartment));
                                                mycommand.Parameters.Add(new SqlParameter("@DesigId", strDesig));
                                                mycommand.Parameters.Add(new SqlParameter("@GradeId", strGrade));
                                                mycommand.Parameters.Add(new SqlParameter("@locationcode", strEmpLocation));
                                                mycommand.Parameters.Add(new SqlParameter("@scl_code", strScale));
                                                mycommand.Parameters.Add(new SqlParameter("@status", 1));
                                                mycommand.Connection.Open();
                                                mycommand.CommandTimeout = 800;
                                                mycommand.ExecuteNonQuery();
                                            }
                                            catch (Exception ex)
                                            {
                                                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---USP_EMPLOYEEMASTER_TRANSACTIONS---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                            }
                                            finally
                                            {
                                                if (mycommand.Connection.State == ConnectionState.Open)
                                                    mycommand.Connection.Close();
                                            }

                                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            //  Temporarily saving to find out the location issue (for 1st day it is HO and next day it is changing to other loc)
                                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            try
                                            {
                                                mycommand = new SqlCommand("USP_EMPLOYEEMASTER_TempSave", mycon);
                                                mycommand.CommandType = CommandType.StoredProcedure;
                                                mycommand.Parameters.Add(new SqlParameter("@EmpId", strEmpNo));
                                                mycommand.Parameters.Add(new SqlParameter("@EmpPerArea", dr["EmpPerArea"].ToString().Replace("'", "").Trim()));
                                                mycommand.Parameters.Add(new SqlParameter("@EmpPayArea", dr["EmpPayArea"].ToString().Replace("'", "").Trim()));
                                                mycommand.Parameters.Add(new SqlParameter("@EmpSaploc", dr["EmpSaploc"].ToString().Replace("'", "").Trim()));
                                                mycommand.Parameters.Add(new SqlParameter("@locationcode", strEmpLocation));
                                                mycommand.Parameters.Add(new SqlParameter("@Flg", "EC"));
                                                mycommand.Connection.Open();
                                                mycommand.ExecuteNonQuery();
                                            }
                                            catch (Exception ex)
                                            {
                                                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---USP_EMPLOYEEMASTER_TempSave---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                            }
                                            finally
                                            {
                                                if (mycommand.Connection.State == ConnectionState.Open)
                                                    mycommand.Connection.Close();
                                            }
                                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            //  Temporarily saving to find out the location issue (for 1st day it is HO and next day it is changing to other loc)
                                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        }
                                        else
                                        {
                                            //Employee already Exists
                                        }
                                    }
                                }

                                else
                                {
                                    //no details found in  sap
                                }
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                //                            Start Employee Wise Basic Details Upload                                      //
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                try
                                {
                                    WriteLog(0, "Start Employee Wise Basic Details Upload " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                    if (ds != null && ds.Tables.Count > 0)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            //checking if date is 8th or not, if 8th then only downloading the data else no
                                            if (ds.Tables[0].Rows[0]["CDay"].ToString() == "12")
                                            {
                                                WriteLog(0, "Capturing employee data from SAP " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                List<string> input3 = new List<string>();
                                                input3.Add(ds.Tables[0].Rows[0]["BasicFrom"].ToString()); //passing from date and to date from when basic has to be downloaded
                                                input3.Add(ds.Tables[0].Rows[0]["Basicto"].ToString());
                                                XmlDocument xDoc3 = XMLSerializerBL.Serialize(input3, XMLSerializerBL.InputType.List);
                                                XmlNode xmlException3 = null;
                                                s.Timeout = System.Threading.Timeout.Infinite;
                                                XmlElement xDocTable3 = (XmlElement)s.R3getMonthwiseBasic(xDoc3, out xmlException3);
                                                List<string> SAPError3 = (List<string>)XMLSerializerBL.Deserialize(xmlException3.OuterXml, XMLSerializerBL.OutputType.List);
                                                decimal stramount = 0;
                                                if (SAPError3[0] == "1000")
                                                {
                                                    DataTable dtfinal = new DataTable("EmpmonthwiseDetails");

                                                    dtfinal.Columns.Add("EmpId");
                                                    dtfinal.Columns.Add("pmonth");
                                                    dtfinal.Columns.Add("pyear");
                                                    dtfinal.Columns.Add("fld_code");
                                                    dtfinal.Columns.Add("fld_amt");
                                                    DataRow drfinal = dtfinal.NewRow();
                                                    DataTable dt2 = (DataTable)XMLSerializerBL.Deserialize(xDocTable3.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                                    WriteLog(0, "Captured employee data from SAP " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                    if (dt2.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow dr2 in dt2.Rows)
                                                        {
                                                            DataRow[] drcheck = dtfinal.Select("empid ='" + dr2["empId"].ToString().Trim().Substring(2, 6) + "'  and pyear ='" + dr2["monthyear"].ToString().Trim().Substring(0, 4) + "' and pmonth ='" + dr2["monthyear"].ToString().Trim().Substring(5, 2) + "' and fld_code ='" + dr2["SAPWage"].ToString().Trim() + dr2["SalaryType"].ToString().Trim() + "'");

                                                            if (drcheck.Length > 0)
                                                            {
                                                                WriteLog(0, "if recode is there Preparing table for Employee Wise Basic Details " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                                if (dr2["SalaryType"].ToString().Trim() == "PAY")
                                                                {
                                                                    stramount = Convert.ToDecimal(drcheck[0]["fld_amt"].ToString()) + Convert.ToDecimal(dr2["amount"].ToString());
                                                                }
                                                                else
                                                                {
                                                                    stramount = Convert.ToDecimal(dr2["amount"].ToString());
                                                                }
                                                                dtfinal.Rows.Remove(drcheck[0]);
                                                            }
                                                            else
                                                            {
                                                                WriteLog(0, "Preparing table for Employee Wise Basic Details " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                                stramount = Convert.ToDecimal(dr2["amount"].ToString());
                                                                drfinal = dtfinal.NewRow();
                                                                drfinal["EmpId"] = dr2["empId"].ToString().Trim().Substring(2, 6);
                                                                drfinal["pmonth"] = dr2["monthyear"].ToString().Trim().Substring(5, 2);
                                                                drfinal["pyear"] = dr2["monthyear"].ToString().Trim().Substring(0, 4);
                                                                drfinal["fld_code"] = dr2["SAPWage"].ToString().Trim() + dr2["SalaryType"].ToString().Trim();
                                                                drfinal["fld_amt"] = stramount;
                                                                dtfinal.Rows.Add(drfinal);
                                                                dtfinal.AcceptChanges();
                                                                WriteLog(0, " table dtfinal count " + dtfinal.Rows.Count.ToString() + "   " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                            }
                                                        }

                                                        if (dtfinal != null && dtfinal.Rows.Count > 0)
                                                        {
                                                            StringWriter SWFinal = new StringWriter();
                                                            dtfinal.WriteXml(SWFinal);
                                                            string empwiseXML = SWFinal.ToString();
                                                            mycommand = new SqlCommand("USP_EMP_MONTHWISEBASICS_T", mycon);
                                                            mycommand.CommandType = CommandType.StoredProcedure;
                                                            mycommand.Parameters.Add(new SqlParameter("@frmdate", ds.Tables[0].Rows[0]["BasicFrom"].ToString())); //passing from date and to date from when basic has to be downloaded
                                                            mycommand.Parameters.Add(new SqlParameter("@todate", ds.Tables[0].Rows[0]["Basicto"].ToString()));
                                                            mycommand.Parameters.Add(new SqlParameter("@MonthwiseTable", SqlDbType.Xml));
                                                            mycommand.Parameters["@MonthwiseTable"].Value = empwiseXML.ToString();
                                                            mycommand.Connection.Open();
                                                            mycommand.ExecuteNonQuery();
                                                            mycommand.Connection.Close();
                                                            WriteLog(0, "Employee Wise Basic Details inserted in Database " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    WriteLog(1, "Exception :" + SAPError3[1] + "---SAPEmpCreation---EmpMonthWiseBasicUpload---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                                }
                                            }
                                        }
                                    }
                                    WriteLog(0, "End Employee Wise Basic Details Upload " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---EmpMonthWiseBasicUpload---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                }
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                //                           End of Employee Wise Basic Details Upload                                      //
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                //                                      Start of LOP Details Upload                                         //
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                try
                                {
                                    ds.Tables.Clear();
                                    mycommand = new SqlCommand("USP_F_GetFinYrDts", mycon);
                                    mycommand.CommandType = CommandType.StoredProcedure;
                                    SqlDataAdapter myAdapter6 = new SqlDataAdapter(mycommand);
                                    mycommand.Connection.Open();
                                    myAdapter6.Fill(ds, "getFinancialYrs");
                                    mycommand.Connection.Close();
                                    if (ds.Tables[1].Rows.Count > 0)
                                    {
                                        List<string> inputLOP = new List<string>();
                                        inputLOP.Add("PA2001");
                                        inputLOP.Add("ENDDA GT '" + ds.Tables[1].Rows[0]["fromyear"].ToString() + "' AND BEGDA LE '" + ds.Tables[1].Rows[0]["endyear"].ToString() + "' AND AWART EQ 'LOP'");
                                        inputLOP.Add("PERNR|STDAZ|ABWTG|BEGDA|ENDDA|AWART");
                                        XmlDocument xDocLop = XMLSerializerBL.Serialize(inputLOP, XMLSerializerBL.InputType.List);
                                        XmlNode xmlExceptionLop = null;
                                        XmlElement xDocTableLop = (XmlElement)s.GetTableData(xDocLop, out xmlExceptionLop);
                                        List<string> SAPErrorLop = (List<string>)XMLSerializerBL.Deserialize(xmlExceptionLop.OuterXml, XMLSerializerBL.OutputType.List);

                                        if (SAPErrorLop[0] == "1000")
                                        {
                                            DataTable dtLop = (DataTable)XMLSerializerBL.Deserialize(xDocTableLop.OuterXml, XMLSerializerBL.OutputType.DataTable);
                                            DataTable dtfinal = new DataTable("SapLopUpdation");
                                            DataRow drfinal = dtfinal.NewRow();
                                            dtfinal.Columns.Add("EmpId");
                                            dtfinal.Columns.Add("fromdate");
                                            dtfinal.Columns.Add("todate");
                                            dtfinal.Columns.Add("daysdiff");
                                            if (dtLop.Rows.Count > 0)
                                            {
                                                foreach (DataRow dr in dtLop.Rows)
                                                {
                                                    drfinal = dtfinal.NewRow();
                                                    drfinal["EmpId"] = dr["PERNR"].ToString().Substring(2, 6);
                                                    drfinal["fromdate"] = dr["BEGDA"].ToString();
                                                    drfinal["todate"] = dr["ENDDA"].ToString();
                                                    if (dr["AWART"].ToString().Trim() == "HLOP")
                                                    {
                                                        drfinal["daysdiff"] = 0.5;
                                                    }
                                                    else
                                                    {
                                                        dr["BEGDA"] = dr["BEGDA"].ToString().Substring(0, 4) + "-" + dr["BEGDA"].ToString().Substring(4, 2) + "-" + dr["BEGDA"].ToString().Substring(6, 2);
                                                        dr["ENDDA"] = dr["ENDDA"].ToString().Substring(0, 4) + "-" + dr["ENDDA"].ToString().Substring(4, 2) + "-" + dr["ENDDA"].ToString().Substring(6, 2);
                                                        drfinal["daysdiff"] = Convert.ToString((DateDiff(Convert.ToDateTime(dr["BEGDA"].ToString()), Convert.ToDateTime(dr["ENDDA"].ToString()), DatePart.Days)) + 1);
                                                    }
                                                    dtfinal.Rows.Add(drfinal);
                                                }

                                                if (dtfinal != null && dtfinal.Rows.Count > 0)
                                                {
                                                    StringWriter SWFinal = new StringWriter();
                                                    dtfinal.WriteXml(SWFinal);
                                                    string CCXML = SWFinal.ToString();
                                                    mycommand = new SqlCommand("[USP_EmpLopDetails]", mycon);
                                                    mycommand.CommandType = CommandType.StoredProcedure;
                                                    mycommand.Parameters.Add(new SqlParameter("@LopTable", SqlDbType.Xml));
                                                    mycommand.Parameters["@LopTable"].Value = CCXML.ToString();
                                                    mycommand.Connection.Open();
                                                    mycommand.ExecuteNonQuery();
                                                    mycommand.Connection.Close();
                                                }
                                            }
                                        }
                                    }
                                    else { }
                                }
                                catch (Exception ex)
                                {
                                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---SAPLOPDetailsUpdation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                                }
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                //                                      End of LOP Details Upload                                           //
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            }
                            else
                            {
                                // sap failure Message 
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Passing Maximum Employee Number to SAP RFC and Retrieving Details of the Employee ---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                        }
                    }

                }
                catch (Exception ex)
                {
                    WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---After SAPEmpCreation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }

                SAPService ASCon = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //                              Updating Status as zero for locked employees                                //
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                List<string> inputLocStat = new List<string>();
                inputLocStat.Add("PA0003");
                inputLocStat.Add("ABRSP EQ 'X'");
                inputLocStat.Add("PERNR|AEDTM");
                //inputLocStat.Add("AEDTM"); // Added by keerthi 14.04.2012
                XmlDocument xDocLocStat = XMLSerializerBL.Serialize(inputLocStat, XMLSerializerBL.InputType.List);
                XmlNode xmlExceptionLocStat = null;
                XmlElement xDocTableLocStat = (XmlElement)ASCon.GetTableData(xDocLocStat, out xmlExceptionLocStat);
                List<string> SAPErrorLocStat = (List<string>)XMLSerializerBL.Deserialize(xmlExceptionLocStat.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPErrorLocStat[0] == "1000")
                {
                    DataTable dtLocStat = (DataTable)XMLSerializerBL.Deserialize(xDocTableLocStat.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    dtLocStat.TableName = "TblEmpId";
                    try
                    {
                        mycommand = new SqlCommand("USP_EMPLOYEEMASTER_LOCKSTATUS", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        if (dtLocStat.Rows.Count > 0)
                        {
                            StringWriter sbEmpId = new StringWriter();
                            dtLocStat.WriteXml(sbEmpId);
                            mycommand.Parameters.Add(new SqlParameter("@flag", 'L'));
                            mycommand.Parameters.Add("@EmpId", SqlDbType.Xml);
                            mycommand.Parameters["@EmpId"].Value = sbEmpId.ToString();
                        }
                        else
                        {
                            mycommand.Parameters.Add(new SqlParameter("@flag", 'U'));
                            mycommand.Parameters.Add(new SqlParameter("@EmpId", ""));
                        }
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Updating Status as zero for locked employees---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    }
                    finally
                    {
                        if (mycommand.Connection.State == ConnectionState.Open)
                            mycommand.Connection.Close();
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //                       End of Updating Status as zero for locked employees                                //
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////                                  Start of Abhay Shopee User Creation                                     //
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //SqlConnection myAScon = new SqlConnection("Data Source=192.168.1.15;Initial Catalog=NewAS; uid=iildb; pwd=iil@123;");
                SqlConnection myAScon = new SqlConnection("Data Source=120.138.9.18;Initial Catalog=NewAS; uid=abhay; pwd=@qh@y@i!l#123;");
                List<string> ASinput = new List<string>();
                ASinput.Add("20150401");
                ASinput.Add("103");
                XmlDocument ASxDoc = XMLSerializerBL.Serialize(ASinput, XMLSerializerBL.InputType.List);
                XmlNode ASxmlException = null;
                XmlElement ASxDocTable = (XmlElement)ASCon.getASUserCreation(ASxDoc, out ASxmlException);
                List<string> ASSAPError = (List<string>)XMLSerializerBL.Deserialize(ASxmlException.OuterXml, XMLSerializerBL.OutputType.List);

                if (ASSAPError[0] == "1000")
                {
                    DataTable dtAS = (DataTable)XMLSerializerBL.Deserialize(ASxDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    if (dtAS.Rows.Count > 0)
                    {
                        foreach (DataRow drAS in dtAS.Rows)
                        {
                            try
                            {
                                mycommand = new SqlCommand("Usp_AS_UserCreation_Transactions", myAScon);
                                mycommand.CommandType = CommandType.StoredProcedure;
                                mycommand.Parameters.Add(new SqlParameter("@LocId", Convert.ToString(drAS["CustomerNo"])));
                                mycommand.Parameters.Add(new SqlParameter("@LocDesc", Convert.ToString(drAS["LocDesc"])));
                                mycommand.Parameters.Add(new SqlParameter("@Address1", Convert.ToString(drAS["Address2"]) + ", " + Convert.ToString(drAS["Address3"]) + ", " + Convert.ToString(drAS["Address1"])));
                                mycommand.Parameters.Add(new SqlParameter("@Address2", Convert.ToString(drAS["Address2"]) + ", " + Convert.ToString(drAS["Address3"]) + ", " + Convert.ToString(drAS["Address1"])));
                                mycommand.Parameters.Add(new SqlParameter("@PinCode", Convert.ToString(drAS["PostalCode"])));
                                mycommand.Parameters.Add(new SqlParameter("@LandLine", Convert.ToString(drAS["TelePhone1"])));
                                mycommand.Parameters.Add(new SqlParameter("@Mobile", Convert.ToString(drAS["TelePhone2"])));
                                mycommand.Parameters.Add(new SqlParameter("@Fax", Convert.ToString(drAS["FaxNo"])));
                                mycommand.Parameters.Add(new SqlParameter("@ContactPerson", Convert.ToString(drAS["Name"])));
                                mycommand.Parameters.Add(new SqlParameter("@Sales_tax_no", Convert.ToString(drAS["LocalSalesTaxNo"])));
                                mycommand.Parameters.Add(new SqlParameter("@Central_tax_no", Convert.ToString(drAS["CntrlSalesTaxNo"])));
                                mycommand.Parameters.Add(new SqlParameter("@Drug_L_No1", Convert.ToString(drAS["DrugLic1"])));
                                mycommand.Parameters.Add(new SqlParameter("@Drug_L_No2", Convert.ToString(drAS["DrugLic2"])));
                                mycommand.Parameters.Add(new SqlParameter("@VatApplicable", "1"));
                                mycommand.Parameters.Add(new SqlParameter("@CandFLocation", Convert.ToString(drAS["SalesOffice"])));
                                //mycommand.Parameters.Add(new SqlParameter("@Title", Convert.ToString(drAS["Title"])));
                                //mycommand.Parameters.Add(new SqlParameter("@SalesGrp", Convert.ToString(drAS["SalesGrp"])));
                                mycommand.Parameters.Add(new SqlParameter("@Password", "IkAzdqzuhfDDwXed3FDcxb5WCdv5JTniDHMWv8WFg74="));
                                mycommand.Connection.Open();
                                mycommand.ExecuteNonQuery();

                                //mycommand1 = new SqlCommand("USP_F_AS_PositinCodes", mycon);
                                //mycommand1.CommandType = CommandType.StoredProcedure;
                                //mycommand1.Parameters.Add(new SqlParameter("@ASCode", Convert.ToString(drAS["CustomerNo"])));
                                //mycommand1.Parameters.Add(new SqlParameter("@ASName", Convert.ToString(drAS["LocDesc"])));
                                //mycommand1.Connection.Open();
                                //mycommand1.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {

                                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---Abhay Shoppe User Creation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                            }
                            finally
                            {
                                if (mycommand.Connection.State == ConnectionState.Open)
                                    mycommand.Connection.Close();
                            }
                        }

                        if (dtAS.Rows.Count > 0)
                        {
                            dtAS.TableName = "ASData";
                            StringWriter sbEmpId = new StringWriter();
                            dtAS.WriteXml(sbEmpId);
                            mycommand1 = new SqlCommand("USP_F_AS_PositinCodes", mycon);
                            mycommand1.CommandType = CommandType.StoredProcedure;
                            mycommand1.CommandTimeout = 100000;
                            mycommand1.Parameters.Add("@ASId", SqlDbType.Xml);
                            mycommand1.Parameters["@ASId"].Value = sbEmpId.ToString();
                            mycommand1.Connection.Open();
                            mycommand1.ExecuteNonQuery();
                            mycommand1.Connection.Close();
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////                                    End of Abhay Shopee User Creation                                     //
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---SAPEmpCreation---SAPEmpCreation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void FillItemMaster()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                SqlCommand mycommand = new SqlCommand();
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);

                List<string> input = new List<string>();
                input.Add("");
                input.Add("");
                input.Add("");
                input.Add("");
                XmlDocument xDoc1 = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlexception1 = null;
                XmlElement xDocTable1 = (XmlElement)s.Readmaterial(xDoc1, out xmlexception1);
                List<string> SAPError1 = (List<string>)XMLSerializerBL.Deserialize(xmlexception1.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPError1[0] == "1000")
                {
                    DataSet ds1 = (DataSet)XMLSerializerBL.Deserialize(xDocTable1.OuterXml, XMLSerializerBL.OutputType.DataSet);
                    DataTable dtitemmaster = ds1.Tables[0].DefaultView.ToTable( /*distinct*/ true);
                    DataTable dtitemmaster1 = ds1.Tables[1].DefaultView.ToTable(/*distinct*/ true);

                    StringWriter SWIndent1 = new StringWriter();
                    dtitemmaster.TableName = "IndentItemMasterfromMRP";
                    StringWriter SWIndent2 = new StringWriter();
                    dtitemmaster1.TableName = "IndentItemMaster";
                    //foreach (DataRow dr1 in dtitemmaster.Rows)
                    //{
                    //    Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                    //    dr1["MatDesc"] = r.Replace(dr1["Matdesc"].ToString(), String.Empty);
                    //    dtitemmaster.AcceptChanges();
                    //}
                    foreach (DataRow dr1 in dtitemmaster.Rows)
                    {
                        // Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled); 
                        //dr1["MatDesc"] = r.Replace(dr1["Matdesc"].ToString(), String.Empty); 
                        string e = dr1["Matdesc"].ToString();
                        e.Trim('\'');
                        dr1["MatDesc"] = e;
                        dtitemmaster.AcceptChanges();
                    }
                    dtitemmaster.WriteXml(SWIndent1);
                    dtitemmaster1.WriteXml(SWIndent2);

                    mycommand = new SqlCommand("USP_Indent_InsertNewItem", mycon);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.Parameters.Add(new SqlParameter("@IndNewItemdetails", SqlDbType.Xml));
                    mycommand.Parameters["@IndNewItemdetails"].Value = SWIndent1.ToString();
                    mycommand.Parameters.Add(new SqlParameter("@IndNewItemdetails1", SqlDbType.Xml));
                    mycommand.Parameters["@IndNewItemdetails1"].Value = SWIndent2.ToString();
                    mycommand.CommandTimeout = 20000;
                    mycommand.Connection.Open();
                    mycommand.ExecuteNonQuery();
                    mycommand.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---FillItemMaster---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void SAPPlantUpdation()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                SAPService Con = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                SqlCommand mycommand = new SqlCommand();

                List<string> inputCC = new List<string>();
                inputCC.Add("T001W");
                inputCC.Add("");
                inputCC.Add("WERKS|NAME1|VKORG");
                XmlDocument xDocLocStat = XMLSerializerBL.Serialize(inputCC, XMLSerializerBL.InputType.List);
                XmlNode xmlExceptionLocStat = null;
                XmlElement xDocTableLocStat = (XmlElement)Con.GetTableData(xDocLocStat, out xmlExceptionLocStat);
                List<string> SAPErrorLocStat = (List<string>)XMLSerializerBL.Deserialize(xmlExceptionLocStat.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPErrorLocStat[0] == "1000")
                {
                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTableLocStat.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    if (dt.Rows.Count > 0)
                    {
                        dt.TableName = "Data";
                        StringWriter SWFinal = new StringWriter();
                        dt.WriteXml(SWFinal);
                        string CCXML = SWFinal.ToString();
                        mycommand = new SqlCommand("USP_PlntUpd_T", mycon);
                        mycommand.CommandType = CommandType.StoredProcedure;
                        mycommand.Parameters.Add(new SqlParameter("@CCTable", SqlDbType.Xml));
                        mycommand.Parameters["@CCTable"].Value = CCXML.ToString();
                        mycommand.Connection.Open();
                        mycommand.ExecuteNonQuery();
                        mycommand.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---SAPPlantUpdation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void SAPCostCenterUpdation()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
                SAPService Con = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                SqlCommand mycommand = new SqlCommand();

                List<string> inputCC = new List<string>();
                inputCC.Add("CSKT");
                inputCC.Add("KOKRS EQ '1000'");
                inputCC.Add("KOSTL|KTEXT|LTEXT|MCTXT");
                XmlDocument xDocLocStat = XMLSerializerBL.Serialize(inputCC, XMLSerializerBL.InputType.List);
                XmlNode xmlExceptionLocStat = null;
                XmlElement xDocTableLocStat = (XmlElement)Con.GetTableData(xDocLocStat, out xmlExceptionLocStat);
                List<string> SAPErrorLocStat = (List<string>)XMLSerializerBL.Deserialize(xmlExceptionLocStat.OuterXml, XMLSerializerBL.OutputType.List);

                if (SAPErrorLocStat[0] == "1000")
                {
                    DataTable dtfinal = new DataTable("CostCenterUpdation");
                    DataRow drfinal = dtfinal.NewRow();
                    dtfinal.Columns.Add("CostCenterId");
                    dtfinal.Columns.Add("CostCenterDesc");
                    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTableLocStat.OuterXml, XMLSerializerBL.OutputType.DataTable);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            drfinal = dtfinal.NewRow();
                            if (dr["Text1"].ToString() != "NOT TO USE" || dr["Text2"].ToString() != "NOT TO USE")
                            {
                                drfinal["CostCenterId"] = dr["CostCenterCode"].ToString().Trim();
                                drfinal["CostCenterDesc"] = dr["CostCenterName"].ToString().Trim();
                                dtfinal.Rows.Add(drfinal);
                            }
                        }
                        if (dtfinal != null && dtfinal.Rows.Count > 0)
                        {
                            StringWriter SWFinal = new StringWriter();
                            dtfinal.WriteXml(SWFinal);
                            string CCXML = SWFinal.ToString();
                            mycommand = new SqlCommand("USP_CCUpd_T", mycon);
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Parameters.Add(new SqlParameter("@CCTable", SqlDbType.Xml));
                            mycommand.Parameters["@CCTable"].Value = CCXML.ToString();
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            mycommand.Connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---SAPCostCenterUpdation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void MktgTrnConfMail()
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                DataSet ds = new DataSet();
                SqlCommand mycommand = new SqlCommand("USP_MktgTraineeConf_SendMail", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "getMktgTrnConfMail");
                mycommand.Connection.Close();

                if (ds.Tables["getMktgTrnConfMail"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables["getMktgTrnConfMail"].Rows)
                    {
                        SendMail(Convert.ToString(dr["ToEmail"]), Convert.ToString(dr["Subject"]), Convert.ToString(dr["Body"]), "0", Convert.ToString(dr["FromEmail"]), Convert.ToString(dr["CCEmail"]));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---MktgTrnConfMail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void SendingMailToTraineeForDocuments()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlDataAdapter da = new SqlDataAdapter("USP_TraineDoc_MailStatus_GetTrainee", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string Empid = ds.Tables[0].Rows[i]["Empid"].ToString();
                        string Name = ds.Tables[0].Rows[i]["EmpName"].ToString();
                        string ToEmail = ds.Tables[0].Rows[i]["ToEmail"].ToString();
                        string CCEmail = ds.Tables[0].Rows[i]["CCEmail"].ToString();// +";MarketingHR@indimmune.com"; 
                        string bodyformat = MailBodyForTraineeDoc(Empid, Name);

                        SendMail(ToEmail, "Original Documents to be Returned.", bodyformat, "0", "MarketingHR@indimmune.com", CCEmail);

                        SqlCommand cmd = new SqlCommand("USP_TraineDoc_Insert", con); con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Empid", SqlDbType.VarChar, 6);
                        cmd.Parameters["@Empid"].Value = Empid;
                        cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 80);
                        cmd.Parameters["@MailTo"].Value = ToEmail;
                        cmd.Parameters.Add("@Ccmail", SqlDbType.VarChar);
                        cmd.Parameters["@Ccmail"].Value = CCEmail;

                        int j = cmd.ExecuteNonQuery(); con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---SendingMailToTraineeForDocuments---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void SendingMailToTraineeForConfirm()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlDataAdapter da = new SqlDataAdapter("USP_TraineConfirm_MailStatus_GetTrainee", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string Empid = ds.Tables[0].Rows[i]["Empid"].ToString();
                        string Name = ds.Tables[0].Rows[i]["EmpName"].ToString();
                        string ToEmail = ds.Tables[0].Rows[i]["ToEmail"].ToString();
                        string CCEmail = ds.Tables[0].Rows[i]["CCEmail"].ToString();// +";MarketingHR@indimmune.com"; 
                        string flag = ds.Tables[0].Rows[i]["flag"].ToString();
                        string bodyformat = MailBodyForTraineeConfirm(Empid, Name, flag);

                        SendMail(ToEmail, "Congratulations on successfully completing your training period!!!", bodyformat, "0", "MarketingHR@indimmune.com", CCEmail);

                        SqlCommand cmd = new SqlCommand("USP_TraineConfirm_Insert", con); con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Empid", SqlDbType.VarChar, 6);
                        cmd.Parameters["@Empid"].Value = Empid;
                        cmd.Parameters.Add("@MailTo", SqlDbType.VarChar, 80);
                        cmd.Parameters["@MailTo"].Value = ToEmail;
                        cmd.Parameters.Add("@Ccmail", SqlDbType.VarChar);
                        cmd.Parameters["@Ccmail"].Value = CCEmail;

                        int j = cmd.ExecuteNonQuery(); con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---SendingMailToTraineeForConfirm---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }

        }

        private void SaveReadSMSIntoTmpTables()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
            SqlCommand mycommand = new SqlCommand();
            try
            {
                mycommand = new SqlCommand("USP_ReadSMSIntoTmpTables_Insert", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.Connection.Open();
                mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---SaveReadSMSIntoTmpTables---EmpCreation---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        private DataTable Filldtcols()
        {
            DataColumn dc;
            dc = new DataColumn("EmpId");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("DisChannel");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("Division");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("SalesOffice");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("SalesGroup");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("CustGroup");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("Title");
            dtItems.Columns.Add(dc);
            dc = new DataColumn("EFlag");
            dtItems.Columns.Add(dc);
            return dtItems;
        }
        private void sendWeeklyMail()
        {
            string repOff = "";
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
                SqlCommand mycommand = new SqlCommand();
                StringBuilder sb = new StringBuilder();
                DataSet ds = new DataSet();

                mycommand = new SqlCommand("USP_Employee_GetAllRepOff", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter myRepOff = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myRepOff.Fill(ds, "RepOff");
                mycommand.Connection.Close();

                /* code added by sasidhar on 26th may 12, for sending mail when user select option Lastweek mail option  */
                DateTime AFromDate; DateTime AToDate; string FromDate; string ToDate;
                //if (ViewState["LastWeekStatus"].ToString() != "0")
                if (LastWeekStatus != "0")
                {
                    //AFromDate = Convert.ToDateTime(ViewState["StatusDate"].ToString());
                    AFromDate = Convert.ToDateTime(StatusDate);
                    AToDate = AFromDate.AddDays(5);
                    FromDate = AFromDate.ToShortDateString();
                    ToDate = AToDate.ToShortDateString();
                }
                else
                {
                    AFromDate = ConvertStringToDate(ds.Tables["RepOff"].Rows[0]["frmdate"].ToString());    //ds.Tables["RepOff"].Rows[0]["afrmdate"].ToString();   change
                    AToDate = ConvertStringToDate(ds.Tables["RepOff"].Rows[0]["todate"].ToString());    //ds.Tables["RepOff"].Rows[0]["atodate"].ToString();    change
                    FromDate = ds.Tables["RepOff"].Rows[0]["frmdate"].ToString();    //ds.Tables["RepOff"].Rows[0]["frmdate"].ToString();    change
                    ToDate = ds.Tables["RepOff"].Rows[0]["todate"].ToString();    //ds.Tables["RepOff"].Rows[0]["todate"].ToString();     change
                }

                /* code end here */

                string EmpId = "0000";
                string strsubject = "";

                foreach (DataRow drRepOff in ds.Tables["RepOff"].Rows)
                {
                    repOff = drRepOff["EmpId"].ToString();
                    mycommand = new SqlCommand("USP_Schedule_WklyAttnRptMail", mycon);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.Parameters.Add(new SqlParameter("@MgrId", drRepOff["EmpId"].ToString())); //drRepOff["EmpId"].ToString()    change
                    // mycommand.Parameters.Add(new SqlParameter("@FromDate", AFromDate));
                    //if (ViewState["LastWeekStatus"].ToString() != "0")
                    if (LastWeekStatus != "0")
                    {
                        DateTime dt = AFromDate.AddDays(-1);
                        mycommand.Parameters.Add(new SqlParameter("@FromDate", dt));
                    }
                    else
                    {
                        mycommand.Parameters.Add(new SqlParameter("@FromDate", AFromDate));
                    }


                    mycommand.Parameters.Add(new SqlParameter("@ToDate", AToDate));
                    SqlDataAdapter myWklyAttnRpt = new SqlDataAdapter(mycommand);
                    mycommand.CommandTimeout = 800;
                    mycommand.Connection.Open();
                    myWklyAttnRpt.Fill(ds, "WklyAttnRpt");
                    mycommand.Connection.Close();

                    if (ds.Tables["WklyAttnRpt"].Rows.Count > 0)
                    {
                        //sb.Append("<body style='background-image:url(http://192.168.2.10/images/page_bg.gif)'>");
                        sb.Append("<body>");
                        //sb.Append("<center><b>INDIAN IMMUNOLOGICALS LIMITED</b><br><br>");
                        //sb.AppendLine();
                        sb.AppendLine();
                        sb.Append("<center><b>Attendance Report for the period of " + FromDate + "--" + ToDate + "</b></center><br>");
                        sb.AppendLine();
                        sb.AppendLine();
                        sb.Append("<b>HOD Name&nbsp;&nbsp;:&nbsp;&nbsp;</b>" + drRepOff["EmpId"].ToString() + "--" + drRepOff["EmpName"].ToString() + "<br>");
                        sb.AppendLine();
                        sb.Append("<b>Designation&nbsp;:&nbsp;&nbsp;</b>" + drRepOff["DesigName"].ToString() + "<br><hr><br>");

                        sb.Append("<center><table cellpadding=5 style='border-width:thin;font-size:12' border=1><tr><td><b>EmpId</b></td><td><b>Employee Name</b></td><td><b>Designation</b></td>");
                        for (int i = 0; i < 6; i++)
                        {
                            sb.Append("<td><b>" + AFromDate.AddDays(i).Day.ToString("00") + "/" + AFromDate.AddDays(i).Month.ToString("00") + "/" + AFromDate.AddDays(i).Year + "<br> Status </b></td>");
                            sb.Append("<td><b>" + AFromDate.AddDays(i).Day.ToString("00") + "/" + AFromDate.AddDays(i).Month.ToString("00") + "/" + AFromDate.AddDays(i).Year + "<br> LateMin</b> </td>");
                        }
                        sb.Append("</tr>");
                        foreach (DataRow drWklyAttnRpt in ds.Tables["WklyAttnRpt"].Rows)
                        {
                            if (EmpId != drWklyAttnRpt["EmpId"].ToString())
                            {
                                if (EmpId != "0000") { sb.Append("</tr>"); }
                                sb.Append("<tr><td>" + drWklyAttnRpt["EmpId"].ToString() + "</td><td>" + drWklyAttnRpt["FirstName"].ToString() + "</td><td>" + drWklyAttnRpt["Desig"].ToString() + "</td>");
                            }

                            EmpId = drWklyAttnRpt["EmpId"].ToString();
                            if ((drWklyAttnRpt["AttendStatus"].ToString() == "AX") || (drWklyAttnRpt["AttendStatus"].ToString() == "XA") || (drWklyAttnRpt["AttendStatus"].ToString() == "AA"))
                            {
                                sb.Append("<td><font color=red>" + drWklyAttnRpt["AttendStatus"].ToString() + "</font></td>");
                            }
                            else
                            {
                                sb.Append("<td>" + drWklyAttnRpt["AttendStatus"].ToString() + "</td>");
                            }
                            if (drWklyAttnRpt["LateHrs"].ToString() == "-")
                            {
                                sb.Append("<td>" + drWklyAttnRpt["LateHrs"].ToString() + "</td>");
                            }
                            else
                            {
                                sb.Append("<td><font color=red>" + drWklyAttnRpt["LateHrs"].ToString() + "</font></td>");
                            }
                        }
                        sb.Append("</tr></table></center><br><hr>");
                        //sb.Append("<font color=red>Note: &nbsp;&nbsp; XX=Present &nbsp; AA=Absent &nbsp; WH=Weekly Off &nbsp;  XA=Half Day Leave &nbsp; LP=Loss Of Pay &nbsp; CL=Casual Leave &nbsp;  SL=Sick Leave &nbsp;  EL=Earn Leave  &nbsp; CX,XC=Half Day Casual Leave &nbsp; <br> SX,XS=Half Day Sick AX-P(m), &nbsp; XA-P(m), &nbsp; AA-P(m)=half day or full day permissions (in minutes)</font><br><br>");
                        sb.Append("<font color=red>Note: &nbsp;&nbsp; XX=Present &nbsp; AA=Absent &nbsp; WH=Weekly Off &nbsp; XA=Half Day Leave &nbsp; LP=Loss Of Pay &nbsp; CL=Casual Leave &nbsp; SL=Sick Leave &nbsp;  EL=Earn Leave  &nbsp; CX,XC=Half Day Casual Leave &nbsp; <br> SX,XS=Half Day Sick Leave &nbsp; AX, XA, &nbsp; AA-P=half day or full day permissions (in minutes)</font><br><br>");
                        string fname = ConfigurationSettings.AppSettings["WklyMailAttach"] + repOff.ToString() + ".html";

                        if (File.Exists(fname))
                            File.Delete(fname);
                        using (StreamWriter w = new StreamWriter(fname, true))
                        { w.WriteLine(sb.ToString()); }

                        sb.Replace(sb.ToString(), "");
                        sb.Append("<Blockquote><center><b><u>" + drRepOff["EmpName"].ToString() + "</u></b></center><br>");
                        sb.Append("<br>Dear Sir / Madam,<br><br>"); //drRepOff["EmpName"].ToString()
                        sb.Append("Please find attached the weekly attendance report (Late minutes & Absentees) of your dept. direct reportees' for the week from(" + FromDate + " To " + ToDate + ").<br>");
                        //sb.Append("Please find auto generated email weekly attendance report (Late minutes & Absentees) of your dept direct reportees' for the week From(" + FromDate + " To " + ToDate + ").<br>");
                        //sb.Append("Please receive the same and acknowledge us with a copy to H.R.Dept,<br>");
                        sb.Append("Please feel free to call us for any further assistance. or service.<br>");
                        sb.Append("Let us coordinate together to monitor the attendance at H.O./Gachibowli and Ooty.<br><br>Regards,<br>Team - HR</Blockquote>");

                        //sb.Replace(sb.ToString(), "");
                        strsubject = "Weekly Attendance Report " + FromDate + "--" + ToDate;
                        SendMail(drRepOff["Email"].ToString(), strsubject, sb.ToString(), fname, "0", drRepOff["hr"].ToString());
                        sb.Replace(sb.ToString(), "");
                        ds.Tables["WklyAttnRpt"].Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "--" + repOff + "---WeeklyAttendanceMail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        private void MakeMailEnable()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"].ToString());
            SqlCommand mycommand = new SqlCommand();
            try
            {
                DateTime dtNow = DateTime.Now;
                mycommand = new SqlCommand("USP_WeeklyAttendanceMailStatus_Insert", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.Parameters.Add(new SqlParameter("@Sessionid", "1"));
                mycommand.Parameters.Add(new SqlParameter("@CreatedBy", "AutoGen"));
                mycommand.Parameters.Add(new SqlParameter("@StatusDate", dtNow));
                mycommand.Parameters.Add(new SqlParameter("@Type", "Update"));
                mycommand.Parameters.Add(new SqlParameter("@LastweekStatus", SqlDbType.Int));
                mycommand.Parameters["@LastweekStatus"].Value = 0;
                mycommand.Parameters.Add(new SqlParameter("@Flags", SqlDbType.Int));
                mycommand.Parameters["@Flags"].Value = 1;

                mycommand.Connection.Open();
                mycommand.ExecuteNonQuery();
                mycommand.Connection.Close();
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Auto Attendance Upd---MakeMailEnable---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }
        private DataTable FilldtcolsSMS()
        {
            DataColumn dc;
            dc = new DataColumn("SMSID");
            dtItemsSMS.Columns.Add(dc);
            dc = new DataColumn("ErrorMsg");
            dtItemsSMS.Columns.Add(dc);
            return dtItemsSMS;
        }
        private StringBuilder funHeader(StringBuilder sb, DataSet ds, int i)
        {
            try
            {
                //sb.Append("<body style='background-image:url(http://192.168.2.10/images/page_bg.gif)'>")
                sb.Append("<body>");
                //sb.Append("<center><b>INDIAN IMMUNOLOGICALS LIMITED</b><center><br>");
                //sb.AppendLine();
                sb.AppendLine();
                sb.Append("<center><b>Name:</b>");
                sb.Append(ds.Tables["GetReportingOfficers"].Rows[i - 1]["EmpId"].ToString() + "--" + ds.Tables["GetReportingOfficers"].Rows[i - 1]["EmpName"].ToString());
                sb.AppendLine();
                sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;<b>Designation:</b>");
                sb.Append(ds.Tables["GetReportingOfficers"].Rows[i - 1]["DesigName"].ToString());
                sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;<b>Date:</b>");
                sb.Append(ds.Tables["GetReportingOfficers"].Rows[i - 1]["TransDate"].ToString() + "<center><br><br>");
                return sb;
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---ApprovalsList---funHeader---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return null;
            }
        }
        private StringBuilder funApprDet(StringBuilder sb, DataSet dsset, int i)
        {
            try
            {
                string LEAVE = "0";
                string LEC = "0";
                string MISC = "0";
                string INDENT = "0";
                string PER = "0";
                string LTA = "0";
                string CON = "0";
                string TOUR = "0";
                string sUnq = "0";
                string tmpAppType = "-";

                if (dsset.Tables["ApprovalsDone"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsset.Tables["ApprovalsDone"].Rows)
                    {
                        if (dr["AppType"].ToString().ToUpper() != tmpAppType.ToString())
                        {
                            if (tmpAppType != "-") sb.Append("</table>");
                            tmpAppType = dr["AppType"].ToString().ToUpper();
                        }

                        if (dr["AppType"].ToString().ToUpper() == "LEAVE")
                        {
                            if (LEAVE == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=8><b>Leave Approvals</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("LeaveType</td><td>From Date</td><td>To Date</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["LeaveType"].ToString() + "</td><td>" + dr["FromDate"].ToString() + "</td><td>" + dr["ToDate"].ToString() + "</td></tr>");
                            LEAVE = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "LEC")
                        {
                            if (LEC == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Leave Encashment</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Financial Year</td><td>No.Of.Days</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["FinYear"].ToString() + "</td><td>" + dr["NoOfDays"].ToString() + "</td></tr>");
                            LEC = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "PER")
                        {
                            if (PER == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Permissions</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Permission Date</td><td>Permission Type</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["PerDate"].ToString() + "</td><td>" + dr["PerType"].ToString() + "</td></tr>");
                            PER = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "CON")
                        {
                            if (CON == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Conveyance</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Conveyance Date</td><td>Amount</td></tr>");
                            }
                            if (sUnq != dr["ID"].ToString())
                            {
                                sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                                sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>");
                            }
                            sb.Append(dr["ConDate"].ToString() + "</td><td>");
                            if (dr["Amount"].ToString() != "0")
                                sb.Append(decimal.Parse(dr["Amount"].ToString()).ToString("N2") + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            CON = "1";
                            sUnq = dr["ID"].ToString();
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "INDENT")
                        {
                            if (INDENT == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=9><b>Indent</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Material Desc</td><td>Item Code</td><td>Item Description</td><td>Estimated Value</td></tr>");
                            }
                            if (sUnq != dr["ID"].ToString())
                            {
                                sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                                sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>" + dr["MaterialDesc"].ToString() + "</td><td>");
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>");
                            }
                            sb.Append(dr["ICode"].ToString() + "</td><td>" + dr["IDesc"].ToString() + "</td><td>");
                            if (dr["EstValue"].ToString() != "0")
                                sb.Append(dr["EstValue"].ToString() + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            INDENT = "1";
                            sUnq = dr["ID"].ToString();
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "LTA")
                        {
                            if (LTA == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=10><b>LTA</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("From Year</td><td>To Year</td><td>AvailFrom</td><td>AvailTo</td><td>Amount</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["FromYear"].ToString() + "</td><td>" + dr["ToYear"].ToString() + "</td><td>" + dr["AvailedFrom"].ToString() + "</td><td>" + dr["AvailedTo"].ToString() + "</td><td>");
                            if (dr["Amount"].ToString() != "0")
                                sb.Append(decimal.Parse(dr["Amount"].ToString()).ToString("N2") + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            LTA = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "MISC")
                        {
                            if (MISC == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Miscellaneous</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Purpose</td><td>Amount</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["Purpose"].ToString() + "</td><td>");
                            if (dr["Amount"].ToString() != "0")
                                sb.Append(decimal.Parse(dr["Amount"].ToString()).ToString("N2") + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            MISC = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "TOUR")
                        {
                            if (TOUR == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=10><b>Tour Approvals</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("From Date</td><td>To Date</td><td>From Place</td><td>To Place</td></tr>");
                            }
                            if (sUnq != dr["ID"].ToString())
                            {
                                sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                                sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>");
                            }
                            sb.Append(dr["FromDate"].ToString() + "</td><td>" + dr["ToDate"].ToString() + "</td><td>" + dr["FromPlace"].ToString() + "</td><td>" + dr["ToPlace"].ToString() + "</td></tr>");
                            TOUR = "1";
                            sUnq = dr["ID"].ToString();
                        }
                    }
                    sb.Append("</table>");
                }

                return sb;
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---ApprovalsList---funApprDet---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return null;
            }
        }
        private StringBuilder funApprPenDet(StringBuilder sb, DataSet dsset, int i)
        {
            try
            {
                string LEAVE = "0";
                string LEC = "0";
                string MISC = "0";
                string INDENT = "0";
                string PER = "0";
                string LTA = "0";
                string CON = "0";
                string TOUR = "0";
                string TRAIN = "0";
                string sUnq = "0";
                string tmpAppType = "-";

                if (dsset.Tables["ApprovalsPending"].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsset.Tables["ApprovalsPending"].Rows)
                    {
                        if (dr["AppType"].ToString().ToUpper() != tmpAppType.ToString())
                        {
                            if (tmpAppType != "-") sb.Append("</table>");
                            tmpAppType = dr["AppType"].ToString().ToUpper();
                        }

                        if (dr["AppType"].ToString().ToUpper() == "LEAVE")
                        {
                            if (LEAVE == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=8><b>Leave Approvals</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("LeaveType</td><td>From Date</td><td>To Date</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["LeaveType"].ToString() + "</td><td>" + dr["FromDate"].ToString() + "</td><td>" + dr["ToDate"].ToString() + "</td></tr>");
                            LEAVE = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "LEC")
                        {
                            if (LEC == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Leave Encashment</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Financial Year</td><td>No.Of.Days</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["FinYear"].ToString() + "</td><td>" + dr["NoOfDays"].ToString() + "</td></tr>");
                            LEC = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "PER")
                        {
                            if (PER == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Permissions</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Permission Date</td><td>Permission Type</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["PerDate"].ToString() + "</td><td>" + dr["PerType"].ToString() + "</td></tr>");
                            PER = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "CON")
                        {
                            if (CON == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Conveyance</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Conveyance Date</td><td>Amount</td></tr>");
                            }
                            if (sUnq != dr["ID"].ToString())
                            {
                                sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                                sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>");
                            }
                            sb.Append(dr["ConDate"].ToString() + "</td><td>");
                            if (dr["Amount"].ToString() != "0")
                                sb.Append(decimal.Parse(dr["Amount"].ToString()).ToString("N2") + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            CON = "1";
                            sUnq = dr["ID"].ToString();
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "INDENT")
                        {
                            if (INDENT == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=9><b>Indent</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Material Desc</td><td>Item Code</td><td>Item Description</td><td>Estimated Value</td></tr>");
                            }
                            if (sUnq != dr["ID"].ToString())
                            {
                                sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                                sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>" + dr["MaterialDesc"].ToString() + "</td><td>");
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>");
                            }
                            sb.Append(dr["ICode"].ToString() + "</td><td>" + dr["IDesc"].ToString() + "</td><td>");
                            if (dr["EstValue"].ToString() != "0")
                                sb.Append(dr["EstValue"].ToString() + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            INDENT = "1";
                            sUnq = dr["ID"].ToString();
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "LTA")
                        {
                            if (LTA == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=10><b>LTA</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("From Year</td><td>To Year</td><td>AvailFrom</td><td>AvailTo</td><td>Amount</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["FromYear"].ToString() + "</td><td>" + dr["ToYear"].ToString() + "</td><td>" + dr["AvailedFrom"].ToString() + "</td><td>" + dr["AvailedTo"].ToString() + "</td><td>");
                            if (dr["Amount"].ToString() != "0")
                                sb.Append(decimal.Parse(dr["Amount"].ToString()).ToString("N2") + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            LTA = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "MISC")
                        {
                            if (MISC == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=7><b>Miscellaneous</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("Purpose</td><td>Amount</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            sb.Append(dr["Purpose"].ToString() + "</td><td>");
                            if (dr["Amount"].ToString() != " 0")
                                sb.Append(decimal.Parse(dr["Amount"].ToString()).ToString("N2") + "</td></tr>");
                            else
                                sb.Append("--</td></tr>");
                            MISC = "1";
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "TOUR")
                        {
                            if (TOUR == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=10><b>Tour Approvals</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Applied Date</td><td>Status</td><td>");
                                sb.Append("From Date</td><td>To Date</td><td>From Place</td><td>To Place</td></tr>");
                            }
                            if (sUnq != dr["ID"].ToString())
                            {
                                sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                                sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td><td>" + dr["Rstatus"].ToString() + "</td><td>");
                            }
                            else
                            {
                                sb.Append("<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>");
                            }
                            sb.Append(dr["FromDate"].ToString() + "</td><td>" + dr["ToDate"].ToString() + "</td><td>" + dr["FromPlace"].ToString() + "</td><td>" + dr["ToPlace"].ToString() + "</td></tr>");
                            TOUR = "1";
                            sUnq = dr["ID"].ToString();
                        }
                        else if (dr["AppType"].ToString().ToUpper() == "TRAIN")
                        {
                            if (TRAIN == "0")
                            {
                                sb.Append("<table border=1 width=1000px><tr><td colspan=4><b>Trainee Confirmation</b>");
                                sb.Append("</td></tr><tr><td>ID</td><td>EmpNo</td><td>Employee Name</td><td>Joining Date</td></tr>");
                            }
                            sb.Append("<tr><td>" + dr["ID"].ToString() + "</td><td>" + dr["EmpNo"].ToString());
                            sb.Append("</td><td>" + dr["EmpName"].ToString() + "</td><td>" + dr["AppliedDate"].ToString() + "</td></tr>");
                            TRAIN = "1";
                        }
                    }

                    int k = 0;
                    foreach (DataRow dr in dsset.Tables["ApprovalsPending1"].Rows)
                    {
                        if (k == 0)
                        {
                            sb.Append("<table border=1 width=1000px><tr><td colspan=4><b>Pending Indents</b>");
                            sb.Append("</td></tr><tr><td>IndentNo</td><td>IndentDate</td><td>Pending Since</td><td>Indentor</td><td>Pending At</td></tr>");
                            k = k + 1;
                        }
                        else
                        {
                            sb.Append("<tr><td>" + dr["indentno"].ToString() + "</td><td>" + dr["inddate"].ToString());
                            sb.Append("</td><td>" + dr["pendingSince"].ToString() + "</td><td>" + dr["empid"].ToString() + "</td><td>" + dr["mgrid"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                }
                return sb;
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---ApprovalsList---funApprPenDet---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return null;
            }
        }
        private void SendHelpDeskTicketMail()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dsHlpdsk = new DataSet();
            try
            {
                mycommand = new SqlCommand("Usp_SendHlpdskMail", mycon);
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dsHlpdsk, "Helpdesk");
                mycommand.Connection.Close();

                int flg = 0;
                if (dsHlpdsk.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView(dsHlpdsk.Tables[0]);
                    DataTable dt = dv.ToTable(true, "respperson", "resppersonmail");

                    foreach (DataRow drEmpId in dt.Rows)
                    {
                        StringBuilder sbMailId = new StringBuilder();
                        dv = new DataView(dsHlpdsk.Tables[0]);
                        dv.RowFilter = "respperson='" + Convert.ToString(drEmpId["respperson"]) + "'";
                        DataTable dt1 = dv.ToTable();
                        if (dt1.Rows.Count > 0)
                        {
                            flg = 1;
                            sbMailId.Append("<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='100%'>");

                            sbMailId.Append("<tr bgcolor='#00BFFF'>");
                            sbMailId.Append("<th align='left' valign='bottom'> TicketNo           </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Issue Title        </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Category           </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Sub Category       </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Department         </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Requestor          </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Status             </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Assigned to        </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Priority           </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Posted On          </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Pending Since(hrs) </th>");
                            sbMailId.Append("<th align='left' valign='bottom'> Query Type         </th>");
                            sbMailId.Append("</tr>");

                            foreach (DataRow dr in dt1.Rows)
                            {
                                sbMailId.Append("<tr>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["QueryNo"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["QuerySubject"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["catgname"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["subcatname"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["department"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["Requestor"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["Status"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["Assignedto"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["Priority"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["Queryposteddate"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["pendingsince"]).ToString().Trim() + " </td>");
                                sbMailId.Append("<td> " + Convert.ToString(dr["querytype"]).ToString().Trim() + " </td>");
                                sbMailId.Append("</tr>");
                            }

                            sbMailId.Append("</table>");
                        }
                        if (flg == 1)
                        {
                            SendMail(drEmpId["resppersonmail"].ToString(), "Helpdesk Pending Tickets", "<br><br>" + Convert.ToString(sbMailId) + "<br><br>This is an automated E-mail <br> Please Don't reply to the mail.", "0", "0", "0");

                            StringWriter SWFinal = new StringWriter();
                            dt1.WriteXml(SWFinal);
                            string MailUpd = SWFinal.ToString();
                            mycommand = new SqlCommand("Usp_InsertHlpdskMailDet", mycon);
                            mycommand.CommandType = CommandType.StoredProcedure;
                            mycommand.Parameters.Add(new SqlParameter("@MailUpd", SqlDbType.Xml));
                            mycommand.Parameters["@MailUpd"].Value = MailUpd.ToString();
                            mycommand.Connection.Open();
                            mycommand.ExecuteNonQuery();
                            mycommand.Connection.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Helpdesk ticket mail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }
        }

        private void Retestmaterialalertmaildetails()
        {
            //System.Data.DataTable objPlantdt = default(System.Data.DataTable);
            //System.Data.DataRow objPlantdr = default(System.Data.DataRow);

            System.Data.DataTable objHdrdt = default(System.Data.DataTable);
            System.Data.DataRow objHdrdr = default(System.Data.DataRow);
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            SqlCommand mycommand1 = new SqlCommand();
            DataSet ds = new DataSet();

            mycommand = new SqlCommand("usp_RetestMaterialAlertMailDetails", mycon);
            mycommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
            mycommand.Connection.Open();
            myAdapter.Fill(ds);
            mycommand.Connection.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)                                 //If  material exists , Process Starts 
                {


                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {

                        DataTable dt = new DataTable();

                        DataTable dt1 = new DataTable();
                        dt = ds.Tables[1];
                        dt1 = ds.Tables[2];
                        DataView dv = new DataView(dt);
                        dv.RowFilter = "Plantcode = '" + drow["Plantcode"].ToString() + "'";
                        dt = dv.ToTable();
                        DataView dv1 = new DataView(dt1);
                        dv1.RowFilter = "Plantcode = '" + drow["Plantcode"].ToString() + "'";
                        dt1 = dv1.ToTable();
                        objHdrdt = new DataTable("HeaderRows");
                        objHdrdt.Columns.Add("Plant", typeof(string));
                        objHdrdr = objHdrdt.NewRow();
                        objHdrdr["Plant"] = drow["Plantcode"].ToString();
                        objHdrdt.Rows.Add(objHdrdr);
                        DataSet dsfinal = new DataSet();
                        dsfinal.Tables.Add(objHdrdt);
                        dsfinal.Tables.Add(dt);
                        SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                        XmlDocument xDoc = XMLSerializerBL.Serialize(dsfinal, XMLSerializerBL.InputType.DataSet);
                        XmlNode xmlException = null;
                        s.Timeout = System.Threading.Timeout.Infinite;
                        XmlElement xDocTable = (XmlElement)s.GetRetestMatAlertMailDetails(xDoc, out xmlException);

                        List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                        if (SAPError[0] == "1000")
                        {
                            DataTable dt2 = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);

                            if (dt2.Rows.Count > 0)
                            {
                                StringBuilder sbMailId = new StringBuilder();
                                StringBuilder sbMail = new StringBuilder();
                                sbMailId.Append("Retest Material Details<br>");
                                sbMailId.Append("<table border = '1' bordercolor = '#00BFFF' cellspacing='0' cellpadding='1' width='100%'>");
                                sbMailId.Append("<tr bgcolor='#00BFFF'><td>Material</td><td>Material Desc</td><td>Batch</td><td>Next Inspection Date</td><td>Expirydate</td><td>InspectionLotNumber</td></tr>");
                                foreach (DataRow drinstr in dt2.Rows)
                                {

                                    sbMailId.Append("<tr><td>" + Convert.ToString(drinstr["Material"]) + "</td>");
                                    sbMailId.Append("<td>" + Convert.ToString(drinstr["MaterialDesc"]) + "</td>");
                                    sbMailId.Append("<td>" + Convert.ToString(drinstr["BatchNo"]) + "</td>");
                                    sbMailId.Append("<td>" + Convert.ToString(Convert.ToDateTime(drinstr["Nextinspectiondate"]).ToString("dd/MM/yyyy")) + "</td>");
                                    sbMailId.Append("<td>" + Convert.ToString(Convert.ToDateTime(drinstr["ShelfLifeExpiryDate"]).ToString("dd/MM/yyyy")) + "</td>");

                                    sbMailId.Append("<td>" + Convert.ToString(drinstr["InspectionLotNumber"]) + "</td></tr>");
                                }
                                sbMailId.Append("</table>");

                                foreach (DataRow drMail in dt1.Rows)
                                {
                                    sbMail.Append(Convert.ToString(drMail["Email"]) + ";");
                                }
                                SendMail(sbMail.ToString(), "Retest material details in 30 days advance", "Dear Sir/Madam, <br><br>The following are the materials which has to be retested <br><br>" + Convert.ToString(sbMailId) + "<br><br>This is an automated E-mail <br> Please Don't reply to the mail.", "0", "0", "0");
                            }
                        }
                    }
                }
            }
        }

        public void GetOutstanding()
        {
            try
            {
                SqlConnection mycon = new SqlConnection((ConfigurationSettings.AppSettings["TestCon"].ToString()));
                SqlConnection mycon1 = new SqlConnection((ConfigurationSettings.AppSettings["connection"].ToString()));
                SqlCommand mycommand = new SqlCommand();
                SqlCommand mycommand1 = new SqlCommand();
                DataSet ds = new DataSet();
                mycommand = new SqlCommand("USP_BOSales_GetInputs", mycon1);           //Getting all emps (rsigned,hold and active)
                mycommand.Parameters.Add(new SqlParameter("@flag", "OS"));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 100000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "getinputs");
                mycommand.Connection.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SAPService s = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceURL"]);

                        XmlDocument xDoc = XMLSerializerBL.Serialize(ds, XMLSerializerBL.InputType.DataSet);
                        XmlNode xmlException = null;
                        s.Timeout = System.Threading.Timeout.Infinite;
                        XmlElement xDocTable = (XmlElement)s.GetOutstanding(xDoc, out xmlException);
                        List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                        //If Call Success
                        if (SAPError[0] == "1000")
                        {
                            DataSet dsos = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                            if (ds.Tables[0].Rows[0]["LFlag"].ToString() == "OS")
                            {
                                mycommand = new SqlCommand("USP_BOReport_Transactions", mycon);
                                mycommand.CommandType = CommandType.StoredProcedure;
                                if (dsos != null && dsos.Tables.Count > 0 && dsos.Tables["Outstanding"].Rows.Count > 0)
                                {
                                    StringWriter sboutstand = new StringWriter();
                                    dsos.Tables["Outstanding"].WriteXml(sboutstand);
                                    mycommand.Parameters.Add(new SqlParameter("@flag", ds.Tables[0].Rows[0]["LFlag"].ToString().Trim()));
                                    mycommand.Parameters.Add(new SqlParameter("@keydate", ds.Tables[0].Rows[0]["Flag"].ToString().Trim()));
                                    mycommand.Parameters.Add("@bodata", SqlDbType.Xml);
                                    mycommand.Parameters["@bodata"].Value = sboutstand.ToString();
                                    mycommand.Connection.Open();
                                    mycommand.ExecuteNonQuery();
                                    mycommand.Connection.Close();
                                }
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception : " + ex.Message + "|-|" + Convert.ToString(ex.Source) + "|-|" + Convert.ToString(ex.StackTrace) + "|-|" + Convert.ToString(ex.TargetSite.ReflectedType.Name + "|-|" + ex.TargetSite.Name + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")));
                //WriteLog(1, "Exception :" + ex.Message + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        public void GetProductwiseBudget(string str)
        {
            try
            {
                SqlConnection mycon = new SqlConnection((ConfigurationSettings.AppSettings["TestCon"].ToString()));
                SqlConnection mycon1 = new SqlConnection((ConfigurationSettings.AppSettings["connection"].ToString()));
                SqlConnection mycon2 = new SqlConnection((ConfigurationSettings.AppSettings["TestCon1"].ToString()));
                SqlCommand mycommand = new SqlCommand();
                SqlCommand mycommand1 = new SqlCommand();
                SqlCommand mycommand2 = new SqlCommand();
                DataSet ds = new DataSet();
                mycommand = new SqlCommand("USP_BOSales_GetInputs", mycon1);           //Getting all emps (rsigned,hold and active)
                mycommand.Parameters.Add(new SqlParameter("@flag", str));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 100000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(ds, "getinputs");
                mycommand.Connection.Close();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SAPService s = new SAPService(ConfigurationManager.AppSettings["SAPWebServiceURL"]);
                        XmlDocument xDoc = XMLSerializerBL.Serialize(ds, XMLSerializerBL.InputType.DataSet);
                        XmlNode xmlException = null;
                        s.Timeout = System.Threading.Timeout.Infinite;
                        XmlElement xDocTable = (XmlElement)s.GetProductwiseBudget(xDoc, out xmlException);
                        List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                        //If Call Success
                        if (SAPError[0] == "1000")
                        {
                            DataSet dsoutput = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                            if (ds.Tables[0].Rows[0]["LFlag"].ToString() == "PB")
                            {
                                if (dsoutput != null && dsoutput.Tables.Count > 0 && dsoutput.Tables["Budget"].Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in dsoutput.Tables["Budget"].Rows)
                                    {
                                        Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                                        dr1["MaterialDesc"] = r.Replace(dr1["MaterialDesc"].ToString(), String.Empty);
                                        dsoutput.Tables["Budget"].AcceptChanges();
                                    }
                                    mycommand = new SqlCommand("USP_BOReport_Transactions", mycon);
                                    mycommand.CommandType = CommandType.StoredProcedure;
                                    mycommand.CommandTimeout = 10000;
                                    StringWriter sbbudget = new StringWriter();
                                    dsoutput.Tables["Budget"].WriteXml(sbbudget);
                                    mycommand.Parameters.Add(new SqlParameter("@flag", ds.Tables[0].Rows[0]["LFlag"].ToString().Trim()));
                                    mycommand.Parameters.Add(new SqlParameter("@keydate", "2000-01-01"));
                                    mycommand.Parameters.Add("@bodata", SqlDbType.Xml);
                                    mycommand.Parameters["@bodata"].Value = sbbudget.ToString();
                                    mycommand.Connection.Open();
                                    mycommand.ExecuteNonQuery();
                                    mycommand.Connection.Close();
                                }
                            }
                            else if ((ds.Tables[0].Rows[0]["LFlag"].ToString() == "PS") || (ds.Tables[0].Rows[0]["LFlag"].ToString() == "SS"))
                            {
                                if (dsoutput != null && dsoutput.Tables.Count > 0 && dsoutput.Tables["Sales"].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["LFlag"].ToString() == "PS")
                                    {
                                        foreach (DataRow dr1 in dsoutput.Tables["Sales"].Rows)
                                        {
                                            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                                            dr1["MatDesc"] = r.Replace(dr1["Matdesc"].ToString(), String.Empty);
                                            dsoutput.Tables["Sales"].AcceptChanges();
                                        }
                                    }
                                    mycommand = new SqlCommand("USP_BOReport_Transactions", mycon);
                                    mycommand.CommandType = CommandType.StoredProcedure;
                                    StringWriter sbsales = new StringWriter();
                                    dsoutput.Tables["Sales"].WriteXml(sbsales);
                                    mycommand.Parameters.Add(new SqlParameter("@flag", ds.Tables[0].Rows[0]["LFlag"].ToString().Trim()));
                                    mycommand.Parameters.Add(new SqlParameter("@keydate", "2000-01-01"));
                                    mycommand.Parameters.Add("@bodata", SqlDbType.Xml);
                                    mycommand.Parameters["@bodata"].Value = sbsales.ToString();
                                    mycommand.Connection.Open();
                                    mycommand.ExecuteNonQuery();
                                    mycommand.Connection.Close();
                                }
                            }
                            else if (ds.Tables[0].Rows[0]["LFlag"].ToString() == "PY")
                            {
                                if (dsoutput != null && dsoutput.Tables.Count > 0 && dsoutput.Tables["Payroll"].Rows.Count > 0)
                                {
                                    dsoutput.DataSetName = "DocumentElement";
                                    dsoutput.Tables["Payroll"].DefaultView.Sort = "EmpId,MonYear";
                                    DataTable dtoutput1 = new DataTable();
                                    dtoutput1 = dsoutput.Tables["Payroll"].DefaultView.ToTable( /*distinct*/ true);
                                    dtoutput1.TableName = "Payroll";
                                    mycommand = new SqlCommand("USP_BOReport_Transactions", mycon);
                                    mycommand.CommandType = CommandType.StoredProcedure;
                                    StringWriter sbppayroll = new StringWriter();
                                    dtoutput1.WriteXml(sbppayroll);
                                    mycommand.Parameters.Add(new SqlParameter("@flag", ds.Tables[0].Rows[0]["LFlag"].ToString().Trim()));
                                    mycommand.Parameters.Add(new SqlParameter("@keydate", "2000-01-01"));
                                    mycommand.Parameters.Add("@bodata", SqlDbType.Xml);
                                    mycommand.Parameters["@bodata"].Value = sbppayroll.ToString();
                                    mycommand.Connection.Open();
                                    mycommand.ExecuteNonQuery();
                                    mycommand.Connection.Close();
                                }
                            }
                            else if (ds.Tables[0].Rows[0]["LFlag"].ToString() == "HQ")
                            {
                                if (dsoutput != null && dsoutput.Tables.Count > 0 && dsoutput.Tables["HQSale"].Rows.Count > 0)
                                {
                                    dsoutput.DataSetName = "DocumentElement";
                                    DataTable dtoutput1 = new DataTable();
                                    dtoutput1 = dsoutput.Tables["HQSale"]; //.DefaultView.ToTable( /*distinct*/ true);
                                    dtoutput1.TableName = "HQSales";
                                    mycommand = new SqlCommand("USP_BOReport_Transactions", mycon);
                                    mycommand.CommandType = CommandType.StoredProcedure;
                                    mycommand.CommandTimeout = 10000;
                                    StringWriter sbppayroll = new StringWriter();
                                    dtoutput1.WriteXml(sbppayroll);
                                    mycommand.Parameters.Add(new SqlParameter("@flag", ds.Tables[0].Rows[0]["LFlag"].ToString().Trim()));
                                    mycommand.Parameters.Add(new SqlParameter("@keydate", "2000-01-01"));
                                    mycommand.Parameters.Add("@bodata", SqlDbType.Xml);
                                    mycommand.Parameters["@bodata"].Value = sbppayroll.ToString();
                                    mycommand.Connection.Open();
                                    mycommand.ExecuteNonQuery();
                                    mycommand.Connection.Close();

                                    mycommand2 = new SqlCommand("USP_BOReport_Transactions", mycon2);
                                    mycommand2.CommandType = CommandType.StoredProcedure;
                                    mycommand2.CommandTimeout = 10000;
                                    StringWriter sbppayroll1 = new StringWriter();
                                    dtoutput1.WriteXml(sbppayroll1);
                                    mycommand2.Parameters.Add(new SqlParameter("@flag", ds.Tables[0].Rows[0]["LFlag"].ToString().Trim()));
                                    mycommand2.Parameters.Add(new SqlParameter("@keydate", "2000-01-01"));
                                    mycommand2.Parameters.Add("@bodata", SqlDbType.Xml);
                                    mycommand2.Parameters["@bodata"].Value = sbppayroll1.ToString();
                                    mycommand2.Connection.Open();
                                    mycommand2.ExecuteNonQuery();
                                    mycommand2.Connection.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception : " + str + "|-|" + ex.Message + "|-|" + Convert.ToString(ex.Source) + "|-|" + Convert.ToString(ex.StackTrace) + "|-|" + Convert.ToString(ex.TargetSite.ReflectedType.Name + "|-|" + ex.TargetSite.Name + "---tmr_Elapsed---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")));
                //throw ex;
            }
        }

        #endregion

        #region SubSubFunctions

        private enum DatePart
        {
            Days,
            Months,
            Years
        }
        private DateTime ConvertStringToDate(string DateString)
        {
            System.Globalization.DateTimeFormatInfo dti = new System.Globalization.DateTimeFormatInfo();
            dti.ShortDatePattern = "dd/MM/yyyy";
            DateString = DateString.Replace("-", "/");
            string strToDecode = DateString;
            DateTime dt = DateTime.ParseExact(strToDecode, "dd/MM/yyyy", dti);
            return dt;
        }
        private int DateDiff(DateTime StartDate, DateTime EndDate, DatePart objDiff)
        {
            TimeSpan ts = EndDate.Subtract(StartDate);
            switch (objDiff)
            {
                case DatePart.Days: return ts.Days;
                //case DatePart.Months: return ts.Days / 30; // Commented by Vijayasai (23/07/2012)
                case DatePart.Months: if (ts.Days % 30 > 15) return ts.Days / 30 + 1; else return ts.Days / 30; // Added by Vijayasai (23/07/2012)
                //case DatePart.Months: return ((Math.Abs(StartDate.Year - EndDate.Year) * 12) + Math.Abs((StartDate.Month - EndDate.Month)));
                case DatePart.Years: return StartDate.Year - EndDate.Year;

            }

            return -1;
        }

        private string MailBodyForTraineeDoc(string empid, string Fname)
        {
            try
            {
                StringBuilder StblrBody = new StringBuilder();
                StblrBody.AppendFormat("<font size = '2' color = 'blue' face = 'verdana'><br />");
                StblrBody.AppendFormat("Dear {0}", Fname + " [" + empid + "]");
                StblrBody.AppendFormat(",<br /><br /><br />");
                StblrBody.AppendFormat("We hope that you are enjoying your work.");
                StblrBody.AppendFormat("<br /><br />");
                StblrBody.AppendFormat("Since you have completed 3 months with IIL, we would like to return your documents lying with us, if any.<br />Please confirm your address with PIN and Phone number to enable us return your documents.");
                //StblrBody.AppendFormat("As you have completed 3 months of service with us, HR department would like to return your documents lying with it, if any.");
                StblrBody.AppendFormat("<br /><br />");
                StblrBody.AppendFormat("Please also share your experience, so far, with the company – its  systems, products, services and practices. Also, in case you have any issue or suggestion, or if you want any kind of clarity/ support / guidance, please write to us at marketinghr@indimmune.com");
                //StblrBody.AppendFormat("You are therefore requested to confirm your</font><font color = red  size = 2 face = verdana> <b><u>Complete address with PIN code and telephone numbers</u></b></font><font color = blue size = 2 face = verdana> where you would like HR to send your documents. ");
                //StblrBody.AppendFormat("<br />Moreover, in case you are not likely to be available at the given address, please mention the name of the family member / person who would receive the same on your behalf.");
                //StblrBody.AppendFormat("<br />Company will send the documents by</font><font color = red  size = 2 face = verdana> <b>Courier or Registered Post</b></font><font color = blue size = 2 face = verdana> as per your preference, within two weeks of receiving your email confirmation.<br />");
                //StblrBody.AppendFormat("<br /></br />You may email your requests  at - marketinghr@indimmune.com.<br /></br />");
                //StblrBody.AppendFormat("<br />Pl note that if the documents are returned undelivered for reasons such as</font><font color = red  size = 2 face = verdana> <b>“incorrect address”, “Change of address” or “non availability of the person”</b></font><font color = blue size = 2 face = verdana>, you will have to make your own arrangements for collecting the same from HR department.");
                StblrBody.AppendFormat("<br /><br />");
                StblrBody.AppendFormat("Wishing you an  Interesting, Challenging, Fulfilling association  with IIL!");
                //StblrBody.AppendFormat("<br /><br /><b>Wishing you an Interesting, Challenging and Rewarding Career with IIL.</b>");
                StblrBody.AppendFormat("<br /><br />All the best!<br />");
                StblrBody.AppendFormat("<b>Shameer Alam</b>");
                StblrBody.AppendFormat("<br />");
                StblrBody.AppendFormat("<b>Executive HR</b>");
                StblrBody.AppendFormat("<br /><hr></font>");
                return StblrBody.ToString();
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---SendingMailToTraineeForDocuments.MailBodyForTraineeDoc---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return null;
            }
        }

        private string MailBodyForTraineeConfirm(string empid, string Fname, string flag)
        {
            try
            {
                StringBuilder StblrBody = new StringBuilder();
                StblrBody.AppendFormat("<font size = '2' color = 'blue' face = 'verdana'><br />");
                StblrBody.AppendFormat("Dear {0}", Fname + " [" + empid + "]");
                StblrBody.AppendFormat(",<br /><br /><br />");
                StblrBody.AppendFormat("Congratulations on successfully completing your training period!!!");
                StblrBody.AppendFormat("<br /><br />");
                StblrBody.AppendFormat("You will  shortly receive a communication  in this regard with  the  details of  your revised  grade  &  compensation.  We hope you will  continue doing the good work and add value to the organisation.");
                StblrBody.AppendFormat("<br /><br />");
                StblrBody.AppendFormat("For any further  query, support, help ,  you may  pl get in touch with the undersigned at marketinghr@indimmune.com.");
                StblrBody.AppendFormat("<br /><br />");
                StblrBody.AppendFormat("Wishing you a Challenging,  Interesting & Rewarding Career with IIL");
                StblrBody.AppendFormat("<br /><br />All the best!<br />");
                if (flag == "Y")
                {
                    StblrBody.AppendFormat("<b>Shameer Alam</b>");
                    StblrBody.AppendFormat("<br />");
                    StblrBody.AppendFormat("<b>Executive HR</b>");
                }
                else
                {
                    StblrBody.AppendFormat("<b>Team HR</b>");

                }
                StblrBody.AppendFormat("<br /><hr></font>");
                return StblrBody.ToString();
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---EmpCreation---SendingMailToTraineeForConfirm.MailBodyForTraineeConfirm---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                return null;
            }
        }

        //private void SendMail(string email, string subject, string body, string fname, string from, string cc)
        //{
        //    try
        //    {
        //        //fp = File.CreateText(Server.MapPath("/news/") & strPostPath);
        //        //string strPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        //        //fp = File.CreateText(strPath & "/news/" &strPostPath); Or
        //        //System.Reflection.Assembly.GetCallingAssembly().Location Or
        //        //System.Reflection.Assembly.GetExecutingAssembly().CodeBase 

        //        MailMessage mmsg = new MailMessage();
        //        mmsg.From = from != "0" ? from : "iilwebadmin@indimmune.com";
        //        mmsg.To = email;
        //        if (cc != "0")
        //        {
        //            mmsg.Cc = cc;
        //        }
        //        if (mmsg.To != ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString())
        //        {
        //            mmsg.Bcc = C_Emailid; // ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString();
        //        }
        //        mmsg.Subject = subject;
        //        StringBuilder stblr = new StringBuilder();
        //        //stblr.Append("<table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='50%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='20%' alt='IIL Home'/></td></tr><tr><td align='justify' valign='top'><blockquote><font face='Arial' size='2'>"       + body +       "</font></blockquote><br /><hr /><br /><blockquote><font face='Arial' size='1' color='MidnightBlue'><center>This is an automated system generated mail. Please don’t reply to this mail.</center></font></blockquote></td></tr></table></td></tr></table>");
        //        stblr.Append("<center><table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='80%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='30%' alt='IIL Home'/></td></tr><tr><td align='center' valign='top'><blockquote><font face='Arial' size='2'><br />" + body + "<br /></font></blockquote><br /><hr /><br /><blockquote><center><font face='Arial' size='1' color='MidnightBlue'>This is an automated system generated mail. Please don’t reply to this mail.</font></center></blockquote></td></tr></table></td></tr></table></center>");
        //        mmsg.Body = stblr.ToString(); //body;
        //        mmsg.BodyFormat = MailFormat.Html;
        //        if (fname != "0")
        //        {
        //            mmsg.Attachments.Add(new MailAttachment(fname));
        //        }
        //        if (mmsg.To != "" && (mmsg.Subject != "" || mmsg.Body != ""))
        //        {
        //            SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["MailServer"].ToString();
        //            SmtpMail.Send(mmsg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLog(1, "Exception :" + ex.Message + "---SendMail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
        //    }
        //}

        private void SendMail(string email, string subject, string body, string fname, string from, string cc)
        {
            try
            {
                //fp = File.CreateText(Server.MapPath("/news/") & strPostPath);
                //string strPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                //fp = File.CreateText(strPath & "/news/" &strPostPath); Or
                //System.Reflection.Assembly.GetCallingAssembly().Location Or
                //System.Reflection.Assembly.GetExecutingAssembly().CodeBase 

                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.From = new System.Net.Mail.MailAddress(from != "0" ? from : "iilemailadmin@indimmune.com");
                // mmsg.To.Add(new System.Net.Mail.MailAddress(email));
                // Changes added by Avinash J on 06-08-2019 : to allow multiple TO Mail address 
                if (!string.IsNullOrEmpty(email))
                {
                    string[] toMailArray = email.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string eMId in toMailArray)
                    {
                        mmsg.To.Add(new System.Net.Mail.MailAddress(eMId));
                    }
                }
                if (cc != "0")
                {
                    //mmsg.CC.Add(new System.Net.Mail.MailAddress(cc));
                    string[] ccid = cc.Split(',');
                    foreach (string ccEmailId in ccid)
                    {
                        mmsg.CC.Add(new System.Net.Mail.MailAddress(ccEmailId)); //Adding Multiple CC email Id
                    }
                }
                if (mmsg.To.Contains(new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString())))
                {
                    mmsg.Bcc.Add(new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString()));
                    mmsg.Bcc.Add(new System.Net.Mail.MailAddress("i.harikrishnaprasad@indimmune.com"));
                }
                mmsg.Subject = subject;
                StringBuilder stblr = new StringBuilder();
                //stblr.Append("<table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='50%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='20%' alt='IIL Home'/></td></tr><tr><td align='justify' valign='top'><blockquote><font face='Arial' size='2'>"       + body +       "</font></blockquote><br /><hr /><br /><blockquote><font face='Arial' size='1' color='MidnightBlue'><center>This is an automated system generated mail. Please don’t reply to this mail.</center></font></blockquote></td></tr></table></td></tr></table>");
                stblr.Append("<center><table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='80%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='30%' alt='IIL Home'/></td></tr><tr><td align='center' valign='top'><blockquote><font face='Arial' size='2'><br />" + body + "<br /></font></blockquote><br /><hr /><br /><blockquote><center><font face='Arial' size='1' color='MidnightBlue'>This is an automated system generated mail. Please don’t reply to this mail.</font></center></blockquote></td></tr></table></td></tr></table></center>");
                mmsg.Body = stblr.ToString(); //body;
                mmsg.IsBodyHtml = true;

                //if (objMailBE.Attachment != "")
                //    mailMessage.Attachments.Add(new Attachment(objMailBE.Attachment));
                //if (objMailBE.Attachment1 != "")
                //    mailMessage.Attachments.Add(new Attachment(objMailBE.Attachment1));

                if (fname != "0")
                {
                    mmsg.Attachments.Add(new System.Net.Mail.Attachment(fname));

                }
                if (mmsg.To.Count > 0 && (mmsg.Subject != "" || mmsg.Body != ""))
                {
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("iilemailadmin@indimmune.com", "Zon50749");
                    client.Port = 587;
                    client.Host = "smtp.office365.com";
                    client.EnableSsl = true;
                    client.Send(mmsg);
                    mailFlag = true;
                    //return true;

                    //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["MailServer"].ToString();
                    //SmtpMail.Send(mmsg);
                }
            }
            catch (Exception ex)
            {
                mailFlag = false;
                WriteLog(1, "Exception :" + ex.Message + "---SendMail---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }



        private void SendMailEComm(string email, string subject, string body, string fname, string from, string cc)
        {
            try
            {
                WriteLog(0, "---SendMail Process Started---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.From = new System.Net.Mail.MailAddress(from != "0" ? from : "iilemailadmin@indimmune.com");


                // Changes added by Avinash J on 06-08-2019 : to allow multiple TO Mail address 
                if (!string.IsNullOrEmpty(email))
                {
                    string[] toMailArray = email.Split(new char[] { ';', ',', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string eMId in toMailArray)
                    {
                        mmsg.To.Add(new System.Net.Mail.MailAddress(eMId));
                    }
                }
                if (cc != "0")
                {
                    //mmsg.CC.Add(new System.Net.Mail.MailAddress(cc));
                    string[] ccid = cc.Split(new char[] { ';', ',', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ccEmailId in ccid)
                    {
                        mmsg.CC.Add(new System.Net.Mail.MailAddress(ccEmailId)); //Adding Multiple CC email Id
                    }
                }
                if (mmsg.To.Contains(new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString())))
                {
                    mmsg.Bcc.Add(new System.Net.Mail.MailAddress(ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString()));
                    mmsg.Bcc.Add(new System.Net.Mail.MailAddress("i.harikrishnaprasad@indimmune.com"));
                    mmsg.Bcc.Add(new System.Net.Mail.MailAddress("jorige.avinash@indimmune.com"));
                }
                mmsg.Subject = subject;
                StringBuilder stblr = new StringBuilder();
                //stblr.Append("<table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='50%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='20%' alt='IIL Home'/></td></tr><tr><td align='justify' valign='top'><blockquote><font face='Arial' size='2'>"       + body +       "</font></blockquote><br /><hr /><br /><blockquote><font face='Arial' size='1' color='MidnightBlue'><center>This is an automated system generated mail. Please don’t reply to this mail.</center></font></blockquote></td></tr></table></td></tr></table>");
                stblr.Append("<center><table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='80%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='30%' alt='IIL Home'/></td></tr><tr><td align='center' valign='top'><blockquote><font face='Arial' size='2'><br />" + body + "<br /></font></blockquote><br /><hr /><br /><blockquote><center><font face='Arial' size='1' color='MidnightBlue'>This is an automated system generated mail. Please don’t reply to this mail.</font></center></blockquote></td></tr></table></td></tr></table></center>");
                mmsg.Body = stblr.ToString(); //body;
                mmsg.IsBodyHtml = true;

                if (fname != "0")
                {
                    mmsg.Attachments.Add(new System.Net.Mail.Attachment(fname));
                }

                if (mmsg.To.Count > 0 && (!string.IsNullOrEmpty(mmsg.Subject) || !string.IsNullOrEmpty(mmsg.Body)))
                {
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("iilemailadmin@indimmune.com", "Zon50749");
                    client.Port = 587;
                    client.Host = "smtp.office365.com";
                    client.EnableSsl = true;
                    client.Send(mmsg);
                    mailFlag = true;

                    WriteLog(0, "---SendMail : mail sent to : " + email + "_" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    //return true;
                }
            }
            catch (Exception ex)
            {
                mailFlag = false;
                WriteLog(1, "Exception :" + ex.Message + "---SendMail Error--- to : " + email + "_" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void SendMailECommOld(string email, string subject, string body, string fname, string from, string cc)
        {
            try
            {
                MailMessage mmsg = new MailMessage();
                mmsg.From = from != "0" ? from : "iilonline@indimmune.com";
                mmsg.To = email;
                if (cc != "0")
                {
                    mmsg.Cc = cc;
                }
                if (mmsg.To != ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString())
                {
                    mmsg.Bcc = ConfigurationSettings.AppSettings["SendMailAdminBcc"].ToString();
                }
                mmsg.Subject = subject;
                StringBuilder stblr = new StringBuilder();
                //stblr.Append("<table border='0' width='100%' cellpadding='5' cellspacing='5' bgcolor ='FFFFFF'><tr><td valign='top' align='center'><table border='5' bordercolor = 'SKYBLUE' width='50%' cellspacing='0' cellpadding='10' bgcolor = 'FFFFFF'><tr><td align= 'center' valign='middle'><img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG' width='20%' alt='IIL Home'/></td></tr><tr><td align='justify' valign='top'><blockquote><font face='Arial' size='2'><br />" + body + "<br /></font></blockquote><br /><hr /><br /><blockquote><center><font face='Arial' size='1' color='MidnightBlue'>This is an automated system generated mail. Please don’t reply to this mail.</font></center></blockquote></td></tr></table></td></tr></table>");
                mmsg.Body = body;
                mmsg.BodyFormat = MailFormat.Html;
                if (fname != "0")
                {
                    mmsg.Attachments.Add(new MailAttachment(fname));
                }
                if (mmsg.To != "" && (mmsg.Subject != "" || mmsg.Body != ""))
                {
                    SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["MailServer"].ToString();
                    SmtpMail.Send(mmsg);
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---SendMailEComm---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        private void SendEnggHlpDskMail(string Body, string email)
        {
            try
            {
                string desclairm = "This e-mail and any files transmitted with it are for the sole use of the intended recipient(s) and may contain confidential and privileged information.If you are not the intended recipient, please contact the sender by reply e-mail and  destroy all copies and the original message. Any unauthorized review, use, disclosure,dissemination, forwarding, printing or copying of this email or any action taken in reliance on this e-mail is strictly prohibited and may be unlawful. Before opening any attachments please check them for viruses and defects.";
                string Subject = "Helpdesk Ticket Allocated in IILHome.";
                StringBuilder stblr = new StringBuilder();
                //if (objMailBE.flag == 1)
                //stblr.Append("<table border='0' width='100%' cellspacing='5' cellpadding='50'  bgcolor ='FFFFFF'><tr><td align='center' valign='top'><table border='5' bordercolor = 'SKYBLUE' width='100%' cellspacing='0' cellpadding='10'  bgcolor = 'FFFFFF'><tr> <td align= 'center' valign='middle'> <img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG'/></td></tr><tr><td align= 'left'><blockquote><font face='Arial' size='2' >" + objMailBE.Body + "</font></blockquote></td></tr><tr><td><font face='Arial' size='1' color='MidnightBlue'><center> This is an automated system generated mail, in case of any discrepancy please report immediately.</center><p align='left'><b>Disclaimer:</b>" + desclairm + "</p></font></td></tr></table></td></tr></table>");
                //else
                stblr.Append("<table border='0' width='100%' cellspacing='5' cellpadding='50'  bgcolor ='FFFFFF'><tr><td align='center' valign='top'><table border='5' bordercolor = 'SKYBLUE' width='80%' cellspacing='0' cellpadding='10'  bgcolor = 'FFFFFF'><tr> <td align= 'center' valign='middle'> <img src='https://starvac.indimmune.com/Images/IILHome_Logo_RZ.PNG'/></td></tr><tr><td align= 'left'><blockquote><font face='Arial' size='2' >" + Body + "</font></blockquote></td></tr><tr><td><font face='Arial' size='1' color='MidnightBlue'><center> This is an automated system generated mail, in case of any discrepancy please report immediately.</center><p align='left'><b>Disclaimer:</b>" + desclairm + "</p></font></td></tr></table></td></tr></table>");
                MailMessage mmsg = new MailMessage();
                mmsg.From = "iilwebadmin@indimmune.com";
                mmsg.To = email;

                mmsg.Subject = Subject;
                mmsg.Body = stblr.ToString();

                mmsg.BodyFormat = MailFormat.Html;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["MailServer"].ToString();
                if (mmsg.To != "" && (mmsg.Subject != "" || mmsg.Body != ""))
                {
                    SmtpMail.Send(mmsg);
                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---SendMailEComm---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }
        /// <summary>
        /// Secrete PIN number for MEssanger Dispatches
        /// </summary>
        protected void GetInvoice()
        {
            SqlConnection mycon = new SqlConnection(ConfigurationSettings.AppSettings["connection"]);
            SqlCommand mycommand = new SqlCommand();
            DataSet dslr = new DataSet();
            DataSet dsUser = new DataSet();
            try
            {
                //string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "iildev"; Dest[2] = "p@$$@dev";
                string[] Dest = new string[3]; Dest[0] = "PRD_000"; Dest[1] = "HOIT12"; Dest[2] = "Itdev#13";
                string Table;
                mycommand = new SqlCommand("USP_EC_InvoiceDet", mycon);
                mycommand.Parameters.Add(new SqlParameter("@Flag", "1"));
                mycommand.CommandType = CommandType.StoredProcedure;
                mycommand.CommandTimeout = 20000;
                SqlDataAdapter myAdapter = new SqlDataAdapter(mycommand);
                mycommand.Connection.Open();
                myAdapter.Fill(dslr, "ds");
                mycommand.Connection.Close();
                SAPService s = new SAPService(ConfigurationSettings.AppSettings["SAPWebServiceURL"]);
                s.Timeout = 999999999;
                DataSet obj = new DataSet();
                DataTable dt1 = new DataTable();
                obj.Tables.Add(dslr.Tables[0].Copy());
                XmlDocument xDoc = XMLSerializerBL.Serialize(obj, XMLSerializerBL.InputType.DataSet);
                // XmlDocument xDoc = XMLSerializerBL.Serialize(input, XMLSerializerBL.InputType.List);
                XmlNode xmlException = null;
                //XmlElement xDocTable = (XmlElement)s.GetInvoiceDet(xDoc,Dest,out xmlException);
                XmlElement xDocTable = (XmlElement)s.GetInvoiceDet(xDoc, Dest, out xmlException);
                List<string> SAPError = (List<string>)XMLSerializerBL.Deserialize(xmlException.OuterXml, XMLSerializerBL.OutputType.List);
                if (SAPError[0] == "1000")
                {
                    dsUser = (DataSet)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataSet);
                    string xmls1 = "";
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtDeT = dsUser.Tables[0].Copy();
                        StringWriter sbLR = new StringWriter();
                        dtDeT.TableName = "Invoice";
                        using (StringWriter sw = new StringWriter())
                        {
                            dtDeT.WriteXml(sw);
                            xmls1 = sw.ToString();
                        }
                    }

                    mycommand = new SqlCommand("USP_EC_InvoiceDet", mycon);
                    mycommand.Parameters.Add(new SqlParameter("@FLAG", "2"));
                    mycommand.Parameters.Add(new SqlParameter("@XMLInvoice", xmls1));
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.CommandTimeout = 20000;
                    myAdapter = new SqlDataAdapter(mycommand);
                    mycommand.Connection.Open();
                    myAdapter.Fill(dslr, "ds");
                    mycommand.Connection.Close();

                }
            }
            catch (Exception ex)
            {
                WriteLog(1, "Exception :" + ex.Message + "---Secrete PIN number for MEssanger---" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            finally
            {
                if (mycommand.Connection.State == ConnectionState.Open)
                    mycommand.Connection.Close();
            }

        }

        #endregion

        #region EncryptDecryptCL
        private static class EncryptDecryptCL
        {
            static string _Phrase = "IIL"; //Be careful storing this in code unless it’s secured and not distributed
            static byte[] _Salt = new byte[] { 0x45, 0xF1, 0x61, 0x6e, 0x20, 0x00, 0x65, 0x64, 0x76, 0x65, 0x64, 0x03, 0x76 };

            public static string Decrypt(string cipherText)
            {
                try
                {
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_Phrase, _Salt);
                    byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                    return System.Text.Encoding.Unicode.GetString(decryptedData);
                }
                catch
                {
                    return cipherText;
                }
            }

            private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
            {
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = null;
                try
                {
                    Rijndael alg = Rijndael.Create();
                    alg.Key = Key;
                    alg.IV = IV;
                    cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(cipherData, 0, cipherData.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cs.Close();
                }
            }

            public static string Encrypt(string clearText)
            {
                try
                {
                    byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_Phrase, _Salt);
                    byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                    return Convert.ToBase64String(encryptedData);
                }
                catch
                {
                    return clearText;
                }
            }

            private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
            {
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = null;
                try
                {
                    Rijndael alg = Rijndael.Create();
                    alg.Key = Key;
                    alg.IV = IV;
                    cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(clearData, 0, clearData.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cs.Close();
                }
            }
        }
        #endregion

        private void evtLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
