using Aspose;
using Gpx;
using Aspose.Gis.Rendering;
using Aspose.Gis;
namespace Rando
{
    public partial class Rando : Form
    {
        public List<GpxTrackPoint> trackPoints;
        public Rando()
        {
            InitializeComponent();
            using (GpxReader reader = new GpxReader(File.Open("loechegemmi.gpx", FileMode.Open)))
            {

                while (reader.Read())
                {
                    switch (reader.ObjectType)
                    {
                        case GpxObjectType.Metadata:
                            //writer.WriteMetadata(reader.Metadata);
                            break;
                        case GpxObjectType.WayPoint:
                            //writer.WriteWayPoint(reader.WayPoint);
                            break;
                        case GpxObjectType.Route:
                            //writer.WriteRoute(reader.Route);
                            break;
                        case GpxObjectType.Track:
                            //writer.WriteTrack(reader.Track);
                            //reader.Read(track);
                            Console.WriteLine(reader.Track);
                            trackPoints = reader.Track.Segments[0].TrackPoints.ToList();
                            break;
                    }
                }
            }

        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {




            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            //Point[] points = new Point[4] { new Point(30,50), new Point(50,10), new Point(80,50), new Point(111,400) };
            //this.CreateGraphics().DrawLines(myPen, points);

            Point[] pointss = trackPoints.Select(tp => new Point((int)Math.Round((tp.Longitude) * 10000), this.ClientRectangle.Height - (int)Math.Round((tp.Latitude) * 10000))).ToArray();
            this.CreateGraphics().DrawLines(myPen, pointss);

        }
    }
    class Trackpoint
    {
        private double _latitude;
        private double _longitude;
        private double _elevation;
    }
}
