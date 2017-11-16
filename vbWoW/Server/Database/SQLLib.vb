Imports System
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

<ComClass(SQLLib.ClassId, SQLLib.InterfaceId, SQLLib.EventsId)> _
Public Class SQLLib
    Implements IDisposable

#Region "Class's used"
    <CLSCompliant(False)> _
    Public MySQLConn As MySqlConnection
    Private MSSQL_Connection As SqlConnection
#End Region

#Region "Events and event ID's"
    Public Enum EMessages
        ID_Error = 0
        ID_Message = 1
    End Enum

    Public Event SQLMessage(ByVal MessageID As EMessages, ByVal OutBuf As String)
#End Region

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "ECC3DCA3-E394-4D4F-BCC9-FBC3A999B8D3"
    Public Const InterfaceId As String = "4A2A2AF5-39A2-44BA-9881-57AA6D867D33"
    Public Const EventsId As String = "BD50B4A8-D148-4C52-B8FC-469119FBB71D"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

#Region "Version Info <Update VInfo and rvDate as needed>"
    Private VInfo As String = "2.1.0a"
    Private rvDate As String = "9:36 PM, Wednesday, September, 25, 2006"

    <Description("Class info version/last date updated.")> _
    Public ReadOnly Property Class_Version_Info() As String
        Get
            Return "Version: " + VInfo + ", Updated at: " + rvDate
        End Get
    End Property
#End Region

#Region "SQL startup Propertys, connections and disposal"
    'SQL Host name/password/etc..
    Private v_SQLHost As String = ""
    Private v_SQLUser As String = ""
    Private v_SQLPass As String = ""
    Private v_SQLDBName As String = ""
    Public Enum DB_Type
        MySQL = 0
        MSSQL = 1
    End Enum
    Private v_SQLType As DB_Type

    <Description("SQL Server selection.")> _
    Public Property MySQLTypeServer() As DB_Type
        Get
            MySQLTypeServer = v_SQLType
        End Get
        Set(ByVal value As DB_Type)
            v_SQLType = value
        End Set
    End Property

    <Description("SQL Host name.")> _
    Public Property MySQLHost() As String
        Get
            MySQLHost = v_SQLHost
        End Get
        Set(ByVal value As String)
            v_SQLHost = value
        End Set
    End Property

    <Description("SQL User name.")> _
    Public Property MySQLUser() As String
        Get
            MySQLUser = v_SQLUser
        End Get
        Set(ByVal value As String)
            v_SQLUser = value
        End Set
    End Property

    <Description("SQL Password.")> _
    Public Property MySQLPass() As String
        Get
            MySQLPass = v_SQLPass
        End Get
        Set(ByVal value As String)
            v_SQLPass = value
        End Set
    End Property

    <Description("SQL Database name.")> _
    Public Property MySQLDBName() As String
        Get
            MySQLDBName = v_SQLDBName
        End Get
        Set(ByVal value As String)
            v_SQLDBName = value
        End Set
    End Property

