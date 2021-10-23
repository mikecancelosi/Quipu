import Repository from "./Repository";

const resource = "/StatusTypes";
export default {
  get() {
    return Repository.get(`${resource}`);
  },

  getById(id) {
    return Repository.get(`${resource}/${id}`);
  },

  post(payload) {
    return Repository.post(`${resource}`, payload);
  },

  put(payload) {
    return Repository.put(`${resource}`, payload);
  },
};
