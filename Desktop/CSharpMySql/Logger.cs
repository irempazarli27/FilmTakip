using System;
using System.IO;

class Logger
{
    public static void LogYaz(string mesaj)
    {
        string logMesaji =
            $"[ERROR] {DateTime.Now} - {mesaj}{Environment.NewLine}";

        File.AppendAllText("log.txt", logMesaji);
    }
}
