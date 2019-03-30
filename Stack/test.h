#pragma once

#include "stack.h"

void create_stack_test(int value);
void delete_stack_test(stack *head);
void find_value_test(stack *head);
void push_test(stack *head, int value);
void pop_test(stack *head);
//    int flag = 1;
//    int a, b;
//    char c;
//    printf("enter string: ");
//    while(c != '\n') {
//        if (a == ' ' || b == ' ' || c == ' ') {
//            flag %= 3;
//            flag++;
//            continue;
//        }
//        switch(flag){
//            case 1:{
//                scanf("%d", &a);
//                break;
//            }
//            case 2:{
//                scanf("%d", &b);
//                break;
//            }
//            case 3:{
//                scanf("%c", &c);
//                break;
//            }
//            default:{
//                printf("flag error");
//                break;
//            }
//        }
//    }
//    push(head, a);
//    push(head, b);