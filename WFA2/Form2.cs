using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bool resul;            
            Persona person1 = new Persona();
            resul = person1.SeekData(1);
            if (resul == true)
            {
                label2.Text = Convert.ToString(person1.Id);
                label3.Text = person1.Name;
                label4.Text = person1.LastName;
            }
        }
    }
}
