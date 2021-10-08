import Repository from "./Repository";

const resource = "/Tasks";
export default {
    get() {
        return Repository.get(`${resource}`);
    },

    getTask(Id) {
        return Repository.get(`${resource}/${Id}`);
    },

    post(payload) {
        return Repository.post(`${resource}`, payload);
    },

    put(payload) {
        return Repository.put(`${resource}/${payload.id}`, payload);
    }
}