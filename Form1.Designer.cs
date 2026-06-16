namespace Lab27
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── top-level controls ────────────────────────────────────────
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblHeader    = new System.Windows.Forms.Label();
            this.pnlStatus    = new System.Windows.Forms.Panel();
            this.lblStatus    = new System.Windows.Forms.Label();

            // ── tab control ────────────────────────────────────────────────
            this.tabMain      = new System.Windows.Forms.TabControl();
            this.tabBrowser   = new System.Windows.Forms.TabPage();
            this.tabDrives    = new System.Windows.Forms.TabPage();

            // ── browser tab ────────────────────────────────────────────────
            this.splitBrowser = new System.Windows.Forms.SplitContainer();
            this.splitRight   = new System.Windows.Forms.SplitContainer();

            // Address bar
            this.pnlAddress   = new System.Windows.Forms.Panel();
            this.lblPath      = new System.Windows.Forms.Label();
            this.txtPath      = new System.Windows.Forms.TextBox();
            this.btnGo        = new System.Windows.Forms.Button();

            // Filter panel
            this.pnlFilter    = new System.Windows.Forms.Panel();
            this.lblFilterFile= new System.Windows.Forms.Label();
            this.txtFilterFile= new System.Windows.Forms.TextBox();
            this.lblFilterDir = new System.Windows.Forms.Label();
            this.txtFilterDir = new System.Windows.Forms.TextBox();
            this.btnApplyFilter= new System.Windows.Forms.Button();
            this.btnClearFilter= new System.Windows.Forms.Button();

            // File list
            this.lvFiles      = new System.Windows.Forms.ListView();
            this.colName      = new System.Windows.Forms.ColumnHeader();
            this.colType      = new System.Windows.Forms.ColumnHeader();
            this.colCreated   = new System.Windows.Forms.ColumnHeader();
            this.colModified  = new System.Windows.Forms.ColumnHeader();
            this.colSize      = new System.Windows.Forms.ColumnHeader();

            // Properties
            this.grpProps     = new System.Windows.Forms.GroupBox();
            this.rtbProps     = new System.Windows.Forms.RichTextBox();

            // Preview
            this.grpPreview   = new System.Windows.Forms.GroupBox();
            this.picPreview   = new System.Windows.Forms.PictureBox();
            this.rtbPreview   = new System.Windows.Forms.RichTextBox();

            // ── drives tab ─────────────────────────────────────────────────
            this.lvDrives     = new System.Windows.Forms.ListView();
            this.colDrive     = new System.Windows.Forms.ColumnHeader();
            this.colDType     = new System.Windows.Forms.ColumnHeader();
            this.colLabel     = new System.Windows.Forms.ColumnHeader();
            this.colFS        = new System.Windows.Forms.ColumnHeader();
            this.colTotal     = new System.Windows.Forms.ColumnHeader();
            this.colFree      = new System.Windows.Forms.ColumnHeader();

            // Image list for icons
            this.imgList      = new System.Windows.Forms.ImageList(this.components);

            // ══════════════════════════════════════════════════════════════
            // pnlHeader
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 46;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 39, 46);
            this.pnlHeader.Padding   = new System.Windows.Forms.Padding(14, 0, 0, 0);

            this.lblHeader.Text      = "🗂  Файловий менеджер  —  Лабораторна робота №27";
            this.lblHeader.Font      = new System.Drawing.Font("Segoe UI", 11f);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlHeader.Controls.Add(this.lblHeader);

            // pnlStatus
            this.pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Height    = 24;
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(44, 55, 63);
            this.pnlStatus.Padding   = new System.Windows.Forms.Padding(8, 3, 0, 0);
            this.lblStatus.Text      = "";
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(180, 190, 200);
            this.lblStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Controls.Add(this.lblStatus);

            // tabMain
            this.tabMain.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font     = new System.Drawing.Font("Segoe UI", 9f);
            this.tabMain.Padding  = new System.Drawing.Point(12, 4);
            this.tabBrowser.Text  = "  📁 Провідник  ";
            this.tabDrives.Text   = "  💿 Диски  ";
            this.tabMain.TabPages.Add(this.tabBrowser);
            this.tabMain.TabPages.Add(this.tabDrives);

            // ══ IMAGE LIST ═══════════════════════════════════════════════
            this.imgList.ColorDepth  = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize   = new System.Drawing.Size(18, 18);
            // 0=drive 1=folder 2=file 3=image 4=text 5=exe 6=archive
            // We paint them at runtime in CreateIcons()
            CreateIcons();

            // ══ ADDRESS BAR ══════════════════════════════════════════════
            this.pnlAddress.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlAddress.Height  = 36;
            this.pnlAddress.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.pnlAddress.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.lblPath.Text     = "Шлях:";
            this.lblPath.Font     = new System.Drawing.Font("Segoe UI", 9f);
            this.lblPath.Location = new System.Drawing.Point(6, 8);
            this.lblPath.Size     = new System.Drawing.Size(42, 20);

            this.txtPath.Location = new System.Drawing.Point(52, 6);
            this.txtPath.Font     = new System.Drawing.Font("Consolas", 9.5f);
            this.txtPath.KeyDown += txtPath_KeyDown;

            this.btnGo.Text      = "→";
            this.btnGo.Size      = new System.Drawing.Size(30, 23);
            this.btnGo.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Click    += btnGo_Click;

            this.pnlAddress.Controls.AddRange(new System.Windows.Forms.Control[]
            { this.lblPath, this.txtPath, this.btnGo });

            this.pnlAddress.Resize += (_, _) =>
            {
                int bw = 34;
                this.txtPath.Width    = this.pnlAddress.Width - 52 - bw - 14;
                this.btnGo.Location   = new System.Drawing.Point(52 + this.txtPath.Width + 2, 6);
            };

            // ══ FILTER PANEL ═════════════════════════════════════════════
            this.pnlFilter.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height    = 36;
            this.pnlFilter.Padding   = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);

            this.lblFilterFile.Text     = "Файли:";
            this.lblFilterFile.Font     = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblFilterFile.Location = new System.Drawing.Point(6, 9);
            this.lblFilterFile.Size     = new System.Drawing.Size(46, 18);

            this.txtFilterFile.Location  = new System.Drawing.Point(55, 6);
            this.txtFilterFile.Size      = new System.Drawing.Size(100, 22);
            this.txtFilterFile.Font      = new System.Drawing.Font("Consolas", 9f);
            this.txtFilterFile.PlaceholderText = "*.txt";

            this.lblFilterDir.Text      = "Папки:";
            this.lblFilterDir.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblFilterDir.Location  = new System.Drawing.Point(162, 9);
            this.lblFilterDir.Size      = new System.Drawing.Size(42, 18);

            this.txtFilterDir.Location   = new System.Drawing.Point(208, 6);
            this.txtFilterDir.Size       = new System.Drawing.Size(100, 22);
            this.txtFilterDir.Font       = new System.Drawing.Font("Consolas", 9f);
            this.txtFilterDir.PlaceholderText = "doc*";

            FBtn(this.btnApplyFilter, "Застосувати", System.Drawing.Color.FromArgb(39,174,96),  316, 5, 100);
            FBtn(this.btnClearFilter, "Скинути",     System.Drawing.Color.FromArgb(127,140,141), 420, 5, 70);
            this.btnApplyFilter.Click += btnApplyFilter_Click;
            this.btnClearFilter.Click += btnClearFilter_Click;

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[]
            { this.lblFilterFile, this.txtFilterFile,
              this.lblFilterDir,  this.txtFilterDir,
              this.btnApplyFilter, this.btnClearFilter });

            // ══ FILE LIST (lvFiles) ════════════════════════════════════════
            this.lvFiles.View           = System.Windows.Forms.View.Details;
            this.lvFiles.FullRowSelect  = true;
            this.lvFiles.GridLines      = true;
            this.lvFiles.SmallImageList = this.imgList;
            this.lvFiles.Font           = new System.Drawing.Font("Segoe UI", 9f);
            this.lvFiles.BackColor      = System.Drawing.Color.White;
            this.lvFiles.BorderStyle    = System.Windows.Forms.BorderStyle.None;
            this.lvFiles.Dock           = System.Windows.Forms.DockStyle.Fill;

            this.colName.Text     = "Назва";     this.colName.Width    = 220;
            this.colType.Text     = "Тип";       this.colType.Width    = 70;
            this.colCreated.Text  = "Створено";  this.colCreated.Width = 130;
            this.colModified.Text = "Змінено";   this.colModified.Width= 130;
            this.colSize.Text     = "Розмір";    this.colSize.Width    = 80;

            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            { this.colName, this.colType, this.colCreated, this.colModified, this.colSize });

            this.lvFiles.DoubleClick           += lvFiles_DoubleClick;
            this.lvFiles.SelectedIndexChanged  += lvFiles_SelectedIndexChanged;

            // ══ LEFT PANEL (file list) ═════════════════════════════════════
            var pnlLeft = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill };
            pnlLeft.Controls.Add(this.lvFiles);
            pnlLeft.Controls.Add(this.pnlFilter);
            pnlLeft.Controls.Add(this.pnlAddress);

            // ══ RIGHT: splitRight (props | preview) ═══════════════════════
            this.splitRight.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitRight.Panel1MinSize = 50;
            this.splitRight.Panel2MinSize = 50;

            // Props
            this.grpProps.Text    = "Властивості";
            this.grpProps.Font    = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.grpProps.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.grpProps.Padding = new System.Windows.Forms.Padding(4);

            this.rtbProps.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.rtbProps.ReadOnly    = true;
            this.rtbProps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbProps.Font        = new System.Drawing.Font("Consolas", 8.5f);
            this.rtbProps.BackColor   = System.Drawing.Color.FromArgb(248, 249, 250);
            this.rtbProps.ForeColor   = System.Drawing.Color.FromArgb(30, 40, 50);
            this.grpProps.Controls.Add(this.rtbProps);
            this.splitRight.Panel1.Controls.Add(this.grpProps);

            // Preview
            this.grpPreview.Text    = "Перегляд";
            this.grpPreview.Font    = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.grpPreview.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.grpPreview.Padding = new System.Windows.Forms.Padding(4);

            this.picPreview.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.picPreview.Visible   = false;

            this.rtbPreview.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.rtbPreview.ReadOnly    = true;
            this.rtbPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPreview.Font        = new System.Drawing.Font("Consolas", 8.5f);
            this.rtbPreview.BackColor   = System.Drawing.Color.FromArgb(20, 24, 28);
            this.rtbPreview.ForeColor   = System.Drawing.Color.FromArgb(200, 210, 180);
            this.rtbPreview.Visible     = false;
            this.rtbPreview.WordWrap    = false;

            this.grpPreview.Controls.Add(this.picPreview);
            this.grpPreview.Controls.Add(this.rtbPreview);
            this.splitRight.Panel2.Controls.Add(this.grpPreview);

            // ══ SPLIT BROWSER ════════════════════════════════════════════
            this.splitBrowser.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.splitBrowser.Panel1MinSize = 50;
            this.splitBrowser.Panel2MinSize = 50;
            this.splitBrowser.Panel1.Controls.Add(pnlLeft);
            this.splitBrowser.Panel2.Controls.Add(this.splitRight);

            this.tabBrowser.Controls.Add(this.splitBrowser);
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(0);

            // ══ DRIVES TAB ═══════════════════════════════════════════════
            this.lvDrives.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.lvDrives.View          = System.Windows.Forms.View.Details;
            this.lvDrives.FullRowSelect = true;
            this.lvDrives.GridLines     = true;
            this.lvDrives.SmallImageList= this.imgList;
            this.lvDrives.Font          = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lvDrives.BackColor     = System.Drawing.Color.White;
            this.lvDrives.BorderStyle   = System.Windows.Forms.BorderStyle.None;

            this.colDrive.Text  = "Диск";       this.colDrive.Width  = 60;
            this.colDType.Text  = "Тип";        this.colDType.Width  = 120;
            this.colLabel.Text  = "Мітка";      this.colLabel.Width  = 120;
            this.colFS.Text     = "Файл.сист."; this.colFS.Width     = 90;
            this.colTotal.Text  = "Загальний";  this.colTotal.Width  = 110;
            this.colFree.Text   = "Вільно";     this.colFree.Width   = 110;

            this.lvDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            { this.colDrive, this.colDType, this.colLabel, this.colFS, this.colTotal, this.colFree });
            this.lvDrives.SelectedIndexChanged += lvDrives_SelectedIndexChanged;

            this.tabDrives.Controls.Add(this.lvDrives);
            this.tabDrives.Padding = new System.Windows.Forms.Padding(0);

            // ══ FORM ════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.Text        = "Файловий менеджер — Лабораторна робота №27";
            this.Size        = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(800, 540);
            this.Font        = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor   = System.Drawing.Color.White;

            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlHeader);

            this.Load += (_, _) =>
            {
                try { splitBrowser.SplitterDistance = System.Math.Max(50, (int)(splitBrowser.Width  * 0.60)); } catch { }
                try { splitRight.SplitterDistance   = System.Math.Max(50, (int)(splitRight.Height   * 0.50)); } catch { }
            };
        }

        private void CreateIcons()
        {
            // Paint simple colored icons at runtime (no external resources needed)
            string[] labels = { "💿", "📁", "📄", "🖼", "📝", "⚙", "🗜" };
            System.Drawing.Color[] colors =
            {
                System.Drawing.Color.FromArgb(52,152,219),  // drive
                System.Drawing.Color.FromArgb(241,196,15),  // folder
                System.Drawing.Color.FromArgb(180,180,180), // file
                System.Drawing.Color.FromArgb(46,204,113),  // image
                System.Drawing.Color.FromArgb(52,73,94),    // text
                System.Drawing.Color.FromArgb(231,76,60),   // exe
                System.Drawing.Color.FromArgb(155,89,182),  // archive
            };

            for (int i = 0; i < colors.Length; i++)
            {
                var bmp = new System.Drawing.Bitmap(18, 18);
                using var g = System.Drawing.Graphics.FromImage(bmp);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var b = new System.Drawing.SolidBrush(colors[i]);
                g.FillRectangle(b, 2, 2, 14, 14);
                this.imgList.Images.Add(bmp);
            }
        }

        private static void FBtn(System.Windows.Forms.Button btn, string text,
            System.Drawing.Color bg, int x, int y, int w)
        {
            btn.Text      = text;
            btn.Location  = new System.Drawing.Point(x, y);
            btn.Size      = new System.Drawing.Size(w, 24);
            btn.BackColor = bg;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
            btn.Cursor    = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel             pnlHeader, pnlStatus, pnlAddress, pnlFilter;
        private System.Windows.Forms.Label             lblHeader, lblStatus, lblPath;
        private System.Windows.Forms.Label             lblFilterFile, lblFilterDir;
        private System.Windows.Forms.TabControl        tabMain;
        private System.Windows.Forms.TabPage           tabBrowser, tabDrives;
        private System.Windows.Forms.SplitContainer    splitBrowser, splitRight;
        private System.Windows.Forms.ListView          lvFiles, lvDrives;
        private System.Windows.Forms.ColumnHeader      colName, colType, colCreated, colModified, colSize;
        private System.Windows.Forms.ColumnHeader      colDrive, colDType, colLabel, colFS, colTotal, colFree;
        private System.Windows.Forms.GroupBox          grpProps, grpPreview;
        private System.Windows.Forms.RichTextBox       rtbProps, rtbPreview;
        private System.Windows.Forms.PictureBox        picPreview;
        private System.Windows.Forms.TextBox           txtPath, txtFilterFile, txtFilterDir;
        private System.Windows.Forms.Button            btnGo, btnApplyFilter, btnClearFilter;
        private System.Windows.Forms.ImageList         imgList;
    }
}
