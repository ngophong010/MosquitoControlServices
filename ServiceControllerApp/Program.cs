using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Runtime.InteropServices;

namespace ServiceControllerApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // dotnet add package MQTTnet
            /*// dotnet add package System.ServiceProcess.ServiceController
            string serviceName = "Mosquitto Broker";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                StartServiceWindows(serviceName);
                StopServiceWindows(serviceName);
            }

            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                StartServiceLinux(serviceName);
                StopServiceLinux(serviceName);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //System.Diagnostics.Process.Start(serviceName);
                StartServiceMac(serviceName);
                StopServiceMac(serviceName);
            }*/

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        /*// Windows service start and stop
        public static void StartServiceWindows(string serviceName)
        {
            // (Include the Windows code from the previous response)
            double timeoutMilliseconds = 10_000;
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

            ServiceController service = new ServiceController(serviceName);
            try
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show($"The service failed to start in a timely manner\n\n{exc}");
            }
        }

        public static void StopServiceWindows(string serviceName)
        {
            // (Include the Windows code from the previous response)
        }

        // Linux service start and stop using `systemctl`
        public static void StartServiceLinux(string serviceName)
        {
            ExecuteShellCommand($"sudo systemctl start mosquito");
        }

        public static void StopServiceLinux(string serviceName)
        {
            ExecuteShellCommand($"sudo systemctl stop mosquitto");
        }

        // macOS service start and stop using `launchctl`
        public static void StartServiceMac(string serviceName)
        {
            ExecuteShellCommand($"sudo launchctl load -w /Library/LaunchDaemons/{serviceName}.plist");
        }

        public static void StopServiceMac(string serviceName)
        {
            ExecuteShellCommand($"sudo launchctl unload -w /Library/LaunchDaemons/{serviceName}.plist");
        }

        public static void ExecuteShellCommand(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{command}\"",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine($"Command executed successfully: {output}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }*/
    }
}