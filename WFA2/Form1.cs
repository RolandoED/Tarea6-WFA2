using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.Sql;
using System.Data.SqlClient;

namespace WFA2
{
    public partial class Form1 : Form
    {
        //definicion del objeto
        Persona person1 = new Persona();
        Persona person2 = new Persona(2, "Cesar", "Duran");
        PersonaAmiga personA = new PersonaAmiga();
        PersonaHeredada personH = new PersonaHeredada();
        int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Down)
        //    {
        //        button1.Location = new Point(i + 20, i + 20);                
        //        i += 20;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=WFA2;" +
                "Integrated Security=True;";
            DataTable dt = new DataTable();
            sqlquery = "select * from Person";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;
            person1.Initdata();
            //person1.Id = 1;
            //person1.Name = "Ana";
            //person1.LastName = "Bolaños";
            //person1.SetSize(size);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //personH.NewCompleteName()
            label4.Text = personH.CompleteName(); 
            
            
        }

        private void updateGridView() {

            string conexion = "Data Source=(local);" + // en vez de Data Source=LAB210-01 uso (local)
            "Initial Catalog=WFA2;" +
            "Integrated Security=True;";
            string sqlquery;
            sqlquery = "select * from Person";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool resul;
            string message = "";
            var result = MessageBox.Show("Desea guardar la información", "Aviso",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                string conexion = "Data Source=(local);" +
                    "Initial Catalog=WFA2;" +
                    "Integrated Security=True;";
                string sqlquery;
                SqlConnection sqlconn = new SqlConnection(conexion);
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand();

                DataTable dt = new DataTable();

                sqlquery = "insert into Person (" +
                    "Id ," +
                    "Name ," +
                    "LastName," +
                    "Address " +
                    ") values (" +
                        " " + txtCedula.Text + " ," +
                        "'" + txtNombre.Text + "'," +
                        "'" + txtApellido.Text + "'," +
                        "'" + txtDireccion.Text + "')";
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandText = sqlquery;
                sqlcomm.CommandType = CommandType.Text;
                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();

                //Actualiza el GridView
                updateGridView();

                if (txtCedula.Text != "")
                {
                    person1.Id = Convert.ToInt32(txtCedula.Text);
                }
                person1.Name = txtNombre.Text;
                person1.LastName = txtApellido.Text;

                //resul = person1.NewData(person1);
                //if (resul == true)
                //{
                //    message = "Información guardada";
                //}
                //else
                //{
                //    message = "No se guardó la información, los registros están llenos";
                //}
                //result = MessageBox.Show(message, "Aviso",
                //                     MessageBoxButtons.OK,
                //                     MessageBoxIcon.Question);
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                person1.SetSize(Convert.ToInt32(textBox4.Text));
                txtCedula.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtDireccion.Enabled = true;
                textBox4.Enabled = false;
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            string conexion = "Data Source=(local);" +
                  "Initial Catalog=WFA2;" +
                  "Integrated Security=True;";
            string sqlquery;
            //'User ID=UserName;Password=Password;
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand();
            DataTable dt = new DataTable();

            sqlquery =
            "UPDATE Person " +
            "SET Name = '" + txtNombre.Text + "', " +
            "LastName = '" + txtApellido.Text + "', " +
            "Address = '" + txtDireccion.Text + "' " +
            "WHERE Id =  '" + txtCedula.Text + "' ;";

            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandText = sqlquery;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            //Actualiza el GridView
            updateGridView();

            //bool resul = false;
            //string message = "";
            //var result = MessageBox.Show("Desea modificar la información", "Aviso",
            //                     MessageBoxButtons.YesNo,
            //                     MessageBoxIcon.Question);

            //if (result == DialogResult.Yes)
            //{
            //    if (txtCedula.Text != "")
            //    {
            //        person1.Name = txtNombre.Text;
            //        person1.LastName = txtApellido.Text;
            //        resul = person1.ModifyData(person1, Convert.ToInt32(txtCedula.Text));
            //    } 
                               
            //    if (resul == true)
            //    {
            //        message = "Información modificada";
            //    }
            //    else
            //    {
            //        message = "No se modificó la información, por favor digite la cédula correctamente";
            //    }
            //    result = MessageBox.Show(message, "Aviso",
            //                         MessageBoxButtons.OK,
            //                         MessageBoxIcon.Question);
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (!txtCedula.Text.Equals(""))
                {
                    string conexion =
                    "Data Source=(local);" +
                    "Initial Catalog=WFA2;" +
                    "Integrated Security=True;";
                    string sqlquery;                    
                    SqlConnection sqlconn = new SqlConnection(conexion);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    DataTable dt = new DataTable();
                    sqlquery =
                    "DELETE FROM Person WHERE " +
                    "Id = " + txtCedula.Text + ";";

                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.CommandType = CommandType.Text;
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();

                    //Actualiza el GridView
                    updateGridView();
                }
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.GetType());
            }



            //bool resul = false;
            //string message = "";
            //var result = MessageBox.Show("Desea eliminar la información", "Aviso",
            //                     MessageBoxButtons.YesNo,
            //                     MessageBoxIcon.Question);

            //if (result == DialogResult.Yes)
            //{
            //    if (txtCedula.Text != "")
            //    {
            //        resul = person1.DeleteData(Convert.ToInt32(txtCedula.Text));
            //    }
                
            //    if (resul == true)
            //    {
            //        message = "Información eliminada";
            //        txtNombre.Text = "";
            //        txtApellido.Text = "";
            //    }
            //    else
            //    {
            //        message = "No se eliminó la información, por favor digite la cédula correctamente";
            //    }
            //    result = MessageBox.Show(message, "Aviso",
            //                         MessageBoxButtons.OK,
            //                         MessageBoxIcon.Question);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCedula.Text.Length != 0)
                {
                    string sqlquery;
                    string Sqlconexion = "Data Source=(local); " +
                        "Initial Catalog=WFA2;" +
                        "Integrated Security=True;";
                    DataTable dt = new DataTable();
                    sqlquery = "SELECT * from Person where ID " +
                    " LIKE  '" + txtCedula.Text + "%';";
                    //LIKE '19%';
                    SqlConnection sqlconn = new SqlConnection(Sqlconexion);
                    sqlconn.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
                    sqlda.Fill(dt);
                    sqlconn.Close();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    Console.WriteLine("Ingrese codigo a buscar");
                }
            }
            catch (System.Exception s)
            {
                Console.WriteLine(s.Message);
            }
            
            
            //bool resul;
            //string message = "";
            //Persona person1 = new Persona();
            //resul = person1.SeekData(Convert.ToInt32(txtCedula.Text));
            //if (resul == true)
            //{
            //    txtCedula.Text = Convert.ToString(person1.Id);
            //    txtNombre.Text = person1.Name;
            //    txtApellido.Text = person1.LastName;
            //    txtDireccion.Text = person1.Address;
            //}
            //else
            //{
            //    txtCedula.Text = "";
            //    txtNombre.Text = "";
            //    txtApellido.Text = "";
            //    txtDireccion.Text = "";
            //}
            //if (resul == true)
            //{
            //    message = "Información encontrada";
            //}
            //else
            //{
            //    message = "No se encontró información, por favor digite la cédula a buscar";
            //}
            //var result = MessageBox.Show(message, "Aviso",
            //                     MessageBoxButtons.OK,
            //                     MessageBoxIcon.Question);
        }

        private void SeleccionCambiada(object sender, EventArgs e)
        {
            try
            {
            if (dataGridView1.SelectedRows.Count > 0)
            {              
                txtCedula.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            }
            catch (Exception es)
            {
                Console.WriteLine(es.Message);
            }
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        button1.Location = new Point(i+20, i+40);;
        //        i += 20;
        //    }
        //}

        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Down)
        //    {
        //        button1.Location = new Point(i + 20, i + 40); ;
        //        i += 20;
        //    }
        //}       


    }
}
