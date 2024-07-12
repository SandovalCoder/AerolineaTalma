namespace Presentacion
{
    partial class FrmVuelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVuelo));
            this.dateTimeSalida = new System.Windows.Forms.DateTimePicker();
            this.dateTimeLLegada = new System.Windows.Forms.DateTimePicker();
            this.cbCodigoAvion = new System.Windows.Forms.ComboBox();
            this.textOrigen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.textDestino = new System.Windows.Forms.TextBox();
            this.textIdentificadorVuelo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataVuelo = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbEstados = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataVuelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeSalida
            // 
            this.dateTimeSalida.Location = new System.Drawing.Point(90, 176);
            this.dateTimeSalida.Name = "dateTimeSalida";
            this.dateTimeSalida.Size = new System.Drawing.Size(174, 20);
            this.dateTimeSalida.TabIndex = 193;
            // 
            // dateTimeLLegada
            // 
            this.dateTimeLLegada.Location = new System.Drawing.Point(106, 135);
            this.dateTimeLLegada.Name = "dateTimeLLegada";
            this.dateTimeLLegada.Size = new System.Drawing.Size(158, 20);
            this.dateTimeLLegada.TabIndex = 192;
            // 
            // cbCodigoAvion
            // 
            this.cbCodigoAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodigoAvion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCodigoAvion.ForeColor = System.Drawing.Color.Black;
            this.cbCodigoAvion.FormattingEnabled = true;
            this.cbCodigoAvion.Location = new System.Drawing.Point(126, 101);
            this.cbCodigoAvion.Name = "cbCodigoAvion";
            this.cbCodigoAvion.Size = new System.Drawing.Size(138, 21);
            this.cbCodigoAvion.TabIndex = 190;
            // 
            // textOrigen
            // 
            this.textOrigen.Location = new System.Drawing.Point(69, 246);
            this.textOrigen.Name = "textOrigen";
            this.textOrigen.Size = new System.Drawing.Size(195, 20);
            this.textOrigen.TabIndex = 189;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 188;
            this.label9.Text = "Origen:";
            // 
            // textCantidad
            // 
            this.textCantidad.Location = new System.Drawing.Point(156, 311);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(108, 20);
            this.textCantidad.TabIndex = 187;
            // 
            // textDestino
            // 
            this.textDestino.Location = new System.Drawing.Point(69, 276);
            this.textDestino.Name = "textDestino";
            this.textDestino.Size = new System.Drawing.Size(195, 20);
            this.textDestino.TabIndex = 186;
            // 
            // textIdentificadorVuelo
            // 
            this.textIdentificadorVuelo.Location = new System.Drawing.Point(156, 62);
            this.textIdentificadorVuelo.Name = "textIdentificadorVuelo";
            this.textIdentificadorVuelo.Size = new System.Drawing.Size(108, 20);
            this.textIdentificadorVuelo.TabIndex = 185;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 17);
            this.label7.TabIndex = 184;
            this.label7.Text = "Cantidad de Equipaje:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 183;
            this.label6.Text = "Destino:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 182;
            this.label5.Text = "Estado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 181;
            this.label4.Text = "Hora Salida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 180;
            this.label3.Text = "Hora Llegada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 179;
            this.label2.Text = "Codigo de  Avion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 178;
            this.label1.Text = "Identificador de Vuelo:";
            // 
            // dataVuelo
            // 
            this.dataVuelo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(11)))), ((int)(((byte)(50)))));
            this.dataVuelo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataVuelo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataVuelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVuelo.EnableHeadersVisualStyles = false;
            this.dataVuelo.Location = new System.Drawing.Point(285, 62);
            this.dataVuelo.Name = "dataVuelo";
            this.dataVuelo.Size = new System.Drawing.Size(525, 313);
            this.dataVuelo.TabIndex = 194;
            this.dataVuelo.SelectionChanged += new System.EventHandler(this.dataVuelo_SelectionChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(9)))), ((int)(((byte)(127)))));
            this.btnModificar.Location = new System.Drawing.Point(516, 388);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 23);
            this.btnModificar.TabIndex = 203;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(9)))), ((int)(((byte)(127)))));
            this.btnAgregar.Location = new System.Drawing.Point(329, 388);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 23);
            this.btnAgregar.TabIndex = 202;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(9)))), ((int)(((byte)(127)))));
            this.btnEliminar.Location = new System.Drawing.Point(677, 388);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 23);
            this.btnEliminar.TabIndex = 201;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(357, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 23);
            this.label8.TabIndex = 204;
            this.label8.Text = "Vuelo";
            // 
            // cbEstados
            // 
            this.cbEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstados.FormattingEnabled = true;
            this.cbEstados.Items.AddRange(new object[] {
            "Avion en vuelo",
            "Avion aterrizando",
            "Avion en puesto de embarque",
            "Avion despegando "});
            this.cbEstados.Location = new System.Drawing.Point(69, 212);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(195, 21);
            this.cbEstados.TabIndex = 206;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 348);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 207;
            this.pictureBox1.TabStop = false;
            // 
            // FrmVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(5)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(822, 469);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbEstados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dataVuelo);
            this.Controls.Add(this.dateTimeSalida);
            this.Controls.Add(this.dateTimeLLegada);
            this.Controls.Add(this.cbCodigoAvion);
            this.Controls.Add(this.textOrigen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.textDestino);
            this.Controls.Add(this.textIdentificadorVuelo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmVuelo";
            this.Text = "FrmVuelo";
            this.Load += new System.EventHandler(this.FrmVuelo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataVuelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeSalida;
        private System.Windows.Forms.ComboBox cbCodigoAvion;
        private System.Windows.Forms.TextBox textOrigen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.TextBox textDestino;
        private System.Windows.Forms.TextBox textIdentificadorVuelo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataVuelo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimeLLegada;
        private System.Windows.Forms.ComboBox cbEstados;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}