using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bug_Tracker.Views
{
    partial class Bugs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public static int rowId = 0;

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
            this.panelBugs = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAssigned = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBugs.SuspendLayout();
            this.panelAssigned.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBugs
            // 
            this.panelBugs.BackColor = System.Drawing.Color.YellowGreen;
            this.panelBugs.Controls.Add(this.label1);
            this.panelBugs.ForeColor = System.Drawing.SystemColors.Window;
            this.panelBugs.Location = new System.Drawing.Point(2, 1);
            this.panelBugs.Name = "panelBugs";
            this.panelBugs.Size = new System.Drawing.Size(561, 567);
            this.panelBugs.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "All bugs";
            // 
            // panelAssigned
            // 
            this.panelAssigned.BackColor = System.Drawing.Color.Salmon;
            this.panelAssigned.Controls.Add(this.label2);
            this.panelAssigned.ForeColor = System.Drawing.SystemColors.Window;
            this.panelAssigned.Location = new System.Drawing.Point(569, 1);
            this.panelAssigned.Name = "panelAssigned";
            this.panelAssigned.Size = new System.Drawing.Size(508, 567);
            this.panelAssigned.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assigned work to yo";
            // 
            // Bugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 564);
            this.Controls.Add(this.panelAssigned);
            this.Controls.Add(this.panelBugs);
            this.Name = "Bugs";
            this.Text = "Bugs";
            this.Load += new System.EventHandler(this.Bugs_Load);
            this.panelBugs.ResumeLayout(false);
            this.panelBugs.PerformLayout();
            this.panelAssigned.ResumeLayout(false);
            this.panelAssigned.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBugs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAssigned;
        private System.Windows.Forms.Label label2;


        //private void loopPanel(List<Bug> list)
        //{
            
        //     int x = 56;
        //     foreach (var bug in list)
        //     {//56
        //        //int x = 0;
        //        Panel panel = new Panel();
        //        panel.Text = bug.BugId.ToString();
        //        this.panelBugs.Controls.Add(panel);

        //        Label lblProject = new Label();
        //        Label lblClass = new Label();
        //        Label lblMethod = new Label();
        //        PictureBox pictureBox = new PictureBox();

        //        panel.Click += new EventHandler(toolStripClick);

        //        void toolStripClick(object sender, EventArgs e)
        //        {
        //            rowId = Convert.ToInt32(panel.Text);
        //        }

        //        //
        //        //panel
        //        //
        //        panel.BackColor = System.Drawing.Color.DarkOliveGreen;
        //        panel.Controls.Add(lblMethod);
        //        panel.Controls.Add(lblClass);
        //        panel.Controls.Add(lblProject);
        //        panel.Controls.Add(pictureBox);
        //        panel.Location = new System.Drawing.Point(10, x);
        //        x += 105;
        //        panel.Name = panel + bug.BugId.ToString();
        //        panel.Size = new System.Drawing.Size(535, 100);
        //        panel.TabIndex = 1;
        //        //panel.Paint += new System.Windows.Forms.PaintEventHandler(panel_Paint);
        //        panel.SuspendLayout();
        //        //
        //        //lblProject
        //        //
        //        lblProject.AutoSize = true;
        //        lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        lblProject.Location = new System.Drawing.Point(3, 3);
        //        lblProject.Name = lblProject + bug.BugId.ToString();
        //        lblProject.Size = new System.Drawing.Size(50, 16);
        //        lblProject.TabIndex = 1;
        //        lblProject.Text = "Project: "+ bug.ProjectName;

        //        //
        //        //lblClass
        //        //
        //        lblClass.AutoSize = true;
        //        lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        lblClass.Location = new System.Drawing.Point(3, 34);
        //        lblClass.Name = lblClass + bug.BugId.ToString();
        //        lblClass.Size = new System.Drawing.Size(42, 16);
        //        lblClass.TabIndex = 2;
        //        lblClass.Text = "Class: " + bug.ClassName;

        //        //
        //        //lblMethod
        //        //
        //        lblMethod.AutoSize = true;
        //        lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        lblMethod.Location = new System.Drawing.Point(4, 71);
        //        lblMethod.Name = lblMethod + bug.BugId.ToString();
        //        lblMethod.Size = new System.Drawing.Size(53, 16);
        //        lblMethod.TabIndex = 3;
        //        lblMethod.Text = "Method: " + bug.MethodName;

        //        //
        //        //pictureBox
        //        //
        //        pictureBox.Location = new System.Drawing.Point(391, 3);
        //        pictureBox.Name = pictureBox + bug.BugId.ToString();
        //        pictureBox.Size = new System.Drawing.Size(141, 94);
        //        pictureBox.TabIndex = 0;
        //        pictureBox.TabStop = false;
        //        ((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();

        //        pictureBox.Image = new Bitmap(Path.Combine(bug.Images.ImagePath +"/"  , bug.Images.ImageName));
        //        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        //        panel.ResumeLayout(false);
        //        panel.PerformLayout();
        //        ((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
        //    }
        //}

    }
}