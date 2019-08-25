namespace mook_ListView
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvView = new System.Windows.Forms.ListView();
            this.Empty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArriveTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServiceTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriorityRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPID = new System.Windows.Forms.Label();
            this.lblServiceTime = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.txtServiceTime = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtArriveTime = new System.Windows.Forms.TextBox();
            this.lblArriveTime = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtQuantumTime = new System.Windows.Forms.TextBox();
            this.lblQuantumTime = new System.Windows.Forms.Label();
            this.btnResion = new System.Windows.Forms.Button();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvView
            // 
            this.lvView.BackColor = System.Drawing.SystemColors.Info;
            this.lvView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Empty,
            this.PID,
            this.ArriveTime,
            this.ServiceTime,
            this.PriorityRank});
            this.lvView.FullRowSelect = true;
            this.lvView.GridLines = true;
            this.lvView.Location = new System.Drawing.Point(12, 12);
            this.lvView.Name = "lvView";
            this.lvView.Size = new System.Drawing.Size(404, 177);
            this.lvView.TabIndex = 0;
            this.lvView.UseCompatibleStateImageBehavior = false;
            this.lvView.View = System.Windows.Forms.View.Details;
            // 
            // Empty
            // 
            this.Empty.Text = "";
            this.Empty.Width = 0;
            // 
            // PID
            // 
            this.PID.Text = "프로세스ID";
            this.PID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PID.Width = 100;
            // 
            // ArriveTime
            // 
            this.ArriveTime.Text = "도착시간";
            this.ArriveTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ArriveTime.Width = 100;
            // 
            // ServiceTime
            // 
            this.ServiceTime.Text = "서비스시간";
            this.ServiceTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServiceTime.Width = 100;
            // 
            // PriorityRank
            // 
            this.PriorityRank.Text = "우선순위";
            this.PriorityRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriorityRank.Width = 100;
            // 
            // lblPID
            // 
            this.lblPID.AutoSize = true;
            this.lblPID.Location = new System.Drawing.Point(13, 199);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(76, 12);
            this.lblPID.TabIndex = 1;
            this.lblPID.Text = "프로세스ID : ";
            // 
            // lblServiceTime
            // 
            this.lblServiceTime.AutoSize = true;
            this.lblServiceTime.Location = new System.Drawing.Point(13, 226);
            this.lblServiceTime.Name = "lblServiceTime";
            this.lblServiceTime.Size = new System.Drawing.Size(77, 12);
            this.lblServiceTime.TabIndex = 2;
            this.lblServiceTime.Text = "서비스시간 : ";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(156, 226);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(65, 12);
            this.lblPriority.TabIndex = 3;
            this.lblPriority.Text = "우선순위 : ";
            // 
            // txtPID
            // 
            this.txtPID.Location = new System.Drawing.Point(89, 196);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(61, 21);
            this.txtPID.TabIndex = 4;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(218, 223);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(61, 21);
            this.txtPriority.TabIndex = 5;
            // 
            // txtServiceTime
            // 
            this.txtServiceTime.Location = new System.Drawing.Point(89, 223);
            this.txtServiceTime.Name = "txtServiceTime";
            this.txtServiceTime.Size = new System.Drawing.Size(61, 21);
            this.txtServiceTime.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(285, 196);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 21);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // txtArriveTime
            // 
            this.txtArriveTime.Location = new System.Drawing.Point(218, 195);
            this.txtArriveTime.Name = "txtArriveTime";
            this.txtArriveTime.Size = new System.Drawing.Size(61, 21);
            this.txtArriveTime.TabIndex = 9;
            // 
            // lblArriveTime
            // 
            this.lblArriveTime.AutoSize = true;
            this.lblArriveTime.Location = new System.Drawing.Point(156, 198);
            this.lblArriveTime.Name = "lblArriveTime";
            this.lblArriveTime.Size = new System.Drawing.Size(65, 12);
            this.lblArriveTime.TabIndex = 8;
            this.lblArriveTime.Text = "도착시간 : ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(285, 223);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(77, 21);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "지우기";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtQuantumTime
            // 
            this.txtQuantumTime.Location = new System.Drawing.Point(89, 250);
            this.txtQuantumTime.Name = "txtQuantumTime";
            this.txtQuantumTime.Size = new System.Drawing.Size(61, 21);
            this.txtQuantumTime.TabIndex = 12;
            // 
            // lblQuantumTime
            // 
            this.lblQuantumTime.AutoSize = true;
            this.lblQuantumTime.Location = new System.Drawing.Point(13, 253);
            this.lblQuantumTime.Name = "lblQuantumTime";
            this.lblQuantumTime.Size = new System.Drawing.Size(77, 12);
            this.lblQuantumTime.TabIndex = 11;
            this.lblQuantumTime.Text = "시간할당량 : ";
            // 
            // btnResion
            // 
            this.btnResion.Location = new System.Drawing.Point(368, 196);
            this.btnResion.Name = "btnResion";
            this.btnResion.Size = new System.Drawing.Size(48, 48);
            this.btnResion.TabIndex = 13;
            this.btnResion.Text = "등록";
            this.btnResion.UseVisualStyleBackColor = true;
            this.btnResion.Click += new System.EventHandler(this.btnResion_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(158, 250);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(258, 21);
            this.pbStatus.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(435, 276);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnResion);
            this.Controls.Add(this.txtQuantumTime);
            this.Controls.Add(this.lblQuantumTime);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtArriveTime);
            this.Controls.Add(this.lblArriveTime);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtServiceTime);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblServiceTime);
            this.Controls.Add(this.lblPID);
            this.Controls.Add(this.lvView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "데이터 등록";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvView;
        private System.Windows.Forms.Label lblPID;
        private System.Windows.Forms.Label lblServiceTime;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.TextBox txtServiceTime;
        private System.Windows.Forms.ColumnHeader ArriveTime;
        private System.Windows.Forms.ColumnHeader ServiceTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader PriorityRank;
        private System.Windows.Forms.TextBox txtArriveTime;
        private System.Windows.Forms.Label lblArriveTime;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtQuantumTime;
        private System.Windows.Forms.Label lblQuantumTime;
        private System.Windows.Forms.Button btnResion;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ColumnHeader PID;
        private System.Windows.Forms.ColumnHeader Empty;
    }
}

