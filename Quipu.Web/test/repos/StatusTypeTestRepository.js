import { getStatusTypes } from "../utils/TestData";

const statustypes = getStatusTypes();

export default {
  get() {
    return {
      data: statustypes,
    };
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
