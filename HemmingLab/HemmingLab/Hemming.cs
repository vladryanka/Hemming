using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemmingLab
{
    class Hemming
    {
        const float k1 = 0.1f;
        const float Un = 10;

        internal Graph Graph
        {
            get => default;
            set
            {
            }
        }

        public int hemmingAlg(Graph graph) {
            float[] v1 = { -0.5f, 0.5f, -0.5f, -0.5f, 0.5f, -0.5f, -0.5f, 0.5f, -0.5f };
            float[] v2 = { 0.5f, 0.5f, 0.5f, 0.5f, -0.5f, 0.5f, 0.5f, -0.5f, 0.5f };
            float[] v3 = { 0.5f, -0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, -0.5f, 0.5f };
            float[] v4 = { 0.5f, 0.5f, 0.5f, 0.5f, -0.5f, -0.5f, 0.5f, -0.5f, -0.5f };
            float[] v5 = { -0.5f, -0.5f, -0.5f, -0.5f, 0.5f, -0.5f, -0.5f, -0.5f, -0.5f };
            const int countV = 5;
            float b = 4.5f;
            const float e = 0.2f;
            const int matrSize = 9;
            int[] S = new int[matrSize];
            float[] Uinp = new float[countV];
            float[] Uout = new float[countV];
            
            float[][] W = {
                new float[countV]{ v1[0], v2[0], v3[0], v4[0], v5[0] },
                new float[countV]{ v1[1], v2[1], v3[1], v4[1], v5[1] },
                new float[countV]{ v1[2], v2[2], v3[2], v4[2], v5[2] },
                new float[countV]{ v1[3], v2[3], v3[3], v4[3], v5[3] },
                new float[countV]{ v1[4], v2[4], v3[4], v4[4], v5[4] },
                new float[countV]{ v1[5], v2[5], v3[5], v4[5], v5[5] },
                new float[countV]{ v1[6], v2[6], v3[6], v4[6], v5[6] },
                new float[countV]{ v1[7], v2[7], v3[7], v4[7], v5[7] },
                new float[countV]{ v1[8], v2[8], v3[8], v4[8], v5[8] }
            };
            List<List<int>> currentGraph = graph.getEdges();
            int k = 0;
            for (int i = 0; i < graph.getVertex(); i++)
            {
                int j = -1;
                while (j++ != graph.getVertex() - 1)
                {
                    S[k] = currentGraph[i][j];
                    k++;
                }
            }

            for (int i = 0; i < countV; i++){
                Uinp[i] = b;
                for (int j = 0; j < matrSize; j++) {
                    Uinp[i] += W[j][i] * S[j];
                }
            }

            for (int i = 0; i < countV; i++) {
                Uout[i] = g(Uinp[i]);
                
            }

            float[][] A = { 
                new float[countV] { 0,0,0,0,0},
                new float[countV] { 0,0,0,0,0},
                new float[countV] { 0,0,0,0,0},
                new float[countV] { 0,0,0,0,0},
                new float[countV] { 0,0,0,0,0}
            };
            for (int i = 0; i < countV; i ++) {
                A[0][i] = Uout[i];
            }
            
            for (int i = 1; i < countV; i++)
            {
                for (int j = 0; j < countV; j++)
                {
                    A[i][j] = Uout[j];
                    float eps = 0; 
                    for (int m = 0; m < countV; m++) {
                        if (m != j)
                            eps += Uout[m];
                    }
                    eps = -e * eps;
                    A[i][j] += eps;
                    A[i][j] = g(A[i][j]);
                }
                for (int m = 0; m < countV; m++)
                {
                    Uout[m] = A[i][m];
                }
            }

            int index = -1;
            for (int i = 0; i < countV; i++)
            {
                for (int j = 0; j < countV; j++)
                {
                    if (A[i][j] != 0) index++;
                }
                if (index == 0)
                {
                    for (int j = 0; j < countV; j++)
                    {
                        if (A[i][j] != 0) {
                            index = j;
                            break;
                        }
                    }
                }
                else index = -1;
            }

            return index;
        }
        float g(float Uinp) {
            float Uout;
            if (Uinp <= 0)
            {
                Uout = 0;
            }
            else if (Uinp >= 0 && Uinp <= Un)
            {
                Uout = k1 * Uinp;
            }
            else Uout = Un;
            return Uout;
        }
    }
}