#Region "StartSQLConnection()       MySQL|MSSQL Supported"
    <Description("Start up the SQL connection.")> _
    Public Sub StartSQLConnection()
        Try
            If MySQLHost.Length < 1 Then
                RaiseEvent SQLMessage(EMessages.ID_Error, "You have to set the SQLHost name cannot be empty")
                Exit Sub
            End If
            If MySQLUser.Length < 1 Then
                RaiseEvent SQLMessage(EMessages.ID_Error, "You have to set the SQLUser name cannot be empty")
                Exit Sub
            End If
            If MySQLPass.Length < 1 Then
                RaiseEvent SQLMessage(EMessages.ID_Error, "You have to set the SQLPassword name cannot be empty")
                Exit Sub
            End If
            If MySQLDBName.Length < 1 Then
                RaiseEvent SQLMessage(EMessages.ID_Error, "You have to set the SQLDatabaseName name cannot be empty")
                Exit Sub
            End If

            Select Case v_SQLType
                Case DB_Type.MySQL
                    MySQLConn = New MySqlConnection
                    MySQLConn.ConnectionString = [String].Format("server={0}; user id={1}; password={2}; database={3}; Compress=false; Connection Timeout=1;", MySQLHost, MySQLUser, MySQLPass, MySQLDBName)
                    MySQLConn.Open()
                    RaiseEvent SQLMessage(EMessages.ID_Message, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MySQL Connection Opened Successfully [" & MySQLUser & "@" & MySQLHost & "]")

                Case DB_Type.MSSQL
                    MSSQL_Connection = New SqlConnection([String].Format("server={0}; user id={1}; password={2}; database={3}; Connection Timeout=1;", MySQLHost, MySQLUser, MySQLPass, MySQLDBName))
                    If MSSQL_Connection.State = ConnectionState.Closed Then
                        MSSQL_Connection.Open()
                    End If
                    RaiseEvent SQLMessage(EMessages.ID_Message, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MS-SQL Connection Opened Successfully [" & MySQLUser & "@" & MySQLHost & "]")

            End Select

        Catch e As MySqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MySQL Connection Error [" & e.Message & "]")
        Catch e As SqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "]  MySQL Connection Error [" & e.Message & "]")
        End Try
    End Sub
#End Region

#Region "Restart()                  MySQL|MSSQL Supported"
    <Description("Restart the SQL connection.")> _
    Public Sub Restart()
        Try
            Select Case v_SQLType
                Case DB_Type.MySQL
                    MySQLConn.Close()
                    MySQLConn.Dispose()
                    MySQLConn = New MySqlConnection
                    MySQLConn.ConnectionString = [String].Format("server={0}; user id={1}; password={2}; database={3}; Allow Zero Datetime=true;", MySQLHost, MySQLUser, MySQLPass, MySQLDBName)
                    MySQLConn.Open()

                    If MySQLConn.State = ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Message, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MySQL Connection restarted!")
                    Else
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "]  Unable to restart MySQL connection.")
                    End If
                Case DB_Type.MSSQL
                    MSSQL_Connection.Close()
                    MSSQL_Connection.Dispose()
                    MSSQL_Connection = New SqlConnection([String].Format("server={0}; user id={1}; password={2}; database={3}; Connection Timeout=1;", MySQLHost, MySQLUser, MySQLPass, MySQLDBName))
                    MSSQL_Connection.Open()

                    If MSSQL_Connection.State = ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Message, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MSSQL Connection restarted!")
                    Else
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "]  Unable to restart MSSQL connection.")
                    End If
            End Select

        Catch e As MySqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "]  MySQL Connection Error [" & e.Message & "]")
        Catch e As SqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "]  MySQL Connection Error [" & e.Message & "]")
        End Try
    End Sub
#End Region

#Region "Dispose()                  MySQL|MSSQL Supported"
    Public Sub Dispose() Implements System.IDisposable.Dispose
        Select Case v_SQLType
            Case DB_Type.MySQL
                MySQLConn.Close()
                MySQLConn.Dispose()
            Case DB_Type.MSSQL
                MSSQL_Connection.Close()
                MSSQL_Connection.Dispose()
        End Select
    End Sub
#End Region
#End Region

#Region "SQL Wraper for VB 6.0."
    Private mQuery As String = ""
    Private mResult As DataTable

#Region "Query Wraper"
    <Description("SQLQuery. EG.: (SELECT * FROM db_accounts WHERE account = 'name';')")> _
    Public Function QuerySQL(ByVal SQLQuery As String) As Boolean
        mQuery = SQLQuery
        Query(mQuery, mResult)
        If mResult.Rows.Count > 0 Then
            'Table gathered
            Return True
        Else
            'Table dosent exist
            Return False
        End If
    End Function
#End Region
#Region "SQL Get"
    <Description("SQLGet. Used after the query to get a section value")> _
    Public Function GetSQL(ByVal TableSection As String) As String
        Return (mResult.Rows(0).Item(TableSection)).ToString
    End Function
    Public Function GetDataTableSQL() As DataTable
        Return mResult
    End Function
