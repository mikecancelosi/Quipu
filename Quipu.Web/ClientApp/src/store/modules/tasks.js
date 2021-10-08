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
    },

    updateTask( { commit },task) {
        TaskRepository.put(task)
            .then(instance => commit('updateTask', JSON.parse(instance.config.data)))
            .catch(errorData => alert(errorData.message));
    }
};

const mutations = {
    setTasks: (state, tasks) => { state.tasks = tasks },
    updateTask: (state, task) => {
        const index = state.tasks.findIndex(x => x.id === task.id);
        if (index !== -1) {
            state.tasks[index] = task;
        } else {
            state.tasks.push(task);
        }
    },
};

export default {
    state,
    getters,
    actions,
    mutations
};