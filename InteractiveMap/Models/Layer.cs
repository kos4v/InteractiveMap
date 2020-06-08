using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteractiveMap.Models
{
    public class Layer
    {
        [Key]
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Color { get; set; }
        public string BackgroundColor { get; set; }
        public List<LayerDot> LayerDots { get; set; }
        public Map Map { get; set; }
        public int MapId { get; set; }
        public List<Description> Descriptions { get; set; }
    }
    public class LayerDot
    {
        [Key]
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Layer Layer { get; set; }
        public int LayerId { get; set; }
        public Map Map { get; set; }
        public int MapId { get; set; }

        public LayerDot(
            double X, 
            double Y,
            int LayerId,
            int SerialNumber)
        {
            this.X = X;
            this.Y = Y;
            this.LayerId = LayerId;
            this.SerialNumber = SerialNumber;
        }

        public LayerDot[] CreateLayerDotsRange(double[] X, double[] Y, int LayerId,int StartFromSerialNumber)
        {
            int XYLength;
            if (X.Length < Y.Length)
                XYLength = X.Length;
            else
                XYLength = Y.Length;

            List<LayerDot> LayersDotsList = new List<LayerDot>();
            for (int i = StartFromSerialNumber; i < StartFromSerialNumber+XYLength; i++)
            {
                LayersDotsList.Add(new LayerDot(X[i], Y[i], LayerId, i));
            }
            return LayersDotsList.ToArray();
        }
    }
}
