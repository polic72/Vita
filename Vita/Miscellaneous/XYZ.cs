using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using 
using Vita.World_;

//namespace Vita.Miscellaneous
//{
//    /// <summary>
//    /// Object representing coordinates in 3-dimensional space.
//    /// </summary>
//    /// <remarks>Usually this means a point or a vector in 3-dimensional space, depending on the actual 
//    /// use.</remarks>
//    public class XYZ : ICloneable
//    {
//        #region Properties and Fields

//        /// <summary>
//        /// The basis of the X axis.
//        /// </summary>
//        /// <remarks>The basis of the X axis is the vector (1,0,0), the unit vector on the X axis.</remarks>
//        public static XYZ BasisX = new XYZ(1, 0, 0);

//        /// <summary>
//        /// The basis of the Y axis.
//        /// </summary>
//        /// <remarks>The basis of the Y axis is the vector (0,1,0), the unit vector on the Y axis.</remarks>
//        public static XYZ BasisY = new XYZ(0, 1, 0);

//        /// <summary>
//        /// The basis of the Z axis.
//        /// </summary>
//        /// <remarks>The basis of the Z axis is the vector (0,0,1), the unit vector on the Z axis.</remarks>
//        public static XYZ BasisZ = new XYZ(0, 0, 1);

//        /// <summary>
//        /// The coordinate origin or zero vector.
//        /// </summary>
//        /// <remarks>The zero vector is (0,0,0).</remarks>
//        public static XYZ Zero = new XYZ();

//        /// <summary>
//        /// Gets the first coordinate.
//        /// </summary>
//        public double X { get; }

//        /// <summary>
//        /// Gets the second coordinate.
//        /// </summary>
//        public double Y { get; }

//        /// <summary>
//        /// Gets the third coordinate.
//        /// </summary>
//        public double Z { get; }

//        #endregion Properties and Fields


//        #region Constructors

//        /// <summary>
//        /// Creates an XYZ with the supplied coordinates.
//        /// </summary>
//        /// <param name="x">The first coordinate.</param>
//        /// <param name="y">The second coordinate.</param>
//        /// <param name="z">The third coordinate.</param>
//        /// <exception cref="ArgumentException">Thrown when setting an infinite number to the X, Y or Z 
//        /// property.</exception>
//        public XYZ(double x, double y, double z)
//        {
//            if (double.IsInfinity(x))
//            {
//                throw new ArgumentException("Cannot be an infinite value.", "x");
//            }
//            else if (double.IsInfinity(y))
//            {
//                throw new ArgumentException("Cannot be an infinite value.", "y");
//            }
//            else if (double.IsInfinity(z))
//            {
//                throw new ArgumentException("Cannot be an infinite value.", "z");
//            }

//            X = x;
//            Y = y;
//            Z = z;
//        }


//        /// <summary>
//        /// Creates a default XYZ with the values (0, 0, 0).
//        /// </summary>
//        public XYZ() : this(0, 0, 0) { }

//        #endregion Constructors


//        #region Methods

//        /// <summary>
//        /// Adds the specified vector to this vector and returns the result.
//        /// </summary>
//        /// <param name="source">The vector to add to this vector.</param>
//        /// <returns>The vector equal to the sum of the two vectors.</returns>
//        /// <remarks>The added vector is obtained by adding each coordinate of the specified vector to the 
//        /// corresponding coordinate of this vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public XYZ Add(XYZ source)
//        {
//            NullCheck(source, "source");

//            return new XYZ(X + source.X, Y + source.Y, Z + source.Z);
//        }


//        /// <summary>
//        /// Returns the angle between this vector and the specified vector projected to the specified plane.
//        /// </summary>
//        /// <param name="right">The specified vector.</param>
//        /// <param name="normal">The normal vector that defines the plane.</param>
//        /// <returns>The real number between 0 and 2*PI equal to the projected angle between the two vectors.</returns>
//        /// <remarks>The angle is projected onto the plane orthogonal to the specified normal vector, counterclockwise 
//        /// with the normal pointing upwards.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when right or normal is a null reference.</exception>
//        public double AngleOnPlaneTo(XYZ right, XYZ normal)
//        {
//            NullCheck(right, "right");
//            NullCheck(normal, "normal");

//            return CrossProduct(normal).AngleTo(right.CrossProduct(normal));
//        }


