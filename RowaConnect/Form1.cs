using C3SharpInterface;
using C3SharpInterface.Requests;
using C3SharpInterface.Responses;
using Nancy.Json;
using RestSharp;
using System.Net;

namespace RowaConnect

{

    public partial class Form1 : Form
    {

        // Benutzten Variablem
        #region MainVariables
        public static string? IPAdr;
        public static int port;
        public static int SubNr;
        public static string? IDName;
        public static string? OrderID;
        public static bool Abort;
        public static bool Fault1 = false; // sub1
        public static bool Fault2 = false; // sub2
        public static bool Fault3 = false; // sub3
        public static bool Fault5 = false; // get ID
        public static bool Fault4 = false; // get order
        public static string? ProgrammName;
        public static string? deadline;
        public static string? finishedTime;
        public static string? orderStatus;
        public static string? _Root;
        public static string? ProgramPath;
        public static string? RBname;
        public static string? ResponseError;
        public static int planParts;
        public static int prodParts;
        public static int ErrorNummer;
        public static string? startTime;
        public static string? workingStation;

        public static int planCycleTime;
        public static int processingLength;
        public static float VersionOnRobot;
        public static int VersionServer;
        public string dateNow = DateTimeOffset.Now.ToString("g");
        public string data = DateTime.Now.ToString("yyyy-MM-dd");
        #endregion

