using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;

namespace GUI
{
    public partial class f_value : DevExpress.XtraEditors.XtraForm
    {
        public f_value()
        {
            InitializeComponent();
        }

        private void calcEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9)
                calcEdit1.ShowPopup();



          
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }


            //if (((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)) && e.Modifiers != Keys.Shift)
            //{
            //    readyToOperate = true;
            //}
             if (e.KeyCode == Keys.OemMinus ||
                        e.KeyCode == Keys.Oemplus ||
                       (e.KeyCode == Keys.OemQuestion && e.Modifiers != Keys.Shift) ||
                       (e.KeyCode == Keys.D8 && e.Modifiers == Keys.Shift) ||
                        e.KeyCode == Keys.Divide ||
                        e.KeyCode == Keys.Multiply ||
                        e.KeyCode == Keys.Subtract ||
                        e.KeyCode == Keys.Add)
               
                    calcEdit1.ShowPopup();

                   
               
        }

        private bool readyToOperate = false;
        private bool edited = false;

        private void f_value_Load(object sender, EventArgs e)
        {
            calcEdit1.Text = Biencucbo.value.ToString();
            calcEdit1.ShowPopup();
            CenterToScreen();

        }

        private void calcEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Biencucbo.value = double.Parse(calcEdit1.Text);
                Close();

            }
        }
    }
}