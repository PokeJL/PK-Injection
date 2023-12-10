using PK3_RAM_Injection.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PK3_RAM_Injection.View
{
    public partial class PK3_RAM_Hex_Editor : Form
    {
        readonly Data_Conversion hex;
        public PK3_RAM_Hex_Editor()
        {
            InitializeComponent();
            hex = new();
            pidLBL.Text = PidString();
            idLBL.Text = TwoBitHex(idNUD1.Value, idNUD2.Value);
            sidLBL.Text = TwoBitHex(sidNUD1.Value, sidNUD2.Value);
        }

        private string PidString()
        {
            return Convert.ToInt32(Math.Round(pidNUD4.Value, 0)).ToString("X").PadLeft(2, '0') +
                Convert.ToInt32(Math.Round(pidNUD3.Value, 0)).ToString("X").PadLeft(2, '0') +
                Convert.ToInt32(Math.Round(pidNUD2.Value, 0)).ToString("X").PadLeft(2, '0') +
                Convert.ToInt32(Math.Round(pidNUD1.Value, 0)).ToString("X").PadLeft(2, '0');
        }

        private string TwoBitHex(decimal x, decimal y)
        {
            return (Convert.ToInt32(
                Convert.ToInt32(Math.Round(y, 0)).ToString("X").PadLeft(2, '0') +
                Convert.ToInt32(Math.Round(x, 0)).ToString("X").PadLeft(2, '0'), 16)).ToString().PadLeft(5, '0');
        }

        private void pidNUD1_ValueChanged(object sender, EventArgs e)
        {
            pidLBL.Text = PidString();
        }

        private void pidNUD2_ValueChanged(object sender, EventArgs e)
        {
            pidLBL.Text = PidString();
        }

        private void pidNUD3_ValueChanged(object sender, EventArgs e)
        {
            pidLBL.Text = PidString();
        }

        private void pidNUD4_ValueChanged(object sender, EventArgs e)
        {
            pidLBL.Text = PidString();
        }

        private void idNUD1_ValueChanged(object sender, EventArgs e)
        {
            idLBL.Text = TwoBitHex(idNUD1.Value, idNUD2.Value);
        }

        private void idNUD2_ValueChanged(object sender, EventArgs e)
        {
            idLBL.Text = TwoBitHex(idNUD1.Value, idNUD2.Value);
        }

        private void sidNUD1_ValueChanged(object sender, EventArgs e)
        {
            sidLBL.Text = TwoBitHex(sidNUD1.Value, sidNUD2.Value);
        }

        private void sidNUD2_ValueChanged(object sender, EventArgs e)
        {
            sidLBL.Text = TwoBitHex(sidNUD1.Value, sidNUD2.Value);
        }
    }
}
