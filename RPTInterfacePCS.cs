using System;
using System.Collections;
using System.Reflection;
using CommonRptBase;
using PCS.BS;

namespace PCS.Report
{
	/// <summary>
	/// Summary description for RPTInterfacePCS.
	/// </summary>
	public class RPTInterfacePCS: RPTInterface
	{
		private RPTData objDB = new RPTData();
		private Assembly oAssembly = Assembly.GetExecutingAssembly();

		#region Constructor
		public RPTInterfacePCS(): base()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		public void View_DayEndBalancing(string sReportID, SortedList oReportParamFields, SortedList oSubReportParamFields, long lTerminalID, long lLocationID, 
			DateTime dtTradingDate, long lTradingCurrency, int iReportType)
		{
			base.SetupReportForViewing(oAssembly, sReportID, ReportHeaderType.ReportHeaderPortrait, oReportParamFields, oSubReportParamFields);
			objDB.Get_DayEndBalancing(base.doc, lTerminalID, lLocationID, dtTradingDate, lTradingCurrency, iReportType);
			base.View_Report();
		}

		public void View_ShiftEndBalancing(string sReportID, SortedList oReportParamFields, SortedList oSubReportParamFields, long lTerminalID, long lLocationID, 
			DateTime dtTradingDate, int iShiftNo, long lTradingCurrency, int iReportType)
		{
			base.SetupReportForViewing(oAssembly, sReportID, ReportHeaderType.ReportHeaderPortrait, oReportParamFields, oSubReportParamFields);
			objDB.Get_ShiftEndBalancing(base.doc, lTerminalID, lLocationID, dtTradingDate, iShiftNo, lTradingCurrency, iReportType);
			base.View_Report();
		}

		public void View_PlayerDepositListing(string sReportID, SortedList oReportParamFields, SortedList oSubReportParamFields, 
			DateTime dtTradingDateFrom, DateTime dtTradingDateTo, string strCardID, string strCustID, long lTerminalID, long lLocationID)
		{
			base.SetupReportForViewing(oAssembly, sReportID, ReportHeaderType.ReportHeaderLandscape, oReportParamFields, oSubReportParamFields);
			objDB.Get_PlayerDepositListing(base.doc, dtTradingDateFrom, dtTradingDateTo, strCardID, strCustID, lTerminalID, lLocationID);
			base.SetDefaultParameterValue(ref base.doc, false, true, false, false, false, true, true, false);
			base.View_Report();
		}

		public void View_PlayerWithdrawalListing(string sReportID, SortedList oReportParamFields, SortedList oSubReportParamFields, 
			DateTime dtTradingDateFrom, DateTime dtTradingDateTo, string strCardID, string strCustID, long lTerminalID, long lLocationID)
		{
			base.SetupReportForViewing(oAssembly, sReportID, ReportHeaderType.ReportHeaderLandscape, oReportParamFields, oSubReportParamFields);
			objDB.Get_PlayerWithdrawalListing(base.doc, dtTradingDateFrom, dtTradingDateTo, strCardID, strCustID, lTerminalID, lLocationID);
			base.SetDefaultParameterValue(ref base.doc, false, true, false, false, false, true, true, false);
			base.View_Report();
		}

		public void View_CardTypeAllowed(long lgCTAID)
		{
			SortedList oReportHeaderParamFields = GetReportHeaderInfo("Card Type Allowed Report", false, true, true, true);
			SortedList oReportParamFields = new SortedList();
			//string strReprint = String.Empty;
			//oReportParamFields.Add("Reprint", strReprint);
			base.SetupReportForViewing(oAssembly,"RPTCardTypeAllowed", ReportHeaderType.ReportHeaderPortrait, oReportParamFields, oReportHeaderParamFields);
			objDB.Get_CardTypeAllowed(base.doc, lgCTAID);
			base.View_Report(); 
		}

		public void View_PrincipalCardTypeAllowed(long lgPCTAID)
		{
			SortedList oReportHeaderParamFields = GetReportHeaderInfo("Principal Card Type Allowed Report", false, true, true, true);
			SortedList oReportParamFields = new SortedList();			
			base.SetupReportForViewing(oAssembly,"RPTPrincipalCardTypeAllowed", ReportHeaderType.ReportHeaderPortrait, oReportParamFields, oReportHeaderParamFields);
			objDB.Get_PrincipalCardTypeAllowed(base.doc, lgPCTAID);
			base.SetDefaultParameterValue(ref base.doc,false,false,false,false,false,false,true,false);
			base.View_Report(); 
		}
	}
}
