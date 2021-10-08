import TaskRepository from './../../repositories/TaskRepository'

const state = {
    tasks: [],
};

const getters = {
    getTasks: (state) => state.tasks,
    getTaskByID: (state) => (id) => { return state.tasks.find(x => x.id === id) }
};

const actions = {
    async fetchTasks({ commit }) {
        const tasks = (await TaskRepository.get()).data;
        commit('setTasks', tasks);
    }
};

const mutations = {
    setTasks: (state, tasks) => { state.tasks = tasks },
};

export default {
    state,
    getters,
    actions,
    mutations
};