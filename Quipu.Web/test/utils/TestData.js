export function getUsers() {
  const users = [
    {
      display_Name: "Test User 1",
      first_Name: "Test1",
      id: 1,
      last_Name: "User1",
      login: "test1",
      password: "password1",
    },
    {
      display_Name: "Test User 2",
      first_Name: "Test2",
      id: 2,
      last_Name: "User2",
      login: "test2",
      password: "password2",
    },
    {
      display_Name: "Test User 3",
      first_Name: "Test3",
      id: 3,
      last_Name: "User3",
      login: "test3",
      password: "password3",
    },
  ];
  return users;
}

export function getTasks() {
  const tasks = [
    {
      id: 1,
      name: "Test Task 1",
      description: "Task 1 Description",
      completed: false,
      startdate: "0001-04-01T00:00:00",
      enddate: "0001-04-05T00:00:00",
      projectid: 1,
      priorityid: 1,
      statusid: 1,
      assignedtouserid: 1,
      statuscategoryid: 1,
    },
    {
      id: 2,
      name: "Test Task 2",
      description: "Task 2 Description",
      completed: false,
      startdate: "0001-05-01T00:00:00",
      enddate: "0001-05-05T00:00:00",
      projectid: 1,
      priorityid: 1,
      statusid: 1,
      assignedtouserid: 1,
      statuscategoryid: 1,
    },
    {
      id: 3,
      name: "Test Task 3",
      description: "Task 3 Description",
      completed: false,
      startdate: "0001-06-01T00:00:00",
      enddate: "0001-06-05T00:00:00",
      projectid: 1,
      priorityid: 1,
      statusid: 1,
      assignedtouserid: 1,
      statuscategoryid: 1,
    },
  ];
  return tasks;
}

export function getPriorityTypes() {
  const priorities = [
    {
      id: 1,
      name: "Priority 1",
      color: "green",
    },
    {
      id: 2,
      name: "Priority 2",
      color: "yellow",
    },
    {
      id: 3,
      name: "Priority 3",
      color: "red",
    },
  ];

  return priorities;
}

export function getStatusTypes() {
  const statuses = [
    {
      id: 1,
      name: "Status 1",
      color: "blue",
    },
    {
      id: 2,
      name: "Status 2",
      color: "purple",
    },
    {
      id: 3,
      name: "Status 3",
      color: "yellow",
    },
  ];

  return statuses;
}
