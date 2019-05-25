using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ServiceProcess;


namespace PostgreDB_Backup_Restore
{
    public partial class Form2 : Form
    {
        public NpgsqlConnection m_NpgsqlConnection;
        string strConnection = "";
        string strServer = string.Empty;
        string strPort = string.Empty;
        string strDatabaseName = string.Empty;
        StringBuilder sbPG_dumpPath = new StringBuilder();
        String strPG_dumpPath = String.Empty;
        string strInstallLocation = string.Empty;


        public Form2()
        {
            try
            {
                InitializeComponent();
                strConnection = "Server=localhost;Port=5432;Database=postgres;Userid=postgres;Password=sistemas;";

                int start = strConnection.IndexOf("Server");
                start = start + ("Server").Length + 1;
                int end = strConnection.IndexOf(";", start);
                end = end - start;
                strServer = strConnection.Substring(start, end);

                start = strConnection.IndexOf("Port");
                start = start + ("Port").Length + 1;
                end = strConnection.IndexOf(";", start);
                end = end - start;
                strPort = strConnection.Substring(start, end);
            }
            catch (Exception ex)
            { }

        }

        private void btnCheckPostgres_Click(object sender, EventArgs e)
        {
            try
            {
                if (sbPG_dumpPath.Length == 0)
                {
                    string strProcess = System.IO.Path.GetDirectoryName(Application.StartupPath) + "\\Progress.exe";
                    Process objProcess = null;
                    if (System.IO.File.Exists(strProcess))
                    {
                        objProcess = new Process();
                        objProcess = Process.Start(strProcess);
                    }

                    bool bPostgresService = false;
                    ServiceController[] services = ServiceController.GetServices();
                    // try to find service name
                    foreach (ServiceController service in services)
                    {
                        if (service.ServiceName.Contains("postgre") == true)
                        {
                            bPostgresService = true;
                            break;
                        }
                    }
                    if (bPostgresService == true)
                    {
                        PG_DumpExePath();
                        objProcess.Kill();
                        if (sbPG_dumpPath.Length != 0)
                        {
                            MessageBox.Show("Your System is INSATALLED with Postgres");
                            labelLocation.Text = "Installation Location is " + strInstallLocation;
                            labelLocation.Visible = true;
                            btnCheckPostgres.BackColor = Color.Green;
                            panel1.Enabled = true;
                        }

                    }
                    else
                    {
                        objProcess.Kill();
                        MessageBox.Show("Your System is NOT INSATALLED with Postgres");
                    }
                }
            }
            catch (Exception ex)
            { }


        }

        private void PG_DumpExePath()
        {
            try
            {
                // Do not change lines / spaces b/w words.
                if (sbPG_dumpPath.Length == 0)
                {
                    //string strPG_dumpPath = string.Empty;
                    if (strPG_dumpPath == string.Empty)
                    {
                        strPG_dumpPath = LookForFile("pg_dump.exe");
                        if (strPG_dumpPath == string.Empty)
                        {
                            MessageBox.Show("Postgres is not installed");
                        }
                    }

                    int a = strPG_dumpPath.IndexOf(":\\", 0);
                    a = a + 2;
                    string strSub = strPG_dumpPath.Substring(0, (a - 2));
                    strPG_dumpPath = strPG_dumpPath.Substring(a, (strPG_dumpPath.Length - a));

                    StringBuilder sbSB1 = new StringBuilder(strPG_dumpPath);
                    sbSB1.Replace("\\", "\r\n\r\ncd ");

                    StringBuilder sbSB2 = new StringBuilder("cd /D ");
                    sbSB2.Append(strSub);
                    sbSB2.Append(":\\");

                    sbSB1 = sbSB2.Append(sbSB1);
                    sbSB1 = sbSB1.Remove((sbSB1.Length - 3), 3);
                    sbPG_dumpPath = sbSB1;
                    strPG_dumpPath = sbSB1.ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        private string LookForFile(string strFileName)
        {
            string strPG_dumpPath = string.Empty;
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    strPG_dumpPath = performFileSearchTask(drive.Name, strFileName);
                    if (strPG_dumpPath.Length != 0)
                        break;
                }

            }
            catch (Exception ex)
            { }
            return strPG_dumpPath;
        }

        private string performFileSearchTask(string dirName, string strfileName)
        {
            try
            {
                if (strPG_dumpPath.Length == 0)
                {
                    try
                    {

                        foreach (string ddir in Directory.GetDirectories(dirName))
                        {
                            System.Security.Permissions.FileIOPermission ReadPermission =
                                new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, ddir);
                            if (System.Security.SecurityManager.IsGranted(ReadPermission))
                            {
                                try
                                {
                                    foreach (string dfile in Directory.GetFiles(ddir, strfileName))
                                    {
                                        strPG_dumpPath = ddir + "\\";
                                        if (strPG_dumpPath.Length > 0)
                                        {
                                            strInstallLocation = strPG_dumpPath;
                                            break;
                                        }
                                    }
                                    if (strPG_dumpPath.Length == 0)
                                        performFileSearchTask(ddir, strfileName);
                                }
                                catch (Exception ex)
                                { }
                            }
                            if (strPG_dumpPath != string.Empty)
                                break;
                        }
                    }
                    catch (Exception ex)
                    { }

                }

            }
            catch (Exception ex)
            { }
            return strPG_dumpPath;
        }

