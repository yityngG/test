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
	/// Summary description for frmRptVwDayEndBalancing.
	/// </summary>
	public class frmRptVwDayEndBalancing : frmReportBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private RPTInterfacePCS oRpt = new RPTInterfacePCS();
		//public string strReportOption = "PCS_ReportRecordOption";

		#region Construtor
		public frmRptVwDayEndBalancing()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			base.ReportID = "PCS_RPTDayEndBalancing";
			//base.bShowProgramCode = true;
			base.bShowLocation = true;
			base.bShowTerminal = true;
			base.bShowTradingDate = true;
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
			base.oParamFields.Add("ShiftNo", "");
			base.oParamFields.Add("ShiftOpenOn", "");
			base.oParamFields.Add("ShiftCloseOn", "");

			long lTradingCurrency = long.Parse(CommonMethod.CheckNull(base.GetControlValue(pnlRecordRange, "uscTradingCurrency", ControlType.LabelTextButton), DataType.IntegerType).ToString());
			string sTradingCurrency = CommonMethod.CheckNull(base.GetControlText(pnlRecordRange, "uscTradingCurrency", ControlType.LabelTextButton), DataType.StringType).ToString();
			base.oParamFields.Add("TradingCurrency", (sTradingCurrency==""? "ALL" : sTradingCurrency));
			int iReportType = 0;

			oRpt.sOverrideReportID = "RPTDayShiftEndBalancing";
			oRpt.View_DayEndBalancing(base.ReportID, base.oParamFields, base.oReportHeaderParamFields, base.lngTerminalID, base.lngLocationID, base.dtTradingDate, lTradingCurrency, iReportType);
		}
	}
}
