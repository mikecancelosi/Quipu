import { getUsers } from "../utils/TestData";
const users = getUsers();

export default {
  async get() {
    return users;
  },

  async getById(id) {
    return users.find((user) => user.id === id);
  },

  async post(payload) {
    users.push(payload);
  },

  async put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
