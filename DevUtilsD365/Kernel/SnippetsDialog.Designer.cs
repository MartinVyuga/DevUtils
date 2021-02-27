namespace DevUtilsD365.Kernel
{
    partial class SnippetsDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.ValuesControl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowResultButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ParametersBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SnippetNameBox = new System.Windows.Forms.ComboBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SeparatorTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.snippetsParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.snippetsParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Values";
            // 
            // ValuesControl
            // 
            this.ValuesControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ValuesControl.BackColor = System.Drawing.SystemColors.Window;
            this.ValuesControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "Values", true));
            this.ValuesControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValuesControl.Location = new System.Drawing.Point(153, 178);
            this.ValuesControl.Multiline = true;
            this.ValuesControl.Name = "ValuesControl";
            this.ValuesControl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ValuesControl.Size = new System.Drawing.Size(339, 514);
            this.ValuesControl.TabIndex = 2;
            this.ValuesControl.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parameters";
            // 
            // ShowResultButton
            // 
            this.ShowResultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowResultButton.Location = new System.Drawing.Point(616, 12);
            this.ShowResultButton.Name = "ShowResultButton";
            this.ShowResultButton.Size = new System.Drawing.Size(90, 31);
            this.ShowResultButton.TabIndex = 6;
            this.ShowResultButton.Text = "Refresh";
            this.ShowResultButton.UseVisualStyleBackColor = true;
            this.ShowResultButton.Click += new System.EventHandler(this.ShowResultButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(535, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Preview";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "ResultText", true));
            this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultTextBox.Location = new System.Drawing.Point(498, 58);
            this.ResultTextBox.MaxLength = 327670;
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultTextBox.Size = new System.Drawing.Size(1070, 631);
            this.ResultTextBox.TabIndex = 9;
            this.ResultTextBox.WordWrap = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(712, 15);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(156, 20);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copy to clipboard";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ParametersBox
            // 
            this.ParametersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParametersBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ParametersBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "Parameters", true));
            this.ParametersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersBox.Location = new System.Drawing.Point(6, 178);
            this.ParametersBox.Multiline = true;
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ParametersBox.Size = new System.Drawing.Size(149, 514);
            this.ParametersBox.TabIndex = 13;
            this.ParametersBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ParametersBox.WordWrap = false;
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(876, 12);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(89, 28);
            this.CreateButton.TabIndex = 15;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SnippetNameBox
            // 
            this.SnippetNameBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "SnippetName", true));
            this.SnippetNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnippetNameBox.FormattingEnabled = true;
            this.SnippetNameBox.Location = new System.Drawing.Point(81, 20);
            this.SnippetNameBox.Name = "SnippetNameBox";
            this.SnippetNameBox.Size = new System.Drawing.Size(184, 28);
            this.SnippetNameBox.TabIndex = 16;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DescriptionBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "Description", true));
            this.DescriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionBox.Location = new System.Drawing.Point(6, 58);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(474, 73);
            this.DescriptionBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(288, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Description";
            // 
            // SeparatorTextBox
            // 
            this.SeparatorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.snippetsParmsBindingSource, "ValuesSeparator", true));
            this.SeparatorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeparatorTextBox.Location = new System.Drawing.Point(450, 135);
            this.SeparatorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SeparatorTextBox.MaxLength = 1;
            this.SeparatorTextBox.Name = "SeparatorTextBox";
            this.SeparatorTextBox.Size = new System.Drawing.Size(32, 27);
            this.SeparatorTextBox.TabIndex = 21;
            this.SeparatorTextBox.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(345, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Separator:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // snippetsParmsBindingSource
            // 
            this.snippetsParmsBindingSource.DataSource = typeof(DevUtilsD365.Kernel.SnippetsParms);
            // 
            // SnippetsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 704);
            this.Controls.Add(this.SeparatorTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.SnippetNameBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ParametersBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShowResultButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValuesControl);
            this.Controls.Add(this.label1);
            this.Name = "SnippetsDialog";
            this.Text = "Advanced snippets dialog";
            ((System.ComponentModel.ISupportInitialize)(this.snippetsParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ValuesControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShowResultButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox ParametersBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ComboBox SnippetNameBox;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SeparatorTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource snippetsParmsBindingSource;
    }
}