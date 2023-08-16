using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CommonRptBase;
using CPS.Common;
using CPS.BS;

namespace PCS.Report.Forms
{
	/// <summary>
	/// Summary description for frmRptVwShiftEndBalancing.
	/// </summary>
	public class frmRptVwShiftEndBalancing : frmReportBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private RPTInterfacePCS oRpt = new RPTInterfacePCS();
		//public string strReportOption = "PCS_ReportRecordOption";

		#region Constructor
		public frmRptVwShiftEndBalancing()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			base.ReportID = "PCS_RPTShiftEndBalancing";
			//base.bShowProgramCode = true;
			base.bShowLocation = true;
			base.bShowTerminal = true;
			base.bShowTradingDate = true;
		}
		#endregion Constructor

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
			int iShiftNo = (int)CommonMethod.CheckNull(base.GetControlValue(pnlRecordRange, "uscShiftNo", ControlType.LabelTextButton), DataType.IntegerType);

			BSShift oBSShift = new BSShift();
			oBSShift.GetShift(base.lngTerminalID, iShiftNo, base.dtTradingDate);

			base.oParamFields.Add("ShiftNo", iShiftNo.ToString());
			base.oParamFields.Add("ShiftOpenOn", oBSShift.ShiftStart.ToString(Settings.DateTimeFormat));
			base.oParamFields.Add("ShiftCloseOn", (oBSShift.ShiftClose == DateTime.MinValue? "N/A": oBSShift.ShiftClose.ToString(Settings.DateTimeFormat)));

			long lTradingCurrency = long.Parse(CommonMethod.CheckNull(base.GetControlValue(pnlRecordRange, "uscTradingCurrency", ControlType.LabelTextButton), DataType.IntegerType).ToString());
			string sTradingCurrency = CommonMethod.CheckNull(base.GetControlText(pnlRecordRange, "uscTradingCurrency", ControlType.LabelTextButton), DataType.StringType).ToString();
			base.oParamFields.Add("TradingCurrency", (sTradingCurrency==""? "ALL" : sTradingCurrency));

			int iReportType = 0;

			// To share a single .rpt file with day end balancing report
			oRpt.sOverrideReportID = "RPTDayShiftEndBalancing";
			oRpt.View_ShiftEndBalancing(base.ReportID, base.oParamFields, base.oReportHeaderParamFields, base.lngTerminalID, base.lngLocationID, base.dtTradingDate, iShiftNo, lTradingCurrency, iReportType);
		}
	}
}
