using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace PepsiLiteDataAccess
{
    public static class DataOperations
    {
        public static bool InsertTanDetails(string _tannumber,string _structure,string _molformula,double _molweight,
                                            string _iupacname,int _pagenum,string _pagelabel,string _examplenum,string _tablenum,
                                            string _enname, string _inchikey, DateTime _createdon, int _createdby, int _usrroleid, string _identifier, out int out_tan_dtl_id)
        {
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();
                
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = pgCon;
                cmd.CommandText = "pepsilite.insert_tan_details";
                cmd.CommandType = CommandType.StoredProcedure;
                
                NpgsqlParameter paramTanID = new NpgsqlParameter();
                paramTanID.ParameterName = "p_tan";
                paramTanID.DbType = DbType.String;
                paramTanID.Value = _tannumber;
                cmd.Parameters.Add(paramTanID);

                NpgsqlParameter paramStructure = new NpgsqlParameter();
                paramStructure.ParameterName = "p_structure";
                paramStructure.DbType = DbType.String;
                paramStructure.Value = _structure;
                cmd.Parameters.Add(paramStructure);

                NpgsqlParameter paramMolFormula = new NpgsqlParameter();
                paramMolFormula.ParameterName = "p_molformula";
                paramMolFormula.DbType = System.Data.DbType.String;
                paramMolFormula.Value = _molformula;
                cmd.Parameters.Add(paramMolFormula);
                
                NpgsqlParameter paramnMolWeight = new NpgsqlParameter();
                paramnMolWeight.ParameterName = "p_molweight";
                paramnMolWeight.DbType = System.Data.DbType.Double;
                paramnMolWeight.Value = _molweight;
                cmd.Parameters.Add(paramnMolWeight);
                
                NpgsqlParameter paramIUPAC = new NpgsqlParameter();
                paramIUPAC.ParameterName = "p_iupacname";
                paramIUPAC.DbType = System.Data.DbType.String;
                paramIUPAC.Value = _iupacname;
                cmd.Parameters.Add(paramIUPAC);
                
                NpgsqlParameter paramPageNum = new NpgsqlParameter();
                paramPageNum.ParameterName = "p_pagenumber";
                paramPageNum.DbType = System.Data.DbType.Int32;
                paramPageNum.Value = _pagenum;
                cmd.Parameters.Add(paramPageNum);
                
                NpgsqlParameter paramPageLabel = new NpgsqlParameter();
                paramPageLabel.ParameterName = "p_pagelabel";
                paramPageLabel.DbType = System.Data.DbType.String;
                paramPageLabel.Value = _pagelabel;
                cmd.Parameters.Add(paramPageLabel);

                NpgsqlParameter paramExampleNum = new NpgsqlParameter();
                paramExampleNum.ParameterName = "p_examplenumber";
                paramExampleNum.DbType = System.Data.DbType.String;
                paramExampleNum.Value = _examplenum;
                cmd.Parameters.Add(paramExampleNum);

                NpgsqlParameter paramTableNum = new NpgsqlParameter();
                paramTableNum.ParameterName = "p_tablenumber";
                paramTableNum.DbType = System.Data.DbType.String;
                paramTableNum.Value = _tablenum;
                cmd.Parameters.Add(paramTableNum);
                
                NpgsqlParameter paramEnName = new NpgsqlParameter();
                paramEnName.ParameterName = "p_enname";
                paramEnName.DbType = System.Data.DbType.String;
                paramEnName.Value = _enname;
                cmd.Parameters.Add(paramEnName);

                NpgsqlParameter paramInchi = new NpgsqlParameter();
                paramInchi.ParameterName = "p_inchikey";
                paramInchi.DbType = System.Data.DbType.String;
                paramInchi.Value = _inchikey;
                cmd.Parameters.Add(paramInchi);

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_createdon";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                cmd.Parameters.Add(paramCreatedOn);

                NpgsqlParameter paramCreatedBy = new NpgsqlParameter();
                paramCreatedBy.ParameterName = "p_createdby";
                paramCreatedBy.DbType = System.Data.DbType.Int32;
                paramCreatedBy.Value = _createdby;
                cmd.Parameters.Add(paramCreatedBy);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_usrroleid";
                paramUserRole.DbType = System.Data.DbType.Int32;
                paramUserRole.Value = _usrroleid;
                cmd.Parameters.Add(paramUserRole);

                NpgsqlParameter paramID = new NpgsqlParameter();
                paramID.ParameterName = "p_id";
                paramID.DbType = System.Data.DbType.String;
                paramID.Value = _identifier;
                cmd.Parameters.Add(paramID);

                NpgsqlParameter paramTanDtlID = new NpgsqlParameter();
                paramTanDtlID.ParameterName = "po_tan_dtl_id";
                paramTanDtlID.DbType = System.Data.DbType.Int32;
                paramTanDtlID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramTanDtlID);

                pgCon.Open();
                cmd.ExecuteNonQuery();

                out_tan_dtl_id = Convert.ToInt32(paramTanDtlID.Value);
                return true;
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            out_tan_dtl_id = 0;
            return false;
        }

        public static bool UpdateTanDetails(string _tannumber,int _tandtlsid, string _structure, string _molformula, double _molweight,
                                           string _iupacname, int _pagenum, string _pagelabel, string _examplenum,
                                           string _tablenum, string _enname, string _inchikey, DateTime _modifiedon,
                                           int _modifiedby)
        {
            bool blStatus = false;
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = pgCon;
                cmd.CommandText = "pepsilite.update_tan_details";
                cmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTanID = new NpgsqlParameter();
                paramTanID.ParameterName = "p_tan";
                paramTanID.DbType = DbType.String;
                paramTanID.Value = _tannumber;
                cmd.Parameters.Add(paramTanID);

                NpgsqlParameter paramTanDtlsID = new NpgsqlParameter();
                paramTanDtlsID.ParameterName = "p_tan_dtls_id";
                paramTanDtlsID.DbType = DbType.Int32;
                paramTanDtlsID.Value = _tandtlsid;
                cmd.Parameters.Add(paramTanDtlsID);

                NpgsqlParameter paramStructure = new NpgsqlParameter();
                paramStructure.ParameterName = "p_structure";
                paramStructure.DbType = System.Data.DbType.String;
                paramStructure.Value = _structure;
                cmd.Parameters.Add(paramStructure);

                NpgsqlParameter paramMolFormula = new NpgsqlParameter();
                paramMolFormula.ParameterName = "p_molformula";
                paramMolFormula.DbType = System.Data.DbType.String;
                paramMolFormula.Value = _molformula;
                cmd.Parameters.Add(paramMolFormula);

                NpgsqlParameter paramnMolWeight = new NpgsqlParameter();
                paramnMolWeight.ParameterName = "p_molweight";
                paramnMolWeight.DbType = System.Data.DbType.Double;
                paramnMolWeight.Value = _molweight;
                cmd.Parameters.Add(paramnMolWeight);

                NpgsqlParameter paramIUPAC = new NpgsqlParameter();
                paramIUPAC.ParameterName = "p_iupacname";
                paramIUPAC.DbType = System.Data.DbType.String;
                paramIUPAC.Value = _iupacname;
                cmd.Parameters.Add(paramIUPAC);

                NpgsqlParameter paramPageNum = new NpgsqlParameter();
                paramPageNum.ParameterName = "p_pagenumber";
                paramPageNum.DbType = System.Data.DbType.Int32;
                paramPageNum.Value = _pagenum;
                cmd.Parameters.Add(paramPageNum);

                NpgsqlParameter paramPageLabel = new NpgsqlParameter();
                paramPageLabel.ParameterName = "p_pagelabel";
                paramPageLabel.DbType = System.Data.DbType.String;
                paramPageLabel.Value = _pagelabel;
                cmd.Parameters.Add(paramPageLabel);

                NpgsqlParameter paramExampleNum = new NpgsqlParameter();
                paramExampleNum.ParameterName = "p_examplenumber";
                paramExampleNum.DbType = System.Data.DbType.String;
                paramExampleNum.Value = _examplenum;
                cmd.Parameters.Add(paramExampleNum);

                NpgsqlParameter paramTableNum = new NpgsqlParameter();
                paramTableNum.ParameterName = "p_tablenumber";
                paramTableNum.DbType = System.Data.DbType.String;
                paramTableNum.Value = _tablenum;
                cmd.Parameters.Add(paramTableNum);

                NpgsqlParameter paramEnName = new NpgsqlParameter();
                paramEnName.ParameterName = "p_enname";
                paramEnName.DbType = System.Data.DbType.String;
                paramEnName.Value = _enname;
                cmd.Parameters.Add(paramEnName);

                NpgsqlParameter paramInchi = new NpgsqlParameter();
                paramInchi.ParameterName = "p_inchikey";
                paramInchi.DbType = System.Data.DbType.String;
                paramInchi.Value = _inchikey;
                cmd.Parameters.Add(paramInchi);

                NpgsqlParameter paramModifiedOn = new NpgsqlParameter();
                paramModifiedOn.ParameterName = "p_modifiedon";
                paramModifiedOn.DbType = System.Data.DbType.Date;
                paramModifiedOn.Value = _modifiedon;
                cmd.Parameters.Add(paramModifiedOn);

                NpgsqlParameter paramModifiedBy = new NpgsqlParameter();
                paramModifiedBy.ParameterName = "p_modifiedby";
                paramModifiedBy.DbType = System.Data.DbType.Int32;
                paramModifiedBy.Value = _modifiedby;
                cmd.Parameters.Add(paramModifiedBy);

                pgCon.Open();
                cmd.ExecuteNonQuery();

                blStatus = true;
                return blStatus;
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return blStatus;
        }

        public static DataTable GetTANDetailsOnUserIDAndRoleID(string _tanNumber, int _userid,int _roleid)
        {            
            DataSet dsTanDetails = new DataSet();
            try
            {
                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_tan_details_on_userid_roleid";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTANID = new NpgsqlParameter();
                paramTANID.ParameterName = "p_tan";
                paramTANID.DbType = DbType.String;
                paramTANID.Value = _tanNumber;
                pgSqlCmd.Parameters.Add(paramTANID);

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_userid";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID);

                NpgsqlParameter paramRoleID = new NpgsqlParameter();
                paramRoleID.ParameterName = "p_usrroleid";
                paramRoleID.DbType = DbType.Int32;
                paramRoleID.Value = _roleid;
                pgSqlCmd.Parameters.Add(paramRoleID);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsTanDetails);

                string str = dsTanDetails.Tables[0].Rows[0][0].ToString();

                string strQry = "fetch all in " + @"""" + str + @"""";

                NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                DataSet dsResults = new DataSet();
                pgSqlDtAdpt2.Fill(dsResults);
                
                 nTrans.Commit();
                 pgSqlCon.Close();

                if (dsResults != null)
                {
                    if (dsResults.Tables.Count > 0)
                    {
                        return dsResults.Tables[0];
                    }
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;

        }

        public static DataTable RetrieveTANDetails(string _tanNumber)
        {
            DataSet dsTanDetails = new DataSet();
            try
            {
                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_tan_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTANID = new NpgsqlParameter();
                paramTANID.ParameterName = "p_tan";
                paramTANID.DbType = DbType.String;
                paramTANID.Value = _tanNumber;
                pgSqlCmd.Parameters.Add(paramTANID);
                
                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsTanDetails);

                string str = dsTanDetails.Tables[0].Rows[0][0].ToString();

                string strQry = "fetch all in " + @"""" + str + @"""";

                NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                DataSet dsResults = new DataSet();
                pgSqlDtAdpt2.Fill(dsResults);

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsResults != null)
                {
                    if (dsResults.Tables.Count > 0)
                    {
                        return dsResults.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;

        }

        public static bool DeleteTANDetails(int _tanDetailsid,int _userid)
        {
            bool blStatus = false;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.delete_tan_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;
                               

                NpgsqlParameter paramTANID = new NpgsqlParameter();
                paramTANID.ParameterName = "p_tan_dtl_id";
                paramTANID.DbType = DbType.Int32;
                paramTANID.Value = _tanDetailsid;
                pgSqlCmd.Parameters.Add(paramTANID);               

                NpgsqlParameter paramTDetailsID = new NpgsqlParameter();
                paramTDetailsID.ParameterName = "p_userid";
                paramTDetailsID.DbType = DbType.Int32;
                paramTDetailsID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramTDetailsID);

                pgSqlCon.Open();
                pgSqlCmd.ExecuteScalar();
                blStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;

        }

        public static bool DeleteTANNumber(string _tanNumber)
        {
            bool blStatus = false;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.delete_tan";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTANID = new NpgsqlParameter();
                paramTANID.ParameterName = "p_tan";
                paramTANID.DbType = DbType.String;
                paramTANID.Value = _tanNumber;
                pgSqlCmd.Parameters.Add(paramTANID);            

                pgSqlCon.Open();
                pgSqlCmd.ExecuteScalar();
                blStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;
        }

        public static DataTable RetrieveTANIDS(int _userid)
        {
            try
            {
                DataSet dsTANIds = new DataSet();

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_tan_ids";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_user_id";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID); 

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsTANIds);                

                //string str = dsTANIds.Tables[0].Rows[0][0].ToString();

                //string strQry = "fetch all in " + @"""" + str + @"""";

                //NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                //DataSet dsResults = new DataSet();
                //pgSqlDtAdpt2.Fill(dsResults);

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsTANIds != null)
                {
                    if (dsTANIds.Tables.Count > 0)
                    {
                        return dsTANIds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static DataTable RetrieveAllUserNames()
        {
            try
            {
                DataSet dsUserNames = new DataSet();

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_all_user_names";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;                

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserNames);

                //string str = dsTANIds.Tables[0].Rows[0][0].ToString();

                //string strQry = "fetch all in " + @"""" + str + @"""";

                //NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                //DataSet dsResults = new DataSet();
                //pgSqlDtAdpt2.Fill(dsResults);

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsUserNames != null)
                {
                    if (dsUserNames.Tables.Count > 0)
                    {
                        return dsUserNames.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static DataTable RetrieveTANIDS_All()
        {
            try
            {
                DataSet dsTANIds = new DataSet();

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.retrieve_tan_ids_all";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;
                
                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsTANIds);

                //string str = dsTANIds.Tables[0].Rows[0][0].ToString();

                //string strQry = "fetch all in " + @"""" + str + @"""";

                //NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                //DataSet dsResults = new DataSet();
                //pgSqlDtAdpt2.Fill(dsResults);

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsTANIds != null)
                {
                    if (dsTANIds.Tables.Count > 0)
                    {
                        return dsTANIds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static DataTable GetCompletedTANs()
        {
            try
            {
                DataSet dsCompTANs = new DataSet();

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_completed_tans";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsCompTANs);               

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsCompTANs != null)
                {
                    if (dsCompTANs.Tables.Count > 0)
                    {
                        return dsCompTANs.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static DataTable RetrieveSearchResults(string _srchqry)
        {
            try
            {
                DataSet dsTANIds = new DataSet();

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_search_results";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramSrchQry = new NpgsqlParameter();
                paramSrchQry.ParameterName = "p_srch_qry";
                paramSrchQry.DbType = DbType.String;
                paramSrchQry.Value = _srchqry;
                pgSqlCmd.Parameters.Add(paramSrchQry);
                
                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsTANIds);

                string str = dsTANIds.Tables[0].Rows[0][0].ToString();

                string strQry = "fetch all in " + @"""" + str + @"""";

                NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                DataSet dsResults = new DataSet();
                pgSqlDtAdpt2.Fill(dsResults);

                nTrans.Commit();
                pgSqlCon.Close();
                               
                if (dsResults != null)
                {
                    if (dsResults.Tables.Count > 0)
                    {
                        return dsResults.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }          
            return null;
        }

        public static int RetrieveTANID_ForTAN(string _tannumber)
        {
            int intTan = 0;
            try
            {               

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_tan_id_for_tan";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTAN= new NpgsqlParameter();
                paramTAN.ParameterName = "p_tan";
                paramTAN.DbType = DbType.String;
                paramTAN.Value = _tannumber;
                pgSqlCmd.Parameters.Add(paramTAN);

                object objTan = pgSqlCmd.ExecuteScalar();

                nTrans.Commit();
                pgSqlCon.Close();

                if (objTan != null)
                {
                    intTan = Convert.ToInt32(objTan); 
                }
                return intTan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intTan;
        }

        public static int GetTANRecordCount(int _tanid)
        {
            int intRecCnt = 0;
            try
            {

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_tan_record_count";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTAN_ID = new NpgsqlParameter();
                paramTAN_ID.ParameterName = "p_tan_id";
                paramTAN_ID.DbType = DbType.Int32;
                paramTAN_ID.Value = _tanid;
                pgSqlCmd.Parameters.Add(paramTAN_ID);

                object objreccnt = pgSqlCmd.ExecuteScalar();

                nTrans.Commit();
                pgSqlCon.Close();

                if (objreccnt != null)
                {
                    intRecCnt = Convert.ToInt32(objreccnt);
                }
                return intRecCnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intRecCnt;
        }

        public static bool CheckForDuplicateStructure(string _molinchi,string _tannumber, int _tan_dtl_id)
        {
            bool blStatus = false;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.is_duplicate_structure";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramInchi = new NpgsqlParameter();
                paramInchi.ParameterName = "p_qry_mol_inchi";
                paramInchi.DbType = DbType.String;
                paramInchi.Value = _molinchi;
                pgSqlCmd.Parameters.Add(paramInchi);

                NpgsqlParameter paramTAN = new NpgsqlParameter();
                paramTAN.ParameterName = "p_tan";
                paramTAN.DbType = DbType.String;
                paramTAN.Value = _tannumber;
                pgSqlCmd.Parameters.Add(paramTAN);

                NpgsqlParameter paramTDetailsID = new NpgsqlParameter();
                paramTDetailsID.ParameterName = "p_tan_dtl_id";
                paramTDetailsID.DbType = DbType.Int32;
                paramTDetailsID.Value = _tan_dtl_id;
                pgSqlCmd.Parameters.Add(paramTDetailsID);

                pgSqlCon.Open();
                blStatus = (bool)pgSqlCmd.ExecuteScalar();

                return blStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;

        }
        
        public static bool CheckForValidUser(string _username, string _userpwd, string _userrole,out int user_id_out)
        {
            bool blStatus = false;
            int userID = 0;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.is_valid_user";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserName = new NpgsqlParameter();
                paramUserName.ParameterName = "p_user_name";
                paramUserName.DbType = DbType.String;
                paramUserName.Value = _username;
                pgSqlCmd.Parameters.Add(paramUserName);

                NpgsqlParameter paramUserPwd = new NpgsqlParameter();
                paramUserPwd.ParameterName = "p_user_pwd";
                paramUserPwd.DbType = DbType.String;
                paramUserPwd.Value = _userpwd;
                pgSqlCmd.Parameters.Add(paramUserPwd);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_user_role";
                paramUserRole.DbType = DbType.String;
                paramUserRole.Value =  _userrole;
                pgSqlCmd.Parameters.Add(paramUserRole);

                pgSqlCon.Open();
                userID = (int)pgSqlCmd.ExecuteScalar();

                if (userID > 0)
                {
                    user_id_out = userID;
                    blStatus = true;
                }
                else
                {
                    user_id_out = userID;
                    blStatus = false;
                }
                return blStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            user_id_out = userID;
            return blStatus;

        }

        public static DataTable RetrieveUserDetails()
        {
            DataSet dsUserDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.retrieve_user_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserDetails);

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsUserDetails != null)
                {
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        return dsUserDetails.Tables[0];
                    }
                }           
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;

        }
        
        public static bool CheckForDuplicateUser(string _username, string _userrole)
        {
            bool blStatus = false;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.is_duplicate_user";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserName = new NpgsqlParameter();
                paramUserName.ParameterName = "p_user_name";
                paramUserName.DbType = DbType.String;
                paramUserName.Value = _username;
                pgSqlCmd.Parameters.Add(paramUserName);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_user_role";
                paramUserRole.DbType = DbType.String;
                paramUserRole.Value = _userrole;
                pgSqlCmd.Parameters.Add(paramUserRole);               

                pgSqlCon.Open();
                blStatus = (bool)pgSqlCmd.ExecuteScalar();

                return blStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;

        }

        public static bool InsertNewUserDetails(string _username, string _userpwd, string _userrole,DateTime _createdon)
        { 
            bool blStatus = false;            
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.insert_new_user_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserName = new NpgsqlParameter();
                paramUserName.ParameterName = "p_user_name";
                paramUserName.DbType = DbType.String;
                paramUserName.Value = _username;
                pgSqlCmd.Parameters.Add(paramUserName);

                NpgsqlParameter paramUserPwd = new NpgsqlParameter();
                paramUserPwd.ParameterName = "p_user_pwd";
                paramUserPwd.DbType = DbType.String;
                paramUserPwd.Value = _userpwd;
                pgSqlCmd.Parameters.Add(paramUserPwd);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_user_role";
                paramUserRole.DbType = DbType.String;
                paramUserRole.Value = _userrole;
                pgSqlCmd.Parameters.Add(paramUserRole);

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_createdon";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                pgSqlCmd.Parameters.Add(paramCreatedOn);

                pgSqlCon.Open();
                int cnt = pgSqlCmd.ExecuteNonQuery();

                blStatus = true;

                return blStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;
        }

        public static bool UpdateUserDetails(string _username, string _password, string _newpassword, int _usrroleid)
        {
            bool blStatus = false;
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = pgCon;
                cmd.CommandText = "pepsilite.update_user_password";
                cmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserName = new NpgsqlParameter();
                paramUserName.ParameterName = "p_username";
                paramUserName.DbType = DbType.String;
                paramUserName.Value = _username;
                cmd.Parameters.Add(paramUserName);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_usr_roleid";
                paramUserRole.DbType = DbType.Int32;
                paramUserRole.Value = _usrroleid;
                cmd.Parameters.Add(paramUserRole);

                NpgsqlParameter paramPassword = new NpgsqlParameter();
                paramPassword.ParameterName = "p_password";
                paramPassword.DbType = System.Data.DbType.String;
                paramPassword.Value = _password;
                cmd.Parameters.Add(paramPassword);

                NpgsqlParameter paramNewPassword = new NpgsqlParameter();
                paramNewPassword.ParameterName = "p_new_password";
                paramNewPassword.DbType = System.Data.DbType.String;
                paramNewPassword.Value = _newpassword;
                cmd.Parameters.Add(paramNewPassword);
                
                pgCon.Open();
                cmd.ExecuteNonQuery();

                blStatus = true;
                return blStatus;
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return blStatus;
        }

        public static bool InsertTanDetails_ArrayValues(string _tannumber, string[] _structure, string[] _molformula, double[] _molweight,
                                            string[] _iupacname, int _pagenum, string _pagelabel, string _examplenum, string _tablenum,
                                            string _enname, string[] _inchikey, DateTime _createdon, int _createdby, out int out_tan_dtl_id)
        {
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = pgCon;
                cmd.CommandText = "pepsilite.insert_tan_details_array";
                cmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramTanID = new NpgsqlParameter();
                paramTanID.ParameterName = "p_tan";
                paramTanID.DbType = DbType.String;
                paramTanID.Value = _tannumber;
                cmd.Parameters.Add(paramTanID);

                NpgsqlParameter paramStructure = new NpgsqlParameter();
                paramStructure.ParameterName = "p_structure";
                paramStructure.DbType = DbType.String;
                paramStructure.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array;
                paramStructure.Value = _structure;
                cmd.Parameters.Add(paramStructure);

                NpgsqlParameter paramMolFormula = new NpgsqlParameter();
                paramMolFormula.ParameterName = "p_molformula";
                paramMolFormula.DbType = System.Data.DbType.String;
                paramMolFormula.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array;
                paramMolFormula.Value = _molformula;
                cmd.Parameters.Add(paramMolFormula);

                NpgsqlParameter paramnMolWeight = new NpgsqlParameter();
                paramnMolWeight.ParameterName = "p_molweight";
                paramnMolWeight.DbType = System.Data.DbType.Double;
                paramnMolWeight.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array;
                paramnMolWeight.Value = _molweight;
                cmd.Parameters.Add(paramnMolWeight);

                NpgsqlParameter paramIUPAC = new NpgsqlParameter();
                paramIUPAC.ParameterName = "p_iupacname";
                paramIUPAC.DbType = System.Data.DbType.String;
                paramIUPAC.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array;
                paramIUPAC.Value = _iupacname;
                cmd.Parameters.Add(paramIUPAC);

                NpgsqlParameter paramPageNum = new NpgsqlParameter();
                paramPageNum.ParameterName = "p_pagenumber";
                paramPageNum.DbType = System.Data.DbType.Int32;
                paramPageNum.Value = _pagenum;
                cmd.Parameters.Add(paramPageNum);

                NpgsqlParameter paramPageLabel = new NpgsqlParameter();
                paramPageLabel.ParameterName = "p_pagelabel";
                paramPageLabel.DbType = System.Data.DbType.String;
                paramPageLabel.Value = _pagelabel;
                cmd.Parameters.Add(paramPageLabel);

                NpgsqlParameter paramExampleNum = new NpgsqlParameter();
                paramExampleNum.ParameterName = "p_examplenumber";
                paramExampleNum.DbType = System.Data.DbType.String;
                paramExampleNum.Value = _examplenum;
                cmd.Parameters.Add(paramExampleNum);

                NpgsqlParameter paramTableNum = new NpgsqlParameter();
                paramTableNum.ParameterName = "p_tablenumber";
                paramTableNum.DbType = System.Data.DbType.String;
                paramTableNum.Value = _tablenum;
                cmd.Parameters.Add(paramTableNum);

                NpgsqlParameter paramEnName = new NpgsqlParameter();
                paramEnName.ParameterName = "p_enname";
                paramEnName.DbType = System.Data.DbType.String;
                paramEnName.Value = _enname;
                cmd.Parameters.Add(paramEnName);

                NpgsqlParameter paramInchi = new NpgsqlParameter();
                paramInchi.ParameterName = "p_inchikey";
                paramInchi.DbType = System.Data.DbType.String;
                paramInchi.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Array;
                paramInchi.Value = _inchikey;
                cmd.Parameters.Add(paramInchi);

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_createdon";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                cmd.Parameters.Add(paramCreatedOn);

                NpgsqlParameter paramCreatedBy = new NpgsqlParameter();
                paramCreatedBy.ParameterName = "p_createdby";
                paramCreatedBy.DbType = System.Data.DbType.Int32;
                paramCreatedBy.Value = _createdby;
                cmd.Parameters.Add(paramCreatedBy);

                NpgsqlParameter paramTanDtlID = new NpgsqlParameter();
                paramTanDtlID.ParameterName = "po_tan_dtl_id";
                paramTanDtlID.DbType = System.Data.DbType.Int32;
                paramTanDtlID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramTanDtlID);

                pgCon.Open();
                cmd.ExecuteNonQuery();

                out_tan_dtl_id = Convert.ToInt32(paramTanDtlID.Value);
                return true;
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            out_tan_dtl_id = 0;
            return false;
        }
        
        public static bool InsertDictionaryDetails(string _compname, string _smiles, DateTime _createdon, int _createdby)
        {
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgCon;
                pgSqlCmd.CommandText = "pepsilite.insert_dictionary_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramCompName = new NpgsqlParameter();
                paramCompName.ParameterName = "p_compname";
                paramCompName.DbType = DbType.String;
                paramCompName.Value = _compname;
                pgSqlCmd.Parameters.Add(paramCompName);         

                NpgsqlParameter paramSmiles = new NpgsqlParameter();
                paramSmiles.ParameterName = "p_smiles";
                paramSmiles.DbType = System.Data.DbType.String;
                paramSmiles.Value = _smiles;
                pgSqlCmd.Parameters.Add(paramSmiles);

                NpgsqlParameter paramCreatedBy = new NpgsqlParameter();
                paramCreatedBy.ParameterName = "p_createdby";
                paramCreatedBy.DbType = System.Data.DbType.Int32;
                paramCreatedBy.Value = _createdby;
                pgSqlCmd.Parameters.Add(paramCreatedBy);

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_createdon";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                pgSqlCmd.Parameters.Add(paramCreatedOn);

                pgCon.Open();
                int cnt = pgSqlCmd.ExecuteNonQuery();                       
                return true;
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return false;
        }

        public static string GetDictSmilesOnCompName(string _compname)
        {
            DataSet dsTanDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_dict_smiles_compname";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramCompName = new NpgsqlParameter();
                paramCompName.ParameterName = "p_compname";
                paramCompName.DbType = DbType.String;
                paramCompName.Value = _compname;
                pgSqlCmd.Parameters.Add(paramCompName);

                object objSmiles = pgSqlCmd.ExecuteScalar();

                nTrans.Commit();
                pgSqlCon.Close();

                return objSmiles.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return "";

        }

        public static bool UpdateDictCompSmilesDetails(string _compname, string _newsmiles,DateTime _modifiedon,int _modifiedby)
        {
            bool blStatus = false;
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = pgCon;
                cmd.CommandText = "pepsilite.update_comp_smiles";
                cmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramCompName = new NpgsqlParameter();
                paramCompName.ParameterName = "p_compname";
                paramCompName.DbType = DbType.String;
                paramCompName.Value = _compname;
                cmd.Parameters.Add(paramCompName);      

                NpgsqlParameter paramNewSmiles = new NpgsqlParameter();
                paramNewSmiles.ParameterName = "p_new_smiles";
                paramNewSmiles.DbType = System.Data.DbType.String;
                paramNewSmiles.Value = _newsmiles;
                cmd.Parameters.Add(paramNewSmiles);       

                NpgsqlParameter paramModifiedOn = new NpgsqlParameter();
                paramModifiedOn.ParameterName = "p_modifiedon";
                paramModifiedOn.DbType = System.Data.DbType.Date;
                paramModifiedOn.Value = _modifiedon;
                cmd.Parameters.Add(paramModifiedOn);

                NpgsqlParameter paramModifiedBy = new NpgsqlParameter();
                paramModifiedBy.ParameterName = "p_modifiedby";
                paramModifiedBy.DbType = System.Data.DbType.Int32;
                paramModifiedBy.Value = _modifiedby;
                cmd.Parameters.Add(paramModifiedBy);

                NpgsqlParameter paramStatus  = new NpgsqlParameter();
                paramStatus.ParameterName = "po_status";
                paramStatus.DbType = System.Data.DbType.Boolean;
                paramStatus.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramStatus);

                pgCon.Open();
                cmd.ExecuteNonQuery();

                if ((bool)paramStatus.Value)
                {
                    blStatus = true;
                }                
                return blStatus;
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return blStatus;
        }

        public static bool DeleteDictCompDetails(string _compname)
        {
            bool blStatus = false;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.delete_dict_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;


                NpgsqlParameter paramCompName = new NpgsqlParameter();
                paramCompName.ParameterName = "p_compname";
                paramCompName.DbType = DbType.String;
                paramCompName.Value = _compname;
                pgSqlCmd.Parameters.Add(paramCompName);

                NpgsqlParameter paramStatus = new NpgsqlParameter();
                paramStatus.ParameterName = "po_status";
                paramStatus.DbType = System.Data.DbType.Boolean;
                paramStatus.Direction = ParameterDirection.Output;
                pgSqlCmd.Parameters.Add(paramStatus);

                pgSqlCon.Open();
                pgSqlCmd.ExecuteScalar();

                if ((bool)paramStatus.Value)
                {
                    blStatus = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;

        }

        public static DataTable GetAllDictionaryEntries()
        {
            try
            {
                DataSet dsDictionary = new DataSet();

                NpgsqlConnection pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_all_dict_entries";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;               

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsDictionary);

                if (dsDictionary != null)
                {
                    if (dsDictionary.Tables.Count > 0)
                    {
                        return dsDictionary.Tables[0];
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        
        public static bool CheckForDuplicateCompName(string _compname)
        {
            bool blStatus = false;
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.is_duplicate_comp_name";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramCompName = new NpgsqlParameter();
                paramCompName.ParameterName = "p_compname";
                paramCompName.DbType = DbType.String;
                paramCompName.Value = _compname;
                pgSqlCmd.Parameters.Add(paramCompName);                

                pgSqlCon.Open();
                blStatus = (bool)pgSqlCmd.ExecuteScalar();

                return blStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return blStatus;

        }

        public static DataTable RetrieveUserDetails_ExceptOne(int _userid,string _userrole)
        {
            DataSet dsUserDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.retrieve_user_details_exceptone";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_userid";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID);

                NpgsqlParameter paramURole = new NpgsqlParameter();
                paramURole.ParameterName = "p_user_role";
                paramURole.DbType = DbType.String;
                paramURole.Value = _userrole;
                pgSqlCmd.Parameters.Add(paramURole);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserDetails);
                
                if (dsUserDetails != null)
                {
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        DataSet dsResults = new DataSet();

                        string str = dsUserDetails.Tables[0].Rows[0][0].ToString();
                        string strQry = "fetch all in " + @"""" + str + @"""";                      

                        NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        pgSqlDtAdpt2.Fill(dsResults);

                        if (dsResults != null)
                        {
                            if (dsResults.Tables.Count > 0)
                            {
                                return dsResults.Tables[0];
                            }
                        }
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static DataTable RetrieveUserRolesOnuserName(string _username)
        {
            DataSet dsUserDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.retrieve_user_roles_on_name";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserName = new NpgsqlParameter();
                paramUserName.ParameterName = "p_username";
                paramUserName.DbType = DbType.String;
                paramUserName.Value = _username;
                pgSqlCmd.Parameters.Add(paramUserName);               

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserDetails);

                if (dsUserDetails != null)
                {
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        DataSet dsResults = new DataSet();

                        string str = dsUserDetails.Tables[0].Rows[0][0].ToString();
                        string strQry = "fetch all in " + @"""" + str + @"""";

                        NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        pgSqlDtAdpt2.Fill(dsResults);

                        if (dsResults != null)
                        {
                            if (dsResults.Tables.Count > 0)
                            {
                                return dsResults.Tables[0];
                            }
                        }
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static DataTable RetrieveUserAssignedTANs(string _username,string _userrole)
        {
            DataSet dsUserDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_user_assigned_tan_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserName = new NpgsqlParameter();
                paramUserName.ParameterName = "p_username";
                paramUserName.DbType = DbType.String;
                paramUserName.Value = _username;
                pgSqlCmd.Parameters.Add(paramUserName);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_userrole";
                paramUserRole.DbType = DbType.String;
                paramUserRole.Value = _userrole;
                pgSqlCmd.Parameters.Add(paramUserRole);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserDetails);

                if (dsUserDetails != null)
                {
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        DataSet dsResults = new DataSet();

                        string str = dsUserDetails.Tables[0].Rows[0][0].ToString();
                        string strQry = "fetch all in " + @"""" + str + @"""";

                        NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        pgSqlDtAdpt2.Fill(dsResults);

                        if (dsResults != null)
                        {
                            if (dsResults.Tables.Count > 0)
                            {
                                return dsResults.Tables[0];
                            }
                        }
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static DataTable GetUserRoles()
        {
            DataSet dsUserRoles = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_all_user_roles";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserRoles);

                nTrans.Commit();
                pgSqlCon.Close();

                if (dsUserRoles != null)
                {
                    if (dsUserRoles.Tables.Count > 0)
                    {
                        return dsUserRoles.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;

        }

        public static bool CheckDuplicatePhase_Shipment_TAN(string _phasename, string _shipmentname, string _tanname,DateTime _createdon)
        {
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgCon;
                pgSqlCmd.CommandText = "pepsilite.check_duplicate_date_ph_sh_tan";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramPhase = new NpgsqlParameter();
                paramPhase.ParameterName = "p_phase_name";
                paramPhase.DbType = DbType.String;
                paramPhase.Value = _phasename;
                pgSqlCmd.Parameters.Add(paramPhase);

                NpgsqlParameter paramShipment = new NpgsqlParameter();
                paramShipment.ParameterName = "p_shipment_name";
                paramShipment.DbType = System.Data.DbType.String;
                paramShipment.Value = _shipmentname;
                pgSqlCmd.Parameters.Add(paramShipment);

                NpgsqlParameter paramTAN = new NpgsqlParameter();
                paramTAN.ParameterName = "p_tan";
                paramTAN.DbType = System.Data.DbType.String;
                paramTAN.Value = _tanname;
                pgSqlCmd.Parameters.Add(paramTAN);          

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_created_on";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                pgSqlCmd.Parameters.Add(paramCreatedOn);

                NpgsqlParameter paramStatus = new NpgsqlParameter();
                paramStatus.ParameterName = "po_status";
                paramStatus.DbType = System.Data.DbType.Boolean;
                paramStatus.Direction = ParameterDirection.Output;
                pgSqlCmd.Parameters.Add(paramStatus);

                pgCon.Open();
                pgSqlCmd.ExecuteNonQuery();

                if ((bool)paramStatus.Value == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return false;
        }
        
        public static bool InsertPhase_Shipment_TAN_Details(string _phasename,string _shipmentname,string _tanname,bool _iseligible,int _subscount, DateTime _createdon, int _createdby)
        {
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgCon;
                pgSqlCmd.CommandText = "pepsilite.insert_phase_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramPhase = new NpgsqlParameter();
                paramPhase.ParameterName = "p_phase_name";
                paramPhase.DbType = DbType.String;
                paramPhase.Value = _phasename;
                pgSqlCmd.Parameters.Add(paramPhase);

                NpgsqlParameter paramShipment = new NpgsqlParameter();
                paramShipment.ParameterName = "p_shipment_name";
                paramShipment.DbType = System.Data.DbType.String;
                paramShipment.Value = _shipmentname;
                pgSqlCmd.Parameters.Add(paramShipment);

                NpgsqlParameter paramTAN = new NpgsqlParameter();
                paramTAN.ParameterName = "p_tan";
                paramTAN.DbType = System.Data.DbType.String;
                paramTAN.Value = _tanname;
                pgSqlCmd.Parameters.Add(paramTAN);

                NpgsqlParameter paramIsEligible = new NpgsqlParameter();
                paramIsEligible.ParameterName = "p_iseligible";
                paramIsEligible.DbType = System.Data.DbType.Boolean;
                paramIsEligible.Value = _iseligible;
                pgSqlCmd.Parameters.Add(paramIsEligible);

                NpgsqlParameter paramSubsCnt = new NpgsqlParameter();
                paramSubsCnt.ParameterName = "p_subs_count";
                paramSubsCnt.DbType = System.Data.DbType.Int32;
                paramSubsCnt.Value = _subscount;
                pgSqlCmd.Parameters.Add(paramSubsCnt);

                NpgsqlParameter paramCreatedBy = new NpgsqlParameter();
                paramCreatedBy.ParameterName = "p_created_by";
                paramCreatedBy.DbType = System.Data.DbType.Int32;
                paramCreatedBy.Value = _createdby;
                pgSqlCmd.Parameters.Add(paramCreatedBy);

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_created_on";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                pgSqlCmd.Parameters.Add(paramCreatedOn);

                NpgsqlParameter paramStatus = new NpgsqlParameter();
                paramStatus.ParameterName = "po_status";
                paramStatus.DbType = System.Data.DbType.Boolean;
                paramStatus.Direction = ParameterDirection.Output;
                pgSqlCmd.Parameters.Add(paramStatus);

                pgCon.Open();
                pgSqlCmd.ExecuteNonQuery();

                if ((bool)paramStatus.Value == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return false;
        }

        public static DataTable GetReportingUserDetails(int _userid, int _usrroleid)
        {
            DataSet dsUserDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_reporting_user_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_userid";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID);

                NpgsqlParameter paramURole = new NpgsqlParameter();
                paramURole.ParameterName = "p_roleid";
                paramURole.DbType = DbType.Int32;
                paramURole.Value = _usrroleid;
                pgSqlCmd.Parameters.Add(paramURole);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserDetails);

                if (dsUserDetails != null)
                {
                    //if (dsUserDetails.Tables.Count > 0)
                    //{
                    //    DataSet dsResults = new DataSet();

                    //    string str = dsUserDetails.Tables[0].Rows[0][0].ToString();
                    //    string strQry = "fetch all in " + @"""" + str + @"""";

                    //    NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                    //    pgSqlDtAdpt2.Fill(dsResults);

                    //if (dsResults != null)
                    //{
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        return dsUserDetails.Tables[0];
                    }
                    //   }
                    //}
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static DataTable RetrievePhaseDetailsOnUserRole(int _userid, int _usrroleid)
        {
            DataSet dsPhaseDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_phase_details_on_user_role";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_userid";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID);

                NpgsqlParameter paramURole = new NpgsqlParameter();
                paramURole.ParameterName = "p_roleid";
                paramURole.DbType = DbType.Int32;
                paramURole.Value = _usrroleid;
                pgSqlCmd.Parameters.Add(paramURole);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsPhaseDetails);

                if (dsPhaseDetails != null)
                {
                    if (dsPhaseDetails.Tables.Count > 0)
                    {
                        //DataSet dsResults = new DataSet();

                        //string str = dsPhaseDetails.Tables[0].Rows[0][0].ToString();
                        //string strQry = "fetch all in " + @"""" + str + @"""";

                        //NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        //pgSqlDtAdpt2.Fill(dsResults);

                        //if (dsResults != null)
                        //{
                        //    if (dsResults.Tables.Count > 0)
                        //    {
                        //        return dsResults.Tables[0];
                        //    }
                        //}

                        return dsPhaseDetails.Tables[0];
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static DataTable GetShipmentDetailsOnPhase(string _phasename)
        {
            DataSet dsUserDetails = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_shipment_details_on_phase";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;
                
                NpgsqlParameter paramPhase = new NpgsqlParameter();
                paramPhase.ParameterName = "p_phasename";
                paramPhase.DbType = DbType.String;
                paramPhase.Value = _phasename;
                pgSqlCmd.Parameters.Add(paramPhase);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsUserDetails);

                if (dsUserDetails != null)
                {
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        DataSet dsResults = new DataSet();

                        string str = dsUserDetails.Tables[0].Rows[0][0].ToString();
                        string strQry = "fetch all in " + @"""" + str + @"""";

                        NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        pgSqlDtAdpt2.Fill(dsResults);

                        if (dsResults != null)
                        {
                            if (dsResults.Tables.Count > 0)
                            {
                                return dsResults.Tables[0];
                            }
                        }
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }
        
        public static DataTable GetTANsOnPhase_Shipment_UID_RoleID(string _phasename,string _shipmentname,int _userid,int _usrroleid)
        {
            DataSet dsTANs = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_tans_on_phase_shipment_userid_roleid";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;
                
                NpgsqlParameter paramPhase = new NpgsqlParameter();
                paramPhase.ParameterName = "p_phasename";
                paramPhase.DbType = DbType.String;
                paramPhase.Value = _phasename;
                pgSqlCmd.Parameters.Add(paramPhase);

                NpgsqlParameter paramShipment = new NpgsqlParameter();
                paramShipment.ParameterName = "p_shipmentname";
                paramShipment.DbType = DbType.String;
                paramShipment.Value = _shipmentname;
                pgSqlCmd.Parameters.Add(paramShipment);

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_userid";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_usrroleid";
                paramUserRole.DbType = DbType.Int32;
                paramUserRole.Value = _usrroleid;
                pgSqlCmd.Parameters.Add(paramUserRole);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsTANs);

                if (dsTANs != null)
                {
                    if (dsTANs.Tables.Count > 0)
                    {
                        DataSet dsResults = new DataSet();

                        string str = dsTANs.Tables[0].Rows[0][0].ToString();
                        string strQry = "fetch all in " + @"""" + str + @"""";

                        NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        pgSqlDtAdpt2.Fill(dsResults);

                        if (dsResults != null)
                        {
                            if (dsResults.Tables.Count > 0)
                            {
                                return dsResults.Tables[0];
                            }
                        }
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static DataTable GetAssignedTANsOnPhase_Shipment(int _userid, int _roleid)
        {
            DataSet dsAssignedTANs = new DataSet();
            NpgsqlConnection pgSqlCon = null;
            try
            {
                pgSqlCon = Connection.GetPostGresConnection();

                pgSqlCon.Open();
                NpgsqlTransaction nTrans = pgSqlCon.BeginTransaction();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgSqlCon;
                pgSqlCmd.CommandText = "pepsilite.get_assigned_tans_on_phase_shipment";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramUserID = new NpgsqlParameter();
                paramUserID.ParameterName = "p_userid";
                paramUserID.DbType = DbType.Int32;
                paramUserID.Value = _userid;
                pgSqlCmd.Parameters.Add(paramUserID);

                NpgsqlParameter paramUserRole = new NpgsqlParameter();
                paramUserRole.ParameterName = "p_usrroleid";
                paramUserRole.DbType = DbType.Int32;
                paramUserRole.Value = _roleid;
                pgSqlCmd.Parameters.Add(paramUserRole);

                NpgsqlDataAdapter pgSqlDtAdpt = new NpgsqlDataAdapter(pgSqlCmd);
                pgSqlDtAdpt.Fill(dsAssignedTANs);

                if (dsAssignedTANs != null)
                {
                    if (dsAssignedTANs.Tables.Count > 0)
                    {
                        //DataSet dsResults = new DataSet();

                        //string str = dsAssignedTANs.Tables[0].Rows[0][0].ToString();
                        //string strQry = "fetch all in " + @"""" + str + @"""";

                        //NpgsqlDataAdapter pgSqlDtAdpt2 = new NpgsqlDataAdapter(strQry, pgSqlCon);
                        //pgSqlDtAdpt2.Fill(dsResults);

                        //if (dsResults != null)
                        //{
                        //    if (dsResults.Tables.Count > 0)
                        //    {
                        return dsAssignedTANs.Tables[0];
                        //    }
                        //}
                    }
                }
                nTrans.Commit();
                pgSqlCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgSqlCon.Close();
            }
            return null;
        }

        public static bool InsertTaskAssignmentDetails(string _phasename, string _shipmentname, string _tanname,
                                                       string _assignedto, string _assignrole, DateTime _createdon,
                                                       int _assignedby, string _assignedbyrole,string _tan_status)
        {
            NpgsqlConnection pgCon = null;
            try
            {
                pgCon = Connection.GetPostGresConnection();

                NpgsqlCommand pgSqlCmd = new NpgsqlCommand();
                pgSqlCmd.Connection = pgCon;
                pgSqlCmd.CommandText = "pepsilite.insert_task_assignment_details";
                pgSqlCmd.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter paramPhase = new NpgsqlParameter();
                paramPhase.ParameterName = "p_phase_name";
                paramPhase.DbType = DbType.String;
                paramPhase.Value = _phasename;
                pgSqlCmd.Parameters.Add(paramPhase);

                NpgsqlParameter paramShipment = new NpgsqlParameter();
                paramShipment.ParameterName = "p_shipment_name";
                paramShipment.DbType = System.Data.DbType.String;
                paramShipment.Value = _shipmentname;
                pgSqlCmd.Parameters.Add(paramShipment);
                
                NpgsqlParameter paramTAN = new NpgsqlParameter();
                paramTAN.ParameterName = "p_tan";
                paramTAN.DbType = System.Data.DbType.String;
                paramTAN.Value = _tanname;
                pgSqlCmd.Parameters.Add(paramTAN);

                NpgsqlParameter paramAssignTo = new NpgsqlParameter();
                paramAssignTo.ParameterName = "p_assignedto";
                paramAssignTo.DbType = System.Data.DbType.String;
                paramAssignTo.Value = _assignedto;
                pgSqlCmd.Parameters.Add(paramAssignTo);

                NpgsqlParameter paramAssignToRole = new NpgsqlParameter();
                paramAssignToRole.ParameterName = "p_assignedto_role";
                paramAssignToRole.DbType = System.Data.DbType.String;
                paramAssignToRole.Value = _assignrole;
                pgSqlCmd.Parameters.Add(paramAssignToRole);

                NpgsqlParameter paramCreatedBy = new NpgsqlParameter();
                paramCreatedBy.ParameterName = "p_assigned_by";
                paramCreatedBy.DbType = System.Data.DbType.Int32;
                paramCreatedBy.Value = _assignedby;
                pgSqlCmd.Parameters.Add(paramCreatedBy);

                NpgsqlParameter paramCrByRole = new NpgsqlParameter();
                paramCrByRole.ParameterName = "p_assigned_byrole";
                paramCrByRole.DbType = System.Data.DbType.String;
                paramCrByRole.Value = _assignedbyrole;
                pgSqlCmd.Parameters.Add(paramCrByRole);

                NpgsqlParameter paramCreatedOn = new NpgsqlParameter();
                paramCreatedOn.ParameterName = "p_createdon";
                paramCreatedOn.DbType = System.Data.DbType.Date;
                paramCreatedOn.Value = _createdon;
                pgSqlCmd.Parameters.Add(paramCreatedOn);

                NpgsqlParameter paramTanStatus = new NpgsqlParameter();
                paramTanStatus.ParameterName = "p_tan_status";
                paramTanStatus.DbType = System.Data.DbType.String;
                paramTanStatus.Value = _tan_status;
                pgSqlCmd.Parameters.Add(paramTanStatus);

                NpgsqlParameter paramStatus = new NpgsqlParameter();
                paramStatus.ParameterName = "po_status";
                paramStatus.DbType = System.Data.DbType.Boolean;
                paramStatus.Direction = ParameterDirection.Output;
                pgSqlCmd.Parameters.Add(paramStatus);

                pgCon.Open();
                int cnt = pgSqlCmd.ExecuteNonQuery();
                if ((bool)paramStatus.Value == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NpgsqlException ex)
            {
                pgCon.Close();
                throw ex;
            }
            finally
            {
                pgCon.Close();
            }
            return false;
        }

    }
}