//        /// <summary>
//        /// Returns the angle between this vector and the specified vector.
//        /// </summary>
//        /// <param name="source">The specified vector.</param>
//        /// <returns>The real number between 0 and PI equal to the angle between the two vectors in 
//        /// radians.</returns>
//        /// <remarks>The angle between the two vectors is measured in the plane spanned by them.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>"
//        public double AngleTo(XYZ source)
//        {
//            NullCheck(source, "source");

//            return Math.Acos(DotProduct(source) / (GetLength() * source.GetLength()));
//        }


//        /// <summary>
//        /// The cross product of this vector and the specified vector.
//        /// </summary>
//        /// <param name="source">The vector to multiply with this vector.</param>
//        /// <returns>The vector equal to the cross product.</returns>
//        /// <remarks>The cross product is defined as the vector which is perpendicular to both vectors with a 
//        /// magnitude equal to the area of the parallelogram they span. Also known as vector product or outer 
//        /// product.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public XYZ CrossProduct(XYZ source)
//        {
//            NullCheck(source, "source");

//            return new XYZ((Y * source.Z) - (source.Y * Z), (Z * source.X) - (source.Z * X), (X * source.Y) - 
//                (source.X * Y));
//        }


//        /// <summary>
//        /// Returns the distance from this point to the specified point.
//        /// </summary>
//        /// <param name="source">The specified point.</param>
//        /// <returns>The real number equal to the distance between the two points.</returns>
//        /// <remarks>The distance between the two points is equal to the length of the vector that joins the two 
//        /// points.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public double DistanceTo(XYZ source)
//        {
//            NullCheck(source, "source");

//            return Math.Sqrt(Math.Pow(source.X - X, 2) + Math.Pow(source.Y - Y, 2) + Math.Pow(source.Z - Z, 2));
//        }


//        /// <summary>
//        /// Divides this vector by the specified value and returns the result.
//        /// </summary>
//        /// <param name="value">The value to divide this vector by.</param>
//        /// <returns>The divided vector.</returns>
//        /// <remarks>The divided vector is obtained by dividing each coordinate of this vector by the specified 
//        /// value.</remarks>
//        /// <exception cref="ArgumentException">Thrown when the specified value is an infinite number or 
//        /// zero.</exception>
//        public XYZ Divide(double value)
//        {
//            if (double.IsInfinity(value))
//            {
//                throw new ArgumentException("The value cannot be infinite.", "value");
//            }
//            else if (value == 0)
//            {
//                throw new ArgumentException("The value cannot be 0.", "value");
//            }

//            return new XYZ(X / value, Y / value, Z / value);
//        }


//        /// <summary>
//        /// The dot product of this vector and the specified vector.
//        /// </summary>
//        /// <param name="source">The vector to multiply with this vector.</param>
//        /// <returns>The real number equal to the dot product.</returns>
//        /// <remarks>The dot product is the sum of the respective coordinates of the two vectors: 
//        /// Vx*Wx + Vy*Wy + Vz*Wz. Also known as scalar product or inner product.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public double DotProduct(XYZ source)
//        {
//            NullCheck(source, "source");

//            return (X * source.X) + (Y * source.Y) + (Z * source.Z);
//        }


//        /// <summary>
//        /// Determines whether the specified Object is equal to the current Object.
//        /// </summary>
//        /// <param name="obj">The object to compare to.</param>
//        /// <returns>Whether the specified Object is equal to the current Object.</returns>
//        public override bool Equals(object obj)
//        {
//            if (obj is XYZ other)
//            {
//                if (X == other.X && Y == other.Y && Z == other.Z)
//                {
//                    return true;
//                }
//            }

//            return false;
//        }


//        /// <summary>
//        /// Determines the hash code of this XYZ object.
//        /// </summary>
//        /// <returns>The hash code of this XYZ object.</returns>
//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                int hash = 486187739;

//                hash *= 50331653 + X.GetHashCode();
//                hash *= 50331653 + Y.GetHashCode();
//                hash *= 50331653 + Z.GetHashCode();

//                return hash;
//            }
//        }


//        /// <summary>
//        /// Gets the length of this vector.
//        /// </summary>
//        /// <returns>The length of this vector.</returns>
//        /// <remarks>In 3-D Euclidean space, the length of the vector is the square root of the sum of the 
//        /// three coordinates squared.</remarks>
//        public double GetLength()
//        {
//            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
//        }


