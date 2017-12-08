using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
   public class ImageReadyEventArgs:EventArgs
    {
        public BitmapImage Image { get; set; }
    }
}
