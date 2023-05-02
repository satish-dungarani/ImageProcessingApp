using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessingApp.Model
{
    public class ImageProcessingModel
    {
        public int Id { get; set; }
        public string RequestedImageUrl { get; set; }
        public string ProcessedImageUrl { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int IPQuality { get; set; }
        public int ResizeType { get; set; }
        public int ProcessingType { get; set; }
    }
}
