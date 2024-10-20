namespace fractales3
{
    public partial class Fractales : Form
    {
        private readonly int PANEL_WIDTH;
        private readonly int PANEL_HEIGHT;

        Graphics graphics;

        // The first point of a pattern must always be (0,0)
        Point[] pattern = new Point[4] { 
            new Point(0, 0), 
            new Point(10, 100), 
            new Point(100, 10), 
            new Point(200, 50) 
        };

        Pen pen = new Pen(Color.Red,3);


        public Fractales()
        {
            InitializeComponent();
            graphics = drawingPanel.CreateGraphics();
            
            // Initialize pannel dimensions
            PANEL_WIDTH = drawingPanel.ClientSize.Width;        
            PANEL_HEIGHT = drawingPanel.ClientSize.Height;
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            graphics.DrawLines(pen, VerticalFlip(MoveTo(pattern, new Point (200,340))));
            graphics.DrawLines(pen, VerticalFlip(MoveTo(pattern, new Point (20,110))));
        }

        private Point[] VerticalFlip(Point[] points)
        {
            return points.Select(p => new Point(p.X, PANEL_HEIGHT-p.Y)).ToArray();
        }

        private Point[] MoveTo(Point[] points, Point basePoint)
        {
            return points.Select(p => new Point(basePoint.X + p.X, basePoint.Y + p.Y)).ToArray();
        }
    }
}
