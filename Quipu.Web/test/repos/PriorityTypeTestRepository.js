const prioritytypes = [];
export default {
  get() {
    return prioritytypes;
  },

  getById(id) {
    return prioritytypes.find((prioritytype) => prioritytype.id === id);
  },

  post(payload) {
    prioritytypes.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
