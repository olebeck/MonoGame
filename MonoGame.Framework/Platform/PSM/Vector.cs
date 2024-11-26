using System;


namespace System.Numerics
{
    public struct Vector4
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
        }

        public float LengthSquared()
        {
            return X * X + Y * Y + Z * Z + W * W;
        }

        public static Vector4 Add(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }

        public static Vector4 Subtract(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        public static Vector4 Multiply(Vector4 vector, float scalar)
        {
            return new Vector4(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
        }

        public static Vector4 Divide(Vector4 vector, float scalar)
        {
            return new Vector4(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar);
        }

        public static float Dot(Vector4 left, Vector4 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        public static Vector4 operator +(Vector4 left, Vector4 right) {
            return Add(left, right);
        }

        public static Vector4 operator -(Vector4 left, Vector4 right) {
            return Subtract(left, right);
        }

        public static Vector4 operator *(Vector4 vector, float scalar) {
            return Multiply(vector, scalar);
        }

        public static Vector4 operator /(Vector4 vector, float scalar) {
            return Divide(vector, scalar);
        }

        public override string ToString()
        {
            return "({X}, {Y}, {Z}, {W})";
        }
    }

    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public float LengthSquared()
        {
            return X * X + Y * Y + Z * Z;
        }

        public static Vector3 Add(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 Subtract(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3 Multiply(Vector3 vector, float scalar)
        {
            return new Vector3(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }

        public static Vector3 Divide(Vector3 vector, float scalar)
        {
            return new Vector3(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
        }

        public static float Dot(Vector3 left, Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.Y * b.Z - a.Z * b.Y, // c_x
                a.Z * b.X - a.X * b.Z, // c_y
                a.X * b.Y - a.Y * b.X  // c_z
            );
        }

        public float Magnitude {
            get {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static Vector3 Normalize(Vector3 v)
        {
            float magnitude = v.Magnitude;

            if (magnitude == 0)
                throw new InvalidOperationException("Cannot normalize a zero-length vector.");

            return new Vector3(v.X / magnitude, v.Y / magnitude, v.Z / magnitude);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right) {
            return Add(left, right);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right) {
            return Subtract(left, right);
        }

        public static Vector3 operator *(Vector3 vector, float scalar) {
            return Multiply(vector, scalar);
        }

        public static Vector3 operator /(Vector3 vector, float scalar) {
            return Divide(vector, scalar);
        }

        public override string ToString()
        {
            return "({X}, {Y}, {Z})";
        }
    }

    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public float LengthSquared()
        {
            return X * X + Y * Y;
        }

        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2 Multiply(Vector2 vector, float scalar)
        {
            return new Vector2(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector2 Divide(Vector2 vector, float scalar)
        {
            return new Vector2(vector.X / scalar, vector.Y / scalar);
        }

        public static float Dot(Vector2 left, Vector2 right)
        {
            return left.X * right.X + left.Y * right.Y;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right) {
            return Add(left, right);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right) {
            return Subtract(left, right);
        }

        public static Vector2 operator *(Vector2 vector, float scalar) {
            return Multiply(vector, scalar);
        }

        public static Vector2 operator /(Vector2 vector, float scalar) {
            return Divide(vector, scalar);
        }

        public override string ToString()
        {
            return "({X}, {Y})";
        }
    }
    public struct Quaternion
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        // Constructor to initialize quaternion from x, y, z, w components
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        // Returns the length (magnitude) of the quaternion
        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
        }

        // Returns the squared length of the quaternion
        public float LengthSquared()
        {
            return X * X + Y * Y + Z * Z + W * W;
        }

        // Normalizes the quaternion (scales it to unit length)
        public Quaternion Normalize()
        {
            float length = Length();
            return new Quaternion(X / length, Y / length, Z / length, W / length);
        }

        // Dot product of two quaternions
        public static float Dot(Quaternion a, Quaternion b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
        }

        // Multiply two quaternions
        public static Quaternion Multiply(Quaternion a, Quaternion b)
        {
            return new Quaternion(
                a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y,
                a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
                a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W,
                a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z
            );
        }

        // Conjugate of a quaternion (negate the vector part)
        public Quaternion Conjugate()
        {
            return new Quaternion(-X, -Y, -Z, W);
        }

        // Inverse of a quaternion (assuming quaternion is normalized)
        public Quaternion Inverse()
        {
            float lengthSquared = LengthSquared();
            if (lengthSquared > 0f)
            {
                Quaternion conjugate = Conjugate();
                return new Quaternion(conjugate.X / lengthSquared, conjugate.Y / lengthSquared, conjugate.Z / lengthSquared, conjugate.W / lengthSquared);
            }
            return new Quaternion(0, 0, 0, 1); // Return identity if quaternion length is 0
        }

        // Operator overload for quaternion multiplication
        public static Quaternion operator *(Quaternion a, Quaternion b) {
            return Multiply(a, b);
        }

        // Override ToString to output quaternion in a readable format
        public override string ToString()
        {
            return "({X}, {Y}, {Z}, {W})";
        }
    }

    public struct Matrix4x4
    {
        // 4x4 matrix represented as an array of 16 elements (row-major order)
        public float M11, M12, M13, M14;
        public float M21, M22, M23, M24;
        public float M31, M32, M33, M34;
        public float M41, M42, M43, M44;

        // Constructor to initialize matrix with individual values
        public Matrix4x4(
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            M11 = m11; M12 = m12; M13 = m13; M14 = m14;
            M21 = m21; M22 = m22; M23 = m23; M24 = m24;
            M31 = m31; M32 = m32; M33 = m33; M34 = m34;
            M41 = m41; M42 = m42; M43 = m43; M44 = m44;
        }

        // Identity matrix (useful as the default matrix for transformations)
        public static Matrix4x4 Identity = new Matrix4x4(
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        );

        // Matrix multiplication
        public static Matrix4x4 Multiply(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41,
                left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42,
                left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43,
                left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44,

                left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41,
                left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42,
                left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43,
                left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44,

                left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41,
                left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42,
                left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43,
                left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44,

                left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41,
                left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42,
                left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43,
                left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44
            );
        }

        // Determinant of a 4x4 matrix (using a cofactor expansion method)
        public float Determinant()
        {
            return M11 * (M22 * (M33 * M44 - M34 * M43) - M23 * (M32 * M44 - M34 * M42) + M24 * (M32 * M43 - M33 * M42)) -
                   M12 * (M21 * (M33 * M44 - M34 * M43) - M23 * (M31 * M44 - M34 * M41) + M24 * (M31 * M43 - M33 * M41)) +
                   M13 * (M21 * (M32 * M44 - M34 * M42) - M22 * (M31 * M44 - M34 * M41) + M24 * (M31 * M42 - M32 * M41)) -
                   M14 * (M21 * (M32 * M43 - M33 * M42) - M22 * (M31 * M43 - M33 * M41) + M23 * (M31 * M42 - M32 * M41));
        }

        // Inverse of a 4x4 matrix (if determinant is non-zero)
        public Matrix4x4 Inverse()
        {
            float det = Determinant();
            if (det == 0)
                throw new InvalidOperationException("Matrix is singular and cannot be inverted.");

            float invDet = 1.0f / det;

            return new Matrix4x4(
                invDet * (M22 * (M33 * M44 - M34 * M43) - M23 * (M32 * M44 - M34 * M42) + M24 * (M32 * M43 - M33 * M42)),
                invDet * -(M12 * (M33 * M44 - M34 * M43) - M13 * (M32 * M44 - M34 * M42) + M14 * (M32 * M43 - M33 * M42)),
                invDet * (M12 * (M23 * M44 - M24 * M43) - M13 * (M22 * M44 - M24 * M42) + M14 * (M22 * M43 - M23 * M42)),
                invDet * -(M12 * (M23 * M34 - M24 * M33) - M13 * (M22 * M34 - M24 * M32) + M14 * (M22 * M33 - M23 * M32)),

                invDet * -(M21 * (M33 * M44 - M34 * M43) - M23 * (M31 * M44 - M34 * M41) + M24 * (M31 * M43 - M33 * M41)),
                invDet * (M11 * (M33 * M44 - M34 * M43) - M13 * (M31 * M44 - M34 * M41) + M14 * (M31 * M43 - M33 * M41)),
                invDet * -(M11 * (M23 * M44 - M24 * M43) - M13 * (M21 * M44 - M24 * M41) + M14 * (M21 * M43 - M23 * M41)),
                invDet * (M11 * (M23 * M34 - M24 * M33) - M13 * (M21 * M34 - M24 * M31) + M14 * (M21 * M33 - M23 * M31)),

                invDet * (M21 * (M32 * M44 - M34 * M42) - M22 * (M31 * M44 - M34 * M41) + M24 * (M31 * M42 - M32 * M41)),
                invDet * -(M11 * (M32 * M44 - M34 * M42) - M12 * (M31 * M44 - M34 * M41) + M14 * (M31 * M42 - M32 * M41)),
                invDet * (M11 * (M22 * M44 - M24 * M42) - M12 * (M21 * M44 - M24 * M41) + M14 * (M21 * M42 - M22 * M41)),
                invDet * -(M11 * (M22 * M34 - M24 * M32) - M12 * (M21 * M34 - M24 * M31) + M14 * (M21 * M32 - M22 * M31)),

                invDet * -(M21 * (M32 * M43 - M33 * M42) - M22 * (M31 * M43 - M33 * M41) + M23 * (M31 * M42 - M32 * M41)),
                invDet * (M11 * (M32 * M43 - M33 * M42) - M12 * (M31 * M43 - M33 * M41) + M13 * (M31 * M42 - M32 * M41)),
                invDet * -(M11 * (M22 * M43 - M23 * M42) - M12 * (M21 * M43 - M23 * M41) + M13 * (M21 * M42 - M22 * M41)),
                invDet * (M11 * (M22 * M33 - M23 * M32) - M12 * (M21 * M33 - M23 * M31) + M13 * (M21 * M32 - M22 * M31))
            );
        }

        // ToString override for printing matrix
        public override string ToString()
        {
            return "{M11} {M12} {M13} {M14}\n" +
                   "{M21} {M22} {M23} {M24}\n" +
                   "{M31} {M32} {M33} {M34}\n" +
                   "{M41} {M42} {M43} {M44}";
        }
    }

    public struct Plane
    {
        public Vector3 Normal;  // The normal vector to the plane
        public float D;         // The D coefficient in the equation: Ax + By + Cz + D = 0

        // Constructor to initialize the plane with a normal and a point on the plane
        public Plane(Vector3 normal, float d)
        {
            Normal = normal;
            D = d;
        }

        public Plane(float nx, float ny, float nz, float d)
        {
            Normal = new Vector3(nx, ny, nz);
            D = d;
        }

        // Constructor that takes a normal vector and a point on the plane (point P)
        public Plane(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            // Compute normal by taking the cross product of two vectors in the plane
            Vector3 v1 = point2 - point1;
            Vector3 v2 = point3 - point1;
            Normal = Vector3.Cross(v1, v2);
            Normal = Vector3.Normalize(Normal);

            // Calculate D using the formula: D = -(Ax + By + Cz)
            D = -Vector3.Dot(Normal, point1);
        }

        // Normalize the plane (adjusts the normal vector to unit length and adjusts D accordingly)
        public void Normalize()
        {
            float length = Normal.Length();
            if (length > 0)
            {
                Normal = Normal / length; // Normalize the normal vector
                D = D / length;           // Adjust D accordingly
            }
        }

        // Checks if a point (x, y, z) lies on the plane
        public bool IsPointOnPlane(Vector3 point)
        {
            return Math.Abs(Vector3.Dot(Normal, point) + D) < float.Epsilon;
        }

        // ToString override to represent the plane in string format
        public override string ToString()
        {
            return "Normal: {Normal.ToString()}, D: {D}";
        }
    }
}
