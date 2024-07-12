namespace Presentacion
{
    partial class FrmEquipoDeLimpieza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEquipoDeLimpieza));
            this.TimeFin = new System.Windows.Forms.DateTimePicker();
            this.TimeInicio = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textComentario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textTareas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textRecursos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataEquipoLimpieza = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cbCodigoEmpleado = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipoLimpieza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeFin
            // 
            this.TimeFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeFin.Location = new System.Drawing.Point(77, 231);
            this.TimeFin.Name = "TimeFin";
            this.TimeFin.Size = new System.Drawing.Size(185, 20);
            this.TimeFin.TabIndex = 181;
            // 
            // TimeInicio
            // 
            this.TimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeInicio.Location = new System.Drawing.Point(98, 205);
            this.TimeInicio.Name = "TimeInicio";
            this.TimeInicio.Size = new System.Drawing.Size(164, 20);
            this.TimeInicio.TabIndex = 180;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(10, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 17);
            this.label13.TabIndex = 179;
            this.label13.Text = "Hora_Fin:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(10, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 17);
            this.label12.TabIndex = 178;
            this.label12.Text = "Hora_Inicio:";
            // 
            // textComentario
            // 
            this.textComentario.Location = new System.Drawing.Point(98, 175);
            this.textComentario.Name = "textComentario";
            this.textComentario.Size = new System.Drawing.Size(164, 20);
            this.textComentario.TabIndex = 177;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(10, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 176;
            this.label11.Text = "Comentarios:";
            // 
            // textTareas
            // 
            this.textTareas.Location = new System.Drawing.Point(131, 149);
            this.textTareas.Name = "textTareas";
            this.textTareas.Size = new System.Drawing.Size(131, 20);
            this.textTareas.TabIndex = 175;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(10, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 174;
            this.label10.Text = "Tareas Realizadas:";
            // 
            // textRecursos
            // 
            this.textRecursos.Location = new System.Drawing.Point(142, 116);
            this.textRecursos.Name = "textRecursos";
            this.textRecursos.Size = new System.Drawing.Size(120, 20);
            this.textRecursos.TabIndex = 173;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(10, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 17);
            this.label9.TabIndex = 172;
            this.label9.Text = "Recursos Empleados:";
            // 
            // textCantidad
            // 
            this.textCantidad.Location = new System.Drawing.Point(142, 84);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(120, 20);
            this.textCantidad.TabIndex = 171;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 170;
            this.label3.Text = "Cantidad Auxiliares:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(253, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(300, 23);
            this.label8.TabIndex = 169;
            this.label8.Text = "Equipo de Servicio de Limpieza";
            // 
            // dataEquipoLimpieza
            // 
            this.dataEquipoLimpieza.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(11)))), ((int)(((byte)(50)))));
            this.dataEquipoLimpieza.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataEquipoLimpieza.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataEquipoLimpieza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEquipoLimpieza.EnableHeadersVisualStyles = false;
            this.dataEquipoLimpieza.Location = new System.Drawing.Point(268, 50);
            this.dataEquipoLimpieza.Name = "dataEquipoLimpieza";
            this.dataEquipoLimpieza.Size = new System.Drawing.Size(532, 330);
            this.dataEquipoLimpieza.TabIndex = 168;
            this.dataEquipoLimpieza.SelectionChanged += new System.EventHandler(this.dataEquipoLimpieza_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 166;
            this.label2.Text = "Codigo EmpleadoTalma:";
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(9)))), ((int)(((byte)(127)))));
            this.btnModificar.Location = new System.Drawing.Point(485, 397);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 23);
            this.btnModificar.TabIndex = 206;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(9)))), ((int)(((byte)(127)))));
            this.btnAgregar.Location = new System.Drawing.Point(289, 397);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(108, 23);
            this.btnAgregar.TabIndex = 205;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(9)))), ((int)(((byte)(127)))));
            this.btnEliminar.Location = new System.Drawing.Point(675, 397);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 23);
            this.btnEliminar.TabIndex = 204;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cbCodigoEmpleado
            // 
            this.cbCodigoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodigoEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCodigoEmpleado.ForeColor = System.Drawing.Color.Black;
            this.cbCodigoEmpleado.FormattingEnabled = true;
            this.cbCodigoEmpleado.Location = new System.Drawing.Point(159, 52);
            this.cbCodigoEmpleado.Name = "cbCodigoEmpleado";
            this.cbCodigoEmpleado.Size = new System.Drawing.Size(103, 21);
            this.cbCodigoEmpleado.TabIndex = 207;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 208;
            this.pictureBox1.TabStop = false;
            // 
            // FrmEquipoDeLimpieza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(5)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(805, 445);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbCodigoEmpleado);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.TimeFin);
            this.Controls.Add(this.TimeInicio);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textComentario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textTareas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textRecursos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataEquipoLimpieza);
            this.Controls.Add(this.label2);
            this.Name = "FrmEquipoDeLimpieza";
            this.Text = "FrmEquipoDeLimpieza";
            this.Load += new System.EventHandler(this.FrmEquipoDeLimpieza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataEquipoLimpieza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker TimeFin;
        private System.Windows.Forms.DateTimePicker TimeInicio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textComentario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textTareas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textRecursos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataEquipoLimpieza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cbCodigoEmpleado;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}