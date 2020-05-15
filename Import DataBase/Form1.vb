Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Public Class Form1
    ' ----------------- MSAccess Define -----------------------
    Dim constring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='D:\Programming\Python\CK.mdb'"
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    '---------------- MySql Define --------------------
    Dim MysqlConn As MySqlConnection
    'Dim Cs As String = "Database=pos_ck;Server=localhost;User id=test1;Password=test1234"
    Dim Cs As String = "Database=test_db;Server=localhost;User id=test1;Password=test1234"
    Dim Ds As DataSet = New DataSet
    Dim Da As MySqlDataAdapter = New MySqlDataAdapter()

    Public bg_time As DateTime = DateSerial(2562, 1, 1)
    Public ed_time As DateTime = DateAdd("d", 1, Now())
    Public diff_time As Integer
    Public AnalyzeDay As Integer = 30
    Public _cultureENInfo As New Globalization.CultureInfo("en-US")
    'test'

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BackgroundWorker1
            .WorkerReportsProgress = True
            .WorkerSupportsCancellation = True
        End With
        CheckForIllegalCrossThreadCalls = False
        Lb_status.Text = ""
        Lb_value.Text = ""
    End Sub

    Private Sub Analyze_Data(DayValue As Integer)
        Dim DayVal As Integer = DayValue
        Dim Today As Date = Date.Today
        Dim Begin_Day As Date = Today.AddDays(-DayVal)
        Dim inv_day1 As Date = Today.AddDays(-DayVal * 2 / 3)      ' คำนวณวันในไตรมาส ที่ 2
        Dim inv_day2 As Date = Today.AddDays(-DayVal / 3)         ' คำนาณวันในไตรมาส ที่ 3
        'MsgBox(Begin_Day.ToShortDateString & "  :  " & inv_day1.ToShortDateString & "  :  " _
        '& inv_day2.ToShortDateString & "  :  " & Today.ToShortDateString)

        '------------------------- Truncate ssw salesum_w1_3 salesum_update ----------------------------
        MysqlConn = New MySqlConnection(Cs)
        MysqlConn.Open()
        'MessageBox.Show("Connection to Database has been opened.")
        Dim stm As String = "truncate table ssw1"
        Dim cmd As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd.ExecuteNonQuery()

        stm = "truncate table ssw2"
        Dim cmd1 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd1.ExecuteNonQuery()

        stm = "truncate table ssw3"
        Dim cmd2 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd2.ExecuteNonQuery()

        stm = "truncate table salesum_w1_3"
        Dim cmd3 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd3.ExecuteNonQuery()

        stm = "truncate table salesum_update"
        Dim cmd4 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd4.ExecuteNonQuery()
        'MsgBox("Truncate Table Completed !")

        '------------------------------- Insert table ssw1 ssw2 ssw3 --------------------------------

        stm = "insert into ssw1
            SELECT 
                `invoicesub`.`ItemCode` AS `ItemCode`,
                `invoicesub`.`ItemDesc` AS `ItemDesc`,
                SUM(`invoicesub`.`Qty`) AS `sumQty`,
                SUM(`invoicesub`.`Amount`) AS `sumAmount`,
                SUM((`invoicesub`.`Amount` - `invoicesub`.`Cost`)) AS `กำไร`,
                `item`.`Qty` AS `stockQty`
            FROM
                (`invoicesub`
                LEFT JOIN `item` ON ((`invoicesub`.`ItemCode` = `item`.`Code`)))
            WHERE
                ((`invoicesub`.`DocDate` BETWEEN @Begin_Day AND @Inv_Day1)
                AND (`invoicesub`.`TransType` = 7))
            GROUP BY `invoicesub`.`ItemCode`; "

        Dim cmd5 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd5.Parameters.Add("@Begin_Day", MySqlDbType.Date).Value = Begin_Day
        cmd5.Parameters.Add("@Inv_Day1", MySqlDbType.Date).Value = inv_day1
        cmd5.ExecuteNonQuery()

        stm = "insert into ssw2
            SELECT 
                `invoicesub`.`ItemCode` AS `ItemCode`,
                `invoicesub`.`ItemDesc` AS `ItemDesc`,
                SUM(`invoicesub`.`Qty`) AS `sumQty`,
                SUM(`invoicesub`.`Amount`) AS `sumAmount`,
                SUM((`invoicesub`.`Amount` - `invoicesub`.`Cost`)) AS `กำไร`,
                `item`.`Qty` AS `stockQty`
            FROM
                (`invoicesub`
                LEFT JOIN `item` ON ((`invoicesub`.`ItemCode` = `item`.`Code`)))
            WHERE
                ((`invoicesub`.`DocDate` BETWEEN @Inv_Day1 AND @Inv_Day2)
                AND (`invoicesub`.`TransType` = 7))
            GROUP BY `invoicesub`.`ItemCode`; "

        Dim cmd6 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd6.Parameters.Add("@Inv_Day1", MySqlDbType.Date).Value = inv_day1
        cmd6.Parameters.Add("@Inv_Day2", MySqlDbType.Date).Value = inv_day2
        cmd6.ExecuteNonQuery()

        stm = "insert into ssw3
            SELECT 
                `invoicesub`.`ItemCode` AS `ItemCode`,
                `invoicesub`.`ItemDesc` AS `ItemDesc`,
                SUM(`invoicesub`.`Qty`) AS `sumQty`,
                SUM(`invoicesub`.`Amount`) AS `sumAmount`,
                SUM((`invoicesub`.`Amount` - `invoicesub`.`Cost`)) AS `กำไร`,
                `item`.`Qty` AS `stockQty`
            FROM
                (`invoicesub`
                LEFT JOIN `item` ON ((`invoicesub`.`ItemCode` = `item`.`Code`)))
            WHERE
                ((`invoicesub`.`DocDate` BETWEEN @Inv_Day2 AND @Today)
                AND (`invoicesub`.`TransType` = 7))
            GROUP BY `invoicesub`.`ItemCode`; "

        Dim cmd7 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd7.Parameters.Add("@Inv_Day2", MySqlDbType.Date).Value = inv_day2
        cmd7.Parameters.Add("@Today", MySqlDbType.Date).Value = Today
        cmd7.ExecuteNonQuery()

        '--------------------------------- Insert Table Salesum_w1_3 -------------------------------------

        stm = "insert into salesum_w1_3
                select ItemCode, ItemDesc, sumqty as w1_qty, 0 as w2_qty, 0 as w3_qty, stockqty
                from ssw1;"
        Dim cmd8 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd8.ExecuteNonQuery()

        stm = "insert into salesum_w1_3
                select ItemCode, ItemDesc, 0 as w1_qty, sumqty as w2_qty, 0 as w3_qty, stockqty
                from ssw2;"
        Dim cmd9 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd9.ExecuteNonQuery()

        stm = "insert into salesum_w1_3
                select ItemCode, ItemDesc, 0 as w1_qty, 0 as w2_qty, sumqty as w3_qty, stockqty
                from ssw3;"
        Dim cmd10 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd10.ExecuteNonQuery()

        '--------------------------------- Insert Table Salesum_update -------------------------------------

        stm = "insert into salesum_update
                select itemcode, itemdesc, sum(w1_qty) as w1_qty, sum(w2_qty) as w2_qty, 
                        sum(w3_qty) as w3_qty, stockqty
                from salesum_w1_3
                group by ItemCode;"
        Dim cmd11 As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd11.ExecuteNonQuery()
        'MsgBox("Analyze Data Completed !")
        MysqlConn.Close()
    End Sub

    Private Sub Truncate_All()
        MysqlConn = New MySqlConnection(Cs)
        MysqlConn.Open()
        'MessageBox.Show("Connection to Database has been opened.")
        Dim stm As String = "truncate table item"
        Dim cmd As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd.ExecuteNonQuery()

        Dim stm1 As String = "truncate table invoicesub"
        Dim cmd1 As MySqlCommand = New MySqlCommand(stm1, MysqlConn)
        cmd1.ExecuteNonQuery()

        Dim stm2 As String = "truncate table billposnew"
        Dim cmd2 As MySqlCommand = New MySqlCommand(stm2, MysqlConn)
        cmd2.ExecuteNonQuery()

        MysqlConn.Close()
    End Sub
    Private Sub Insert_Item(Code As String, name1 As String, Qty As Double, SalePrice1 As Double, SalePrice2 As Double, SalePrice3 As Double _
                            , SalePrice4 As Double, AgvCost As Double)
        MysqlConn = New MySqlConnection(Cs)
        MysqlConn.Open()
        'MessageBox.Show("Connection to Database has been opened.")
        Dim stm As String = "insert into item(Code,name1,Qty,SalePrice1,SalePrice2,SalePrice3,SalePrice4,AgvCost) " &
                            "values(@Code,@name1,@Qty,@SalePrice1,@SalePrice2,@SalePrice3,@SalePrice4,@AgvCost)"
        Dim cmd As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd.Parameters.Add("@Code", MySqlDbType.VarChar, 20).Value = Code
        cmd.Parameters.Add("@name1", MySqlDbType.VarChar, 100).Value = name1
        cmd.Parameters.Add("@Qty", MySqlDbType.Double).Value = Qty
        cmd.Parameters.Add("@SalePrice1", MySqlDbType.Double).Value = SalePrice1
        cmd.Parameters.Add("@SalePrice2", MySqlDbType.Double).Value = SalePrice2
        cmd.Parameters.Add("@SalePrice3", MySqlDbType.Double).Value = SalePrice3
        cmd.Parameters.Add("@SalePrice4", MySqlDbType.Double).Value = SalePrice4
        cmd.Parameters.Add("@AgvCost", MySqlDbType.Double).Value = AgvCost
        cmd.ExecuteNonQuery()
        MysqlConn.Close()
    End Sub
    Private Sub Insert_InvoiceSub(DocNo As String, ItemCode As String, ItemDesc As String, Qty As Double, Price As Double, Discount As String _
                            , Amount As Double, Cost As Double, TransType As Int16, DocDate As DateTime)
        MysqlConn = New MySqlConnection(Cs)
        MysqlConn.Open()
        'MessageBox.Show("Connection to Database has been opened.")
        Dim stm As String = "insert into invoicesub(DocNo,ItemCode,ItemDesc,Qty,Price,Discount,Amount,Cost,TransType,DocDate) " &
                            "values(@DocNo,@ItemCode,@ItemDesc,@Qty,@Price,@Discount,@Amount,@Cost,@TransType,@DocDate)"
        Dim cmd As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd.Parameters.Add("@DocNo", MySqlDbType.VarChar, 15).Value = DocNo
        cmd.Parameters.Add("@ItemCode", MySqlDbType.VarChar, 20).Value = ItemCode
        cmd.Parameters.Add("@ItemDesc", MySqlDbType.VarChar, 250).Value = ItemDesc
        cmd.Parameters.Add("@Qty", MySqlDbType.Double).Value = Qty
        cmd.Parameters.Add("@Price", MySqlDbType.Double).Value = Price
        cmd.Parameters.Add("@Discount", MySqlDbType.VarChar, 30).Value = Discount
        cmd.Parameters.Add("@Amount", MySqlDbType.Double).Value = Amount
        cmd.Parameters.Add("@Cost", MySqlDbType.Double).Value = Cost
        cmd.Parameters.Add("@TransType", MySqlDbType.Int16).Value = TransType
        cmd.Parameters.Add("@DocDate", MySqlDbType.DateTime).Value = DocDate
        cmd.ExecuteNonQuery()
        MysqlConn.Close()
    End Sub
    Private Sub Insert_BillPosNew(DocNo As String, ArCode As String, Name As String, DocDate As DateTime)
        MysqlConn = New MySqlConnection(Cs)
        MysqlConn.Open()
        'MessageBox.Show("Connection to Database has been opened.")
        Dim stm As String = "insert into BillPosNew(DocNo,ArCode,Name,DocDate)" &
                            "values(@DocNo,@ArCode,@Name,@DocDate)"
        Dim cmd As MySqlCommand = New MySqlCommand(stm, MysqlConn)
        cmd.Parameters.Add("@DocNo", MySqlDbType.VarChar, 15).Value = DocNo
        cmd.Parameters.Add("@ArCode", MySqlDbType.VarChar, 15).Value = ArCode
        cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 100).Value = Name
        cmd.Parameters.Add("@DocDate", MySqlDbType.DateTime).Value = DocDate

        cmd.ExecuteNonQuery()
        MysqlConn.Close()
    End Sub

    Private Sub Bt_Im_to_MySql_Click(sender As Object, e As EventArgs) Handles Bt_Im_to_MySql.Click
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
            Me.Bt_Im_to_MySql.Enabled = False
            Me.Bt_Analyze.Enabled = False
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim MyRD As OleDbDataReader
        Dim ItemRows As Integer
        Dim InvoiceRows As Integer
        Dim BillPosRows As Integer
        Dim i As Integer
        Truncate_All()
        'MsgBox("Truncate All Table Completed")
        Lb_status.Text = "Truncate All Table Completed"
        con.ConnectionString = constring
        con.Open()
        cmd.Connection = con

        ' ------------------------------------ Import Item -------------------------------------
        cmd.CommandText = "select count(*) from item"
        ItemRows = cmd.ExecuteScalar()
        'MsgBox("Table Item Rows >>  " & ItemRows.ToString("0,000") & " Rows")
        Lb_status.Text = "Import from Item"
        ProgressBar1.Maximum = ItemRows

        cmd.CommandText = "select Code,name1,Qty,SalePrice1,SalePrice2,SalePrice3,SalePrice4,AgvCost from item"
        MyRD = cmd.ExecuteReader()
        i = 0
        While MyRD.Read()
            'MsgBox(MyRD("Code").ToString & " " & MyRD("name1").ToString )
            Insert_Item(MyRD("Code").ToString, MyRD("name1").ToString, MyRD("Qty"), MyRD("SalePrice1"), MyRD("SalePrice2"),
                        MyRD("SalePrice3"), MyRD("SalePrice4"), MyRD("AgvCost"))
            BackgroundWorker1.ReportProgress(i)
            'Threading.Thread.Sleep(100)
            i += 1
        End While
        'MsgBox("Insert Table Item Completed")
        ProgressBar1.Value = 0
        MyRD.Close()

        '---------------------------------------- Import Invoicesub -------------------------------
        cmd.CommandText = "select count(*) from invoicesub 
                            where Docdate >= #" & bg_time.ToString("MM/dd/yyyy", _cultureENInfo) & "# and Docdate <= #" &
                            ed_time.ToString("MM/dd/yyyy", _cultureENInfo) & "#"
        InvoiceRows = cmd.ExecuteScalar()
        'MsgBox("Table Invoicesub Rows >>  " & InvoiceRows.ToString("000,000") & " Rows")
        Lb_status.Text = "Import from Invoicesub"
        ProgressBar1.Maximum = InvoiceRows

        cmd.CommandText = "select DocNo,ItemCode,ItemDesc,Qty,Price,Discount,Amount,Cost,TransType,DocDate from invoicesub
                            where Docdate >= #" & bg_time.ToString("MM/dd/yyyy", _cultureENInfo) & "# and Docdate <= #" &
                            ed_time.ToString("MM/dd/yyyy", _cultureENInfo) & "#"

        'MsgBox("select DocNo,ItemCode,ItemDesc,Qty,Price,Discount,Amount,Cost,TransType,DocDate from invoicesub
        'where Docdate >= #" & bg_time.ToString("MM/dd/yyyy", _cultureENInfo) & "# and Docdate <= #" &
        'ed_time.ToString("MM/dd/yyyy", _cultureENInfo) & "#")
        MyRD = cmd.ExecuteReader()
        i = 0
        While MyRD.Read()
            Insert_InvoiceSub(MyRD("DocNo").ToString, MyRD("ItemCode").ToString, MyRD("ItemDesc").ToString, MyRD("Qty"), MyRD("Price"),
                    MyRD("Discount").ToString, MyRD("Amount"), MyRD("Cost"), MyRD("TransType"), MyRD("DocDate"))
            BackgroundWorker1.ReportProgress(i)
            'Threading.Thread.Sleep(100)
            i += 1
        End While
        'MsgBox("Insert Table Invoicesub Completed")
        ProgressBar1.Value = 0
        MyRD.Close()

        ' --------------------------------- Import from Billpos --------------------------------------- 
        cmd.CommandText = "select count(*) from billpos INNER JOIN Ar ON BillPos.ArCode = Ar.Code 
                            where Docdate >= #" & bg_time.ToString("MM/dd/yyyy", _cultureENInfo) & "# and Docdate <= #" &
                            ed_time.ToString("MM/dd/yyyy", _cultureENInfo) & "#"
        BillPosRows = cmd.ExecuteScalar()
        'MsgBox("Table BillPos Rows >>  " & BillPosRows.ToString("000,000") & " Rows")
        Lb_status.Text = "Import from BillPos"
        ProgressBar1.Maximum = BillPosRows

        cmd.CommandText = "select BillPos.DocNo, BillPos.ArCode, Ar.Name1, BillPos.DocDate from billpos " &
                           "INNER JOIN Ar ON BillPos.ArCode = Ar.Code where Docdate >= #" & bg_time.ToString("MM/dd/yyyy", _cultureENInfo) &
                           "# and Docdate <= #" & ed_time.ToString("MM/dd/yyyy", _cultureENInfo) & "#"

        'MsgBox("select BillPos.DocNo, BillPos.ArCode, Ar.Name1, BillPos.DocDate from billpos INNER JOIN Ar ON BillPos.ArCode = Ar.Code " &
        '"where Docdate >= #" & bg_time.ToString("MM/dd/yyyy", _cultureENInfo) & "# and Docdate <= #" &
        'ed_time.ToString("MM/dd/yyyy", _cultureENInfo) & "#")
        MyRD = cmd.ExecuteReader()
        i = 0
        While MyRD.Read()
            Insert_BillPosNew(MyRD("DocNo").ToString, MyRD("ArCode").ToString, MyRD("Name1").ToString, MyRD("DocDate"))
            BackgroundWorker1.ReportProgress(i)
            'Threading.Thread.Sleep(100)
            i += 1
        End While
        'MsgBox("Insert Table BillPosNew Completed")
        MyRD.Close()
        con.Close()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Dim PercentageValue As Integer
        Me.ProgressBar1.Value = e.ProgressPercentage
        PercentageValue = (ProgressBar1.Value * 100) / ProgressBar1.Maximum
        Lb_value.Text = PercentageValue.ToString("###") & "  %"
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Bt_Im_to_MySql.Enabled = True
        Me.Bt_Analyze.Enabled = True
        Lb_status.Text = "Waiting for Analyzing Data ..."
        'Dim PyRun As String = "analyze_py.exe analyze_data " & AnalyzeDay.ToString
        'Shell(PyRun)
        'Threading.Thread.Sleep(5000)
        Analyze_Data(AnalyzeDay)
        MsgBox("Import Completed !")
        Me.Close()
    End Sub

    Private Sub DurationImportTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DurationImportTimeToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub Bt_Analyze_Click(sender As Object, e As EventArgs) Handles Bt_Analyze.Click
        'Lb_status.Text = "Analyzing Data ..."
        Me.Bt_Analyze.Enabled = False
        Me.Bt_Im_to_MySql.Enabled = False
        MsgBox("Analyzing Data for " & AnalyzeDay.ToString & " Days")
        'Dim PyRun As String = "analyze_py.exe analyze_data " & AnalyzeDay.ToString
        'Shell(PyRun)
        'Threading.Thread.Sleep(5000)
        Analyze_Data(AnalyzeDay)
        Me.Bt_Analyze.Enabled = True
        Me.Bt_Im_to_MySql.Enabled = True
        Lb_status.Text = ""
        MsgBox("Analyze Completed !")
    End Sub
End Class
