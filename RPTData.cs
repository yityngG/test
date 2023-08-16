//#define GenerateDataSet
using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CPS.DBWrapper;

namespace PCS.Report
{
	/// <summary>
	/// Summary description for RPTData.
	/// </summary>
	public class RPTData : DBConnection
	{
		#region Constructor
		public RPTData()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion Constructor

		internal void Get_DayEndBalancing(ReportDocument oDoc, long lTerminalID, long lLocationID, DateTime dtTradingDate, 
			long lTradingCurrency, int iReportType)
		{
			DataSet dsResult;
			ClearParameters();
			AddParameter("@TerminalID", SqlDbType.BigInt, (lTerminalID == 0? (object) DBNull.Value: lTerminalID));
			AddParameter("@LocationID", SqlDbType.BigInt, (lLocationID == 0? (object) DBNull.Value: lLocationID));
			AddParameter("@TradingDate", SqlDbType.DateTime, dtTradingDate);
			AddParameter("@TradingCurrencyID", SqlDbType.BigInt, lTradingCurrency == -1? (object) DBNull.Value: lTradingCurrency);
			AddParameter("@ReportType", SqlDbType.Int, iReportType);
			dsResult = ExecuteDataset("PCS_R_S_DayShiftEndBalancing");
#if GenerateDataSet
			dsResult.WriteXmlSchema(@"..\..\..\PCS.Report\XSD\dsDayShiftEndBalance.xsd");
#endif
			oDoc.SetDataSource(dsResult.Tables[0]);
		}

		internal void Get_ShiftEndBalancing(ReportDocument oDoc, long lTerminalID, long lLocationID, DateTime dtTradingDate, int iShiftNo,
			long lTradingCurrency, int iReportType)
		{
			DataSet dsResult;
			ClearParameters();
			AddParameter("@TerminalID", SqlDbType.BigInt, (lTerminalID == 0? (object) DBNull.Value: lTerminalID));
			AddParameter("@LocationID", SqlDbType.BigInt, (lLocationID == 0? (object) DBNull.Value: lLocationID));
			AddParameter("@ShiftNo", SqlDbType.Int, iShiftNo);
			AddParameter("@TradingDate", SqlDbType.DateTime, dtTradingDate);
			AddParameter("@TradingCurrencyID", SqlDbType.BigInt, lTradingCurrency == -1? (object) DBNull.Value: lTradingCurrency);
			AddParameter("@ReportType", SqlDbType.Int, iReportType);
			dsResult = ExecuteDataset("PCS_R_S_DayShiftEndBalancing");
#if GenerateDataSet
			dsResult.WriteXmlSchema(@"..\..\..\PCS.Report\XSD\dsDayShiftEndBalance.xsd");
#endif
			oDoc.SetDataSource(dsResult.Tables[0]);
		}

		internal void Get_PlayerDepositListing(ReportDocument oDoc, DateTime dtTradingDateFrom, DateTime dtTradingDateTo, 
			string strCardID, string strCustID, long lTerminalID, long lLocationID)
		{
			DataSet dsResult;
			ClearParameters();
			AddParameter("@TradingDateFrom", SqlDbType.DateTime, dtTradingDateFrom);
			AddParameter("@TradingDateTo", SqlDbType.DateTime, dtTradingDateTo);
			AddParameter("@CardID", SqlDbType.NVarChar, strCardID == String.Empty? (object) DBNull.Value: strCardID);
			AddParameter("@CustID", SqlDbType.NVarChar, strCustID == String.Empty? (object) DBNull.Value: strCustID);
			AddParameter("@TerminalID", SqlDbType.BigInt, (lTerminalID == 0? (object) DBNull.Value: lTerminalID));
			AddParameter("@LocationID", SqlDbType.BigInt, (lLocationID == 0? (object) DBNull.Value: lLocationID));
			dsResult = ExecuteDataset("PCS_R_S_PlayerDepositListing");
#if GenerateDataSet
			dsResult.WriteXmlSchema(@"..\..\..\PCS.Report\XSD\dsPlayerDepositListing.xsd");
#endif
			oDoc.SetDataSource(dsResult.Tables[0]);
		}

		internal void Get_PlayerWithdrawalListing(ReportDocument oDoc, DateTime dtTradingDateFrom, DateTime dtTradingDateTo, 
			string strCardID, string strCustID, long lTerminalID, long lLocationID)
		{
			DataSet dsResult;
			ClearParameters();
			AddParameter("@TradingDateFrom", SqlDbType.DateTime, dtTradingDateFrom);
			AddParameter("@TradingDateTo", SqlDbType.DateTime, dtTradingDateTo);
			AddParameter("@CardID", SqlDbType.NVarChar, strCardID == String.Empty? (object) DBNull.Value: strCardID);
			AddParameter("@CustID", SqlDbType.NVarChar, strCustID == String.Empty? (object) DBNull.Value: strCustID);
			AddParameter("@TerminalID", SqlDbType.BigInt, (lTerminalID == 0? (object) DBNull.Value: lTerminalID));
			AddParameter("@LocationID", SqlDbType.BigInt, (lLocationID == 0? (object) DBNull.Value: lLocationID));
			dsResult = ExecuteDataset("PCS_R_S_PlayerWithdrawalListing");
#if GenerateDataSet
			dsResult.WriteXmlSchema(@"..\..\..\PCS.Report\XSD\dsPlayerWithdrawalListing.xsd");
#endif
			oDoc.SetDataSource(dsResult.Tables[0]);
		}

		internal void Get_CardTypeAllowed(ReportDocument oDoc, long lgCTAID)
		{
			DataSet dsResult;
			ClearParameters();
			AddParameter("@CTAID", SqlDbType.BigInt, (lgCTAID == -1? (object) DBNull.Value: lgCTAID));			
			dsResult = ExecuteDataset("PCS_R_S_CardTypeAllowed");
#if GenerateDataSet
			dsResult.WriteXmlSchema(@"..\..\..\PCS.Report\XSD\dsCardTypeAllowed.xsd");
#endif
			oDoc.SetDataSource(dsResult.Tables[0]);
		}

		internal void Get_PrincipalCardTypeAllowed(ReportDocument oDoc, long lgPCTAID)
		{
			DataSet dsResult;
			ClearParameters();
			AddParameter("@PCTAID", SqlDbType.BigInt, (lgPCTAID == -1? (object) DBNull.Value: lgPCTAID));
			dsResult = ExecuteDataset("PCS_R_S_PrincipalCardTypeAllowed");
#if GenerateDataSet
			dsResult.WriteXmlSchema(@"..\..\..\PCS.Report\XSD\dsPrincipalCardTypeAllowed.xsd");
#endif
			oDoc.SetDataSource(dsResult.Tables[0]);
		}
	}
}
