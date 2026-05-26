using System;
using System.Windows.Forms;

namespace PhysicsSolver;

static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Принудительно задаем режим масштабирования по умолчанию для системы
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2); 
        
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}