import { getTasks } from "../utils/TestData";

const tasks = getTasks();
export default {
  async get() {
    return {
      data: tasks,
    };
  },

  getTask(id) {
    return tasks.find((task) => task.id === id);
  },

  post(payload) {
    tasks.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
