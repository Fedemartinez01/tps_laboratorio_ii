
namespace Formularios
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verClientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Cargando = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verClientesToolStripMenuItem,
            this.verClientesToolStripMenuItem1,
            this.bajaClienteToolStripMenuItem,
            this.cerrarAppToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(383, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verClientesToolStripMenuItem
            // 
            this.verClientesToolStripMenuItem.Name = "verClientesToolStripMenuItem";
            this.verClientesToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.verClientesToolStripMenuItem.Text = "Nuevo cliente";
            this.verClientesToolStripMenuItem.Click += new System.EventHandler(this.verClientesToolStripMenuItem_Click);
            // 
            // verClientesToolStripMenuItem1
            // 
            this.verClientesToolStripMenuItem1.Name = "verClientesToolStripMenuItem1";
            this.verClientesToolStripMenuItem1.Size = new System.Drawing.Size(92, 20);
            this.verClientesToolStripMenuItem1.Text = "Ver clientes";
            this.verClientesToolStripMenuItem1.Click += new System.EventHandler(this.verClientesToolStripMenuItem1_Click);
            // 
            // bajaClienteToolStripMenuItem
            // 
            this.bajaClienteToolStripMenuItem.Name = "bajaClienteToolStripMenuItem";
            this.bajaClienteToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.bajaClienteToolStripMenuItem.Text = "Baja cliente";
            this.bajaClienteToolStripMenuItem.Click += new System.EventHandler(this.bajaClienteToolStripMenuItem_Click);
            // 
            // cerrarAppToolStripMenuItem
            // 
            this.cerrarAppToolStripMenuItem.Name = "cerrarAppToolStripMenuItem";
            this.cerrarAppToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarAppToolStripMenuItem.Text = "Cerrar app";
            this.cerrarAppToolStripMenuItem.Click += new System.EventHandler(this.cerrarAppToolStripMenuItem_Click);
            // 
            // lbl_Cargando
            // 
            this.lbl_Cargando.AutoSize = true;
            this.lbl_Cargando.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Cargando.Location = new System.Drawing.Point(33, 116);
            this.lbl_Cargando.Name = "lbl_Cargando";
            this.lbl_Cargando.Size = new System.Drawing.Size(0, 24);
            this.lbl_Cargando.TabIndex = 3;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Cargando);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Central de datos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verClientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bajaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarAppToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Cargando;
    }
}