#include <stdio.h>
#include <stdlib.h>

#include "test.h"
#include "stack.h"

void create_stack_test(int value){
    stack *head = create_stack(value);
    int head_data = get_head_data(head);
    if((head != NULL) && (head_data == value)){
        printf("Create stack test: Ok\n");
    }
    else{
        printf("Create stack test: Fail\n");
    }
}
void delete_stack_test(stack *head){
    delete_stack(head);
    int data = get_head_data(head);
    if(data == 0){
        printf("Delete stack test: Ok\n");
    }
    else{
        printf("Delete stack test: Fail\n");
    }
}
void find_value_test(stack *head){
    int value = get_head_data(head);
    if(find_value(head, value) == head){
        printf("Find value test: OK\n");
    }
    else{
        printf("Find value test: Fail\n");
    }
}
void push_test(stack *head, int value){
    push(head, value);
    int data = get_head_data(head);
    if(data == value){
        printf("Push test: OK\n");
    }
    else{
        printf("Push test: Fail\n");
    }
}