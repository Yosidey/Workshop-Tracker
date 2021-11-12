
namespace Automotriz
{
    partial class Vehiculos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgVehiculo = new System.Windows.Forms.DataGridView();
            this.btnEditarVehiculo = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbModelo = new System.Windows.Forms.RadioButton();
            this.rbMarca = new System.Windows.Forms.RadioButton();
            this.rbNombreCliente = new System.Windows.Forms.RadioButton();
            this.rbIdCliente = new System.Windows.Forms.RadioButton();
            this.rbPlaca = new System.Windows.Forms.RadioButton();
            this.rbIdVehiculo = new System.Windows.Forms.RadioButton();
            this.txtBusquedad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVehiculo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 36F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vehiculos";
            // 
            // dvgVehiculo
            // 
            this.dvgVehiculo.AllowUserToAddRows = false;
            this.dvgVehiculo.AllowUserToDeleteRows = false;
            this.dvgVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgVehiculo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgVehiculo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dvgVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgVehiculo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgVehiculo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgVehiculo.ColumnHeadersHeight = 30;
            this.dvgVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvgVehiculo.EnableHeadersVisualStyles = false;
            this.dvgVehiculo.GridColor = System.Drawing.Color.White;
            this.dvgVehiculo.Location = new System.Drawing.Point(32, 143);
            this.dvgVehiculo.Name = "dvgVehiculo";
            this.dvgVehiculo.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgVehiculo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgVehiculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgVehiculo.Size = new System.Drawing.Size(1017, 452);
            this.dvgVehiculo.TabIndex = 5;
            this.dvgVehiculo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgVehiculo_CellClick);
            // 
            // btnEditarVehiculo
            // 
            this.btnEditarVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnEditarVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarVehiculo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarVehiculo.ForeColor = System.Drawing.Color.White;
            this.btnEditarVehiculo.Location = new System.Drawing.Point(844, 76);
            this.btnEditarVehiculo.Name = "btnEditarVehiculo";
            this.btnEditarVehiculo.Size = new System.Drawing.Size(205, 43);
            this.btnEditarVehiculo.TabIndex = 19;
            this.btnEditarVehiculo.Tag = "";
            this.btnEditarVehiculo.Text = "Editar Vehiculo";
            this.btnEditarVehiculo.UseVisualStyleBackColor = false;
            this.btnEditarVehiculo.Click += new System.EventHandler(this.btnEditarVehiculo_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(844, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(205, 43);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Tag = "";
            this.btnNuevo.Text = "Nuevo Vehiculo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.rbModelo);
            this.groupBox1.Controls.Add(this.rbMarca);
            this.groupBox1.Controls.Add(this.rbNombreCliente);
            this.groupBox1.Controls.Add(this.rbIdCliente);
            this.groupBox1.Controls.Add(this.rbPlaca);
            this.groupBox1.Controls.Add(this.rbIdVehiculo);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(609, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 99);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones busquedad";
            // 
            // rbModelo
            // 
            this.rbModelo.AutoSize = true;
            this.rbModelo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModelo.Location = new System.Drawing.Point(117, 63);
            this.rbModelo.Name = "rbModelo";
            this.rbModelo.Size = new System.Drawing.Size(80, 27);
            this.rbModelo.TabIndex = 5;
            this.rbModelo.TabStop = true;
            this.rbModelo.Text = "Modelo";
            this.rbModelo.UseVisualStyleBackColor = true;
            this.rbModelo.CheckedChanged += new System.EventHandler(this.rbIdVehiculo_CheckedChanged);
            // 
            // rbMarca
            // 
            this.rbMarca.AutoSize = true;
            this.rbMarca.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMarca.Location = new System.Drawing.Point(6, 63);
            this.rbMarca.Name = "rbMarca";
            this.rbMarca.Size = new System.Drawing.Size(72, 27);
            this.rbMarca.TabIndex = 4;
            this.rbMarca.TabStop = true;
            this.rbMarca.Text = "Marca";
            this.rbMarca.UseVisualStyleBackColor = true;
            this.rbMarca.CheckedChanged += new System.EventHandler(this.rbIdVehiculo_CheckedChanged);
            // 
            // rbNombreCliente
            // 
            this.rbNombreCliente.AutoSize = true;
            this.rbNombreCliente.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNombreCliente.Location = new System.Drawing.Point(117, 42);
            this.rbNombreCliente.Name = "rbNombreCliente";
            this.rbNombreCliente.Size = new System.Drawing.Size(94, 27);
            this.rbNombreCliente.TabIndex = 3;
            this.rbNombreCliente.TabStop = true;
            this.rbNombreCliente.Text = "N. Cliente";
            this.rbNombreCliente.UseVisualStyleBackColor = true;
            this.rbNombreCliente.CheckedChanged += new System.EventHandler(this.rbIdVehiculo_CheckedChanged);
            // 
            // rbIdCliente
            // 
            this.rbIdCliente.AutoSize = true;
            this.rbIdCliente.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIdCliente.Location = new System.Drawing.Point(117, 19);
            this.rbIdCliente.Name = "rbIdCliente";
            this.rbIdCliente.Size = new System.Drawing.Size(91, 27);
            this.rbIdCliente.TabIndex = 2;
            this.rbIdCliente.TabStop = true;
            this.rbIdCliente.Text = "Id Cliente";
            this.rbIdCliente.UseVisualStyleBackColor = true;
            this.rbIdCliente.CheckedChanged += new System.EventHandler(this.rbIdVehiculo_CheckedChanged);
            // 
            // rbPlaca
            // 
            this.rbPlaca.AutoSize = true;
            this.rbPlaca.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPlaca.Location = new System.Drawing.Point(6, 42);
            this.rbPlaca.Name = "rbPlaca";
            this.rbPlaca.Size = new System.Drawing.Size(67, 27);
            this.rbPlaca.TabIndex = 1;
            this.rbPlaca.TabStop = true;
            this.rbPlaca.Text = "Placa";
            this.rbPlaca.UseVisualStyleBackColor = true;
            this.rbPlaca.CheckedChanged += new System.EventHandler(this.rbIdVehiculo_CheckedChanged);
            // 
            // rbIdVehiculo
            // 
            this.rbIdVehiculo.AutoSize = true;
            this.rbIdVehiculo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIdVehiculo.Location = new System.Drawing.Point(6, 19);
            this.rbIdVehiculo.Name = "rbIdVehiculo";
            this.rbIdVehiculo.Size = new System.Drawing.Size(105, 27);
            this.rbIdVehiculo.TabIndex = 0;
            this.rbIdVehiculo.TabStop = true;
            this.rbIdVehiculo.Text = "Id Vehiculo";
            this.rbIdVehiculo.UseVisualStyleBackColor = true;
            this.rbIdVehiculo.CheckedChanged += new System.EventHandler(this.rbIdVehiculo_CheckedChanged);
            // 
            // txtBusquedad
            // 
            this.txtBusquedad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusquedad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusquedad.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusquedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.txtBusquedad.Location = new System.Drawing.Point(406, 81);
            this.txtBusquedad.Name = "txtBusquedad";
            this.txtBusquedad.Size = new System.Drawing.Size(178, 29);
            this.txtBusquedad.TabIndex = 61;
            this.txtBusquedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusquedad.TextChanged += new System.EventHandler(this.txtBusquedad_TextChanged);
            // 
            // Vehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Automotriz.Properties.Resources.O1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 612);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBusquedad);
            this.Controls.Add(this.btnEditarVehiculo);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dvgVehiculo);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Vehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehiculos";
            this.Load += new System.EventHandler(this.Vehiculos_Load);
            this.Click += new System.EventHandler(this.Vehiculos_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dvgVehiculo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dvgVehiculo;
        private System.Windows.Forms.Button btnEditarVehiculo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNombreCliente;
        private System.Windows.Forms.RadioButton rbIdCliente;
        private System.Windows.Forms.RadioButton rbPlaca;
        private System.Windows.Forms.RadioButton rbIdVehiculo;
        public System.Windows.Forms.TextBox txtBusquedad;
        private System.Windows.Forms.RadioButton rbModelo;
        private System.Windows.Forms.RadioButton rbMarca;
    }
}