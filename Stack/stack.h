#pragma once

typedef struct stack stack;
stack *create_stack(int value);
stack *push(stack *head, int value);
void delete_stack(stack *head);
stack *pop(stack *head, int *result, int *error);
int get_head_data(stack *head);
stack *find_value(stack *head, int value);
int calculate(char *expression, int *error);
int convert_string_to_int(const char *string);