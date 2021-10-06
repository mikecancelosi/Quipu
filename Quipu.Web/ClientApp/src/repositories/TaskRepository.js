import Repository from "./Repository";

const resource = "/Tasks";
export default {
    get() {
        return Repository.get(`${resource}`);
    },

    getTask(projectId) {
        return Repository.get(`${resource}/${projectId}`);
    },

    createTask(payload) {
        return Repository.post(`${resource}`, payload);
    },

    updateTask(payload) {
        return Repository.put(`${resource}`, payload);
    }
}