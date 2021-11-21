import { getUsers } from "../utils/TestData";
const users = getUsers();

export default {
  async get() {
    return new Promise((resolve, reject) => {
      process.nextTick(() =>
        (users?.length ?? 0) > 0
          ? resolve({ data: users })
          : reject({ error: "No users found" })
      );
    });
  },

  getById(id) {
    return users.find((user) => user.id === id);
  },

  post(payload) {
    users.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
