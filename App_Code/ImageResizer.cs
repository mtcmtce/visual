using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

public class ImageResizer
{
    public int MaxX { get; set; }

    public int MaxY { get; set; }

    public bool TrimImage { get; set; }

    public ImageFormat SaveFormat { get; set; }

    public ImageResizer()
    {
        MaxX = MaxY = 650;
        TrimImage = false;
        SaveFormat = ImageFormat.Jpeg;
    }

    public bool Resize(string source, string target)
    {
        using (Image src = Image.FromFile(source, true))
        {
            
            if (src != null)
            {
                int origX, origY, newX, newY;
                int trimX = 0, trimY = 0;

            
                newX = origX = src.Width;
                newY = origY = src.Height;

            
                if (origX > MaxX || origY > MaxY)
                {
            
                    if (TrimImage)
                    {
                      
                        double factor = Math.Max((double)MaxX / (double)origX,
                            (double)MaxY / (double)origY);
                        newX = (int)Math.Ceiling((double)origX * factor);
                        newY = (int)Math.Ceiling((double)origY * factor);
                        trimX = newX - MaxX;
                        trimY = newY - MaxY;
                    }
                    else
                    {
                      
                        double factor = Math.Min((double)MaxX / (double)origX,
                            (double)MaxY / (double)origY);
                        newX = (int)Math.Ceiling((double)origX * factor);
                        newY = (int)Math.Ceiling((double)origY * factor);
                    }
                }

                
                using (Image dest = new Bitmap(newX - trimX, newY - trimY))
                {
                    Graphics graph = Graphics.FromImage(dest);
                    graph.InterpolationMode =
                        System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graph.DrawImage(src, -(trimX / 2), -(trimY / 2), newX, newY);
                    dest.Save(target, SaveFormat);
        
                    return true;
                }
            }
        }
        
        return false;
    }
}
