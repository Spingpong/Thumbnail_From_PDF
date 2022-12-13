using Aspose.Pdf;
using Aspose.Pdf.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //String fileName = new string("c:\\rm\\Image.jpg");
            //Image image = Image.FromFile(fileName);
            //Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            //thumb.Save(Path.ChangeExtension(fileName, "thumb"));

            Bitmap myBitmap = new Bitmap("c:\\rm\\Image.jpg");
            Bitmap myThumbnail = new Bitmap(myBitmap, new Size(45, 59));
            myThumbnail.Save("c:\\rm\\Image2.jpg");

            
            // Open document
            //Document pdfDocument = new Document("c:\\rm\\powershell-fr.pdf");
            Document pdfDocument = new Document("c:\\rm\\powershell-fr");

            int pageIndex = 1;

            // Get page of desired index from collection
            var page = pdfDocument.Pages[pageIndex];

            // Create stream for image file
            using (FileStream imageStream = new FileStream("Thumbanils_" + page.Number + ".jpg", FileMode.Create))
            {
                // Create Resolution object
                Resolution resolution = new Resolution(300);

                // Create an instance of JpegDevice and set height, width, resolution, and quality of image
                JpegDevice jpegDevice = new JpegDevice(45, 59, resolution, 100);
                
                // Convert a particular page and save the image to stream
                jpegDevice.Process(page, imageStream);

                // Close stream
                imageStream.Close();
                MessageBox.Show("kammelna", "ka");
                Application.Exit();

            }

        }
    }

}
