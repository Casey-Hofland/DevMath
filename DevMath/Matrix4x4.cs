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

        private float[,] matrix;

        public float this[int row, int column]
        {
            get => matrix[row, column];
            set => this[row, column] = value;
        }

        public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            matrix = new float[4,4] 
            {
                { column0[0], column1[0], column2[0], column3[0] },
                { column0[1], column1[1], column2[1], column3[1] },
                { column0[2], column1[2], column2[2], column3[2] },
                { column0[3], column1[3], column2[3], column3[3] },
            };
        }

        public float Determinant =>
               matrix[0, 3] * matrix[1, 2] * matrix[2, 1] * matrix[3, 0] - matrix[0, 2] * matrix[1, 3] * matrix[2, 1] * matrix[3, 0] -
               matrix[0, 3] * matrix[1, 1] * matrix[2, 2] * matrix[3, 0] + matrix[0, 1] * matrix[1, 3] * matrix[2, 2] * matrix[3, 0] +
               matrix[0, 2] * matrix[1, 1] * matrix[2, 3] * matrix[3, 0] - matrix[0, 1] * matrix[1, 2] * matrix[2, 3] * matrix[3, 0] -
               matrix[0, 3] * matrix[1, 2] * matrix[2, 0] * matrix[3, 1] + matrix[0, 2] * matrix[1, 3] * matrix[2, 0] * matrix[3, 1] +
               matrix[0, 3] * matrix[1, 0] * matrix[2, 2] * matrix[3, 1] - matrix[0, 0] * matrix[1, 3] * matrix[2, 2] * matrix[3, 1] -
               matrix[0, 2] * matrix[1, 0] * matrix[2, 3] * matrix[3, 1] + matrix[0, 0] * matrix[1, 2] * matrix[2, 3] * matrix[3, 1] +
               matrix[0, 3] * matrix[1, 1] * matrix[2, 0] * matrix[3, 2] - matrix[0, 1] * matrix[1, 3] * matrix[2, 0] * matrix[3, 2] -
               matrix[0, 3] * matrix[1, 0] * matrix[2, 1] * matrix[3, 2] + matrix[0, 0] * matrix[1, 3] * matrix[2, 1] * matrix[3, 2] +
               matrix[0, 1] * matrix[1, 0] * matrix[2, 3] * matrix[3, 2] - matrix[0, 0] * matrix[1, 1] * matrix[2, 3] * matrix[3, 2] -
               matrix[0, 2] * matrix[1, 1] * matrix[2, 0] * matrix[3, 3] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] * matrix[3, 3] +
               matrix[0, 2] * matrix[1, 0] * matrix[2, 1] * matrix[3, 3] - matrix[0, 0] * matrix[1, 2] * matrix[2, 1] * matrix[3, 3] -
               matrix[0, 1] * matrix[1, 0] * matrix[2, 2] * matrix[3, 3] + matrix[0, 0] * matrix[1, 1] * matrix[2, 2] * matrix[3, 3];

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
            throw new NotImplementedException();
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            throw new NotImplementedException();
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
                matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3],
                matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3],
                matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3],
                matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3]).GetHashCode();
        }

        public override string ToString()
        {
            return 
$@"{matrix[0, 0]}, {matrix[0, 1]}, {matrix[0, 2]}, {matrix[0, 3]}
{matrix[1, 0]}, {matrix[1, 1]}, {matrix[1, 2]}, {matrix[1, 3]}
{matrix[2, 0]}, {matrix[2, 1]}, {matrix[2, 2]}, {matrix[2, 3]}
{matrix[3, 0]}, {matrix[3, 1]}, {matrix[3, 2]}, {matrix[3, 3]}";
        }
    }
}