#End Region
#Region "Insert Wraper"
    <Description("SQLInsert. EG.: (INSERT INTO db_textpage (pageid, text, nextpageid, wdbversion, checksum) VALUES ('pageid DWORD', 'pagetext STRING', 'nextpage DWORD', 'version DWORD', 'checksum DWORD')")> _
    Public Sub InsertSQL(ByVal SQLInsertionQuery As String)
        Insert(SQLInsertionQuery)
    End Sub
#End Region
#Region "Update Wraper"
    <Description("SQLUpdate. EG.: (UPDATE db_textpage SET pagetext='pagetextstring' WHERE pageid = 'pageiddword';")> _
    Public Sub UpdateSQL(ByVal SQLUpdateQuery As String)
        Update(SQLUpdateQuery)
    End Sub
#End Region
#End Region

#Region "Main SQL Functions Used."
#Region "Query      MySQL|MSSQL Supported       [SELECT * FROM db_accounts WHERE account = 'name';']"
    Private Sub Query(ByVal sqlquery As String, ByRef Result As DataTable)
        Select Case v_SQLType
            Case DB_Type.MySQL
                If MySQLConn.State <> ConnectionState.Open Then
                    Restart()
                    If MySQLConn.State <> ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MySQL Database Request Failed!")
                        Exit Sub
                    End If
                End If
            Case DB_Type.MSSQL
                If MSSQL_Connection.State <> ConnectionState.Open Then
                    Restart()
                    If MSSQL_Connection.State <> ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MSSQL Database Request Failed!")
                        Exit Sub
                    End If
                End If
        End Select

        Try
            Select Case v_SQLType
                Case DB_Type.MySQL
                    Monitor.Enter(MySQLConn)
                    Dim MySQLCommand As New MySqlCommand
                    Dim MySQLAdapter As New MySqlDataAdapter
                    MySQLCommand.Connection = MySQLConn
                    MySQLCommand.CommandText = sqlquery
                    MySQLAdapter.SelectCommand = MySQLCommand
                    Result = New DataTable
                    MySQLAdapter.Fill(Result)



                Case DB_Type.MSSQL
                    Monitor.Enter(MSSQL_Connection)
                    Dim cmd As SqlCommand = New SqlCommand(sqlquery, MSSQL_Connection)
                    Dim MSAdapter As New SqlDataAdapter
                    'Dim sqlCommand As System.Data.SqlClient.SqlCommand = _
                    'New System.Data.SqlClient.SqlCommand(queryString, SqlConnection)
                    'cmd.Connection = MSSQL_Connection
                    'cmd.CommandText = sqlquery
                    MSAdapter.SelectCommand = cmd
                    Result = New DataTable
                    MSAdapter.Fill(Result)
            End Select

        Catch e As MySqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Error Reading From MySQL Database " & e.Message)
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Query string was: " & sqlquery)
        Catch e As SqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Error Reading From MSSQL Database " & e.Message)
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Query string was: " & sqlquery)
        Finally
            Select Case v_SQLType
                Case DB_Type.MySQL
                    Monitor.Exit(MySQLConn)
                Case DB_Type.MSSQL
                    Monitor.Exit(MSSQL_Connection)
            End Select
        End Try
    End Sub
