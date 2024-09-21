
# Task Tracker CLI

  

Task Tracker CLI is a simple command-line application that allows you to add, update, mark, and delete tasks in a JSON file. The application also lets you view a list of tasks based on their status.

Sample solution for the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh/).
  
## Features

  

-  **Add Task:** Add a new task with a description and a default status of "to-do".

-  **List Tasks:** View a list of tasks based on their status ("to-do", "in progress", "done") or all tasks.

-  **Update Task:** Update the description and status of an existing task based on its ID.

-  **Mark Task Status:** Change the status of a task to "in progress" or "done" based on its ID.

-  **Delete Task:** Remove an existing task based on its ID.

  

## Usage

  

### Add Task



To add a new task, use the `add` command:

  

```bash
task-cli  add  "Task Description"  "status"
```
### List Task



To list tasks based on their status, use the `list` or `list-by-status` command. If no status is specified, it lists all tasks:
```bash
task-cli list
task-cli list-by-status "to-do"
```
### Update Task

To update the description and status of an existing task, use the `update` command:

```bash
task-cli update <id> "New Task Description" "New Status"
```
### Mark Task Status

To delete a task, use the `delete` command:
```bash
task-cli delete <id>
```
