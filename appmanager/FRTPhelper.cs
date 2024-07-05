using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace Mantis_tests
{
    public class FRTPhelper : HelperBase

    {
        public FtpClient client;
        public FRTPhelper(ApplicationManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis","mantis");
            client.Connect();
        }

        public void BackUpFile(String path)
        {

            String backUpPath = path + ".bak";
            if(client.FileExists(backUpPath))
            {
                return;
            }
            client.Rename(path, backUpPath);
        }

        public void RestoreBackUpFile(String path)
        {
            String backUpPath = path + ".bak";
            if (!client.FileExists(backUpPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
               client.DeleteFile(path);
            }
            client.Rename(backUpPath,path);

        }

        public void Upload(String path,Stream localFile)

        {
           if (client.FileExists(path))
          {
               client.DeleteFile(path);
            }
            using (Stream ftpStream = client.OpenWrite(path))
            {
                byte [] buffer = new byte[8 * 1024];
                 int count = localFile.Read(buffer, 0, buffer.Length);
                while(count > 0) 
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
            

        }



    }
}
