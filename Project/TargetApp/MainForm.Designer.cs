namespace TargetApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonFlexGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonFlexGrid
            // 
            this._buttonFlexGrid.Location = new System.Drawing.Point(13, 13);
            this._buttonFlexGrid.Name = "_buttonFlexGrid";
            this._buttonFlexGrid.Size = new System.Drawing.Size(75, 23);
            this._buttonFlexGrid.TabIndex = 0;
            this._buttonFlexGrid.Text = "FlexGrid";
            this._buttonFlexGrid.UseVisualStyleBackColor = true;
            this._buttonFlexGrid.Click += new System.EventHandler(this.ButtonFlexGridClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._buttonFlexGrid);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonFlexGrid;
    }
}

