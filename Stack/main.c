#include <stdio.h>

#include "stack.h"

int main() {
    stack *head = create_stack(10);
    push(head, 86);
    pop(head, 86);
    return 0;
}