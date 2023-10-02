using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageBrightnessModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Image Brightness Modifier");

            // Prompt the user for the image file path
            Console.Write("Enter the path of the image file: ");
            string imagePath = Console.ReadLine();

            // Load the image
            try
            {
                using (Bitmap originalImage = new Bitmap(imagePath))
                {
                    Console.WriteLine("Enter brightness adjustment value (negative for darker, positive for lighter): ");
                    if (int.TryParse(Console.ReadLine(), out int brightnessAdjustment))
                    {
                        // Modify the image brightness
                        Bitmap adjustedImage = AdjustBrightness(originalImage, brightnessAdjustment);

                        // Save the modified image
                        string outputImagePath = "output.jpg"; // You can change the output file name and format
                        adjustedImage.Save(outputImagePath, ImageFormat.Jpeg);
                        Console.WriteLine($"Image saved as {outputImagePath}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid brightness adjustment value.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static Bitmap AdjustBrightness(Bitmap image, int brightnessAdjustment)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int newRed = Math.Max(0, Math.Min(255, pixel.R + brightnessAdjustment));
                    int newGreen = Math.Max(0, Math.Min(255, pixel.G + brightnessAdjustment));
                    int newBlue = Math.Max(0, Math.Min(255, pixel.B + brightnessAdjustment));

                    Color newPixel = Color.FromArgb(pixel.A, newRed, newGreen, newBlue);
                    adjustedImage.SetPixel(x, y, newPixel);
                }
            }

            return adjustedImage;
        }
    }
}