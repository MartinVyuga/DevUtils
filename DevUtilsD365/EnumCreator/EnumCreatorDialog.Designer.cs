﻿namespace DevUtilsD365.EnumCreator
{
    partial class EnumCreatorDialog
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
            this.EnumNameTextBox = new System.Windows.Forms.TextBox();
            this.enumCreatorParmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SeparatorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValuesTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PreviewTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.TypeNameTextBox = new System.Windows.Forms.TextBox();
            this.IsCreateTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EnumLabelTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StartIndexTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.enumCreatorParmsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enum name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnumNameTextBox
            // 
            this.EnumNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumName", true));
            this.EnumNameTextBox.Location = new System.Drawing.Point(16, 26);
            this.EnumNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnumNameTextBox.Name = "EnumNameTextBox";
            this.EnumNameTextBox.Size = new System.Drawing.Size(247, 23);
            this.EnumNameTextBox.TabIndex = 1;
            // 
            // enumCreatorParmsBindingSource
            // 
            this.enumCreatorParmsBindingSource.DataSource = typeof(DevUtilsD365.EnumCreator.EnumCreatorParms);
            // 
            // SeparatorTextBox
            // 
            this.SeparatorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "ValuesSeparator", true));
            this.SeparatorTextBox.Location = new System.Drawing.Point(329, 112);
            this.SeparatorTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SeparatorTextBox.MaxLength = 1;
            this.SeparatorTextBox.Name = "SeparatorTextBox";
            this.SeparatorTextBox.Size = new System.Drawing.Size(32, 23);
            this.SeparatorTextBox.TabIndex = 3;
            this.SeparatorTextBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Separator:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ValuesTextBox
            // 
            this.ValuesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumValuesStr", true));
            this.ValuesTextBox.Font = new System.Drawing.Font("Consolas", 9F);
            this.ValuesTextBox.Location = new System.Drawing.Point(16, 140);
            this.ValuesTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ValuesTextBox.Multiline = true;
            this.ValuesTextBox.Name = "ValuesTextBox";
            this.ValuesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ValuesTextBox.Size = new System.Drawing.Size(349, 216);
            this.ValuesTextBox.TabIndex = 4;
            this.ValuesTextBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Values per line(Label | Name):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.PreviewTextBox.Location = new System.Drawing.Point(375, 140);
            this.PreviewTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PreviewTextBox.Multiline = true;
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PreviewTextBox.Size = new System.Drawing.Size(404, 216);
            this.PreviewTextBox.TabIndex = 6;
            this.PreviewTextBox.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Preview:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PreviewButton
            // 
            this.PreviewButton.Location = new System.Drawing.Point(472, 106);
            this.PreviewButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(72, 28);
            this.PreviewButton.TabIndex = 8;
            this.PreviewButton.Text = "Preview";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // TypeNameTextBox
            // 
            this.TypeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumTypeName", true));
            this.TypeNameTextBox.Location = new System.Drawing.Point(671, 74);
            this.TypeNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TypeNameTextBox.Name = "TypeNameTextBox";
            this.TypeNameTextBox.Size = new System.Drawing.Size(239, 23);
            this.TypeNameTextBox.TabIndex = 9;
            // 
            // IsCreateTypeCheckBox
            // 
            this.IsCreateTypeCheckBox.AutoSize = true;
            this.IsCreateTypeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.enumCreatorParmsBindingSource, "IsCreateEnumType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsCreateTypeCheckBox.Location = new System.Drawing.Point(671, 26);
            this.IsCreateTypeCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IsCreateTypeCheckBox.Name = "IsCreateTypeCheckBox";
            this.IsCreateTypeCheckBox.Size = new System.Drawing.Size(101, 21);
            this.IsCreateTypeCheckBox.TabIndex = 10;
            this.IsCreateTypeCheckBox.Text = "Create EDT";
            this.IsCreateTypeCheckBox.UseVisualStyleBackColor = true;
            this.IsCreateTypeCheckBox.CheckStateChanged += new System.EventHandler(this.IsCreateTypeCheckBox_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "EDT name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnumLabelTextBox
            // 
            this.EnumLabelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumLabel", true));
            this.EnumLabelTextBox.Location = new System.Drawing.Point(373, 26);
            this.EnumLabelTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnumLabelTextBox.Name = "EnumLabelTextBox";
            this.EnumLabelTextBox.Size = new System.Drawing.Size(251, 23);
            this.EnumLabelTextBox.TabIndex = 13;
            this.EnumLabelTextBox.Validated += new System.EventHandler(this.EnumLabelTextBox_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Label:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumHelpText", true));
            this.textBox2.Location = new System.Drawing.Point(375, 74);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 23);
            this.textBox2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Help text:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 364);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 39);
            this.button1.TabIndex = 16;
            this.button1.Text = "Create ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartIndexTextBox
            // 
            this.StartIndexTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.enumCreatorParmsBindingSource, "EnumValueStartIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N0"));
            this.StartIndexTextBox.Location = new System.Drawing.Point(16, 74);
            this.StartIndexTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartIndexTextBox.Name = "StartIndexTextBox";
            this.StartIndexTextBox.Size = new System.Drawing.Size(75, 23);
            this.StartIndexTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Start index:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EnumCreatorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 407);
            this.Controls.Add(this.StartIndexTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EnumLabelTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IsCreateTypeCheckBox);
            this.Controls.Add(this.TypeNameTextBox);
            this.Controls.Add(this.PreviewButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PreviewTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValuesTextBox);
            this.Controls.Add(this.SeparatorTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnumNameTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EnumCreatorDialog";
            this.Text = "Enum builder";
            ((System.ComponentModel.ISupportInitialize)(this.enumCreatorParmsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EnumNameTextBox;
        private System.Windows.Forms.TextBox SeparatorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ValuesTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PreviewTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.TextBox TypeNameTextBox;
        private System.Windows.Forms.CheckBox IsCreateTypeCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EnumLabelTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource enumCreatorParmsBindingSource;
        private System.Windows.Forms.TextBox StartIndexTextBox;
        private System.Windows.Forms.Label label8;
    }
}