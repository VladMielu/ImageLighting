The application is a command-line tool for modifying the brightness of an image file. It is written in C# and is designed to be cross-platform, allowing you to use it on different operating systems supported by .NET 5 or later.

Functionality:

The user provides two command-line arguments:
The path to the image file they want to modify.
A brightness adjustment value (100 being the actual brigtness of the image).
Key Features:

The application checks if the specified image file exists and provides appropriate error messages if it doesn't.
It uses the ImageSharp library for image loading, processing, and saving, ensuring cross-platform compatibility.
After processing the image, it saves the modified version as "output.jpg" (you can change the output file name and format).
It opens the modified image with the default image viewer associated with the image file type so that you can view the changes immediately.
Usage:

The user runs the application from the command line, providing the image file path and brightness adjustment value as arguments.
```
dotnet build
dotnet run -- <image path> <brightness adjustment value>
```
The application then processes the image, saves the modified version, and opens it for viewing.
Overall, the application simplifies the task of adjusting the brightness of images, making it easier to enhance or tone down the lighting in photos without the need for a dedicated image editing software.
