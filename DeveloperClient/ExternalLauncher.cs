using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace DeveloperClient
{
    public class ExternalLauncher
    {
        private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NoMachine\Connection to 134.129.125.246.nxs";

        public ExternalLauncher()
        {
            if (!File.Exists(PATH))
            {
                File.Move(Environment.CurrentDirectory + @"\Dependencies\Connection to 134.129.125.246.nxs", PATH);
            }
        }

        public void Launch()
        {
            Process.Start(PATH);
        }
    }
}
