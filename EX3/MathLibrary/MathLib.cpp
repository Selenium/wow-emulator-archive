// (c) Abyss Group

#include "MathLib.h"

// Shared functions

template <class T>
inline T lerp(const T &v, const T &u, const Float &t)
{
	return v * (1.0f - t) + u * t;
}

// Vector2

Vector2::Vector2()
{

}

Vector2::~Vector2()
{

}

Vector2::Vector2(const Float &X, const Float &Y)
:x(X), y(Y)
{

}

Vector2::Vector2(const Vector2 &u)
:x(u.x), y(u.y)
{

}

Vector2::Vector2(const Float *V)
:x(V[0]), y(V[1])
{

}

Vector2 Vector2::operator / (const Float &rhs) const
{
	Float reciprocal_rhs = 1.0f / rhs;
	return Vector2(x * reciprocal_rhs, y * reciprocal_rhs);
}

const Vector2 &Vector2::operator += (const Vector2 &rhs)
{
	x += rhs.x;
	y += rhs.y;

	return *this;
}

const Vector2 &Vector2::operator -= (const Vector2 &rhs)
{
	x -= rhs.x;
	y -= rhs.y;

	return *this;
}

const Vector2 &Vector2::operator *= (const Vector2 &rhs)
{
	x *= rhs.x;
	y *= rhs.y;

	return *this;
}

const Vector2 &Vector2::operator /= (const Vector2 &rhs)
{
	x /= rhs.x;
	y /= rhs.y;

	return *this;
}

const Vector2 &Vector2::operator *= (const Float &rhs)
{
	x *= rhs;
	y *= rhs;

	return *this;
}

const Vector2 &Vector2::operator /= (const Float &rhs)
{
	Float reciprocal_rhs = 1.0f / rhs;
	x *= reciprocal_rhs;
	y *= reciprocal_rhs;

	return *this;
}

Vector2 &Vector2::Set(const Float &X, const Float &Y)
{
	x = X;
	y = Y;

	return *this;
}

Vector2 &Vector2::Set(const Float *V)
{
	memcpy((void *)v, (void *)V, sizeof(Float) * 2);

	return *this;
}

Vector2 &Vector2::Normalize()
{
	Float reciprocal_normal = 1.0f / sqrtf(x * x + y * y);
	x *= reciprocal_normal;
	y *= reciprocal_normal;

	return *this;
}

// Vector3

Vector3::Vector3()
{

}

Vector3::~Vector3()
{

}

Vector3::Vector3(const Float &X, const Float &Y, const Float &Z)
:x(X), y(Y), z(Z)
{

}

Vector3::Vector3(const Vector3 &u)
:x(u.x), y(u.y), z(u.z)
{

}

Vector3::Vector3(const Vector2 &u)
:x(u.x), y(u.y), z(0.0f)
{

}

Vector3::Vector3(const Float *V)
:x(V[0]), y(V[1]), z(V[2])
{

}

Vector3 Vector3::operator / (const Float &rhs) const
{
	Float reciprocal_rhs = 1.0f / rhs;
	return Vector3(x * reciprocal_rhs, y * reciprocal_rhs, z * reciprocal_rhs);
}

const Vector3 &Vector3::operator += (const Vector3 &rhs)
{
	x += rhs.x;
	y += rhs.y;
	z += rhs.z;

	return *this;
}

const Vector3 &Vector3::operator -= (const Vector3 &rhs)
{
	x -= rhs.x;
	y -= rhs.y;
	z -= rhs.z;

	return *this;
}

const Vector3 &Vector3::operator *= (const Vector3 &rhs)
{
	x *= rhs.x;
	y *= rhs.y;
	z *= rhs.z;

	return *this;
}

const Vector3 &Vector3::operator /= (const Vector3 &rhs)
{
	x /= rhs.x;
	y /= rhs.y;
	z /= rhs.z;

	return *this;
}

const Vector3 &Vector3::operator *= (const Float &rhs)
{
	x *= rhs;
	y *= rhs;
	z *= rhs;

	return *this;
}

const Vector3 &Vector3::operator /= (const Float &rhs)
{
	Float reciprocal_rhs = 1.0f / rhs;
	x *= reciprocal_rhs;
	y *= reciprocal_rhs;
	z *= reciprocal_rhs;

	return *this;
}

Vector3 &Vector3::Set(const Float &X, const Float &Y, const Float &Z)
{
	x = X;
	y = Y;
	z = Z;

	return *this;
}

Vector3 &Vector3::Set(const Float *V)
{
	memcpy((void *)v, (void *)V, sizeof(Float) * 3);

	return *this;
}

Vector3 &Vector3::Normalize()
{
	Float reciprocal_normal = 1.0f / sqrtf(x * x + y * y + z * z);
	x *= reciprocal_normal;
	y *= reciprocal_normal;
	z *= reciprocal_normal;

	return *this;
}

// Vector4

Vector4::Vector4()
{

}

Vector4::~Vector4()
{

}

Vector4::Vector4(const Float &X, const Float &Y, const Float &Z, const Float &W)
:x(X), y(Y), z(Z), w(W)
{

}

Vector4::Vector4(const Vector4 &u)
:x(u.x), y(u.y), z(u.z), w(u.w)
{

}

Vector4::Vector4(const Float *V)
:x(V[0]), y(V[1]), z(V[2]), w(V[3])
{

}

Vector4 Vector4::operator / (const Float &rhs) const
{
	Float reciprocal_rhs = 1.0f / rhs;
	return Vector4(x * reciprocal_rhs, y * reciprocal_rhs, z * reciprocal_rhs, w * reciprocal_rhs);
}

const Vector4 &Vector4::operator += (const Vector4 &rhs)
{
	x += rhs.x;
	y += rhs.y;
	z += rhs.z;
	w += rhs.w;

	return *this;
}

const Vector4 &Vector4::operator -= (const Vector4 &rhs)
{
	x -= rhs.x;
	y -= rhs.y;
	z -= rhs.z;
	w -= rhs.w;

	return *this;
}

const Vector4 &Vector4::operator *= (const Vector4 &rhs)
{
	x *= rhs.x;
	y *= rhs.y;
	z *= rhs.z;
	w *= rhs.w;

	return *this;
}

const Vector4 &Vector4::operator /= (const Vector4 &rhs)
{
	x /= rhs.x;
	y /= rhs.y;
	z /= rhs.z;
	w /= rhs.w;

	return *this;
}

const Vector4 &Vector4::operator *= (const Float &rhs)
{
	x *= rhs;
	y *= rhs;
	z *= rhs;
	w *= rhs;

	return *this;
}

const Vector4 &Vector4::operator /= (const Float &rhs)
{
	Float reciprocal_rhs = 1.0f / rhs;
	x *= reciprocal_rhs;
	y *= reciprocal_rhs;
	z *= reciprocal_rhs;
	w *= reciprocal_rhs;

	return *this;
}

Vector4 &Vector4::Set(const Float &X, const Float &Y, const Float &Z, const Float &W)
{
	x = X;
	y = Y;
	z = Z;
	w = W;

	return *this;
}

Vector4 &Vector4::Set(const Float *V)
{
	memcpy((void *)v, (void *)V, sizeof(Float) * 4);

	return *this;
}

Vector4 &Vector4::Normalize()
{
	Float reciprocal_normal = 1.0f / sqrtf(x * x + y * y + z * z + w * w);
	x *= reciprocal_normal;
	y *= reciprocal_normal;
	z *= reciprocal_normal;
	w *= reciprocal_normal;

	return *this;
}

