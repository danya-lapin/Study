#include <stdio.h>

#include "stack.h"
#include "test.h"

int main() {
    int err;
    int value = calculate("42 421+ 2- ", &err);
    printf("%d", value);
    return 0;
}