using System.Windows.Forms;
using static Lab_4.OpenGL;


namespace Lab_4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void curve_cb_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch(curve_cb.SelectedIndex)
            {
                case 0:
                    renderControl1.SetDrawCurve(Curve.ellipse);
                    parabola_panel.Enabled = false;
                    ellipse_panel.Enabled = true;
                    break;

                case 1:
                    renderControl1.SetDrawCurve(Curve.parabola);
                    parabola_panel.Enabled = true;
                    ellipse_panel.Enabled = false;
                    break;
            }
        }

        private void el_a_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetEllipse((float)el_a_numeric.Value, 
                                      (float)el_b_numeric.Value);
        }

        private void el_b_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetEllipse((float)el_a_numeric.Value,
                                      (float)el_b_numeric.Value);
        }

        private void point1_x_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetPointsLine(new PointLine((float)point1_x_numeric.Value, (float)point1_y_numeric.Value),
                                         new PointLine((float)point2_x_numeric.Value, (float)point2_y_numeric.Value));
        }

        private void point1_y_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetPointsLine(new PointLine((float)point1_x_numeric.Value, (float)point1_y_numeric.Value),
                                         new PointLine((float)point2_x_numeric.Value, (float)point2_y_numeric.Value));
        }

        private void point2_x_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetPointsLine(new PointLine((float)point1_x_numeric.Value, (float)point1_y_numeric.Value),
                                         new PointLine((float)point2_x_numeric.Value, (float)point2_y_numeric.Value));
        }

        private void point2_y_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetPointsLine(new PointLine((float)point1_x_numeric.Value, (float)point1_y_numeric.Value),
                                         new PointLine((float)point2_x_numeric.Value, (float)point2_y_numeric.Value));
        }

        private void par_h_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetParabola((float)par_h_numeric.Value,
                                        (float)par_k_numeric.Value,
                                        (float)par_a_numeric.Value);
        }

        private void par_k_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetParabola((float)par_h_numeric.Value,
                                        (float)par_k_numeric.Value,
                                        (float)par_a_numeric.Value);
        }

        private void par_a_numeric_ValueChanged(object sender, System.EventArgs e)
        {
            renderControl1.SetParabola((float)par_h_numeric.Value,
                                        (float)par_k_numeric.Value,
                                        (float)par_a_numeric.Value);
        }
    }
}
