namespace AgendaTelefonica;

// Formulario con los autores del proyecto
public class FormAutores : Form
{
    public FormAutores()
    {
        Text = "Autores del proyecto";
        Size = new Size(360, 320);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Label titulo = new Label();
        titulo.Text = "Autores del proyecto";
        titulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        titulo.Location = new Point(20, 20);
        titulo.AutoSize = true;
        Controls.Add(titulo);

        Label curso = new Label();
        curso.Text = "Programación I - SP 226";
        curso.Location = new Point(22, 55);
        curso.AutoSize = true;
        Controls.Add(curso);

        // TODO: cambiar por los nombres reales de los integrantes
        string[] integrantes = { "Integrante 1", "Integrante 2", "Integrante 3", "Integrante 4" };

        int y = 95;
        foreach (string nombre in integrantes)
        {
            Label etiqueta = new Label();
            etiqueta.Text = nombre;
            etiqueta.Location = new Point(22, y);
            etiqueta.AutoSize = true;
            Controls.Add(etiqueta);
            y += 28;
        }

        Button btnCerrar = new Button();
        btnCerrar.Text = "Cerrar";
        btnCerrar.Location = new Point(120, 235);
        btnCerrar.Size = new Size(100, 30);
        btnCerrar.Click += (s, e) => Close();
        Controls.Add(btnCerrar);
    }
}
