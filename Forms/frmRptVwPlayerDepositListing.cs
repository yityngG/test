using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CommonRptBase;
using CPS.Common;

namespace PCS.Report.Forms
{
	/// <summary>
	/// Summary description for frmRptVwPlayerDepositListing.
	/// </summary>
	public class frmRptVwPlayerDepositListing : frmReportBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private RPTInterfacePCS oRpt = new RPTInterfacePCS();
		private string strPrepaidCardID = "Card ID";

		#region Construtor
		public frmRptVwPlayerDepositListing()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			base.ReportID = "PCS_RPTPlayerDepositListing";
			
			CPS.BS.Maintenance.BSSCRTParameter oBSSCRT = new CPS.BS.Maintenance.BSSCRTParameter();
			DataSet ds = new DataSet();
			ds = oBSSCRT.GetSCRTParameterByParamOption("PCS");
			if(ds.Tables[0].Rows.Count != 0)
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					switch(dr["paramType"].ToString())
					{
						case "PrepaidCardID":
							strPrepaidCardID = dr["paramCode"].ToString();
							break;
					}
				}
			}
		}
		#endregion Construtor

		#region Resources Clean Up
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion Resources Clean Up

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(800,600);
			this.Text = "Casino Marketing Treasury System";
		}
		#endregion

		protected override void HandleReport()
		{
			DateTime dtTradingDateFrom = (DateTime)CommonMethod.CheckNull(base.GetControlValue(pnlRecordRange, "uscTradingDateFrom", ControlType.LabelDateTimePicker), DataType.DateTimeType);
			DateTime dtTradingDateTo = (DateTime)CommonMethod.CheckNull(base.GetControlValue(pnlRecordRange, "uscTradingDateTo", ControlType.LabelDateTimePicker), DataType.DateTimeType);
			string strCardID = CommonMethod.CheckNull(base.GetControlText(pnlRecordRange, "uscCardID", ControlType.LabelTextBox), DataType.StringType).ToString();
			string strCustID = CommonMethod.CheckNull(base.GetControlText(pnlRecordRange, "uscDRSID", ControlType.LabelTextBox), DataType.StringType).ToString();
			long lTMID = (long)CommonMethod.CheckNull(GetControlValue(pnlRecordRange, "uscTerminal", ControlType.LabelTextButton), DataType.LongType);
			string strTerminalCode = CommonMethod.CheckNull(base.GetControlText(pnlRecordRange, "uscTerminal", ControlType.LabelTextButton), DataType.StringType).ToString();
			long lLHID = (long)CommonMethod.CheckNull(GetControlValue(pnlRecordRange, "uscGroupLocation", ControlType.LabelTextButton), DataType.LongType);
			string strLocationCode = CommonMethod.CheckNull(base.GetControlText(pnlRecordRange, "uscGroupLocation", ControlType.LabelTextButton), DataType.StringType).ToString();

			base.oParamFields.Add("PrepaidCardID", strPrepaidCardID);
			base.oParamFields.Add("TradingDateFrom", dtTradingDateFrom.ToString(Settings.DateFormat));
			base.oParamFields.Add("TradingDateTo", dtTradingDateTo.ToString(Settings.DateFormat));
			base.oParamFields.Add("CardID", (strCardID==""? "ALL" : strCardID));
			base.oParamFields.Add("CustID", (strCustID==""? "ALL" : strCustID));
			base.oParamFields.Add("TerminalCode", (strTerminalCode==""? "ALL" : strTerminalCode));
			base.oParamFields.Add("LocationCode", (strLocationCode==""? "ALL" : strLocationCode));

			oRpt.View_PlayerDepositListing(base.ReportID, base.oParamFields, base.oReportHeaderParamFields, 
				dtTradingDateFrom, dtTradingDateTo, strCardID, strCustID, lTMID, lLHID);
		}
	}
}
