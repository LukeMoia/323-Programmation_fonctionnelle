using Aspose.Gis;
using Aspose.Gis.Geometries;

namespace Rando
{
    public partial class Rando : Form
    {
        public Rando()
        {
            InitializeComponent();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            List<PointLuke> Points = new List<PointLuke>();
            using (var layer = Drivers.Gpx.OpenLayer(".\\gpx\\Running.gpx"))
            {
                foreach (var feature in layer)
                {
                    if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
                    {
                        // read segment
                        var lines = (MultiLineString)feature.Geometry;
                        for (int i = 0; i < lines.Count; i++)
                        {
                            richTextBox1.Text += $"....segment({i})......\n";
                            var segment = (LineString)lines[i];

                            // read points in segment
                            for (int j = 0; j < segment.Count; j++)
                            {
                                // look for attribute
                                string attributeName = $"name__{i}__{j}";
                                if (layer.Attributes.Contains(attributeName) && feature.IsValueSet(attributeName))
                                {
                                    // print a point and attribute
                                    var value = feature.GetValue<string>(attributeName);
                                   richTextBox1.Text += $"\n{segment[j].AsText()} - {attributeName}: {value}\n";
                                }
                                else
                                {
                                    /*if (j % 5 == 0)
                                    {*/
                                    PointLuke point = new PointLuke();
                                    // print a point only
                                    point.X = segment[j].X;
                                    point.Y = segment[j].Y;
                                    point.Z = segment[j].Z;
                                        Points.Add(point);
                                   /* }*/
                                }
                            }
                        }
                        richTextBox1.Text += "\n..........\n";
                    }
                }
            }

            var z = Points.Aggregate(new PointLuke(), (p,next) => {
                return new PointLuke() { 
                    X = next.X, 
                    Y = next.Y, 
                    Z = next.Z, 
                    distance = (Math.Sqrt(Math.Pow(next.X-p.X,2)+Math.Pow(next.Y-p.Y,2)+Math.Pow(next.Z-p.Z,2))* 3.8) + p.distance};
            }
            ,e=>e.distance);
            richTextBox1.Text += $"dist:{z}";

            /*Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            System.Drawing.Point[] points = new System.Drawing.Point[4] { new System.Drawing.Point(30, 50), new System.Drawing.Point(50, 10), new System.Drawing.Point(80, 50), new System.Drawing.Point(111, 400) };
            this.CreateGraphics().DrawLines(myPen, points);*/
        }
        class PointLuke
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            public double distance { get; set; }
        }
    }
}
