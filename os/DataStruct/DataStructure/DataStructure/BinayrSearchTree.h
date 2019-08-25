#pragma once

#include"BinaryTree2.h"

typedef BTData BSTData;

void BSTMakeAndInit(BTreeNode **pRoot);

BTData BSTGetNodeData(BTreeNode *bst);

void BSTInsert(BTreeNode **pRoot, BSTData data);

BTreeNode* BSTSearch(BTreeNode *bst, BSTData target);

