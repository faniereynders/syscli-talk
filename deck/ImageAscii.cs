using System.Drawing;
using System.Text;

public class ImageAscii {
    
    private const int _asciiWidth = 80;
		
	private static string[] _asciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", " " };
    public static void Render(string path, int width = _asciiWidth) {
        var image = new Bitmap(path);
        var ascii  = ConvertImageToAsciiArt(image, width);

		Console.WriteLine(ascii);
    }
  
		
		
		//from http://www.c-sharpcorner.com/uploadfile/dheenu27/imagetoasciiconverter03022007164455pm/imagetoasciiconverter.aspx
		private static string ConvertImageToAsciiArt(Bitmap image, int width)
		{
			image = GetReSizedImage(image, width);

			//Convert the resized image into ASCII
			string ascii = ConvertToAscii(image);
			return ascii;
		}



		private static Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth)
		{
			int asciiHeight = 0;
			//Calculate the new Height of the image from its width
			asciiHeight = (int) Math.Ceiling((double) inputBitmap.Height*asciiWidth/inputBitmap.Width);

			//Create a new Bitmap and define its resolution
			Bitmap result = new Bitmap(asciiWidth, asciiHeight);
			Graphics g = Graphics.FromImage((Image) result);
			//The interpolation mode produces high quality images 
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
			g.Dispose();
			return result;
		}

		
		private static string ConvertToAscii(Bitmap image)
		{
			Boolean toggle = false;
			var sb = new StringBuilder();

			for (int h = 0; h < image.Height; h++)
			{
				for (int w = 0; w < image.Width; w++)
				{
					Color pixelColor = image.GetPixel(w, h);
					//Average out the RGB components to find the Gray Color
					int red = (pixelColor.R + pixelColor.G + pixelColor.B)/3;
					int green = (pixelColor.R + pixelColor.G + pixelColor.B)/3;
					int blue = (pixelColor.R + pixelColor.G + pixelColor.B)/3;
					Color grayColor = Color.FromArgb(red, green, blue);

					//Use the toggle flag to minimize height-wise stretch
					if (!toggle)
					{
						int index = (grayColor.R*10)/255;
						sb.Append(_asciiChars[index]);
					}
				}

				if (!toggle)
				{
					sb.Append(Environment.NewLine);
					toggle = true;
				}
				else
				{
					toggle = false;
				}
			}

			return sb.ToString();
		}	
}