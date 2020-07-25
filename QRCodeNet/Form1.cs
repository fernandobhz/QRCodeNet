using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding.Windows.Render;
using Gma.QrCodeNet.Encoding;
using System.IO;
using System.Drawing.Imaging;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QrEncoder encoder = new QrEncoder();
            QrCode qrCode;
            encoder.TryEncode("http://www.fernandobhz.com.br", out qrCode);

            GraphicsRenderer gRenderer = new GraphicsRenderer(
                new FixedModuleSize(10, QuietZoneModules.Four),
                Brushes.Black, Brushes.White);


            FileStream fs = new FileStream("C:\\teste.png", FileMode.Create);
            
            gRenderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, fs);

            fs.Close();

        }
    }
}
