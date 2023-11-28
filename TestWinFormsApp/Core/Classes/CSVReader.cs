using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWinFormsApp.Core.Interfaces;

namespace TestWinFormsApp.Core.Classes
{
    public class CSVReader<T> : IReader<T> where T : class
    {
        string FilePath = string.Empty;

        public void ChengePath(string filePath)
        {
            FilePath = filePath;
        }

        public List<T> ReadData()
        {
            List<T> resultList = new();
            List<string> errorLines = new();

            if(FilePath is null)
                return resultList;

            if (!File.Exists(FilePath))
            {
                MessageBox.Show("Файл не найден.", "Ошибка обработки файла");
                return resultList;
            }

            var fileData = File.ReadAllLines(FilePath);

            foreach (var line in fileData)
            {
                try
                {
                    var item = (T)Activator.CreateInstance(typeof(T), line.Split(";"));

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
                                            $"Во время обработки данных {errorLines.Count} имели неверный формат данных. Сохранить его?",
                                            "Ошибка обработки файла", 
                                            MessageBoxButtons.OKCancel);

                if(errorDialog == DialogResult.OK)
                {
                    var errorFileName = SaveErrorLinesToFile(errorLines, FilePath);
                    MessageBox.Show($"Файл сохранен в той же директории в файле \"{errorFileName}\"",
                                            "Сохранение ошибок",
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
