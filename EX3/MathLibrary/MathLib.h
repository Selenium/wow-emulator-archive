// (c) Abyss Group

#if !defined(MATHLIB_H)
#define MATHLIB_H

#include <math.h>
#include <memory.h>

class Vector2;
class Vector3;
class Vector4;

// Useful constants

namespace Math
{
const Float zero = 0;
const Float half = 0.5;
const Float quarter = 0.25;
const Float one = 1;
const Float two = 2;
const Float pi = (Float)3.14159265358979323846264338327950288419716939937510582;
const Float half_pi = pi * half;
const Float quarter_pi = pi * quarter;
const Float two_pi = pi * two;
const Float oo_pi = one / pi;
const Float oo_two_pi = one / two_pi;
const Float to_rad = pi / 180;
const Float to_deg = 180 / pi;
const Float epsilon = (Float)10e-6;
const Float double_epsilon = (Float)(10e-6 * two);
const Float big_epsilon = (Float)10e-6;
const Float small_epsilon = (Float)10e-2;
}

// Shared functions

template <class T>
inline T lerp(const T &v, const T &u, const Float &t);

// Vector2

class Vector2  
{
public:

	inline Vector2 &Perpendicularize()
	{
		return Set(-y, x);
	}

	Vector2 &Normalize();

	inline Float Length() const
	{
		return sqrtf(x * x + y * y);
	}

	inline Float SquareLength() const
	{
		return x * x + y * y;
	}

	inline Vector2 Perpendicular() const
	{
		return Vector2(-y, x);
	}

	inline Float Dot(const Vector2 &u) const
	{
		return x * u.x + y * u.y;
	}
	
	inline Vector2 Normal() const
	{
		return *this / Length();
	}

	Vector2 &Set(const Float *V);
	Vector2 &Set(const Float &X, const Float &Y);
	const Vector2 &operator /= (const Float &rhs);
	const Vector2 &operator *= (const Float &rhs);
	const Vector2 &operator /= (const Vector2 &rhs);
	const Vector2 &operator *= (const Vector2 &rhs);
	const Vector2 &operator -= (const Vector2 &rhs);
	const Vector2 &operator += (const Vector2 &rhs);
	
	inline Float &operator [ ] (const int &index)
	{
		return v[index];
	}

	Vector2 operator / (const Float &rhs) const;

	inline operator Float * ()
	{
		return v;
	}

	inline bool operator == (const Vector2 &rhs) const
	{
		return x == rhs.x && y == rhs.y;
	}

	inline bool operator != (const Vector2 &rhs) const
	{
		return x != rhs.x || y != rhs.y;
	}

	inline Vector2 operator - () const
	{
		return Vector2(-x, -y);
	}

	inline Vector2 operator + (const Vector2 &rhs) const
	{
		return Vector2(x + rhs.x, y + rhs.y);
	}

	inline Vector2 operator - (const Vector2 &rhs) const
	{
		return Vector2(x - rhs.x, y - rhs.y);
	}

	inline Vector2 operator * (const Vector2 &rhs) const
	{
		return Vector2(x * rhs.x, y * rhs.y);
	}

	inline Vector2 operator / (const Vector2 &rhs) const
	{
		return Vector2(x / rhs.x, y / rhs.y);
	}

	inline Vector2 operator * (const Float &rhs) const
	{
		return Vector2(x * rhs, y * rhs);
	}

	Vector2(const Float *V);
	Vector2(const Vector2 &u);
	Vector2(const Float &X, const Float &Y);
	Vector2();
	virtual ~Vector2();

	union
	{
		struct
		{
			Float x, y;
		};
		Float v[2];
	};
};

inline Vector2 operator * (const Float &lhs, const Vector2 &rhs)
{
	return Vector2(lhs * rhs.x, lhs * rhs.y);
}

inline Vector2 operator / (const Float &lhs, const Vector2 &rhs)
{
	return Vector2(lhs / rhs.x, lhs / rhs.y);
}

inline Float dot(const Vector2 &v, const Vector2 &u)
{
	return v.x * u.x + v.y * u.y;
}

inline Float norm(const Vector2 &v)
{
	return sqrtf(v.x * v.x + v.y * v.y);
}

inline Float sq_norm(const Vector2 &v)
{
	return v.x * v.x + v.y * v.y;
}

inline Vector2 perp(const Vector2 &v)
{
	return Vector2(-v.y, v.x);
}

// Vector3

class Vector3  
{
public:

	inline Vector3 Vector3::Cross(const Vector3 &u) const
	{
		return Vector3(y * u.z - z * u.y, z * u.x - x * u.z, x * u.y - y * u.x);
	}

	Vector3 &Normalize();

	inline Float Length() const
	{
		return sqrtf(x * x + y * y + z * z);
	}

	inline Float SquareLength() const
	{
		return x * x + y * y + z * z;
	}

	inline Float Dot(const Vector3 &u) const
	{
		return x * u.x + y * u.y + z * u.z;
	}

	inline Vector3 Normal() const
	{
		return *this / Length();
	}

	Vector3 &Set(const Float *V);
	Vector3 &Set(const Float &X, const Float &Y, const Float &Z);
	const Vector3 &operator /= (const Float &rhs);
	const Vector3 &operator *= (const Float &rhs);
	const Vector3 &operator /= (const Vector3 &rhs);
	const Vector3 &operator *= (const Vector3 &rhs);
	const Vector3 &operator -= (const Vector3 &rhs);
	const Vector3 &operator += (const Vector3 &rhs);

	inline Float &operator [ ] (const int &index)
	{
		return v[index];
	}

	Vector3 operator / (const Float &rhs) const;