//        /// <summary>
//        /// Determines whether 2 vectors are the same within the given tolerance. (Might not be how Revit does it).
//        /// </summary>
//        /// <param name="source">The vector to compare with this vector.</param>
//        /// <param name="tolerance">The tolerance for equality check.</param>
//        /// <returns>True if the vectors are the same; otherwise, false.</returns>
//        /// <remarks>This routine uses an input tolerance to compare two vectors to see if they are almost 
//        /// equivalent. Because it is comparing two vectors the tolerance value is not in length units but 
//        /// instead represents the variation in direction between the vectors. For very small tolerance values 
//        /// it should also be possible to compare two points with this method. To compute the distance between 
//        /// two points for a comparison with a larger allowable difference, use DistanceTo(XYZ).</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        /// <exception cref="ArgumentException">Thrown when tolerance is less than 0.</exception>
//        public bool IsAlmostEqualTo(XYZ source, double tolerance)
//        {
//            NullCheck(source, "source");

//            if (tolerance < 0)
//            {
//                throw new ArgumentException("Tolerance cannot be less than 0.", "tolerance");
//            }

//            return (Math.Abs(X - source.X) < tolerance) && (Math.Abs(Y - source.Y) < tolerance) && 
//                (Math.Abs(Z - source.Z) < tolerance);
//        }


//        /// <summary>
//        /// Determines whether this vector and the specified vector are the same within the tolerance (1.0e-09). 
//        /// (Might not be how Revit does it).
//        /// </summary>
//        /// <param name="source">The vector to compare with this vector.</param>
//        /// <returns>True if the vectors are the same; otherwise, false.</returns>
//        /// <remarks>This routine uses Revit's default tolerance to compare two vectors to see if they are almost 
//        /// equivalent. Because the tolerance is small enough this can also be used to compare two 
//        /// points.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public bool IsAlmostEqualTo(XYZ source)
//        {
//            return IsAlmostEqualTo(source, 1.0E-09);
//        }


//        /// <summary>
//        /// The boolean value that indicates whether this vector is of unit length.
//        /// </summary>
//        /// <returns>Whether this vector is of unit length.</returns>
//        /// <remarks>A unit length vector has a length of one, and is considered normalized.</remarks>
//        public bool IsUnitLength()
//        {
//            return GetLength().IsAlmostEqualTo(1);
//        }


//        /// <summary>
//        /// Validates that the input point is within the given World's design limits.
//        /// </summary>
//        /// <param name="world">The world to test.</param>
//        /// <returns>True if the input point is within the given World's design limits, false otherwise.</returns>
//        /// <remarks>Used to validate input for geometry construction methods.</remarks>
//        public bool IsWithinLengthLimits(World world)
//        {
//            return (X <= world.WorldSize_X) && (Y <= world.WorldSize_Y) && (Z <= world.WorldSize_Z);
//        }


//        /// <summary>
//        /// The boolean value that indicates whether this vector is a zero vector.
//        /// </summary>
//        /// <returns>Thether this vector is a zero vector.</returns>
//        /// <remarks>The zero vector's each component is zero within the tolerance (1.0e-09).</remarks>
//        public bool IsZeroLength()
//        {
//            return IsAlmostEqualTo(Zero);
//        }


//        /// <summary>
//        /// Multiplies this vector by the specified value and returns the result.
//        /// </summary>
//        /// <param name="value">The value to multiply with this vector.</param>
//        /// <returns>The multiplied vector.</returns>
//        /// <remarks>The multiplied vector is obtained by multiplying each coordinate of this vector by the 
//        /// specified value.</remarks>
//        /// <exception cref="ArgumentException">Thrown when the specified value is an infinite number.</exception>
//        public XYZ Multiply(double value)
//        {
//            if (double.IsInfinity(value))
//            {
//                throw new ArgumentException("The value cannot be infinite.", "value");
//            }

//            return new XYZ(X * value, Y * value, Z * value);
//        }


//        /// <summary>
//        /// Negates this vector.
//        /// </summary>
//        /// <returns>The vector opposite to this vector.</returns>
//        /// <remarks>The negated vector is obtained by changing the sign of each coordinate of this 
//        /// vector.</remarks>
//        public XYZ Negate()
//        {
//            return new XYZ(-X, -Y, -Z);
//        }


