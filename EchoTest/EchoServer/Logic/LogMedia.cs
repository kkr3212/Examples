using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aegis;



namespace EchoServer.Logic
{
    public static class LogMedia
    {
        private static TextBox _textBox;
        private static StreamWriter _textFile;





        public static void AddTextBoxLogger(TextBox tb)
        {
            if (tb == null)
                return;

            _textBox = tb;
            Logger.Written += TextBoxLog;
        }


        public static void AddTextFileLogger(string path, string filePrefix)
        {
            if (path == null)
                return;

            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            string filename = string.Format(".\\log\\{0}_{1}_{2:D2}{3:D2}_{4:D2}{5:D2}.log",
                                            filePrefix,
                                            DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                            DateTime.Now.Hour, DateTime.Now.Minute);
            _textFile = new StreamWriter(filename);
            Logger.Written += TextFileLog;
        }


        public static void AddOutputLog()
        {
            Logger.Written += OutputLog;
        }


        public static void DeleteAllLogger()
        {
            Logger.Written -= TextBoxLog;
            Logger.Written -= TextFileLog;
            Logger.Written -= OutputLog;

            if (_textFile != null)
            {
                _textFile.Close();
                _textFile = null;
            }
        }


        private static void TextBoxLog(int mask, string log)
        {
            Action action = () =>
            {
                string message = string.Format("{0}\r\n", log);

                _textBox.Text += message;
                _textBox.SelectionStart = _textBox.TextLength;
                _textBox.ScrollToCaret();
            };


            if (_textBox.InvokeRequired)
                _textBox.BeginInvoke(action);
            else
                action();
        }


        private static void TextFileLog(int mask, string log)
        {
            string text = string.Format("[{0}/{1} {2}:{3}:{4}] {5}",
                                        DateTime.Now.Month, DateTime.Now.Day,
                                        DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second,
                                        log);

            _textFile.WriteLine(text);
            _textFile.Flush();
        }


        private static void OutputLog(int mask, string log)
        {
            string text = string.Format("[{0}/{1} {2}:{3}:{4}] {5}",
                                        DateTime.Now.Month, DateTime.Now.Day,
                                        DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second,
                                        log);

            System.Diagnostics.Debug.WriteLine(text);
        }
    }
}