        private static C3SharpInterface.SyncClient syncClient = new SyncClient();

        
        public Form1()
        {
            // GUI laden

            InitializeComponent();
            ProgramRun.WorkerSupportsCancellation = true;
            // TEST PURPOSE ONLY!!
            //CheckForIllegalCrossThreadCalls = false;
            Unconnect_label.Enabled = false;
            button1.Enabled = false;
            button2.Enabled= false;
            Connect_TB.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) // das ist wegen IP adress, dass kan man nur Number und punkt schreiber�n
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void Connect_TB_Click(object sender, EventArgs e)
        {
            // was passiert nach IP und port schreiben 

            label3.Text = "        Connecting..."; 
            IPAddress? IP;
            bool connected;

            IPAdr = IpAdress_box.Text;
            bool connectingOK = IPAddress.TryParse(IPAdr, out IP); //pruef ob IP passt
            port = Convert.ToInt32(Port_box.Text);


            if (connectingOK)
            {
                try
                {
                    // wenn IP ist OK und 
                    syncClient.ConnectToHost(IPAddress.Parse(IPAdr), port);
                    connected = true;


         
                    label3.Text = "        Connection OK, choose a working path";
                    label3.Image = Image.FromFile(@"icons8-documents-folder-18.png");
                    this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    // kommunikation zwischen Server und Handler - hier Robnameabfrage

                    VariableValueResponse valueResponse1 = (VariableValueResponse)syncClient.SendRequest(new ReadVariableRequest("$ROBNAME[]"));
                    RBname = valueResponse1.Value;
                    Console.AppendText("[Info: " + dateNow + "] " + "Connection to " + RBname + " established, please choose a path" + System.Environment.NewLine);

                    // pr�f welche folder sind am Roboter

                    ListDirectoryRequest request21 = new ListDirectoryRequest(@"KRC:\");
                    ListDirectoryResponse response21 = (ListDirectoryResponse)syncClient.SendRequest(request21);

                   
                    var programmsList = new List<string>();
                    for (int i = 0; i < response21.Count; i++)

                    {
                        programmsList.Add(response21[i].ToString());
                    }

                    Program_box.Items.AddRange(programmsList.ToArray());

                    Connect_TB.Text = "  Connection OK";
                    Connect_TB.Enabled = false;
                    Unconnect_label.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = false;


                }
                catch (Exception ex)

                {
                    // info, in falls IP ist falsch oder c3 bridge ist nicht eingeschalten
                    connected = false;

                    Console.AppendText("[Warning: " + dateNow + "] " + "Connection not established. Check if C3Bridge on the Robot is on, port 7000 is allowed and IP adress is correct" + System.Environment.NewLine);
                    connected = false;
                    label3.Text = "        Not connected";
                    label3.Image = Image.FromFile(@"icons8-close-20.png");
                    Connect_TB.Enabled = true;
                    Unconnect_label.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
            }
            else 
            {
                // info, wenn IP ist falsch
                Console.AppendText("[Error: " + dateNow + "] " + "IP Address is wrong" + System.Environment.NewLine);

                label3.Text = "        Not connected";

            }

        }

        private void Unconnect_label_Click(object sender, EventArgs e)
        {
            syncClient.AbortConnection();
            if (ProgramRun.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                ProgramRun.CancelAsync();
            }
            label3.Text = "        Not connected ";
            Connect_TB.Text = "     Check Connection";
            label3.Image = Image.FromFile(@"icons8-close-20.png");
            Abort = true;
            Program_box.Items.Clear();

            Unconnect_label.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            Connect_TB.Enabled = true;
        }

        // Data und Value lesen von txt files
        public class DataLesen
        {
            public object? DataOnRobot { get; set; }

            public void ReadConfig(string txtFile1)
            {

                var dict = File.ReadAllLines(txtFile1)
                               .Select(l => l.Split(new[] { ';' }))
                               .ToDictionary(s => s[0].Trim(), s => s[1].Trim());  // read the entire file into a dictionary.

                try  // exception for new programms
                {
                    DataOnRobot = Convert.ToString(dict[Form1.ProgrammName]);
                }
                catch (Exception ex)
                {

                }



            }

        }
        public class ValueLesen
        {
            public int ValueOnRobot { get; set; }

            public void ReadConfig(string txtFile1)
            {

                var dict = File.ReadAllLines(txtFile1)
                               .Select(l => l.Split(new[] { ';' }))
                               .ToDictionary(s => s[0].Trim(), s => s[1].Trim());  // read the entire file into a dictionary.
                try // exception for new programms
                {
                    ValueOnRobot = Convert.ToInt32(dict[Form1.ProgrammName]);

                }
                catch (Exception ex)
                {

                }
            }
        }
        private void ProgramRun_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {


            // infinite loop f�r program 
            for (; ; )
            {
                API.Subscription1();
                API.Subscription2();
                API.Subscription3();
                API.Subscription4();


                DataLesen dictLesen = new DataLesen();
                dictLesen.ReadConfig(@"ProgramDict.txt");
                ValueLesen valueLesen = new ValueLesen();
                valueLesen.ReadConfig(@"ValueDict.txt");


                // neu dictionary in program von txt files
                Dictionary<string, string> ProgramDict = new Dictionary<string, string>();
                Dictionary<string, float> ValueDict = new Dictionary<string, float>();


                try
                {
                    ProgramDict.Add(ProgrammName, Convert.ToString(dictLesen.DataOnRobot));
                }
                catch (Exception ex)
                {
                    SubNr = 0;

                }


                if (SubNr == 1 || SubNr == 4)
                {                 
                    FilePropertiesRequest request26 = new FilePropertiesRequest(@"KRC:\" + ProgramPath + ProgrammName);

                    FilePropertiesResponse response26 = (FilePropertiesResponse)syncClient.SendRequest(request26);
                    if (response26.Success)
                    {


                        // VersDat is a string variable make from data we get from robot
                        string VersDat = Convert.ToString(response26.LastWriteTime);

                        string VersDatOnRobot;
                        // wenn wir haben das program schon in txt file wir nehmen deten von letze modifikation

                        if (ProgramDict.ContainsKey(ProgrammName) == true)
                        {

                            ProgramDict.TryGetValue(ProgrammName, out VersDatOnRobot);

                        }
                        // wenn nicht, dann wir machen neu program f�r dictionary (neue variable)
                        else
                        {
                            ProgramDict.Add(ProgrammName, VersDat);
                            VersionOnRobot = 1;
                            ValueDict.Add(ProgrammName, VersionOnRobot);
                            VersDatOnRobot = VersDat;

                        }
                        // Wenn letze modifikation data ist anders als in dictionary wir macher neue program version und schreiben es zu dictionary

                        if (VersDat != VersDatOnRobot)
                        {
                            VersionOnRobot = valueLesen.ValueOnRobot;
                            VersionOnRobot++;
                            VersDatOnRobot = VersDat;

                            ProgramDict[ProgrammName] = VersDatOnRobot;
                            ValueDict[ProgrammName] = VersionOnRobot;
                        }
                        else

                        //  wenn ist gleich, dann wir lesen von dictionary program version
                        {
                            VersionOnRobot = valueLesen.ValueOnRobot;
                            ValueDict[ProgrammName] = VersionOnRobot;
                        }

                        #region dict to file 

                        // speichern dictionary to txt file
                        string lines = System.IO.File.ReadAllText(@"ProgramDict.txt");

                        if (lines.Contains(ProgrammName))
                        {
                            {
                                lines = lines.Replace(ProgrammName + ";" + dictLesen.DataOnRobot, ProgrammName + ";" + VersDatOnRobot);

                            }
                            File.WriteAllText(@"ProgramDict.txt", lines);
                        }
                        else
                        {

                            string filePath = @"ProgramDict.txt";
                            using (FileStream fs = new FileStream(filePath, FileMode.Append))
                            {
                                using (TextWriter tw = new StreamWriter(fs))

                                    foreach (KeyValuePair<string, string> kvp in ProgramDict)
                                    {

                                        tw.WriteLine(string.Format("{0};{1}", kvp.Key, kvp.Value));

                                    }
                            }

                        }
                        string lines2 = System.IO.File.ReadAllText(@"ValueDict.txt");

                        if (lines2.Contains(ProgrammName))
                        {
                            {
                                lines2 = lines2.Replace(ProgrammName + ";" + valueLesen.ValueOnRobot, ProgrammName + ";" + VersionOnRobot);

                            }
                            File.WriteAllText(@"ValueDict.txt", lines2);
                        }
                        else
                        {
                            string filePath2 = @"ValueDict.txt";
                            using (FileStream fs = new FileStream(filePath2, FileMode.Append))
                            {
                                using (TextWriter tw = new StreamWriter(fs))

                                    foreach (KeyValuePair<string, float> kvp1 in ValueDict)
                                    {
                                        tw.WriteLine(string.Format("{0};{1}", kvp1.Key, kvp1.Value));
                                    }
                            }

                        }
                        #endregion

                        API.Answer();

                        if (Console.InvokeRequired)

                        {
                            Console.Invoke(new MethodInvoker(delegate {
                                Console.AppendText( "[Info: " + dateNow + "] " + "Program ->" + ProgrammName + "<- data succesfully transmitted " + System.Environment.NewLine);
                            }));
                        }
                       
                        Fault1 = true;
                        Fault4 = true;
                        Fault5 = true;
                        SubNr = 0;
                    }
                }

                if (SubNr == 2)
                {
                    // von KRC to server
                    SetFileAttributesRequest request20 = new SetFileAttributesRequest(@"KRC:\" + ProgramPath + ProgrammName, ItemAttribute.None, ItemAttribute.None);

                    Response response = syncClient.SendRequest(request20);

                    // Move
                    response = syncClient.SendRequest(new CopyFileRequest(@"KRC:\" + ProgramPath  + ProgrammName, @"" + Form1._Root + ProgrammName + "_V" + Form1.VersionOnRobot));

                    SubNr = 0;

                    if (Console.InvokeRequired)

                    {
                        Console.Invoke(new MethodInvoker(delegate {
                            Console.AppendText("[Info: " + dateNow + "] " + "Version " + VersionOnRobot +" of Program ->" + ProgrammName + "<- succesfully tranfered from \"KRC:\\ " + ProgramPath + " to " + Form1._Root + System.Environment.NewLine);
                        }));
                    }
                    Fault2 = true;
                    Fault4 = true;
                    Fault5 = true;


                }

                if (SubNr == 3)
                { 
                    // von server to KRC
 
                    SetFileAttributesRequest request21 = new SetFileAttributesRequest(@"" + Form1._Root  + ProgrammName + "_V" + VersionServer, ItemAttribute.None, ItemAttribute.None);

                    Response response1 = syncClient.SendRequest(request21);

                    // Move
                    response1 = syncClient.SendRequest(new CopyFileRequest(@"" + Form1._Root + ProgrammName + "_V" + VersionServer, @"KRC:\" + ProgramPath + ProgrammName));


                    SubNr = 0;

                   
                    if (Console.InvokeRequired)

                    {
                        Console.Invoke(new MethodInvoker(delegate {
                            Console.AppendText("[Info: " + dateNow + "] " + "Version " + VersionServer +  " of Program ->" + ProgrammName + "<- succesfully tranfered from " + Form1._Root  + " to \"KRC:\\ " + ProgramPath + "\"" + System.Environment.NewLine);
                        }));
                    }

                    Fault3 = true;
                    Fault4 = true;
                    Fault5  = true;

                }

                if (Form1.Abort==true)
                {
                   
                    Form1.Abort = false;
                    return;
                }

                if (Form1.ErrorNummer == 1) 
                {
                    Console.Invoke(new MethodInvoker(delegate {
                        Console.AppendText("[Error: " + dateNow + "]" + "Error occured  while connecting to OCB, check if entity is added and port 1026 is connected. Response code: " + ResponseError + System.Environment.NewLine);
                    }));
                    Form1.ErrorNummer = 0;
                }

                if (Form1.ErrorNummer == 2) 
                {
                    Console.Invoke(new MethodInvoker(delegate {
                        Console.AppendText("[Error: " + dateNow + "]" + "Error occured  while connecting to 10.92.80.10:5011, check if subscription manager is on" + System.Environment.NewLine);
                    }));
                    Form1.ErrorNummer = 0;

                }

                if (ProgramRun.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }


            }

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is a part of a bigger project, to work with it, check our github, link below." + System.Environment.NewLine + "This programm allows to download, upload and getting program Information directly from HMI." + System.Environment.NewLine + "Check readme for connection manual." + System.Environment.NewLine + System.Environment.NewLine + "https://github.com/dih2-rowa/programhandler" , "Info", MessageBoxButtons.OK, MessageBoxIcon.None);

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Program bases on C3Bridge Open Source." + System.Environment.NewLine + "Made by Rowa Automation." + System.Environment.NewLine + "For questions and contact please send an e - mail to marlena.pirchl@rowa-automation.at or max-hoedl@rowa-automation.at.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Clean_TB_Click(object sender, EventArgs e)
        {
            Console.Clear();

        }



        private void Program_box_SelectedValueChanged(object sender, EventArgs e)
        {
            Form1.ProgramPath = Program_box.Items[Program_box.SelectedIndex].ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (ProgramRun.IsBusy != true)
            {
                ProgramRun.RunWorkerAsync();
            }
            VariableValueResponse valueResponse1 = (VariableValueResponse)syncClient.SendRequest(new ReadVariableRequest("$ROBNAME[]"));
            RBname = valueResponse1.Value;
            label3.Text = "        Connected. Working path: " + Form1.ProgramPath;
            label3.Image = Image.FromFile(@"icons8-ok-20.png");

            Console.AppendText("[Info: " + dateNow + "] " + RBname + "Connected" + System.Environment.NewLine);
            button2.Enabled = false;
            button1.Enabled = false;
            Connect_TB.Enabled = false;
            Unconnect_label.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1._Root = Root.Text;
            if (Form1._Root == null)
            {
                Console.AppendText("[Info: " + dateNow + "] " + "Download/Upload path is empty, please add it." + System.Environment.NewLine);
            }
            else
            {
                Console.AppendText("[Info: " + dateNow + "] " + "Choosen path: " + Form1.ProgramPath + " If it is correct, connect to robot, if not, change a path." + System.Environment.NewLine + "[Info: " + dateNow + "] " + "Path for Download/Upload: " + Form1._Root + " If it is correct, connect to robot, if not, change a path." + System.Environment.NewLine);
                button2.Enabled = true;
                button1.Enabled = true;
                Connect_TB.Enabled = false;
                Unconnect_label.Enabled = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;

        }

        private void Console_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                ShowInTaskbar = false;
            }
        }


        private void Port_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }








    #region variable

    public class DataSub1
    {
        public List<DatumDto>? data { get; set; }

    }
    public class DatumDto
    {
        public ProductID productID { get; set; }

        public OrderID orderID { get; set; }
    }
    public class ProductID
    {

        public string value { get; set; }
    }
    public class OrderID
    {

        public string value { get; set; }
    }

    public class IdName
    {

        public ItemID productID { get; set; }
        public Deadline deadline { get; set; }
        public FinishedTime finishedTime { get; set; }
        public OrderStatus orderStatus { get; set; }
        public PlanParts planParts { get; set; }
        public ProdParts prodParts { get; set; }
        public StartTime startTime { get; set; }
        public WorkingStation workingStation { get; set; }

    }

    public class ItemID
    {
        public string value { get; set; }
    }

    public class Deadline
    {
        public string value { get; set; }
    }
    public class FinishedTime
    {
        public string value { get; set; }
    }
    public class OrderStatus
    {
        public string value { get; set; }
    }
    public class PlanParts
    {
        public int value { get; set; }
    }
    public class ProdParts
    {
        public int value { get; set; }
    }
    public class StartTime
    {
        public string value { get; set; }
    }
    public class WorkingStation
    {
        public string value { get; set; }
    }


    public class ProductName
    {

        public ProgramName programName { get; set; }
        public PlanCycleTime planCycleTime { get; set; }
        public ProcessingLength processingLength { get; set; }
        public ProgramVersion programVersion { get; set; }

    }

    public class ProgramVersion
    {
        public int value { get; set; }
    }

    public class ProgramName
    {
        public string value { get; set; }
    }
    public class PlanCycleTime
    {
        public int value { get; set; }
    }
    public class ProcessingLength
    {
        public int value { get; set; }
    }
    #endregion

    public class API
    {

        public static void Answer()
        {
            if (Form1.SubNr == 4)
            {

                // das ist ok
                var client = new RestClient("http://10.92.80.10:1026/");
                var request = new RestRequest("v2/entities/Robot1/attrs/writeOrderstatus?type=Order", Method.Put);
                request.AddHeader("fiware-service", "robot_info");
                request.AddHeader("fiware-servicepath", "/demo");
                request.AddHeader("Content-Type", "application/json");


                var body = @"{" + "\n" + @"""value"": [""" + Form1.orderStatus + @""", """ + Form1.ProgrammName + @""", """ + Form1.OrderID + @""",  " + Form1.VersionServer + @", " + Form1.VersionOnRobot + @", " + Form1.planCycleTime + @", " + Form1.planParts + "]," + "\n" +
                @"   ""type"": ""command""" + "\n" + @"}";
                string body1 = Convert.ToString(body);



                request.AddJsonBody(body1);

                client.Execute(request);
            }

            if (Form1.SubNr == 1)
            {

                // hier ist url zu wechseln wenn neue subscription funktioniert
                var client = new RestClient("http://10.92.80.10:1026/");
                var request = new RestRequest("v2/entities/Robot1/attrs/writeOrderstatus?type=Order", Method.Put); // here writeOrderStatus?type=Order to writeProductstatus?type=Product
                request.AddHeader("fiware-service", "robot_info");
                request.AddHeader("fiware-servicepath", "/demo");
                request.AddHeader("Content-Type", "application/json");


                var body = @"{" + "\n" + @"""value"": [""-"",""" + Form1.ProgrammName + @""",""" + Form1.OrderID + @"""," + Form1.VersionServer + @"," + Form1.VersionOnRobot + @",0,0]," + "\n" +
                @"   ""type"": ""command""" + "\n" + @"}";
                string body1 = Convert.ToString(body);



                request.AddJsonBody(body1);

                client.Execute(request);
            }


        }
        public static void GetProgramData()

        {
            // json lesen und data von programm nehmen 

            var client = new RestClient("http://10.92.80.10:1026/");
            var request = new RestRequest("/v2/entities/" + Form1.OrderID);
            request.AddHeader("fiware-service", "robot_info");
            request.AddHeader("fiware-servicepath", "/demo");
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                string rawResponse2 = response.Content;

                ProductName programName = new JavaScriptSerializer().Deserialize<ProductName>(rawResponse2);
                try
                {

                    Form1.ProgrammName = programName.programName.value;
                    Form1.planCycleTime = Convert.ToInt32(programName.planCycleTime.value);
                    Form1.processingLength = Convert.ToInt32(programName.processingLength.value);
                    Form1.VersionServer = Convert.ToInt32(programName.programVersion.value);



                }
                catch (NullReferenceException ex)
                {
                }
            }
            else
            {
                if (Form1.Fault5 == true )
                {
                    Form1.ErrorNummer = 1;
                    Form1.Fault5 = false;
                }

                Form1.ResponseError = Convert.ToString(response.StatusCode);

            }




        }


        public static void GetDataID()

        {
            // json lesen und data von programm nehmen 

            var client = new RestClient("http://10.92.80.10:1026/");
            var request = new RestRequest("v2/entities/" + Form1.IDName, Method.Get);
            request.AddHeader("fiware-service", "robot_info");
            request.AddHeader("fiware-servicepath", "/demo");
            var response = client.Execute(request);
            if (Form1.IDName != null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    string rawResponse1 = response.Content;


                    Console.WriteLine(rawResponse1);
                    IdName itemID = new JavaScriptSerializer().Deserialize<IdName>(rawResponse1);
                    if (Form1.SubNr == 1)
                    {
                        Form1.OrderID = Form1.IDName;
                        GetProgramData();
                    }
                    else 
                    { 
                    Form1.OrderID = itemID.productID.value;
                    Form1.deadline = itemID.deadline.value;
                    Form1.finishedTime = itemID.finishedTime.value;
                    Form1.orderStatus = itemID.orderStatus.value;
                    Form1.planParts = itemID.planParts.value;
                    Form1.prodParts = itemID.prodParts.value;
                    Form1.startTime = itemID.startTime.value;
                    Form1.workingStation = itemID.workingStation.value;
                    GetProgramData();
                     }
                }
                else
                {
                    if (Form1.Fault4 == true)
                    {
                        Form1.ErrorNummer = 1;
                        Form1.Fault4 = false;
                    }

                    Form1.ResponseError = Convert.ToString(response.StatusCode);
                    if (Form1.ProgrammName == null)
                        Form1.SubNr = 0;
                }
            }



        }

        public static void Subscription1()

        {

            // 4 sub, in falls, brauchst du neue, enfach copy paste und name wechseln

            var client = new RestClient("http://10.92.80.10:5011/");
            var request = new RestRequest("/Subscription1");
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {


                string Sub1 = System.IO.File.ReadAllText(@"Sub1.txt");

                string rawResponse = response.Content;

                if (Sub1 != rawResponse)
                {
                    try
                    {
                        DataSub1 datumDto = new JavaScriptSerializer().Deserialize<DataSub1>(rawResponse); ;
                        foreach (var item in datumDto.data)
                        {

                            Form1.IDName = item.productID.value;

                        }

                        File.WriteAllTextAsync(@"Sub1.txt", rawResponse);
                        Form1.SubNr = 1;
                       GetDataID();

                    }
                    catch (Exception ex)

                    {

                        Form1.SubNr = 0;
                    }
                }

            }
            else
            {
                if (Form1.Fault1 == true)
                {
                    Form1.ErrorNummer = 2;
                    Form1.Fault1 = false;
                    Form1.SubNr = 0;

                }
            }

        }
        public static void Subscription2() // Server to robot 

        {
            var client = new RestClient("http://10.92.80.10:5011/");
            var request = new RestRequest("/Subscription2");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string Sub2 = System.IO.File.ReadAllText(@"Sub2.txt");

                string rawResponse = response.Content;

                if (Sub2 != rawResponse)
                {

                    try
                    {
                        DataSub1 datumDto = new JavaScriptSerializer().Deserialize<DataSub1>(rawResponse); ;
                        foreach (var item in datumDto.data)
                        {

                            Form1.IDName = item.productID.value;


                        }
                        File.WriteAllTextAsync(@"Sub2.txt", rawResponse);
                        Form1.SubNr = 2;
                        GetDataID();
                    }
                    catch (Exception ex)

                    {
                        Form1.SubNr = 0;


                    }
                }

            }
            else
            {
                if (Form1.Fault2 == true)
                {
                    Form1.ErrorNummer = 2;
                    Form1.Fault2 = false;
                    Form1.SubNr = 0;

                }
            }

        }
        public static void Subscription3()  // Robot to server
        {
            var client = new RestClient("http://10.92.80.10:5011/");
            var request = new RestRequest("/Subscription3");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string Sub3 = System.IO.File.ReadAllText(@"Sub3.txt");

                string rawResponse = response.Content;

                if (Sub3 != rawResponse)
                {

                    try
                    {
                        DataSub1 datumDto = new JavaScriptSerializer().Deserialize<DataSub1>(rawResponse); ;
                        foreach (var item in datumDto.data)
                        {

                            Form1.IDName = item.productID.value;

                        }
                        File.WriteAllTextAsync(@"Sub3.txt", rawResponse);
                        Form1.SubNr = 3;
                        GetDataID();
                    }
                    catch (Exception ex)

                    {
                        Form1.SubNr = 0;

                    }
                }

            }
            else
            {
                if (Form1.Fault3 == true)
                {
                    Form1.ErrorNummer = 2;
                    Form1.Fault3 = false;
                    Form1.SubNr = 0;

                }
            }

        }

        public static void Subscription4()  // Auftragsnummer 

        {

            var client = new RestClient("http://10.92.80.10:5011/");
            var request = new RestRequest("/Subscription4");
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {


                string Sub4 = System.IO.File.ReadAllText(@"Sub4.txt");

                string rawResponse = response.Content;

                if (Sub4 != rawResponse)
                {
                    try
                    {
                        DataSub1 datumDto = new JavaScriptSerializer().Deserialize<DataSub1>(rawResponse); ;
                        foreach (var item in datumDto.data)
                        {
                            Form1.IDName = item.orderID.value;

                        }

                        File.WriteAllTextAsync(@"Sub4.txt", rawResponse);
                        Form1.SubNr = 4;
                        GetDataID();

                    }
                    catch (Exception ex)

                    {
                        Form1.SubNr = 0;
                    }
                }

            }
            else
            {
                if (Form1.Fault1 == true)
                {
                    Form1.ErrorNummer = 2;
                    Form1.Fault1 = false;
                    Form1.SubNr = 0;

                }
            }

        }
    }

}

    