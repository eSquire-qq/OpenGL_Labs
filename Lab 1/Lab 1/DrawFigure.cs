using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_1.OpenGL;

namespace Lab_1
{
    internal class DrawFigure
    {
        private float Xmin, Xmax, Ymin, Ymax;

        private Vertex[] VertexesFigure;
        private float merge;

        public DrawFigure(float Xmin, float Xmax, float Ymin, float Ymax)
        {
            this.Xmin = Xmin;
            this.Xmax = Xmax;
            this.Ymin = Ymin;
            this.Ymax = Ymax;

            VertexesFigure = new Vertex[] {
                new Vertex(Xmin, Ymin),
                new Vertex(Xmin + 1f, Ymin),
                new Vertex(Xmin + 3f, Ymin + 1f),
                new Vertex(Xmin + 3f, Ymin + 4f),
                new Vertex(Xmin + 1f, Ymin + 4f),
                new Vertex(Xmin, Ymin + 3f),
                };

            merge = 6f;
        }

        public void Draw()
        {
            DFigure();
            DPorintsFigure();
        }

        private void DFigure()
        {
            glLineWidth(8);
            glBegin(GL_LINES);

            glVertex2d(VertexesFigure[0].x, VertexesFigure[0].y);
            glVertex2d(VertexesFigure[1].x, VertexesFigure[1].y);

            glVertex2d(VertexesFigure[1].x, VertexesFigure[1].y);
            glVertex2d(VertexesFigure[2].x, VertexesFigure[2].y);

            glVertex2d(VertexesFigure[2].x, VertexesFigure[2].y);
            glVertex2d(VertexesFigure[3].x, VertexesFigure[3].y);

            glVertex2d(VertexesFigure[3].x, VertexesFigure[3].y);
            glVertex2d(VertexesFigure[4].x, VertexesFigure[4].y);

            glVertex2d(VertexesFigure[4].x, VertexesFigure[4].y);
            glVertex2d(VertexesFigure[5].x, VertexesFigure[5].y);

            glVertex2d(VertexesFigure[5].x, VertexesFigure[5].y);
            glVertex2d(VertexesFigure[0].x, VertexesFigure[0].y);

            glEnd();
            glLineWidth(1);
        }

        private void DPorintsFigure()
        {
            glPointSize(16);
            glBegin(GL_POINTS);

            glVertex2d(VertexesFigure[0].x + merge, VertexesFigure[0].y);
            glVertex2d(VertexesFigure[1].x + merge, VertexesFigure[1].y);
            glVertex2d(VertexesFigure[2].x + merge, VertexesFigure[2].y);
            glVertex2d(VertexesFigure[3].x + merge, VertexesFigure[3].y);
            glVertex2d(VertexesFigure[4].x + merge, VertexesFigure[4].y);
            glVertex2d(VertexesFigure[5].x + merge, VertexesFigure[5].y);

            glEnd();
            glPointSize(1);
        }
    }
}
