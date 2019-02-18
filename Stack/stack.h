#pragma once

typedef struct stack stack;
stack *create_stack(int value);
stack *push(stack *head, int value);
void delete_stack(stack *head);
stack *pop(stack *head);
int get_head_data(stack *head);
stack *find_value(stack *head, int value);