#include "StdAfx.h"
// (c) Abyss Group
// (c) NAWE Group

Field::Field() :
    mValue(NULL), mName(NULL), mType(DB_TYPE_UNKNOWN)
{
}

Field::Field(Field &f)
{
    const char *value, *name;

    value = f.GetString();
    name = f.GetName();

    if (value && (mValue = new char[strlen(value) + 1]))
        strcpy(mValue, value);
    else
        mValue = 0;

    if (name && (mName = new char[strlen(name) + 1]))
        strcpy(mName, name);
    else
        mName = 0;

    mType = f.GetType();
}

Field::Field(const char *value, const char *name, enum Field::DataTypes type) :
    mType(type)
{
    if (value && (mValue = new char[strlen(value) + 1]))
        strcpy(mValue, value);
    else
        mValue = NULL;

    if (name && (mName = new char[strlen(name) + 1]))
        strcpy(mName, name);
    else
        mName = NULL;
}

Field::~Field()
{
    if (mValue)
        delete mValue;
    if (mName)
        delete mName;
}

void Field::SetValue(const char *value)
{
    if (mValue)
        delete mValue;
    if (value)
    {
        mValue = new char[strlen(value) + 1];
        if (mValue)
            strcpy(mValue, value);
    }
    else
        mValue = NULL;
}

void Field::SetName(const char *name)
{
    if (mName)
        delete mName;
    if (name)
    {
        mName = new char[strlen(name) + 1];
        if (mName)
            strcpy(mName, name);
    }
    else
        mName = NULL;
}
