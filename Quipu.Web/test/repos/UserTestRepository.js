import { getUsers } from "../utils/TestData";
const users = getUsers();

export default {
  async get() {
    return {
      data: users,
    };
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
