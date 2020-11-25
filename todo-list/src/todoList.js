export todoRecord from './todoRecord'
const List = require("collections/list");

const todoList = new class
{
    todo_list = new List();

    add(name, content){
        this.todo_list.add(new todoRecord(name, content))
    }

    constructor() { }
}