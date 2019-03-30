#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "stack.h"
#include "test.h"
typedef struct stack{
    int data;
    struct stack *next;
}stack;

stack *create_stack(int value){
    stack *head = malloc(sizeof(stack));
    head->data = value;
    head->next = NULL;
    return head;
}

stack *push(stack *head, int value){
    if(head == NULL){
        head = create_stack(value);
    }
    if(head->next == NULL){
        stack *next = malloc(sizeof(stack));
        next->next = NULL;
        next->data = value;
        stack *tmp = malloc(sizeof(stack));
        tmp->next = head->next;
        tmp->data = head->data;
        head = next;
        head->next = tmp;
    }
    return head;
}

void delete_stack(stack *head){
    if(head == NULL){
        return;
    }
    if(head->next == NULL){
        free(head);
    }
    else{
        delete_stack(head->next);
        return;
    }

}

stack *find_value(stack *head, int value){
    if(head == NULL) {
        return NULL;
    }
    if(head->data == value) {
        return head;
    }
    else{
        return find_value(head->next, value);
    }
}

stack *pop(stack *head, int *result, int *error) {
    if (head == NULL){
        *error = 1;
        return NULL;
    } else {
        *error = 0;
    }
    *result = head->data;
    stack *next = head->next;
    free(head);
    return next;
}

int get_head_data(stack *head){
    return head->data;
}

int convert_string_to_int(const char *string)
{
    int i, sign = 1, offset, result;

    if (string[0] == '-') {
        sign = -1;
    }
    if (sign == -1) {  // Set starting position to convert
        offset = 1;
    }
    else {
        offset = 0;
    }
    result = 0;
    for (i = offset; string[i] != '\0'; i++) {
        result = result * 10 + (string[i] - '0');
    }
    if (sign == -1) {
        result = -result;
    }
    return result;
}


int calculate(char *expression, int *error)
{
    stack *head = NULL;
    int num, previous = 0;
    int i = 0;
    while (expression[i] != '\0')
    {
        char symbol = expression[i];
        char buffer[15] = {'\0'};
        switch(symbol)
        {
            case ' ':
            {
                for(int j = previous; j < i; j++)
                {
                    buffer[j] = expression[j];
                }
                num = convert_string_to_int(buffer);
                buffer[0] = '\0';
                head = push(head, num);
                previous += i;
                break;
            }
            case '+':
            {
                int a = head->data;
                int b = head->next->data;
                head = push(head, a + b);
                break;
            }
            case '*':
            {
                int a = head->data;
                int b = head->next->data;
                head = push(head, a * b);
                break;
            }
            case '/':
            {
                int a = head->data;
                int b = head->next->data;
                head = push(head, a / b);
                break;
            }
            case '-':
            {
                int a = head->data;
                int b = head->next->data;
                head = push(head, a - b);
                break;
            }
            default:
            {
                continue;
            }
        }
        i++;
    }
    if(head->next != NULL)
    {
        printf("Incorrect string ");
    }
    return head->data;
}