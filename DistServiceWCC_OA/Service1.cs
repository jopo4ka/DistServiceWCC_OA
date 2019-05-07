using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WCCOACOMLib;

namespace DistServiceWCC_OA
{
    public partial class Service1 : ServiceBase
    {
        WCCOA_COM wccoa_com;
        public Service1()
        {
            InitializeComponent();
            wccoa_com = new WCCOA_COM();
        }

        protected override void OnStart(string[] args)
        {
            wccoa_com.checkDp("Server_OPI:1_GZU_1_otvod.Current_otvod");
        }
        protected override void OnStop()
        {
        }
    }

    class WCCOA_COM
    {
        public ComManager wcc;
        public WCCOA_COM()
        {
            wcc  = new ComManager();
            wcc.Init("-currentproject");
        }
        public void checkDp(string dp)
        {
            object val;
            wcc.dpGet(dp, out val);
            int mVal = Int32.Parse(val.ToString());
            if(mVal != 0)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    Arguments = @"mkdir C:/ss/ss"
                };
            }
            else
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    Arguments = @"mkdir C:/ss/ss"
                };
            }
        }
        public void getDp(string dp, out object val)
        {
            wcc.dpGet(dp, out val);
        }
    }
}
