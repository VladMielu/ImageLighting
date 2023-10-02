using System.Diagnostics;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ImageBrightnessModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: dotnet run <image_path> <brightness_adjustment>");
                return;
            }

            string imagePath = args[0];

            // Check if the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("The specified image file does not exist.");
                return;
            }

            // Load the image using ImageSharp
            try
            {
                using (var image = Image.Load(imagePath))
                {
                    if (int.TryParse(args[1], out int brightnessAdjustment))
                    {
                        // Modify the image brightness
                        image.Mutate(x => x
                            .Brightness(brightnessAdjustment / 100.0f) // Adjust brightness (-1.0 to 1.0)
                        );

                        // Save the modified image
                        string outputImagePath = "output.jpg"; // You can change the output file name and format
                        image.Save(outputImagePath, new JpegEncoder());
                        Console.WriteLine($"Image saved as {outputImagePath}");

                        // Open the modified image with the default image viewer
                        Process.Start(new ProcessStartInfo(outputImagePath) { UseShellExecute = true });
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
    }
}