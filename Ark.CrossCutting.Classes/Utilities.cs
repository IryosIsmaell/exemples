using System.Text.RegularExpressions;

namespace Ark.CrossCutting.Classes
{
    public static class Utilities
    {
        public static string GeneratePassword(int digitos)
        {
            int Tamanho = digitos; // Numero de digitos da senha
            string senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return senha;
        }

        public static string RemoveCaracteresEspeciais(string input)
        {
            string result = "";
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                result = rgx.Replace(input, replacement);
            }
            return result;
        }

        public static string localApp()
        {
            var exeDir = AppDomain.CurrentDomain.BaseDirectory;
            var exeDirInfo = new DirectoryInfo(exeDir);

            return exeDirInfo.FullName;
        }

        public static void GravarServiceLog(string Message)
        {
            var dataHora = DateTime.Now;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + dataHora.Date.ToShortDateString().Replace('/', '_') + ".log";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(dataHora.ToLongTimeString() + ": " + Message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(dataHora.ToLongTimeString() + ": " + Message);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            finally
            {
                Console.WriteLine(dataHora + ": " + Message);
            }
        }
    }
}
