const projects = [];

export default {
  get() {
    return projects;
  },

  getById(id) {
    return projects.find((project) => project.id === id);
  },

  post(payload) {
    projects.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