        /// <summary>
        /// This function checks for the Postgres DB existance, if exists gets all the Databases availlable from Postgres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDB_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                strDatabaseName = comboBox1.Text;
            }
            catch (Exception ex)
            { }
        }

        private void butSelectLoc_Click(object sender, EventArgs e)
        {
            //Path to be saved for the backup file
            try
            {
                textBox1.Text = string.Empty;
                butBackup.Enabled = false;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Location for BackUp File";
                saveFileDialog1.Filter = "Backup File|*.backup";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.RestoreDirectory = true;
                string fileName = strDatabaseName + "_Backup" + "_" + System.DateTime.Now.ToString("ddMMyyyy_HHmm");
                saveFileDialog1.FileName = fileName;

                //use a if here to see if the user actually click save button.
                //if DialogResult.OK means the user actually click save button.
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = saveFileDialog1.FileName;
                    butBackup.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void butBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "-------")
                {
                    MessageBox.Show("Select the location to save");
                    return;
                }
                StreamWriter sw = new StreamWriter("DBBackup.bat");
                // Do not change lines / spaces b/w words.
                StringBuilder strSB = new StringBuilder(strPG_dumpPath);

                if (strSB.Length != 0)
                {
                    strSB.Append("pg_dump.exe --host " + strServer + " --port " + strPort + " --username postgres --format custom --blobs --verbose --file ");
                    strSB.Append("\"" + textBox1.Text + "\"");
                    strSB.Append(" \"" + strDatabaseName + "\r\n\r\n");
                    sw.WriteLine(strSB);
                    sw.Dispose();
                    sw.Close();
                    Process processDB = Process.Start("DBBackup.bat");
                    do
                    {//dont perform anything
                    }
                    while (!processDB.HasExited);
                    {
                        MessageBox.Show(strDatabaseName + " Successfully Backed up at " + textBox1.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Please Provide the Location to take Backup!");
                }
            }
            catch (Exception ex)
            { }
        }

        private void butBackupFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                txtBackupFilePath.Text = string.Empty;
                butRestore.Enabled = false;
                OpenFileDialog objOpenFileDialog = new OpenFileDialog();
                objOpenFileDialog.Title = "Selecting Backup File";
                objOpenFileDialog.Filter = "backup files|*.backup";
                objOpenFileDialog.RestoreDirectory = true;
                if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupFilePath.Text = objOpenFileDialog.FileName;
                    butRestore.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void butRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBackupFilePath.Text == string.Empty)
                {
                    MessageBox.Show("Select backup file");
                    return;
                }
                //check for the pre-requisites before restoring the database.*********
                if (strDatabaseName != "")
                {
                    if (txtBackupFilePath.Text != "")
                    {
                        StreamWriter sw = new StreamWriter("DBRestore.bat");
                        // Do not change lines / spaces b/w words.
                        StringBuilder strSB = new StringBuilder(strPG_dumpPath);
                        if (strSB.Length != 0)
                        {
                            checkDBExists(strDatabaseName);
                            strSB.Append("pg_restore.exe --host " + strServer + " --port " + strPort + " --username postgres --dbname");
                            strSB.Append(" \"" + strDatabaseName + "\"");
                            strSB.Append(" --verbose ");
                            strSB.Append("\"" + txtBackupFilePath.Text + "\"");
                            sw.WriteLine(strSB);
                            sw.Dispose();
                            sw.Close();
                            Process processDB = Process.Start("DBRestore.bat");
                            do
                            {//dont perform anything
                            }
                            while (!processDB.HasExited);
                            {
                                MessageBox.Show("Successfully restored " + strDatabaseName + " Database from " + txtBackupFilePath.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the save path to get the backup!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Database name to Restore!");
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// This function check for the database existance, if database exists the the database droped and created, if not existing create it.
        /// </summary>
        /// <param name="strdatabase"></param>
        /// <returns></returns>
        private bool checkDBExists(string strdatabase)
        {
            try
            {
                string DBlist = "SELECT datname FROM pg_database WHERE datistemplate IS FALSE AND datallowconn IS TRUE AND datname!='postgres';";
                DataSet ds = new DataSet();
                ds = GetData(DBlist);
                bool databaseExists = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0].ToString() == strdatabase)
                    {
                        databaseExists = true;
                        break;
                    }
                }
                if (databaseExists)//existing database
                {
                    //close the DB connections
                    string str = "select pg_terminate_backend(procpid) from pg_stat_activity where datname='" + strdatabase + "'";
                    ExecuteQuery(str);
                    //drop the database
                    string str1 = "drop database \"" + strdatabase + "\" ";
                    ExecuteQuery(str1);

                    string str2 = "create database \"" + strdatabase + "\" ";
                    ExecuteQuery(str2);

                    return true;
                }
                else//new database
                {
                    //create the database
                    string str = "create database \"" + strdatabase + "\" ";
                    ExecuteQuery(str);
                    Thread.Sleep(1000);
                    return true;
                }

                //return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteQuery(string strQuery)
        {
            bool bstatus = false;
            try
            {
                NpgsqlConnection m_NpgsqlConnection = new NpgsqlConnection(strConnection);
                int snReturnValue = 0;

                try
                {
                    if (m_NpgsqlConnection.State != ConnectionState.Open)
                        m_NpgsqlConnection.Open();
                    if (m_NpgsqlConnection.State == ConnectionState.Open)
                    {
                        NpgsqlCommand objSqlCommand = new NpgsqlCommand(strQuery, m_NpgsqlConnection);

                        snReturnValue = objSqlCommand.ExecuteNonQuery();
                        if (snReturnValue == -1)
                            bstatus = false;
                        else
                            bstatus = true;
                    }
                    if (m_NpgsqlConnection.State == ConnectionState.Open)
                        m_NpgsqlConnection.Close();

                    if (m_NpgsqlConnection != null)
                        m_NpgsqlConnection.Dispose();
                }
                catch (Exception ex)
                {
                    bstatus = false;

                    if (m_NpgsqlConnection.State == ConnectionState.Open)
                        m_NpgsqlConnection.Close();

                    if (m_NpgsqlConnection != null)
                        m_NpgsqlConnection.Dispose();
                }
            }
            catch (Exception ex)
            { }
            return bstatus;

        }

        /// <summary>
        /// Supply the query and get the data
        /// into DataSet. If GetData method fails, DataSet object will be NULL.
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns>DataSet Object</returns>
        public DataSet GetData(string strQuery)
        {
            DataSet objDataSet = new DataSet();
            try
            {
                // if (m_NpgsqlConnection == null)
                {
                    m_NpgsqlConnection = new NpgsqlConnection(strConnection);
                }

                NpgsqlDataAdapter objSqlAdapter = new NpgsqlDataAdapter(strQuery, m_NpgsqlConnection);
                objSqlAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception Ex)
            {
                objDataSet = null;
                return objDataSet;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            this.Location = new Point(350, 350);
        }

   

      

    }

}



