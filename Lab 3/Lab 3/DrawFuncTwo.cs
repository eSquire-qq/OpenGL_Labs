using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab_3.OpenGL;

namespace Lab_3
{
    internal class DrawFuncTwo : Draw
    {
        private int points;
        private bool isAutoY;

        private NumericUpDown Ymin_numeric;
        private NumericUpDown Ymax_numeric;

        public DrawFuncTwo(WindowSize windowSize, DrawConfig drawConfig, int points, bool isAutoY, NumericUpDown Ymin_numeric, NumericUpDown Ymax_numeric)
            : base(windowSize, drawConfig)
        {
            this.points = points;
            this.isAutoY = isAutoY;

            this.Ymin_numeric = Ymin_numeric;
            this.Ymax_numeric = Ymax_numeric;
        }

        private float Func(float x) =>
            MathF.Sin(3 * x) + MathF.Log10(MathF.Cos(x) + 1);

        public void DrawFunction()
        {
            float h = config.width / (points - 1);
            float breakdown = 1f / (points * config.width);

            float x = 0;
            float y = 0;

            float _x = 0;
            float _y = 0;

            float _Ymin = float.MaxValue;
            float _Ymax = float.MinValue;

            glLineWidth(2);

            glBegin(GL_LINES);
            glColor3d(65f / 255f, 105f / 255f, 225f / 255f);

            for (int i = 0; i < points; i++)
            {
                if (i > 0)
                {
                    _x = x;
                    _y = y;
                }

                x = windowSize.Xmin + i * h;
                y = Func(x);

                if (MathF.Cos(x) + 1 <= breakdown)
                {
                    continue;
                }
                else if (MathF.Cos(_x) + 1 <= breakdown)
                {
                    DrawLinesBreakdown(_x);

                    continue;
                }

                if (!isAutoY)
                {
                    if (y > windowSize.Ymax)
                    {
                        y = windowSize.Ymax;
                        continue;
                    }
                    else if (y < windowSize.Ymin)
                    {
                        y = windowSize.Ymin;
                        continue;
                    }
                }

                if (i > 0)
                {
                    glVertex2d(_x, _y);
                    glVertex2d(x, y);
                }

                if (y < _Ymin && y < 0)
                {
                    _Ymin = y;
                }
                if (y > _Ymax && y > 0)
                {
                    _Ymax = y;
                }
            }

            glEnd();

            _Ymin = MathF.Round(_Ymin, 1);
            _Ymax = MathF.Round(_Ymax, 1);

            if (_Ymin < -100) _Ymin = -99.0f + config.step;
            if (_Ymax > 100) _Ymax = 99.0f - config.step;

            if (isAutoY)
            {
                Ymin_numeric.Value = (decimal)(_Ymin);
                Ymax_numeric.Value = (decimal)(_Ymax);
            }
        }

        private void DrawLinesBreakdown(float x)
        {
            // end draw function
            glEnd();

            glLineStipple(10, 21845);
            glEnable(GL_LINE_STIPPLE);
            glLineWidth(3);

            glBegin(GL_LINES);
            glColor3d(255f / 255f, 128f / 255f, 0f / 255f);

            glVertex2d(x, windowSize.Ymin);
            glVertex2d(x, windowSize.Ymax);

            glEnd();

            glDisable(GL_LINE_STIPPLE);
            glLineWidth(2);

            glBegin(GL_LINES);
            glColor3d(65f / 255f, 105f / 255f, 225f / 255f);
        }
    }
}
