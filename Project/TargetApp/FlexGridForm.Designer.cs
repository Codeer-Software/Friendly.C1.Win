namespace TargetApp
{
    partial class FlexGridForm
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
            this._grid = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.ColumnInfo = "4,1,0,0,0,90,Columns:2{Style:\"DataType:System.Boolean;TextAlign:LeftCenter;ImageA" +
    "lign:CenterCenter;\";}\t3{Style:\"ComboList:\"\"a|b|c\"\";\";}\t";
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.ExtendLastCol = true;
            this._grid.Location = new System.Drawing.Point(0, 0);
            this._grid.Name = "_grid";
            this._grid.Rows.DefaultSize = 18;
            this._grid.Size = new System.Drawing.Size(343, 261);
            this._grid.TabIndex = 0;
            // 
            // FlexGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 261);
            this.Controls.Add(this._grid);
            this.Name = "FlexGridForm";
            this.Text = "FlexGridForm";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid _grid;
    }
}