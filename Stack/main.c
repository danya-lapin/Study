#include <stdio.h>

#include "stack.h"
#include "test.h"

int main() {
    stack *head = create_stack(9);
    create_stack_test(10);
    delete_stack_test(head);
    find_value_test(head);
    push_test(head, 9);
    stack *test_head = create_stack(9);
    pop_test(test_head);
    return 0;
}