namespace ProjectImplementaion
{
    partial class FormProject
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
            System.Windows.Forms.Label dateStartLabel;
            System.Windows.Forms.Label durationLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label customerLabel;
            System.Windows.Forms.Label categoryLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProject));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.projectDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAddPerformer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.performersListBox = new System.Windows.Forms.ListBox();
            this.performersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.projectBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.projectBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            dateStartLabel = new System.Windows.Forms.Label();
            durationLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            customerLabel = new System.Windows.Forms.Label();
            categoryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingNavigator)).BeginInit();
            this.projectBindingNavigator.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateStartLabel
            // 
            dateStartLabel.AutoSize = true;
            dateStartLabel.Location = new System.Drawing.Point(71, 99);
            dateStartLabel.Name = "dateStartLabel";
            dateStartLabel.Size = new System.Drawing.Size(105, 25);
            dateStartLabel.TabIndex = 4;
            dateStartLabel.Text = "Date Start:";
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new System.Drawing.Point(71, 135);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new System.Drawing.Size(91, 25);
            durationLabel.TabIndex = 6;
            durationLabel.Text = "Duration:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(71, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(70, 25);
            nameLabel.TabIndex = 12;
            nameLabel.Text = "Name:";
            // 
            // customerLabel
            // 
            customerLabel.AutoSize = true;
            customerLabel.Location = new System.Drawing.Point(71, 55);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new System.Drawing.Size(103, 25);
            customerLabel.TabIndex = 13;
            customerLabel.Text = "Customer:";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new System.Drawing.Point(71, 170);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new System.Drawing.Size(98, 25);
            categoryLabel.TabIndex = 14;
            categoryLabel.Text = "Category:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.projectDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddPerformer);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.performersListBox);
            this.splitContainer1.Panel2.Controls.Add(categoryLabel);
            this.splitContainer1.Panel2.Controls.Add(this.categoryComboBox);
            this.splitContainer1.Panel2.Controls.Add(customerLabel);
            this.splitContainer1.Panel2.Controls.Add(this.customerComboBox);
            this.splitContainer1.Panel2.Controls.Add(dateStartLabel);
            this.splitContainer1.Panel2.Controls.Add(this.dateStartDateTimePicker);
            this.splitContainer1.Panel2.Controls.Add(durationLabel);
            this.splitContainer1.Panel2.Controls.Add(this.durationTextBox);
            this.splitContainer1.Panel2.Controls.Add(nameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.nameTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 676);
            this.splitContainer1.SplitterDistance = 661;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // projectDataGridView
            // 
            this.projectDataGridView.AllowUserToAddRows = false;
            this.projectDataGridView.AllowUserToDeleteRows = false;
            this.projectDataGridView.AutoGenerateColumns = false;
            this.projectDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.projectDataGridView.DataSource = this.projectBindingSource;
            this.projectDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectDataGridView.Location = new System.Drawing.Point(0, 0);
            this.projectDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectDataGridView.Name = "projectDataGridView";
            this.projectDataGridView.ReadOnly = true;
            this.projectDataGridView.RowHeadersWidth = 51;
            this.projectDataGridView.RowTemplate.Height = 24;
            this.projectDataGridView.Size = new System.Drawing.Size(661, 676);
            this.projectDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Проект";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Customer";
            this.dataGridViewTextBoxColumn9.HeaderText = "Замовник";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CustomerId";
            this.dataGridViewTextBoxColumn3.HeaderText = "CustomerId";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HeadId";
            this.dataGridViewTextBoxColumn4.HeaderText = "HeadId";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateStart";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата початку";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Duration";
            this.dataGridViewTextBoxColumn6.HeaderText = "Тривалість";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CategoryId";
            this.dataGridViewTextBoxColumn7.HeaderText = "CategoryId";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn8.HeaderText = "Категорія";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(ProjectImplementaion.Project);
            this.projectBindingSource.CurrentChanged += new System.EventHandler(this.projectBindingSource_CurrentChanged);
            this.projectBindingSource.PositionChanged += new System.EventHandler(this.projectBindingSource_PositionChanged);
            // 
            // buttonAddPerformer
            // 
            this.buttonAddPerformer.Location = new System.Drawing.Point(201, 420);
            this.buttonAddPerformer.Name = "buttonAddPerformer";
            this.buttonAddPerformer.Size = new System.Drawing.Size(147, 61);
            this.buttonAddPerformer.TabIndex = 17;
            this.buttonAddPerformer.Text = "Додати виконавця";
            this.buttonAddPerformer.UseVisualStyleBackColor = true;
            this.buttonAddPerformer.Click += new System.EventHandler(this.buttonAddPerformer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Виконавець:";
            // 
            // performersListBox
            // 
            this.performersListBox.DataSource = this.performersBindingSource;
            this.performersListBox.DisplayMember = "Employee";
            this.performersListBox.FormattingEnabled = true;
            this.performersListBox.ItemHeight = 25;
            this.performersListBox.Location = new System.Drawing.Point(201, 209);
            this.performersListBox.Name = "performersListBox";
            this.performersListBox.Size = new System.Drawing.Size(320, 204);
            this.performersListBox.TabIndex = 15;
            this.performersListBox.ValueMember = "Id";
            // 
            // performersBindingSource
            // 
            this.performersBindingSource.DataMember = "Performers";
            this.performersBindingSource.DataSource = this.projectBindingSource;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.projectBindingSource, "Category", true));
            this.categoryComboBox.DataSource = this.categoryBindingSource;
            this.categoryComboBox.DisplayMember = "Name";
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(201, 170);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(320, 33);
            this.categoryComboBox.TabIndex = 15;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(ProjectImplementaion.Category);
            // 
            // customerComboBox
            // 
            this.customerComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.projectBindingSource, "Customer", true));
            this.customerComboBox.DataSource = this.customerBindingSource;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(201, 55);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(320, 33);
            this.customerComboBox.TabIndex = 14;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(ProjectImplementaion.Customer);
            // 
            // dateStartDateTimePicker
            // 
            this.dateStartDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.projectBindingSource, "DateStart", true));
            this.dateStartDateTimePicker.Location = new System.Drawing.Point(201, 95);
            this.dateStartDateTimePicker.Name = "dateStartDateTimePicker";
            this.dateStartDateTimePicker.Size = new System.Drawing.Size(320, 30);
            this.dateStartDateTimePicker.TabIndex = 5;
            // 
            // durationTextBox
            // 
            this.durationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Duration", true));
            this.durationTextBox.Location = new System.Drawing.Point(201, 132);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(320, 30);
            this.durationTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(201, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(320, 30);
            this.nameTextBox.TabIndex = 13;
            // 
            // projectBindingNavigator
            // 
            this.projectBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.projectBindingNavigator.BindingSource = this.projectBindingSource;
            this.projectBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.projectBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.projectBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.projectBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.projectBindingNavigatorSaveItem});
            this.projectBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.projectBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.projectBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.projectBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.projectBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.projectBindingNavigator.Name = "projectBindingNavigator";
            this.projectBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.projectBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.projectBindingNavigator.Size = new System.Drawing.Size(1200, 27);
            this.projectBindingNavigator.TabIndex = 1;
            this.projectBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // projectBindingNavigatorSaveItem
            // 
            this.projectBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.projectBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("projectBindingNavigatorSaveItem.Image")));
            this.projectBindingNavigatorSaveItem.Name = "projectBindingNavigatorSaveItem";
            this.projectBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.projectBindingNavigatorSaveItem.Text = "Save Data";
            this.projectBindingNavigatorSaveItem.Click += new System.EventHandler(this.projectBindingNavigatorSaveItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 681);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Location = new System.Drawing.Point(0, 654);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(661, 22);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.projectBindingNavigator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormProject";
            this.Text = "Створення і редагуваня проектів";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingNavigator)).EndInit();
            this.projectBindingNavigator.ResumeLayout(false);
            this.projectBindingNavigator.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView projectDataGridView;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.BindingNavigator projectBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton projectBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.DateTimePicker dateStartDateTimePicker;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox performersListBox;
        private System.Windows.Forms.BindingSource performersBindingSource;
        private System.Windows.Forms.Button buttonAddPerformer;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}