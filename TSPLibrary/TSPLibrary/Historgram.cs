using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TSPLibrary
{
    public static class Historgram
    {
        public static SortedDictionary<int, int> ToHistogram(this IEnumerable<int> nums)
        {
            var dict = new SortedDictionary<int, int>();
            foreach (var n in nums)
            {
                if (!dict.ContainsKey(n))
                    dict[n] = 1;
                else
                    dict[n] += 1;
            }
            return dict;
        }

        public static Bitmap ToBitmap(this IEnumerable<KeyValuePair<int, int>> histogram, float heightScale = 3.0f, int xLabelOffset = 12, int yLabelOffset = 4)
        {
            var marginTop = 50;
            var marginBottom = 500;
            var marginLeft = 10;

            var max = histogram.Max(kvp => kvp.Key);
            var min = histogram.Min(kvp => kvp.Key);
            var width = 500;
            var maxValue = histogram.Max(kvp => kvp.Value);
            var height = (int)Math.Ceiling(maxValue * heightScale);
            var bitmap = new Bitmap(width + marginLeft, height + marginBottom + marginTop);
            var gfx = Graphics.FromImage(bitmap);
            gfx.Clear(Color.White);
            var blue = new Pen(Color.Blue);
            foreach (var kvp in histogram)
            {
                var x = kvp.Key - min + marginLeft;
                gfx.DrawLine(blue, new PointF(x, (height - kvp.Value * heightScale) + marginTop), new PointF(x, height + marginTop));
                gfx.DrawLine(blue, new PointF(x+1, (height - kvp.Value * heightScale) + marginTop), new PointF(x+1, height + marginTop));
                gfx.DrawLine(blue, new PointF(x+2, (height - kvp.Value * heightScale) + marginTop), new PointF(x+2, height + marginTop));
                gfx.DrawLine(blue, new PointF(x-1, (height - kvp.Value * heightScale) + marginTop), new PointF(x-1, height + marginTop));
                gfx.DrawLine(blue, new PointF(x-2, (height - kvp.Value * heightScale) + marginTop), new PointF(x-2, height + marginTop));
                gfx.DrawLine(blue, new PointF(x, (height - kvp.Value * heightScale) + marginTop), new PointF(x, height + marginTop));
            }

            var font = new Font("Arial", 10);
            StringFormat strF = new StringFormat();
            strF.Alignment = StringAlignment.Far;

            for (var i = (int)((maxValue - yLabelOffset) * heightScale); i >= 0; i -= 21)
            {
                gfx.DrawString(((int)(i / heightScale)).ToString(), font, Brushes.Black, marginLeft - 5, (maxValue * heightScale) - i - 6, strF);
            }

            for (var i = 0; i < width; i++)
            {
                if ((i + xLabelOffset) % 20 == 0)
                {
                    var g = Graphics.FromImage(bitmap);
                    g.TranslateTransform(i - 6 + marginLeft, height + 5 + marginTop);
                    g.RotateTransform(270);
                    g.DrawString((i + min).ToString(), font, Brushes.Black, 0, 0, strF);
                }
            }

            return bitmap;
        }
    }
}