//        /// <summary>
//        /// Returns a new XYZ whose coordinates are the normalized values from this vector.
//        /// </summary>
//        /// <returns>The normalized XYZ or zero if the vector is almost Zero.</returns>
//        /// <remarks>Normalized indicates that the length of this vector equals one (a unit vector).</remarks>
//        public XYZ Normalize()
//        {
//            if (IsAlmostEqualTo(Zero))
//            {
//                return Zero;
//            }

//            return this / GetLength();
//        }


//        /// <summary>
//        /// Determines whether this vector is parallel with the given vector.
//        /// </summary>
//        /// <param name="source">The given vector.</param>
//        /// <returns>True if parallel, false otherwise.</returns>
//        /// <remarks>Two vectors are parellel if there exists a constant C where a = Cb.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public bool ParallelWith(XYZ source)
//        {
//            NullCheck(source, "source");

//            return (DotProduct(this) * source).IsAlmostEqualTo(DotProduct(source) * this);
//        }


//        /// <summary>
//        /// Projects the given vector on this vector.
//        /// </summary>
//        /// <param name="source">The vector to project onto this vector.</param>
//        /// <returns>The projected vector.</returns>
//        /// <remarks>The projected vector will be in the same direction as this vector. The magnitude of the vector
//        /// will be the magnitude of the given vector in this direction.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public XYZ Project(XYZ source)
//        {
//            NullCheck(source, "source");

//            return (DotProduct(source) / source.GetLength()) * Normalize();
//        }


//        /// <summary>
//        /// Subtracts the specified vector from this vector and returns the result.
//        /// </summary>
//        /// <param name="source">The vector to subtract from this vector.</param>
//        /// <returns>The vector equal to the difference between the two vectors.</returns>
//        /// <remarks>The subtracted vector is obtained by subtracting each coordinate of the specified vector from 
//        /// the corresponding coordinate of this vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public XYZ Subtract(XYZ source)
//        {
//            NullCheck(source, "source");

//            return new XYZ(X - source.X, Y - source.Y, Z - source.Z);
//        }


//        /// <summary>
//        /// Gets formatted string showing (X, Y, Z) with values formatted to 9 decimal places.
//        /// </summary>
//        /// <returns>Formatted string showing (X, Y, Z) with values formatted to 9 decimal places.</returns>
//        public override string ToString()
//        {
//            return string.Format("({0:0.#########}, {1:0.#########}, {2:0.#########})", X, Y, Z);
//        }


//        /// <summary>
//        /// The triple product of this vector and the two specified vectors.
//        /// </summary>
//        /// <param name="middle">The second vector.</param>
//        /// <param name="right">The third vector.</param>
//        /// <returns>The real number equal to the triple product.</returns>
//        /// <remarks>The scalar triple product is defined as the dot product of one of the vectors with the cross 
//        /// product of the other two. Geometrically, this product is the (signed) volume of the parallelepiped 
//        /// formed by the three vectors given.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when middle or right is a null reference.</exception>"
//        public double TripleProduct(XYZ middle, XYZ right)
//        {
//            NullCheck(middle, "middle");
//            NullCheck(right, "right");

//            return DotProduct(middle.CrossProduct(right));
//        }


//        /// <summary>
//        /// Clones this object.
//        /// </summary>
//        /// <returns>The cloned object.</returns>
//        public object Clone()
//        {
//            return new XYZ(X, Y, Z);
//        }


//        /// <summary>
//        /// Check if the value is null. Throws exception if so.
//        /// </summary>
//        /// <param name="check">Value to check.</param>
//        /// <param name="name">the name of the value.</param>
//        private static void NullCheck(object check, string name)
//        {
//            if (check == null)
//            {
//                throw new ArgumentNullException(name);
//            }
//        }

//        #endregion Methods


//        #region Operators

//        /// <summary>
//        /// Adds the two specified vectors and returns the result.
//        /// </summary>
//        /// <param name="left">The first vector.</param>
//        /// <param name="right">The second vector.</param>
//        /// <returns>The vector equal to the sum of the two source vectors.</returns>
//        /// <remarks>The added vector is obtained by adding each coordinate of the right vector to the 
//        /// corresponding coordinate of the left vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public static XYZ operator +(XYZ left, XYZ right) => left.Add(right);


