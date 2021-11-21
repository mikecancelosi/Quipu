const statustypes = [];
export default {
  get() {
    return statustypes;
  },

  getById(id) {
    return statustypes.find((statustype) => statustype.id === id);
  },

  post(payload) {
    statustypes.push(payload);
  },

  put(payload) {
    const id = payload.id;
    const match = getById(id);
    if (match !== null) {
      match = payload;
    }
  },
};
