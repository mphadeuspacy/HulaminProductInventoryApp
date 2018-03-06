namespace Gijima.Hulamin.WinFormsClient
{
    partial class RollingPruductsApp
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelContactName = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textCompanyName = new System.Windows.Forms.TextBox();
            this.textContactName = new System.Windows.Forms.TextBox();
            this.textContactTitle = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewEntities = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEntityId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textPostalCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textRegion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textCity = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCounty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(356, 53);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(121, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Company Name";
            // 
            // labelContactName
            // 
            this.labelContactName.AutoSize = true;
            this.labelContactName.BackColor = System.Drawing.Color.Transparent;
            this.labelContactName.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactName.Location = new System.Drawing.Point(356, 77);
            this.labelContactName.Name = "labelContactName";
            this.labelContactName.Size = new System.Drawing.Size(114, 16);
            this.labelContactName.TabIndex = 1;
            this.labelContactName.Text = "Contact Name";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.labelCompanyName.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyName.Location = new System.Drawing.Point(356, 103);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(108, 16);
            this.labelCompanyName.TabIndex = 2;
            this.labelCompanyName.Text = "Contact Title";
            // 
            // textCompanyName
            // 
            this.textCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCompanyName.Location = new System.Drawing.Point(528, 51);
            this.textCompanyName.Name = "textCompanyName";
            this.textCompanyName.Size = new System.Drawing.Size(176, 22);
            this.textCompanyName.TabIndex = 4;
            // 
            // textContactName
            // 
            this.textContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContactName.Location = new System.Drawing.Point(528, 75);
            this.textContactName.Name = "textContactName";
            this.textContactName.Size = new System.Drawing.Size(176, 22);
            this.textContactName.TabIndex = 5;
            // 
            // textContactTitle
            // 
            this.textContactTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textContactTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContactTitle.Location = new System.Drawing.Point(528, 103);
            this.textContactTitle.Name = "textContactTitle";
            this.textContactTitle.Size = new System.Drawing.Size(176, 22);
            this.textContactTitle.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(862, 77);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 32);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(862, 159);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 32);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(862, 235);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 32);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridViewEntities
            // 
            this.dataGridViewEntities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEntities.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntities.Location = new System.Drawing.Point(93, 333);
            this.dataGridViewEntities.Name = "dataGridViewEntities";
            this.dataGridViewEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEntities.Size = new System.Drawing.Size(857, 348);
            this.dataGridViewEntities.TabIndex = 11;
            this.dataGridViewEntities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.lblEntityId);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 46);
            this.panel1.TabIndex = 12;
            // 
            // lblEntityId
            // 
            this.lblEntityId.AutoSize = true;
            this.lblEntityId.Location = new System.Drawing.Point(523, 20);
            this.lblEntityId.Name = "lblEntityId";
            this.lblEntityId.Size = new System.Drawing.Size(18, 13);
            this.lblEntityId.TabIndex = 14;
            this.lblEntityId.Text = "ID";
            this.lblEntityId.Visible = false;
            this.lblEntityId.Click += new System.EventHandler(this.lblID_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Suppliers";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textAddress
            // 
            this.textAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAddress.Location = new System.Drawing.Point(528, 131);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(176, 22);
            this.textAddress.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Region";
            // 
            // textPostalCode
            // 
            this.textPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPostalCode.Location = new System.Drawing.Point(528, 213);
            this.textPostalCode.Name = "textPostalCode";
            this.textPostalCode.Size = new System.Drawing.Size(176, 22);
            this.textPostalCode.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Postal Code";
            // 
            // textRegion
            // 
            this.textRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRegion.Location = new System.Drawing.Point(528, 185);
            this.textRegion.Name = "textRegion";
            this.textRegion.Size = new System.Drawing.Size(176, 22);
            this.textRegion.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(356, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "City";
            // 
            // textCity
            // 
            this.textCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCity.Location = new System.Drawing.Point(528, 157);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(176, 22);
            this.textCity.TabIndex = 21;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.BackColor = System.Drawing.Color.Transparent;
            this.labelAddress.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(356, 131);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(67, 16);
            this.labelAddress.TabIndex = 20;
            this.labelAddress.Text = "Address";
            // 
            // textFax
            // 
            this.textFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFax.Location = new System.Drawing.Point(528, 295);
            this.textFax.Name = "textFax";
            this.textFax.Size = new System.Drawing.Size(176, 22);
            this.textFax.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fax";
            // 
            // textPhone
            // 
            this.textPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPhone.Location = new System.Drawing.Point(528, 267);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(176, 22);
            this.textPhone.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Phone";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textCounty
            // 
            this.textCounty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCounty.Location = new System.Drawing.Point(528, 241);
            this.textCounty.Name = "textCounty";
            this.textCounty.Size = new System.Drawing.Size(176, 22);
            this.textCounty.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(356, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Country";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // RollingPruductsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gijima.Hulamin.WinFormsClient.Properties.Resources.Backgrund1;
            this.ClientSize = new System.Drawing.Size(1037, 809);
            this.Controls.Add(this.textCounty);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textFax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCity);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textRegion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPostalCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewEntities);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.textContactTitle);
            this.Controls.Add(this.textContactName);
            this.Controls.Add(this.textCompanyName);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelContactName);
            this.Controls.Add(this.labelName);
            this.Name = "RollingPruductsApp";
            this.Text = "Rolling Product App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelContactName;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textCompanyName;
        private System.Windows.Forms.TextBox textContactName;
        private System.Windows.Forms.TextBox textContactTitle;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewEntities;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEntityId;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPostalCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textFax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCounty;
        private System.Windows.Forms.Label label8;
    }
}