	inline operator Float * ()
	{
		return v;
	}

	inline bool operator == (const Vector3 &rhs) const
	{
		return x == rhs.x && y == rhs.y && z == rhs.z;
	}

	inline bool operator != (const Vector3 &rhs) const
	{
		return x != rhs.x || y != rhs.y || z != rhs.z;
	}

	inline Vector3 operator - () const
	{
		return Vector3(-x, -y, -z);
	}

	inline Vector3 operator + (const Vector3 &rhs) const
	{
		return Vector3(x + rhs.x, y + rhs.y, z + rhs.z);
	}

	inline Vector3 operator - (const Vector3 &rhs) const
	{
		return Vector3(x - rhs.x, y - rhs.y, z - rhs.z);
	}

	inline Vector3 operator * (const Vector3 &rhs) const
	{
		return Vector3(x * rhs.x, y * rhs.y, z * rhs.z);
	}

	inline Vector3 operator / (const Vector3 &rhs) const
	{
		return Vector3(x / rhs.x, y / rhs.y, z / rhs.z);
	}

	inline Vector3 operator * (const Float &rhs) const
	{
		return Vector3(x * rhs, y * rhs, z * rhs);
	}

	Vector3(const Vector2 &u);
	Vector3(const Float *V);
	Vector3(const Vector3 &u);
	Vector3(const Float &X, const Float &Y, const Float &Z);
	Vector3();
	~Vector3();

	union
	{
		struct
		{
			Float x, y, z;
		};
		Float v[3];
	};
};

inline Vector3 operator * (const Float &lhs, const Vector3 &rhs)
{
	return Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
}

inline Vector3 operator / (const Float &lhs, const Vector3 &rhs)
{
	return Vector3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
}

inline Float dot(const Vector3 &v, const Vector3 &u)
{
	return v.x * u.x + v.y * u.y + v.z * u.z;
}

inline Float norm(const Vector3 &v)
{
	return sqrtf(v.x * v.x + v.y * v.y + v.z * v.z);
}

inline Float sq_norm(const Vector3 &v)
{
	return v.x * v.x + v.y * v.y + v.z * v.z;
}

inline Vector3 cross(const Vector3 &v, const Vector3 &u)
{
	return Vector3(v.y * u.z - v.z * u.y, v.z * u.x - v.x * u.z, v.x * u.y - v.y * u.x);
}

// Vector4

class Vector4  
{
public:
	Vector4 &Normalize();

	inline Float Length() const
	{
		return sqrtf(x * x + y * y + z * z + w * w);
	}

	inline Float SquareLength() const
	{
		return x * x + y * y + z * z + w * w;
	}

	inline Float Dot(const Vector4 &u) const
	{
		return x * u.x + y * u.y + z * u.z + w * u.w;
	}

	inline Vector4 Normal() const
	{
		return *this / Length();
	}

	Vector4 &Set(const Float *V);
	Vector4 &Set(const Float &X, const Float &Y, const Float &Z, const Float &W);
	const Vector4 &operator /= (const Float &rhs);
	const Vector4 &operator *= (const Float &rhs);
	const Vector4 &operator /= (const Vector4 &rhs);
	const Vector4 &operator *= (const Vector4 &rhs);
	const Vector4 &operator -= (const Vector4 &rhs);
	const Vector4 &operator += (const Vector4 &rhs);

	inline Float &operator [ ] (const int &index)
	{
		return v[index];
	}

	Vector4 operator / (const Float &rhs) const;

	inline operator Float * ()
	{
		return v;
	}

	inline bool operator == (const Vector4 &rhs) const
	{
		return x == rhs.x && y == rhs.y && z == rhs.z && w == rhs.w;
	}

	inline bool operator != (const Vector4 &rhs) const
	{
		return x != rhs.x || y != rhs.y || z != rhs.z || w != rhs.w;
	}

	inline Vector4 operator - () const
	{
		return Vector4(-x, -y, -z, -w);
	}

	inline Vector4 operator + (const Vector4 &rhs) const
	{
		return Vector4(x + rhs.x, y + rhs.y, z + rhs.z, w + rhs.w);
	}

	inline Vector4 operator - (const Vector4 &rhs) const
	{
		return Vector4(x - rhs.x, y - rhs.y, z - rhs.z, w - rhs.w);
	}

	inline Vector4 operator * (const Vector4 &rhs) const
	{
		return Vector4(x * rhs.x, y * rhs.y, z * rhs.z, w * rhs.w);
	}

	inline Vector4 operator / (const Vector4 &rhs) const
	{
		return Vector4(x / rhs.x, y / rhs.y, z / rhs.z, w / rhs.w);
	}

	inline Vector4 operator * (const Float &rhs) const
	{
		return Vector4(x * rhs, y * rhs, z * rhs, w * rhs);
	}

	Vector4(const Float *u);
	Vector4(const Vector4 &V);
	Vector4(const Float &X, const Float &Y, const Float &Z, const Float &W);
	Vector4();
	virtual ~Vector4();

	union
	{
		struct
		{
			Float x, y, z, w;
		};
		Float v[4];
	};
};

inline Vector4 operator * (const Float &lhs, const Vector4 &rhs)
{
	return Vector4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
}

inline Vector4 operator / (const Float &lhs, const Vector4 &rhs)
{
	return Vector4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
}

inline Float dot(const Vector4 &v, const Vector4 &u)
{
	return v.x * u.x + v.y * u.y + v.z * u.z + v.w * u.w;
}

inline Float norm(const Vector4 &v)
{
	return sqrtf(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w);
}

inline Float sq_norm(const Vector4 &v)
{
	return v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w;
}

#endif
