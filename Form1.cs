using System;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace Lab27
{
    public partial class Form1 : Form
    {
        private string _currentPath = "";

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        // ════════════════════════════════════════════════════════════════════
        // STARTUP
        // ════════════════════════════════════════════════════════════════════
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrives();
            SetStatus("Оберіть диск, каталог або файл");
        }

        // ════════════════════════════════════════════════════════════════════
        // DRIVES
        // ════════════════════════════════════════════════════════════════════
        private void LoadDrives()
        {
            lvDrives.Items.Clear();
            foreach (var d in DriveInfo.GetDrives())
            {
                string label  = d.IsReady ? (d.VolumeLabel.Length > 0 ? d.VolumeLabel : "—") : "—";
                string size   = d.IsReady ? FormatBytes(d.TotalSize) : "—";
                string free   = d.IsReady ? FormatBytes(d.TotalFreeSpace) : "—";
                string fsType = d.IsReady ? d.DriveFormat : "—";

                var item = new ListViewItem(d.Name)
                {
                    ImageIndex = 0,
                    Tag = d.Name
                };
                item.SubItems.Add(d.DriveType.ToString());
                item.SubItems.Add(label);
                item.SubItems.Add(fsType);
                item.SubItems.Add(size);
                item.SubItems.Add(free);
                lvDrives.Items.Add(item);
            }
        }

        private void lvDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDrives.SelectedItems.Count == 0) return;
            string driveName = lvDrives.SelectedItems[0].Tag?.ToString() ?? "";
            ShowDriveInfo(driveName);
            NavigateTo(driveName);
        }

        private void ShowDriveInfo(string path)
        {
            try
            {
                var d = new DriveInfo(path);
                var sb = new StringBuilder();
                sb.AppendLine($"Диск:          {d.Name}");
                sb.AppendLine($"Тип:           {d.DriveType}");
                if (d.IsReady)
                {
                    sb.AppendLine($"Мітка:         {(d.VolumeLabel.Length > 0 ? d.VolumeLabel : "—")}");
                    sb.AppendLine($"Файлова сист.: {d.DriveFormat}");
                    sb.AppendLine($"Загальний розм:{FormatBytes(d.TotalSize)}");
                    sb.AppendLine($"Вільно:        {FormatBytes(d.TotalFreeSpace)}");
                    sb.AppendLine($"Зайнято:       {FormatBytes(d.TotalSize - d.TotalFreeSpace)}");
                    sb.AppendLine($"Корінь:        {d.RootDirectory}");
                }
                else sb.AppendLine("Диск не готовий");
                ShowProperties(sb.ToString());
            }
            catch (Exception ex) { ShowProperties("Помилка: " + ex.Message); }
        }

        // ════════════════════════════════════════════════════════════════════
        // NAVIGATION
        // ════════════════════════════════════════════════════════════════════
        private void NavigateTo(string path)
        {
            if (!Directory.Exists(path)) return;
            _currentPath = path;
            txtPath.Text = path;
            LoadDirectory(path);
        }

        private void LoadDirectory(string path)
        {
            lvFiles.Items.Clear();

            string filterFile = txtFilterFile.Text.Trim();
            string filterDir  = txtFilterDir.Text.Trim();
            if (string.IsNullOrEmpty(filterFile)) filterFile = "*";
            if (string.IsNullOrEmpty(filterDir))  filterDir  = "*";

            try
            {
                // Up button
                var parent = Directory.GetParent(path);
                if (parent != null)
                {
                    var up = new ListViewItem("..")
                    { ImageIndex = 1, Tag = ("dir", parent.FullName) };
                    up.SubItems.Add("Батьківська папка");
                    up.SubItems.Add(""); up.SubItems.Add(""); up.SubItems.Add("");
                    lvFiles.Items.Add(up);
                }

                // Directories
                foreach (var dir in Directory.GetDirectories(path, filterDir))
                {
                    try
                    {
                        var di   = new DirectoryInfo(dir);
                        var item = new ListViewItem(di.Name)
                        { ImageIndex = 1, Tag = ("dir", di.FullName) };
                        item.SubItems.Add("Папка");
                        item.SubItems.Add(di.CreationTime.ToString("dd.MM.yyyy HH:mm"));
                        item.SubItems.Add(di.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                        item.SubItems.Add("");
                        lvFiles.Items.Add(item);
                    }
                    catch { }
                }

                // Files
                foreach (var file in Directory.GetFiles(path, filterFile))
                {
                    try
                    {
                        var fi   = new FileInfo(file);
                        var item = new ListViewItem(fi.Name)
                        { ImageIndex = GetFileIcon(fi.Extension), Tag = ("file", fi.FullName) };
                        item.SubItems.Add(fi.Extension.ToUpper().TrimStart('.'));
                        item.SubItems.Add(fi.CreationTime.ToString("dd.MM.yyyy HH:mm"));
                        item.SubItems.Add(fi.LastWriteTime.ToString("dd.MM.yyyy HH:mm"));
                        item.SubItems.Add(FormatBytes(fi.Length));
                        lvFiles.Items.Add(item);
                    }
                    catch { }
                }

                SetStatus($"{path}  —  {lvFiles.Items.Count - (Directory.GetParent(path) != null ? 1 : 0)} об'єктів");
            }
            catch (Exception ex) { SetStatus("Помилка: " + ex.Message); }
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0) return;
            var tag = lvFiles.SelectedItems[0].Tag;
            if (tag is not ValueTuple<string, string> t) return;
            var (type, fullPath) = t;
            if (type == "dir") NavigateTo(fullPath);
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 0) { ClearPreview(); return; }
            var tag = lvFiles.SelectedItems[0].Tag;
            if (tag is not ValueTuple<string, string> t) return;
            var (type, fullPath) = t;

            if (type == "dir") ShowDirProperties(fullPath);
            else               ShowFileProperties(fullPath);
        }

        // ════════════════════════════════════════════════════════════════════
        // PROPERTIES
        // ════════════════════════════════════════════════════════════════════
        private void ShowDirProperties(string path)
        {
            try
            {
                var di = new DirectoryInfo(path);
                var sb = new StringBuilder();
                sb.AppendLine($"Назва:        {di.Name}");
                sb.AppendLine($"Повний шлях:  {di.FullName}");
                sb.AppendLine($"Батьківська:  {di.Parent?.FullName ?? "—"}");
                sb.AppendLine($"Корінь:       {di.Root}");
                sb.AppendLine($"Створено:     {di.CreationTime:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine($"Змінено:      {di.LastWriteTime:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine($"Відкрито:     {di.LastAccessTime:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine($"Атрибути:     {di.Attributes}");
                sb.AppendLine($"Існує:        {di.Exists}");

                // Security
                sb.AppendLine();
                sb.AppendLine("── Безпека ──────────────────");
                AppendSecurity(sb, path, isDir: true);

                ShowProperties(sb.ToString());
                ClearPreview();
            }
            catch (Exception ex) { ShowProperties("Помилка: " + ex.Message); }
        }

        private void ShowFileProperties(string path)
        {
            try
            {
                var fi = new FileInfo(path);
                var sb = new StringBuilder();
                sb.AppendLine($"Ім'я:         {fi.Name}");
                sb.AppendLine($"Розширення:   {fi.Extension}");
                sb.AppendLine($"Повний шлях:  {fi.FullName}");
                sb.AppendLine($"Папка:        {fi.DirectoryName}");
                sb.AppendLine($"Розмір:       {FormatBytes(fi.Length)}  ({fi.Length:N0} байт)");
                sb.AppendLine($"Створено:     {fi.CreationTime:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine($"Змінено:      {fi.LastWriteTime:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine($"Відкрито:     {fi.LastAccessTime:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine($"Атрибути:     {fi.Attributes}");
                sb.AppendLine($"Лише читання: {fi.IsReadOnly}");

                sb.AppendLine();
                sb.AppendLine("── Безпека ──────────────────");
                AppendSecurity(sb, path, isDir: false);

                ShowProperties(sb.ToString());
                PreviewFile(path, fi.Extension.ToLower());
            }
            catch (Exception ex) { ShowProperties("Помилка: " + ex.Message); }
        }

        private static void AppendSecurity(StringBuilder sb, string path, bool isDir)
        {
            try
            {
                if (isDir)
                {
                    var sec  = new DirectoryInfo(path).GetAccessControl();
                    var rules = sec.GetAccessRules(true, true,
                        typeof(System.Security.Principal.NTAccount));
                    foreach (FileSystemAccessRule r in rules)
                        sb.AppendLine($"  {r.IdentityReference,-30} {r.FileSystemRights,-20} {r.AccessControlType}");
                }
                else
                {
                    var sec   = new FileInfo(path).GetAccessControl();
                    var rules = sec.GetAccessRules(true, true,
                        typeof(System.Security.Principal.NTAccount));
                    foreach (FileSystemAccessRule r in rules)
                        sb.AppendLine($"  {r.IdentityReference,-30} {r.FileSystemRights,-20} {r.AccessControlType}");
                }
            }
            catch { sb.AppendLine("  (недостатньо прав для перегляду)"); }
        }

        // ════════════════════════════════════════════════════════════════════
        // PREVIEW (image / text)
        // ════════════════════════════════════════════════════════════════════
        private void PreviewFile(string path, string ext)
        {
            string[] imgExts = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".ico", ".tiff", ".webp" };
            string[] txtExts = { ".txt", ".log", ".csv", ".xml", ".json", ".cs", ".html",
                                 ".htm", ".css", ".js", ".py", ".md", ".ini", ".cfg" };

            if (Array.IndexOf(imgExts, ext) >= 0)
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(path);
                    using var ms = new MemoryStream(bytes);
                    picPreview.Image = Image.FromStream(ms);
                    picPreview.Visible = true;
                    rtbPreview.Visible = false;
                }
                catch { ClearPreview(); }
            }
            else if (Array.IndexOf(txtExts, ext) >= 0)
            {
                try
                {
                    long size = new FileInfo(path).Length;
                    if (size > 2 * 1024 * 1024)
                    {
                        rtbPreview.Text = "(файл завеликий для перегляду — понад 2 МБ)";
                    }
                    else
                    {
                        rtbPreview.Text = File.ReadAllText(path, Encoding.UTF8);
                    }
                    rtbPreview.Visible = true;
                    picPreview.Visible = false;
                }
                catch { ClearPreview(); }
            }
            else ClearPreview();
        }

        private void ClearPreview()
        {
            picPreview.Image   = null;
            picPreview.Visible = false;
            rtbPreview.Visible = false;
        }

        // ════════════════════════════════════════════════════════════════════
        // FILTER
        // ════════════════════════════════════════════════════════════════════
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentPath))
                LoadDirectory(_currentPath);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilterFile.Text = "";
            txtFilterDir.Text  = "";
            if (!string.IsNullOrEmpty(_currentPath))
                LoadDirectory(_currentPath);
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) NavigateTo(txtPath.Text.Trim());
        }

        private void btnGo_Click(object sender, EventArgs e)
            => NavigateTo(txtPath.Text.Trim());

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════
        private void ShowProperties(string text)
            => rtbProps.Text = text;

        private void SetStatus(string msg)
            => lblStatus.Text = msg;

        private static string FormatBytes(long bytes)
        {
            if (bytes < 1024)           return $"{bytes} Б";
            if (bytes < 1024 * 1024)    return $"{bytes / 1024.0:F1} КБ";
            if (bytes < 1024L * 1024 * 1024) return $"{bytes / 1024.0 / 1024:F1} МБ";
            return $"{bytes / 1024.0 / 1024 / 1024:F2} ГБ";
        }

        private static int GetFileIcon(string ext) => ext.ToLower() switch
        {
            ".jpg" or ".jpeg" or ".png" or ".bmp" or ".gif" or ".ico" => 3,
            ".txt" or ".log" or ".md"  => 4,
            ".exe" or ".msi"           => 5,
            ".zip" or ".rar" or ".7z"  => 6,
            _ => 2
        };
    }
}
