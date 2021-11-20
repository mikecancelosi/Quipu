import { createStore } from "vuex";
function getInitialTestState() {
  return {
    users: [
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
    ],
    userDropdownOptions: [
      {
        label: "Test User 1",
        category: 1,
        value: {
          display_Name: "Test User 1",
          first_Name: "Test1",
          id: 1,
          last_Name: "User1",
          login: "test1",
          password: "password1",
        },
      },
      {
        label: "Test User 2",
        category: 2,
        value: {
          display_Name: "Test User 2",
          first_Name: "Test2",
          id: 2,
          last_Name: "User2",
          login: "test2",
          password: "password2",
        },
      },
      {
        label: "Test User 3",
        category: 3,
        value: {
          display_Name: "Test User 3",
          first_Name: "Test3",
          id: 3,
          last_Name: "User3",
          login: "test3",
          password: "password3",
        },
      },
    ],
  };
}

export function createTestStore() {
  const testState = getInitialTestState();
  const store = createStore({
    state: { ...testState },
  });
  return store;
}
