using System.Diagnostics;
using System.Drawing.Text;
using System.IO.Compression;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LuckyUpdater
{
    public partial class Main : Form
    {
        private bool mouseDown = false;
        private Point lastLocation;

        private string LaunchEXE = "";
        private string SupportLink = "";
        private string RemoveFiles = "";
        private string SelfDestruct = "";
        private string FileName = "";

        private DateTime startTime;
        private DateTime lastProgressUpdateTime;
        private long lastProgressUpdateBytes;

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.Image = Properties.Resources.Close_Icon_Hover;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.Image = Properties.Resources.Close_Icon;
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void TitlePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TitleIcon_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TitleIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void TitleIcon_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateChangelog.SelectionBullet = true;
            ReadUpdateFile();
        }

        private void ReadUpdateFile()
        {
            string ErrorMessage = "";
            if (File.Exists("UpdateData.ini"))
            {
                string[] lines = File.ReadAllLines("UpdateData.ini");
                foreach (string rawLine in lines)
                {
                    if (string.IsNullOrWhiteSpace(rawLine)) { continue; }
                    string line = rawLine.Trim();
                    int idx = line.IndexOf('=');
                    if (idx <= 0) // no '=' found or key is empty
                    {
                        ErrorMessage = "Misconfigured UpdateData.ini file.";
                        break;
                    }

                    string key = line.Substring(0, idx).Trim();
                    string value = line.Substring(idx + 1).Trim();

                    switch (key)
                    {
                        case "Version":
                            UpdateVersion.Text = value;
                            break;
                        case "Changelog":
                            // Allow literal "\n" sequences in the INI to denote new lines.
                            UpdateChangelog.Text = value.Replace("\\n", Environment.NewLine);
                            break;
                        case "DownloadLink":
                            UpdateButton.Tag = value;
                            break;
                        case "ProductName":
                            TitleLabel.Text = $"Lucky Updater - {value}";
                            break;
                        case "LogoURL":
                            UpdateLogo.ImageLocation = value;
                            break;
                        case "ExeLaunch":
                            LaunchEXE = value;
                            break;
                        case "PromoLink":
                            PromoLink.Text = value;
                            break;
                        case "SupportLink":
                            SupportLink = value;
                            SupportLinkLL.Text = value;
                            SupportLinkLL.Visible = true;
                            break;
                        case "RemoveFiles":
                            // Files to remove should be separated by colons (:)
                            RemoveFiles = value;
                            break;
                        case "SelfDestruct":
                            SelfDestruct = value;
                            break;
                        case "FileName":
                            FileName = value;
                            break;
                        default:
                            break;
                    }
                }

                //Check if mandatory data is present
                if (UpdateButton.Tag == null || FileName == "")
                {
                    ErrorMessage = "Misconfigured UpdateData.ini file.";
                }

                if (string.IsNullOrEmpty(ErrorMessage))
                {
                    UpdatePanel.Visible = true;
                }
                else
                {
                    ErrorLabel.Text = ErrorMessage;
                }
            }
        }

        private void PromoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", PromoLink.Text);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (UpdateButton.Text == "Update")
            {
                UpdateButton.Enabled = false;
                DownloadFileAsync(UpdateButton.Tag.ToString());
            }
            else
            {
                if (LaunchEXE != "")
                {
                    try
                    {
                        using (Process p = new Process())
                        {
                            p.StartInfo = new ProcessStartInfo(LaunchEXE) { UseShellExecute = true };
                            p.StartInfo.WorkingDirectory = Application.StartupPath;
                            p.Start();
                        }
                        Application.Exit();
                    }
                    catch
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private async Task DownloadFileAsync(string link)
        {
            try
            {
                Uri fileLink = new Uri(link);

                UpdateStatus.Text = "Downloading... 0%";
                UpdateProgressBar.Value = 0;
                startTime = DateTime.Now;

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("LuckyUpdater");

                    using (var response = await httpClient.GetAsync(fileLink, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        var canReportProgress = totalBytes != -1;

                        using (var contentStream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                        {
                            var buffer = new byte[8192];
                            long totalRead = 0;
                            int read;
                            lastProgressUpdateTime = DateTime.Now;
                            lastProgressUpdateBytes = 0;

                            while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read);
                                totalRead += read;

                                if (canReportProgress)
                                {
                                    double percentage = totalRead / (double)totalBytes * 100;
                                    UpdateProgressBar.Value = (int)Math.Truncate(percentage);

                                    DateTime now = DateTime.Now;
                                    TimeSpan timeElapsed = now - lastProgressUpdateTime;

                                    if (timeElapsed.TotalMilliseconds > 250)
                                    {
                                        long bytesSinceLastUpdate = totalRead - lastProgressUpdateBytes;
                                        double speedInBytesPerSecond = bytesSinceLastUpdate / timeElapsed.TotalSeconds;
                                        if (speedInBytesPerSecond < 0)
                                        {
                                            speedInBytesPerSecond = 0;
                                        }

                                        string DLSpeed = FormatBytes(speedInBytesPerSecond) + "/s";
                                        string DLCurrent = $"{FormatBytes(totalRead)} / {FormatBytes(totalBytes)}";
                                        string DLTimeLeft = string.Empty;

                                        if (totalRead > 0 && totalRead < totalBytes)
                                        {
                                            double downloadRate = totalRead / (DateTime.Now - startTime).TotalSeconds;
                                            double remainingBytes = totalBytes - totalRead;
                                            double timeLeftInSeconds = remainingBytes / downloadRate;

                                            if (timeLeftInSeconds > 0)
                                            {
                                                TimeSpan timeLeft = TimeSpan.FromSeconds(timeLeftInSeconds);
                                                DLTimeLeft = $"{timeLeft.Hours:D2}:{timeLeft.Minutes:D2}:{timeLeft.Seconds:D2}";
                                            }
                                        }

                                        UpdateStats.Text = $"Speed: {DLSpeed} | {DLCurrent} | Time Left: {DLTimeLeft}";

                                        lastProgressUpdateTime = now;
                                        lastProgressUpdateBytes = totalRead;
                                    }

                                    UpdateStatus.Text = $"Downloading... {(int)Math.Truncate(percentage)}%";
                                }
                                Application.DoEvents();
                            }
                        }
                        UpdateProgressBar.Value = 100;
                        UpdateStatus.Text = "Extracting Update...";
                        UpdateStats.Text = "Speed: 0 B/s | 0 B / 0 B | Time Left: 00:00:00";
                        Application.DoEvents();

                        while (IsFileLocked(new FileInfo(FileName)))
                        {
                            await Task.Delay(100);
                        }
                        await ZipFile.ExtractToDirectoryAsync(FileName, Application.StartupPath, true);
                        UpdateStatus.Text = "Cleaning Up...";

                        // Clean up
                        if (File.Exists(FileName))
                        {
                            File.Delete(FileName);
                        }
                        if (SelfDestruct.ToLower() == "true")
                        {
                            if (File.Exists("UpdateData.ini"))
                            {
                                File.Delete("UpdateData.ini");
                            }
                        }

                        // Remove specified files
                        if (!string.IsNullOrEmpty(RemoveFiles))
                        {
                            string[] filesToRemove = RemoveFiles.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string filePath in filesToRemove)
                            {
                                string trimmedPath = filePath.Trim();
                                if (File.Exists(trimmedPath))
                                {
                                    try
                                    {
                                        File.Delete(trimmedPath);
                                    }
                                    catch {}
                                }
                                else if (Directory.Exists(trimmedPath))
                                {
                                    try
                                    {
                                        Directory.Delete(trimmedPath, true);
                                    }
                                    catch {}
                                }
                            }
                        }
                        UpdateStatus.Text = "Update Complete!";
                        UpdateButton.Enabled = true;
                        UpdateButton.Text = "Finish";
                    }
                }
            }
            catch (Exception ex)
            {
                UpdatePanel.Hide();
                ErrorLabel.Text = "An error occurred.";
                File.WriteAllText("ErrorLog.txt", ex.ToString());
            }
        }

        string FormatBytes(double bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            while (bytes >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                bytes /= 1024;
                suffixIndex++;
            }

            return string.Format("{0:0.##} {1}", bytes, suffixes[suffixIndex]);
        }

        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void SupportLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", SupportLinkLL.Text);
        }
    }
}