//        /// <summary>
//        /// Divides the specified vector by the specified value.
//        /// </summary>
//        /// <param name="left">The value to divide the vector by.</param>
//        /// <param name="right">The vector to divide by the value.</param>
//        /// <returns>The divided vector.</returns>
//        /// <remarks>The divided vector is obtained by dividing each coordinate of the specified vector by the 
//        /// specified value.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        /// <exception cref="ArgumentException">Thrown when the specified value is an infinite number or 
//        /// zero.</exception>
//        public static XYZ operator /(XYZ left, double right)
//        {
//            NullCheck(left, "left");

//            return left.Divide(right);
//        }


//        /// <summary>
//        /// Multiplies the specified number and the specified vector.
//        /// </summary>
//        /// <param name="left">The vector to multiply with the value.</param>
//        /// <param name="right">The value to multiply with the specified vector.</param>
//        /// <returns>The multiplied vector.</returns>
//        /// <remarks>The multiplied vector is obtained by multiplying each coordinate of the specified vector by 
//        /// the specified value.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        /// <exception cref="ArgumentException">Thrown when the specified value is an infinite number.</exception>
//        public static XYZ operator *(XYZ left, double right)
//        {
//            NullCheck(left, "left");

//            return left.Multiply(right);
//        }


//        /// <summary>
//        /// Multiplies the specified number and the specified vector.
//        /// </summary>
//        /// <param name="left">The value to multiply with the specified vector.</param>
//        /// <param name="right">The vector to multiply with the value.</param>
//        /// <returns>The multiplied vector.</returns>
//        /// <remarks>The multiplied vector is obtained by multiplying each coordinate of the specified vector by 
//        /// the specified value.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        /// <exception cref="ArgumentException">Thrown when the specified value is an infinite number.</exception>
//        public static XYZ operator *(double left, XYZ right)
//        {
//            NullCheck(right, "right");

//            return right.Multiply(left);
//        }


//        /// <summary>
//        /// Subtracts the two specified vectors and returns the result.
//        /// </summary>
//        /// <param name="left">The first vector.</param>
//        /// <param name="right">The second vector.</param>
//        /// <returns>The vector equal to the difference between the two source vectors.</returns>
//        /// <remarks>The subtracted vector is obtained by subtracting each coordinate of the right vector from the 
//        /// corresponding coordinate of the left vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when left or right is a null reference.</exception>
//        public static XYZ operator -(XYZ left, XYZ right) => left.Subtract(right);


//        /// <summary>
//        /// Negates the specified vector and returns the result.
//        /// </summary>
//        /// <param name="source">The vector to negate.</param>
//        /// <returns>The vector opposite to the specified vector.</returns>
//        /// <remarks>The negated vector is obtained by changing the sign of each coordinate of the specified 
//        /// vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when source is a null reference.</exception>
//        public static XYZ operator -(XYZ source)
//        {
//            NullCheck(source, "source");

//            return source.Negate();
//        }


//        /// <summary>
//        /// Determines whether the left XYZ is equal to the right XYZ.
//        /// </summary>
//        /// <param name="left">The first XYZ.</param>
//        /// <param name="right">The second XYZ.</param>
//        /// <returns>Whether the left XYZ is equal to the right XYZ.</returns>
//        /// <remarks>Equivalence is determined by the equivalence of each coordinate of the left and right 
//        /// vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when left or right is a null reference.</exception>
//        public static bool operator ==(XYZ left, XYZ right)
//        {
//            NullCheck(left, "left");
//            NullCheck(right, "right");

//            return (left.X == right.X) && (left.Y == right.Y) && (left.Z == right.Z);
//        }


//        /// <summary>
//        /// Determines whether the left XYZ is not equal to the right XYZ.
//        /// </summary>
//        /// <param name="left">The first XYZ.</param>
//        /// <param name="right">The second XYZ.</param>
//        /// <returns>Whether the left XYZ is not equal to the right XYZ.</returns>
//        /// <remarks>Equivalence is determined by the equivalence of each coordinate of the left and right 
//        /// vector.</remarks>
//        /// <exception cref="ArgumentNullException">Thrown when left or right is a null reference.</exception>
//        public static bool operator !=(XYZ left, XYZ right) => !(left == right);

//        #endregion Operators
//    }
//}
