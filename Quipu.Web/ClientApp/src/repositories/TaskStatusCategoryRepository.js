import Repository from "./Repository";

const resource = "/TaskStatusCategories";
export default {
    get() {
        return Repository.get(`${resource}`);
    },

    getTaskStatusCategory(projectId) {
        return Repository.get(`${resource}/${projectId}`);
    },

    createTaskStatusCategory(payload) {
        return Repository.post(`${resource}`, payload);
    }
}