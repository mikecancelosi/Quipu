import Repository from "./Repository";

const resource = "/Projects";
export default {
    get() {
        return Repository.get(`${resource}`);
    },

    getProject(projectId) {
        return Repository.get(`${resource}/${projectId}`);
    },

    createProject(payload) {
        return Repository.post(`${resource}`, payload);
    }
}