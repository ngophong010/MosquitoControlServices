namespace ServiceControllerApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblStatus = new Label();
            btnConnect = new Button();
            btnCreateUser = new Button();
            btnSubscribe = new Button();
            btnPublish = new Button();
            btnUnsubscribe = new Button();
            btnDisconnect = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(366, 81);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Username :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(366, 123);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Password :";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(485, 81);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(485, 120);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(152, 326);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(140, 194);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(33, 194);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(75, 23);
            btnCreateUser.TabIndex = 6;
            btnCreateUser.Text = "Create";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // btnSubscribe
            // 
            btnSubscribe.Location = new Point(255, 194);
            btnSubscribe.Name = "btnSubscribe";
            btnSubscribe.Size = new Size(101, 23);
            btnSubscribe.TabIndex = 7;
            btnSubscribe.Text = "SubscribeTopic";
            btnSubscribe.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.Location = new Point(408, 194);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(110, 23);
            btnPublish.TabIndex = 8;
            btnPublish.Text = "PublishMessages";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnUnsubscribe
            // 
            btnUnsubscribe.Location = new Point(567, 194);
            btnUnsubscribe.Name = "btnUnsubscribe";
            btnUnsubscribe.Size = new Size(103, 23);
            btnUnsubscribe.TabIndex = 9;
            btnUnsubscribe.Text = "Unsubscribe";
            btnUnsubscribe.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(704, 194);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 10;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(33, 236);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(33, 276);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnDisconnect);
            Controls.Add(btnUnsubscribe);
            Controls.Add(btnPublish);
            Controls.Add(btnSubscribe);
            Controls.Add(btnCreateUser);
            Controls.Add(btnConnect);
            Controls.Add(lblStatus);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosing_1;
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblStatus;
        private Button btnConnect;
        private Button btnCreateUser;
        private Button btnSubscribe;
        private Button btnPublish;
        private Button btnUnsubscribe;
        private Button btnDisconnect;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
