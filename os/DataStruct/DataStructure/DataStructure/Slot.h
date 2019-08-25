#pragma once

#include"Person.h"

typedef int Key;
typedef Person *Value;

enum SlotStaus{EMPTY,DELETED,INUSE};

typedef struct _slot
{
	Key key;
	Value val;
	enum SlotStaus status;
}Slot;