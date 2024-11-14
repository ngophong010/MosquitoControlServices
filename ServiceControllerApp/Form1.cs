using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Windows.Forms;

namespace ServiceControllerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Service Controller Application Started");
        }

        // When the application starts (Form Load), start the service
        private void Form1_Load_1(object sender, EventArgs e)
        {
            string serviceName = "mosquitto"; // Replace with your service name
            MessageBox.Show("Form Load: Starting service...");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                MessageBox.Show("Detected OS: Windows");
                StartServiceWindows(serviceName);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                MessageBox.Show("Detected OS: Linux");
                StartServiceLinux(serviceName);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                MessageBox.Show("Detected OS: macOS");
                StartServiceMac(serviceName);
            }
        }

        // When the application is closing (Form Closing), stop the service

        private void Form1_FormClosing_1(object sender, FormClosedEventArgs e)
        {
            string serviceName = "mosquitto"; // Replace with your service name
            MessageBox.Show("Form Closing: Stopping service...");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                MessageBox.Show("Detected OS: Windows");
                StopServiceWindows(serviceName);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                MessageBox.Show("Detected OS: Linux");
                StopServiceLinux(serviceName);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                MessageBox.Show("Detected OS: macOS");
                StopServiceMac(serviceName);
            }
        }


        // Windows service start and stop
        public void StartServiceWindows(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    MessageBox.Show($"Attempting to start Windows service '{serviceName}'...");

                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                        MessageBox.Show($"Service '{serviceName}' started successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Service '{serviceName}' is already running.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting service: {ex.Message}");
                MessageBox.Show($"Error starting service: {ex}");
            }
        }

        public void StopServiceWindows(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    MessageBox.Show($"Attempting to stop Windows service '{serviceName}'...");

                    if (service.Status != ServiceControllerStatus.Stopped)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                        MessageBox.Show($"Service '{serviceName}' stopped successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Service '{serviceName}' is already stopped.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping service: {ex.Message}");
                MessageBox.Show($"Error stopping service: {ex}");
            }
        }

        // Linux service start and stop using `systemctl`
        public void StartServiceLinux(string serviceName)
        {
            MessageBox.Show($"Attempting to start Linux service '{serviceName}'...");
            ExecuteShellCommand($"sudo systemctl start {serviceName}");
        }

        public void StopServiceLinux(string serviceName)
        {
            MessageBox.Show($"Attempting to stop Linux service '{serviceName}'...");
            ExecuteShellCommand($"sudo systemctl stop {serviceName}");
        }

        // macOS service start and stop using `launchctl`
        public void StartServiceMac(string serviceName)
        {
            MessageBox.Show($"Attempting to start macOS service '{serviceName}'...");
            ExecuteShellCommand($"sudo launchctl load -w /Library/LaunchDaemons/{serviceName}.plist");
        }

        public void StopServiceMac(string serviceName)
        {
            MessageBox.Show($"Attempting to stop macOS service '{serviceName}'...");
            ExecuteShellCommand($"sudo launchctl unload -w /Library/LaunchDaemons/{serviceName}.plist");
        }

        // Helper method to execute shell commands
        public void ExecuteShellCommand(string command)
        {
            try
            {
                MessageBox.Show($"Executing command: {command}");
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
                        MessageBox.Show($"Command executed successfully: {output}");
                    }
                    else
                    {
                        MessageBox.Show($"Command error: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while executing command: {ex}");
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate that username and password are not empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Path to the Mosquitto password executable file
            string mosquittoPasswdPath = @"C:\Program Files\mosquitto\mosquitto_passwd.exe"; // Update path if needed

            // Path to the Mosquitto password file
            string passwordFilePath = @"C:\Program Files\mosquitto\passwd";

            // Create a new user using mosquitto_passwd
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"\"{mosquittoPasswdPath}\" -b \"{passwordFilePath}\" \"{username}\" \"{password}\"",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // Capture any errors
                    string error = process.StandardError.ReadToEnd();
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error: {error}", "User creation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // string broker = "******.emqxsl.com"; //This is for EMQX Serverless
            // int port = 1883; //This is for EMQX Serverless
            // string clientId = Guid.NewGuid().ToString(); //This is for EMQX Serverless
            // string topic = "test/mqtt"; //This is for EMQX Serverless
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate user input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Vui lòng nhập username và password.";
                return;
            }

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883) // Replace with your broker's address
                .WithCredentials(username, password)
                .WithCleanSession()
                .Build();

            // Create the MQTT Client
            var mqttClient = new MqttFactory().CreateMqttClient();

            // Event handler for when the client connects
            mqttClient.ConnectedAsync += async e =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Connected successfully.";
                }));
                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("test/topic").Build());
                this.Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Subscribed to topic 'test/topic'.";
                }));
            };

            // Event handler for when the client disconnects
            mqttClient.DisconnectedAsync += e =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Disconnected from MQTT broker.";
                }));
                return Task.CompletedTask;
            };

            // Event handler for when a message is received
            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                string message = Encoding.UTF8.GetString(
                    e.ApplicationMessage.PayloadSegment);
                this.Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = $"Received message: {message}";
                }));

                return Task.CompletedTask;
            };
            try
            {
                this.Invoke((MethodInvoker)((() =>
                {
                    lblStatus.Text = "Connecting...";

                }
                )));
                await mqttClient.ConnectAsync(options);
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)((() =>
                {
                    lblStatus.Text = $"Error: {ex.Message}";
                }
                )));
            }
        }

        
    }
}
