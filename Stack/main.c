#include <stdio.h>

#include "stack.h"
<<<<<<< HEAD
#include "test.h"

int main() {
    stack *head = create_stack(9);
    create_stack_test(10);
    delete_stack_test(head);
    find_value_test(head);
    push_test(head, 9);
    stack *test_head = create_stack(9);
    pop_test(test_head);
=======

int main() {
    stack *head = create_stack(10);
    push(head, 86);
    pop(head, 86);
>>>>>>> 83d0c64f9a7fa61f63eb8e9752fd9112c806a65d
    return 0;
}