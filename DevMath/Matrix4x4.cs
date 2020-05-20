using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DevMath
{
    public struct Matrix4x4
    {
        public static readonly Matrix4x4 zero = new Matrix4x4();
        public static readonly Matrix4x4 identity = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1));

        private Vector4 column0;
        private Vector4 column1;
        private Vector4 column2;
        private Vector4 column3;

        public float this[int row, int column]
        {
            get => column == 0 ? column0[row] : column == 1 ? column1[row] : column == 2 ? column2[row] : column == 3 ? column3[row] : throw new IndexOutOfRangeException();
            set
            {
                if(column == 0)
                {
                    column0[row] = value;
                    return;
                }
                else if(column == 1)
                {
                    column1[row] = value;
                    return;
                }
                else if(column == 2)
                {
                    column2[row] = value;
                    return;
                }
                else if(column == 3)
                {
                    column3[row] = value;
                    return;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            this.column0 = column0;
            this.column1 = column1;
            this.column2 = column2;
            this.column3 = column3;
        }

        public float Determinant =>
               this[0, 3] * this[1, 2] * this[2, 1] * this[3, 0] - this[0, 2] * this[1, 3] * this[2, 1] * this[3, 0] -
               this[0, 3] * this[1, 1] * this[2, 2] * this[3, 0] + this[0, 1] * this[1, 3] * this[2, 2] * this[3, 0] +
               this[0, 2] * this[1, 1] * this[2, 3] * this[3, 0] - this[0, 1] * this[1, 2] * this[2, 3] * this[3, 0] -
               this[0, 3] * this[1, 2] * this[2, 0] * this[3, 1] + this[0, 2] * this[1, 3] * this[2, 0] * this[3, 1] +
               this[0, 3] * this[1, 0] * this[2, 2] * this[3, 1] - this[0, 0] * this[1, 3] * this[2, 2] * this[3, 1] -
               this[0, 2] * this[1, 0] * this[2, 3] * this[3, 1] + this[0, 0] * this[1, 2] * this[2, 3] * this[3, 1] +
               this[0, 3] * this[1, 1] * this[2, 0] * this[3, 2] - this[0, 1] * this[1, 3] * this[2, 0] * this[3, 2] -
               this[0, 3] * this[1, 0] * this[2, 1] * this[3, 2] + this[0, 0] * this[1, 3] * this[2, 1] * this[3, 2] +
               this[0, 1] * this[1, 0] * this[2, 3] * this[3, 2] - this[0, 0] * this[1, 1] * this[2, 3] * this[3, 2] -
               this[0, 2] * this[1, 1] * this[2, 0] * this[3, 3] + this[0, 1] * this[1, 2] * this[2, 0] * this[3, 3] +
               this[0, 2] * this[1, 0] * this[2, 1] * this[3, 3] - this[0, 0] * this[1, 2] * this[2, 1] * this[3, 3] -
               this[0, 1] * this[1, 0] * this[2, 2] * this[3, 3] + this[0, 0] * this[1, 1] * this[2, 2] * this[3, 3];

        public Matrix4x4 Inverse
        {
            get { throw new NotImplementedException(); }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            //Er zijn 2 manieren om deze te berekenen
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            throw new NotImplementedException();
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            Matrix4x4 matrix4X4 = zero;

            for(int row = 0; row < 4; row++)
            {
                for(int column = 0; column < 4; column++)
                {
                    for(int x = 0; x < 4; x++)
                    {
                        matrix4X4[row, column] += lhs[row, x] * rhs[x, column];
                    }
                }
            }

            return matrix4X4;
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            Vector4 vector = Vector4.zero;

            for(int row = 0; row < 4; row++)
            {
                for(int column = 0; column < 4; column++)
                {
                    vector[row] += lhs[row, column] * rhs[column];
                }
            }

            return vector;
        }

        public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs) => !(lhs == rhs);
        public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs) =>
            lhs[0, 0] == rhs[0, 0] && lhs[0, 1] == rhs[0, 1] && lhs[0, 2] == rhs[0, 2] && lhs[0, 3] == rhs[0, 3] &&
            lhs[1, 0] == rhs[1, 0] && lhs[1, 1] == rhs[1, 1] && lhs[1, 2] == rhs[1, 2] && lhs[1, 3] == rhs[1, 3] &&
            lhs[2, 0] == rhs[2, 0] && lhs[2, 1] == rhs[2, 1] && lhs[2, 2] == rhs[2, 2] && lhs[2, 3] == rhs[2, 3] &&
            lhs[3, 0] == rhs[3, 0] && lhs[3, 1] == rhs[3, 1] && lhs[3, 2] == rhs[3, 2] && lhs[3, 3] == rhs[3, 3];

        public override bool Equals(object obj)
        {
            return obj is Matrix4x4 matrix4X4 && matrix4X4 == this;
        }

        public override int GetHashCode()
        {
            return (
                this[0, 0], this[0, 1], this[0, 2], this[0, 3],
                this[1, 0], this[1, 1], this[1, 2], this[1, 3],
                this[2, 0], this[2, 1], this[2, 2], this[2, 3],
                this[3, 0], this[3, 1], this[3, 2], this[3, 3]).GetHashCode();
        }

        public override string ToString()
        {
            return 
$@"{this[0, 0]}, {this[0, 1]}, {this[0, 2]}, {this[0, 3]}
{this[1, 0]}, {this[1, 1]}, {this[1, 2]}, {this[1, 3]}
{this[2, 0]}, {this[2, 1]}, {this[2, 2]}, {this[2, 3]}
{this[3, 0]}, {this[3, 1]}, {this[3, 2]}, {this[3, 3]}";
        }
    }
}
