import { RepositoryFactory } from "src/repositories/RepositoryFactory";
const TaskRepository = RepositoryFactory.get("tasks");

const state = {
  tasks: [],
};

const getters = {
  getTasks: (state) => state.tasks,
  getTaskByID: (state) => (id) => {
    return { ...state.tasks.find((x) => x.id === id) };
  },
  getTasksByProjectID: (state) => (projectid) => {
    return state.tasks.filter((task) => task.projectID === projectid);
  },
  getTasksByTaskStatusCategoryID: (state) => (taskstatuscategoryid) => {
    return state.tasks.filter(
      (task) => task.statusCategoryID === taskstatuscategoryid
    );
  },
};

const actions = {
  async fetchTasks({ commit }) {
    const tasks = (await TaskRepository.get()).data;
    commit("setTasks", tasks);
  },

  async updateTask({ commit }, task) {
    if (task.id !== undefined && task.id !== 0) {
      return TaskRepository.put(task)
        .then((instance) => {
          commit("updateTask", JSON.parse(instance.config.data));
        })
        .catch((errorData) => alert(errorData.message));
    } else {
      return TaskRepository.post(task)
        .then((instance) => {
          commit("updateTask", instance.data);
        })
        .catch((errorData) => alert(errorData.message));
    }
  },
};

const mutations = {
  setTasks: (state, tasks) => {
    state.tasks = tasks;
  },
  updateTask: (state, task) => {
    const index = state.tasks.findIndex((x) => x.id === task.id);
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
  mutations,
};
