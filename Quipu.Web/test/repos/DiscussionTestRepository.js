const discussions = [];

export default {
  get() {
    return discussions;
  },

  getById(id) {
    return discussions.find((discussion) => discussion.id === id);
  },

  post(payload) {
    discussions.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
