const taskstatuscategories = [];
export default {
  get() {
    return taskstatuscategories;
  },

  getTask(id) {
    return taskstatuscategories.find(
      (taskstatuscategory) => taskstatuscategory.id === id
    );
  },

  post(payload) {
    taskstatuscategories.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
