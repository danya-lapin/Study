#include <stdio.h>

#include "stack.h"
#include "test.h"

int main() {

    int err;
    calculate("25 32 + 11 -", &err);
//    int err;
//    printf("result: %d, %d", calculate("25 32 + 11 -", &err), err);
//    return 1;
//    char expression[100] = {0};
//    printf("enter expression\n");
//    //scanf(" %s ", expression);
//    fgets(expression, 100, stdin);
//    printf("you entered: %s\n", expression);
//    int error;
//    int result = calculate(expression, &error);
//    if (!error)
//    {
//        printf("result: %d", result);
//    }
//    else {
//        printf("error");
//    }
//    return 0;
}