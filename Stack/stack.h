#pragma once

typedef struct stack stack;
stack *create_stack(int value);
<<<<<<< HEAD
stack *push(stack *head, int value);
void delete_stack(stack *head);
stack *pop(stack *head);
int get_head_data(stack *head);
stack *find_value(stack *head, int value);
=======
void push(stack *head, int value);
void delete_stack(stack *head, int value);
void pop(stack *head, int value);
>>>>>>> 83d0c64f9a7fa61f63eb8e9752fd9112c806a65d
