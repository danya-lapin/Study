#include <stdio.h>
#include <stdlib.h>

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
        head->next = next;
    }
    return head->next;
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

//TODO: ERROR
stack *find_value(stack *head, int value){
    if(head == NULL) {
        return 0;
    }
    if(head->data == value) {
        return head;
    }
    else{
        return find_value(head->next, value);
    }
}


stack *pop(stack *head) {
    if (head == NULL) {
        return 0;
    }
    if (head->next == NULL) {
        free(head);
        return 0;
    }
    if (head->next->next == NULL){
        free(head->next);
    }
    else{
        return pop(head->next);
    }
    return head;
}
int get_head_data(stack *head){
    return head->data;
}