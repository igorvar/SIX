namespace SearchInXml
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spliterXmlSource = new System.Windows.Forms.SplitContainer();
            this.txtXpathToNode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.twSourceXml = new System.Windows.Forms.TreeView();
            this.mnuXmlTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmCopyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSource = new System.Windows.Forms.TabControl();
            this.tabPageSourceText = new System.Windows.Forms.TabPage();
            this.btnVisualizateXmlText = new System.Windows.Forms.Button();
            this.txtXml = new System.Windows.Forms.RichTextBox();
            this.tabPageSourceFile = new System.Windows.Forms.TabPage();
            this.txtFileInfo = new System.Windows.Forms.TextBox();
            this.btnVisualizateXmlFile = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtRezult = new System.Windows.Forms.RichTextBox();
            this.mnuRezult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmShowInTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtXpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lstXpathHelperSourse = new System.Windows.Forms.ListBox();
            this.spliterEditor = new System.Windows.Forms.SplitContainer();
            this.btnShowHideBuilder = new System.Windows.Forms.Button();
            this.rtfXpathHelp = new System.Windows.Forms.RichTextBox();
            this.spliterMain = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmCopyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTxtXml = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itnUundoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itmCleareAndPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFindItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.spliterXmlSource.Panel1.SuspendLayout();
            this.spliterXmlSource.Panel2.SuspendLayout();
            this.spliterXmlSource.SuspendLayout();
            this.mnuXmlTree.SuspendLayout();
            this.tabSource.SuspendLayout();
            this.tabPageSourceText.SuspendLayout();
            this.tabPageSourceFile.SuspendLayout();
            this.mnuRezult.SuspendLayout();
            this.spliterEditor.Panel1.SuspendLayout();
            this.spliterEditor.Panel2.SuspendLayout();
            this.spliterEditor.SuspendLayout();
            this.spliterMain.Panel1.SuspendLayout();
            this.spliterMain.Panel2.SuspendLayout();
            this.spliterMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.mnuTxtXml.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 491);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.spliterXmlSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtRezult);
            this.splitContainer1.Size = new System.Drawing.Size(1050, 491);
            this.splitContainer1.SplitterDistance = 654;
            this.splitContainer1.TabIndex = 0;
            // 
            // spliterXmlSource
            // 
            this.spliterXmlSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spliterXmlSource.Location = new System.Drawing.Point(0, 0);
            this.spliterXmlSource.Name = "spliterXmlSource";
            this.spliterXmlSource.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spliterXmlSource.Panel1
            // 
            this.spliterXmlSource.Panel1.Controls.Add(this.txtXpathToNode);
            this.spliterXmlSource.Panel1.Controls.Add(this.label3);
            this.spliterXmlSource.Panel1.Controls.Add(this.twSourceXml);
            // 
            // spliterXmlSource.Panel2
            // 
            this.spliterXmlSource.Panel2.Controls.Add(this.tabSource);
            this.spliterXmlSource.Size = new System.Drawing.Size(654, 491);
            this.spliterXmlSource.SplitterDistance = 389;
            this.spliterXmlSource.TabIndex = 2;
            // 
            // txtXpathToNode
            // 
            this.txtXpathToNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXpathToNode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXpathToNode.Location = new System.Drawing.Point(78, 368);
            this.txtXpathToNode.Name = "txtXpathToNode";
            this.txtXpathToNode.ReadOnly = true;
            this.txtXpathToNode.Size = new System.Drawing.Size(572, 13);
            this.txtXpathToNode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xpath to node:";
            // 
            // twSourceXml
            // 
            this.twSourceXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.twSourceXml.ContextMenuStrip = this.mnuXmlTree;
            this.twSourceXml.Font = new System.Drawing.Font("Courier New", 8F);
            this.twSourceXml.ItemHeight = 14;
            this.twSourceXml.Location = new System.Drawing.Point(0, 0);
            this.twSourceXml.Name = "twSourceXml";
            this.twSourceXml.Size = new System.Drawing.Size(654, 365);
            this.twSourceXml.TabIndex = 1;
            this.twSourceXml.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.twSourceXml_AfterSelect);
            this.twSourceXml.MouseDown += new System.Windows.Forms.MouseEventHandler(this.twSourceXml_MouseDown);
            // 
            // mnuXmlTree
            // 
            this.mnuXmlTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmCopyValueToolStripMenuItem,
            this.itmFindItToolStripMenuItem});
            this.mnuXmlTree.Name = "mnuXmlTree";
            this.mnuXmlTree.ShowImageMargin = false;
            this.mnuXmlTree.Size = new System.Drawing.Size(104, 48);
            this.mnuXmlTree.Opening += new System.ComponentModel.CancelEventHandler(this.mnuXmlTree_Opening);
            // 
            // itmCopyValueToolStripMenuItem
            // 
            this.itmCopyValueToolStripMenuItem.Name = "itmCopyValueToolStripMenuItem";
            this.itmCopyValueToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.itmCopyValueToolStripMenuItem.Text = "Copy value";
            this.itmCopyValueToolStripMenuItem.Click += new System.EventHandler(this.itmCopyValueToolStripMenuItem_Click);
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.tabPageSourceText);
            this.tabSource.Controls.Add(this.tabPageSourceFile);
            this.tabSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSource.Location = new System.Drawing.Point(0, 0);
            this.tabSource.Name = "tabSource";
            this.tabSource.SelectedIndex = 0;
            this.tabSource.Size = new System.Drawing.Size(654, 98);
            this.tabSource.TabIndex = 0;
            // 
            // tabPageSourceText
            // 
            this.tabPageSourceText.Controls.Add(this.btnVisualizateXmlText);
            this.tabPageSourceText.Controls.Add(this.txtXml);
            this.tabPageSourceText.Location = new System.Drawing.Point(4, 22);
            this.tabPageSourceText.Name = "tabPageSourceText";
            this.tabPageSourceText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSourceText.Size = new System.Drawing.Size(646, 72);
            this.tabPageSourceText.TabIndex = 0;
            this.tabPageSourceText.Text = "Text";
            this.tabPageSourceText.UseVisualStyleBackColor = true;
            // 
            // btnVisualizateXmlText
            // 
            this.btnVisualizateXmlText.Location = new System.Drawing.Point(8, 3);
            this.btnVisualizateXmlText.Name = "btnVisualizateXmlText";
            this.btnVisualizateXmlText.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizateXmlText.TabIndex = 1;
            this.btnVisualizateXmlText.Text = "Show";
            this.btnVisualizateXmlText.UseVisualStyleBackColor = true;
            this.btnVisualizateXmlText.Click += new System.EventHandler(this.btnVisualizateXmlText_Click);
            // 
            // txtXml
            // 
            this.txtXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXml.ContextMenuStrip = this.mnuTxtXml;
            this.txtXml.DetectUrls = false;
            this.txtXml.EnableAutoDragDrop = true;
            this.txtXml.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtXml.Location = new System.Drawing.Point(3, 30);
            this.txtXml.Name = "txtXml";
            this.txtXml.Size = new System.Drawing.Size(640, 39);
            this.txtXml.TabIndex = 0;
            this.txtXml.Text = "";
            this.txtXml.Validating += new System.ComponentModel.CancelEventHandler(this.txtXml_Validating);
            // 
            // tabPageSourceFile
            // 
            this.tabPageSourceFile.Controls.Add(this.txtFileInfo);
            this.tabPageSourceFile.Controls.Add(this.btnVisualizateXmlFile);
            this.tabPageSourceFile.Controls.Add(this.btnSelectFile);
            this.tabPageSourceFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageSourceFile.Name = "tabPageSourceFile";
            this.tabPageSourceFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSourceFile.Size = new System.Drawing.Size(646, 72);
            this.tabPageSourceFile.TabIndex = 1;
            this.tabPageSourceFile.Text = "File";
            this.tabPageSourceFile.UseVisualStyleBackColor = true;
            // 
            // txtFileInfo
            // 
            this.txtFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileInfo.Location = new System.Drawing.Point(8, 40);
            this.txtFileInfo.Multiline = true;
            this.txtFileInfo.Name = "txtFileInfo";
            this.txtFileInfo.ReadOnly = true;
            this.txtFileInfo.Size = new System.Drawing.Size(638, 24);
            this.txtFileInfo.TabIndex = 5;
            // 
            // btnVisualizateXmlFile
            // 
            this.btnVisualizateXmlFile.Location = new System.Drawing.Point(88, 11);
            this.btnVisualizateXmlFile.Name = "btnVisualizateXmlFile";
            this.btnVisualizateXmlFile.Size = new System.Drawing.Size(79, 23);
            this.btnVisualizateXmlFile.TabIndex = 4;
            this.btnVisualizateXmlFile.Text = "Show";
            this.btnVisualizateXmlFile.UseVisualStyleBackColor = true;
            this.btnVisualizateXmlFile.Click += new System.EventHandler(this.btnVisualizateXmlFile_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(3, 11);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(79, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Load...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtRezult
            // 
            this.txtRezult.BackColor = System.Drawing.SystemColors.Window;
            this.txtRezult.ContextMenuStrip = this.mnuRezult;
            this.txtRezult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRezult.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtRezult.Location = new System.Drawing.Point(0, 0);
            this.txtRezult.Name = "txtRezult";
            this.txtRezult.ReadOnly = true;
            this.txtRezult.Size = new System.Drawing.Size(392, 491);
            this.txtRezult.TabIndex = 0;
            this.txtRezult.Text = "";
            // 
            // mnuRezult
            // 
            this.mnuRezult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmShowInTreeToolStripMenuItem,
            this.toolStripSeparator1,
            this.itmCopyAllToolStripMenuItem,
            this.itmCopyToolStripMenuItem});
            this.mnuRezult.Name = "mnuRezult";
            this.mnuRezult.ShowImageMargin = false;
            this.mnuRezult.Size = new System.Drawing.Size(110, 76);
            this.mnuRezult.Text = "a1";
            // 
            // itmShowInTreeToolStripMenuItem
            // 
            this.itmShowInTreeToolStripMenuItem.Name = "itmShowInTreeToolStripMenuItem";
            this.itmShowInTreeToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.itmShowInTreeToolStripMenuItem.Text = "Show in tree";
            this.itmShowInTreeToolStripMenuItem.Click += new System.EventHandler(this.itmShowInTreeToolStripMenuItem_Click);
            // 
            // txtXpath
            // 
            this.txtXpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXpath.AutoCompleteCustomSource.AddRange(new string[] {
            "111",
            "222",
            "333"});
            this.txtXpath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtXpath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtXpath.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtXpath.Location = new System.Drawing.Point(43, 3);
            this.txtXpath.Name = "txtXpath";
            this.txtXpath.Size = new System.Drawing.Size(670, 21);
            this.txtXpath.TabIndex = 1;
            this.txtXpath.Text = "/";
            this.txtXpath.TextChanged += new System.EventHandler(this.txtXpath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Xpath:";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(725, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(42, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Exec";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lstXpathHelperSourse
            // 
            this.lstXpathHelperSourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstXpathHelperSourse.FormattingEnabled = true;
            this.lstXpathHelperSourse.Location = new System.Drawing.Point(0, 0);
            this.lstXpathHelperSourse.Name = "lstXpathHelperSourse";
            this.lstXpathHelperSourse.Size = new System.Drawing.Size(276, 100);
            this.lstXpathHelperSourse.TabIndex = 6;
            this.lstXpathHelperSourse.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // spliterEditor
            // 
            this.spliterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spliterEditor.Location = new System.Drawing.Point(0, 0);
            this.spliterEditor.Name = "spliterEditor";
            // 
            // spliterEditor.Panel1
            // 
            this.spliterEditor.Panel1.Controls.Add(this.btnShowHideBuilder);
            this.spliterEditor.Panel1.Controls.Add(this.rtfXpathHelp);
            this.spliterEditor.Panel1.Controls.Add(this.txtXpath);
            this.spliterEditor.Panel1.Controls.Add(this.btnRun);
            this.spliterEditor.Panel1.Controls.Add(this.label1);
            // 
            // spliterEditor.Panel2
            // 
            this.spliterEditor.Panel2.Controls.Add(this.lstXpathHelperSourse);
            this.spliterEditor.Size = new System.Drawing.Size(1050, 100);
            this.spliterEditor.SplitterDistance = 770;
            this.spliterEditor.TabIndex = 9;
            // 
            // btnShowHideBuilder
            // 
            this.btnShowHideBuilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHideBuilder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowHideBuilder.Location = new System.Drawing.Point(714, 3);
            this.btnShowHideBuilder.Name = "btnShowHideBuilder";
            this.btnShowHideBuilder.Size = new System.Drawing.Size(7, 21);
            this.btnShowHideBuilder.TabIndex = 0;
            this.btnShowHideBuilder.TabStop = false;
            this.btnShowHideBuilder.Text = ".";
            this.btnShowHideBuilder.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnShowHideBuilder.UseVisualStyleBackColor = true;
            this.btnShowHideBuilder.Click += new System.EventHandler(this.lblShowHideBuilder_Click);
            // 
            // rtfXpathHelp
            // 
            this.rtfXpathHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfXpathHelp.AutoWordSelection = true;
            this.rtfXpathHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfXpathHelp.Location = new System.Drawing.Point(3, 30);
            this.rtfXpathHelp.Name = "rtfXpathHelp";
            this.rtfXpathHelp.ReadOnly = true;
            this.rtfXpathHelp.Size = new System.Drawing.Size(764, 67);
            this.rtfXpathHelp.TabIndex = 10;
            this.rtfXpathHelp.Text = "text for xpath helper";
            // 
            // spliterMain
            // 
            this.spliterMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spliterMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spliterMain.Location = new System.Drawing.Point(0, 0);
            this.spliterMain.Name = "spliterMain";
            this.spliterMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spliterMain.Panel1
            // 
            this.spliterMain.Panel1.Controls.Add(this.spliterEditor);
            // 
            // spliterMain.Panel2
            // 
            this.spliterMain.Panel2.Controls.Add(this.panel1);
            this.spliterMain.Size = new System.Drawing.Size(1050, 595);
            this.spliterMain.SplitterDistance = 100;
            this.spliterMain.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.xml";
            this.openFileDialog1.Filter = "*.xml|*.xml|*.*|*.*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // itmCopyAllToolStripMenuItem
            // 
            this.itmCopyAllToolStripMenuItem.Name = "itmCopyAllToolStripMenuItem";
            this.itmCopyAllToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.itmCopyAllToolStripMenuItem.Text = "Copy all";
            this.itmCopyAllToolStripMenuItem.Click += new System.EventHandler(this.itmCopyAllToolStripMenuItem_Click);
            // 
            // itmCopyToolStripMenuItem
            // 
            this.itmCopyToolStripMenuItem.Name = "itmCopyToolStripMenuItem";
            this.itmCopyToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.itmCopyToolStripMenuItem.Text = "Copy";
            this.itmCopyToolStripMenuItem.Click += new System.EventHandler(this.itmCopyToolStripMenuItem_Click);
            // 
            // mnuTxtXml
            // 
            this.mnuTxtXml.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itnUundoToolStripMenuItem,
            this.toolStripSeparator2,
            this.itmCleareAndPasteToolStripMenuItem});
            this.mnuTxtXml.Name = "mnuTxtXml";
            this.mnuTxtXml.ShowImageMargin = false;
            this.mnuTxtXml.Size = new System.Drawing.Size(126, 54);
            this.mnuTxtXml.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTxtXml_Opening);
            // 
            // itnUundoToolStripMenuItem
            // 
            this.itnUundoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itnUundoToolStripMenuItem.Name = "itnUundoToolStripMenuItem";
            this.itnUundoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.itnUundoToolStripMenuItem.Text = "Undo";
            this.itnUundoToolStripMenuItem.Click += new System.EventHandler(this.itnUundoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // itmCleareAndPasteToolStripMenuItem
            // 
            this.itmCleareAndPasteToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.itmCleareAndPasteToolStripMenuItem.Name = "itmCleareAndPasteToolStripMenuItem";
            this.itmCleareAndPasteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.itmCleareAndPasteToolStripMenuItem.Text = "Clear and paste";
            this.itmCleareAndPasteToolStripMenuItem.Click += new System.EventHandler(this.itmCleareAndPasteToolStripMenuItem_Click);
            // 
            // itmFindItToolStripMenuItem
            // 
            this.itmFindItToolStripMenuItem.Name = "itmFindItToolStripMenuItem";
            this.itmFindItToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.itmFindItToolStripMenuItem.Text = "Find it";
            this.itmFindItToolStripMenuItem.Click += new System.EventHandler(this.itmFindItToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 597);
            this.Controls.Add(this.spliterMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SearchInXml";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.spliterXmlSource.Panel1.ResumeLayout(false);
            this.spliterXmlSource.Panel1.PerformLayout();
            this.spliterXmlSource.Panel2.ResumeLayout(false);
            this.spliterXmlSource.ResumeLayout(false);
            this.mnuXmlTree.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            this.tabPageSourceText.ResumeLayout(false);
            this.tabPageSourceFile.ResumeLayout(false);
            this.tabPageSourceFile.PerformLayout();
            this.mnuRezult.ResumeLayout(false);
            this.spliterEditor.Panel1.ResumeLayout(false);
            this.spliterEditor.Panel1.PerformLayout();
            this.spliterEditor.Panel2.ResumeLayout(false);
            this.spliterEditor.ResumeLayout(false);
            this.spliterMain.Panel1.ResumeLayout(false);
            this.spliterMain.Panel2.ResumeLayout(false);
            this.spliterMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.mnuTxtXml.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtXpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RichTextBox txtXml;
        private System.Windows.Forms.RichTextBox txtRezult;
        private System.Windows.Forms.ListBox lstXpathHelperSourse;
        private System.Windows.Forms.SplitContainer spliterEditor;
        private System.Windows.Forms.SplitContainer spliterMain;
        private System.Windows.Forms.TreeView twSourceXml;
        private System.Windows.Forms.SplitContainer spliterXmlSource;
        private System.Windows.Forms.TabControl tabSource;
        private System.Windows.Forms.TabPage tabPageSourceText;
        private System.Windows.Forms.TabPage tabPageSourceFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnVisualizateXmlText;
        private System.Windows.Forms.Button btnVisualizateXmlFile;
        private System.Windows.Forms.TextBox txtFileInfo;
        private System.Windows.Forms.TextBox txtXpathToNode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip mnuRezult;
        private System.Windows.Forms.ToolStripMenuItem itmShowInTreeToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtfXpathHelp;
        private System.Windows.Forms.Button btnShowHideBuilder;
        private System.Windows.Forms.ContextMenuStrip mnuXmlTree;
        private System.Windows.Forms.ToolStripMenuItem itmCopyValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmCopyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itmCopyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuTxtXml;
        private System.Windows.Forms.ToolStripMenuItem itnUundoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem itmCleareAndPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itmFindItToolStripMenuItem;
    }
}

