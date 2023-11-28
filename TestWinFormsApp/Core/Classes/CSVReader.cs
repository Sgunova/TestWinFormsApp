using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWinFormsApp.Core.Interfaces;
using TestWinFormsApp.Properties;

namespace TestWinFormsApp.Core.Classes
{
    public class CSVReader: IReader<Passenger>
    {
        string FilePath = string.Empty;

        public void ChengePath(string filePath)
        {
            FilePath = filePath;
        }

        public List<Passenger> ReadData()
        {
            List<Passenger> resultList = new();
            List<string> errorLines = new();

            if(FilePath is null)
                return resultList;

            if (!File.Exists(FilePath))
            {
                MessageBox.Show(Resources.FileNotFound_Message, Resources.FileNotFound_Caption);
                return resultList;
            }

            var fileData = File.ReadAllLines(FilePath);

            foreach (var line in fileData)
            {
                try
                {
                    var dataObj = line.Split(";");

                    if (!Passenger.Validate(dataObj))
                        throw new ArgumentException("Не пройдена валидация.");

                    var item = new Passenger(dataObj);

                    if(item is not null)
                        resultList.Add(item);
                }
                catch
                {
                    errorLines.Add(line);
                }
            }

            if (errorLines.Count > 0)
            {

                var errorDialog = MessageBox.Show(
                                            string.Format(Resources.FileProcessingError_Message, errorLines.Count),
                                            Resources.FileProcessingError_Caption, 
                                            MessageBoxButtons.OKCancel);

                if(errorDialog == DialogResult.OK)
                {
                    var errorFileName = SaveErrorLinesToFile(errorLines, FilePath);
                    MessageBox.Show(string.Format(Resources.ErrorFileSave_Message,errorFileName),
                                    Resources.ErrorFileSave_Caption,
                                    MessageBoxButtons.OK);
                }
            }

            return resultList;
        }

        private string SaveErrorLinesToFile(List<string> errorLines, string filePath) {

            var fileName = $"ErrorList {DateTime.Now.ToString().Replace(":", ".")}.csv";
            var path = Path.GetDirectoryName(filePath) + $"\\{fileName}";

            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(string.Join("\n", errorLines));
                fs.Write(info, 0, info.Length);
            }

            return fileName;
        }
    }
}
