#include <stdio.h>

#include "stack.h"
#include "test.h"

int main() {
    int err;
    int value = calculate("18 3 * 10 +", &err);
    printf("%d", value);
    return 0;
}