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
    else if(head->next == NULL){
        stack *next = malloc(sizeof(stack));
        next->next = NULL;
        next->data = value;
        stack *tmp = malloc(sizeof(stack));
        tmp->next = head->next;
        tmp->data = head->data;
        head = next;
        head->next = tmp;
    }
    else{
        return push(head->next, value);
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

int is_operation(char symbol){
    if(!(symbol >= '0' && symbol <= '9')){
        return 1;
    }
    return 0;
}

void string_check(stack *head, char symbol){
    if(head->next == NULL && is_operation(symbol) == 1){
        printf("Incorrect string");
        exit(0);
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
    if (sign == -1) {
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


int calculate(char *expression, int *error) {
    stack *head = NULL;
    int num;
    int i = 0, j = 0;
    char buffer[15] = {0};
    while (expression[i] != '\0') {
        char symbol = expression[i];
        if (i == 0 && is_operation(symbol) == 1) {
            printf("incorrect string");
            exit(0);
        }
        if((is_operation(symbol) == 1) || symbol == ' '){
            j = 0;
            num = convert_string_to_int(buffer);
            if(buffer[0] != '\0'){
                head = push(head, num);
            }
            buffer[0] = '\0';
//            for (int k = 0; k < 15; k++) {
//                buffer[k] = 0;
//            }
            switch (symbol) {
                case '+': {
                    string_check(head, symbol);
                    int a, b;
                    head = pop(head, &a, error);
                    head = pop(head, &b, error);
                    head = push(head, a + b);
                    break;
                }
                case '*': {
                    string_check(head, symbol);
                    int a, b;
                    head = pop(head, &a, error);
                    head = pop(head, &b, error);
                    head = push(head, a * b);
                    break;
                }
                case '/': {
                    string_check(head, symbol);
                    int a, b;
                    head = pop(head, &a, error);
                    head = pop(head, &b, error);
                    if (a > b) {
                        head = push(head, a / b);
                    } else {
                        head = push(head, b / a);
                    }
                    break;
                }
                case '-': {
                    string_check(head, symbol);
                    int a, b;
                    head = pop(head, &a, error);
                    head = pop(head, &b, error);
                    if (a > b) {
                        head = push(head, a - b);
                    } else {
                        head = push(head, b - a);
                    }
                    break;
                }
                default: {
                    break;
                }
            }
        }
        if (symbol >= '0' && symbol <= '9') {
            buffer[j] = symbol;
        }
        i++;
        if (symbol != ' ') {
            j++;
        }
    }
    if (head->next != NULL || head == NULL) {
        printf("Incorrect string");
        exit(0);
    }
    return head->data;
}