#End Region
#Region "Insert     MySQL|MSSQL Supported       [INSERT INTO db_textpage (pageid, text, nextpageid, wdbversion, checksum) VALUES ('pageid DWORD', 'pagetext STRING', 'nextpage DWORD', 'version DWORD', 'checksum DWORD']"
    Private Sub Insert(ByVal sqlquery As String)
        Select Case v_SQLType
            Case DB_Type.MySQL
                If MySQLConn.State <> ConnectionState.Open Then
                    Restart()
                    If MySQLConn.State <> ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MySQL Database Request Failed!")
                        Exit Sub
                    End If
                End If
            Case DB_Type.MSSQL
                If MSSQL_Connection.State <> ConnectionState.Open Then
                    Restart()
                    If MSSQL_Connection.State <> ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MSSQL Database Request Failed!")
                        Exit Sub
                    End If
                End If
        End Select

        Try
            Select Case v_SQLType
                Case DB_Type.MySQL
                    Monitor.Enter(MySQLConn)
                    Dim MySQLCommand As New MySqlCommand
                    Dim MySQLTransaction As MySqlTransaction

                    MySQLCommand.Connection = MySQLConn
                    MySQLTransaction = MySQLConn.BeginTransaction
                    MySQLCommand.Transaction = MySQLTransaction

                    MySQLCommand.CommandText = sqlquery
                    MySQLCommand.ExecuteNonQuery()
                    MySQLTransaction.Commit()
                    Console.WriteLine("transaction completed")
                Case DB_Type.MSSQL
                    Monitor.Enter(MSSQL_Connection)
                    Dim cmd As New SqlCommand
                    Dim MSTrans As SqlTransaction

                    cmd.Connection = MSSQL_Connection
                    MSTrans = MSSQL_Connection.BeginTransaction()
                    cmd.Transaction = MSTrans

                    cmd.CommandText = sqlquery
                    cmd.ExecuteNonQuery()
                    MSTrans.Commit()
                    Console.WriteLine("transaction completed")
            End Select
        Catch e As MySqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Error Reading From MySQL Database " & e.Message)
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Insert string was: " & sqlquery)
        Catch e As SqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Error Reading From MSSQL Database " & e.Message)
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Query string was: " & sqlquery)
        Finally
            Select Case v_SQLType
                Case DB_Type.MySQL
                    Monitor.Exit(MySQLConn)
                Case DB_Type.MSSQL
                    Monitor.Exit(MSSQL_Connection)
            End Select
        End Try
    End Sub
#End Region
#Region "Update     MySQL|MSSQL Supported       [UPDATE db_textpage SET pagetext='pagetextstring' WHERE pageid = 'pageiddword';]"
    Public Sub Update(ByVal sqlquery As String)
        Select Case v_SQLType
            Case DB_Type.MySQL
                If MySQLConn.State <> ConnectionState.Open Then
                    Restart()
                    If MySQLConn.State <> ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MySQL Database Request Failed!")
                        Exit Sub
                    End If
                End If
            Case DB_Type.MSSQL
                If MSSQL_Connection.State <> ConnectionState.Open Then
                    Restart()
                    If MSSQL_Connection.State <> ConnectionState.Open Then
                        RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] MSSQL Database Request Failed!")
                        Exit Sub
                    End If
                End If
        End Select

        Try
            Select Case v_SQLType
                Case DB_Type.MySQL
                    Monitor.Enter(MySQLConn)
                    Dim MySQLCommand As New MySqlCommand
                    Dim MySQLAdapter As New MySqlDataAdapter
                    MySQLCommand.Connection = MySQLConn
                    MySQLCommand.CommandText = sqlquery
                    MySQLAdapter.SelectCommand = MySQLCommand
                    Dim result As DataTable
                    result = New DataTable
                    MySQLAdapter.Fill(result)
                Case DB_Type.MSSQL
                    Monitor.Enter(MSSQL_Connection)
                    Dim cmd As SqlCommand = New SqlCommand(sqlquery)
                    Dim MSAdapter As New SqlDataAdapter
                    cmd.Connection = MSSQL_Connection
                    MSAdapter.SelectCommand = cmd
                    Dim result As DataTable
                    result = New DataTable
                    MSAdapter.Fill(result)
            End Select

        Catch e As MySqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Error Reading From MySQL Database " & e.Message)
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Update string was: " & sqlquery)
        Catch e As SqlException
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Error Reading From MSSQL Database " & e.Message)
            RaiseEvent SQLMessage(EMessages.ID_Error, "[" & Format(TimeOfDay, "hh:mm:ss") & "] Query string was: " & sqlquery)
        Finally
            Select Case v_SQLType
                Case DB_Type.MySQL
                    Monitor.Exit(MySQLConn)
                Case DB_Type.MSSQL
                    Monitor.Exit(MSSQL_Connection)
            End Select
        End Try
    End Sub
#End Region
#End Region

End Class


