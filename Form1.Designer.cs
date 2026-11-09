namespace AgendaTelefonica;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblNombres = new Label();
        txtNombres = new TextBox();
        lblApellidos = new Label();
        txtApellidos = new TextBox();
        lblCorreo = new Label();
        txtCorreo = new TextBox();
        lblCategoria = new Label();
        cmbCategoria = new ComboBox();
        lblTelefono = new Label();
        txtTelefono = new TextBox();
        lblTipo = new Label();
        cmbTipo = new ComboBox();
        chkFavorito = new CheckBox();
        btnAgregar = new Button();
        btnTelefono = new Button();
        btnEliminar = new Button();
        btnAutores = new Button();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        tabla = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)tabla).BeginInit();
        SuspendLayout();
        // 
        // lblNombres
        // 
        lblNombres.AutoSize = true;
        lblNombres.Location = new Point(31, 43);
        lblNombres.Margin = new Padding(5, 0, 5, 0);
        lblNombres.Name = "lblNombres";
        lblNombres.Size = new Size(97, 28);
        lblNombres.TabIndex = 0;
        lblNombres.Text = "Nombres:";
        // 
        // txtNombres
        // 
        txtNombres.Location = new Point(173, 37);
        txtNombres.Margin = new Padding(5, 6, 5, 6);
        txtNombres.Name = "txtNombres";
        txtNombres.Size = new Size(296, 34);
        txtNombres.TabIndex = 1;
        // 
        // lblApellidos
        // 
        lblApellidos.AutoSize = true;
        lblApellidos.Location = new Point(31, 108);
        lblApellidos.Margin = new Padding(5, 0, 5, 0);
        lblApellidos.Name = "lblApellidos";
        lblApellidos.Size = new Size(98, 28);
        lblApellidos.TabIndex = 2;
        lblApellidos.Text = "Apellidos:";
        // 
        // txtApellidos
        // 
        txtApellidos.Location = new Point(173, 103);
        txtApellidos.Margin = new Padding(5, 6, 5, 6);
        txtApellidos.Name = "txtApellidos";
        txtApellidos.Size = new Size(296, 34);
        txtApellidos.TabIndex = 3;
        // 
        // lblCorreo
        // 
        lblCorreo.AutoSize = true;
        lblCorreo.Location = new Point(31, 174);
        lblCorreo.Margin = new Padding(5, 0, 5, 0);
        lblCorreo.Name = "lblCorreo";
        lblCorreo.Size = new Size(76, 28);
        lblCorreo.TabIndex = 4;
        lblCorreo.Text = "Correo:";
        // 
        // txtCorreo
        // 
        txtCorreo.Location = new Point(173, 168);
        txtCorreo.Margin = new Padding(5, 6, 5, 6);
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(296, 34);
        txtCorreo.TabIndex = 5;
        // 
        // lblCategoria
        // 
        lblCategoria.AutoSize = true;
        lblCategoria.Location = new Point(31, 239);
        lblCategoria.Margin = new Padding(5, 0, 5, 0);
        lblCategoria.Name = "lblCategoria";
        lblCategoria.Size = new Size(101, 28);
        lblCategoria.TabIndex = 6;
        lblCategoria.Text = "Categoría:";
        // 
        // cmbCategoria
        // 
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategoria.FormattingEnabled = true;
        cmbCategoria.Location = new Point(173, 233);
        cmbCategoria.Margin = new Padding(5, 6, 5, 6);
        cmbCategoria.Name = "cmbCategoria";
        cmbCategoria.Size = new Size(296, 36);
        cmbCategoria.TabIndex = 7;
        // 
        // lblTelefono
        // 
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(566, 43);
        lblTelefono.Margin = new Padding(5, 0, 5, 0);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(90, 28);
        lblTelefono.TabIndex = 8;
        lblTelefono.Text = "Teléfono:";
        // 
        // txtTelefono
        // 
        txtTelefono.Location = new Point(707, 37);
        txtTelefono.Margin = new Padding(5, 6, 5, 6);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(296, 34);
        txtTelefono.TabIndex = 9;
        // 
        // lblTipo
        // 
        lblTipo.AutoSize = true;
        lblTipo.Location = new Point(566, 108);
        lblTipo.Margin = new Padding(5, 0, 5, 0);
        lblTipo.Name = "lblTipo";
        lblTipo.Size = new Size(55, 28);
        lblTipo.TabIndex = 10;
        lblTipo.Text = "Tipo:";
        // 
        // cmbTipo
        // 
        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipo.FormattingEnabled = true;
        cmbTipo.Items.AddRange(new object[] { "Móvil", "Casa", "Trabajo" });
        cmbTipo.Location = new Point(707, 103);
        cmbTipo.Margin = new Padding(5, 6, 5, 6);
        cmbTipo.Name = "cmbTipo";
        cmbTipo.Size = new Size(296, 36);
        cmbTipo.TabIndex = 11;
        // 
        // chkFavorito
        // 
        chkFavorito.AutoSize = true;
        chkFavorito.Location = new Point(707, 168);
        chkFavorito.Margin = new Padding(5, 6, 5, 6);
        chkFavorito.Name = "chkFavorito";
        chkFavorito.Size = new Size(106, 32);
        chkFavorito.TabIndex = 12;
        chkFavorito.Text = "Favorito";
        chkFavorito.UseVisualStyleBackColor = true;
        // 
        // btnAgregar
        // 
        btnAgregar.Location = new Point(31, 308);
        btnAgregar.Margin = new Padding(5, 6, 5, 6);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(236, 56);
        btnAgregar.TabIndex = 13;
        btnAgregar.Text = "Agregar contacto";
        btnAgregar.UseVisualStyleBackColor = true;
        // 
        // btnTelefono
        // 
        btnTelefono.Location = new Point(283, 308);
        btnTelefono.Margin = new Padding(5, 6, 5, 6);
        btnTelefono.Name = "btnTelefono";
        btnTelefono.Size = new Size(330, 56);
        btnTelefono.TabIndex = 14;
        btnTelefono.Text = "Agregar teléfono al seleccionado";
        btnTelefono.UseVisualStyleBackColor = true;
        // 
        // btnEliminar
        // 
        btnEliminar.Location = new Point(629, 308);
        btnEliminar.Margin = new Padding(5, 6, 5, 6);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(236, 56);
        btnEliminar.TabIndex = 15;
        btnEliminar.Text = "Eliminar contacto";
        btnEliminar.UseVisualStyleBackColor = true;
        // 
        // btnAutores
        // 
        btnAutores.Location = new Point(880, 308);
        btnAutores.Margin = new Padding(5, 6, 5, 6);
        btnAutores.Name = "btnAutores";
        btnAutores.Size = new Size(189, 56);
        btnAutores.TabIndex = 16;
        btnAutores.Text = "Autores";
        btnAutores.UseVisualStyleBackColor = true;
        // 
        // lblBuscar
        // 
        lblBuscar.AutoSize = true;
        lblBuscar.Location = new Point(31, 407);
        lblBuscar.Margin = new Padding(5, 0, 5, 0);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(72, 28);
        lblBuscar.TabIndex = 17;
        lblBuscar.Text = "Buscar:";
        // 
        // txtBuscar
        // 
        txtBuscar.Location = new Point(173, 401);
        txtBuscar.Margin = new Padding(5, 6, 5, 6);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(296, 34);
        txtBuscar.TabIndex = 18;
        // 
        // tabla
        // 
        tabla.AllowUserToAddRows = false;
        tabla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tabla.Location = new Point(31, 281);
        tabla.Margin = new Padding(5, 6, 5, 6);
        tabla.Name = "tabla";
        tabla.ReadOnly = true;
        tabla.RowHeadersWidth = 51;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabla.Size = new Size(1037, 467);
        tabla.TabIndex = 19;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(11F, 28F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 971);
        Controls.Add(tabla);
        Controls.Add(txtBuscar);
        Controls.Add(lblBuscar);
        Controls.Add(btnAutores);
        Controls.Add(btnEliminar);
        Controls.Add(btnTelefono);
        Controls.Add(btnAgregar);
        Controls.Add(chkFavorito);
        Controls.Add(cmbTipo);
        Controls.Add(lblTipo);
        Controls.Add(txtTelefono);
        Controls.Add(lblTelefono);
        Controls.Add(cmbCategoria);
        Controls.Add(lblCategoria);
        Controls.Add(txtCorreo);
        Controls.Add(lblCorreo);
        Controls.Add(txtApellidos);
        Controls.Add(lblApellidos);
        Controls.Add(txtNombres);
        Controls.Add(lblNombres);
        Margin = new Padding(5, 6, 5, 6);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Proyecto de cátedra - Agenda Telefónica";
        ((System.ComponentModel.ISupportInitialize)tabla).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }

    private System.Windows.Forms.Label lblNombres;
    private System.Windows.Forms.TextBox txtNombres;
    private System.Windows.Forms.Label lblApellidos;
    private System.Windows.Forms.TextBox txtApellidos;
    private System.Windows.Forms.Label lblCorreo;
    private System.Windows.Forms.TextBox txtCorreo;
    private System.Windows.Forms.Label lblCategoria;
    private System.Windows.Forms.ComboBox cmbCategoria;
    private System.Windows.Forms.Label lblTelefono;
    private System.Windows.Forms.TextBox txtTelefono;
    private System.Windows.Forms.Label lblTipo;
    private System.Windows.Forms.ComboBox cmbTipo;
    private System.Windows.Forms.CheckBox chkFavorito;
    private System.Windows.Forms.Button btnAgregar;
    private System.Windows.Forms.Button btnTelefono;
    private System.Windows.Forms.Button btnEliminar;
    private System.Windows.Forms.Button btnAutores;
    private System.Windows.Forms.Label lblBuscar;
    private System.Windows.Forms.TextBox txtBuscar;
    private System.Windows.Forms.DataGridView tabla;
}
