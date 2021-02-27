﻿namespace DevUtilsD365.CreateExtensionClass
{
    partial class CreateExtensionClassDialog
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
            this.ElementNameTextBox = new System.Windows.Forms.TextBox();
            this.createExtensionClassParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PrefixTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ResultClassNameTextBox = new System.Windows.Forms.TextBox();
            this.CreateClassButton = new System.Windows.Forms.Button();
            this.RestoreNameButton = new System.Windows.Forms.Button();
            this.ElementTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.createExtensionClassParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ElementNameTextBox
            // 
            this.ElementNameTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ElementNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createExtensionClassParmsBindingSource, "ElementName", true));
            this.ElementNameTextBox.Location = new System.Drawing.Point(210, 44);
            this.ElementNameTextBox.Name = "ElementNameTextBox";
            this.ElementNameTextBox.Size = new System.Drawing.Size(404, 28);
            this.ElementNameTextBox.TabIndex = 101;
            // 
            // createExtensionClassParmsBindingSource
            // 
            this.createExtensionClassParmsBindingSource.DataSource = typeof(DevUtilsD365.CreateExtensionClass.CreateExtensionClassParms);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Primary element:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Element type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Prefix:";
            // 
            // PrefixTextBox
            // 
            this.PrefixTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createExtensionClassParmsBindingSource, "Prefix", true));
            this.PrefixTextBox.Location = new System.Drawing.Point(210, 120);
            this.PrefixTextBox.Name = "PrefixTextBox";
            this.PrefixTextBox.Size = new System.Drawing.Size(104, 28);
            this.PrefixTextBox.TabIndex = 4;
            this.PrefixTextBox.Validated += new System.EventHandler(this.PrefixTextBox_Validated);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.createExtensionClassParmsBindingSource, "ClassType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(448, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 30);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Final class name:";
            // 
            // ResultClassNameTextBox
            // 
            this.ResultClassNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createExtensionClassParmsBindingSource, "ResultClassName", true));
            this.ResultClassNameTextBox.Location = new System.Drawing.Point(168, 154);
            this.ResultClassNameTextBox.Name = "ResultClassNameTextBox";
            this.ResultClassNameTextBox.Size = new System.Drawing.Size(437, 28);
            this.ResultClassNameTextBox.TabIndex = 8;
            // 
            // CreateClassButton
            // 
            this.CreateClassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateClassButton.Location = new System.Drawing.Point(16, 237);
            this.CreateClassButton.Name = "CreateClassButton";
            this.CreateClassButton.Size = new System.Drawing.Size(129, 31);
            this.CreateClassButton.TabIndex = 10;
            this.CreateClassButton.Text = "Create class";
            this.CreateClassButton.UseVisualStyleBackColor = true;
            this.CreateClassButton.Click += new System.EventHandler(this.CreateClassButton_Click);
            // 
            // RestoreNameButton
            // 
            this.RestoreNameButton.Location = new System.Drawing.Point(623, 159);
            this.RestoreNameButton.Name = "RestoreNameButton";
            this.RestoreNameButton.Size = new System.Drawing.Size(21, 23);
            this.RestoreNameButton.TabIndex = 11;
            this.RestoreNameButton.Text = "..";
            this.MyToolTip.SetToolTip(this.RestoreNameButton, "Refresh");
            this.RestoreNameButton.UseVisualStyleBackColor = true;
            this.RestoreNameButton.Click += new System.EventHandler(this.RestoreNameButton_Click);
            // 
            // ElementTypeComboBox
            // 
            this.ElementTypeComboBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ElementTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.createExtensionClassParmsBindingSource, "ElementType", true));
            this.ElementTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.createExtensionClassParmsBindingSource, "ElementType", true));
            this.ElementTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createExtensionClassParmsBindingSource, "ElementType", true));
            this.ElementTypeComboBox.FormattingEnabled = true;
            this.ElementTypeComboBox.Location = new System.Drawing.Point(210, 9);
            this.ElementTypeComboBox.Name = "ElementTypeComboBox";
            this.ElementTypeComboBox.Size = new System.Drawing.Size(202, 30);
            this.ElementTypeComboBox.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 24);
            this.label6.TabIndex = 102;
            this.label6.Text = "Child element:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.createExtensionClassParmsBindingSource, "SubElementName", true));
            this.textBox1.Location = new System.Drawing.Point(210, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(404, 28);
            this.textBox1.TabIndex = 103;
            // 
            // CreateExtensionClassDialog
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(919, 377);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ElementTypeComboBox);
            this.Controls.Add(this.RestoreNameButton);
            this.Controls.Add(this.CreateClassButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResultClassNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrefixTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ElementNameTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Name = "CreateExtensionClassDialog";
            this.Text = "Create extension class";
            ((System.ComponentModel.ISupportInitialize)(this.createExtensionClassParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ElementNameTextBox;
        private System.Windows.Forms.BindingSource createExtensionClassParmsBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PrefixTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ResultClassNameTextBox;
        private System.Windows.Forms.Button CreateClassButton;
        private System.Windows.Forms.Button RestoreNameButton;
        private System.Windows.Forms.ComboBox ElementTypeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}