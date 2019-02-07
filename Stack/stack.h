#pragma once

typedef struct stack stack;
stack *create_stack(int value);
void push(stack *head, int value);
void delete_stack(stack *head, int value);
void pop(stack *head, int value);