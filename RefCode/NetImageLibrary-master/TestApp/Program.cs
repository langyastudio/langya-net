using System;
using System.Drawing;
using Kaliko.ImageLibrary;
using Kaliko.ImageLibrary.Filters;

namespace TestApp {
    using Kaliko.ImageLibrary.Scaling;

    class Program {
        static void Main(string[] args) 
        {
            KalikoImage image = new KalikoImage("M.jpg");
            // image.BackgroundColor = Color.Red;

            image.ApplyFilter(new ChromaKeyFilter(Color.Green, 50, 0.5f, 0.5f));
            image.SaveJpg("chromaKey.jpg", 100);

            //image.Scale(new FitScaling(100, 100)).SaveJpg("thumbnail-fit.jpg", 90);

            //image.Scale(new CropScaling(100,100)).SaveJpg("thumbnail-crop.jpg", 90);

            //image.Scale(new PadScaling(100, 100)).SaveJpg("thumbnail-pad.jpg", 90);
           
            //KalikoImage sharpimg = image.Scale(new CropScaling(100, 100));
            //sharpimg.ApplyFilter(new UnsharpMaskFilter(1.2f, 0.3f, 1));
            //sharpimg.SaveJpg("thumbnail-unsharpened.jpg", 90);

            //sharpimg.ApplyFilter(new DesaturationFilter());
            //sharpimg.SaveJpg("thumbnail-gray.jpg", 90);

            //sharpimg.ApplyFilter(new ContrastFilter(30));
            //sharpimg.SaveJpg("thumbnail-contrast.jpg", 90);

        }
    }
}
